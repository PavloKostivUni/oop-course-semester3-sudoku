using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.Repositories
{
    public class GameRepository : IGameRepository
    {
        public DbContext Context { get; set; }
        public GameRepository(DbContext Context)
        {
            this.Context = Context;
        }

        public void AddGame(Game game)
        {
            Context.Games.Add(game);
        }
        public List<Game> GetAllGames()
        {
            List<Game> AllGames = Context.Games;
            return AllGames;
        }
        public Game? GetGameByGameID(int gameID)
        {
            foreach (Game game in Context.Games)
            {
                if (game.gameID == gameID) return game;
            }
            return null;
        }
    }
}
