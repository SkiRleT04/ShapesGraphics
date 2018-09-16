using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.ViewModels;
using ShapesGraphics.Views;
using System.Windows;

namespace ShapesGraphics
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new CreateCircleViewModel();
            CreateCircleWindow window = new CreateCircleWindow(viewModel);
            window.ShowDialog();
            var shape = (window.DataContext as BaseViewModel).Shape;
        }
    }
}
