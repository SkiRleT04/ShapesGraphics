using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.ViewModels
{
    public class CreateCircleViewModel : BaseViewModel
    {
        #region Constructors
        public CreateCircleViewModel()
        {

        }

        //public CreateCircleViewModel(Shape shape)
        //{
        //    Name = shape.Name;
        //    CenterOfMass = shape.CenterOfMass;

        //    if(shape is Circle circle)
        //    {
        //        Radius = circle.Radius;
        //    }
        //    else
        //    {
        //        throw new ConstructionArgsCastException("Cannot cast shape to circle");
        //    }
        //}

        //public CreateCircleViewModel(string name, Point centerOfMass, int radius)
        //{
        //    Name = name;
        //    CenterOfMass = centerOfMass;
        //    Radius = radius;
        //}
        #endregion

        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                Shape.Name = value;
            }
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
                SetProperty(ref _centerOfMass, value);
                Shape.CenterOfMass = value;
            }
        }

        private int _radius;
        public int Radius
        {
            get { return _radius; }
            set
            {
                SetProperty(ref _radius, value);
                if (Shape is Circle circle)
                {
                    circle.Radius = value;
                }
                else
                {
                    throw new ConstructionArgsCastException("Cannot cast shape to circle.");
                }
            }
        }

        private Shape _shape;
        public Shape Shape
        {
            get
            {
                if (_shape == null)
                {
                    _shape = new Circle(new CircleConstructionArgs { CenterOfMass = CenterOfMass, Name = Name, Radius = Radius });
                }
                return _shape;
            }
            set
            {
                _shape = value;
            }
        }
        #endregion
    }
}
