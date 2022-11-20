using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }

        public Guid ShopingCartId { get; set; }
    }
}
