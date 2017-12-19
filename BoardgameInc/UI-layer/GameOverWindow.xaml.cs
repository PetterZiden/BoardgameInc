using BoardgameInc.Logic_layer;
using BoardgameInc.UI_layer;
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
using System.Windows.Shapes;

namespace BoardgameInc
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {

        UIController controller;

        public GameOverWindow(UIController u)
        {
            InitializeComponent();
            controller = u;
            GameOverText.Text = controller.getActivePlayer().getName() + " has destroyed all of " + controller.getActivePlayfield().getName() + "s ships!\n" + controller.getActivePlayer().getName() + " wins!";
            

        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            controller.startNewGame();

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }
    }
}
