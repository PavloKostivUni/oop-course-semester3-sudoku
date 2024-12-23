using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Repositories;

namespace course.Services
{
    public class GameService : IGameService
    {
        public IGameRepository Repository { get; set; }
        public GameService(IGameRepository Repository)
        {
            this.Repository = Repository;
        }

        public void AddGame(Game game)
        {
            if (Repository.GetGameByGameID(game.gameID) != null)
            {
                throw new Exception("Гра з цим ID вже iснує");
            }
            Repository.AddGame(game);
            if (game.isWinner)
            {
                game.player.ChangeRating(game.rating);
            }
            else
            {
                game.player.ChangeRating(-game.rating);
            }
        }

        public List<Game> GetAllGames()
        {
            return Repository.GetAllGames();
        }
        public Game? GetGameByGameID(int gameID)
        {
            return Repository.GetGameByGameID(gameID);
        }
    }
}
