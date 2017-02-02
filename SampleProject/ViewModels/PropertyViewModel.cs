using System;
using SampleProject.Models;

namespace SampleProject.ViewModels
{
    /// <summary>
    ///     ViewModel Property for Property View
    /// </summary>
    public class PropertyViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        ///     Default constructor which initialise all internal properties base on PropertModel
        /// </summary>
        /// <param name="propertyModel">Property model</param>
        public PropertyViewModel(PropertyModel propertyModel)
        {
            _propertyModel = propertyModel;
            Fill();
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Mapping base on Property Model
        /// </summary>
        private void Fill()
        {
            if (_propertyModel == null) throw new ArgumentNullException(nameof(_propertyModel));
            DisplayOwner = _propertyModel.OwnerName;
            DisplayAddress = _propertyModel.Address;
            DisplayRoomNumber = _propertyModel.RoomNumber;
            DisplayCost = _propertyModel.Cost;
        }

        #endregion

        #region Fields

        /// <summary>
        ///     origin PropertyModel
        /// </summary>
        private readonly PropertyModel _propertyModel;
        private string _displayAddress;
        private int _displayCost;
        private string _displayOwner;
        private int _displayRoomNumber;

        #endregion

        #region Properties

        /// <summary>
        ///     Property Owner
        /// </summary>
        public string DisplayOwner
        {
            get { return _displayOwner; }
            set
            {
                if (value==_displayOwner) return;
                _displayOwner = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        ///     Property Address
        /// </summary>
        public string DisplayAddress
        {
            get { return _displayAddress; }
            set
            {
                if (value == _displayAddress) return;
                _displayAddress = value;
                OnPropertyChanged();
            }
        }

        internal PropertyModel GetModel()
        {
            return _propertyModel;
        }

        /// <summary>
        ///     Property Cost
        /// </summary>
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

        /// <summary>
        ///     Property RoomNumber
        /// </summary>
        public int DisplayRoomNumber
        {
            get { return _displayRoomNumber; }
            set
            {
                if (value.Equals(_displayRoomNumber)) return;
                _displayRoomNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}