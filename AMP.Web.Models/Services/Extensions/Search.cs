using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Services.Extensions
{
    public class Search
    {
        [Required]
        public string SearchTerm { get; set; }
    }
}