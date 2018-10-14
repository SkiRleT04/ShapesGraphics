using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Validators;
using System;

namespace ShapesGraphics.Models.Shapes
{
    public abstract class Shape
    {
        protected Shape(BaseConstructionArgs baseConstructionArgs, IValidator validator)
        {
            CenterOfMass = baseConstructionArgs.CenterOfMass;
            Name = baseConstructionArgs.Name;
            validator.Validate(baseConstructionArgs);
        }

        private Point _centerOfMass;
        public Point CenterOfMass
        {
            get
            {
                if (_centerOfMass == null)
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

        public override string ToString()
        {
            return $"Name: {Name}{Environment.NewLine}CenterOfMass: ({CenterOfMass.X}; {CenterOfMass.Y}){Environment.NewLine}";
        }

        public string GetShapeCharacteristics()
        {
            return $"Area: {Math.Round(GetArea(), 2)}{Environment.NewLine}Perimeter: {Math.Round(GetPerimeter(), 2)}";
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
