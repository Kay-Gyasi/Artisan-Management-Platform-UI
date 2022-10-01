using System;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.PageDtos
{
    public class OrderPageDto
    {
        public string ReferenceNo { get; set; }
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string? ArtisanId { get; set; }
        public bool IsRequestAccepted { get; set; }
        public string Description { get; set; }
        public Address WorkAddress { get; set; }
        public ServicePageDto Service { get; set; } = new ServicePageDto();
    }
}