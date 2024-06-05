using RecipeShopper.Application.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using RecipeShopper.DBContexts.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// UsersRepository
    /// </summary>
    public class UsersRepository(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        RecipeShopperDbContext dbContext) : IUsersRepository
    {
        #region Private variables

        private RecipeShopperDbContext _dbContext = dbContext;
        private UserManager<User> _userManager = userManager;
        private RoleManager<IdentityRole> _roleManager = roleManager;
        #endregion

        #region Interface methods
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="request">Users request</param>
        /// <returns></returns>
        public async Task AddAsync(UsersAggregate request)
        {

            if (request != null && request.RegisterUser != null)
            {
                // Step 1 : Create user
                var createUserResponse = await _userManager.CreateAsync(request.RegisterUser.User, request.RegisterUser.RawPassword!).ConfigureAwait(false);
                request.IsAdded = createUserResponse != null && createUserResponse.Succeeded;
                if (request.IsAdded)
                {
                    // Step 2 : If role not exists create one.
                    if ((await _roleManager.FindByNameAsync(request.RegisterUser.User.Role.ToString()).ConfigureAwait(false)) == null)
                        await _roleManager.CreateAsync(new IdentityRole(request.RegisterUser.User.Role.ToString())).ConfigureAwait(false);

                    // Step 3 : Associate user role
                    await _userManager.AddToRoleAsync(request.RegisterUser.User, request.RegisterUser.User.Role.ToString().ToUpper()).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="request">User id</param>
        /// <returns></returns>
        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null && !string.IsNullOrWhiteSpace(request.Id))
            {
                var userAggregate = await GetAsync(request).ConfigureAwait(false);
                if (userAggregate != null && userAggregate.User != null)
                {
                    await _userManager.DeleteAsync(userAggregate.User).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UsersAggregate> GetAsync(GenericRequest request)
        {
            // Get user from db
            return new UsersAggregate(await _userManager.FindByIdAsync(request.Id).ConfigureAwait(false));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
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
                var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
                userAggregate = new UsersAggregate(user);
            }
            catch { }//Exception ignored intentionally
            return userAggregate!;
        }
        #endregion
    }
}
