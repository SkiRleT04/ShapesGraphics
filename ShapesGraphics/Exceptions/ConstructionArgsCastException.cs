using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.Exceptions
{
    class ConstructionArgsCastException : ApplicationException
    {
        public ConstructionArgsCastException(string message) : base(message)
        {

        }
    }
}
