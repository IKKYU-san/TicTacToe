using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        public string PlayerToken { get; set; }
        public bool Over { get; set; }
        public int Turn { get; set; }

        string[,] board = new string[3,3];
        
        public TicTacToe()
        {
            board = new string[,] { { "1", "2", "3" }, 
                                    { "4", "5", "6" }, 
                                    { "7", "8", "9" }};
            PlayerToken = "O";
        }

        public void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("     |     |");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("     |     |");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |");
            Console.WriteLine();
        }

        public void PlayerMove()
        {
            bool answer = false;

            while (!answer)
            {
                string playerChoice = Console.ReadKey(true).KeyChar.ToString();

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == playerChoice && (board[i, j] != "X" || board[i, j] != "O"))
                        {
                            board[i, j] = PlayerToken;
                            Turn++;
                            answer = true;
                            return;
                        }                        
                    }
                }

                if (!answer)
                {
                    DrawBoard();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid move!");
                    Console.ResetColor();
                    Console.Write($"Try again Player {PlayerToken}: ");
                }
            }

        }

        public void NextPlayer()
        {
            if (PlayerToken == "O")
            {
                PlayerToken = "X";
            }
            else PlayerToken = "O";
        }

        public bool CheckWin()
        {
            // Check diagonally from upper left corner to lower right
            if (board[0, 0] == PlayerToken && board[1,1] == PlayerToken && board [2,2] == PlayerToken)
            {
                return true;
            }
            // Check diagonally from lower left corner to upper right corner
            if (board[2, 0] == PlayerToken && board[1, 1] == PlayerToken && board[0, 2] == PlayerToken)
            {
                return true;
            }
            // Check horizontally from top left corner to upper right corner
            if (board[0, 0] == PlayerToken && board[0, 1] == PlayerToken && board[0, 2] == PlayerToken)
            {
                return true;
            }
            // Check horizontally from middle left to middle right
            if (board[1, 0] == PlayerToken && board[1, 1] == PlayerToken && board[1, 2] == PlayerToken)
            {
                return true;
            }
            // Check horizontally from bottom left corner to bottom right corner
            if (board[2, 0] == PlayerToken && board[2, 1] == PlayerToken && board[2, 2] == PlayerToken)
            {
                return true;
            }

            // Check vertically from top left corner to bottom left corner
            if (board[0, 0] == PlayerToken && board[1, 0] == PlayerToken && board[2, 0] == PlayerToken)
            {
                return true;
            }
            // Check vertically from top middle to bottom middle
            if (board[0, 1] == PlayerToken && board[1, 1] == PlayerToken && board[2, 1] == PlayerToken)
            {
                return true;
            }
            // Check vertically from top right corner to bottom right corner
            if (board[0, 2] == PlayerToken && board[1, 2] == PlayerToken && board[2, 2] == PlayerToken)
            {
                return true;
            }

            return false;
        }
    }
}
