using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game()
        {
            Player1 = new Player("Player 1");
            Player2 = new Player("Player 2");

            //place ships on the board

            //print player 1 place ship
            Player1.PlaceShips();
            //print player 2 place ship
            Player2.PlaceShips();

        }

        public void PlayOneRound()
        {

            var coordinates = Player1.Attack();
            Player2.ProcessAttack(coordinates);

            //possible that all player 2 ships have been sunk before player 2 launches an attack
            if(!Player2.hasLost)
            {
                coordinates = Player2.Attack();
                Player1.ProcessAttack(coordinates);
            }

        }

        public void KeepOnPlaying()
        {
            //keep on playing until someone loses
            while (!Player1.hasLost && !Player2.hasLost)
            {
                PlayOneRound();
            }

            //repeatedly call play until one of the player loses
            if (Player1.hasLost)
            {
                //player 2 wins
            }
            else
            {
                //player 1 wins
            }
        }
        
    }
}
