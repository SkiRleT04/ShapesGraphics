using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;
using System;

namespace ShapesGraphics.Models.Shapes
{
    public class Circle : Shape
    {
        public Circle(BaseConstructionArgs baseConstructionArgs) : base(baseConstructionArgs)
        {
            if (baseConstructionArgs is CircleConstructionArgs circleConstructionArgs)
            {
                Radius = circleConstructionArgs.Radius;
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Circle Construction Args.");
            }
        }

        public int Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $@"{base.ToString()}\n
                       Radius: {Radius}\n";
        }
    }
}
