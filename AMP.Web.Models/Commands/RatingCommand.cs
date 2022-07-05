using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class RatingCommand
    {
        [Required(ErrorMessage = "Field is required")]
        public int ArtisanId { get; set; }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Range(0, 5, ErrorMessage = "Input should be between 0 and 5")]
        public int Votes { get; set; }

        public string Description { get; set; }
        public ArtisanCommand Artisan { get; set; } = new ArtisanCommand();
        public CustomerCommand Customer { get; set; } = new CustomerCommand();
    }
}