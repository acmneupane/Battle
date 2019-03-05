using BattleShip.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {

        public String name { get; set; }
        public Board Board { get; set; }
        public List<Ship> ships { get; set; }
        public bool hasLost
        {
            get
            {
                return ships.All(x => x.isSunk);
            }
        }

        public Player(String name)
        {
            this.name = name;
            Board = new Board();
            ships = new List<Ship>()
            {
                new Submarine(),
                new Cruise(),
                new Destroyer(),
                new FighterShip()
            };
        }

        public void PlaceShips()
        {
            foreach (var ship in ships)
            {
                var isPlaced = false; //to check if the ship is placed or not
                while (!isPlaced)
                {
                    //print the ship name ask player to enter coordinates to start placing ship
                    int startRow = Int32.Parse(Console.ReadLine());
                    int startColumn = Int32.Parse(Console.ReadLine());
                    
                    int endRow = startRow;
                    int endColumn = startColumn;


                    //ask player if ship is to be placed horizontally or vertically (0 for Horizontal and 1 for vertical)
                    int orientation = Int32.Parse(Console.ReadLine());

                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.width; i++)
                            endRow++;
                    }
                    else
                    {
                        for (int i = 1; i < ship.width; i++)
                            endColumn++;
                    }

                    //as ships need to be placed only inside the box, check boundaries of the board
                    if (endRow > 10 || endColumn > 10)
                    {
                        isPlaced = false;
                        //print the ships are outside the boundaries and again ask for new coordinates
                        continue; //restart the while loop
                    }

                    //check if any panels is occupied by any other ship
                    var newPanels = Board.panels.Where(x => x.coordinates.row >= startRow
                                    && x.coordinates.column >= startColumn
                                    && x.coordinates.row <= endRow
                                    && x.coordinates.column <= endColumn).ToList();

                    var occupied = newPanels.Any(x => !x.IsShipOccupied());

                    if(occupied)
                    {
                        isPlaced = false;
                        continue;
                    }

                    foreach(var panel in newPanels)
                    {
                        panel.type = ship.type;
                    }

                    isPlaced = true;

                }

            }
        }

        public Coordinate Attack()
        {
            Coordinate coord;
            //ask for row and column to attack from the user, 2,2 by default
            int row = Int32.Parse(Console.ReadLine());
            int column = Int32.Parse(Console.ReadLine());
            coord = new Coordinate(row, column);
            return coord;
        }

        public void ProcessAttack(Coordinate coord)
        {
            var panel = Board.panels.FirstOrDefault(x => x.coordinates.row == coord.row && x.coordinates.column == coord.column);

            //if panel is not occupied, call it a miss
            if(!panel.IsShipOccupied())
            {
                //print Miss
                panel.type = Type.Miss;
            }

            //print Hit
            //panel occupied, get the ship that is in the panel
            var ship = ships.FirstOrDefault(x => x.type == panel.type);

            ship.hits++; //increment hits counter for ship

            //check if the ship is sunk
            if(ship.isSunk)
            {
                //Print The Ship is sunk
            }

        }
    }
}
