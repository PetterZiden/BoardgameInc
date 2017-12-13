using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Data_layer
{
    class LoadObject
    {

        public List<int> playerOneGrid;
        public List<int> playerTwoGrid;
        public List<Ship> playerOneShips;
        public List<Ship> playerTwoShips;
        public String playerOneName;
        public String playerTwoName;
        public int activePlayer;
        public int playerAmount;
        public List<Boolean> aiPlayerGrid;
        public List<int> mediumPriority;
        public List<int> highPriority;

        public LoadObject(List<int> p1Grid, List<int> p2Grid, List<Ship> p1Ships, List<Ship> p2Ships, String p1Name, String p2Name, int active, int amount, List<Boolean> aiGrid, List<int> mediumPrio, List<int> highPrio) {

            playerOneGrid = p1Grid;
            playerTwoGrid = p2Grid;
            playerOneShips = p1Ships;
            playerTwoShips = p2Ships;
            playerOneName = p1Name;
            playerTwoName = p2Name;
            activePlayer = active;
            playerAmount = amount;
            aiPlayerGrid = aiGrid;
            mediumPriority = mediumPrio;
            highPriority = highPrio;

        }
    }
}
