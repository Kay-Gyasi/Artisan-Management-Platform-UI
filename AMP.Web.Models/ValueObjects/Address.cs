using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AMP.Web.Models.Enums;

namespace AMP.Web.Models.ValueObjects
{
    public class Address 
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
    }
}