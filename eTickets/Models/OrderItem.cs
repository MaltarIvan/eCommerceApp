using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public Guid MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
