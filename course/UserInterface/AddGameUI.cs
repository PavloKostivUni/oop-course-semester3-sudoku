using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course.UserInterface
{
    public class AddGameUI : IUserInterface
    {
        private readonly IGameService gameService;
        private readonly IUserService userService;
        public AddGameUI(IGameService gameService, IUserService userService)
        {
            this.gameService = gameService;
            this.userService = userService;
        }
        public void Execute()
        {
            if(userService.LoggedInUser == null)
            {
                Console.WriteLine("Спочатку увiйдуть в акаунт");
                return;
            }

            int rating = 0;
            
            Console.WriteLine("Введiть рейтинг гри: "); ;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 0)
            {
                Console.WriteLine("Введiть додатнє цiле число");
            }
            
            PlayGame.PlaySudoku(userService.LoggedInUser, rating, gameService);
        }
        public string CommandInfo()
        {
            return "Запустити гру";
        }
    }
}
