using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {

        public String name { get; set; }
        public int width { get; set; }
        public int hits { get; set; }
        public Type type { get; set; }
        public bool isSunk
        {
            get
            {
                return hits >= width;
            }
        }

    }
}
