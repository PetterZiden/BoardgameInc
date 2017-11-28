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
using BoardgameInc.UI_layer;

namespace BoardgameInc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIController controller;

        public MainWindow(UIController c)
        {
            InitializeComponent();
            controller = c;
        }

        private void playerAmountInput(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int playerAmount = Convert.ToInt32(button.Tag);
            controller.setPlayerAmount(playerAmount);
            onePlayerButton.Visibility = System.Windows.Visibility.Hidden;
            twoPlayerButton.Visibility = System.Windows.Visibility.Hidden;
            playerOneName.Visibility = System.Windows.Visibility.Visible;
            playerOneInput.Visibility = System.Windows.Visibility.Visible;
        }
        
        private void onePlayerInput(object sender, RoutedEventArgs e)
        {
            if(controller.getPlayerAmount() == 1)
            {
                controller.setPlayers(playerOneName.Text, "");
                controller.switchView(new GameWindow(controller)); 
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
            controller.setPlayers(playerOneName.Text, playerTwoName.Text);
            controller.switchView(new ShipSelectWindow(controller));
            
        }

    
    }
}
