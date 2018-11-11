using ShapesGraphics.Enums;
using ShapesGraphics.Extensions;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WpfOpenGlControl;
using OpenTK.Graphics.OpenGL;
using ShapesGraphics.List;

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
                ShapesFullList.Add(shape);
                ShapesFullList = new CustomList<Shape>(ShapesFullList);
                ApplyFilter();
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
            ShapesFullList.Remove(SelectedShape);
            ShapesFullList = new CustomList<Shape>(ShapesFullList);
            ApplyFilter();
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
                    GL.Clear(ClearBufferMask.ColorBufferBit);
                }

                _canvas.Invalidate();
            }
        }

        private CustomList<Shape> _shapesList;
        public CustomList<Shape> ShapesList
        {
            get
            {
                if (_shapesList == null)
                {
                    _shapesList = new CustomList<Shape>();
                }
                return _shapesList;
            }
            set
            {
                SetProperty(ref _shapesList, value);
            }
        }

        private CustomList<Shape> _shapesFullList;
        public CustomList<Shape> ShapesFullList
        {
            get
            {
                if (_shapesFullList == null)
                {
                    _shapesFullList = new CustomList<Shape>();
                }
                return _shapesFullList;
            }
            set
            {
                SetProperty(ref _shapesFullList, value);
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

        private bool _isCircleSelected;
        public bool IsCircleSelected
        {
            get
            {
                return _isCircleSelected;
            }
            set
            {
                SetProperty(ref _isCircleSelected, value);
                ApplyFilter();
            }
        }

        private bool _isRectangleSelected;
        public bool IsRectangleSelected
        {
            get
            {
                return _isRectangleSelected;
            }
            set
            {
                SetProperty(ref _isRectangleSelected, value);
                ApplyFilter();
            }
        }


        private bool _isTrapeziumSelected;
        public bool IsTrapeziumSelected
        {
            get
            {
                return _isTrapeziumSelected;
            }
            set
            {
                SetProperty(ref _isTrapeziumSelected, value);
                ApplyFilter();
            }
        }
        #endregion Properties

        #region Variables
        private WpfOpenGLControl _canvas;
        #endregion

        #region Methods
        private void ApplyFilter()
        {
            if(!IsCircleSelected && !IsTrapeziumSelected && !IsRectangleSelected)
            {
                ShapesList = new CustomList<Shape>(ShapesFullList);
                return;
            }

            var filteredList = ShapesFullList.Where(x=>
            (IsCircleSelected && x is Circle) ||
            (IsTrapeziumSelected && x is Trapezium) ||
            (IsRectangleSelected && x is Rectangle)).ToList();

            ShapesList = new CustomList<Shape>(filteredList);
        }
        #endregion
    }
}
