using ContactsBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsBook.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
        
        public Email Email { get; set; }
        [Display(Name = "Email Address")]
        public List<Email> Emails { get; set; }

        public Phone Phone { get; set; }
        public List<Phone> Phones { get; set; }

        public Address Address { get; set; }
        public List<Address> Addresses { get; set; }
    }
}