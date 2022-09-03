using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Stores.Order
{
    public interface IOrderAction : IAction
    {
        PaginatedQuery Payload { get; }
    }
}
