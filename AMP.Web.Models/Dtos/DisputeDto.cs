using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Dtos
{
    public class DisputeDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ArtisanId { get; set; }
        public string Details { get; set; }
        public DisputeStatus Status { get; set; }
        public CustomerDto Customer { get; set; } = new CustomerDto();
        public ArtisanDto Artisan { get; set; } = new ArtisanDto();
    }
}