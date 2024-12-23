using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class GetUserStatsUI : IUserInterface
    {
        private readonly IGameService gameService;
        private readonly IUserService userService;
        public GetUserStatsUI(IGameService gameService, IUserService userService)
        {
            this.gameService = gameService;
            this.userService = userService;
        }

        public void Execute()
        {
            Console.WriteLine("Введiть iм'я користувача: ");
            string? username = Console.ReadLine();
            User? user = userService.GetUserByUserName(username);
            if (user == null)
            {
                Console.WriteLine("Користувача не знайдено");
                return;
            }

            string result;
            StringBuilder stats = new StringBuilder(string.Format("{0,-18} {1,-15} {2,-15}\n", "|Результат гри", "|Рейтинг гри", "|Iндекс гри"));

            List<Game> AllGames = gameService.GetAllGames();
            foreach (var game in AllGames)
            {
                if (user != game.player)
                {
                    continue;
                }

                if (game.isWinner) result = "Виграш";
                else result = "Програш";

                stats.AppendLine(string.Format("{0,-18} {1,-15} {2,-15}", "|" + result, "|" + game.rating, "|" + game.gameID));

            }

            Console.WriteLine(stats.ToString());
        }

        public string CommandInfo()
        {
            return "Вивести статистику користувача";
        }
    }
}
