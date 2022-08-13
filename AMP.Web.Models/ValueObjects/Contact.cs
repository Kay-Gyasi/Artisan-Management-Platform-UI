using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.ValueObjects
{
    public class Contact
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PrimaryContact { get; set; }
        public string PrimaryContact2 { get; set; }
        public string PrimaryContact3 { get; set; }

    }
}