using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Game
    {
        public User player { get; set; }
        public bool isWinner {  get; set; }

        public int rating { get; }

        public int gameID;
        private static int gameIDSeed = 12345678;

        public Game(User player, bool isWinner, int rating)
        {
            this.player = player;
            this.isWinner = isWinner;
            this.rating = rating;
            gameID = gameIDSeed;
            gameIDSeed++;
        }
    }
}
