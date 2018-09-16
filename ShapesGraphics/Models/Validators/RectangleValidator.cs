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
        public void Validate(BaseConstructionArgs baseConstructionArgs)
        {
            if (baseConstructionArgs is RectangleConstructionArgs rectangleConstructionArgs)
            {
                if (rectangleConstructionArgs.Width <= 0)
                {
                    throw new ValidationException("Width of rectangle should be greater than zero.");
                }
                if (rectangleConstructionArgs.Height <= 0)
                {
                    throw new ValidationException("Height of rectangle should be greater than zero.");
                }  
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Rectangle Construction Args.");
            }
        }
    }
}
