using ShapesGraphics.Exceptions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using System;
using System.Windows;

namespace ShapesGraphics.ViewModels
{
    public abstract class BaseViewModel : BindableObject
    {
        private BaseConstructionArgs _constructionArgs;
        public BaseConstructionArgs ConstructionArgs
        {
            get
            {
                return _constructionArgs;
            }
            set
            {
                SetProperty(ref _constructionArgs, value);
            }
        }

        public abstract Shape Shape { get; set; }
        public abstract Action Save { get; }

        public Command CloseCommand
        {
            get
            {
                return new Command(Close);
            }
        }

        public Action<object> Close { get; set; }

        public bool Closing(object isDialogPromtUnrequired)
        {
            try
            {
                if (!(bool)isDialogPromtUnrequired)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        Save?.Invoke();
                    }
                    return true;
                }
                Save?.Invoke();
                return true;
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
