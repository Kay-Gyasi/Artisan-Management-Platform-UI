using System;
using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.Commands
{
    public class OrderCommand
    {
        public string ReferenceNo { get; set; }
        public string Id { get; set; }
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string ServiceId { get; set; }
        public string? ArtisanId { get; set; }
        public string? PaymentId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Description { get; set; }
        public decimal Cost { get; set; } 

        public Urgency Urgency { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public ScopeOfWork Scope { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public DateTime PreferredStartDate { get; set; } = DateTime.Today;
        public DateTime PreferredCompletionDate { get; set; } = DateTime.Today.AddDays(1);

        [Required(ErrorMessage = "Field is required")]
        public Address WorkAddress { get; set; } = new Address();

        public PaymentCommand Payment { get; set; } 
    }
}