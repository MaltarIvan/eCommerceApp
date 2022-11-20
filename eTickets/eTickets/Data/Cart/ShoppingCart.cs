using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public readonly AppDbContext _context;

        public Guid Id { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            Guid cartId;

            string stringId = session.GetString("CartId");

            if (string.IsNullOrEmpty(stringId))
            {
                cartId = Guid.NewGuid();
            }
            else
            {
                cartId = Guid.Parse(stringId);
            }

            session.SetString("CartId", cartId.ToString());

            return new ShoppingCart(context)
            {
                Id = cartId
            };
        }

        public void AddItemToCart(Movie movie)
        {
            var shopingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShopingCartId == Id);

            if(shopingCartItem == null)
            {
                shopingCartItem = new ShoppingCartItem()
                {
                    Id = Guid.NewGuid(),
                    ShopingCartId = Id,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shopingCartItem);
            }
            else
            {
                shopingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shopingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShopingCartId == Id);

            if (shopingCartItem != null)
            {
                if(shopingCartItem.Amount > 1)
                {
                    shopingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shopingCartItem);
                }

                _context.SaveChanges();
            }
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _context.ShoppingCartItems.Where(x => x.ShopingCartId == Id).Include(x => x.Movie).ToList();
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(x => x.ShopingCartId == Id).Select(x => x.Movie.Price * x.Amount).Sum();

            return total;
        }
    }
}
