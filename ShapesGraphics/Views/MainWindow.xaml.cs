using ShapesGraphics.ViewModels;
using System.Windows;

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
        }

        private void CanvasContainerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Width = e.NewSize.Height;
            canvas.Height = e.NewSize.Height;
        }
    }
}
