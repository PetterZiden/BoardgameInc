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

        public String checkHit(String loc) {
            return "";
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
