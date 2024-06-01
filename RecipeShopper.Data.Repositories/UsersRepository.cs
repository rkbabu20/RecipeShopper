using RecipeShopper.Data.Contracts;
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
                request.User.CreateDate = DateTime.Now;
                request.User.ModifiedDate = DateTime.Now;
                _dbContext.Users.Add(request.User);
                request.IsAdded = _dbContext.SaveChanges() > 0;
            }
        }

        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null && request.RequestId != Guid.Empty)
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
            return new UsersAggregate(_dbContext.Users.Find(request.RequestId!));
        }

        public async Task<UsersAggregate> GetAllAsync()
        {
            return new UsersAggregate(_dbContext.Users.ToList());
        }

        public async Task UpdateAsync(UsersAggregate request)
        {
            var userAggregate = await GetAsync(new GenericRequest() { RequestId = request.User.UserId }).ConfigureAwait(false);
            if (userAggregate != null && userAggregate.User != null)
            {
                userAggregate.User.Email = request.User.Email;
                userAggregate.User.LastName = request.User.LastName;
                userAggregate.User.FirstName = request.User.FirstName;
                userAggregate.User.Role = request.User.Role;
                userAggregate.User.ModifiedDate = DateTime.Now;
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
