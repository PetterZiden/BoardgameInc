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
        String player1;
        String player2;
        Window current;


        public UIController() {
            
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

        public void setPlayerAmount(int a)
        {
            playerAmount = a;
        }

        public int getPlayerAmount()
        {
            return playerAmount;
        }

        public void setPlayer1(String n)
        {
            player1 = n;
        }

        public void setPlayer2(String n)
        {
            player2 = n;
        }

    }
}
