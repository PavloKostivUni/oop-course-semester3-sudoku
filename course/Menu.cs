using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;
using course.UserInterface;

namespace course
{
    public class Menu
    {
        private readonly GameService gameService;
        private readonly UserService userService;

        private List<IUserInterface> publicMenuList;
        private List<IUserInterface> hiddenMenuList;

        public Menu(GameService gameService, UserService userService)
        {
            this.gameService = gameService;
            this.userService = userService;

            publicMenuList = new List<IUserInterface>();
            publicMenuList.Add(new RegisterUserUI(gameService, userService));
            publicMenuList.Add(new UserLoginUI(userService));

            hiddenMenuList = new List<IUserInterface>();
            hiddenMenuList.Add(new AddGameUI(gameService, userService));
            hiddenMenuList.Add(new DisplayAllGamesUI(gameService));
            hiddenMenuList.Add(new DisplayAllUsersUI(userService));
            hiddenMenuList.Add(new GetUserStatsUI(gameService, userService));
            hiddenMenuList.Add(new UserLogoutUI(userService));
        }

        public void Display()
        {
            List<IUserInterface> menuList;
            while (true)
            {
                if (userService.LoggedInUser == null)
                {
                    menuList = publicMenuList;
                }
                else
                {
                    menuList = hiddenMenuList;
                }

                for (int i = 0; i < menuList.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + menuList[i].CommandInfo());
                }
                Console.WriteLine(menuList.Count + 1 + ". Вийти з програми");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= menuList.Count + 1 && choice >= 1)
                {
                    if (choice == menuList.Count + 1) return;
                    menuList[choice - 1].Execute();
                }
                else
                {
                    Console.WriteLine("Некоректний ввiд, введiть номер вiд 1 до " + (menuList.Count + 1));
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

    }
}
