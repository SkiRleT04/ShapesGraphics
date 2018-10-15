using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    public class CircleValidator : IValidator<CircleConstructionArgs>
    {
        public void Validate(CircleConstructionArgs constructionArgs)
        {
            if (constructionArgs.Radius <= 0 || !constructionArgs.Radius.HasValue)
            {
                throw new ValidationException("Radius of circle should be greater than zero.");
            }
        }
    }
}
