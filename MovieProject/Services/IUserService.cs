using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrentUserAsync(HttpContext httpContext);
    }
}
