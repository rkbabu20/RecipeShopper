﻿using RecipeShopper.Domain.Aggregates.Base;
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
    public class UsersAggregate : BaseAggregate
    {
        #region members

        #endregion
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

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="userRegistration">RegisterUser</param>
        public UsersAggregate(RegisterUser userRegistration)
        {
            RegisterUser = userRegistration;
        }
        #endregion
        
        #region Users
        public RegisterUser RegisterUser { get; private set; }
        /// <summary>Users</summary>
        public List<User>? Users { get; private set; }

        /// <summary>Users</summary>
        public User? User { get; private set; }

        #endregion
    }
}
