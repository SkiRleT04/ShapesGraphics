using System;
using ShapesGraphics.Models.Shapes;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace ShapesGraphics.Graphics
{
    public class CircleDrawer : BaseDrawer<Circle>
    {
        public override void Draw(Circle circle)
        {
            GL.ClearColor(0f, 1f, 0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Color3(1f, 1f, 1f);
            GL.LoadIdentity();

            GL.Begin(PrimitiveType.LineLoop);
            float radius = circle.Radius;

            float oX = 0f;
            float oY = 0f;

            int triangleAmount = 100;

            List<float> listValuesForCalculateCoefficient = new List<float>();

            for (int i = 0; i <= triangleAmount; i++)
            {
                float pX = (float)(oX + (radius * Math.Cos(i * 2.0f * Math.PI / triangleAmount)));
                float pY = (float)(oY + (radius * Math.Sin(i * 2.0f * Math.PI / triangleAmount)));
                listValuesForCalculateCoefficient.Add(pX);
                listValuesForCalculateCoefficient.Add(pY);
            }

            int coefficient = GetСoefficient(listValuesForCalculateCoefficient);

            for (int i = 0; i <= triangleAmount; i++)
            {
                float pX = (float)(oX + (radius * Math.Cos(i * 2.0f * Math.PI / triangleAmount)))/coefficient;
                float pY = (float)(oY + (radius * Math.Sin(i * 2.0f * Math.PI / triangleAmount)))/coefficient;
                GL.Vertex2(pX,pY);
            }

            GL.End();
        }
    }
}
