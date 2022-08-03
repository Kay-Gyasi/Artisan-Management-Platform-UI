using System.ComponentModel.DataAnnotations;

namespace AMP.Web.Models.Commands
{
    public class SigninCommand
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class SigninResponse
    {
        public string Token { get; set; }
    }
}