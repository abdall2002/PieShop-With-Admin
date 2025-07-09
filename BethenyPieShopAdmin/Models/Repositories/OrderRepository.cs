
using Microsoft.EntityFrameworkCore;

namespace BethenyPieShopAdmin.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethenysPieShopDbContext _bethenysPieShopDbContext;
        public OrderRepository(BethenysPieShopDbContext bethenysPieShopDbContext)
        {
            _bethenysPieShopDbContext = bethenysPieShopDbContext;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync()
        {
            return await _bethenysPieShopDbContext.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Pie).OrderBy(o => o.OrderId).ToListAsync();
        }

        public async Task<Order?> GetOrderDetailsAsync(int? orderId)
        {
            if (orderId != null)
            {
                var order = await _bethenysPieShopDbContext.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Pie).OrderBy(o => o.OrderId).Where(o => o.OrderId == orderId.Value).FirstOrDefaultAsync();

                return order;
            }
            return null;
        }
    }
}
