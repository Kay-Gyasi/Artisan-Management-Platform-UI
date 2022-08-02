using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class ServiceCommand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}