using ShapesGraphics.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ShapesGraphics.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(gl);
            DataContext = _viewModel;
        }
      
    }
}
