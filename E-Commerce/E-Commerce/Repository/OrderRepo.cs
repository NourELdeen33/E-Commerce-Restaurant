using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderWithOrderItemsWithProductsAsync(string Userid)
        {
            
            var list =  await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x=>x.UserId==Userid)
                .AsNoTracking()
                .ToListAsync();
            return list;
        }
    }
}
