﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPGPROJECT_OPG.Models;

namespace OPGPROJECT_OPG.Controllers
{
    public class EmailsController : Controller
    {
        private Context db = new Context();

        // GET: Emails
        public ActionResult Index()
        {
            return View(db.Emails.ToList());
        }

        // GET: Emails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Subject,Message")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(email);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Subject,Message")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(email);
        }

        // GET: Emails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Email email = db.Emails.Find(id);
            db.Emails.Remove(email);
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
