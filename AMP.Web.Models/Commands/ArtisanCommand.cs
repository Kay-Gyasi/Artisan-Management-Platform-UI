using System.Collections.Generic;

namespace AMP.Web.Models.Commands
{
    public class ArtisanCommand
    {
        //TODO: Work on command validation
        public int UserId { get; set; }
        public string? BusinessName { get; set; }
        public string? Description { get; set; }
        //public string? Website { get; set; }
        public List<int>? Services { get; set; } = new List<int>(); // Ids of services
    }
}