using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class ArtisanCommand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string? BusinessName { get; set; }
        public string? Description { get; set; }
        public List<ServiceCommand> Services { get; set; } = new List<ServiceCommand>(); 
    }
}