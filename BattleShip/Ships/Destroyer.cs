using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ships
{
    public class Destroyer : Ship
    {

        public Destroyer()
        {
            name = "Destroyer";
            width = 3;
            type = Type.Destroyer;
        }

    }
}
