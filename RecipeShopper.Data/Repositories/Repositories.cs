using RecipeShopper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    public class Repositories : IRepositories
    {
        #region Private variables
        private readonly IUsersRepository _usersRepository;
        #endregion
        #region Constructor
        public Repositories(IUsersRepository userRepository) 
        {
            _usersRepository = userRepository;
        }
        #endregion

        #region Interface members
        public IUsersRepository UsersRepository { get => _usersRepository; }
        #endregion
    }
}
