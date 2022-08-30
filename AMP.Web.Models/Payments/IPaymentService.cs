using AMP.Web.Models.Commands;
using System.Threading.Tasks;

namespace AMP.Web.Models.Payments
{
    public interface IPaymentService
    {
        Task<string> InitializeTransaction(PaymentCommand command, string email);
        Task<string> VerifyTransaction(VerifyPaymentCommand command);
    }
}