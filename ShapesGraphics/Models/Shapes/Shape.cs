using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Shapes
{
    abstract class Shape
    {
        protected Shape(BaseConstructionArgs baseConstructionArgs)
        {
            CenterOfMass = baseConstructionArgs.CenterOfMass;
            Name = baseConstructionArgs.Name;
        }

        protected Point CenterOfMass { get; set; }
        protected string Name { get; set; }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return $@"Name: {Name}\n
                      CenterOfMass: {CenterOfMass}\n";
        }
    }
}
