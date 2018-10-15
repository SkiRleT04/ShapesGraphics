using ShapesGraphics.Models.ConstructionArgs;
using System;

namespace ShapesGraphics.Models.Shapes
{
    public class Rectangle : Shape
    {
        private static int _rectanglesCount = 0;

        public Rectangle()
        {
            Name = $"R{++_rectanglesCount}";
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Rectangle{Environment.NewLine}{base.ToString()}Width: {Width}{Environment.NewLine}Height: {Height}{Environment.NewLine}";
        }
    }
}
