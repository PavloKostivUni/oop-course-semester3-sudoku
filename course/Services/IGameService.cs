using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.Services
{
    public interface IGameService
    {
        void AddGame(Game game);
        List<Game> GetAllGames();
        Game? GetGameByGameID(int gameID);
    }
}
