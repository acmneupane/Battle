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

        public List<Panel> Panels { get; set; }

        public Board()
        {
            Panels = new List<Panel>();
            for(int i = 1; i <= SIZE; i++)
            {
                for(int j = 1; j <= SIZE; j++)
                {
                    var newth = new Panel(i, j);
                    Panels.Add(newth);
                }

            }
        }

    }
}
