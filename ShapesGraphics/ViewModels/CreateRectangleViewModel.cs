using System;
using System.Windows;
using DryIoc;
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
                CenterOfMass = new Models.Common.Point(),
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
                try
                {
                    App.Container.Resolve<RectangleValidator>().Validate(RectangleConstructionArgs);

                    Rectangle rectangle = new Rectangle
                    {
                        CenterOfMass = RectangleConstructionArgs.CenterOfMass,
                        Width = RectangleConstructionArgs.Width,
                        Height = RectangleConstructionArgs.Height
                    };

                    return () => Shape = rectangle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return default;
            }
        }
    }
}
