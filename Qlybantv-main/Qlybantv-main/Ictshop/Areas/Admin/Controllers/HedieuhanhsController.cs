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
    public class HedieuhanhsController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: Admin/Hedieuhanhs
        public ActionResult Index()
        {
            return View(db.LoaiTVs.ToList());
        }

        // GET: Admin/Hedieuhanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiTV loaitv = db.LoaiTVs.Find(id);
            if (loaitv == null)
            {
                return HttpNotFound();
            }
            return View(loaitv);
        }

        // GET: Admin/Hedieuhanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hedieuhanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiTV loaitv)
        {
            if (ModelState.IsValid)
            {
                db.LoaiTVs.Add(loaitv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaitv);
        }

        // GET: Admin/Hedieuhanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiTV loaitv = db.LoaiTVs.Find(id);
            if (loaitv == null)
            {
                return HttpNotFound();
            }
            return View(loaitv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiTV loaitv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaitv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaitv);
        }

        // GET: Admin/Hedieuhanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiTV loaitv = db.LoaiTVs.Find(id);
            if (loaitv == null)
            {
                return HttpNotFound();
            }
            return View(loaitv);
        }

        // POST: Admin/Hedieuhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiTV loaitv = db.LoaiTVs.Find(id);
            db.LoaiTVs.Remove(loaitv);
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
