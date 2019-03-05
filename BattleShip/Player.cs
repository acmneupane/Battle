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

        public String Name { get; set; }
        public Board Board { get; set; }
        public List<Ship> Ships { get; set; }
        public bool hasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(String name)
        {
            this.Name = name;
            Board = new Board();
            Ships = new List<Ship>()
            {
                new Submarine(),
                new Cruise(),
                new Destroyer(),
                new FighterShip()
            };
        }

        public void PlaceShips()
        {
            foreach (var ship in Ships)
            {
                //to check if the ship is placed or not
                var isPlaced = false; 
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
                        for (int i = 1; i < ship.Width; i++)
                            endRow++;
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                            endColumn++;
                    }

                    //as ships need to be placed only inside the box, check boundaries of the board
                    if (endRow > 10 || endColumn > 10)
                    {
                        isPlaced = false;
                        //print the ships are outside the boundaries and again ask for new coordinates
                        continue;
                        //restart the while loop
                    }

                    //check if any panels is occupied by any other ship
                    var newPanels = Board.Panels.Where(x => x.Coordinates.Row >= startRow
                                    && x.Coordinates.Column >= startColumn
                                    && x.Coordinates.Row <= endRow
                                    && x.Coordinates.Column <= endColumn).ToList();

                    var occupied = newPanels.Any(x => x.IsShipOccupied);

                    if(occupied)
                    {
                        isPlaced = false;
                        continue;
                    }

                    foreach(var panel in newPanels)
                    {
                        panel.Type = ship.Type;
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
            var panel = Board.Panels.FirstOrDefault(x => x.Coordinates.Row == coord.Row && x.Coordinates.Column == coord.Column);

            //if panel is not occupied, call it a miss
            if(!panel.IsShipOccupied)
            {
                //print Miss
                panel.Type = Type.Miss;
            }
            else
            {
                //print Hit

                //panel occupied, get the ship that is in the panel
                var ship = Ships.FirstOrDefault(x => x.Type == panel.Type);

                ship.Hits++; //increment hits counter for ship

                //check if the ship is sunk
                if (ship.IsSunk)
                {
                    //Print The Ship is sunk
                }

            }

        }
    }
}
