using ShapesGraphics.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesGraphics.Graphics
{
    public abstract class BaseDrawer<T> : IDrawer<T> where T : IShape
    {
        public abstract void Draw(T shape);

        protected int GetСoefficient(List<float> listValues)
        {
            float maxValue = listValues.Select(Math.Abs).Max();
            int coefficient = Convert.ToInt32(Math.Ceiling(maxValue));
            return coefficient;
        }
    }
}
