using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapesGraphics.Views.Templates
{
    /// <summary>
    /// Логика взаимодействия для CreateShapeBaseParams.xaml
    /// </summary>
    public partial class CreateShapeBaseParamsTemplate : UserControl
    {
        public CreateShapeBaseParamsTemplate()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Regex regex = new Regex(@"(^-$)|(^-?\d+$)");
                bool isValid = regex.IsMatch(textBox.Text) || string.IsNullOrEmpty(textBox.Text);

                if (textBox.Text.Length > 0)
                {
                    if (!regex.IsMatch(e.Text))
                    {
                        isValid = false;
                    }

                    if (e.Text == "-")
                    {
                        isValid = false;
                    }
                }

                e.Handled = !isValid;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
