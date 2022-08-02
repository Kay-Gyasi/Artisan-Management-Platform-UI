using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Dtos
{
    public class DisputeDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Details { get; set; }
        public DisputeStatus Status { get; set; }
        public CustomerDto Customer { get; set; } = new CustomerDto();
        public OrderDto Artisan { get; set; } = new OrderDto();
    }
}