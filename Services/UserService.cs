using Microsoft.AspNetCore.Identity;
using VitzShop.Data;

namespace VitzShop.Services
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
