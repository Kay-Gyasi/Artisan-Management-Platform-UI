using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class DisputeCommand
    {
        [Required]
        public int CustomerId { get; set; }

        public int ArtisanId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Details { get; set; }
    }
}