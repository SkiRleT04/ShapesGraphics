using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Validators;

namespace ShapesGraphics.Models.Shapes
{
    class Rectangle : Shape
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
            return $@"{base.ToString()}\n
                       Width: {Width}\n
                       Height: {Height}\n";
        }
    }
}
