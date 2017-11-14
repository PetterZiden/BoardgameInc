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

        public String getShotLoc()
        {
            Console.WriteLine(name + " Enter grid location to shoot at:");
            String gridLoc = Console.ReadLine();
            return gridLoc;
        }

        public void getShotFeedback(int hitmarker)
        {

        }

    }
}
