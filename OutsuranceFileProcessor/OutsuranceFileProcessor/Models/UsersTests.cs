using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OutsuranceFileProcessor.Models
{
    /// <summary>
    /// UsersTests
    /// This users test class is to simulate unit testing, in a larger more managed application I would use Moq instead.
    /// </summary>
    [TestClass]
    public class UsersTests
    {
        private Users users = new Users();

        [TestMethod]
        public void PopulateUsers()
        {
            users.AddUser(new string[] { "John", "Doe", "C# Street 123", "0112345678" });
            users.AddUser(new string[] { "Joseph", "Albehari", "O'Reilly", "0112345678" });
            users.AddUser(new string[] { "Ben", "Albehari", "C# Pro", "0112345678" });
            users.AddUser(new string[] { "John", "Hello World", "WPF Unleashed", "0112345678" });
        }

        [TestMethod]
        public List<UserGroupedNameInfo> TestGroupedFirstAndLastNames()
        {
            return users.getGroupedFirstAndLastNames();
        }

        [TestMethod]
        public List<string> TestDistinctAddressList()
        {
            return users.getDistinctAddressList();
        }
    }
}
