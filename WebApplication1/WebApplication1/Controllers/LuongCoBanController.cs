using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using PagedList;
using PagedList.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class LuongCoBanController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: LuongCoBan
        public ActionResult Index(int? page, string trangThai, string MaPB, string loaiTimKiem, string tenTimKiem)
        {
            ViewBag.MaPB = new SelectList(db.PhongBans.OrderByDescending(x => x.TenPB), "MaPB", "TenPB", "12");
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<LuongCoBan> luongCoBans;
            List<LuongCoBanViewModel> luongCoBanViewModels;
            try
            {
                if (trangThai == "TatCa")
                {
                    if (MaPB == "12")
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x);
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (MaPB == "12")
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai == true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai == true).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai == true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x);  
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai == true).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (MaPB == "12")
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai != true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x);  
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x);  
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai != true).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai != true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai != true).OrderBy(x => x.NhanVien.HoTen);
                            luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x); 
                            return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                }

                luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x);  
                return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                luongCoBans = db.LuongCoBans.Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals("*/-+-*/-+*/")).Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                luongCoBanViewModels = luongCoBans.ToList().ConvertAll<LuongCoBanViewModel>(x => x);  
                return View(luongCoBanViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: LuongCoBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongCoBan luongCoBan = db.LuongCoBans.Find(id);
            if (luongCoBan == null)
            {
                return HttpNotFound();
            }
            LuongCoBanViewModel luongCoBanViewModel = luongCoBan;
            return View(luongCoBanViewModel);
        }

        // GET: LuongCoBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongCoBan luongCoBan = db.LuongCoBans.Find(id);
            if (luongCoBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", luongCoBan.MaNhanVien);
            LuongCoBanViewModel luongCoBanViewModel = luongCoBan;
            return View(luongCoBanViewModel);
        }

        // POST: LuongCoBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LuongCoBanViewModel luongCoBanViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(luongCoBan).State = EntityState.Modified;
                var luongCoBanList = db.LuongCoBans.Where(x => x.MaNhanVien == luongCoBanViewModel.MaNhanVien);
                foreach(var item in luongCoBanList)
                {
                    item.TrangThai = false;
                }
                LuongCoBan newLuongCB = new LuongCoBan();
                newLuongCB.TienLuongCoBan = luongCoBanViewModel.TienLuongCoBan;
                newLuongCB.MaNhanVien = luongCoBanViewModel.MaNhanVien;
                newLuongCB.TrangThai = true;
                newLuongCB.NguoiSua = luongCoBanViewModel.NguoiSua;
                newLuongCB.NgaySua = DateTime.Now;
                db.LuongCoBans.Add(newLuongCB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", luongCoBanViewModel.MaNhanVien);
            return View(luongCoBanViewModel);
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
