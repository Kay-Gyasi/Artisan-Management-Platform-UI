using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class ArtisanCommand
    {
        [Required(ErrorMessage = "Field is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string? BusinessName { get; set; }
        public string? Description { get; set; }
        public List<int>? Services { get; set; } = new List<int>(); // Ids of services
    }
}