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
        PlayField playfield1;
        PlayField playfield2;
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
            ui.updateGrid(activePlayfield.getGrid());

        }

        public void shotInput(int input)
        {
            int hitMarker = activePlayfield.checkHit(input);
            activePlayer.getShotFeedback(hitMarker, input);
            List<int> grid = activePlayfield.getGrid();
            activePlayfield = activePlayer.getPlayfield();
            if (activePlayer == player1)
            {
                activePlayer = player2; 
            }
            else
            { 
                activePlayer = player1; 
            }
            ui.updateGrid(grid);
            Thread.Sleep(3000);
            ui.updateGrid(activePlayfield.getGrid());
            if (activePlayer.GetType() == typeof(AIPlayer))
            {
                Thread.Sleep(1000);
                shotInput(activePlayer.getShotLoc());
            }
            
            
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
