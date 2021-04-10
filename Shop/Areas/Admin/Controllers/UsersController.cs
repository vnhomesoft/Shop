using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Shop.Models.ViewModels;
using Shop.Common;

namespace Shop.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Users
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.Account);
            return View(await users.ToListAsync());
        }

        // GET: Admin/Users/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserAccountView viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                viewModel.CopyToUser(ref user);
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);

            return View(viewModel);
        }

        // GET: Admin/Users/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);      
            if (user == null)
            {
                return HttpNotFound();
            }
            UserAccountView viewModel = new UserAccountView(user);
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);
            return View(viewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserAccountView viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FindAsync(viewModel.Id);
                viewModel.CopyToUser(ref user); // TODO: prevent update username and password
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);

            return View(viewModel);
        }

        // GET: Admin/Users/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
