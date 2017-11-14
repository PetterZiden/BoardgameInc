using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{



    class LogicController
    {

        private Player[] players;

        static void Main(String[] args) {

           
            Console.WriteLine("Enter player name for Player 1");
            String name1 = Console.ReadLine();
            Player player1 = new HumanPlayer(name1);
            Console.WriteLine("Enter player name for Player 2");
            String name2 = Console.ReadLine();

            Console.WriteLine("Choose 1 or 2 human players");
            int playerType = Console.Read();
            if (playerType == 1)
            {
                Player player2 = new AIPlayer(name2);
            }
            else {
                Player player2 = new HumanPlayer(name2);
            }






         
        }

        public Player[] getPlayers()
        {
            return this.players;
        }

        public void setPlayers(Player[] p)
        {
            this.players = p;
        }
    }
}
