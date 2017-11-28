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
        List<Button> activeButtons = new List<Button>();
        
 

        public GameWindow(UIController c)
        {
            InitializeComponent();
            controller = c;
            Alignment.SelectedIndex = 0;
            posOutput.Text = "Player: " + controller.getPlayer1Name() + "\nPlace ship of size: " + controller.getCurrentShipSize(); 
            
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            int[] shipLocs = new int[controller.getCurrentShipSize()];
            Button current = (Button)sender;
            int row = Grid.GetRow(current);
            int col = Grid.GetColumn(current);
            if (Alignment.Text.Equals("Horizontal"))
            {
                for (int i = 1; i < controller.getCurrentShipSize(); i++)
                {
                    if (col + i < 10)
                    {
                        Button temp1 = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col + i).FirstOrDefault();
                        
                        
                    }
                }
            }
            else
            {
                for (int i = 1; i < controller.getCurrentShipSize(); i++)
                {
                    if (row + i < 10)
                    {
                        Button temp1 = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row + i && Grid.GetColumn(x) == col).FirstOrDefault();
                        temp1.Background = Brushes.Aquamarine;
                        activeButtons.Add(temp1);
                    }
                }
            }


        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {

            Button current = (Button)sender;
            int row = Grid.GetRow(current);
            int col = Grid.GetColumn(current);

            current.Background = Brushes.Aquamarine;
          
            if (Alignment.Text.Equals("Horizontal")) {
                for(int i = 1; i < controller.getCurrentShipSize(); i++) {
                    if (col + i < 10)
                    {
                        Button temp1 = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col + i).FirstOrDefault();
                        temp1.Background = Brushes.Aquamarine;
                        activeButtons.Add(temp1);
                    }
                }
            }
            else
            {
                for (int i = 1; i < controller.getCurrentShipSize(); i++)
                {
                    if (row + i < 10)
                    {
                        Button temp1 = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row + i && Grid.GetColumn(x) == col).FirstOrDefault();
                        temp1.Background = Brushes.Aquamarine;
                        activeButtons.Add(temp1);
                    }
                }
            }
            
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button current = (Button)sender;
            current.Background = Brushes.Gray;
            foreach(Button b in activeButtons)
            {
                b.Background = Brushes.Gray;
            }
            activeButtons.Clear();

        }

        
    }
}
