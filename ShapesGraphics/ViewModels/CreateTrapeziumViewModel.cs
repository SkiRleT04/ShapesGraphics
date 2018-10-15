using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DryIoc;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Models.Validators;

namespace ShapesGraphics.ViewModels
{
    public class CreateTrapeziumViewModel : BaseViewModel
    {
        #region Constructors
        public CreateTrapeziumViewModel()
        {
            TrapeziumConstructionArgs = new TrapeziumConstructionArgs()
            {
                CenterOfMass = new Models.Common.Point(),
                Height = default,
                LongBase = default,
                ShortBase = default
            };

            ConstructionArgs = TrapeziumConstructionArgs;
        }
        #endregion

        #region Properties
        private TrapeziumConstructionArgs _TrapeziumConstructionArgs;
        public TrapeziumConstructionArgs TrapeziumConstructionArgs
        {
            get
            {
                return _TrapeziumConstructionArgs;
            }
            set
            {
                SetProperty(ref _TrapeziumConstructionArgs, value);
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
                    App.Container.Resolve<TrapeziumValidator>().Validate(TrapeziumConstructionArgs);

                    Trapezium trapezium = new Trapezium
                    {
                        CenterOfMass = TrapeziumConstructionArgs.CenterOfMass,
                        LongBase = TrapeziumConstructionArgs.LongBase,
                        ShortBase = TrapeziumConstructionArgs.ShortBase,
                        Height = TrapeziumConstructionArgs.Height
                    };

                    return () => Shape = trapezium;
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
