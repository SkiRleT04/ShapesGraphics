using ShapesGraphics.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.Graphics
{
    public interface IDrawer<in T> where T:IShape
    {
        void Draw(T shape);
    }
}
