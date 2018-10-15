using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    public class TrapeziumValidator : IValidator<TrapeziumConstructionArgs>
    {
        public void Validate(TrapeziumConstructionArgs constructionArgs)
        {
            if (constructionArgs.Height <= 0 || !constructionArgs.Height.HasValue)
            {
                throw new ValidationException("Height of trapezium should be greater than zero.");
            }
            if (constructionArgs.LongBase <= 0 || !constructionArgs.LongBase.HasValue)
            {
                throw new ValidationException("LongBase of trapezium should be greater than zero.");
            }
            if (constructionArgs.ShortBase <= 0 || !constructionArgs.ShortBase.HasValue)
            {
                throw new ValidationException("ShortBase of trapezium should be greater than zero.");
            }
        }
    }
}
