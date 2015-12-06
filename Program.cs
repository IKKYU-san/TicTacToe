using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            
            do
            {
                game.NextPlayer(); // Check who plays next and set that players token X || O
                game.DrawBoard(); // Draw the game board
                Console.Write($"Player {game.PlayerToken} Move: "); 
                game.PlayerMove(); // Ask the player for input [1-9] and place token on that square.

                if (game.CheckWin()) // After each turn check if someone won the game
                {
                    game.DrawBoard(); // Draw the board again
                    Console.WriteLine($"Player {game.PlayerToken} wins!");
                    game.Over = true; 
                }
                // If no one won, check if there been 9 turns. 
                // If so all empty slots on the boards are full and its a draw
                else if (game.Turn == 9) 
                {
                    game.DrawBoard();
                    Console.WriteLine("It's a Draw!");
                    game.Over = true;
                }
            }
            while (!game.Over); // Continue as long as the game is not won or a draw.
        }

    }
}
