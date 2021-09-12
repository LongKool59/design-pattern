using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: TaiKhoan
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page)
        {
            IQueryable<TaiKhoan> taiKhoans;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            List<TaiKhoanViewModel> taiKhoanViewModels;
            try
            {
                if (loaiTimKiem == "TenTK")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên tài khoản!", NotificationType.WARNING);
                    }
                    taiKhoans = db.TaiKhoans.Where(x => x.TenTK.Contains(tenTimKiem.ToString())).Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.NhanVien.HoTen);
                    taiKhoanViewModels = taiKhoans.ToList().ConvertAll<TaiKhoanViewModel>(x => x);
                    return View("Index", taiKhoanViewModels.ToPagedList(pageNumber, pageSize));

                }
                else if (loaiTimKiem == "MaNhanVien")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                    }
                    taiKhoans = db.TaiKhoans.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.NhanVien.HoTen);
                    taiKhoanViewModels = taiKhoans.ToList().ConvertAll<TaiKhoanViewModel>(x => x);
                    return View("Index", taiKhoanViewModels.ToPagedList(pageNumber, pageSize));

                }
                else if (loaiTimKiem == "TenQuyen")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên quyền!", NotificationType.WARNING);
                    }
                    taiKhoans = db.TaiKhoans.Where(x => x.PhanQuyen.TenQuyen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                    taiKhoanViewModels = taiKhoans.ToList().ConvertAll<TaiKhoanViewModel>(x => x);
                    return View("Index", taiKhoanViewModels.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    taiKhoans = db.TaiKhoans.Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.NhanVien.HoTen);
                    taiKhoanViewModels = taiKhoans.ToList().ConvertAll<TaiKhoanViewModel>(x => x);
                    return View("Index", taiKhoanViewModels.ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                taiKhoans = db.TaiKhoans.Where(x => x.PhanQuyen.TenQuyen.Contains("-*/+-*/*-++//*")).Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.PhanQuyen.TenQuyen);
                taiKhoanViewModels = taiKhoans.ToList().ConvertAll<TaiKhoanViewModel>(x => x);
                return View("Index", taiKhoanViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: TaiKhoan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            TaiKhoanViewModel taiKhoanViewModel = taiKhoan;
            return View(taiKhoanViewModel);
        }

        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
            TaiKhoanViewModel taiKhoanViewModel = taiKhoan;
            return View(taiKhoanViewModel);
        }

        // POST: TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaiKhoanViewModel taiKhoanViewModel)
        {
            TaiKhoan taiKhoan;
            if (ModelState.IsValid)
            {
                taiKhoan = taiKhoanViewModel;
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoanViewModel.MaNhanVien);
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoanViewModel.MaQuyen);
            return View(taiKhoanViewModel);
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
