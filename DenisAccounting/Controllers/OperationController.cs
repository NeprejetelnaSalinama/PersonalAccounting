using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DenisAccounting.Database;
using DenisAccounting.Models;

namespace DenisAccounting.Controllers
{
    public class OperationController : Controller
    {
        private AccountingContext db = new AccountingContext();

        // GET: Operation
        public ActionResult Index()
        {
            var operations = db.Operations.Include(o => o.Category).Include(o => o.Currency);
            return View(operations.ToList());
        }

        // GET: Operation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // GET: Operation/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Id = new SelectList(db.Currencies, "Id", "Code");
            return View();
        }

        // POST: Operation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id,Id,Amount,Date,Description")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Categories, "Id", "Name", operation.Id);
            ViewBag.Id = new SelectList(db.Currencies, "Id", "Code", operation.Id);
            return View(operation);
        }

        // GET: Operation/AddIncome
        public ActionResult AddIncome()
        {
            ViewBag.Id = new SelectList(from x in db.Categories.Where(s => s.Name == "Income") select x, "Id", "Name");
            ViewBag.Id = new SelectList(db.Currencies, "Id", "Code");
            return View();
        }

        // GET: Operation/AddOutcome
        public ActionResult AddOutcome()
        {
            ViewBag.Id = new SelectList(from x in db.Categories.Where(s => s.Name == "Outcome") select x, "Id", "Name");
            ViewBag.Id = new SelectList(db.Currencies, "Id", "Code");
            return View();
        }

        // GET: Operation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Categories, "Id", "Name", operation.Id);
            ViewBag.Id = new SelectList(db.Currencies, "Id", "Code", operation.Id);
            return View(operation);
        }

        // POST: Operation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id,Id,Amount,Date,Description")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Categories, "Id", "Name", operation.Id);
            ViewBag.Id = new SelectList(db.Currencies, "Id", "Code", operation.Id);
            return View(operation);
        }

        // GET: Operation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // POST: Operation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operation operation = db.Operations.Find(id);
            db.Operations.Remove(operation);
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
