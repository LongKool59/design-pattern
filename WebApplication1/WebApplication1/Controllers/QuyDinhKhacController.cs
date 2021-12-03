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
    public class QuyDinhKhacController : Controller
    {
        private QLNhanSuEntities db = QLNhanSuEntities.getInstance();

        // GET: QuyDinhKhac
        public ActionResult Index(int? page, string loaiTimKiem, string tenTimKiem)
        {
            TempData["loaiTimKiem"] = loaiTimKiem;
            TempData["tenTimKiem"] = tenTimKiem;
            TempData["page"] = page;
            IQueryable<QuyDinhKhac> quyDinhKhacs;
            int pageNumber = page ?? 1;
            int pageSize = 10;
            List<QuyDinhKhacViewModel> quyDinhKhacViewModels;
            try
            {
                if (loaiTimKiem == "MaQuyDinh")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã quy định!", NotificationType.WARNING);
                    else
                        this.AddNotification("Kết quả tìm kiếm theo mã quy định: " + tenTimKiem, NotificationType.INFO);
                    quyDinhKhacs = db.QuyDinhKhacs.Where(x => x.MaQuyDinh.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenQuyDinh);
                    quyDinhKhacViewModels = quyDinhKhacs.ToList().ConvertAll<QuyDinhKhacViewModel>(x => x);
                    return View("Index", quyDinhKhacViewModels.ToPagedList(pageNumber, pageSize));
                }
                else if (loaiTimKiem == "TenQuyDinh")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên quy định!", NotificationType.WARNING);
                    else
                        this.AddNotification("Kết quả tìm kiếm theo tên quy định: " + tenTimKiem, NotificationType.INFO);
                    quyDinhKhacs = db.QuyDinhKhacs.Where(x => x.TenQuyDinh.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenQuyDinh);
                    quyDinhKhacViewModels = quyDinhKhacs.ToList().ConvertAll<QuyDinhKhacViewModel>(x => x);
                    return View("Index", quyDinhKhacViewModels.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    quyDinhKhacs = db.QuyDinhKhacs.OrderBy(x => x.TenQuyDinh);
                    quyDinhKhacViewModels = quyDinhKhacs.ToList().ConvertAll<QuyDinhKhacViewModel>(x => x);
                    return View("Index", quyDinhKhacViewModels.ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                quyDinhKhacs = db.QuyDinhKhacs.OrderBy(x => x.TenQuyDinh);
                quyDinhKhacViewModels = quyDinhKhacs.ToList().ConvertAll<QuyDinhKhacViewModel>(x => x);
                return View("Index", quyDinhKhacViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: QuyDinhKhac/Details/5
        public ActionResult Details(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyDinhKhac quyDinhKhac = db.QuyDinhKhacs.Find(id);
            if (quyDinhKhac == null)
            {
                return HttpNotFound();
            }
            QuyDinhKhacViewModel quyDinhKhacViewModel = quyDinhKhac;
            return View(quyDinhKhacViewModel);
        }

        // GET: QuyDinhKhac/Edit/5
        public ActionResult Edit(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyDinhKhac quyDinhKhac = db.QuyDinhKhacs.Find(id);
            if (quyDinhKhac == null)
            {
                return HttpNotFound();
            }
            QuyDinhKhacViewModel quyDinhKhacViewModel = quyDinhKhac;
            return View(quyDinhKhacViewModel);
        }

        // POST: QuyDinhKhac/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuyDinhKhacViewModel quyDinhKhacViewModel)
        {
            if (ModelState.IsValid)
            {
                QuyDinhKhac quyDinhKhac = quyDinhKhacViewModel;
                db.Entry(quyDinhKhac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { page = TempData["page"], loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"] });
            }
            return View(quyDinhKhacViewModel);
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
