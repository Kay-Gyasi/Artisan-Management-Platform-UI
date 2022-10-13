using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Commands
{
    public class ArtisanCommand
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string? BusinessName { get; set; }
        
        public BusinessType Type { get; set; }
        
        /// <summary>
        /// Energy Commission Certification Number (for electricians only)
        /// </summary>
        public string ECCN { get; set; }

        public string? Description { get; set; }
        public List<ServiceCommand> Services { get; set; } = new List<ServiceCommand>(); 
    }
}