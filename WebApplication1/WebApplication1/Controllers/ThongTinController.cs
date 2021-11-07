using PagedList;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class ThongTinController : Controller
    {
        QLNhanSuEntities db = new QLNhanSuEntities();
        // GET: ThongTin
        public ActionResult ThongTinTaiKhoan()
        {
            return View();
        }

        //Xem chi tiết lương
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongThang luongThang = db.LuongThangs.Find(id);
            if (luongThang == null)
            {
                return HttpNotFound();
            }
            LuongThangViewModel luongThangViewModel = luongThang;
            return View(luongThangViewModel);
        }

        public ActionResult XemBangLuong(int? page, int? month, int? year)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<LuongThang> luongThangs;
            string maNV = Session["MaNhanVien"].ToString();
            List<LuongThangViewModel> luongThangViewModels;
            try
            {
                if (year != null && month != null)
                {
                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Equals(maNV)).OrderBy(x => x.ThangNam);
                    luongThangViewModels = luongThangs.ToList().ConvertAll<LuongThangViewModel>(x => x);
                    return View(luongThangViewModels.ToPagedList(pageNumber, pageSize));
                }
                else if (year != null && month == null)
                {
                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.MaNhanVien.ToString().Equals(maNV)).OrderBy(x => x.ThangNam);
                    luongThangViewModels = luongThangs.ToList().ConvertAll<LuongThangViewModel>(x => x);
                    return View(luongThangViewModels.ToPagedList(pageNumber, pageSize));
                }
                else if (year == null && month != null)
                {
                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Equals(maNV)).OrderBy(x => x.ThangNam);
                    luongThangViewModels = luongThangs.ToList().ConvertAll<LuongThangViewModel>(x => x);
                    return View(luongThangViewModels.ToPagedList(pageNumber, pageSize));
                }
                luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.MaNhanVien.ToString().Equals(maNV)).OrderBy(x => x.ThangNam);
                luongThangViewModels = luongThangs.ToList().ConvertAll<LuongThangViewModel>(x => x);
                return View(luongThangViewModels.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện lại!", NotificationType.ERROR);
                luongThangs = db.LuongThangs.Where(x => x.MaLuong_Thang.ToString().Contains("+-*/*-+-*/-+")).OrderBy(x => x.ThangNam);
                luongThangViewModels = luongThangs.ToList().ConvertAll<LuongThangViewModel>(x => x);
                return View(luongThangViewModels.ToPagedList(pageNumber, pageSize));
            }

        }
        public ActionResult DoiMatKhau()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(ChangePassword changePass)
        {
            string tenTK = Session["TenTK"].ToString();
            var taiKhoan = db.TaiKhoans.Where(x => x.TenTK == tenTK).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (taiKhoan != null)
                {
                    if (taiKhoan.MatKhau == changePass.MatKhauCu)
                    {
                        if (ModelState.IsValid)
                        {
                            taiKhoan.MatKhau = changePass.MatKhauMoi;
                            db.SaveChanges();
                            this.AddNotification("Đổi mật khẩu thành công", NotificationType.SUCCESS);
                            return View();
                        }
                        return View(changePass);
                    }
                    else
                    {
                        this.AddNotification("Mật khẩu cũ không đúng", NotificationType.ERROR);
                        return View(changePass);
                    }
                }
            }
            return View();
        }
        public ActionResult XemThongTinCaNhan()
        {
            string tenTK = Session["TenTK"].ToString();
            int maNV = Convert.ToInt32(Session["MaNhanVien"]);
            var taiKhoan = db.TaiKhoans.Where(x => x.TenTK == tenTK).SingleOrDefault();
            if (taiKhoan != null)
            {
                NhanVien nhanVien = db.NhanViens.Where(x => x.MaNhanVien == taiKhoan.MaNhanVien).SingleOrDefault();
                if (nhanVien != null)
                {
                    NhanVienViewModel nhanVienViewModel = nhanVien;
                    return View(nhanVienViewModel);
                }
            }
            return RedirectToAction("ThongTinTaiKhoan");
        }
        #region in ra chi tiết phạt của nhân viên
        public ActionResult PrintCTPhat(int? month, int? year, int? maNV)
        {
            return new ActionAsPdf("DsChiTietPhat", new { month, year, maNV }) { FileName = "ChiTietPhat_MaNV_" + maNV + "_Thang_" + month + "_Nam_" + year + ".pdf" };
        }
        public ActionResult DsChiTietPhat(int? month, int? year, int? maNV)
        {
            TempData.Keep();
            IQueryable<Ct_Phat> ct_Phats;
            List<Ct_PhatViewModel> ct_PhatViewModels;
            ViewBag.month = month;
            ViewBag.year = year;
            ct_Phats = db.Ct_Phat.Where(x => x.MaNhanVien == maNV && x.NgayPhat.Month == month && x.NgayPhat.Year == year);
            ct_PhatViewModels = ct_Phats.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
            return View(ct_PhatViewModels);
        }
        #endregion in ra chi tiết phạt của nhân viên

        public ActionResult PrintCTThuong(int? month, int? year, int? maNV)
        {
            return new ActionAsPdf("DsChiTietThuong", new { month, year, maNV }) { FileName = "ChiTietThuong_MaNV_" + maNV + "_Thang_" + month + "_Nam_" + year + ".pdf" };
        }

        public ActionResult DsChiTietThuong(int? month, int? year, int? maNV)
        {
            TempData.Keep();
            IQueryable<Ct_Thuong> ct_Thuongs;
            List<Ct_ThuongViewModel> ct_ThuongViewModels;
            ViewBag.month = month;
            ViewBag.year = year;
            ct_Thuongs = db.Ct_Thuong.Where(x => x.MaNhanVien == maNV && x.NgayThuong.Month == month && x.NgayThuong.Year == year);
            ct_ThuongViewModels = ct_Thuongs.ToList().ConvertAll<Ct_ThuongViewModel>(x => x);
            return View(ct_ThuongViewModels);
        }
    }
}