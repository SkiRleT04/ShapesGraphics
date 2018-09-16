using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    class CircleValidator : IValidator
    {
        public void Validate(BaseConstructionArgs baseConstructionArgs)
        {
            if (baseConstructionArgs is CircleConstructionArgs circleConstructionArgs)
            {
                if (circleConstructionArgs.Radius <= 0)
                {
                    throw new ValidationException("Radius of circle should be greater than zero.");
                }
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Circle Construction Args.");
            }
        }
    }
}
