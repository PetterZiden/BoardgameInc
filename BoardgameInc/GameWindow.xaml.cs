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
        Boolean vertical = true;
        
 

        public GameWindow(UIController c)
        {
            InitializeComponent();
            controller = c;
            
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {

            Button current = (Button)sender;
            int row = Grid.GetRow(current);
            int col = Grid.GetColumn(current);

            String tempR = row.ToString();
            String tempC = col.ToString();

            posOutput.Text = tempR + tempC;

            current.Background = Brushes.Aquamarine;

            if (vertical) {
                for(int i = 1; i < controller.getCurrentShipSize(); i++) {

                    Button temp1 = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col + i).FirstOrDefault();
                    temp1.Background = Brushes.Aquamarine;
                }
                

            }
            
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button current = (Button)sender;
            current.Background = Brushes.Gray;

        }
    }
}
