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
        private String[] gridLocs;

        public Ship(String t, int s, String[] gl)
        {
            this.type = t;
            this.size = s;
            this.gridLocs = gl;
        }

        ~Ship()
        {
        }

        public int checkHit(String loc)
        {
            return 0;
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

        public String[] getGridlocs()
        {
            return this.gridLocs;
        }

        public void setGridlocs(String[] s)
        {
            this.gridLocs = s;
        }

    }
}
