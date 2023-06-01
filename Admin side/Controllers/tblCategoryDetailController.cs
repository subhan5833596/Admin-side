using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Admin_side.Models;

namespace Admin_side.Controllers
{
    public class tblCategoryDetailController : Controller
    {
        private dbmsProject01Entities2 db = new dbmsProject01Entities2();
        public static string image;
        // GET: /tblCategoryDetail/
        public ActionResult Index()
        {
            var tblcategorydetails = db.tblCategoryDetails.Include(t => t.tblProductDetail);
            return View(tblcategorydetails.ToList());
        }

        // GET: /tblCategoryDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategoryDetail tblcategorydetail = db.tblCategoryDetails.Find(id);
            if (tblcategorydetail == null)
            {
                return HttpNotFound();
            }
            return View(tblcategorydetail);
        }

        // GET: /tblCategoryDetail/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.tblProductDetails, "ProductID", "ProductName");
            return View();
        }

        // POST: /tblCategoryDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCategoryDetail cat)
        {

            if (cat.Imagefile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(cat.Imagefile.FileName);
                string extension = Path.GetExtension(cat.Imagefile.FileName);
                HttpPostedFileBase postedfile = cat.Imagefile;
                int length = postedfile.ContentLength;
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extension;
                        cat.ImageUrl = "~/Image/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                        cat.Imagefile.SaveAs(fileName);
                        db.tblCategoryDetails.Add(cat);

                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            ViewBag.Message = "RECORD INSERT";
                            if (ModelState.IsValid)
                            {
                                db.Entry(cat).State = EntityState.Modified;
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            ModelState.Clear();
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }

                return View();
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //product.ImageUrl = "~/Image/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                //product.Imagefile.SaveAs(fileName);
            }
            //if (ModelState.IsValid)
            //{
            //    db.tblProductDetails.Add(product);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return RedirectToAction("Index");

            //if (ModelState.IsValid)
            //{
            //    db.tblCategoryDetails.Add(tblcategorydetail);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.PID = new SelectList(db.tblProductDetails, "ProductID", "ProductName", tblcategorydetail.PID);
            //return View(tblcategorydetail);
        }

        // GET: /tblCategoryDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategoryDetail tblcategorydetail = db.tblCategoryDetails.Find(id);
          
            image = tblcategorydetail.ImageUrl;
            if (tblcategorydetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.tblProductDetails, "ProductID", "ProductName", tblcategorydetail.PID);
            return View(tblcategorydetail);
        }

        // POST: /tblCategoryDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblCategoryDetail category)
        {
            //if (category.Imagefile != null)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(category.Imagefile.FileName);
            //    string extension = Path.GetExtension(category.Imagefile.FileName);
            //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //    category.ImageUrl = "~/Image/" + fileName;
            //    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            //    category.Imagefile.SaveAs(fileName);
            //}
            //else
            //{
            //    category.ImageUrl = image;
            //}
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tblcategorydetail).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.PID = new SelectList(db.tblProductDetails, "ProductID", "ProductName", tblcategorydetail.PID);
            //return View(tblcategorydetail);
        }

        // GET: /tblCategoryDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategoryDetail tblcategorydetail = db.tblCategoryDetails.Find(id);
            if (tblcategorydetail == null)
            {
                return HttpNotFound();
            }
            return View(tblcategorydetail);
        }

        // POST: /tblCategoryDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCategoryDetail tblcategorydetail = db.tblCategoryDetails.Find(id);
            db.tblCategoryDetails.Remove(tblcategorydetail);
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
