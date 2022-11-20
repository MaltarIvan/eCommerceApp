using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Logo Picture URL")]
        public string LogoPictureURL { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
