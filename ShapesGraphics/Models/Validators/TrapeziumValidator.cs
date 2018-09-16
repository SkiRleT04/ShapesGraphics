using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    class TrapeziumValidator : IValidator
    {
        public void Validate(BaseConstructionArgs baseConstructionArgs)
        {
            if (baseConstructionArgs is TrapeziumConstructionArgs trapeziumConstructionArgs)
            {
                if (trapeziumConstructionArgs.Height <= 0)
                {
                    throw new ValidationException("Height of trapezium should be greater than zero.");

                }
                if (trapeziumConstructionArgs.LongBase <= 0)
                {
                    throw new ValidationException("LongBase of trapezium should be greater than zero.");

                }
                if (trapeziumConstructionArgs.ShortBase <= 0)
                {
                    throw new ValidationException("ShortBase of trapezium should be greater than zero.");

                }
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Trapezium Construction Args.");
            }
        }
    }
}
