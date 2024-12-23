using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.SudokuLogic
{
    public static class Sudoku
    {
        public static Cell[,] board = new Cell[9, 9];

        public static bool Play()
        {
            GenerateBoard(board);
            FillBoard();
            DeleteRandCells(board, 1);
            return RunGame();
        }

        private static Cell[,] GenerateBoard(Cell[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = new Cell(0, true);
                }
            }

            return board;
        }

        public static bool RunGame()
        {

            while (true)
            {
                Console.Clear();

                PrintBoard(board);

                int row;
                Console.WriteLine("Введiть номер рядка, який хочете змiнити");
                if (!int.TryParse(Console.ReadLine(), out row) || row < 1 || row > 9)
                {
                    Console.WriteLine("Некоректний ввiд, введiть число вiд 1 до 9");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                int col;
                Console.WriteLine("Введiть номер стовпця, який хочете змiнити");
                if (!int.TryParse(Console.ReadLine(), out col) || col < 1 || col > 9)
                {
                    Console.WriteLine("Некоректний ввiд, введiть число вiд 1 до 9");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (board[row - 1, col - 1].isSystemGenerated)
                {
                    Console.WriteLine("Ця комiрка створена системою!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                int inputNum;
                Console.WriteLine("Введiть число, яке хочете додати в комiрку");
                if (!int.TryParse(Console.ReadLine(), out inputNum) || inputNum < 1 || inputNum > 9)
                {
                    Console.WriteLine("Некоректний ввiд, введiть число вiд 1 до 9");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                board[row - 1, col - 1].value = inputNum;


                bool isFilled = true;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i, j].value == 0)
                        {
                            isFilled = false;
                            break;
                        }
                    }
                }

                if (isFilled)
                {
                    Console.WriteLine("Введiть 'yes', якщо хочете закiнчити гру:");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "yes")
                    {
                        return CheckEndGame();
                    }
                }

            }
        }

        public static Cell[,] FillBoard()
        {
            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                FillBoardRow(board, i, 0);
            }

            return board;
        }

        private static bool FillBoardRow(Cell[,] board, int row, int col)
        {
            if (col == 9) return true;
            Random random = new Random();

            if (board[row, col].value == 0)
            {
                int randomNumber = random.Next(1, 10);
                for (int i = 0; i < 9; i++)
                {
                    if (randomNumber == 9) randomNumber = 1;
                    else randomNumber++;

                    if (NumFits(board, row, col, randomNumber))
                    {
                        board[row, col].value = randomNumber;
                        if (FillBoardRow(board, row, col + 1))
                        {
                            return true;
                        }
                        board[row, col].value = 0;
                    }
                }
            }
            else FillBoardRow(board, row, col + 1);

            return false;
        }

        private static bool NumFits(Cell[,] board, int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != col && board[row, i].value == num) return false;
                if (i != row && board[i, col].value == num) return false;
            }

            int startRow = row / 3 * 3;
            int startCol = col / 3 * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int currentRow = startRow + i;
                    int currentCol = startCol + j;

                    if (currentRow == row && currentCol == col) continue;
                    if (board[currentRow, currentCol].value == num) return false;
                }
            }

            return true;
        }
        private static void DeleteRandCells(Cell[,] board, int delCellsPerBlock)
        {
            Random random = new Random();

            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    int removedCells = 0;
                    while (removedCells < delCellsPerBlock)
                    {
                        int row = i + random.Next(0, 3);
                        int col = j + random.Next(0, 3);

                        if (board[row, col].value != 0)
                        {
                            board[row, col].value = 0;
                            board[row, col].isSystemGenerated = false;
                            removedCells++;
                        }
                    }
                }
            }
        }
        public static void PrintBoard(Cell[,] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!board[row, col].isSystemGenerated)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (board[row, col].value == 0) Console.Write(". ");
                        else Console.Write(board[row, col].value + " ");
                        Console.ResetColor();
                        continue;
                    }            
                    else Console.Write(board[row, col].value + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool CheckEndGame()
        {
            Console.Clear();
            PrintCheckedBoard(board);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!NumFits(board, i, j, board[i, j].value))
                    {
                        Console.WriteLine("Ви програли!");
                        return false;
                    }
                }
            }

            Console.WriteLine("Ви виграли!");
            return true;
        }
        private static void PrintCheckedBoard(Cell[,] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!board[row, col].isSystemGenerated)
                    {
                        if (!NumFits(board, row, col, board[row, col].value))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(board[row, col].value + " ");
                        Console.ResetColor();
                        continue;
                    }
                    else Console.Write(board[row, col].value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
