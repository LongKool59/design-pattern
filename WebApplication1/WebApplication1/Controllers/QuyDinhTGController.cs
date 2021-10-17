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
    public class QuyDinhTGController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: QuyDinhTG
        public ActionResult Index(int? page, string loaiTimKiem, string tenTimKiem)
        {
            TempData["loaiTimKiem"] = loaiTimKiem;
            TempData["tenTimKiem"] = tenTimKiem;
            TempData["page"] = page;
            IQueryable<QuyDinhThoiGian> quyDinhThoiGians;
            int pageNumber = page ?? 1;
            int pageSize = 10;
            List<QuyDinhTGViewModel> quyDinhTGViewModels;
            try
            {
                if (loaiTimKiem == "MaQuyDinh")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã quy định!", NotificationType.WARNING);
                    else
                        this.AddNotification("Kết quả tìm kiếm theo mã quy định: " + tenTimKiem, NotificationType.INFO);
                    quyDinhThoiGians = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenQuyDinh);
                    quyDinhTGViewModels = quyDinhThoiGians.ToList().ConvertAll<QuyDinhTGViewModel>(x => x);
                    return View("Index", quyDinhTGViewModels.ToPagedList(pageNumber, pageSize));
                }
                else if (loaiTimKiem == "TenQuyDinh")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên quy định!", NotificationType.WARNING);
                    else
                        this.AddNotification("Kết quả tìm kiếm theo tên quy định: " + tenTimKiem, NotificationType.INFO);
                    quyDinhThoiGians = db.QuyDinhThoiGians.Where(x => x.TenQuyDinh.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenQuyDinh);
                    quyDinhTGViewModels = quyDinhThoiGians.ToList().ConvertAll<QuyDinhTGViewModel>(x => x);
                    return View("Index", quyDinhTGViewModels.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    quyDinhThoiGians = db.QuyDinhThoiGians.OrderBy(x => x.TenQuyDinh);
                    quyDinhTGViewModels = quyDinhThoiGians.ToList().ConvertAll<QuyDinhTGViewModel>(x => x);
                    return View("Index", quyDinhTGViewModels.ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                quyDinhThoiGians = db.QuyDinhThoiGians.OrderBy(x => x.TenQuyDinh);
                quyDinhTGViewModels = quyDinhThoiGians.ToList().ConvertAll<QuyDinhTGViewModel>(x => x);
                return View("Index", quyDinhTGViewModels.ToPagedList(pageNumber, pageSize));
            }
           
        }

        // GET: QuyDinhTG/Details/5
        public ActionResult Details(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyDinhThoiGian quyDinhThoiGian = db.QuyDinhThoiGians.Find(id);
            if (quyDinhThoiGian == null)
            {
                return HttpNotFound();
            }
            QuyDinhTGViewModel quyDinhTGViewModel = quyDinhThoiGian;
            return View(quyDinhTGViewModel);
        }

        // GET: QuyDinhTG/Edit/5
        public ActionResult Edit(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuyDinhThoiGian quyDinhThoiGian = db.QuyDinhThoiGians.Find(id);
            if (quyDinhThoiGian == null)
            {
                return HttpNotFound();
            }
            QuyDinhTGViewModel quyDinhTGViewModel = quyDinhThoiGian;
            return View(quyDinhTGViewModel);
        }

        // POST: QuyDinhTG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuyDinhTGViewModel quyDinhTGViewModel)
        {
            QuyDinhThoiGian quyDinhThoiGian;
            if (ModelState.IsValid)
            {
                quyDinhThoiGian = quyDinhTGViewModel;
                var batDauCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 3).Select(x => x.GiaTri).Single();
                var ketThucCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 4).Select(x => x.GiaTri).Single();
                switch (quyDinhThoiGian.MaQuyDinh)
                {
                    case 1:
                        var ketThucCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 2).Select(x => x.GiaTri).Single();
                        if(quyDinhThoiGian.GiaTri > ketThucCaSang)
                        {
                            this.AddNotification("Giờ bắt đầu ca sáng không được lớn hơn giờ kết thúc ca sáng (" + ketThucCaSang + ")!", NotificationType.ERROR);
                            return RedirectToAction("Edit", quyDinhTGViewModel);
                        }
                        break;
                    case 2:
                        var batDauCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 1).Select(x => x.GiaTri).Single();

                        if (quyDinhThoiGian.GiaTri < batDauCaSang)
                        {
                            this.AddNotification("Giờ kết thúc ca sáng không được nhỏ hơn giờ bắt đầu ca sáng (" + batDauCaSang + ")!", NotificationType.ERROR);
                            return RedirectToAction("Edit", quyDinhTGViewModel);
                        }
                        else if(quyDinhThoiGian.GiaTri > batDauCaChieu)
                        {
                            this.AddNotification("Giờ kết thúc ca sáng không được lớn hơn hoặc bằng giờ bắt đầu ca chiều (" + batDauCaChieu + ")!", NotificationType.ERROR);
                            return RedirectToAction("Edit", quyDinhTGViewModel);
                        }
                        break;
                    case 3:
                        
                        if (quyDinhThoiGian.GiaTri > ketThucCaChieu)
                        {
                            this.AddNotification("Giờ bắt đầu ca chiều không được lớn hơn giờ kết thúc ca chiều (" + ketThucCaChieu + ")!", NotificationType.ERROR);
                            return RedirectToAction("Edit", quyDinhTGViewModel);
                        }
                        break;
                    case 4:
                       
                        if (quyDinhThoiGian.GiaTri < batDauCaChieu)
                        {
                            this.AddNotification("Giờ kết thúc ca chiều không được nhỏ hơn giờ bắt đầu ca chiều (" + batDauCaChieu + ")!", NotificationType.ERROR);
                            return RedirectToAction("Edit", quyDinhTGViewModel);
                        }
                        break;
                    case 5:
                        if (quyDinhThoiGian.GiaTri < ketThucCaChieu)
                        {
                            this.AddNotification("Giờ thêm nhân viên nghỉ vào danh sách không được nhỏ hơn giờ kết thúc ca chiều (" + ketThucCaChieu + ")!", NotificationType.ERROR);
                            return RedirectToAction("Edit", quyDinhTGViewModel);
                        }
                        break;
                }
                    
                db.Entry(quyDinhThoiGian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { page = TempData["page"], loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"] });
            }
            return View(quyDinhTGViewModel);
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
