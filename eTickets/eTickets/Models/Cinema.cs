using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        public string LogoPictureURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
