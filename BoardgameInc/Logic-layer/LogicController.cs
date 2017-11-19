using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    class LogicController
    {

        public static void GameLoop() {

            List<Ship> ships = new List<Ship>();
            ships.Add(new Ship("Small", 2, new List<String>(new String[]{ "A3", "A4" })));
            ships.Add(new Ship("Medium", 3, new List<String>(new String[]{ "C3", "C4", "C5" })));
            ships.Add(new Ship("Large", 4, new List<String>(new String[]{ "E5", "E6", "E7", "E8" })));
            Console.WriteLine("Enter player name for Player 1");
            String name1 = Console.ReadLine();
            Player player1 = new HumanPlayer(name1);
            PlayField playfield1 = new PlayField(ships);
            Console.WriteLine("Enter player name for Player 2");
            String name2 = Console.ReadLine();

            Console.WriteLine("Choose 1 or 2 human players");
            int playerType = Console.Read();
            Player player2;
            if (playerType == 1)
            {
                player2 = new AIPlayer(name2);
            }
            else {
                player2 = new HumanPlayer(name2);
            }
            ships = new List<Ship>();
            ships.Add(new Ship("Small", 2, new List<String>(new String[]{ "A3", "A4" })));
            ships.Add(new Ship("Medium", 3, new List<String>(new String[]{ "C3", "C4", "C5" })));
            ships.Add(new Ship("Large", 4, new List<String>(new String[]{ "E5", "E6", "E7", "E8" })));
            PlayField playfield2 = new PlayField(ships);
            String input;
            int hitMarker;
            while(true) {
                input = player1.getShotLoc();
                hitMarker = playfield2.checkHit(input);
                player1.getShotFeedback(hitMarker);
                if(!playfield2.getShipsLeft()) {

                    break;
                    }
                input = player2.getShotLoc();
                hitMarker = playfield1.checkHit(input);
                player2.getShotFeedback(hitMarker);
                if (!playfield1.getShipsLeft()) {

                    break;
                    }
            }
            }

    }
}
