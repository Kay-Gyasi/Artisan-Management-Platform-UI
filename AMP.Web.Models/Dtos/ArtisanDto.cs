using System.Collections.Generic;

namespace AMP.Web.Models.Dtos
{
    public class ArtisanDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BusinessName { get; set; }
        public string Description { get; set; }
        public bool IsVerified { get; set; }
        public bool IsApproved { get; set; }
        public double Rating { get; set; }
        public int NoOfReviews { get; set; }
        public int NoOfOrders { get; set; }
        public UserDto? User { get; set; } = new UserDto();
        public List<ServiceDto> Services { get; set; } = new List<ServiceDto>();
        public List<RatingDto> Ratings { get; set; } = new List<RatingDto>();
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public List<DisputeDto> Disputes { get; set; } = new List<DisputeDto>();
    }
}