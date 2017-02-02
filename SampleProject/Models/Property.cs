namespace SampleProject.Models
{
    /// <summary>
    ///     Property Model
    /// </summary>
    public class PropertyModel
    {
        #region Constructor

        /// <summary>
        ///     Cosntructor
        /// </summary>
        /// <param name="address">Address of property</param>
        /// <param name="ownerName">Onwer of property</param>
        /// <param name="roomNumber">Number of rooms</param>
        /// <param name="cost">Cost of property</param>
        public PropertyModel(string address, string ownerName, int roomNumber, int cost)
        {
            Address = address;
            OwnerName = ownerName;
            RoomNumber = roomNumber;
            Cost = cost;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Address of property
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Number of rooms
        /// </summary>
        public int RoomNumber { get; set; }


        /// <summary>
        ///     Onwer of property
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        ///     Cost of property
        /// </summary>
        public int Cost { get; set; }

        #endregion
    }
}