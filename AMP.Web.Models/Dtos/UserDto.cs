using System.Collections.Generic;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserNo { get; set; }
        public string? FirstName { get; set; }
        public string? FamilyName { get; set; }
        public string? OtherName { get; set; }
        public string? DisplayName { get; set; }
        public string? MomoNumber { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsRemoved { get; set; }
        public UserType Type { get; set; }
        public LevelOfEducation LevelOfEducation { get; set; }
        public Contact? Contact { get; set; } = new Contact();
        public Address? Address { get; set; } = new Address();
        public ImageDto? Image { get; set; } = new ImageDto();
        public List<LanguagesDto> Languages { get; set; } = new List<LanguagesDto>();
        public List<ArtisanDto> Artisans { get; set; } = new List<ArtisanDto>();
        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
    }

    public class LanguagesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class LanguagesCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}