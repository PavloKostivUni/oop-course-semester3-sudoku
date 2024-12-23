using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class UserLoginUI : IUserInterface
    {
        private readonly IUserService userService;
        public UserLoginUI(IUserService userService) {
            this.userService = userService;
        }

        public void Execute()
        {
            if (userService.LoggedInUser != null)
            {
                Console.WriteLine("Ви вже увiйшли в акаунт");
                return;
            }

            Console.WriteLine("Введiть iм'я користувача: ");
            string? username = Console.ReadLine();
            if (username == "")
            {
                Console.WriteLine("Iм'я користувача не може бути пустим");
            }

            Console.WriteLine("Введiть пароль: ");
            string? password = Console.ReadLine();
            while (password.Length < 8)
            {
                Console.WriteLine("Пароль повинен мати мiнiмум 8 символiв");
                Console.WriteLine("Спробуйте знову:");
                password = Console.ReadLine();
            }

            userService.LoginUser(username, password);
        }

        public string CommandInfo()
        {
            return "Вхiд в акаунт";
        }
    }
}
