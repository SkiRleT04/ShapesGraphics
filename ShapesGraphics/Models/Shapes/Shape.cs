using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Shapes
{
    public abstract class Shape
    {
        protected Shape(BaseConstructionArgs baseConstructionArgs)
        {
            CenterOfMass = baseConstructionArgs.CenterOfMass;
            Name = baseConstructionArgs.Name;
        }

        private Point _centerOfMass;
        public Point CenterOfMass
        {
            get
            {
                if(_centerOfMass == null)
                {
                    _centerOfMass = new Point();
                }
                return _centerOfMass;
            }
            set
            {
                _centerOfMass = value;
            }
        }

        public string Name { get; set; }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return $@"Name: {Name}\n
                      CenterOfMass: {CenterOfMass}\n";
        }
    }
}
