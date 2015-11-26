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
            game.PlayerToken = "X";

            do {
                game.DrawBoard();

                Console.Write($"Player {game.PlayerToken} Move: ");
                game.PlayerMove();

                if (game.CheckWin())
                {
                    Console.WriteLine($"Player {game.PlayerToken} wins!");
                    
                }

            } 
            while (!game.CheckWin());
        }
    }
}
