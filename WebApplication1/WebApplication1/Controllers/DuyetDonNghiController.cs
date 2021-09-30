using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DuyetDonNghiController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: DuyetDonNghi
        public ActionResult Index()
        {
            var donNghiPheps = db.DonNghiPheps.Include(d => d.NhanVien);
            return View(donNghiPheps.ToList());
        }

        // GET: DuyetDonNghi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNghiPhep donNghiPhep = db.DonNghiPheps.Find(id);
            if (donNghiPhep == null)
            {
                return HttpNotFound();
            }
            return View(donNghiPhep);
        }

        // GET: DuyetDonNghi/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: DuyetDonNghi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonNghiPhep,MaNhanVien,NgayNghi,CaNghi,LyDo,TrangThai,NguoiDuyet")] DonNghiPhep donNghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.DonNghiPheps.Add(donNghiPhep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", donNghiPhep.MaNhanVien);
            return View(donNghiPhep);
        }

        // GET: DuyetDonNghi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNghiPhep donNghiPhep = db.DonNghiPheps.Find(id);
            if (donNghiPhep == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", donNghiPhep.MaNhanVien);
            return View(donNghiPhep);
        }

        // POST: DuyetDonNghi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonNghiPhep,MaNhanVien,NgayNghi,CaNghi,LyDo,TrangThai,NguoiDuyet")] DonNghiPhep donNghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donNghiPhep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", donNghiPhep.MaNhanVien);
            return View(donNghiPhep);
        }

        // GET: DuyetDonNghi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNghiPhep donNghiPhep = db.DonNghiPheps.Find(id);
            if (donNghiPhep == null)
            {
                return HttpNotFound();
            }
            return View(donNghiPhep);
        }

        // POST: DuyetDonNghi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonNghiPhep donNghiPhep = db.DonNghiPheps.Find(id);
            db.DonNghiPheps.Remove(donNghiPhep);
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
