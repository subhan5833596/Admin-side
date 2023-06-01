using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin_side.Models;

namespace Admin_side.Controllers
{
    public class PaymentController : Controller
    {
        private dbmsProject01Entities2 db = new dbmsProject01Entities2();

        // GET: /Payment/
        public ActionResult Index()
        {
            return View(db.tblPayment_Details.ToList());
        }

        // GET: /Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment_Details tblpayment_details = db.tblPayment_Details.Find(id);
            if (tblpayment_details == null)
            {
                return HttpNotFound();
            }
            return View(tblpayment_details);
        }

        // GET: /Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PaymentID,Name,AccNumber,BankName,Mode,CvvNo")] tblPayment_Details tblpayment_details)
        {
            if (ModelState.IsValid)
            {
                db.tblPayment_Details.Add(tblpayment_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpayment_details);
        }

        // GET: /Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment_Details tblpayment_details = db.tblPayment_Details.Find(id);
            if (tblpayment_details == null)
            {
                return HttpNotFound();
            }
            return View(tblpayment_details);
        }

        // POST: /Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PaymentID,Name,AccNumber,BankName,Mode,CvvNo")] tblPayment_Details tblpayment_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpayment_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpayment_details);
        }

        // GET: /Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPayment_Details tblpayment_details = db.tblPayment_Details.Find(id);
            if (tblpayment_details == null)
            {
                return HttpNotFound();
            }
            return View(tblpayment_details);
        }

        // POST: /Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPayment_Details tblpayment_details = db.tblPayment_Details.Find(id);
            db.tblPayment_Details.Remove(tblpayment_details);
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
