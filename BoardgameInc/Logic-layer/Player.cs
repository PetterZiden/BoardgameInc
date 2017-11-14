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

        public Player(string n)
        {
            this.name = n;
        }

        public abstract String getShotLoc();
        


        public void getShotFeedback(int hitmarker)
        {

        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String n)
        {
            this.name = n;
        } 
    }

}
