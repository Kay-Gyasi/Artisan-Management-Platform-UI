namespace AMP.Web.Models.PageDtos
{
    public class ProposalPageDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArtisanId { get; set; }
        public bool IsAccepted { get; set; }
        public OrderPageDto Order { get; set; }
        public ArtisanPageDto Artisan { get; set; }
    }
}