using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using movieproject.Database;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace movieproject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(MovieContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetCurrentUser(HttpContext httpContext)
        {
            if(!string.IsNullOrEmpty(httpContext.User.Identity.Name))
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == httpContext.User.Identity.Name);
                return currentUser;
            }

            return null;
        }
    }
}
