using System;

namespace AMP.Web.Models.PageDtos
{
    public class SchedulePageDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArtisanId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public OrderPageDto Order { get; set; }
        public ArtisanPageDto Artisan { get; set; }
    }
}