using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.Repositories
{
    public interface IGameRepository
    {
        void AddGame(Game game);
        List<Game> GetAllGames();
        Game? GetGameByGameID(int gameID);
    }
}
