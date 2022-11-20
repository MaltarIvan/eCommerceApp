using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class ActorMovie
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
