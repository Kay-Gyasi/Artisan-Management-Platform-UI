using System.Collections.Generic;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Dtos
{
    public class ArtisanDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string BusinessName { get; set; }
        public BusinessType Type { get; set; }
        
        /// <summary>
        /// Energy Commission Certification Number (for electricians only)
        /// </summary>
        public string ECCN { get; set; }

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