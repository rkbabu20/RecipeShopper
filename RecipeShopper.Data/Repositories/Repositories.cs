using RecipeShopper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Repositories implementation
    /// </summary>
    /// <param name="usersRepository">IUsersRepository</param>
    /// <param name="cartRepository">ICartRepository</param>
    /// <param name="ingradientRepository">IIngradientRepository</param>
    /// <param name="ordersRepository">IOrderRepository</param>
    /// <param name="loginRepository">ILoginRepository</param>
    public class Repositories
        (
            IUsersRepository usersRepository,
            ICartRepository cartRepository,
            IIngradientsRepository ingradientRepository,
            IOrdersRepository ordersRepository,
            ILoginRepository loginRepository
        ) 
        : IRepositories
    {

        #region Interface Implementation
        /// <summary>Users repository</summary>
        public IUsersRepository UsersRepository => usersRepository;
        /// <summary>Cart repository</summary>
        public ICartRepository CartRepository => cartRepository;
        /// <summary>Ingradients repository</summary>
        public IIngradientsRepository IngradientRepository => ingradientRepository;
        /// <summary>Orders repository</summary>
        public IOrdersRepository OrdersRepository => ordersRepository;
        /// <summary>Login repository</summary>
        public ILoginRepository LoginRepository => loginRepository;
        #endregion
    }// End Repositories class
}
