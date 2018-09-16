using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Validators;
using System;

namespace ShapesGraphics.Models.Shapes
{
    class Trapezium : Shape
    {
        public Trapezium(BaseConstructionArgs baseConstructionArgs, IValidator validator) : base(baseConstructionArgs, validator)
        {
            if (baseConstructionArgs is TrapeziumConstructionArgs trapeziumConstructionArgs)
            {
                ShortBase = trapeziumConstructionArgs.ShortBase;
                LongBase = trapeziumConstructionArgs.LongBase;
                Height = trapeziumConstructionArgs.Height;
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Trapezium Construction Args.");
            }
        }

        public int ShortBase { get; set; }
        public int LongBase { get; set; }
        public int Height { get; set; }

        public override double GetArea()
        {
            return ((ShortBase + LongBase) * Height) / 2;
        }

        public override double GetPerimeter()
        {
            return ShortBase + LongBase + 2 * Math.Sqrt(Math.Pow(Height, 2) + Math.Pow((ShortBase - LongBase), 2) / 4);
        }

        public override string ToString()
        {
            return $@"{base.ToString()}\n
                       ShortBase: {ShortBase}\n
                       LongBase: {LongBase}\n
                       Height: {Height}\n";
        }
    }
}
