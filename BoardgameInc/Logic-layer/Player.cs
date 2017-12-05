using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{

    public abstract class Player
    {
        protected String name;
        protected List<List<int>> shipLocs;
        protected PlayField playfield;

        public Player(string n)
        {
            this.name = n;
            shipLocs = new List<List<int>>();
        }

        public abstract void placeShips(int[] shipSizes);
        public abstract int getShotLoc();
        public abstract void getShotFeedback(int hitmarker, int gridLoc);
        
        public String getName()
        {
            return this.name;
        }

        public void setName(String n)
        {
            this.name = n;
        }
        
        public void setShipLoc(List<int> locs)
        {
            shipLocs.Add(locs);
        }

        public PlayField getPlayfield()
        {
            return playfield;
        }
    }

}
