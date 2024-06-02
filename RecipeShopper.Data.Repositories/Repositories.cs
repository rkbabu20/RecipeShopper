using RecipeShopper.Application.Contracts;
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
    /// <param name="stockIngradientRepository">IStockIngradientsRepository</param>
    /// <param name="ordersRepository">IOrderRepository</param>
    /// <param name="loginRepository">ILoginRepository</param>
    public class Repositories
        (
            IUsersRepository usersRepository,
            ICartRepository cartRepository,
            IStockIngradientsRepository stockIngradientRepository,
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
        public IStockIngradientsRepository StockIngradientRepository => stockIngradientRepository;
        /// <summary>Orders repository</summary>
        public IOrdersRepository OrdersRepository => ordersRepository;
        /// <summary>Login repository</summary>
        public ILoginRepository LoginRepository => loginRepository;
        #endregion
    }// End Repositories class
}
