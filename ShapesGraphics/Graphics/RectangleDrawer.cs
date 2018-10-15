using ShapesGraphics.Models.Shapes;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace ShapesGraphics.Graphics
{
    public class RectangleDrawer : BaseDrawer<Rectangle>
    {
        public override void Draw(Rectangle rectangle)
        {
            GL.ClearColor(0f, 1f, 0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Color3(1f, 1f, 1f);
            GL.LoadIdentity();
            GL.MapGrid1(1, 5, 5);

            GL.Begin(PrimitiveType.Polygon);
            float width = rectangle.Width;
            float height = rectangle.Height;
            float oX = rectangle.CenterOfMass.X;
            float oY = rectangle.CenterOfMass.Y;
            float halfWidth = width / 2.0f;
            float halfHeight = height / 2.0f;

            float p1X = oX - halfWidth;
            float p1Y = oY + halfHeight;

            float p2X = oX + halfWidth;
            float p2Y = oY + halfHeight;

            float p3X = oX + halfWidth;
            float p3Y = oY - halfHeight;

            float p4X = oX - halfWidth;
            float p4Y = oY - halfHeight;

            List<float> listValuesForCalculateCoefficient = new List<float>
            {
                p1X,
                p1Y,
                p2X,
                p2Y,
                p3X,
                p3Y,
                oX,
                oY
            };

            int coefficient = GetСoefficient(listValuesForCalculateCoefficient);

            GL.Vertex2(p1X / coefficient, p1Y / coefficient);
            GL.Vertex2(p2X / coefficient, p2Y / coefficient);
            GL.Vertex2(p3X / coefficient, p3Y / coefficient);
            GL.Vertex2(p4X / coefficient, p4Y / coefficient);

            GL.End();
        }
    }
}
