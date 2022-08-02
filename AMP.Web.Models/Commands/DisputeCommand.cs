using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Commands
{
    public class DisputeCommand
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public DisputeStatus Status { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Details { get; set; }
    }
}