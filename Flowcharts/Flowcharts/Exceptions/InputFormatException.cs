using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class InputFormatException : Exception
    {
        public InputFormatException(string message) : base(message) { }
    }
}
