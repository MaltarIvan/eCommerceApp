using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.VeiwModels
{
    public class NewMovieVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "The image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "The price is required")]
        public double Price { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "The end date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "The category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Actor(s)")]
        [Required(ErrorMessage = "The actor(s) is required")]
        public List<Guid> ActorIds { get; set; }

        [Display(Name = "Cinema")]
        [Required(ErrorMessage = "The cinema is required")]
        public Guid CinemaId { get; set; }

        [Display(Name = "Producer")]
        [Required(ErrorMessage = "The producer is required")]
        public Guid ProducerId { get; set; }
    }
}
