using System;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.PageDtos
{
    public class OrderPageDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; } // To be set by approved artisan
        public Urgency Urgency { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PreferredDate { get; set; }
        public Address Address { get; set; } = new Address();
        public CustomerPageDto Customer { get; set; } = new CustomerPageDto();
        public ServicePageDto Service { get; set; } = new ServicePageDto();
    }
}