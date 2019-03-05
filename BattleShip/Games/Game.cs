using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {

        public Player player1 { get; set; }
        public Player player2 { get; set; }

        public Game()
        {
            player1 = new Player("Player 1");
            player2 = new Player("Player 2");

            //place ships on the board

            //print player 1 place ship
            player1.PlaceShips();
            //print player 2 place ship
            player2.PlaceShips();

        }

        public void PlayOneRound()
        {

            var coordinates = player1.Attack();
            player2.ProcessAttack(coordinates);

            //possible that all player 2 ships have been sunk before player 2 launches an attack
            if(!player2.hasLost)
            {
                coordinates = player2.Attack();
                player1.ProcessAttack(coordinates);
            }

        }

        public void KeepOnPlaying()
        {
            //keep on playing until someone loses
            while (!player1.hasLost && !player2.hasLost)
            {
                PlayOneRound();
            }

            //repeatedly call play until one of the player loses
            if (player1.hasLost)
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
