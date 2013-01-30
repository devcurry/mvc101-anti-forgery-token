using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatIsValidateAntiForgeryToken.Models
{
    [Authorize()]
    public class ProductDetailsController : Controller
    {
        private WhatIsValidateAntiForgeryTokenContext db = new WhatIsValidateAntiForgeryTokenContext();

        //
        // GET: /ProductDetails/
        [Authorize(Roles="Admins")]
        public ActionResult Index()
        {
            return View(db.ProductDetails.ToList());
        }

        //
        // GET: /ProductDetails/Details/5
        [Authorize(Roles="Admins,Users")]
        public ActionResult Details(int id = 0)
        {
            ProductDetails productdetails = db.ProductDetails.Find(id);
            if (productdetails == null)
            {
                return HttpNotFound();
            }
            return View(productdetails);
        }

        //
        // GET: /ProductDetails/Create
        [Authorize(Roles = "Admins")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductDetails/Create

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult Create(ProductDetails productdetails)
        {
            if (ModelState.IsValid)
            {
                db.ProductDetails.Add(productdetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productdetails);
        }

        //
        // GET: /ProductDetails/Edit/5
        [Authorize(Roles = "Admins")]
        public ActionResult Edit(int id = 0)
        {
            ProductDetails productdetails = db.ProductDetails.Find(id);
            if (productdetails == null)
            {
                return HttpNotFound();
            }
            return View(productdetails);
        }

        //
        // POST: /ProductDetails/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admins")]
        //[ValidateAntiForgeryToken()]
        public ActionResult Edit(ProductDetails productdetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productdetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productdetails);
        }

        //
        // GET: /ProductDetails/Delete/5
        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int id = 0)
        {
            ProductDetails productdetails = db.ProductDetails.Find(id);
            if (productdetails == null)
            {
                return HttpNotFound();
            }
            return View(productdetails);
        }

        //
        // POST: /ProductDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDetails productdetails = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(productdetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}