using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Coordinate
    {

        public int Row { get; set; }

        public int Column { get; set; }

        public Coordinate(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

    }
}
