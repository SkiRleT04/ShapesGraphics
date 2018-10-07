using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.Models.Shapes
{
    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }
}
