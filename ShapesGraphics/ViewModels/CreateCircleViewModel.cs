using DryIoc;
using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Models.Validators;
using System;
using System.Windows;

namespace ShapesGraphics.ViewModels
{
    public class CreateCircleViewModel : BaseViewModel
    {
        #region Constructors
        public CreateCircleViewModel()
        {
            CircleConstructionArgs = new CircleConstructionArgs()
            {
                CenterOfMass = new Models.Common.Point(),
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
                App.Container.Resolve<CircleValidator>().Validate(CircleConstructionArgs);

                Circle circle = new Circle
                {
                    CenterOfMass = CircleConstructionArgs.CenterOfMass,
                    Radius = CircleConstructionArgs.Radius.GetValueOrDefault(0)
                };

                return () => Shape = circle;
            }
        }
    }
}

