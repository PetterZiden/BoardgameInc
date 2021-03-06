﻿using BoardgameInc.Logic_layer;
using BoardgameInc.UI_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

            controller.nextShotInput(Convert.ToInt32("" + row + col));
            
        }


        public void updateGrid(List<int> grid, int hitMarker) {

            ActivePlayer.Text = "Active player: " + controller.getActivePlayer().getName();
            ActivePlayfield.Text = "Shooting at " + controller.getActivePlayfield().getName() + "s playfield";
            ShipsLeft.Text = "Ships left for " + controller.getActivePlayfield().getName() + " : " + controller.getShipLeft();

            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    Button temp = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == i && Grid.GetColumn(x) == j).FirstOrDefault();
                    var brush = new ImageBrush();
                    int tempInt = Convert.ToInt32("" + i + j);
                    if (grid[tempInt] == 0)
                    {

                        brush.ImageSource = new BitmapImage(new Uri("Images/Water.jpg", UriKind.Relative));
                        temp.Background = brush;

                    }
                    else if (grid[tempInt] == 1)
                    {
                        
                        brush.ImageSource = new BitmapImage(new Uri("Images/Miss.jpg", UriKind.Relative));
                        temp.Background = brush;


                    }
                    else if (grid[tempInt] == 2)
                    {
                        
                        brush.ImageSource = new BitmapImage(new Uri("Images/Hit.jpg", UriKind.Relative));
                        temp.Background = brush;
                        

                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                    setShotOutput(hitMarker);

                }
            }

        }

        private void save(object sender, RoutedEventArgs e)
        {
            controller.saveGame();
        }

        public void setShotOutput(int hitMarker) {

            if (hitMarker == 0)
            {
                ShotOutput.Text = "SHIP SUNK";

            }
            else if (hitMarker == -1)
            {

                ShotOutput.Text = "MISS";
            }
            else if(hitMarker > 0 && hitMarker < 10) {
                ShotOutput.Text = "HIT";
            }
            else
            {
                ShotOutput.Text = "";
            }
            
        }

        private void newGame(object sender, RoutedEventArgs e)
        {
            controller.startNewGame();
        }
    }
}
