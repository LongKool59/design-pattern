using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Builder.ConcreteBuilder;
using WebApplication1.Builder.IBuilder;

namespace WebApplication1.Controllers
{
    public class ChucVuController : Controller
    {
        private QLNhanSuEntities db = QLNhanSuEntities.getInstance();

        // GET: ChucVu
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page, string trangThai)
        {
            TempData["loaiTimKiem"] = loaiTimKiem;
            TempData["tenTimKiem"] = tenTimKiem;
            TempData["page"] = page;
            TempData["trangThai"] = trangThai;
            IQueryable<ChucVu> chucVus;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            List<ChucVuViewModel> chucVuViewModels;
            try
            {
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaChucVu")
                    {
                        if (tenTimKiem == null || tenTimKiem == "")
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã chức vụ!", NotificationType.WARNING);
                        }
                        chucVus = db.ChucVus.Where(x => x.MaChucVu.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }

                    else if (loaiTimKiem == "TenChucVu")
                    {
                        if (tenTimKiem == null || tenTimKiem == "")
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên chức vụ!", NotificationType.WARNING);
                        }
                        chucVus = db.ChucVus.Where(x => x.TenChucVu.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        chucVus = db.ChucVus.OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x); 
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaChucVu")
                    {
                        if (tenTimKiem == null || tenTimKiem == "")
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã chức vụ!", NotificationType.WARNING);
                        }
                        chucVus = db.ChucVus.Where(x => x.MaChucVu.ToString().Contains(tenTimKiem.ToString()) && x.TrangThai == true).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x); 
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }

                    else if (loaiTimKiem == "TenChucVu")
                    {
                        if (tenTimKiem == null || tenTimKiem == "")
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên chức vụ!", NotificationType.WARNING);
                        }
                        chucVus = db.ChucVus.Where(x => x.TenChucVu.Contains(tenTimKiem.ToString()) && x.TrangThai == true).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x); 
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        chucVus = db.ChucVus.Where(x => x.TrangThai == true).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x); 
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaChucVu")
                    {
                        if (tenTimKiem == null || tenTimKiem == "")
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã chức vụ!", NotificationType.WARNING);
                        }
                        chucVus = db.ChucVus.Where(x => x.MaChucVu.ToString().Contains(tenTimKiem.ToString()) && x.TrangThai != true).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }

                    else if (loaiTimKiem == "TenChucVu")
                    {
                        if (tenTimKiem == null || tenTimKiem == "")
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên chức vụ!", NotificationType.WARNING);
                        }
                        chucVus = db.ChucVus.Where(x => x.TenChucVu.Contains(tenTimKiem.ToString()) && x.TrangThai != true).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        chucVus = db.ChucVus.Where(x => x.TrangThai != true).OrderBy(x => x.TenChucVu);
                        chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                        return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    chucVus = db.ChucVus.OrderBy(x => x.TenChucVu);
                    chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                    return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                chucVus = db.ChucVus.OrderBy(x => x.TenChucVu).Where(x => x.TenChucVu.Contains("/*-+-*/-+-*/"));
                chucVuViewModels = chucVus.ToList().ConvertAll<ChucVuViewModel>(x => x);
                return View("Index", chucVuViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<ChucVuViewModel> chucVuViewModels)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = chucVuViewModels.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn chức vụ để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index", new {  loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"], page = TempData["page"], trangThai = TempData["trangThai"] });
                }

                foreach (var item in chucVuViewModels)
                {
                    if (item.IsChecked == true)
                    {
                        int maChucVu = item.MaChucVu;
                        ChucVu chucVu = db.ChucVus.Where(x => x.MaChucVu == maChucVu).SingleOrDefault();
                        if (chucVu != null)
                        {
                            chucVu.TrangThai = false;
                           
                        }
                    }
                }
                db.SaveChanges();

                return RedirectToAction("Index", new { loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"], page = TempData["page"], trangThai = TempData["trangThai"] });
            }
            catch
            {

                this.AddNotification("Không thể xóa vì chức vụ này đã và đang được sử dụng!", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
        }

        // GET: ChucVu/Details/5
        public ActionResult Details(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            ChucVuViewModel chucVuViewModel = chucVu;
            return View(chucVuViewModel);
        }

        // GET: ChucVu/Create
        public ActionResult Create()
        {
            TempData.Keep();
            ChucVuViewModel chucVuViewModel = new ChucVuViewModel();
            return View(chucVuViewModel);
        }

        // POST: ChucVu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChucVuViewModel chucVuViewModel)
        {
            if (ModelState.IsValid)
            {
                var oldTenChucVu = "";
                var tenChucVuList = db.ChucVus.Where(x => x.TenChucVu.Equals(chucVuViewModel.TenChucVu.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

                if (tenChucVuList.Count > 0)
                {
                    foreach (var item in tenChucVuList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + chucVuViewModel.NguoiSua;
                            item.NgaySua = DateTime.Now;
                           
                        }
                        oldTenChucVu = item.TenChucVu;
                    }

                    var _chucVuViewModel = new ChucVuViewModelBuilder()
                        .AddTenChucVu(oldTenChucVu)
                        .AddHeSoChucVu(chucVuViewModel.HeSoChucVu)
                        .AddPhuCap(chucVuViewModel.PhuCap)
                        .AddTrangThai(true)
                        .AddNguoiSua(chucVuViewModel.NguoiSua)
                        .AddNgaySua(chucVuViewModel.NgaySua)
                        .Build();   

                    ChucVu chucVu = _chucVuViewModel;
                    db.ChucVus.Add(chucVu);
                    db.SaveChanges();

                    var nhanViens = db.NhanViens.ToList();
                    var newMaChucVu = db.ChucVus.Where(x => x.TenChucVu.Equals(chucVu.TenChucVu.Trim(), StringComparison.OrdinalIgnoreCase) && x.TrangThai == true).FirstOrDefault();
                    if (newMaChucVu != null)
                    {
                        ThayDoiNhanVienVoiMaChucVuMoi(newMaChucVu.MaChucVu, chucVu.TenChucVu.Trim(), nhanViens);
                    }
                }
                else
                {
                    var _chucVuViewModel = new ChucVuViewModelBuilder()
                       .AddTenChucVu(chucVuViewModel.TenChucVu)
                       .AddHeSoChucVu(chucVuViewModel.HeSoChucVu)
                       .AddPhuCap(chucVuViewModel.PhuCap)
                       .AddTrangThai(true)
                       .AddNguoiSua(chucVuViewModel.NguoiSua)
                       .AddNgaySua(chucVuViewModel.NgaySua)
                       .Build();

                    ChucVu chucVu = _chucVuViewModel;
                    db.ChucVus.Add(chucVu);
                }
                db.SaveChanges();
                return RedirectToAction("Index", new { loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"], page = TempData["page"], trangThai = TempData["trangThai"] });
            }

            return View(chucVuViewModel);
        }

        // GET: ChucVu/Edit/5
        public ActionResult Edit(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            ChucVuViewModel chucVuViewModel = chucVu;
            return View(chucVuViewModel);
        }

        // POST: ChucVu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChucVuViewModel chucVuViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(chucVu).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
                var oldTenChucVu = "";
                var tenChucVuList = db.ChucVus.Where(x => x.TenChucVu.Equals(chucVuViewModel.TenChucVu.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                if (tenChucVuList.Count > 0)
                {
                    foreach (var item in tenChucVuList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + chucVuViewModel.NguoiSua;
                            item.NgaySua = DateTime.Now;
                           
                        }
                        oldTenChucVu = item.TenChucVu;
                    }
                    chucVuViewModel.TenChucVu = oldTenChucVu;
                    chucVuViewModel.TrangThai = true;
                    ChucVu chucVu = chucVuViewModel;
                    db.ChucVus.Add(chucVu);
                    db.SaveChanges();

                    var nhanViens = db.NhanViens.ToList();
                    var newMaChucVu = db.ChucVus.Where(x => x.TenChucVu.Equals(chucVu.TenChucVu.Trim(), StringComparison.OrdinalIgnoreCase) && x.TrangThai == true).FirstOrDefault();
                    if (newMaChucVu != null)
                    {
                        ThayDoiNhanVienVoiMaChucVuMoi(newMaChucVu.MaChucVu, chucVu.TenChucVu.Trim(), nhanViens);
                    }
                }
                else
                {
                    chucVuViewModel.TrangThai = true;
                    ChucVu chucVu = chucVuViewModel;
                    db.ChucVus.Add(chucVu);
                }
                db.SaveChanges();
                return RedirectToAction("Index", new { loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"], page = TempData["page"], trangThai = TempData["trangThai"] });
            }
            return View(chucVuViewModel);
        }

        [NonAction]
        public void ThayDoiNhanVienVoiMaChucVuMoi(int newMaChucVu, string tenChucVu, List<NhanVien> nhanViens)
        {
            if (ModelState.IsValid)
            {
                var listNhanVien = db.NhanViens.Where(x => x.ChucVu.TenChucVu.ToString().Equals(tenChucVu.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var item in listNhanVien)
                {
                    foreach (var NV in nhanViens)
                    {
                        if (item.MaNhanVien == NV.MaNhanVien)
                        {
                            NV.MaChucVu = newMaChucVu;
                        }
                    }
                }
                db.SaveChanges();
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
