using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    public class Ship
    {

        private int size;
        private List<String> gridLocs;

        public Ship(int s, List<String> gl)
        {
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
