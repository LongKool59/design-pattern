using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class PhanQuyenController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: PhanQuyen
        public ActionResult Index(int? page, string loaiTimKiem, string tenTimKiem)
        {
            IQueryable<PhanQuyen> phanQuyens;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            List<PhanQuyenViewModel> phanQuyenViewModels;
            try
            {
                if (loaiTimKiem == "MaQuyen")
                {
                    if (tenTimKiem == null || tenTimKiem == "")
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã quyền!", NotificationType.WARNING);
                    }
                    phanQuyens = db.PhanQuyens.Where(x => x.MaQuyen.ToString().Contains(tenTimKiem.ToString())).OrderByDescending(x => x.TenQuyen);
                    phanQuyenViewModels = phanQuyens.ToList().ConvertAll<PhanQuyenViewModel>(x => x);
                    return View("Index", phanQuyenViewModels.ToPagedList(pageNumber, pageSize));
                }
                else if (loaiTimKiem == "TenQuyen")
                {
                    if (tenTimKiem == null || tenTimKiem == "")
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên quyền!", NotificationType.WARNING);
                    }
                    phanQuyens = db.PhanQuyens.Where(x => x.TenQuyen.Contains(tenTimKiem.ToString())).OrderByDescending(x => x.TenQuyen);
                    phanQuyenViewModels = phanQuyens.ToList().ConvertAll<PhanQuyenViewModel>(x => x);
                    return View("Index", phanQuyenViewModels.ToPagedList(pageNumber, pageSize));
                }
                phanQuyens = db.PhanQuyens.OrderByDescending(x => x.TenQuyen);
                phanQuyenViewModels = phanQuyens.ToList().ConvertAll<PhanQuyenViewModel>(x => x);
                return View("Index", phanQuyenViewModels.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                phanQuyens = db.PhanQuyens.Where(x => x.MaQuyen.ToString().Contains("+-*/*-+-*/-+"));
                phanQuyenViewModels = phanQuyens.ToList().ConvertAll<PhanQuyenViewModel>(x => x);
                return View("Index", phanQuyenViewModels.ToPagedList(pageNumber, pageSize));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<PhanQuyenViewModel> phanQuyenViewModels)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = phanQuyenViewModels.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn phân quyền để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }

                foreach (var item in phanQuyenViewModels)
                {
                    if (item.IsChecked == true)
                    {
                        int maQuyen = item.MaQuyen;
                        PhanQuyen quyen = db.PhanQuyens.Where(x => x.MaQuyen == maQuyen).SingleOrDefault();
                        if (quyen != null)
                        {
                            db.PhanQuyens.Remove(quyen);
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                this.AddNotification("Không thể xóa vì quyền này đã và đang được sử dụng!", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
        }


        // GET: PhanQuyen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            PhanQuyenViewModel phanQuyenViewModel = phanQuyen;
            return View(phanQuyenViewModel);
        }

        // GET: PhanQuyen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanQuyen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhanQuyenViewModel phanQuyenViewModel)
        {
            PhanQuyen phanQuyen;
            if (ModelState.IsValid)
            {
                phanQuyen = phanQuyenViewModel;
                db.PhanQuyens.Add(phanQuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phanQuyenViewModel);
        }

        // GET: PhanQuyen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            PhanQuyenViewModel phanQuyenViewModel = phanQuyen;
            return View(phanQuyenViewModel);
        }

        // POST: PhanQuyen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhanQuyenViewModel phanQuyenViewModel)
        {
            PhanQuyen phanQuyen;
            if (ModelState.IsValid)
            {
                phanQuyen = phanQuyenViewModel;
                db.Entry(phanQuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phanQuyenViewModel);
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
