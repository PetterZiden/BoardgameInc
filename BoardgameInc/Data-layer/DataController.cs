using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Data_layer
{
    public class DataController
    {
        SaveBroker saveBroker;

        public DataController()
        {
            saveBroker = new SaveBroker();
        }

        public void save(Player player1, Player player2, int activePlayer, int playerAmount)
        {
            if (playerAmount == 1)
            {
                saveBroker.saveToXML(player1.getPlayfield().getGrid(), player2.getPlayfield().getGrid(), player1.getPlayfield().getShips(), player2.getPlayfield().getShips(), player1.getName(), player2.getName(), activePlayer, player2.getAIGrid(), player2.getMediumPriority(), player2.getHighPriority());
            }
            else
            {
                saveBroker.saveToXML(player1.getPlayfield().getGrid(), player2.getPlayfield().getGrid(), player1.getPlayfield().getShips(), player2.getPlayfield().getShips(), player1.getName(), player2.getName(), activePlayer);
            }
        }
    }
}
