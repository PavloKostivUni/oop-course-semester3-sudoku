using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class RegisterUserUI : IUserInterface
    {
        private readonly IGameService gameService;
        private readonly IUserService userService;

        public RegisterUserUI(IGameService gameService, IUserService userService)
        {
            this.gameService = gameService;
            this.userService = userService;
        }
        public void Execute()
        {
            if (userService.LoggedInUser != null)
            {
                Console.WriteLine("Спочатку вийдiть з акаунту");
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

            if (userService.GetUserByUserName(username) != null)
            {
                Console.WriteLine("Користувач з таким iменем вже iснує");
                return;
            }

            userService.RegisterUser(username, password);
        }
        public string CommandInfo()
        {
            return "Зареєструвати користувача";
        }

    }
}
