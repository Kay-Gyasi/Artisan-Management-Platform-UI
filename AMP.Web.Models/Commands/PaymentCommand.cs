using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class PaymentCommand
    {

        public string Id { get; set; }
        public string TransactionReference { get; set; }
        public string Reference { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string OrderId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public decimal AmountPaid { get; set; }
    }
}