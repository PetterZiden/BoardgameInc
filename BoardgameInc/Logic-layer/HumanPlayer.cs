using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    class HumanPlayer : Player
    {
        public HumanPlayer(String n)
            :base(n)
        {

        }

        ~HumanPlayer()
        {
        }

            override
            public List<Ship> placeShips(int[] shipSizes)
        {
            List<Ship> ships = new List<Ship>();
            for(int i = 0; i < shipLocs.Count; i++)
            {
                ships.Add(new Ship(shipSizes[i], shipLocs[i]));
            }
            return ships;
        }

        override
        public int getShotLoc()
        {
            return 0;
        }

        override
        public void getShotFeedback(int hitmarker, int gridLoc)
        {
        }

    }
}
