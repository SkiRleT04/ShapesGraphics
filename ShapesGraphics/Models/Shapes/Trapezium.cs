using ShapesGraphics.Models.ConstructionArgs;
using System;

namespace ShapesGraphics.Models.Shapes
{
    public class Trapezium : Shape
    {
        private static int _trapeziumsCount = 0;

        public Trapezium()
        {
            Name = $"T{++_trapeziumsCount}";
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
            return ShortBase + LongBase + 2 * Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Math.Abs((ShortBase - LongBase)), 2) / 4);
        }

        public override string ToString()
        {
            return $"Trapezium{Environment.NewLine}{base.ToString()}ShortBase: {ShortBase}{Environment.NewLine}LongBase: {LongBase}{Environment.NewLine}Height: {Height}{Environment.NewLine}";
        }
    }
}
