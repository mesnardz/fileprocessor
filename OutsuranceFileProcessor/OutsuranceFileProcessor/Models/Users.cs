using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceFileProcessor.Models
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users : List<User>
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Users()
        {

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add User Method for Custom Add Event Handling
        /// </summary>
        internal void AddUser(User user)
        {
            user.Active = true;
            this.Add(user);
        }

        /// <summary>
        /// Add User Method from csv array
        /// </summary>
        /// <param name="fields"></param>
        internal void AddUser(string[] fields)
        {
            this.Add(new User(fields[0], fields[1], fields[2], fields[3]));
        }

        /// <summary>
        /// getDistinctAddressList
        /// </summary>
        /// <returns>return a grouped list of combined first names, last names and their frequency</returns>
        internal List<string> getDistinctAddressList()
        {
            return this.Select(s => s.Address).OrderBy(o => o) .ToList();
        }

        /// <summary>
        /// getGroupedFirstAndLastNames
        /// </summary>
        /// <returns>return a list of all addresses</returns>
        internal List<UserGroupedNameInfo> getGroupedFirstAndLastNames()
        {
            List<string> firstNames = this.Select(s => s.FirstName).ToList();
            List<string> lastNames = this.Select(s => s.LastName).ToList();

            return firstNames.Concat(lastNames).GroupBy(g => g)
                .Select(group => new UserGroupedNameInfo(group.Key, group.Count()))
                .OrderByDescending(o => o.Count)
                .ThenBy(o => o.Name)
                .ToList();
        }
        #endregion
    }
}
