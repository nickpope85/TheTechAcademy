using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class FraudException : Exception
    {
        public FraudException()
            : base() { } //<-- inherits from base Exception
        public FraudException(string message)
            : base (message) { }
    }
}
