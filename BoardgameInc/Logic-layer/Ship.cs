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
        private List<int> gridLocs;

        public Ship(int s, List<int> gl)
        {
            this.size = s;
            gridLocs = new List<int>();
            this.gridLocs = gl;
        }

        ~Ship()
        {
        }

        public int checkHit(int loc)
        {
            foreach(int i in gridLocs)
            {
                if (loc == i)
                {
                    gridLocs.Remove(i);
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

        public List<int> getGridlocs()
        {
            return this.gridLocs;
        }

        public void setGridlocs(List<int> s)
        {
            this.gridLocs = s;
        }

    }
}
