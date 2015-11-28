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
            game.PlayerToken = "O";

            do
            {
                game.NextPlayer();
                game.DrawBoard();
                Console.Write($"Player {game.PlayerToken} Move: ");
                game.PlayerMove();

                if (game.CheckWin())
                {
                    game.DrawBoard();
                    Console.WriteLine($"Player {game.PlayerToken} wins!");
                    game.Over = true;
                }
                else if (game.Turn == 9)
                {
                    game.DrawBoard();
                    Console.WriteLine("It's a Draw!");
                    game.Over = true;
                }
            }
            while (!game.Over);
        }

    }
}
