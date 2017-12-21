using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BoardgameInc.Data_layer
{
    class SaveBroker
    {
        private readonly string directory = AppDomain.CurrentDomain.BaseDirectory + @"\save.xml";

        public SaveBroker() {

        }

        public void saveToXML(List<int> playerOneGrid, List<int> playerTwoGrid, List<Ship> playerOneShips, List<Ship> playerTwoShips, String p1Name, String p2Name, int activePlayer, List<Boolean> aiGrid, List<int> mediumPrio, List<int> highPrio) {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement("Save",
                    new XElement("Players",
                        new XElement("Player",
                            new XElement("Name", p1Name),
                            new XElement("GridList", playerOneGrid.Select(x => new XElement("Grid", x))),
                            new XElement("Ships", playerOneShips.Select(x => new XElement("Ship",
                                new XAttribute("ShipSize", x.getSize()),
                                new XElement("ShipGrids", x.getGridlocs().Select(y => new XElement("ShipGrids",
                                    new XAttribute("Grid", y)
                                )))
                            )))
                        ),
                        new XElement("Player",
                            new XElement("Name", p2Name),
                            new XElement("GridList", playerTwoGrid.Select(x => new XElement("Grid", x))),
                            new XElement("Ships", playerTwoShips.Select(x => new XElement("Ship",
                                new XAttribute("ShipSize", x.getSize()),
                                new XElement("ShipGrids", x.getGridlocs().Select(y => new XElement("ShipGrids",
                                    new XAttribute("Grid", y)
                                )))
                            )))
                        )
                    ),
                    new XElement("AIInfo",
                            new XElement("AIGrids", aiGrid.Select(x => new XElement("AIGrid", x))),
                            new XElement("AIMediumPrio", mediumPrio.Select(x => new XElement("MediumPrio", x))),
                            new XElement("AIHighPrio", highPrio.Select(x => new XElement("HighPrio", x)))
                            ),
                    new XElement("ActivePlayer", activePlayer),
                    new XElement("PlayerAmount", 1)
                )
            );
            StringWriter sWriter = new StringWriter();
            XmlWriter xWriter = XmlWriter.Create(sWriter);
            Console.WriteLine(xWriter);
            doc.Save(xWriter);
            xWriter.Close();
            doc.Save(directory);
        }

        public void saveToXML(List<int> playerOneGrid, List<int> playerTwoGrid, List<Ship> playerOneShips, List<Ship> playerTwoShips, String p1Name, String p2Name, int activePlayer)
        {
            XDocument doc = new XDocument(new XElement("Document"));
            doc.Root.Add(
                new XElement("Players",
                    new XElement("Player",
                        new XElement("Name", p1Name),
                        new XElement("GridList", playerOneGrid.Select(x => new XElement("Grid", x))),
                        new XElement("Ships", playerOneShips.Select(x => new XElement("Ship",
                                new XAttribute("ShipSize", x.getSize()),
                                new XElement("ShipGrids", x.getGridlocs().Select(y => new XElement("ShipGrids",
                                    new XAttribute("Grid", y)
                                 )))
                            )))
                        ),
                    new XElement("Player",
                        new XElement("Name", p2Name),
                        new XElement("GridList", playerTwoGrid.Select(x => new XElement("Grid", x))),
                        new XElement("Ships", playerTwoShips.Select(x => new XElement("Ship",
                                new XAttribute("ShipSize", x.getSize()),
                                new XElement("ShipGrids", x.getGridlocs().Select(y => new XElement("ShipGrids",
                                    new XAttribute("Grid", y)
                                )))
                            )))
                        )
                    ),
                new XElement("ActivePlayer", activePlayer),
                new XElement("PlayerAmount", 2)
                );

            StringWriter sWriter = new StringWriter();
            XmlWriter xWriter = XmlWriter.Create(sWriter);
            Console.WriteLine(xWriter);
            doc.Save(xWriter);
            xWriter.Close();
            doc.Save(directory);
        }
    }
}
