using ContactsBook.Models;
using ContactsBook.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace ContactsBook.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: User/Edit
        public ActionResult Edit(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            var viewModel = new UserViewModel
            {
                User = user,
                Roless = _context.Roles.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Update(UserViewModel model)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == model.User.Id);
            var oldRole = userInDb.Roles.FirstOrDefault();
            var newRole = new IdentityUserRole
            {
                UserId = model.User.Id,
                RoleId = model.selectedRoleId
            };

            userInDb.Roles.Remove(oldRole);
            userInDb.Roles.Add(newRole);

            _context.SaveChanges();

            return RedirectToAction("Users", "Book");
        }

        public ActionResult Delete(string id)
        {
            var userToDelete = _context.Users.SingleOrDefault(u => u.Id == id);
            _context.Users.Remove(userToDelete);

            _context.SaveChanges();

            return RedirectToAction("Users", "Book");
        }
    }
}