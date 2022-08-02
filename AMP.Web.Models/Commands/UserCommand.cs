using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.Commands
{
    public class UserCommand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string? UserNo { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string? FamilyName { get; set; }

        public string? OtherName { get; set; }
        public string? DisplayName { get; set; }
        public string? ImageUrl { get; set; }
        public string? MomoNumber { get; set; }
        public UserType Type { get; set; }
        public LevelOfEducation LevelOfEducation { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public Contact? Contact { get; set; } = new Contact();

        [Required(ErrorMessage = "Field is required")]
        public Address? Address { get; set; } = new Address();

        public List<LanguagesCommand> Languages { get; set; } = new List<LanguagesCommand>();
    }
}