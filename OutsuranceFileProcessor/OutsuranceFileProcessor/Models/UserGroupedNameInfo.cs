using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceFileProcessor.Models
{
    /// <summary>
    /// UserGroupedNameInfo Model
    /// </summary>
    public class UserGroupedNameInfo
    {
        private string _Name { get; set; }
        private int _Count { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Count"></param>
        public UserGroupedNameInfo(string Name, int Count)
        {
            this.Name = Name;
            this.Count = Count;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return this._Name; }
            set
            {
                if (this._Name != value)
                    this._Name = value;
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get { return this._Count; }
            set
            {
                if (this._Count != value)
                    this._Count = value;
            }
        }
    }
}
