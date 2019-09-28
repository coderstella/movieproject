using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movieproject.Areas.Identity.Extention;
using movieproject.Data;
using movieproject.Models;

[assembly: HostingStartup(typeof(movieproject.Areas.Identity.IdentityHostingStartup))]
namespace movieproject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MovieContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MovieContextConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MovieContext>()
                .AddDefaultTokenProviders();

                services.ConfigureApplicationCookie(options => 
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.ReturnUrlParameter = "ReturnUrl";
                    options.AccessDeniedPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                });

                services.AddTransient<IEmailSender, CustomEmailSender>();

                services.Configure<IdentityOptions>(options =>
                {
                    // Password setting
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout setting
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User setting
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;
                });
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(
                        o => o.LoginPath = new PathString("/Identity/Account/Login")
                    );                
            });
        }
    }
}