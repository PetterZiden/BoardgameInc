using BoardgameInc.UI_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BoardgameInc.Logic_layer
{
   public class LogicController
    {
        Player player1;
        Player player2;
        Player activePlayer;
        PlayField activePlayfield;
        UIController ui;

        public LogicController()
        {
           
        }


        public void StartGame()
        {

            player1.placeShips(new int[] { 2, 3, 4 });
            player2.placeShips(new int[] { 2, 3, 4 });
            activePlayer = player1;
            activePlayfield = player2.getPlayfield();
            ui.updateGrid(activePlayfield.getGrid(), activePlayfield.getName());

        }

        public void shotInput(int input)
        {
            int hitMarker = activePlayfield.checkHit(input);
            activePlayer.getShotFeedback(hitMarker, input);
            //ui.updateGrid(activePlayfield.getGrid(), activePlayfield.getName());
            firstPause();
            activePlayfield = activePlayer.getPlayfield();
            if (activePlayer == player1)
            {
                Console.WriteLine("Player 1 to Player 2");
                activePlayer = player2;
                
            }
            else
            {
                Console.WriteLine("Player 2 to Player 1");
                activePlayer = player1; 
            }
            ui.setActivePlayer(activePlayer);
            secondPause();
            if (activePlayer.GetType() == typeof(AIPlayer))
            {
                shotInput(activePlayer.getShotLoc());
            }
        }

        private async void firstPause()
        {
            ui.updateGrid(activePlayfield.getGrid(), activePlayfield.getName());
            await Task.Delay(2000);

        }

        private async void secondPause()
        {
            await Task.Delay(2000);
            ui.updateGrid(activePlayfield.getGrid(), activePlayfield.getName());


        }

        public List<int> getActivePlayfield()
        {
            return activePlayfield.getGrid();
        }

        private static void printOutput(int hitMarker)
        {
            if(hitMarker > 0)
            {
                Console.WriteLine("HIT!");
            }
            else if(hitMarker == 0)
            {
                Console.WriteLine("HIT! SHIP DESTROYED!");
            }
            else
            {
                Console.WriteLine("MISS!");
            }
        }

        public void setUIController(UIController c)
        {
            ui = c;
        } 

        public void setPlayers(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            
        }

    }
}
