using AMP.Web.Models.Enums;

namespace AMP.Web.Models.PageDtos
{
    public class PaymentPageDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        public PaymentStatus Status { get; set; }
        public CustomerPageDto Customer { get; set; }
        public OrderPageDto Order { get; set; }
    }
}