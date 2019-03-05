using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ships
{
    public class FighterShip : Ship
    {

        public FighterShip()
        {
            name = "Fightership";
            width = 2;
            type = Type.Fightership;
        }

    }
}
