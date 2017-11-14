using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    public class AIPlayer : Player
    {
        public AIPlayer(String n)
            :base(n)
        {

        }

        ~AIPlayer()
        {
        }
        override
        public String getShotLoc()
        {
            return null;
        }

        public void getShotFeedback(int hitmarker)
        {

        }

    }
}

