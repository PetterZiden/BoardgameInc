using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Data_layer
{
    class FailedToSaveLoadException:Exception
    {
        public FailedToSaveLoadException() { }

        public FailedToSaveLoadException(string message) : base(message) { }

        public FailedToSaveLoadException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
