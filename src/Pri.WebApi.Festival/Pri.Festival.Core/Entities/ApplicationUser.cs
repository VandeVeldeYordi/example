using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Pri.Festivals.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
