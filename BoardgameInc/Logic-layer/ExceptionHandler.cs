using BoardgameInc.UI_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    public class ExceptionHandler
    {
        private UIController ui;

        public ExceptionHandler(UIController u)
        {
            ui = u;
        }

        public void LoadException(string errorOutput)
        {
            ui.printError("Unable to load save file: " + errorOutput);
        }

        public void SaveException(string errorOutput)
        {
            ui.printError("Unable to save file: " + errorOutput);
        }

        public void IncorrectGridException(string errorOutput)
        {
            ui.printError("Invalid grid selected: " + errorOutput);
        }

        public void WindowErrorException(string errorOutput)
        {
            ui.printError("An unhandled error has occured: " + errorOutput);
        }
    }
}
