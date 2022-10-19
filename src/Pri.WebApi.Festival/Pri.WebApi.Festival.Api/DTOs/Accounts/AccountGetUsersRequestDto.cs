using System;

namespace Pri.WebApi.Festival.Api.DTOs.Accounts
{
    public class AccountGetUsersRequestDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AmountOfTickets { get; set; }
    }
}
