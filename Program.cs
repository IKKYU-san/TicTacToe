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
                if (game.PlayerToken == "O")
                {
                    game.PlayerToken = "X";
                }
                else game.PlayerToken = "O";


                game.DrawBoard();
                Console.Write($"Player {game.PlayerToken} Move: ");
                game.PlayerMove();
            }
            while (!game.CheckWin());

            game.DrawBoard();
            Console.WriteLine($"Player {game.PlayerToken} wins!");
        }

    }
}
