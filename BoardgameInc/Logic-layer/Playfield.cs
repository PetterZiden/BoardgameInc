using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
 

    class PlayField
    {
        private List<Ship> ships;
        private int shipsLeft;

        public PlayField(List<Ship> s) {
            this.ships = s;
            shipsLeft = 3;
        }

        ~PlayField()
        {
        }

       public int checkHit(int loc) {

            for (int i = 0; i < ships.Count; i++) {
                int checkIfHit = ships[i].checkHit(loc);
                if (checkIfHit >= 0)
                {
                    if (checkIfHit == 0)
                    {
                        ships.RemoveAt(i);
                        shipsLeft--;
                    }
                    return checkIfHit;
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
            if(shipsLeft > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setShips(int i)
        {
            this.shipsLeft = i;
        }
    }
}
