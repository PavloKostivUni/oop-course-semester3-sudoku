using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class DisplayAllUsersUI : IUserInterface
    {
        private readonly IUserService userService;

        public DisplayAllUsersUI(IUserService userService)
        {
            this.userService = userService;
        }
        public void Execute()
        {
            var users = userService.GetAllUsers();

            if (users.FirstOrDefault() == null)
            {
                Console.WriteLine("Гравцiв немає!");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine("Iм'я граця: '" + user.UserName + "'; рейтинг: " + user.Rating);
            }
        }

        public string CommandInfo()
        {
            return "Вивести всiх користувачiв";
        }
    }
}
