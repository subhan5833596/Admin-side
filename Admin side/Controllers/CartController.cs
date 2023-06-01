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
    public class CartController : Controller
    {
        private dbmsProject01Entities2 db = new dbmsProject01Entities2();

        // GET: /Default3/
        public ActionResult Index()
        {
            var tblcustdetail_cart = db.tblCustDetail_Cart.Include(t => t.tbl_costumerdetails).Include(t => t.tblCategoryDetail);
            return View(tblcustdetail_cart.ToList());
        }

        // GET: /Default3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustDetail_Cart tblcustdetail_cart = db.tblCustDetail_Cart.Find(id);
            if (tblcustdetail_cart == null)
            {
                return HttpNotFound();
            }
            return View(tblcustdetail_cart);
        }

        // GET: /Default3/Create
        public ActionResult Create()
        {
            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName");
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name");
            return View();
        }

        // POST: /Default3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CartID,UID,CID,Qty")] tblCustDetail_Cart tblcustdetail_cart)
        {
            if (ModelState.IsValid)
            {
                db.tblCustDetail_Cart.Add(tblcustdetail_cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName", tblcustdetail_cart.UID);
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name", tblcustdetail_cart.CID);
            return View(tblcustdetail_cart);
        }

        // GET: /Default3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustDetail_Cart tblcustdetail_cart = db.tblCustDetail_Cart.Find(id);
            if (tblcustdetail_cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName", tblcustdetail_cart.UID);
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name", tblcustdetail_cart.CID);
            return View(tblcustdetail_cart);
        }

        // POST: /Default3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CartID,UID,CID,Qty")] tblCustDetail_Cart tblcustdetail_cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcustdetail_cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UID = new SelectList(db.tbl_costumerdetails, "CID", "FirstName", tblcustdetail_cart.UID);
            ViewBag.CID = new SelectList(db.tblCategoryDetails, "CID", "Name", tblcustdetail_cart.CID);
            return View(tblcustdetail_cart);
        }

        // GET: /Default3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustDetail_Cart tblcustdetail_cart = db.tblCustDetail_Cart.Find(id);
            if (tblcustdetail_cart == null)
            {
                return HttpNotFound();
            }
            return View(tblcustdetail_cart);
        }

        // POST: /Default3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCustDetail_Cart tblcustdetail_cart = db.tblCustDetail_Cart.Find(id);
            db.tblCustDetail_Cart.Remove(tblcustdetail_cart);
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
