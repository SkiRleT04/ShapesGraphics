using DryIoc;
using ShapesGraphics.Graphics;
using ShapesGraphics.Models.Validators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShapesGraphics
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Container = new Container();
            Container.Register<CircleDrawer>(Reuse.Singleton);
            Container.Register<CircleValidator>(Reuse.Singleton);

            base.OnStartup(e);
        }
    }
}
