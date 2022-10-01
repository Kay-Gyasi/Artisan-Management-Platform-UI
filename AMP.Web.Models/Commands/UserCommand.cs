using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace AMP.Web.Models.Commands
{
    public class UserCommand
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string FamilyName { get; set; }
        public string? ImageId { get; set; }
        public string? OtherName { get; set; }
        public string? DisplayName { get; set; }
        public string? MomoNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserType Type { get; set; }
        public LevelOfEducation LevelOfEducation { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public Contact? Contact { get; set; } = new Contact();

        [Required(ErrorMessage = "Field is required")]
        public Address? Address { get; set; } = new Address();
        public ImageCommand? Image { get; set; } = new ImageCommand();
        public List<LanguagesCommand> Languages { get; set; } = new List<LanguagesCommand>();
    }

    public class ImageCommand
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PublicId { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }

    public class ImageDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PublicId { get; set; }
        public string ImageUrl { get; set; }
    }
}