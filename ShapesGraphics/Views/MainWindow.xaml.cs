﻿using ShapesGraphics.ViewModels;
using System.Windows;
using OpenTK.Graphics.OpenGL;

namespace ShapesGraphics.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(canvas);
            DataContext = _viewModel;
            GL.ClearColor(0f, 1f, 0f, 1.0f);
        }

        private void CanvasContainerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Width = e.NewSize.Height;
            canvas.Height = e.NewSize.Height;
        }
    }
}
