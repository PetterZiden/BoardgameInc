﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{



    class LogicController
    {

        private Player[] players;

        public LogicController(Player[] p)
        {
            this.players = p;
        }

        ~LogicController()
        {
        }

        public Player[] getPlayers()
        {
            return this.players;
        }

        public void setPlayers(Player[] p)
        {
            this.players = p;
        }
    }
}