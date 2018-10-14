using DryIoc;
using ShapesGraphics.Models.Shapes;
using System;
using System.Linq;
using System.Reflection;

namespace ShapesGraphics.Graphics
{
    public static class DrawerHelper
    {
        public static void Draw(Shape shape)
        {
            if (shape == null)
            {
                throw new NullReferenceException("Shape should not be null.");
            }

            var drawerType = GetDrawer(shape.GetType());

            if (drawerType == null)
            {
                throw new NotImplementedException("There is no such drawer for your shape.");
            }

            var drawerInstance = App.Container.Resolve(drawerType);

            if (drawerInstance == null)
            {
                throw new NotImplementedException("There is no drawer singleton.");
            }

            MethodInfo methodInfo = drawerType.GetMethod("Draw");
            methodInfo.Invoke(drawerInstance, new object[] { shape });
        }

        private static Type GetDrawer(Type shapeType)
        {
            var AllTypesOfIRepository = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                         let y = x.BaseType
                                         where !x.IsAbstract &&
                                         !x.IsInterface &&
                                         y != null &&
                                         y.IsGenericType &&
                                         y.GetMethod("Draw") != null &&
                                         y.GenericTypeArguments[0] == shapeType &&
                                         y.GetGenericTypeDefinition() == typeof(BaseDrawer<>)
                                         select x).ToList().FirstOrDefault();
            return AllTypesOfIRepository;
        }
    }
}
