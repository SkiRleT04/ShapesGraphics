using ShapesGraphics.Models.Shapes;
using System;

namespace ShapesGraphics.Helpers
{
    public class GenerateShapeHelper
    {
        private readonly Random _random;

        public int PositiveDiapason { get; set; } = 1000;
        public int NegativeDiapason { get; set; } = -1000;

        public GenerateShapeHelper()
        {
            _random = new Random();
        }

        private Models.Common.Point GeneratePoint()
        {
            var point = new Models.Common.Point()
            {
                X = _random.Next(NegativeDiapason, PositiveDiapason),
                Y = _random.Next(NegativeDiapason, PositiveDiapason)
            };
            return point;
        }

        public Circle GenerateCircle()
        {
            var circle = new Circle()
            {
                CenterOfMass = GeneratePoint(),
                Radius = _random.Next(PositiveDiapason),
            };
            return circle;
        }

        public Rectangle GenerateRectangle()
        {
            var rectangle = new Rectangle()
            {
                CenterOfMass = GeneratePoint(),
                Height = _random.Next(PositiveDiapason),
                Width = _random.Next(PositiveDiapason)
            };
            return rectangle;
        }

        public Trapezium GenerateTrapezium()
        {
            var trapezium = new Trapezium()
            {
                CenterOfMass = GeneratePoint(),
                Height = _random.Next(PositiveDiapason),
                LongBase = _random.Next(PositiveDiapason),
                ShortBase = _random.Next(PositiveDiapason)
            };
            return trapezium;
        }
    }
}
