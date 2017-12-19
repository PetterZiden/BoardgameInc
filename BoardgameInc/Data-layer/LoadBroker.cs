using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BoardgameInc.Data_layer
{
    class LoadBroker
    {

        private readonly string directory = AppDomain.CurrentDomain.BaseDirectory + @"\save.xml";

        public LoadBroker() {
        }

        public LoadObject loadFromXML() {

            XDocument doc = XDocument.Load(directory);

            var tempPlayer = from r in doc.Descendants("Player")
                       select new
                       {
                           Name = r.Element("Name").Value,
                           GridList = r.Element("GridList").Elements(),
                           Ships = r.Elements("Ships").Elements(),
                       };

            var settings = from s in doc.Descendants("Save")
                           select new
                           {
                               Active = s.Element("ActivePlayer").Value,
                               Amount = s.Element("PlayerAmount").Value,
                           };

            List < string > playerNames = new List<string>();
            List<List<int>> playerGrids = new List<List<int>>();
            List<List<Ship>> playerShips = new List<List<Ship>>();
            List<Boolean> aiGrid = new List<Boolean>();
            List<int> medPrio = new List<int>();
            List<int> highPrio = new List<int>();
            int activePlayer = 0;
            int playerAmount = 0;

            foreach (var s in settings)
            {
                activePlayer = Int32.Parse(s.Active);
                playerAmount = Int32.Parse(s.Amount);
            }

            if(playerAmount == 1)
            {
                var aiInfo = from a in doc.Descendants("AIInfo")
                             select new
                             {
                                 AIGrids = a.Element("AIGrids").Elements(),
                                 MedPrio = a.Element("AIMediumPrio").Elements(),
                                 HighPrio = a.Element("AIHighPrio").Elements(),
                             };

                foreach (var a in aiInfo)
                {
                    foreach (var s in a.AIGrids)
                    {
                        aiGrid.Add(Convert.ToBoolean(s.Value));
                    }

                    foreach (var s in a.MedPrio)
                    {
                        medPrio.Add(Int32.Parse(s.Value));
                    }

                    foreach (var s in a.HighPrio)
                    {
                        highPrio.Add(Int32.Parse(s.Value));
                    }
                }   
            }

            foreach (var r in tempPlayer) {
                playerNames.Add(r.Name);
                List<int> tempList = new List<int>();
                List<Ship> tempShips = new List<Ship>();
                foreach (var l in r.GridList)
                {
                    tempList.Add(Int32.Parse(l.Value));
                }
                playerGrids.Add(tempList);
                
                foreach (var s in r.Ships)
                {
                    Console.WriteLine(s.Attribute("ShipSize").Value);
                    List<int> shipLocs = new List<int>();
                    foreach (var q in s.Element("ShipGrids").Elements())
                    {
                        shipLocs.Add(Int32.Parse(q.Attribute("Grid").Value));
                    }
                    tempShips.Add(new Ship(Int32.Parse(s.Attribute("ShipSize").Value), shipLocs));
                }
                playerShips.Add(tempShips);   
            }

            LoadObject lo = new LoadObject(playerGrids[0], playerGrids[1], playerShips[0], playerShips[1], playerNames[0], playerNames[1], activePlayer, playerAmount, aiGrid, medPrio, highPrio);

            return lo;
        }
    }
}
