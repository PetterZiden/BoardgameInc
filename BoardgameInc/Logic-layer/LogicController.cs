using BoardgameInc.UI_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
   public class LogicController
    {
        Player player1;
        Player player2;
        int playerAmount;
        UIController ui;

        public LogicController()
        {
           
        }


        public void GameLoop()
        {

            PlayField playfield1 = new PlayField(player1.placeShips(new int[] { 2, 3, 4 }));
            PlayField playfield2 = new PlayField(player2.placeShips(new int[] { 2, 3, 4 }));

            int input;
            int hitMarker;
            while(true) {
                input = player1.getShotLoc();
                hitMarker = playfield2.checkHit(input);
                player1.getShotFeedback(hitMarker, input);
                printOutput(hitMarker);
                if(!playfield2.getShipsLeft()) {

                    break;
                    }
                input = player2.getShotLoc();
                hitMarker = playfield1.checkHit(input);
                player2.getShotFeedback(hitMarker, input);
                printOutput(hitMarker);
                if (!playfield1.getShipsLeft()) {

                    break;
                    }
            } 
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
