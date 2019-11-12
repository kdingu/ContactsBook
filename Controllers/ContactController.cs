using LumenWorks.Framework.IO.Csv;
using ContactsBook.Models;
using ContactsBook.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using System.Data;

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


        // email form to add new email for a contact
        public ActionResult NewEmail(int id)
        {
            var viewModel = new ContactViewModel
            {
                Email = new Email(),
                Contact = _context.Contacts.SingleOrDefault(c => c.Id == id)
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult SaveNewEmail(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactViewModel
                {
                    Email = cvm.Email,
                    Contact = _context.Contacts.SingleOrDefault(c => c.Id == cvm.Contact.Id)
                };

                return View("NewEmail", viewModel);
            }

            // add email for specific contact to DB
            cvm.Email.ContactId = cvm.Contact.Id;
            _context.Email.Add(cvm.Email);

            _context.SaveChanges();

            return RedirectToAction("Details", "Contact", new { cvm.Contact.Id });
        }

        public ActionResult DeleteEmail(int contactId, int emailId)
        {
            var numberOfEmails = _context.Email.Where(e => e.ContactId == contactId).Count();
            if (numberOfEmails == 1)
            {
                TempData["EmailDeleteErrorMessage"] = "<div style=\"color: red;\" id=\"DeleteErrorMessage\">Can not leave a contact without any email registered.</div>";
                return RedirectToAction("Details", "Contact", new { id = contactId });
            }

            var emailToRemove = _context.Email.SingleOrDefault(e => e.Id == emailId);
            _context.Email.Remove(emailToRemove);
            _context.SaveChanges();

            return RedirectToAction("Details", "Contact", new { id = contactId});
        }


        // phone form to add new phone for a contact
        public ActionResult NewPhone(int id)
        {
            var viewModel = new ContactViewModel
            {
                Phone = new Phone(),
                Contact = _context.Contacts.SingleOrDefault(c => c.Id == id)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveNewPhone(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactViewModel
                {
                    Phone = new Phone(),
                    Contact = _context.Contacts.SingleOrDefault(c => c.Id == cvm.Contact.Id)
                };

                return View("NewPhone", viewModel);
            }

            cvm.Phone.ContactId = cvm.Contact.Id;
            _context.Phone.Add(cvm.Phone);
            _context.SaveChanges();

            return RedirectToAction("Details", "Contact", new { cvm.Contact.Id });
        }

        public ActionResult DeletePhone(int contactId, int phoneId)
        {
            var numberOfPhones = _context.Phone.Where(p => p.ContactId == contactId).Count();
            if (numberOfPhones == 1)
            {
                TempData["PhoneDeleteErrorMessage"] = "<div style=\"color: red;\" id=\"DeleteErrorMessage\">Can not leave a contact without any phone number registered.</div>";
                return RedirectToAction("Details", "Contact", new { id = contactId });
            }

            var phoneToRemove = _context.Phone.SingleOrDefault(p => p.Id == phoneId);
            _context.Phone.Remove(phoneToRemove);
            _context.SaveChanges();

            return RedirectToAction("Details", "Contact", new { id = contactId });
        }

        // address form to add new address for a a contact
        public ActionResult NewAddress(int id)
        {
            var viewModel = new ContactViewModel
            {
                Address = new Address(),
                Contact = _context.Contacts.SingleOrDefault(c => c.Id == id)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveNewAddress(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactViewModel
                {
                    Address = new Address(),
                    Contact = _context.Contacts.SingleOrDefault(c => c.Id == cvm.Contact.Id)
                };

                return View("NewAddress", viewModel);
            }

            cvm.Address.ContactId = cvm.Contact.Id;
            _context.Address.Add(cvm.Address);
            _context.SaveChanges();

            return RedirectToAction("Details", "Contact", new { cvm.Contact.Id });
        }

        public ActionResult DeleteAddress(int contactId, int addressId)
        {
            var numberOfAddresses = _context.Address.Where(a => a.ContactId == contactId).Count();
            if (numberOfAddresses == 1)
            {
                TempData["AddressDeleteErrorMessage"] = "<div style=\"color: red;\" id=\"DeleteErrorMessage\">Can not leave a contact without an address registered.</div>";
                return RedirectToAction("Details", "Contact", new { id = contactId });
            }

            var addressToRemove = _context.Address.SingleOrDefault(a => a.Id == addressId);
            _context.Address.Remove(addressToRemove);
            _context.SaveChanges();

            return RedirectToAction("Details", "Contact", new { id = contactId });
        }

        [HttpPost]
        public ActionResult UploadCsv(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }
                        foreach (DataRow row in csvTable.Rows)
                        {
                            var contactToAdd = new Contact
                            {
                                FirstName = row[csvTable.Columns[0]].ToString(),
                                LastName = row[csvTable.Columns[1]].ToString()
                            };
                            var emailToAdd = new Email
                            {
                                EmailAddress = row[csvTable.Columns[2]].ToString()
                            };
                            var phoneToAdd = new Phone
                            {
                                PhoneNumber = row[csvTable.Columns[3]].ToString()
                            };
                            var addressToAdd = new Address
                            {
                                ContactAddress = row[csvTable.Columns[4]].ToString()
                            };

                            _context.Contacts.Add(contactToAdd);
                            _context.Email.Add(emailToAdd);
                            _context.Phone.Add(phoneToAdd);
                            _context.Address.Add(addressToAdd);

                            _context.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("Contacts", "Book", null);
        }
    }
}