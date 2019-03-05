using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Panel
    {

        public Coordinate coordinates { get; set; }

        public Type type { get; set; }

        public Panel(int row, int column)
        {
            coordinates = new Coordinate(row, column);
            type = Type.Empty;
        }

        public bool IsShipOccupied()
        {
            return type == Type.Cruise || 
                   type == Type.Destroyer || 
                   type == Type.Fightership || 
                   type == Type.Submarine;
        }

        public string Status()
        {
            return type.ToString();
        }

    }
}
