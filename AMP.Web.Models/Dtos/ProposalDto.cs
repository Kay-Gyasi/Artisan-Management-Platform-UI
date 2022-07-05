namespace AMP.Web.Models.Dtos
{
    public class ProposalDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArtisanId { get; set; }
        public bool IsAccepted { get; set; }
        public OrderDto Order { get; set; } = new OrderDto();
        public ArtisanDto Artisan { get; set; } = new ArtisanDto();
    }
}