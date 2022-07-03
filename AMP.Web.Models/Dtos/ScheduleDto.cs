using System;

namespace AMP.Web.Models.Dtos
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArtisanId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public OrderDto Order { get; set; }
        public ArtisanDto Artisan { get; set; }
    }
}