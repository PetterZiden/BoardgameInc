using BoardgameInc.Data_layer;
using BoardgameInc.Logic_layer;
using BoardgameInc.UI_layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BoardgameInc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            DataController dc = new DataController();
            LogicController lc = new LogicController(dc);
            UIController ui = new UIController(lc);
            lc.setUIController(ui);
            ExceptionHandler eh = new ExceptionHandler(ui);
            dc.setExceptionHandler(eh);
            lc.setExceptionHandler(eh);
            ui.setExceptionHandler(eh);
            ui.startApp();
        }
    }
}
