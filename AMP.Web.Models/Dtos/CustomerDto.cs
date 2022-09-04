using System.Collections.Generic;

namespace AMP.Web.Models.Dtos
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; } = new UserDto();
        public List<RatingDto> Ratings { get; set; } = new List<RatingDto>();
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public List<DisputeDto> Disputes { get; set; } = new List<DisputeDto>();
        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}