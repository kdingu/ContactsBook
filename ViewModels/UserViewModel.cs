using ContactsBook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsBook.ViewModels
{
    public class UserViewModel
    {
        public ApplicationUser User { get; set; }
        public string selectedRoleId { get; set; }


        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roless { get; set; }
    }
}