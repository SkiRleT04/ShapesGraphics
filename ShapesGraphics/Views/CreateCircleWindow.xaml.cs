using ShapesGraphics.Exceptions;
using ShapesGraphics.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShapesGraphics.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateCircleWindow.xaml
    /// </summary>
    public partial class CreateCircleWindow : BaseWindow
    {
        public CreateCircleWindow(CreateCircleViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
