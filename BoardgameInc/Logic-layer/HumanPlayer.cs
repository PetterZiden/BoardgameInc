﻿using System;
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

        public HumanPlayer(String n, PlayField pf)
            :base(n, pf)
        {

        }

        ~HumanPlayer()
        {
        }

            override
            public void placeShips(int[] shipSizes)
        {
            List<Ship> ships = new List<Ship>();
            for(int i = 0; i < shipLocs.Count; i++)
            {
                ships.Add(new Ship(shipSizes[i], shipLocs[i]));
            }
            playfield = new PlayField(ships, this.name);
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
