namespace AMP.Web.Models.Commands
{
    public class VerifyPaymentCommand
    {
        public string Reference { get; set; }
        public string TransactionReference { get; set; }
    }
}