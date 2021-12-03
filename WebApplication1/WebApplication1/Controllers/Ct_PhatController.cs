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
    public class Ct_PhatController : Controller
    {
        private QLNhanSuEntities db = QLNhanSuEntities.getInstance();

        // GET: Ct_Phat
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page, string trangThai, string submit)
        {
            IQueryable<Ct_Phat> ct_P;
            QLNhanSuEntities db = QLNhanSuEntities.getInstance();
            List<Ct_PhatViewModel> ct_PhatViewModels;
            TempData["loaiTimKiem"] = loaiTimKiem;
            TempData["tenTimKiem"] = tenTimKiem;
            TempData["page"] = page;
            TempData["trangThai"] = trangThai;
            TempData["submit"] = submit;

            if (submit != null)
            {
                if(submit == "timKiem")
                {
                    try
                    {
                        if (trangThai == "TatCa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                            }
                        }
                        else if (trangThai == "HoatDong")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }

                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {

                                ct_P = db.Ct_Phat.Where(x => x.TrangThai == true).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));

                            }
                        }
                        else if (trangThai == "VoHieuHoa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_P = db.Ct_Phat.Where(x => x.TrangThai != true).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                            }
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen).OrderBy(x => x.NhanVien.HoTen);
                            ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                            return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                        }
                    }
                    catch
                    {
                        this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                        ct_P = db.Ct_Phat.OrderBy(x => x.NhanVien.HoTen);
                        ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                        return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                    }
                }
                else
                {
                    try
                    {
                        if (trangThai == "TatCa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                            }
                        }
                        else if (trangThai == "HoatDong")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }

                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {

                                ct_P = db.Ct_Phat.Where(x => x.TrangThai == true).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));

                            }
                        }
                        else if (trangThai == "VoHieuHoa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                    ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                    return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_P = db.Ct_Phat.Where(x => x.TrangThai != true).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                            }
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgayPhat);
                            ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                            return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                        }
                    }
                    catch
                    {
                        this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                        ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderByDescending(x => x.NgaySua);
                        ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                        return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
                    }
                }
            }
            else
            {
                ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                ct_PhatViewModels = ct_P.ToList().ConvertAll<Ct_PhatViewModel>(x => x);
                return View("Index", ct_PhatViewModels.ToPagedList(page ?? 1, 10));
            }
        }

        // GET: Ct_Phat/Details/5
        public ActionResult Details(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ct_Phat ct_Phat = db.Ct_Phat.Find(id);
            if (ct_Phat == null)
            {
                return HttpNotFound();
            }
            Ct_PhatViewModel ct_PhatViewModel = ct_Phat;
            return View(ct_PhatViewModel);
        }

        // GET: Ct_Phat/Edit/5
        public ActionResult Edit(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ct_Phat ct_Phat = db.Ct_Phat.Find(id);
            if (ct_Phat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats.Where(x => x.TrangThai == true), "MaLoaiPhat", "TenLoaiPhat", ct_Phat.MaLoaiPhat);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Phat.MaNhanVien);
            Ct_PhatViewModel ct_PhatViewModel = ct_Phat;
            return View(ct_PhatViewModel);
        }

        // POST: Ct_Phat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ct_PhatViewModel ct_PhatViewModel)
        {
            if (ModelState.IsValid)
            {
                Ct_Phat ct_Phat = ct_PhatViewModel;
                db.Entry(ct_Phat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"], page = TempData["page"], trangThai = TempData["trangThai"], submit = TempData["submit"] });
            }
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats.Where(x => x.TrangThai == true), "MaLoaiPhat", "TenLoaiPhat", ct_PhatViewModel.MaLoaiPhat);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_PhatViewModel.MaNhanVien);
            return View(ct_PhatViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<Ct_PhatViewModel> ct_PhatViewModels)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = ct_PhatViewModels.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn chi tiết phạt để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in ct_PhatViewModels)
                {
                    if (item.IsChecked == true)
                    {
                        int maCTPhat = item.MaCTPhat;
                        Ct_Phat ct_Phat = db.Ct_Phat.Where(x => x.MaCTPhat == maCTPhat).SingleOrDefault();
                        if (ct_Phat != null)
                        {
                            ct_Phat.TrangThai = false;
                            if (Session["TenNhanVien"] == null)
                            {
                                ct_Phat.NguoiSua = "Ẩn danh";
                                ct_Phat.NgaySua = DateTime.Now;
                            }
                            else
                            {
                                ct_Phat.NguoiSua = Session["TenNhanVien"].ToString();
                                ct_Phat.NgaySua = DateTime.Now;
                            }
                            ct_Phat.NgaySua = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index", new { loaiTimKiem = TempData["loaiTimKiem"], tenTimKiem = TempData["tenTimKiem"], page = TempData["page"], trangThai = TempData["trangThai"], submit = TempData["submit"] });
            }
            catch
            {
                this.AddNotification("Không thể xóa vì chi tiết phạt này đã và đang được sử dụng!", NotificationType.ERROR);
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
