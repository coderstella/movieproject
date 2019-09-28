using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync(HttpContext httpContext)
        {
            var currentUserId = await _userRepository.GetCurrentUser(httpContext);

            return currentUserId;
        }
    }
}
