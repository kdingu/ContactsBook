using ContactsBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ContactsBook.ViewModels;

namespace ContactsBook.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Book/Users
        [Authorize(Roles = RolesModel.Admin)]
        public ActionResult Users()
        {
            var users = _context.Users.ToList();
            var roles = _context.Roles.ToList();

            var viewModel = new UserViewModel
            {
                Users = users,
                Roless = roles
            };

            return View(viewModel);
        }

        // GET: Book/Contacts
        public ActionResult Contacts()
        {
            var contacts = _context.Contacts.ToList();
            var emails = _context.Email.ToList();
            var phones = _context.Phone.ToList();
            var addresses = _context.Address.ToList();

            var viewModel = new AllContactsViewModel
            {
                Contacts = contacts,
                Emails = emails,
                Phones = phones,
                Addresses = addresses
            };

            if (User.IsInRole("Standard"))
                return View("ContactsStandard", viewModel);

            return View(viewModel);
        }
    }
}