using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.Commands;

public class InvitationCommand
{
    [Required(ErrorMessage = "Field is required")]
    [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Invalid phone")]
    public string InvitedPhone { get; set; }

    [Required(ErrorMessage = "Field is required")]
    public UserType Type { get; set; }
}