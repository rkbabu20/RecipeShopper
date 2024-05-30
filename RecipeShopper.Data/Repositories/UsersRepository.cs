using RecipeShopper.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// UsersRepository
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        #region Private variables
        List<User> _users = null;
        #endregion

        #region Constructor
        public UsersRepository()
        {
            ConstructMockUsersData();
        }
        #endregion

        #region Interface methods
        public async Task AddAsync(UsersAggregate request)
        {
            _users.Add(request.User);
        }

        public async Task DeleteAsync(GenericRequest request)
        {
            if (_users.Exists(x => x.UserId.Equals(request.RequestId)))
                _users.Remove(_users.Find(x => x.UserId.Equals(request.RequestId)));
        }

        public async Task<UsersAggregate> GetAsync(GenericRequest request)
        {
            // Implement logic here
            var usersAggrigate = new UsersAggregate(_users.Find(x => x.UserId.Equals(request.RequestId)));
            return usersAggrigate;
        }

        public async Task<UsersAggregate> GetAllAsync()
        {
            var usersAggregate = new UsersAggregate(_users);
            return usersAggregate;
        }

        public async Task UpdateAsync(UsersAggregate request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private members
        private void ConstructMockUsersData()
        {
            if (_users == null)
                _users = new List<User>();
            _users.Add(new User() { UserId = Guid.NewGuid(), FirstName = "Ramesh", LastName = "Kampati", Email = "ramesh.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.Admin, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            _users.Add(new User() { UserId = Guid.NewGuid(), FirstName = "Radhika", LastName = "Kampati", Email = "radhika.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.User, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            _users.Add(new User() { UserId = Guid.NewGuid(), FirstName = "Lalitha", LastName = "Kampati", Email = "lalitha.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.User, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            _users.Add(new User() { UserId = Guid.NewGuid(), FirstName = "Lasya", LastName = "Kampati", Email = "lasya.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.User, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
        }
        #endregion
    }
}
