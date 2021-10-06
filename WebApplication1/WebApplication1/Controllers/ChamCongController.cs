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
using WebApplication1.Extensions;
using PagedList;
namespace WebApplication1.Controllers
{
    public class ChamCongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: ChamCong
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate, string MaPB, string loaiTimKiem, string tenTimKiem)
        {
            ViewBag.MaPB = new SelectList(db.PhongBans.OrderByDescending(x => x.TenPB), "MaPB", "TenPB", "12");
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<ChamCong> chamCongs;
            List<ChamCongViewModel> chamCongViewModel;
            string tenPB = "";
            TempData["loaiTimKiem"] = loaiTimKiem;
            TempData["tenTimKiem"] = tenTimKiem;
            TempData["page"] = page;
            TempData["fromDate"] = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd") != DateTime.MinValue.ToString("yyyy-MM-dd") ? Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd") : null;
            TempData["toDate"] = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd") != DateTime.MinValue.ToString("yyyy-MM-dd") ? Convert.ToDateTime(toDate).ToString("yyyy-MM-dd") : null; ;

            try
            {
                if (MaPB != null)
                {
                    tenPB = db.PhongBans.Where(x => x.MaPB.ToString() == MaPB).Select(x => x.TenPB).Single();
                }
                if (MaPB == "12")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        chamCongs = db.ChamCongs.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                    }
                    else if (fromDate == null && toDate == null)
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm theo phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm theo phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm theo phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay <= toDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay <= toDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.Ngay <= toDate).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    else
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    chamCongViewModel = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                    return View(chamCongViewModel.ToPagedList(pageNumber, pageSize));
                }
                else if(MaPB != null)
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        chamCongs = db.ChamCongs.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                    }
                    else if (fromDate == null && toDate == null)
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm theo phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm theo phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm theo phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay <= toDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay <= toDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.Ngay <= toDate && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    else
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", phòng ban: " + tenPB + ", mã nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            else
                                this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", phòng ban: " + tenPB + ", tên nhân viên:  " + tenTimKiem + "!", NotificationType.INFO);

                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                        else
                        {
                            this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", phòng ban: " + tenPB + "!", NotificationType.INFO);
                            chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                        }
                    }
                    chamCongViewModel = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                    return View(chamCongViewModel.ToPagedList(pageNumber, pageSize));
                }
                chamCongs = db.ChamCongs.Include(n => n.NhanVien).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                chamCongViewModel = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                return View(chamCongViewModel.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                chamCongs = db.ChamCongs.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderByDescending(x => x.Ngay).ThenBy(x => x.NhanVien.HoTen);
                chamCongViewModel = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                return View(chamCongViewModel.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: ChamCong/Details/5
        public ActionResult Details(int? id)
        {
            TempData.Keep();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
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
