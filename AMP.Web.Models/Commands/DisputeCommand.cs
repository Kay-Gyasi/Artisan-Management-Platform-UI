using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Commands
{
    public class DisputeCommand
    {
        public string Id { get; set; }
        public DisputeStatus Status { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public string Details { get; set; }
    }

    public class DisputeCount
    {
        public int Count { get; set; }
    }
}