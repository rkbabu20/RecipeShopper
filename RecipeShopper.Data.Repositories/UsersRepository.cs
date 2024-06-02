using RecipeShopper.Application.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using RecipeShopper.DBContexts.DatabaseContext;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// UsersRepository
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        #region Private variables
        List<User> _users = null;
        RecipeShopperDbContext _dbContext = null;
        #endregion

        #region Constructor
        /// <summary>
        /// User repository
        /// </summary>
        /// <param name="dbContext">dbcontext</param>
        public UsersRepository(RecipeShopperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Interface methods
        public async Task AddAsync(UsersAggregate request)
        {
            if (request != null && request.User != null)
            {
                _dbContext.Users.Add(request.User);
                request.IsAdded = _dbContext.SaveChanges() > 0;
            }
        }

        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null && !string.IsNullOrWhiteSpace(request.Id))
            {
                var userAggregate = await GetAsync(request).ConfigureAwait(false);
                if (userAggregate != null && userAggregate.User != null)
                {
                    _dbContext.Users.Remove(userAggregate.User!);
                    _dbContext.SaveChanges();
                }
            }
        }

        public async Task<UsersAggregate> GetAsync(GenericRequest request)
        {
            // Get user from db
            return new UsersAggregate(_dbContext.Users.Find(request.Id));
        }

        public async Task<UsersAggregate> GetAllAsync()
        {
            return new UsersAggregate(_dbContext.Users.ToList());
        }

        public async Task UpdateAsync(UsersAggregate request)
        {
            var userAggregate = await GetAsync(new GenericRequest() { Id = request.User!.Id }).ConfigureAwait(false);
            if (userAggregate != null && userAggregate.User != null)
            {
                userAggregate.User.Email = request.User.Email;
                userAggregate.User.LastName = request.User.LastName;
                userAggregate.User.FirstName = request.User.FirstName;
                request.IsUpdated = _dbContext.SaveChanges() > 0;
            }
        }
        public async Task<UsersAggregate> GetUserByEmailAsync(string email)
        {
            var userAggregate = new UsersAggregate(user: null!);
            try
            {
                userAggregate = new UsersAggregate(_dbContext.Users.ToList().First(u => u.Email == email));
            }
            catch { }//Exception ignored intentionally
            return userAggregate!;
        }
        #endregion
    }
}
