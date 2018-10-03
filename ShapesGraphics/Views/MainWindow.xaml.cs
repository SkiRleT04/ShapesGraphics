using ShapesGraphics.ViewModels;
using System.Windows;

namespace ShapesGraphics.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
