using ContactsBook.Models;
using ContactsBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ContactsBook.Controllers
{
    [Authorize(Roles = RolesModel.Admin+","+RolesModel.Manager)]
    public class ContactController : Controller
    {
        private ApplicationDbContext _context;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Contact/Details
        public ActionResult Details(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);
            var emails = _context.Email.Where(e => e.ContactId == id);
            var phones = _context.Phone.Where(p => p.ContactId == id);
            var addresses = _context.Address.Where(a => a.ContactId == id);

            if (contact == null)
                return HttpNotFound();

            var viewModel = new ContactViewModel
            {
                Contact = contact,
                Emails = emails.ToList(),
                Phones = phones.ToList(),
                Addresses = addresses.ToList()

            };

            return View(viewModel);
        }
        
        public ActionResult New()
        {
            var viewModel = new ContactViewModel
            {
                Contact = new Contact(),
                Email = new Email(),
                Phone = new Phone(),
                Address = new Address(),
                Emails = new List<Email>(),
                Phones = new List<Phone>(),
                Addresses = new List<Address>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactViewModel
                {
                    Contact = contactViewModel.Contact,
                    Email = contactViewModel.Email,
                    Phone = contactViewModel.Phone,
                    Address = contactViewModel.Address
                };

                return View("New", viewModel);
            }

            _context.Contacts.Add(contactViewModel.Contact);
            _context.Email.Add(contactViewModel.Email);
            _context.Phone.Add(contactViewModel.Phone);
            _context.Address.Add(contactViewModel.Address);

            _context.SaveChanges();

            return RedirectToAction("Contacts", "Book");
        }
        
        public ActionResult Delete(int id)
        {
            var contact = _context.Contacts.Where(c => c.Id == id).Single();
            var email = _context.Email.Where(e => e.ContactId == id).ToList();
            var phone = _context.Phone.Where(p => p.ContactId == id).ToList();
            var address = _context.Address.Where(a => a.ContactId == id).ToList();
            _context.Contacts.Remove(contact);
            _context.Email.RemoveRange(email);
            _context.Phone.RemoveRange(phone);
            _context.Address.RemoveRange(address);

            _context.SaveChanges();

            return RedirectToAction("Contacts", "Book");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactViewModel
                {
                    Contact = contactViewModel.Contact,
                    Emails = contactViewModel.Emails,
                    Phones = contactViewModel.Phones,
                    Addresses = contactViewModel.Addresses
                };

                return View("Details", viewModel);
            }

            var contactInDb = _context.Contacts.Single(c => c.Id == contactViewModel.Contact.Id);
            var emailInDb = _context.Email.Where(e => e.ContactId == contactViewModel.Contact.Id);
            var phoneInDb = _context.Phone.Where(e => e.ContactId == contactViewModel.Contact.Id);
            var addressInDb = _context.Address.Where(e => e.ContactId == contactViewModel.Contact.Id);

            contactInDb.FirstName = contactViewModel.Contact.FirstName;
            contactInDb.LastName = contactViewModel.Contact.LastName;

            // check if Email is empty
            if (!emailInDb.Any())
            {
                // if empty add all new records to Email table
                contactViewModel.Emails.ForEach(email =>
                {
                    email.ContactId = contactInDb.Id;
                    _context.Email.Add(email);
                });
            }
            else
            {
                // update existing
                contactViewModel.Emails.ForEach(email =>
                {
                    emailInDb.Single(record => record.Id == email.Id).EmailAddress = email.EmailAddress;
                });
            }

            // check if Phone table is empty
            if (!phoneInDb.Any())
            {
                // if empty add all new records to Phone table
                contactViewModel.Phones.ForEach(phone => 
                {
                    phone.ContactId = contactInDb.Id;
                    _context.Phone.Add(phone);
                });
            }
            else
            {
                // update existing
                contactViewModel.Phones.ForEach(phone =>
                {
                    phoneInDb.Single(record => record.Id == phone.Id).PhoneNumber = phone.PhoneNumber;
                });
            }

            //check if Address is empty
            if (!addressInDb.Any())
            {
                // if empty add all new records to Address table
                contactViewModel.Addresses.ForEach(address => 
                {
                    address.ContactId = contactInDb.Id;
                    _context.Address.Add(address);
                });
            }
            else
            {
                // update existing
                contactViewModel.Addresses.ForEach(address =>
                {
                    addressInDb.Single(record => record.Id == address.Id).ContactAddress = address.ContactAddress;
                });
            }

            _context.SaveChanges();

            return RedirectToAction("Contacts", "Book");
        }
    }
}