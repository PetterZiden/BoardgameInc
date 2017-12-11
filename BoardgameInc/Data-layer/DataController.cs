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
        SaveBroker sBroker;
        LoadBroker lBroker;

        public DataController()
        {
            sBroker = new SaveBroker();
            lBroker = new LoadBroker();
        }

        public void save(Player player1, Player player2, int activePlayer, int playerAmount)
        {
            if (playerAmount == 1)
            {
                sBroker.saveToXML(player1.getPlayfield().getGrid(), player2.getPlayfield().getGrid(), player1.getPlayfield().getShips(), player2.getPlayfield().getShips(), player1.getName(), player2.getName(), activePlayer, player2.getAIGrid(), player2.getMediumPriority(), player2.getHighPriority());
            }
            else
            {
                sBroker.saveToXML(player1.getPlayfield().getGrid(), player2.getPlayfield().getGrid(), player1.getPlayfield().getShips(), player2.getPlayfield().getShips(), player1.getName(), player2.getName(), activePlayer);
            }
        }

        public List<Player> load()
        {
            LoadObject loaded = lBroker.loadFromXML();
            List<Player> players = new List<Player>();
            players.Add(new HumanPlayer(loaded.p1Name, new PlayField(loaded.playerOneShips, loaded.p1Name, loaded.playerOneGrid)));
            if(loaded.playerAmount == 1)
            {
                players.Add(new AIPlayer(loaded.p2Name, new PlayField(loaded.playerTwoShips, loaded.p2Name, loaded.playerTwoGrid), loaded.aiGrid, loaded.mediumPrio, loaded.highPrio));
            }
            else
            {
                players.Add(new HumanPlayer(loaded.p2Name, new PlayField(loaded.playerTwoShips, loaded.p2Name, loaded.playerTwoGrid)));
            }

            return players;

        } 
    }
}
