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
        public String getShotLoc()
        {
            Console.WriteLine(name + " Enter grid location to shoot at:");
            String gridLoc = Console.ReadLine();
            return gridLoc;
        }

        override
        public void getShotFeedback(int hitmarker, String gridLoc)
        {
        }

    }
}
