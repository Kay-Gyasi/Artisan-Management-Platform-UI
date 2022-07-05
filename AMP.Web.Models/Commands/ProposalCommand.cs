using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class ProposalCommand
    {
        [Required(ErrorMessage = "Field is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public int ArtisanId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public bool IsAccepted { get; set; } = false;
    }
}