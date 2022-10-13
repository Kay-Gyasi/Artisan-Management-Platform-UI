using AMP.Web.Models.Enums;

namespace AMP.Web.Models.PageDtos
{
    public class ArtisanPageDto
    {
        public string Id { get; set; }
        public string BusinessName { get; set; }
        public BusinessType Type { get; set; }
        
        /// <summary>
        /// Energy Commission Certification Number (for electricians only)
        /// </summary>
        public string ECCN { get; set; }

        public string ImageUrl { get; set; }
        public double Rating { get; set; } 
        public UserPageDto User { get; set; } = new UserPageDto();
    }
}