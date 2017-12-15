using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BoardgameInc.UI_layer
{
    public class UIController
    {
        int playerAmount;
        Player activePlayer;
        PlayField activePlayfield;
        Window current;
        Boolean paused;
        LogicController lc;
        int currentShipSize = 2;
        int counter = 1;


        public UIController(LogicController c) {
            lc = c;
            paused = false;
        }

        public void startApp()
        {
            MainWindow mw = new MainWindow(this);
            current = mw;
            mw.Show();
        }

        public void setShip(List<int> shipLocs)
        {
            activePlayer.setShipLoc(shipLocs);
            if (currentShipSize < 4)
            {
                currentShipSize++;

            }
            else if (playerAmount > counter && activePlayer.GetType() == typeof(HumanPlayer))
            {
                ShipSelectWindow temp = (ShipSelectWindow)current;
                temp.clearShips();
                lc.switchActivePlayer();
                activePlayer = lc.getActivePlayer();
                currentShipSize = 2;
                counter++;
            }
            else
            {
                switchView(new GameWindow(this));
                lc.StartGame();
                activePlayfield = lc.getActivePlayfield();
            }
        }

        public void switchView(Window view)
        {
            view.Show();
            current.Close();
            current = view;
        }

        public int nextShotInput(int input)
        {
            if (!paused)
            {
                lc.shotInput(input);
            }
            
            return 0;
        }

        public void updateGrid(int hitMarker)
        {
            activePlayfield = lc.getActivePlayfield();
            GameWindow temp = (GameWindow)current;
            temp.updateGrid(activePlayfield.getGrid(), hitMarker);

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

            lc.setPlayers(n1, n2, playerAmount);
            activePlayer = lc.getActivePlayer();

        }

        public Player getActivePlayer()
        {
            return lc.getActivePlayer();
        }

        public int getShipLeft() {

            return lc.getActivePlayfield().getShipsLeftInt();
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

        public PlayField getActivePlayfield()
        {
            return lc.getActivePlayfield();
        }

        public void switchPaused()
        {
            if(paused)
            {
                paused = false;
            }
            else
            {
                paused = true;
            }
        }

        public void createGameoverWindow() {

            GameOverWindow gow = new GameOverWindow(this);
            gow.ShowDialog();
        }

        public void saveGame()
        {
            lc.saveGame();
        }

        public void loadGame()
        {
            lc.loadGame();
            activePlayer = lc.getActivePlayer();
            activePlayfield = lc.getActivePlayfield();
            switchView(new GameWindow(this));
            updateGrid(15);

        }

        public void startNewGame()
        {
            lc.resetGame();
            resetGame();
            switchView(new MainWindow(this));
        }

        public void resetGame()
        {
            counter = 1;
            currentShipSize = 2;
            activePlayer = null;
            activePlayfield = null;
        }
    }
}
