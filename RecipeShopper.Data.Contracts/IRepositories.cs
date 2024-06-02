namespace RecipeShopper.Data.Contracts
{
    /// <summary>
    /// Repositories interface
    /// </summary>
    public interface IRepositories
    {
        /// <summary>Users repository</summary>
        IUsersRepository UsersRepository { get; }
        /// <summary>Cart repository</summary>
        ICartRepository CartRepository { get; }
        /// <summary>Ingradients repository</summary>
        IStockIngradientsRepository StockIngradientRepository { get; }
        /// <summary>Orders repository</summary>
        IOrdersRepository OrdersRepository { get; }
        /// <summary>Login repository</summary>
        ILoginRepository LoginRepository { get; }
    }// IRepositories
}
