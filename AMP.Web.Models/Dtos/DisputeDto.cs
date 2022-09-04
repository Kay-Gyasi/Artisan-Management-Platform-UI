using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Dtos
{
    public class DisputeDto
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string Details { get; set; }
        public DisputeStatus Status { get; set; }
        public CustomerDto Customer { get; set; } = new CustomerDto();
        public OrderDto Artisan { get; set; } = new OrderDto();
    }
}