using System;
using AMP.Web.Models.Enums;
using AMP.Web.Models.ValueObjects;

namespace AMP.Web.Models.PageDtos
{
    public class OrderPageDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public ScopeOfWork Scope { get; set; }
        public DateTime PreferredDate { get; set; }
        public Address WorkAddress { get; set; } = new Address();
        public ServicePageDto Service { get; set; } = new ServicePageDto();
    }
}