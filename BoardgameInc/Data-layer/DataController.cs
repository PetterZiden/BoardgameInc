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

        public List<Player> load(LogicController lc)
        {
            LoadObject loaded = lBroker.loadFromXML();
            List<Player> players = new List<Player>();
            players.Add(new HumanPlayer(loaded.playerOneName, new PlayField(loaded.playerOneShips, loaded.playerOneName, loaded.playerOneGrid)));
            Console.WriteLine("Player amount: " + loaded.playerAmount);
            if (loaded.playerAmount == 1)
            {
                players.Add(new AIPlayer(loaded.playerTwoName, new PlayField(loaded.playerTwoShips, loaded.playerTwoName, loaded.playerTwoGrid), loaded.aiPlayerGrid, loaded.mediumPriority, loaded.highPriority));
            }
            else
            {
                players.Add(new HumanPlayer(loaded.playerTwoName, new PlayField(loaded.playerTwoShips, loaded.playerTwoName, loaded.playerTwoGrid)));
            }

            lc.setGameInfo(loaded.activePlayer, loaded.playerAmount);
            
            return players; 

        } 
    }
}
