using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class DisplayAllGamesUI : IUserInterface
    {
        private readonly IGameService gameService;

        public DisplayAllGamesUI(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public void Execute()
        {
            var games = gameService.GetAllGames();

            if (games.FirstOrDefault() == null)
            {
                Console.WriteLine("Iгор немає!");
                return;
            }

            string playerStatus;
            foreach (var game in games)
            {
                if (game.isWinner)
                {
                    playerStatus = "Виграв";
                }
                else
                {
                    playerStatus = "Програв";
                }

                Console.WriteLine("Гравець: '" + game.player.UserName + "'; статус: '" + playerStatus + "'; рейтинг: " + game.rating);
            }
        }

        public string CommandInfo()
        {
            return "Вивести всi iгри";
        }
    }
}
