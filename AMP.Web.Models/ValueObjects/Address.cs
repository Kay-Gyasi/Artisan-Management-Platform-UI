using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.ValueObjects
{
    public class Address 
    {
        public Countries Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
    }
}