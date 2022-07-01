namespace AMP.Web.Models.Commands
{
    public class DisputeCommand
    {
        public int CustomerId { get; set; }
        public int ArtisanId { get; set; }
        public string Details { get; set; }
    }
}