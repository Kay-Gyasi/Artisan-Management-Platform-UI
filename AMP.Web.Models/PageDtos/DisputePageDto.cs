using AMP.Web.Models.Enums;

namespace AMP.Web.Models.PageDtos
{
    public class DisputePageDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Details { get; set; }
        public DisputeStatus Status { get; set; }
        public CustomerPageDto Customer { get; set; }
        public OrderPageDto Order { get; set; }
    }
}