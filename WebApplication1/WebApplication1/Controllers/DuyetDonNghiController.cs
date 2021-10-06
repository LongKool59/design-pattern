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
    public class DuyetDonNghiController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: DuyetDonNghi
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate, string trangThai)
        {
            TempData["page"] = page;
            TempData["fromDate"] = fromDate;
            TempData["toDate"] = toDate;
            TempData["trangThai"] = trangThai;

            IQueryable<DonNghiPhep> donNghiPheps;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            string tenTrangThai = "";
            List<DonNghiPhepViewModel> donNghiPhepViewModels;
            try
            {
                if (trangThai == "TatCa")
                {
                    tenTrangThai = "Tất cả";
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/"));
                    }
                    else if (fromDate == null && toDate == null)
                    {
                        this.AddNotification("Kết quả tìm kiếm theo trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi <= toDate).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else
                    {
                        this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }

                }
                else if (trangThai == "HoatDong")
                {
                    tenTrangThai = "Đã duyệt";
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/"));
                    }
                    else if (fromDate == null && toDate == null)
                    {
                        this.AddNotification("Kết quả tìm kiếm theo trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.TrangThai == true).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.TrangThai == true).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi <= toDate && x.TrangThai == true).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else
                    {
                        this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.TrangThai == true).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }

                }
                else if (trangThai == "VoHieuHoa")
                {
                    tenTrangThai = "Chưa duyệt";
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/"));
                    }
                    else if (fromDate == null && toDate == null)
                    {
                        this.AddNotification("Kết quả tìm kiếm theo trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.TrangThai == false).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        this.AddNotification("Kết quả tìm kiếm từ " + fromDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.TrangThai == false).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        this.AddNotification("Kết quả tìm kiếm đến " + toDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi <= toDate && x.TrangThai == false).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }
                    else
                    {
                        this.AddNotification("Kết quả tìm kiếm từ " + fromDate + " đến " + toDate + ", trạng thái: " + tenTrangThai + "!", NotificationType.INFO);
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.TrangThai == false).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                    }

                }
                else
                {
                    donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).OrderByDescending(x => x.NgayNghi).ThenBy(x => x.MaNhanVien);
                }
                donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/"));
                donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: DuyetDonNghi/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.page = TempData["page"];
            ViewBag.fromDate = Convert.ToDateTime(TempData["fromDate"]).ToString("yyyy-MM-dd") != DateTime.MinValue.ToString("yyyy-MM-dd") ? Convert.ToDateTime(TempData["fromDate"]).ToString("yyyy-MM-dd") : null;
            ViewBag.toDate = Convert.ToDateTime(TempData["toDate"]).ToString("yyyy-MM-dd") != DateTime.MinValue.ToString("yyyy-MM-dd") ? Convert.ToDateTime(TempData["toDate"]).ToString("yyyy-MM-dd") : null;
            ViewBag.trangThai = TempData["trangThai"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNghiPhep donNghiPhep = db.DonNghiPheps.Find(id);
            if (donNghiPhep == null)
            {
                return HttpNotFound();
            }
            DonNghiPhepViewModel donNghiPhepViewModel = donNghiPhep;
            return View(donNghiPhepViewModel);
        }

        public ActionResult XuLyDonNghiPhep(List<DonNghiPhepViewModel> donNghiPhepViewModels, string submit)
        {
            try
            {
                var fromDate = Convert.ToDateTime(TempData["fromDate"]).ToString("yyyy-MM-dd") != DateTime.MinValue.ToString("yyyy-MM-dd") ? Convert.ToDateTime(TempData["fromDate"]).ToString("yyyy-MM-dd") : null;
                var toDate = Convert.ToDateTime(TempData["toDate"]).ToString("yyyy-MM-dd") != DateTime.MinValue.ToString("yyyy-MM-dd") ? Convert.ToDateTime(TempData["toDate"]).ToString("yyyy-MM-dd") : null;
                TimeSpan thoiGianTaoDSNVNghi = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 5).Select(x => x.GiaTri).Single();
                int maNhanVien = Convert.ToInt32(Session["MaNhanVien"].ToString());
                var nhanVien = db.NhanViens.Where(x => x.MaNhanVien == maNhanVien).Single();
                if (submit == "duyetDon")
                {
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var checkIsChecked = donNghiPhepViewModels.Where(x => x.IsChecked == true).ToList();
                    if (checkIsChecked.Count == 0)
                    {
                        this.AddNotification("Vui lòng chọn đơn để duyệt!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    var donChuaDuyet = checkIsChecked.Where(x => x.TrangThai == false).ToList();
                    if (donChuaDuyet.Count == 0)
                    {
                        this.AddNotification("Vui lòng chỉ chọn những đơn chưa duyệt để duyệt!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    var beginFromToday = checkIsChecked.Where(x => x.NgayNghi >= DateTime.Today).ToList();
                    if (beginFromToday.Count == 0)
                    {
                        this.AddNotification("Vui lòng chọn đơn có ngày nghỉ bắt đầu từ hôm nay để duyệt!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    var dsDonNghiPhepHomNay = beginFromToday.Where(x => x.NgayNghi == DateTime.Today).ToList();
                    if (DateTime.Now.TimeOfDay > thoiGianTaoDSNVNghi && dsDonNghiPhepHomNay.Count > 0)
                    {
                        this.AddNotification("Đã quá giờ quy định hệ thống thêm nhân viên vào danh sách nghỉ lúc " + thoiGianTaoDSNVNghi + " .Không thể duyệt đơn cho nhân viên nghỉ hôm nay!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    foreach (var item in beginFromToday)
                    {
                        DonNghiPhep donNghiPhep = db.DonNghiPheps.Where(x => x.MaDonNghiPhep == item.MaDonNghiPhep).SingleOrDefault();
                        if (donNghiPhep != null)
                        {
                            donNghiPhep.TrangThai = true;
                            donNghiPhep.NguoiDuyet = nhanVien.HoTen;
                            db.SaveChanges();
                        }
                    }

                    this.AddNotification("Duyệt đơn thành công!", NotificationType.SUCCESS);
                    return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                }
                else
                {
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var checkIsChecked = donNghiPhepViewModels.Where(x => x.IsChecked == true).ToList();
                    if (checkIsChecked.Count == 0)
                    {
                        this.AddNotification("Vui lòng chọn đơn để bỏ duyệt!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    var donDaDuyet = checkIsChecked.Where(x => x.TrangThai == true).ToList();
                    if (donDaDuyet.Count == 0)
                    {
                        this.AddNotification("Vui lòng chỉ chọn những đơn đã duyệt để bỏ duyệt!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    var beginFromToday = donDaDuyet.Where(x => x.NgayNghi >= DateTime.Today).ToList();
                    if (beginFromToday.Count == 0)
                    {
                        this.AddNotification("Vui lòng đơn có ngày nghỉ bắt đầu từ hôm nay để bỏ duyệt!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    var dsDonNghiPhepHomNay = beginFromToday.Where(x => x.NgayNghi == DateTime.Today).ToList();
                    if (DateTime.Now.TimeOfDay > thoiGianTaoDSNVNghi && dsDonNghiPhepHomNay.Count > 0)
                    {
                        this.AddNotification("Đã quá giờ quy định hệ thống thêm nhân viên vào danh sách nghỉ lúc " + thoiGianTaoDSNVNghi + " .Không thể bỏ duyệt đơn cho nhân viên nghỉ hôm nay!", NotificationType.WARNING);
                        return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                    }

                    foreach (var item in beginFromToday)
                    {
                        DonNghiPhep donNghiPhep = db.DonNghiPheps.Where(x => x.MaDonNghiPhep == item.MaDonNghiPhep).SingleOrDefault();
                        if (donNghiPhep != null)
                        {
                            donNghiPhep.TrangThai = false;
                            donNghiPhep.NguoiDuyet = "";
                            db.SaveChanges();
                        }
                    }

                    this.AddNotification("Bỏ duyệt đơn thành công!", NotificationType.SUCCESS);
                    return RedirectToAction("Index", new { page = TempData["page"], fromDate = fromDate, toDate = toDate, trangThai = TempData["trangThai"] });
                }
            }
            catch
            {
                this.AddNotification("Xảy ra lỗi. Vui lòng thực hiện lại thao tác!", NotificationType.ERROR);
                return RedirectToAction("Index", new { page = TempData["page"], fromDate = TempData["fromDate"], toDate = TempData["toDate"], trangThai = TempData["trangThai"] });
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
