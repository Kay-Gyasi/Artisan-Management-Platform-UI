using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Stores.Order
{
    public class GetOrderPageAction : IOrderAction
    {
        public const string GETORDERPAGE = "GETORDERPAGE";

        // Type
        public string NameOfAction => GETORDERPAGE;

        // Payload
        public PaginatedQuery Payload { get; }

        public GetOrderPageAction(PaginatedQuery payload)
        {
            Payload = payload;
        }
    }
}
