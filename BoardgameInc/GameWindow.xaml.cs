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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        public UIController controller;
        
        public GameWindow(UIController c)
        {
            InitializeComponent();
            controller = c;
            
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            List<int> shipLocs = new List<int>();
            Button current = (Button)sender;
            int row = Grid.GetRow(current);
            int col = Grid.GetColumn(current);
            
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {

            Button current = (Button)sender;
            int row = Grid.GetRow(current);
            int col = Grid.GetColumn(current);

            current.Background = Brushes.Aquamarine;
          
            
            
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button current = (Button)sender;
            current.Background = Brushes.Gray;
          
        }

        
    }
}
