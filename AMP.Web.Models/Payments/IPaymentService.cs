using AMP.Web.Models.Commands;

namespace AMP.Web.Models.Payments
{
    public interface IPaymentService
    {
        string InitializeTransaction(PaymentCommand command, string email);
        string VerifyTransaction(VerifyPaymentCommand command);
    }
}