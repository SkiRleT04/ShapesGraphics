using ShapesGraphics.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.Graphics
{
    public class DrawersPool
    {
        List<IDrawer<IShape>> Drawers { get; set; }

        public IDrawer<IShape> GetDrawer(Type type)
        {
            var draw = new CircleDrawer();
            dynamic drawer = Activator.CreateInstance(type);

            Drawers.Add(draw);
            return null;
        }
    }
}
