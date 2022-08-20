using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class SigninCommand
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class SigninResponse
    {
        public string Token { get; set; }
    }
}