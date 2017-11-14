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

           
            Ship ship1 = new Ship("Small", 2, new List<String>(new String[]{ "A3", "A4" }));
            Ship ship2 = new Ship("Medium", 3, new List<String>(new String[]{ "C3", "C4", "C5" }));
            Ship ship3 = new Ship("Large", 4, new List<String>(new String[]{ "E5", "E6", "E7", "E8" }));
            Ship [] ships = new Ship[3] {ship1, ship2, ship3};
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
            ship1 = new Ship("Small", 2, new List<String>(new String[]{ "A3", "A4" }));
            ship2 = new Ship("Medium", 3, new List<String>(new String[]{ "C3", "C4", "C5" }));
            ship3 = new Ship("Large", 4, new List<String>(new String[]{ "E5", "E6", "E7", "E8" }));
            ships = new Ship[3] {ship1, ship2, ship3};
            PlayField playfield2 = new PlayField(ships);
            String input;
            while(true) {
                input = player1.getShotLoc();
                playfield2.checkHit(input);
                if(playfield2.getShipsLeft()) {

                    break;
                    }
                input = player2.getShotLoc();
                playfield1.checkHit(input);
                if(playfield1.getShipsLeft()) {

                    break;
                    }
            }
            }

    }
}
