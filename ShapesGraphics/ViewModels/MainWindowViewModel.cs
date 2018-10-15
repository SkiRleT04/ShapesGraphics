using ShapesGraphics.Enums;
using ShapesGraphics.Extensions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfOpenGlControl;
using OpenTK.Graphics.OpenGL;


namespace ShapesGraphics.ViewModels
{
    public class MainWindowViewModel : BindableObject
    {
        public MainWindowViewModel(WpfOpenGLControl canvas)
        {
            _canvas = canvas;
        }

        #region Commands
        private Command _createShapeCommand;
        public Command CreateShapeCommand
        {
            get
            {
                if (_createShapeCommand == null)
                {
                    _createShapeCommand = new Command(OnCreateShape);
                }
                return _createShapeCommand;
            }
        }
        private void OnCreateShape()
        {
            BaseWindow window = null;

            if(SelectedShapeType == ShapeType.Circle)
            {
                var viewModel = new CreateCircleViewModel();
                window = new CreateCircleWindow(viewModel);
            }

            if (SelectedShapeType == ShapeType.Rectangle)
            {
                var viewModel = new CreateRectangleViewModel();
                window = new CreateRectangleWindow(viewModel);
            }

            if (SelectedShapeType == ShapeType.Trapezium)
            {
                var viewModel = new CreateTrapeziumViewModel();
                window = new CreateTrapeziumWindow(viewModel);
            }

            window.ShowDialog();

            var shape = (window.DataContext as BaseViewModel).Shape;

            if(shape != null)
            {
                ShapesList.Add(shape);
            }
        }

        private Command _deleteShapeCommand;
        public Command DeleteShapeCommand
        {
            get
            {
                if (_deleteShapeCommand == null)
                {
                    _deleteShapeCommand = new Command(OnDeleteShape, CanEditOrDeleteShape);
                }
                return _deleteShapeCommand;
            }
        }
        private void OnDeleteShape()
        {
            ShapesList.Remove(SelectedShape);
            SelectedShape = ShapesList.LastOrDefault();
        }

        private bool CanEditOrDeleteShape()
        {
            return SelectedShape != null;
        }
        #endregion Commands

        #region Properties
        private Shape _selectedShape;
        public Shape SelectedShape
        {
            get
            {
                return _selectedShape;
            }
            set
            {
                SetProperty(ref _selectedShape, value);

                DeleteShapeCommand.RaiseCanExecuteChanged();

                if (_selectedShape != null)
                {
                    SelectedShapeProperties = _selectedShape.GetShapeCharacteristics();
                    _selectedShape.Draw();
                }
                else
                {
                    SelectedShapeProperties = string.Empty;
                    GL.ClearColor(0f, 1f, 0f, 1.0f);
                }
                _canvas.Invalidate();
            }
        }

        private ObservableCollection<Shape> _shapesList;
        public ObservableCollection<Shape> ShapesList
        {
            get
            {
                if (_shapesList == null)
                {
                    _shapesList = new ObservableCollection<Shape>();
                }
                return _shapesList;
            }
            set
            {
                SetProperty(ref _shapesList, value);
            }
        }

        private ShapeType _selectedShapeType;
        public ShapeType SelectedShapeType
        {
            get
            {
                return _selectedShapeType;
            }
            set
            {
                SetProperty(ref _selectedShapeType, value);
            }
        }

        public IEnumerable<ShapeType> ShapeTypesList
        {
            get
            {
                return Enum.GetValues(typeof(ShapeType)).Cast<ShapeType>();
            }
        }

        private string _selectedShapeProperties;
        public string SelectedShapeProperties
        {
            get
            {
                return _selectedShapeProperties;
            }
            set
            {
                SetProperty(ref _selectedShapeProperties, value);
            }
        }
        #endregion Properties

        #region Variables
        private WpfOpenGLControl _canvas;
        #endregion
    }
}
