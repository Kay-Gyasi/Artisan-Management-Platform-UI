using System;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.PageDtos;

public class InvitationPageDto
{
    public string InvitedPhone { get; set; }
    public UserType Type { get; set; }
    public DateTime DateCreated { get; set; }
}