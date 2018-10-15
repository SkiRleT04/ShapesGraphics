using ShapesGraphics.Models.ConstructionArgs;
using System;

namespace ShapesGraphics.Models.Shapes
{
    public class Circle : Shape
    {
        private static int _circlesCount = 0;

        public Circle()
        {
           Name =  $"C{++_circlesCount}";
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
            return $"Circle{Environment.NewLine}{base.ToString()}Radius: {Radius}{Environment.NewLine}";
        }
    }
}
