using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Responses
{
    public class ContactInfoResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
    }
}