using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        // create properties
        public string PlayerToken { get; set; } // used to keep the playertoken X || O
        public bool Over { get; set; } // hold the value for if the game is over or not
        public int Turn { get; set; } // keeps the number of turns played 

        // create the 2 dimensional array to hold the game board
        string[,] board = new string[3,3];
        
        // Constructor to create the game board
        public TicTacToe()
        {
            board = new string[,] { { "1", "2", "3" }, 
                                    { "4", "5", "6" }, 
                                    { "7", "8", "9" }};
            // I set the token to O at creation but then at start its set to X.
            // I was struggling to find a better way to set so that X always started and that
            // the players took turn afterwards. 
            PlayerToken = "O"; 
        }

        // Draw out the game board on screen. Showing all empty and taken slots.
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

        // Let the player make a move
        public void PlayerMove()
        {
            bool answer = false;

            // loop until the player gives a valid input
            while (!answer)
            {
                // I used ReadKey(true) to minimize the keypresses needed to make a move. 
                // (true) also to prevent the keystroke to be written to screen
                string playerChoice = Console.ReadKey(true).KeyChar.ToString();

                // I was thinking of naming the variables to row & column. 
                // But read that the namestandard for 2 dimensional arrays are i, j
                // So i went with that instead. 

                // Loop thru each row
                for (int i = 0; i < 3; i++)
                {
                    // Loop thru each column
                    for (int j = 0; j < 3; j++)
                    {
                        // If the players choice match the value on that slot and is not taken already by X or O
                        if (board[i, j] == playerChoice && (board[i, j] != "X" || board[i, j] != "O"))
                        {
                            board[i, j] = PlayerToken; // Set the token to the current player's
                            Turn++; // Increment the turn (counter runs up to 9 which mean a draw occured)
                            answer = true; 
                            return; // break out of the method and go back to the game.
                        }                        
                    }
                }
                // If the user fails to make a valid choice.
                if (!answer)
                {
                    // Draw the board again and write out a red message 
                    // Asking the user to make a new choice
                    DrawBoard();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid move!");
                    Console.ResetColor();
                    Console.Write($"Try again Player {PlayerToken}: ");
                }
            }

        }

        // Check who is playing now if its the current player, change to the other one.
        // This is why i started with player O in the constructor, it gets changed to X and after the loop works.
        public void NextPlayer()
        {
            if (PlayerToken == "O")
            {
                PlayerToken = "X";
            }
            else PlayerToken = "O";
        }

        // Method to check if the player made a winning move
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
