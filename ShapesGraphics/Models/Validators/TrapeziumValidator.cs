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
        public bool IsValid(BaseConstructionArgs baseConstructionArgs)
        {
            if (baseConstructionArgs is TrapeziumConstructionArgs trapeziumConstructionArgs)
            {
                if (trapeziumConstructionArgs.Height <= 0 || 
                    trapeziumConstructionArgs.LongBase <= 0 || 
                    trapeziumConstructionArgs.ShortBase <= 0)
                {
                    return false;
                }
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Trapezium Construction Args.");
            }
            return true;
        }
    }
}
