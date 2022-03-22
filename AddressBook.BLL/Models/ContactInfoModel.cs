using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Bll.Models
{
    public class ContactInfoModel
    {
        private string email;
        private string phoneNumber;

        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress 
        { 
            get { return email; } 
            set { email = value.Trim().ToLower(); }
        }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber 
        { 
            get { return phoneNumber; } 
            set { phoneNumber = value.Trim().Replace("-", ""); } 
        }
        [Display(Name = "Address")]
        public string PhysicalAddress { get; set; }
    }
}
