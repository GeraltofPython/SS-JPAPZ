using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FForum.DAL;
using Microsoft.AspNet.Identity;

namespace FForum.Controllers
{
    public class ForaController : Controller
    {
        private Context db = new Context();

        // GET: Fora
        public ActionResult Index()
        {
            var fora = db.Fora.Include(f => f.AspNetUser).Include(f => f.Category);
            return View(fora.ToList());
        }

        // GET: Fora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // GET: Fora/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Fora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,PostDate,SubjectTitle,Description,CategoryID")] Forum forum)
        {
            var UserID = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(UserID);
            forum.UserID = user.Id;
            if (ModelState.IsValid)
            {
                forum.PostDate = DateTime.Now;
                db.Fora.Add(forum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", forum.UserID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", forum.CategoryID);
            return View(forum);
        }

        // GET: Fora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", forum.UserID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", forum.CategoryID);
            return View(forum);
        }

        // POST: Fora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,PostDate,SubjectTitle,Description,CategoryID")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", forum.UserID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", forum.CategoryID);
            return View(forum);
        }

        // GET: Fora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: Fora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum forum = db.Fora.Find(id);
            db.Fora.Remove(forum);
            db.SaveChanges();
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
