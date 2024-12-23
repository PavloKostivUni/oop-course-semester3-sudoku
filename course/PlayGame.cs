using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;
using course.SudokuLogic;

namespace course
{
    public static class PlayGame
    {
        public static void PlaySudoku(User player, int rating, IGameService gameService)
        {
            if (Sudoku.Play())
            {
                Game game = new Game(player, true, rating);
                gameService.AddGame(game);
            }
            else
            {
                Game game = new Game(player, false, rating);
                gameService.AddGame(game);
            }
        }
    }
}
