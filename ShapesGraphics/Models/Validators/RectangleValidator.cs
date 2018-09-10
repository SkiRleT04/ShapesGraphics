using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    class RectangleValidator : IValidator
    {
        public bool IsValid(BaseConstructionArgs baseConstructionArgs)
        {
            if (baseConstructionArgs is RectangleConstructionArgs rectangleConstructionArgs)
            {
                if (rectangleConstructionArgs.Width <= 0 || 
                    rectangleConstructionArgs.Height <= 0)
                {
                    return false;
                }
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Rectangle Construction Args.");
            }

            return true;
        }
    }
}
