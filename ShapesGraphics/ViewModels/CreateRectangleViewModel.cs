using System;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Models.Validators;

namespace ShapesGraphics.ViewModels
{
    public class CreateRectangleViewModel : BaseViewModel
    {
        #region Constructors
        public CreateRectangleViewModel()
        {
            RectangleConstructionArgs = new RectangleConstructionArgs()
            {
                CenterOfMass = new Point(),
                Name = string.Empty,
                Height = default,
                Width = default
            };

            ConstructionArgs = RectangleConstructionArgs;
        }
        #endregion

        #region Properties
        private RectangleConstructionArgs _RectangleConstructionArgs;
        public RectangleConstructionArgs RectangleConstructionArgs
        {
            get
            {
                return _RectangleConstructionArgs;
            }
            set
            {
                SetProperty(ref _RectangleConstructionArgs, value);
            }
        }

        public override Shape Shape { get; set; }
        #endregion

        public override Action Save
        {
            get
            {
                return () => Shape = new Rectangle(RectangleConstructionArgs, new RectangleValidator());
            }
        }
    }
}
