using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Battleship Game");

            Game game = new Game();
            game.KeepOnPlaying();

            Console.ReadKey();
        }
    }
}
