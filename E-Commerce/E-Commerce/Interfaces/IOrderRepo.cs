namespace E_Commerce.Interfaces
{
    public interface IOrderRepo:IRepository<Order>
    {
        public Task<List<Order>> GetOrderWithOrderItemsWithProductsAsync(string userid);
    }
}
