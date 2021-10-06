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
    public class XinNghiPhepController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: XinNghiPhep
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate)
        {
            IQueryable<DonNghiPhep> donNghiPheps;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            List<DonNghiPhepViewModel> donNghiPhepViewModels;
            string maNhanVien = Session["MaNhanVien"].ToString();
            try
            {
                if (fromDate > toDate)
                {
                    this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                    donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/"));
                    donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                    return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    if (fromDate == null && toDate == null)
                    {
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.MaNhanVien.ToString() == maNhanVien).OrderBy(x => x.NgayNghi);
                        donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                        return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.MaNhanVien.ToString() == maNhanVien).OrderBy(x => x.NgayNghi);
                        donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                        return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi <= toDate && x.MaNhanVien.ToString() == maNhanVien).OrderBy(x => x.NgayNghi);
                        donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                        return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.MaNhanVien.ToString() == maNhanVien).OrderBy(x => x.NgayNghi);
                        donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                        return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                donNghiPheps = db.DonNghiPheps.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/"));
                donNghiPhepViewModels = donNghiPheps.ToList().ConvertAll<DonNghiPhepViewModel>(x => x);
                return View(donNghiPhepViewModels.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: XinNghiPhep/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: XinNghiPhep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XinNghiPhep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonNghiPhepViewModel donNghiPhepViewModel)
        {
            DonNghiPhep donNghiPhep;
            DateTime ngayHomNay = DateTime.Today;
            int maNhanVien = Convert.ToInt32(Session["MaNhanVien"].ToString());
            if (ModelState.IsValid)
            {
                TimeSpan thoiGianKetThucCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 4).Select(x => x.GiaTri).Single();
                var dsDonNghiPhepHomNay = db.DonNghiPheps.Where(x => x.NgayNghi == DateTime.Today).ToList();
                if (DateTime.Now.TimeOfDay > thoiGianKetThucCaChieu && donNghiPhepViewModel.NgayNghi == ngayHomNay)
                {
                    this.AddNotification("Đã quá giờ quy định làm việc lúc " + thoiGianKetThucCaChieu+ " .Không thể tạo đơn xin nghỉ phép ngày hôm nay!", NotificationType.WARNING);
                    return View(donNghiPhepViewModel);
                }

                List<DonNghiPhep> donNghiPhepTrongNgay = db.DonNghiPheps.Where(x => x.MaNhanVien == maNhanVien && x.NgayNghi == donNghiPhepViewModel.NgayNghi).ToList();
                if (donNghiPhepTrongNgay == null)
                {

                    if (donNghiPhepViewModel.NgayNghi < ngayHomNay)
                    {
                        this.AddNotification("Vui lòng tạo đơn có ngày nghỉ bắt đầu từ hôm nay!", NotificationType.ERROR);
                        return View(donNghiPhepViewModel);
                    }
                    else
                    {
                        ChamCong chamCongHomNay = db.ChamCongs.Where(x => x.Ngay == ngayHomNay && x.MaNhanVien == maNhanVien).SingleOrDefault();
                        if (chamCongHomNay != null)
                        {
                            var batDatCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 1).Select(x => x.GiaTri).Single();
                            var ketThucCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 2).Select(x => x.GiaTri).Single();
                            if (chamCongHomNay.ThoiGianVao < ketThucCaSang)
                            {
                                if (donNghiPhepViewModel.CaNghi == "Ca sáng" || donNghiPhepViewModel.CaNghi == "Cả ngày")
                                {
                                    this.AddNotification("Vui lòng chọn ca nghỉ là buổi chiều. Vì bạn đã chấm công vào buổi sáng!", NotificationType.ERROR);
                                    return View(donNghiPhepViewModel);
                                }
                            }
                            else if (chamCongHomNay.ThoiGianVao >= ketThucCaSang)
                            {
                                if (donNghiPhepViewModel.CaNghi == "Ca chiều" || donNghiPhepViewModel.CaNghi == "Cả ngày")
                                {
                                    this.AddNotification("Vui lòng chọn ca nghỉ là buổi sáng. Vì bạn đã chấm công vào buổi chiều!", NotificationType.ERROR);
                                    return View(donNghiPhepViewModel);
                                }
                            }
                        }
                        donNghiPhepViewModel.MaNhanVien = Convert.ToInt32(Session["MaNhanVien"].ToString());
                        donNghiPhepViewModel.TrangThai = false;
                        donNghiPhepViewModel.NguoiDuyet = null;
                        donNghiPhep = donNghiPhepViewModel;
                        db.DonNghiPheps.Add(donNghiPhep);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in donNghiPhepTrongNgay)
                    {
                        if (item.CaNghi == "Cả ngày")
                        {
                            this.AddNotification("Không thể tạo thêm đơn nghỉ phép. Vì bạn đã tạo đơn xin nghỉ phép cả ngày!", NotificationType.ERROR);
                            return View(donNghiPhepViewModel);
                        }
                        else if (item.CaNghi == "Ca sáng")
                        {
                            if (donNghiPhepViewModel.CaNghi == "Ca sáng")
                            {
                                this.AddNotification("Không thể tạo thêm đơn nghỉ phép ca sáng. Vì bạn đã tạo đơn xin nghỉ phép ca sáng!", NotificationType.ERROR);
                                return View(donNghiPhepViewModel);
                            }
                            else if (donNghiPhepViewModel.CaNghi == "Cả ngày")
                            {
                                this.AddNotification("Không thể tạo thêm đơn nghỉ phép cả ngày. Vì bạn đã tạo đơn xin nghỉ phép ca sáng!", NotificationType.ERROR);
                                return View(donNghiPhepViewModel);
                            }
                        }
                        else if (item.CaNghi == "Ca chiều")
                        {
                            if (donNghiPhepViewModel.CaNghi == "Ca chiều")
                            {
                                this.AddNotification("Không thể tạo thêm đơn nghỉ phép ca chiều. Vì bạn đã tạo đơn xin nghỉ phép ca chiều!", NotificationType.ERROR);
                                return View(donNghiPhepViewModel);
                            }
                            else if (donNghiPhepViewModel.CaNghi == "Cả ngày")
                            {
                                this.AddNotification("Không thể tạo thêm đơn nghỉ phép cả ngày. Vì bạn đã tạo đơn xin nghỉ phép ca chiều!", NotificationType.ERROR);
                                return View(donNghiPhepViewModel);
                            }
                        }
                    }
                    donNghiPhepViewModel.MaNhanVien = Convert.ToInt32(Session["MaNhanVien"].ToString());
                    donNghiPhepViewModel.TrangThai = false;
                    donNghiPhepViewModel.NguoiDuyet = null;
                    donNghiPhep = donNghiPhepViewModel;
                    db.DonNghiPheps.Add(donNghiPhep);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(donNghiPhepViewModel);
        }

        // GET: XinNghiPhep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNghiPhep donNghiPhep = db.DonNghiPheps.Find(id);
            if (donNghiPhep == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", donNghiPhep.MaNhanVien);
            return View(donNghiPhep);
        }

        // POST: XinNghiPhep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonNghiPhep,MaNhanVien,NgayNghi,CaNghi,LyDo,TrangThai,NguoiDuyet")] DonNghiPhep donNghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donNghiPhep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", donNghiPhep.MaNhanVien);
            return View(donNghiPhep);
        }

        // GET: XinNghiPhep/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<DonNghiPhepViewModel> donNghiPhepViewModels)
        {
            try
            {
                var donNghiPhepChecked = donNghiPhepViewModels.Where(x => x.IsChecked == true).ToList();
                if (donNghiPhepChecked.Count == 0)
                {
                    this.AddNotification("Vui lòng chọn đơn nghỉ phép để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }

                var donNghiPhepDaDuyet = donNghiPhepViewModels.Where(x => x.TrangThai == true && x.IsChecked == true).FirstOrDefault();
                if (donNghiPhepDaDuyet != null)
                {
                    this.AddNotification("Vui lòng chỉ chọn đơn nghỉ phép chưa duyệt để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in donNghiPhepChecked)
                {
                    if (item.IsChecked == true)
                    {
                        DonNghiPhep itemDeleted = db.DonNghiPheps.Find(item.MaDonNghiPhep);
                        db.DonNghiPheps.Remove(itemDeleted);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

                this.AddNotification("Không thể xóa. Vui lòng thử lại sau!", NotificationType.ERROR);
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
