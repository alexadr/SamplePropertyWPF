using System;
using System.Windows;
using System.Windows.Input;
using SampleProject.Models;
using SampleProject.Utils;

namespace SampleProject.ViewModels
{
    /// <summary>
    /// ViewModel for Add Property View
    /// </summary>
    public class AddPropertiViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public AddPropertiViewModel()
        {
            InitCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Init Save and Cancel Command
        /// </summary>
        private void InitCommands()
        {
            SaveCommand = new RelayCommand(p =>
                {
                    var m = new PropertyModel(DisplayAddress, DisplayOwner, DisplayRoomNumber, DisplayCost);
                    var model = Application.Current.MainWindow.DataContext as MainViewModel;
                        //todo need to find a more elegant solution
                    if (model == null) throw new ArgumentNullException(nameof(model));
                    model.AddNewProperty(m);
                    model.ShowPropertiesView();
                }
            );
            CancelCommand = new RelayCommand(p =>
            {
                var model = Application.Current.MainWindow.DataContext as MainViewModel;
                    //todo need to find a more elegant solution
                if (model == null) throw new ArgumentNullException(nameof(model));
                model.ShowPropertiesView();
            });
        }

        #endregion

        #region Fields

        private string _displayAddress;
        private int _displayCost;
        private string _displayOwner;
        private int _displayRoomNumber;

        #endregion

        #region Properties

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string DisplayOwner
        {
            get { return _displayOwner; }
            set
            {
                if (value != _displayOwner)
                {
                    _displayOwner = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DisplayAddress
        {
            get { return _displayAddress; }
            set
            {
                if (value != _displayAddress)
                {
                    _displayAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        public int DisplayCost
        {
            get { return _displayCost; }
            set
            {
                if (value.Equals(_displayCost)) return;
                _displayCost = value;
                OnPropertyChanged();
            }
        }

        public int DisplayRoomNumber
        {
            get { return _displayRoomNumber; }
            set
            {
                if (value == _displayRoomNumber) return;
                _displayRoomNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}