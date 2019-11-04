using ContactsBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsBook.ViewModels
{
    public class AllContactsViewModel
    {
        public int Id { get; set; }
        public List<Contact> Contacts { get; set; }

        public List<Email> Emails { get; set; }

        public List<Phone> Phones { get; set; }

        public List<Address> Addresses { get; set; }
    }
}