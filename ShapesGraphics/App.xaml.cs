using DryIoc;
using ShapesGraphics.Graphics;
using ShapesGraphics.Helpers;
using ShapesGraphics.Models.Validators;
using System.Windows;

namespace ShapesGraphics
{
    public partial class App : Application
    {
        public static Container Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container = new Container();

            Container.Register<CircleDrawer>(Reuse.Singleton);
            Container.Register<RectangleDrawer>(Reuse.Singleton);
            Container.Register<TrapeziumDrawer>(Reuse.Singleton);

            Container.Register<CircleValidator>(Reuse.Singleton);
            Container.Register<TrapeziumValidator>(Reuse.Singleton);
            Container.Register<RectangleValidator>(Reuse.Singleton);

            Container.Register<GenerateShapeHelper>(Reuse.Singleton);

            base.OnStartup(e);
        }
    }
}
