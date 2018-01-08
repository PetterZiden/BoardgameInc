using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameInc.Logic_layer
{
    class HitmarkerOutOfRangeException : Exception
    {
        public HitmarkerOutOfRangeException() { }

        public HitmarkerOutOfRangeException(string message) : base(message) { }

        public HitmarkerOutOfRangeException(string message, Exception inner) : base(message, inner) { }
    }
}
