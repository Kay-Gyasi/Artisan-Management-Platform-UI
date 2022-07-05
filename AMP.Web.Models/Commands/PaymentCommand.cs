using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class PaymentCommand
    {
        [Required(ErrorMessage = "Field is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public decimal AmountPaid { get; set; }
    }
}