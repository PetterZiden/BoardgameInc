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

        public LogicController(int pa, String n)
        {
            player1 = new HumanPlayer(n);
            player2 = new AIPlayer("AI");
            playerAmount = pa;
        }

        public LogicController(int pa, String n1, String n2)
        {
            player1 = new HumanPlayer(n1);
            player2 = new HumanPlayer(n2);
            playerAmount = pa;
        }

        public void GameLoop()
        {

            player2.placeShips(new int[] { 2, 3, 4 });
            List<Ship> ships = new List<Ship>();
            ships.Add(new Ship(2, new List<String>(new String[]{ "A3", "A4" })));
            ships.Add(new Ship(3, new List<String>(new String[]{ "C3", "C4", "C5" })));
            ships.Add(new Ship( 4, new List<String>(new String[]{ "E5", "E6", "E7", "E8" })));
            PlayField playfield1 = new PlayField(ships);

            ships = new List<Ship>();
            ships.Add(new Ship(2, new List<String>(new String[]{ "A3", "A4" })));
            ships.Add(new Ship(3, new List<String>(new String[]{ "C3", "C4", "C5" })));
            ships.Add(new Ship(4, new List<String>(new String[]{ "E5", "E6", "E7", "E8" })));
            PlayField playfield2 = new PlayField(ships);

            String input;
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

    }
}
