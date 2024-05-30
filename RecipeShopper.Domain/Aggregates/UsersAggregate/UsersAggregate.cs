using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.UsersAggregate
{
    /// <summary>
    /// Users aggregate
    /// </summary>
    public class UsersAggregate
    {
        #region Constructor
        /// <summary>
        /// Users agrregate
        /// </summary>
        /// <param name="users"></param>
        public UsersAggregate(List<User> users)
        {
            Users = users;
        }

        /// <summary>
        /// Users aggrigate
        /// </summary>
        /// <param name="user"></param>
        public UsersAggregate(User user)
        {
            User = user;
        }
        #endregion

        #region Users
        /// <summary>Users</summary>
        public List<User> Users { get; private set; }

        /// <summary>Users</summary>
        public User User { get; private set; }

        /// <summary>User add status</summary>
        public bool IsUserAdded => User != null && User.UserId! != Guid.Empty;
        #endregion
    }
}
