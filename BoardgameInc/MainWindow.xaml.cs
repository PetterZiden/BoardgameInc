using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BoardgameInc.Logic_layer;

namespace BoardgameInc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int playerAmount;
        String player1;
        String player2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void playerAmountInput(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            playerAmount = Convert.ToInt32(button.Tag);
            onePlayerButton.Visibility = System.Windows.Visibility.Hidden;
            twoPlayerButton.Visibility = System.Windows.Visibility.Hidden;
            playerOneName.Visibility = System.Windows.Visibility.Visible;
            playerOneInput.Visibility = System.Windows.Visibility.Visible;
        }
        
        private void onePlayerInput(object sender, RoutedEventArgs e)
        {
            player1 = playerOneName.Text;
            if(playerAmount == 1)
            {
                LogicController lc = new LogicController(playerAmount, player1);
                GameWindow gw = new GameWindow(lc);
                gw.Show();
                this.Close();
            }
            else
            {
                playerOneName.Visibility = System.Windows.Visibility.Hidden;
                playerOneInput.Visibility = System.Windows.Visibility.Hidden;
                playerTwoName.Visibility = System.Windows.Visibility.Visible;
                playerTwoInput.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void twoPlayerInput(object sender, RoutedEventArgs e)
        {
            player2 = playerTwoName.Text;
            LogicController lc = new LogicController(playerAmount, player1, player2);
            GameWindow gw = new GameWindow(lc);
            
            gw.Show();
            this.Close();
        }

    
    }
}
