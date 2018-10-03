using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                CenterOfMass = new Point(),
                Name = string.Empty,
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
                return () => Shape = new Trapezium(TrapeziumConstructionArgs, new TrapeziumValidator());
            }
        }
    }
}
