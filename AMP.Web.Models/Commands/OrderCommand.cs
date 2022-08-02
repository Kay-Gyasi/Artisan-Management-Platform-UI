using System;
using System.ComponentModel.DataAnnotations;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.Commands
{
    public class OrderCommand
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public int ServiceId { get; set; }
        public int? ArtisanId { get; set; }
        public int? PaymentId { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Description { get; set; }
        public decimal Cost { get; set; } 

        public Urgency Urgency { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public ScopeOfWork Scope { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public DateTime PreferredDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Field is required")]
        public Address WorkAddress { get; set; } = new Address();

        public PaymentCommand Payment { get; set; } 
    }
}