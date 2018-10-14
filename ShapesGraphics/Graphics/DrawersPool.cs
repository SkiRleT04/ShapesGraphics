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
            //var draw = new CircleDrawer();
            //IDrawer<IShape> drawer =(IDrawer<IShape>)/* Activator.CreateInstance(type)*/new CircleDrawer();
            //IDrawer<IShape> drawer = new CircleDrawer();
            //Drawers.Add(drawer);
            return null;
        }
    }
}
