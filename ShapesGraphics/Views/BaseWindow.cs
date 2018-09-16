using ShapesGraphics.Exceptions;
using ShapesGraphics.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ShapesGraphics.Views
{
    public partial class BaseWindow : Window
    {
        protected BaseViewModel _viewModel;
        private Func<object, bool> Closing;
        private bool isDialogPromtUnrequired;

        protected BaseWindow(BaseViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Close = CloseWindow;
            Closing = _viewModel.Closing;
        }

        private void CloseWindow(object parameter)
        {
            isDialogPromtUnrequired = parameter == null ? false : true;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            bool isClosed = Closing.Invoke(isDialogPromtUnrequired);
            e.Cancel = !isClosed;
        }
    }
}
