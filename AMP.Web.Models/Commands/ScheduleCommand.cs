using System;
using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class ScheduleCommand
    {
        [Required(ErrorMessage = "Field is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public int ArtisanId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}