using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Panel
    {

        public Coordinate Coordinates { get; set; }

        public Type Type { get; set; }

        public Panel(int row, int column)
        {
            Coordinates = new Coordinate(row, column);
            Type = Type.Empty;
        }

        public bool IsShipOccupied
        {
            get
            {
                return Type == Type.Cruise ||
                       Type == Type.Destroyer ||
                       Type == Type.Fightership ||
                       Type == Type.Submarine;

            }
        }

        public string Status
        {
            get
            {
                return Type.ToString();
            }
        }

    }
}
