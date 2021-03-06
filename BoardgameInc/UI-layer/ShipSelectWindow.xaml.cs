﻿using BoardgameInc.Logic_layer;
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
            clearShips();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            List<int> shipLocs = new List<int>();
            List<Button> tempList = new List<Button>();
            Button current = (Button)sender;
            Boolean gridTaken = false;
            Boolean invalidGrid = false;
     
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
                        else
                        {
                            invalidGrid = true;
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
                        else
                        {
                            invalidGrid = true;
                        }
                    }
                }
                posOutput.Text = Convert.ToString(shipLocs[0]);
                if (!gridTaken && !invalidGrid)
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
                else if(gridTaken)
                {
                    errorOutput.Text = "Cannot place ship in that location. Location already occupied!";
                    updateTextBox();
                }
                else
                {
                    errorOutput.Text = "Cannot place ship in that location. Location is outside playfield";
                    updateTextBox();
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
          
            if (Alignment.Text.Equals("Horizontal")) {
                for(int i = 1; i < controller.getCurrentShipSize(); i++) {
                    if (col + i < 10)
                    {
                        Button temp1 = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col + i).FirstOrDefault();
                        temp1.Background = Brushes.IndianRed;
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
                        temp1.Background = Brushes.IndianRed;
                        activeButtons.Add(temp1);
                    }
                }
            }
            
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button current = (Button)sender;
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Images/Water.jpg", UriKind.Relative));
            foreach (Button b in activeButtons)
            {
                b.Background = brush;
            }
            foreach (Button b in placedShips)
            {
                b.Background = Brushes.IndianRed;
            }
            activeButtons.Clear();

        }

        public void clearShips()
        {
            placedShips.Clear();
            activeButtons.Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button temp = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == i && Grid.GetColumn(x) == j).FirstOrDefault();
                    var brush = new ImageBrush();
                    int tempInt = Convert.ToInt32("" + i + j);
                    brush.ImageSource = new BitmapImage(new Uri("Images/Water.jpg", UriKind.Relative));
                    temp.Background = brush;

                }
            }
        }

        private void updateTextBox()
        {
            posOutput.Text = "Player: " + controller.getActivePlayer().getName() + "\nPlace ship of size: " + controller.getCurrentShipSize();
        }

        
    }
}
