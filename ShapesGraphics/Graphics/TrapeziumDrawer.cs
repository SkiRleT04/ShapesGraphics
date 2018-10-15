using System;
using ShapesGraphics.Models.Shapes;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace ShapesGraphics.Graphics
{
    public class TrapeziumDrawer : BaseDrawer<Trapezium>
    {
        public override void Draw(Trapezium shape)
        {
            GL.ClearColor(0f, 1f, 0f, 1.0f);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Color3(1f, 1f, 1f);
            GL.LoadIdentity();

            GL.Begin(PrimitiveType.Polygon);

            float shortBase = shape.ShortBase;
            float longBase = shape.LongBase;
            float height = shape.Height;
            float oX = shape.CenterOfMass.X;
            float oY = shape.CenterOfMass.Y;

            float halfShortBase = shortBase / 2.0f;
            float halfLongBase = longBase / 2.0f;
            float halfHeight = height / 2.0f;
            float halfSubLongShortBase = (longBase - shortBase) / 2.0f;

            float p1X = oX - halfShortBase;
            float p1Y = oY + halfHeight;

            float p2X = oX + halfShortBase;
            float p2Y = oY + halfHeight;

            float p3X = oX + halfShortBase + halfSubLongShortBase;
            float p3Y = oY - halfHeight;

            float p4X = oX - halfShortBase - halfSubLongShortBase;
            float p4Y = oY - halfHeight;

            List<float> listValuesForCalculateCoefficient = new List<float>
            {
                p1X,
                p1Y,
                p2X,
                p2Y,
                p3X,
                p3Y,
                p4X,
                p4Y,
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
