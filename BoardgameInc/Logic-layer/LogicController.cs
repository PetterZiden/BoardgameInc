using BoardgameInc.UI_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BoardgameInc.Data_layer;

namespace BoardgameInc.Logic_layer
{
   public class LogicController
    {
        Player player1;
        Player player2;
        Player activePlayer;
        int playerAmount;
        PlayField activePlayfield;
        UIController ui;
        DataController data;

        public LogicController(DataController dc)
        {
            data = dc;
        }


        public void StartGame()
        {

            player1.placeShips(new int[] { 2, 3, 4 });
            player2.placeShips(new int[] { 2, 3, 4 });
            activePlayer = player1;
            activePlayfield = player2.getPlayfield();
            ui.updateGrid();

        }

        public async void shotInput(int input)
        {
            int hitMarker = activePlayfield.checkHit(input);
            if (activePlayfield.getShipsLeft())
            {
                activePlayer.getShotFeedback(hitMarker, input);
                ui.updateGrid();
                ui.switchPaused();
                await Task.Delay(1500);
                ui.switchPaused();
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
                ui.updateGrid();
                if (activePlayer.GetType() == typeof(AIPlayer))
                {
                    shotInput(activePlayer.getShotLoc());
                }
            }
            else {
                ui.createGameoverWindow();
            }

        }

        public PlayField getActivePlayfield()
        {
            return activePlayfield;
        }

        public Player getActivePlayer()
        {
            return activePlayer;
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

        public void setPlayers(String n1, String n2, int amount)
        {
            playerAmount = amount;
            player1 = new HumanPlayer(n1);
            activePlayer = player1;

            if (playerAmount == 1)
            {
                player2 = new AIPlayer("AI");
            }
            else
            {
                player2 = new HumanPlayer(n2);
            }

        }

        public void saveGame()
        {
            int active;
            if(activePlayer == player1)
            {
                active = 1;
            }
            else
            {
                active = 2;
            }
            data.save(player1, player2, active, playerAmount);
        }

        public void loadGame()
        {
            List<Player> players = data.load(this);
            player1 = players[0];
            player2 = players[1];
            activePlayer = player1;
            activePlayfield = player2.getPlayfield();
        }

        public void setGameInfo(int active, int amount)
        {
            if(active == 1)
            {
                activePlayer = player1;
            }
            else
            {
                activePlayer = player2;
            }

            playerAmount = amount;
        }

    }
}
