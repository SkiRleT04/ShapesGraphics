using ShapesGraphics.Enums;
using ShapesGraphics.Models.Common;
using ShapesGraphics.Models.ConstructionArgs;
using ShapesGraphics.Models.Shapes;
using ShapesGraphics.Models.Validators;
using ShapesGraphics.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ShapesGraphics.ViewModels
{
    public class MainWindowViewModel : BindableObject
    {
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

        private Command _editShapeCommand;
        public Command EditShapeCommand
        {
            get
            {
                if (_editShapeCommand == null)
                {
                    _editShapeCommand = new Command(OnEditShape, CanEditOrDeleteShape);
                }
                return _editShapeCommand;
            }
        }
        private void OnEditShape()
        {

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
            SelectedShape = null;
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
                EditShapeCommand.RaiseCanExecuteChanged();
                DeleteShapeCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Shape> _shapesList;
        public ObservableCollection<Shape> ShapesList
        {
            get
            {
                if (_shapesList == null)
                {
                    _shapesList = new ObservableCollection<Models.Shapes.Shape>();

                    //var circle = new Circle(
                    //        new CircleConstructionArgs { CenterOfMass = new Point { X = 1, Y = 2 }, Name = "123", Radius = 3 }
                    //        , new CircleValidator());

                    //_shapesList.Add(circle);
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
        #endregion Properties
    }
}
