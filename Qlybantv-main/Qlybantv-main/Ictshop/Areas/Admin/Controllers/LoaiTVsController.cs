using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Areas.Admin.Controllers
{
    public class LoaiTVsController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: Admin/LoaiTVs
        public ActionResult Index()
        {
            return View(db.LoaiTVs.ToList());
        }

        // GET: Admin/LoaiTVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiTV loaiTV = db.LoaiTVs.Find(id);
            if (loaiTV == null)
            {
                return HttpNotFound();
            }
            return View(loaiTV);
        }

        // GET: Admin/LoaiTVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiTVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiTV loaiTV)
        {
            if (ModelState.IsValid)
            {
                db.LoaiTVs.Add(loaiTV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiTV);
        }

        // GET: Admin/LoaiTVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiTV loaiTV = db.LoaiTVs.Find(id);
            if (loaiTV == null)
            {
                return HttpNotFound();
            }
            return View(loaiTV);
        }

        // POST: Admin/LoaiTVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiTV loaiTV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiTV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiTV);
        }

        // GET: Admin/LoaiTVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiTV loaiTV = db.LoaiTVs.Find(id);
            if (loaiTV == null)
            {
                return HttpNotFound();
            }
            return View(loaiTV);
        }

        // POST: Admin/LoaiTVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiTV loaiTV = db.LoaiTVs.Find(id);
            db.LoaiTVs.Remove(loaiTV);
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
