using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    public class AIPlayer : Player
    {
        private List<String> grid;
        private List<int> mediumPriority;
        private List<int> highPriority;
        private int gridSizeX;
        private int gridSizeY;
        private Random rnd;

        public AIPlayer(String n)
            : base(n)
        {
            grid = new List<string>();
            mediumPriority = new List<int>();
            highPriority = new List<int>();
            rnd = new Random();
            gridSizeX = 10;
            gridSizeY = 10;
            name = n;

            for (int i = 0; i < gridSizeX * gridSizeY; i++)
            {
                grid.Add(Convert.ToString(i));
            }
        }

        ~AIPlayer()
        {
        }

        override
            public List<Ship> placeShips(int[] shipSizes)
        {
            List<Ship> ships = new List<Ship>();
            List<int> usedLocations = new List<int>();
            for (int i = 0; i < shipSizes.Length; i++)
            {
                Boolean intersects = false;
                int[] gridLocations = new int[shipSizes[i]];
                do
                {
                    intersects = false;
                    int orientation = rnd.Next(0, 2);
                    gridLocations[0] = rnd.Next(0, grid.Count - 1);
                    for (int j = 1; j < gridLocations.Length; j++)
                    {
                        int gridIndex = 0;
                        if (orientation == 0)
                        {
                            gridIndex = gridLocations[j-1] + 1;
                        }
                        else
                        {
                            gridIndex = gridLocations[j-1] + gridSizeY;
                        }
                        if (gridIndex % gridSizeY != 0 && gridIndex % gridSizeY != gridSizeY && gridIndex >= 0 && gridIndex < grid.Count)
                        {
                            gridLocations[j] = gridIndex;
                        }
                        else
                        {
                            intersects = true;
                            break;
                        }
                        foreach (int loc in usedLocations) {
                            if(gridIndex == loc)
                            {
                                intersects = true;
                                break;
                            }
                        }
                    }

                } while (intersects) ;
                usedLocations.AddRange(gridLocations);
                List<int> shipLocations = new List<int>();
                for(int j = 0; j < gridLocations.Length; j++)
                {
                    shipLocations.Add(gridLocations[j]);
                }
                ships.Add(new Ship(shipSizes[i], shipLocations));

            } 
            
            return ships;

        }


    override
        public int getShotLoc()
    {
            Console.WriteLine(name + " Enter grid location to shoot at:");
            int locIndex;
            if (highPriority.Count != 0)
            {
                locIndex = rnd.Next(0, highPriority.Count - 1);
                int gridIndex = grid.IndexOf(Convert.ToString(highPriority[locIndex]));
                Console.WriteLine(highPriority[locIndex]);
                return highPriority[locIndex];
            }
            else if (mediumPriority.Count != 0)
            {
                locIndex = rnd.Next(0, mediumPriority.Count - 1);
                Console.WriteLine(mediumPriority[locIndex]);
                return mediumPriority[locIndex];
            }
            else
            {
                do
                {
                    locIndex = rnd.Next(0, grid.Count - 1);
                } while (((locIndex / 10) % 2 == 0 && locIndex % 2 == 0) || ((locIndex / 10) % 2 == 1 && locIndex % 2 == 1) || grid[locIndex].Equals("HIT") || grid[locIndex].Equals("MISS"));
                Console.WriteLine(grid[locIndex]); 
                return 0;
            }
            return 0;
        }

    override
        public void getShotFeedback(int hitMarker, int gridLoc)
    {
        int gridIndex = grid.IndexOf(Convert.ToString(gridLoc));
        if (highPriority.Contains(gridLoc))
        {
            highPriority.Remove(gridLoc);
            if (hitMarker > 0)
            {
                grid[gridIndex] = "HIT";
                if ((gridIndex + 1) % gridSizeY != 0 && !grid[gridIndex + 1].Equals("HIT") && !grid[gridIndex + 1].Equals("MISS") && (gridIndex - 1) % gridSizeY != gridSizeY && grid[gridIndex - 1].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex + 1]));
                }
                if ((gridIndex - 1) % gridSizeY != gridSizeY && !grid[gridIndex - 1].Equals("HIT") && !grid[gridIndex - 1].Equals("MISS") && (gridIndex + 1) % gridSizeY != 0 && grid[gridIndex + 1].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex - 1]));
                }
                if ((gridIndex + gridSizeY) <= gridSizeX * gridSizeY && !grid[gridIndex + gridSizeY].Equals("HIT") && !grid[gridIndex + gridSizeY].Equals("MISS") && (gridIndex - gridSizeY) >= 0 && grid[gridIndex - gridSizeY].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex + gridSizeY]));
                }
                if ((gridIndex - gridSizeY) >= 0 && !grid[gridIndex - gridSizeY].Equals("HIT") && !grid[gridIndex - gridSizeY].Equals("MISS") && (gridIndex + gridSizeY) <= gridSizeX * gridSizeY && grid[gridIndex + gridSizeY].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex - gridSizeY]));
                }
            }
            else if (hitMarker == 0)
            {
                grid[gridIndex] = "HIT";
                highPriority.Clear();
                mediumPriority.Clear();
            }
            else
            {
                grid[gridIndex] = "MISS";
            }
        }
        else if (mediumPriority.Contains(gridLoc))
        {
            mediumPriority.Remove(gridLoc);
            if (hitMarker > 0)
            {
                grid[gridIndex] = "HIT";
                if ((gridIndex + 1) % gridSizeY != 0 && !grid[gridIndex + 1].Equals("HIT") && !grid[gridIndex + 1].Equals("MISS") && (gridIndex - 1) % gridSizeY != gridSizeY && grid[gridIndex - 1].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex + 1]));
                }
                if ((gridIndex - 1) % gridSizeY != gridSizeY && !grid[gridIndex - 1].Equals("HIT") && !grid[gridIndex - 1].Equals("MISS") && (gridIndex + 1) % gridSizeY != 0 && grid[gridIndex + 1].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex - 1]));
                }
                if ((gridIndex + gridSizeY) <= gridSizeX * gridSizeY && !grid[gridIndex + gridSizeY].Equals("HIT") && !grid[gridIndex + gridSizeY].Equals("MISS") && (gridIndex - gridSizeY) >= 0 && grid[gridIndex - gridSizeY].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex + gridSizeY]));
                }
                if ((gridIndex - gridSizeY) >= 0 && !grid[gridIndex - gridSizeY].Equals("HIT") && !grid[gridIndex - gridSizeY].Equals("MISS") && (gridIndex + gridSizeY) <= gridSizeX * gridSizeY && grid[gridIndex + gridSizeY].Equals("HIT"))
                {
                    highPriority.Add(Convert.ToInt32(grid[gridIndex - gridSizeY]));
                }

            }
            else if (hitMarker == 0)
            {
                grid[gridIndex] = "HIT";
                mediumPriority.Clear();
            }
            else
            {
                grid[gridIndex] = "MISS";
            }
        }
        else
        {
            if (hitMarker > 0)
            {
                grid[gridIndex] = "HIT";
                if ((gridIndex + 1) % gridSizeY != 0 && !grid[gridIndex + 1].Equals("HIT") && !grid[gridIndex + 1].Equals("MISS"))
                {
                    mediumPriority.Add(Convert.ToInt32(grid[gridIndex + 1]));
                }
                if ((gridIndex - 1) % gridSizeY != gridSizeY && !grid[gridIndex - 1].Equals("HIT") && !grid[gridIndex - 1].Equals("MISS"))
                {
                    mediumPriority.Add(Convert.ToInt32(grid[gridIndex - 1]));
                }
                if ((gridIndex + gridSizeY) <= gridSizeX * gridSizeY && !grid[gridIndex + gridSizeY].Equals("HIT") && !grid[gridIndex + gridSizeY].Equals("MISS"))
                {
                    mediumPriority.Add(Convert.ToInt32(grid[gridIndex + gridSizeY]));
                }
                if ((gridIndex - gridSizeY) >= 0 && !grid[gridIndex - gridSizeY].Equals("HIT") && !grid[gridIndex - gridSizeY].Equals("MISS"))
                {
                    mediumPriority.Add(Convert.ToInt32(grid[gridIndex - gridSizeY]));
                }
            }
            else if (hitMarker == 0)
            {
                grid[gridIndex] = "HIT";

            }
            else
            {
                grid[gridIndex] = "MISS";
            }
        }
        
    } 

}
}

