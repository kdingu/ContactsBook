using ContactsBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsBook.ViewModels
{
    public class DetailsViewModel
    {
        public IQueryable<Email> Emails { get; set; }
        public IQueryable<Phone> Phones{ get; set; }
        public IQueryable<Address> Addresses{ get; set; }
    }
}