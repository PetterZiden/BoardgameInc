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
    /// Interaction logic for ShipSelectWindow.xaml
    /// </summary>
    public partial class ShipSelectWindow : Window
    {

        public UIController controller;
        List<Button> activeButtons = new List<Button>();
        List<Button> placedShips = new List<Button>();
        
 

        public ShipSelectWindow(UIController c)
        {
            InitializeComponent();
            controller = c;
            Alignment.SelectedIndex = 0;
            updateTextBox();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            List<int> shipLocs = new List<int>();
            List<Button> tempList = new List<Button>();
            Button current = (Button)sender;
            Boolean gridTaken = false;
     
            if (!placedShips.Contains(current))
            {
                int row = Grid.GetRow(current);
                int col = Grid.GetColumn(current);
                shipLocs.Add(Convert.ToInt32("" + row + col));
                if (Alignment.Text.Equals("Horizontal"))
                {
                    for (int i = 1; i < controller.getCurrentShipSize(); i++)
                    {
                        if (col + i < 10)
                        {
                            Button temp = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col + i).FirstOrDefault();
                            if (!placedShips.Contains(temp))
                            {
                                tempList.Add(temp);
                            }
                            else
                            {
                                gridTaken = true;
                            }

                        }
                    }
                }
                else
                {
                    for (int i = 1; i < controller.getCurrentShipSize(); i++)
                    {
                        if (row + i < 10)
                        {
                            Button temp = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row + i && Grid.GetColumn(x) == col).FirstOrDefault();
                            if (!placedShips.Contains(temp))
                            {
                                tempList.Add(temp);
                            }
                            else
                            {
                                gridTaken = true;
                            }
                        }
                    }
                }
                posOutput.Text = Convert.ToString(shipLocs[0]);
                if (!gridTaken)
                {
                    placedShips.Add(current);
                    foreach (Button b in tempList)
                    {
                        placedShips.Add(b);
                        shipLocs.Add(Convert.ToInt32("" + Grid.GetRow(b) + Grid.GetColumn(b)));
                    }
                    
                    controller.setShip(shipLocs);
                    updateTextBox();
                    errorOutput.Text = "";
                }
                else
                {
                    errorOutput.Text = "Grid already taken!";
                }
                
            }
            else
            {
                errorOutput.Text = "Grid already taken!";
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
            foreach (Button b in placedShips)
            {
                b.Background = Brushes.Aquamarine;
            }
            activeButtons.Clear();

        }

        private void updateTextBox()
        {
            posOutput.Text = "Player: " + controller.getActivePlayerName() + "\nPlace ship of size: " + controller.getCurrentShipSize();
        }

        
    }
}
