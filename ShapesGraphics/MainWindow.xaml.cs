using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.ViewModels;
using ShapesGraphics.Views;
using System.Windows;

namespace ShapesGraphics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateCircleViewModel viewModel = new CreateCircleViewModel();
            CreateCircleWindow page = new CreateCircleWindow(viewModel);
            page.ShowDialog();
            var filledViewModel = page.DataContext;
        }
    }
}
