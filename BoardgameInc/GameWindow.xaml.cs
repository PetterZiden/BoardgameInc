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

        private void btn_setImage(List<int> grid) {

            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    Button temp = (Button)GameGrid.Children.OfType<Button>().Where(x => Grid.GetRow(x) == i && Grid.GetColumn(x) == j).FirstOrDefault();
                    int tempInt = Convert.ToInt32("" + i + j);
                    if (grid[tempInt] == 0)
                    {
                       
                        BitmapImage bmp = new BitmapImage();
                        Uri u = new Uri("Images/Water.jpg", UriKind.RelativeOrAbsolute);
                        bmp.UriSource = u;
                        Image tempImages = new Image();
                        tempImages.Source = bmp;
                        temp.Content = tempImages;

                    }
                    else if (grid[tempInt] == 1)
                    {
                        BitmapImage bmp = new BitmapImage();
                        Uri u = new Uri("Images/Miss.jpg", UriKind.RelativeOrAbsolute);
                        bmp.UriSource = u;
                        Image tempImages = new Image();
                        tempImages.Source = bmp;
                        temp.Content = tempImages;
                    }
                    else if (grid[tempInt] == 2)
                    {
                        BitmapImage bmp = new BitmapImage();
                        Uri u = new Uri("Images/Hit.jpg", UriKind.RelativeOrAbsolute);
                        bmp.UriSource = u;
                        Image tempImages = new Image();
                        tempImages.Source = bmp;
                        temp.Content = tempImages;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                }
            }

        }

        
    }
}
