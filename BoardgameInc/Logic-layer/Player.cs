using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{

    public class Player
    {
        private String name;
        private PlayField type;

        public Player(string n, PlayField t){
            this.name = n;
            this.type = t;
        }
    }

}
