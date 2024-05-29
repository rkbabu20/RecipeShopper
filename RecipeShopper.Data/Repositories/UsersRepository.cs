using RecipeShopper.Contracts;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public Task Add(UsersAggregate user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UsersAggregate> GetAll()
        {
            var users = GetFakeUsers();
            var usersAggregate = new UsersAggregate(users);
            return usersAggregate;
        }

        public Task<UsersAggregate> GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(UsersAggregate user)
        {
            throw new NotImplementedException();
        }
        private List<User> GetFakeUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User() { UserId = "User01", FirstName = "Ramesh", LastName = "Kampati", Email = "ramesh.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.Admin, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            users.Add(new User() { UserId = "User02", FirstName = "Radhika", LastName = "Kampati", Email = "radhika.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.User, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            users.Add(new User() { UserId = "User03", FirstName = "Lalitha", LastName = "Kampati", Email = "lalitha.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.User, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            users.Add(new User() { UserId = "User04", FirstName = "Lasya", LastName = "Kampati", Email = "lasya.kampati@gmail.com", Role = Domain.Enums.UserRoleEnum.User, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now });
            return users;
        }
    }
}
