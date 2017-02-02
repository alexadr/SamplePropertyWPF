using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SampleProject.Models;
using SampleProject.Utils;

namespace SampleProject.ViewModels
{
    /// <summary>
    ///     Class for Properties View
    /// </summary>
    public class PropertiesViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<PropertyViewModel> _propertyViewModels;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="models"></param>
        public PropertiesViewModel(List<PropertyModel> models)
        {
            InitData(models);
            RemoveCommand = new RelayCommand(Remove);
        }

        #endregion

        #region Properties

        /// <summary>
        ///     ICommand Remove property
        /// </summary>
        public ICommand RemoveCommand { get; set; }

        /// <summary>
        ///     Collections
        /// </summary>
        public ObservableCollection<PropertyViewModel> PropertyViewModels
        {
            get { return _propertyViewModels; }
            set
            {
                _propertyViewModels = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Initialisation data sources from incoming Property Models
        /// </summary>
        private void InitData(List<PropertyModel> models)
        {
            GenerateObservableCollectionfromPropertyModels(models);
        }


        /// <summary>
        ///     Generate ObservableCollection which will use in View from original collection properties
        /// </summary>
        /// <param name="propertyModels">original collection properties</param>
        private void GenerateObservableCollectionfromPropertyModels(List<PropertyModel> propertyModels)
        {
            _propertyViewModels = new ObservableCollection<PropertyViewModel>();
            if (propertyModels == null) return;
            foreach (var listPropertyModel in propertyModels)
                _propertyViewModels.Add(new PropertyViewModel(listPropertyModel));
        }


        /// <summary>
        ///     Remove incoming obj from currect Observable collection and orignal collection Property models //todo need move to
        ///     special class Helper
        /// </summary>
        /// <param name="obj">PropertyViewModel</param>
        private void Remove(object obj)
        {
            var propertyViewModel = obj as PropertyViewModel;
            if (propertyViewModel == null) throw new ArgumentNullException(nameof(propertyViewModel));

            PropertyViewModels.Remove(propertyViewModel);
            var mainViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            if (mainViewModel == null) throw new ArgumentNullException(nameof(mainViewModel));
            mainViewModel.RemovePropery(propertyViewModel.GetModel());
            mainViewModel.ShowPropertiesView();
        }

        #endregion
    }
}