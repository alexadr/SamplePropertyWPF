using System.Collections.Generic;
using System.Windows.Input;
using SampleProject.Models;
using SampleProject.Utils;
using SampleProject.Views;

namespace SampleProject.ViewModels
{
    /// <summary>
    ///     That main management class. Manage all Control in MainViewForm and manipulate main Frame control
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        ///     Default constructor. Init default data and commands
        /// </summary>
        public MainViewModel()
        {
            _listPropertyModels = GetDefaultListPropertyModels();
            InitCommands();
            ShowPropertiesView();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     CurrentViewModel which attached to main Frame control
        /// </summary>
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     ICommand Show Properties View
        /// </summary>
        public ICommand ShowPropertiesCommand { get; set; }


        /// <summary>
        ///     ICommand Show "Add new Propery" View
        /// </summary>
        public ICommand AddNewPropertyCommand { get; set; }

        #endregion

        #region Fields

        private object _currentViewModel;
        private readonly List<PropertyModel> _listPropertyModels;

        #endregion

        #region Public Methonds

        /// <summary>
        ///     Show  "Add new Propery" View through set CurrentViewModel
        /// </summary>
        public void ShowAddNewPropertyView()
        {
            var p = new AddProperty {DataContext = new AddPropertiViewModel()};
            CurrentViewModel = p;
        }

        /// <summary>
        ///     Add to original collection new PropertyModel //todo will good move to class Helper
        /// </summary>
        /// <param name="model"></param>
        public void AddNewProperty(PropertyModel model)
        {
            _listPropertyModels.Add(model);
        }

        /// <summary>
        ///     Show  Properties View through set CurrentViewModel
        /// </summary>
        public void ShowPropertiesView()
        {
            CurrentViewModel = new PropertiesView {DataContext = new PropertiesViewModel(_listPropertyModels)};
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Remove incoming obj from orignal collection Property models //todo need move to special class Helper
        /// </summary>
        public void RemovePropery(PropertyModel model)
        {
            _listPropertyModels.Remove(model);
        }

        /// <summary>
        ///     Initialisations whole commands
        /// </summary>
        private void InitCommands()
        {
            AddNewPropertyCommand = new RelayCommand(o => { ShowAddNewPropertyView(); });
            ShowPropertiesCommand =
                new RelayCommand(p => { ShowPropertiesView(); });
        }

        /// <summary>
        ///     Generate list of 3 property
        /// </summary>
        /// <returns></returns>
        private List<PropertyModel> GetDefaultListPropertyModels()
        {
            var list = new List<PropertyModel>
            {
                new PropertyModel("Berlin", "Ben", 2, 1000),
                new PropertyModel("Oslo", "Pol", 1, 2000),
                new PropertyModel("London", "Kati", 3, 3000)
            };
            return list;
        }

        #endregion
    }
}