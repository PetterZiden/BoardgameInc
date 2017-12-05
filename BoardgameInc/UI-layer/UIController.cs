using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoardgameInc.UI_layer
{
    public class UIController
    {
        int playerAmount;
        Player player1;
        Player player2;
        Player activePlayer;
        Window current;
        LogicController lc;
        int currentShipSize = 2;
        int counter = 1;


        public UIController(LogicController c) {
            lc = c;
            activePlayer = player1;
        }

        public void startApp()
        {
            MainWindow mw = new MainWindow(this);
            current = mw;
            mw.Show();
        }

        public void switchView(Window view)
        {
            view.Show();
            current.Close();
            current = view;
        }

        public int nextShotInput(int input)
        {
            lc.shotInput(input);
            
            return 0;
        }

        public void updateGrid(List<int> grid)
        {
            GameWindow temp = (GameWindow)current;
            temp.updateGrid(grid);
            Console.WriteLine("UICONTROLLER");
        }
       

        public void setShip(List<int> shipLocs)
        {
            activePlayer.setShipLoc(shipLocs);
            if(currentShipSize < 4)
            {
                currentShipSize++;
                
            }
            else if(playerAmount > counter && activePlayer.GetType() == typeof(HumanPlayer)) 
            {
                ShipSelectWindow temp = (ShipSelectWindow)current;
                temp.clearShips();
                activePlayer = player2;
                currentShipSize = 2;
                counter++;
            }
            else
            {
                switchView(new GameWindow(this));
                lc.StartGame();
            }
        }

        public void setPlayerAmount(int a)
        {
            playerAmount = a;
        }

        public int getPlayerAmount()
        {
            return playerAmount;
        }

        public void setPlayers(String n1, String n2)
        {
            player1 = new HumanPlayer(n1);
            activePlayer = player1;

            if(playerAmount == 1)
            {
                player2 = new AIPlayer("AI");
            }
            else
            {
                player2 = new HumanPlayer(n2);
            }

            lc.setPlayers(player1, player2);

        }

        public String getActivePlayerName()
        {
            return activePlayer.getName();
        }

        public void setCurrentShipSize() {
          
            if (currentShipSize == 4)
            {
                currentShipSize = 2;
            }
            else {
                currentShipSize++;
            }
        }

        public int getCurrentShipSize()
        {
            return currentShipSize;
        }

    }
}
