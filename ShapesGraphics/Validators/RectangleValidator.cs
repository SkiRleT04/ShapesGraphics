using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    class RectangleValidator : IValidator<RectangleConstructionArgs>
    {
        public void Validate(RectangleConstructionArgs constructionArgs)
        {
            if (constructionArgs.Width <= 0)
            {
                throw new ValidationException("Width of rectangle should be greater than zero.");
            }
            if (constructionArgs.Height <= 0)
            {
                throw new ValidationException("Height of rectangle should be greater than zero.");
            }
        }
    }
}
