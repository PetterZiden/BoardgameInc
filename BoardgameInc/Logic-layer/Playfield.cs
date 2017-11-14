using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
 

    class PlayField
    {
        private Ship[] ships;
        private int shipsLeft;

        public PlayField(Ship[] s, int sl) {
            this.ships = s;
            this.shipsLeft = sl;
        }

        ~PlayField()
        {
        }

       public Boolean checkHit(String loc) {

            for (int i = 0; i < ships.Length; i++) {
                int checkIfHit = ships[i].checkHit(loc);
                if (checkIfHit >= 0)
                {
                    if (checkIfHit == 0)
                    {
                        //ta bort ship
                    }
                    return true;
                }
                else {
                    return false;
                }
            }
            return false;

        }

        public Ship[] getShips()
        {
            return this.ships;
        }

        public void setShips(Ship[] s)
        {
            this.ships = s;
        }

        public int getShipsLeft()
        {
            return this.shipsLeft;
        }

        public void setShips(int i)
        {
            this.shipsLeft = i;
        }
    }
}
