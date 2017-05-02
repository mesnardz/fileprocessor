using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceFileProcessor.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
    {
        #region Members
        private string _FirstName;
        private string _LastName;
        private string _Address;
        private string _PhoneNumber;
        private bool _Active;
        #endregion

        #region Constructor
        /// <summary>
        /// User Constructor
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Address"></param>
        /// <param name="PhoneNumber"></param>
        public User(string FirstName, string LastName, string Address, string PhoneNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        #endregion

        #region Properties
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName
        {
            get { return this._FirstName; }
            set
            {
                //Check if the value is not the same. Reading the value is less resource intensive than writing over the value.
                if (this._FirstName != value)
                    this._FirstName = value;
            }
        }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName
        {
            get { return this._LastName; }
            set
            {
                if (this._LastName != value)
                    this._LastName = value;
            }
        }

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return this._Address; }
            set
            {
                if (this._Address != value)
                    this._Address = value;
            }
        }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber
        {
            get { return this._PhoneNumber; }
            set
            {
                if (this._PhoneNumber != value)
                    this._PhoneNumber = value;
            }
        }

        /// <summary>
        /// Active
        /// </summary>
        public bool Active
        {
            get { return this._Active; }
            set
            {
                if (this._Active != value)
                    this._Active = value;
            }
        }
        #endregion
    }
}
