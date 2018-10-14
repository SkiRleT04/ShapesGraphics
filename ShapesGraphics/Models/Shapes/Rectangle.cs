using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Validators;
using System;

namespace ShapesGraphics.Models.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(BaseConstructionArgs constructionArgs, IValidator validator) : base(constructionArgs, validator)
        {
            if (constructionArgs is RectangleConstructionArgs rectangleConstructionArgs)
            {
                Width = rectangleConstructionArgs.Width;
                Height = rectangleConstructionArgs.Height;
            }
            else
            {
                throw new ConstructionArgsCastException("Cannot cast Base Construction Args to Rectangle Construction Args.");
            }
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
