using Microsoft.AspNetCore.Identity;
using VitzShop.Core.Entities;

namespace VitzShop.Infrastructure.Services
{
    public class UserService
    {
        UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> manager)
        {
            _userManager = manager;
        }

        public UserManager<ApplicationUser> GetManager()
        {
            return _userManager;
        }

    }
}
