using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography name is required.")]
        public string Bio { get; set; }

        public List<ActorMovie> ActorMovieList { get; set; } = new List<ActorMovie>();
    }
}
