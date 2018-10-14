using DryIoc;
using ShapesGraphics.Graphics;
using ShapesGraphics.Helpers;
using ShapesGraphics.Models.Validators;
using ShapesGraphics.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace ShapesGraphics.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            DrawersPool drawersPool = new DrawersPool();
            drawersPool.GetDrawer(typeof(CircleDrawer));
        }

        private void GlRender(object sender, EventArgs e)
        {
          
        }
    }
}
