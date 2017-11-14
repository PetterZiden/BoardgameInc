using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    class Ship
    {

        private String type;
        private int size;
        private List<String> gridLocs;

        public Ship(String t, int s, List<String> gl)
        {
            this.type = t;
            this.size = s;
            gridLocs = new List<String>();
            this.gridLocs = gl;
        }

        ~Ship()
        {
        }

        public int checkHit(String loc)
        {
            foreach(String s in gridLocs)
            {
                if (loc.Equals(s))
                {
                    gridLocs.Remove(s);
                    return gridLocs.Count;
                }
            }
            return -1;
            
        }

        public String getType()
        {
            return this.type;
        }

        public void setType(String s)
        {
            this.type = s;
        }

        public int getSize()
        {
            return this.size;
        }

        public void setSize(int i)
        {
            this.size = i;
        }

        public List<String> getGridlocs()
        {
            return this.gridLocs;
        }

        public void setGridlocs(List<String> s)
        {
            this.gridLocs = s;
        }

    }
}
