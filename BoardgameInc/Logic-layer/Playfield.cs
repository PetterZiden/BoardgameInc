using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{


    public class PlayField
    {
        private List<Ship> ships;
        private List<int> grid;
        private int shipsLeft;
        private string name;

        public PlayField(List<Ship> s, string n) {
            this.ships = s;
            shipsLeft = 3;
            name = n;
            grid = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                grid.Add(0);
            }
        }

        ~PlayField()
        {
        }

        public int checkHit(int loc) {
            Console.WriteLine(loc);

            for (int i = 0; i < ships.Count; i++) {
                int checkIfHit = ships[i].checkHit(loc);
                if (checkIfHit >= 0)
                {
                    grid[loc] = 2;
                    if (checkIfHit == 0)
                    {
                        ships.RemoveAt(i);
                        shipsLeft--;
                    }
                    return checkIfHit;
                }
                else
                {
                    grid[loc] = 1;
                }

            }
            return -1;

        }

        public List<Ship> getShips()
        {
            return this.ships;
        }

        public void setShips(List<Ship> s)
        {
            this.ships = s;
        }

        public Boolean getShipsLeft()
        {
            if (shipsLeft > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getShipsLeftInt() {
            return shipsLeft;
        }

        public void setShipsLeft(int i)
        {
            this.shipsLeft = i;
        }

        public List<int> getGrid()
        {
            return grid;
        }

        public string getName()
        {
            return name;
        }

        public void setName(String n){
            name = n;
        }       
    }
}
