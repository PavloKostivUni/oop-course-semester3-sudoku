using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class UserLogoutUI : IUserInterface
    {
        private readonly IUserService userService;
        public UserLogoutUI(IUserService userService)
        {
            this.userService = userService;
        }

        public void Execute()
        {
            userService.LogoutUser();
        }

        public string CommandInfo()
        {
            return "Вийти з акаунту";
        }
    }
}
