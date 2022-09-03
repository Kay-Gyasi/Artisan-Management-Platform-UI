using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Stores.Order
{
    public class ResetOrderPageAction : IOrderAction
    {
        public const string RESET = "RESETORDERPAGE";

        public PaginatedQuery Payload { get; }
        public string NameOfAction => RESET;
    }
}
