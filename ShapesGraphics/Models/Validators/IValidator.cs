using ShapesGraphics.Models.ConstructionArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.Models.Validators
{
    interface IValidator
    {
        bool IsValid(BaseConstructionArgs baseContructionArgs);
    }
}
