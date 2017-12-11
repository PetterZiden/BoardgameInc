using BoardgameInc.Logic_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoardgameInc.Data_layer
{
    class saveBroker
    {
        public saveBroker() {

        }

        public void saveToXML(List<int> playfieldGrid, List<Ship> playfieldShips, String p1Name, String p2Name, Player activePlayer, List<Boolean> aiGrid, List<int> mediumPrio, List<int> highPrio) {
            XDocument doc = new XDocument();
            doc.Add(new XElement("Playfield Grid", playfieldGrid.Select(x => new XElement("Grid", x))));
            doc.Add(new XElement("Playfield Ships", playfieldShips.Select(x => new XElement("Ships", x))));
            doc.Add(new XElement("Player 1 Name", p1Name));
            doc.Add(new XElement("Player 2 Name", p2Name));
            doc.Add(new XElement("Active Player", activePlayer));
            doc.Add(new XElement("AI Grid", aiGrid.Select(x => new XElement("AI Grid", x))));
            doc.Add(new XElement("AI Medium Prio", mediumPrio.Select(x => new XElement("Medium Prio", x))));
            doc.Add(new XElement("AI High Prio", highPrio.Select(x => new XElement("High Prio", x))));

            doc.Save("Data_layer/save.XML");
        }
    }
}
