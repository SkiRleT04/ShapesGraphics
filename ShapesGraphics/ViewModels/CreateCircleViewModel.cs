using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Models.Validators;
using System;

namespace ShapesGraphics.ViewModels
{
    public class CreateCircleViewModel : BaseViewModel
    {
        #region Constructors
        public CreateCircleViewModel()
        {
            CircleConstructionArgs = new CircleConstructionArgs()
            {
                CenterOfMass = new Point(),
                Name = string.Empty,
                Radius = default
            };

            ConstructionArgs = CircleConstructionArgs;
        }
        #endregion

        #region Properties
        private CircleConstructionArgs _circleConstructionArgs;
        public CircleConstructionArgs CircleConstructionArgs
        {
            get
            {
                return _circleConstructionArgs;
            }
            set
            {
                SetProperty(ref _circleConstructionArgs, value);
            }
        }

        public override Shape Shape { get; set; }
        #endregion
      
        public override Action Save
        {
            get
            {
                return () => Shape = new Circle(CircleConstructionArgs, new CircleValidator());
            }
        }
    }
}

