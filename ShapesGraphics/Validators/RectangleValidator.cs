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
            if (constructionArgs.Width <= 0 || !constructionArgs.Width.HasValue)
            {
                throw new ValidationException("Width of rectangle should be greater than zero.");
            }
            if (constructionArgs.Height <= 0 || !constructionArgs.Height.HasValue)
            {
                throw new ValidationException("Height of rectangle should be greater than zero.");
            }
        }
    }
}
