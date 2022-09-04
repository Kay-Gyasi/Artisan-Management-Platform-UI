using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class CustomerCommand
    {
        [Required(ErrorMessage = "Field is required")]
        public string UserId { get; set; }
    }
}