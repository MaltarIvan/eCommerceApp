using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Where(x => x.UserId == userId).Include(x => x.OrderItems).ThenInclude(x => x.Movie).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmail
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(ShoppingCartItem item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };

                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}
