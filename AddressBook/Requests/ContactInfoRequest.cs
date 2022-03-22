using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AddressBook.Requests
{
    public class ContactInfoRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "Your full name should contain at least 3 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [StringLength(128)]
        [MinLength(11, ErrorMessage = "Your email address should contain at least 11 characters")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [StringLength(25)]
        [MinLength(9, ErrorMessage = "Your phone number should contain at least 9 characters")]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string PhysicalAddress { get; set; }
    }
}
