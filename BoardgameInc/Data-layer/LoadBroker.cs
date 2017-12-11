using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoardgameInc.Data_layer
{
    class LoadBroker
    {
        public LoadBroker() {
        }

        public LoadObject loadFromXML() {

            XDocument doc = XDocument.Load("Z:\\save.xml");

            var tempWHATEVER = from r in doc.Descendants("Player")
                               select new
                               {
                                   Name = r.Element("Name").Value,
                                   GridList = r.Element("Grid").Value,
                                   ShipsSize = r.Element("ShipSize").Value,
                                   ShipGrid = r.Element("ShipGrid").Value,
                              
                               };
            foreach (var r in tempWHATEVER) {
                Console.WriteLine(r.Name);
            }


            LoadObject lo = null;

            return lo;
        }
    }
}
