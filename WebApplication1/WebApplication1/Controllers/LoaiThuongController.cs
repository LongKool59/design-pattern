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
using PagedList;
using PagedList.Mvc;
using WebApplication1.FactoryMethod.Factory;
using WebApplication1.FactoryMethod.ConcreteFactory;

namespace WebApplication1.Controllers
{
    public class LoaiThuongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        public ActionResult Index(int? page, string trangThai, string loaiTimKiem, string tenTimKiem)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            IQueryable<LoaiThuong> loaiThuongs;
            List<LoaiThuongViewModel> loaiThuongViewModels;
            TempData["loaiTimKiem"] = loaiTimKiem;
            TempData["tenTimKiem"] = tenTimKiem;
            TempData["page"] = page;
            TempData["trangThai"] = trangThai;

            try
            {
                QLNhanSuEntities db = new QLNhanSuEntities();
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.MaLoaiThuong.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.MaLoaiThuong.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiThuongs = db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong);
                        loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                        return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.MaLoaiThuong.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.MaLoaiThuong.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.TenLoaiThuong.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.TenLoaiThuong.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true).OrderBy(x => x.TenLoaiThuong);
                        loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                        return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.MaLoaiThuong.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.MaLoaiThuong.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.TenLoaiThuong.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.TenLoaiThuong.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                            return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true).OrderBy(x => x.TenLoaiThuong);
                        loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                        return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    loaiThuongs = db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong);
                    loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                    return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                loaiThuongs = db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong);
                loaiThuongViewModels = loaiThuongs.ToList().ConvertAll<LoaiThuongViewModel>(x => x);
                return View("Index", loaiThuongViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: LoaiThuong/Details/5
        public ActionResult Details(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuong loaiThuong = db.LoaiThuongs.Find(id);
            if (loaiThuong == null)
            {
                return HttpNotFound();
            }
            LoaiThuongViewModel loaiThuongViewModel = loaiThuong;
            return View(loaiThuongViewModel);
        }

        // GET: LoaiThuong/Create
        public ActionResult Create()
        {
            TempData.Keep();
            LoaiThuongViewModel loaiThuongViewModel = new LoaiThuongViewModel();
            return View(loaiThuongViewModel);
        }

        // POST: LoaiThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiThuongViewModel loaiThuongViewModel)
        {
            LoaiThuong loaiThuong;
            if (ModelState.IsValid)
            {
                //kiểm tra tên loại thưởng được nhập từ ô textbox có trùng với bất kỳ tên loại thưởng nào trong database bảng LoaiThuong không 
                var tenLoaiThuongList = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Equals(loaiThuongViewModel.TenLoaiThuong.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                string oldTenLoaiThuong = "";
                if (tenLoaiThuongList.Count > 0)
                {
                    foreach (var item in tenLoaiThuongList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiThuongViewModel.NguoiSua;
                            item.NgaySua = DateTime.Now;

                        }
                        oldTenLoaiThuong = item.TenLoaiThuong;
                    }
                    loaiThuongViewModel.TenLoaiThuong = oldTenLoaiThuong;
                    loaiThuongViewModel.TrangThai = true;
                }
                //loaiThuong = loaiThuongViewModel;
                Factory1 factory = new LoaiThuongFactory();
                db.LoaiThuongs.Add(factory.CreateModel(loaiThuongViewModel));
                db.SaveChanges();
                return RedirectToAction("Index", new { page = TempData["page"], trangThai = TempData["trangThai"], loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"] });
            }
            return View(loaiThuongViewModel);
        }

        // GET: LoaiThuong/Edit/5
        public ActionResult Edit(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuong loaiThuong = db.LoaiThuongs.Find(id);
            if (loaiThuong == null)
            {
                return HttpNotFound();
            }
            LoaiThuongViewModel loaiThuongViewModel = loaiThuong;
            return View(loaiThuongViewModel);
        }

        // POST: LoaiThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiThuongViewModel loaiThuongViewModel)
        {
            LoaiThuong loaiThuong;
            if (ModelState.IsValid)
            {
                var tenLoaiThuongList = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Equals(loaiThuongViewModel.TenLoaiThuong.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                string oldTenLoaiThuong = "";
                if (tenLoaiThuongList.Count > 0)
                {
                    foreach (var item in tenLoaiThuongList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiThuongViewModel.NguoiSua;
                            item.NgaySua = DateTime.Now;

                        }
                        oldTenLoaiThuong = item.TenLoaiThuong;
                    }
                    loaiThuongViewModel.TenLoaiThuong = oldTenLoaiThuong;
                    loaiThuongViewModel.TrangThai = true;
                    loaiThuong = loaiThuongViewModel;
                    db.LoaiThuongs.Add(loaiThuong);
                }
                else
                {
                    loaiThuong = loaiThuongViewModel;
                    db.LoaiThuongs.Add(loaiThuong);
                }

                db.SaveChanges();
                return RedirectToAction("Index", new { page = TempData["page"], trangThai = TempData["trangThai"], loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"] });
            }
            return View(loaiThuongViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<LoaiThuongViewModel> loaiThuongViewModels)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = loaiThuongViewModels.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn loại thưởng để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index", new { page = TempData["page"], trangThai = TempData["trangThai"], loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"] });
                }
                foreach (var item in loaiThuongViewModels)
                {
                    if (item.IsChecked == true)
                    {
                        int maLoaiThuong = item.MaLoaiThuong;
                        LoaiThuong loaiThuong = db.LoaiThuongs.Where(x => x.MaLoaiThuong == maLoaiThuong).SingleOrDefault();
                        if (loaiThuong != null)
                        {
                            loaiThuong.TrangThai = false;
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index", new { page = TempData["page"], trangThai = TempData["trangThai"], loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"] });
            }
            catch
            {
                this.AddNotification("Không thể xóa vì loại thưởng này đã và đang được sử dụng!", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
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
