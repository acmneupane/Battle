using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Coordinate
    {

        public int row { get; set; }

        public int column { get; set; }

        public Coordinate(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

    }
}
