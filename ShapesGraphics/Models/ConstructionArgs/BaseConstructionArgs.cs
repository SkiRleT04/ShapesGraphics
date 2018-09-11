using ShapesGraphics.Models.Common;

namespace ShapesGraphics.Models.ConstructionArgs
{
    public abstract class BaseConstructionArgs
    {
        public Point CenterOfMass { get; set; }
        public string Name { get; set; }
    }
}
