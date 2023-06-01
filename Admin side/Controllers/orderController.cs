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
    public class orderController : Controller
    {
        private dbmsProject01Entities2 db = new dbmsProject01Entities2();

        // GET: /order/
        public ActionResult Index()
        {
            var tblorders = db.tblorders.Include(t => t.tbl_costumerdetails).Include(t => t.tblCategoryDetail).Include(t => t.tblPayment_Details);
            return View(tblorders.ToList());
        }

        // GET: /order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblorder tblorder = db.tblorders.Find(id);
            if (tblorder == null)
            {
                return HttpNotFound();
            }
            return View(tblorder);
        }

        // GET: /order/Create
        public ActionResult Create()
        {
            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName");
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name");
            ViewBag.PID = new SelectList(db.tblPayment_Details, "PaymentID", "Name");
            return View();
        }

        // POST: /order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OID,PID,UID,CID,status,Bill,Address")] tblorder tblorder)
        {
            if (ModelState.IsValid)
            {
                db.tblorders.Add(tblorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName", tblorder.UID);
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name", tblorder.CID);
            ViewBag.PID = new SelectList(db.tblPayment_Details, "PaymentID", "Name", tblorder.PID);
            return View(tblorder);
        }

        // GET: /order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblorder tblorder = db.tblorders.Find(id);
            if (tblorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName", tblorder.UID);
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name", tblorder.CID);
            ViewBag.PID = new SelectList(db.tblPayment_Details, "PaymentID", "Name", tblorder.PID);
            return View(tblorder);
        }

        // POST: /order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OID,PID,UID,CID,status,Bill,Address")] tblorder tblorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName", tblorder.UID);
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name", tblorder.CID);
            ViewBag.PID = new SelectList(db.tblPayment_Details, "PaymentID", "Name", tblorder.PID);
            return View(tblorder);
        }

        // GET: /order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblorder tblorder = db.tblorders.Find(id);
            if (tblorder == null)
            {
                return HttpNotFound();
            }
            return View(tblorder);
        }

        // POST: /order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblorder tblorder = db.tblorders.Find(id);
            db.tblorders.Remove(tblorder);
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
