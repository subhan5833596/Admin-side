using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin_side.Models;
using System.IO;

namespace Admin_side.Controllers
{
    public class tblProductDetailsController : Controller
    {
        private dbmsProject01Entities2 db = new dbmsProject01Entities2();
        public static string image;

        // GET: /tblProductDetails/
        public ActionResult Index()
        {
            return View(db.tblProductDetails.ToList());
        }

        // GET: /tblProductDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductDetail tblproductdetail = db.tblProductDetails.Find(id);
            if (tblproductdetail == null)
            {
                return HttpNotFound();
            }
            return View(tblproductdetail);
        }

        // GET: /tblProductDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /tblProductDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(tblProductDetail product)
        {
            if (product.Imagefile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.Imagefile.FileName);
                string extension = Path.GetExtension(product.Imagefile.FileName);
                HttpPostedFileBase postedfile = product.Imagefile;
                int length = postedfile.ContentLength;
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extension;
                        product.ImageUrl = "~/Image/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                        product.Imagefile.SaveAs(fileName);
                        db.tblProductDetails.Add(product);

                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            ViewBag.Message = "RECORD INSERT";
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
                return RedirectToAction("Index");
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //product.ImageUrl = "~/Image/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                //product.Imagefile.SaveAs(fileName);
            }
            //if (ModelState.IsValid)
            //{
            //db.tblProductDetails.Add(product);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        

            return View();
        }

    
        // GET: /tblProductDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductDetail tblproductdetail = db.tblProductDetails.Find(id);
            image = tblproductdetail.ImageUrl;
            if (tblproductdetail == null)
            {
                return HttpNotFound();
            }
            return View(tblproductdetail);
        }

        // POST: /tblProductDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(tblProductDetail product)
        {
            if (product.Imagefile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.Imagefile.FileName);
                string extension = Path.GetExtension(product.Imagefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImageUrl = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                product.Imagefile.SaveAs(fileName);
            }
            else
            {
                product.ImageUrl = image;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
            //if (product.Imagefile != null)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(product.Imagefile.FileName);
            //    string extension = Path.GetExtension(product.Imagefile.FileName);
            //    HttpPostedFileBase postedfile = product.Imagefile;
            //    int length = postedfile.ContentLength;
            //    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
            //    {
            //        if (length <= 1000000)
            //        {
            //            fileName = fileName + extension;
            //            product.ImageUrl = "~/Image/" + fileName;
            //            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            //            product.Imagefile.SaveAs(fileName);
           

            //            int a = db.SaveChanges();
            //            if (a > 0)
            //            {
            //                ViewBag.Message = "RECORD INSERT";
            //                if (ModelState.IsValid)
            //                {
            //                    db.Entry(product).State = EntityState.Modified;
            //                    db.SaveChanges();
            //                    return RedirectToAction("Index");
            //                }
            //                ModelState.Clear();
            //            }
            //            else
            //            {
                            
            //            }
            //        }
            //        else
            //        {
                            
            //        }
            //    }
            //    else
            //    {
                        
            //    }
                
            //    return View(product);
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

          
        
            
        

        // GET: /tblProductDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductDetail tblproductdetail = db.tblProductDetails.Find(id);
            if (tblproductdetail == null)
            {
                return HttpNotFound();
            }
            return View(tblproductdetail);
        }

        // POST: /tblProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProductDetail tblproductdetail = db.tblProductDetails.Find(id);
            db.tblProductDetails.Remove(tblproductdetail);
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
