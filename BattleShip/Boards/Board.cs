using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        private const int SIZE = 10; 

        public List<Panel> panels { get; set; }

        public Board()
        {
            for(int i = 1; i <= SIZE; i++)
            {
                for(int j = 1; j <= SIZE; j++)
                {
                    panels.Add(new Panel(i, j));
                }

            }
        }

    }
}
