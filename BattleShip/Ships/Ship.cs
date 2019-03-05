using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {

        public String Name { get; set; }
        public int Width { get; set; }
        public int Hits { get; set; }
        public Type Type { get; set; }
        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }

    }
}
