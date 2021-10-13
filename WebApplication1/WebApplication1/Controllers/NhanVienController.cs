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
using System.Net.Mail;

namespace WebApplication1.Controllers
{
    public class NhanVienController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: NhanVien
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page, string trangThai)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            IQueryable<NhanVien> nhanViens;
            QLNhanSuEntities db = new QLNhanSuEntities();
            List<NhanVienViewModel> nhanVienViewModels;
            try
            {
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.HoTen.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        nhanViens = db.NhanViens.Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                        nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                        return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }

                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.HoTen.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {

                        nhanViens = db.NhanViens.Where(x => x.TrangThai == true).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                        nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                        return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));

                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.HoTen.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                            return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        nhanViens = db.NhanViens.Where(x => x.TrangThai != true).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                        nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                        return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    nhanViens = db.NhanViens.Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen).OrderBy(x => x.HoTen);
                    nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                    return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                nhanViens = db.NhanViens.Where(x => x.MaNhanVien.ToString().Equals("+-*/*-+-*/*-+")).Include(c => c.ChucVu).OrderBy(x => x.HoTen).OrderBy(x => x.HoTen);
                nhanVienViewModels = nhanViens.ToList().ConvertAll<NhanVienViewModel>(x => x);
                return View("Index", nhanVienViewModels.ToPagedList(pageNumber, pageSize));
            }
        }


        // GET: NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            NhanVienViewModel nhanVienViewModel = nhanVien;
            return View(nhanVienViewModel);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(db.ChucVus.Where(x => x.TrangThai == true), "MaChucVu", "TenChucVu");
            ViewBag.MaPB = new SelectList(db.PhongBans.Where(x => x.MaPB != 12), "MaPB", "TenPB");
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK");

            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(x => !x.MaQuyen.Equals(3)), "MaQuyen", "TenQuyen");
            NhanVienViewModel nhanVienViewModel = new NhanVienViewModel();
            return View(nhanVienViewModel);
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVienViewModel nhanVienViewModel, FormCollection form)
        {
            NhanVien nhanVien;
            if (ModelState.IsValid)
            {
                if (form["LuongCoBan"] == "" || form["LuongCoBan"] == null)
                {
                    ViewBag.MaChucVu = new SelectList(db.ChucVus.Where(x => x.TrangThai == true), "MaChucVu", "TenChucVu", nhanVienViewModel.MaChucVu);
                    ViewBag.MaPB = new SelectList(db.PhongBans.Where(x => x.MaPB != 12), "MaPB", "TenPB", nhanVienViewModel.MaPB);
                    ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVienViewModel.MaNhanVien);

                    ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(x => !x.MaQuyen.Equals(3)), "MaQuyen", "TenQuyen");
                    this.AddNotification("Lương cơ bản không được trống!", NotificationType.ERROR);
                    return View(nhanVienViewModel);
                }
                else
                {
                    nhanVien = nhanVienViewModel;
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                    var generator = new RandomGenerator();
                    int tenTaiKhoanRandom = generator.RandomNumber(100000, 999999);

                    var luongCB = db.LuongCoBans.Where(x => x.MaNhanVien == nhanVien.MaNhanVien).SingleOrDefault();
                    if (luongCB == null)
                    {
                        var lCB = new LuongCoBan();
                        lCB.MaNhanVien = nhanVien.MaNhanVien;
                        lCB.TienLuongCoBan = Convert.ToInt32(form["LuongCoBan"]);
                        lCB.TrangThai = true;
                        lCB.NguoiSua = nhanVien.NguoiSua;
                        lCB.NgaySua = nhanVien.NgaySua;
                        db.LuongCoBans.Add(lCB);
                        db.SaveChanges();
                    }
                    var taiKhoan = db.TaiKhoans.Where(x => x.MaNhanVien == nhanVien.MaNhanVien).SingleOrDefault();
                    if (taiKhoan == null)
                    {
                        var newTaiKhoan = new TaiKhoan();
                        newTaiKhoan.TenTK = nhanVien.MaNhanVien + tenTaiKhoanRandom.ToString();
                        newTaiKhoan.MaNhanVien = nhanVien.MaNhanVien;
                        newTaiKhoan.MatKhau = "a123456";
                        newTaiKhoan.MaQuyen = Convert.ToInt32(form["MaQuyen"]);

                        GuiTaiKhoanQuaEmail(nhanVien.Email, newTaiKhoan.TenTK, newTaiKhoan.MatKhau);
                        db.TaiKhoans.Add(newTaiKhoan);
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus.Where(x => x.TrangThai == true), "MaChucVu", "TenChucVu", nhanVienViewModel.MaChucVu);
            ViewBag.MaPB = new SelectList(db.PhongBans.Where(x => x.MaPB != 12), "MaPB", "TenPB", nhanVienViewModel.MaPB);
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVienViewModel.MaNhanVien);
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(x => !x.MaQuyen.Equals(3)), "MaQuyen", "TenQuyen");
            return View(nhanVienViewModel);
        }

        //Gửi tài khoản và mật khẩu đăng nhập đến mail của nhân viên
        [NonAction]
        public void GuiTaiKhoanQuaEmail(string email, string tenTaiKhoan, string matKhau)
        {
            var fromEmail = new MailAddress("democnpmnc@gmail.com", "Long Nguyen");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "democnpmnc123";
            string subject = "Chào mừng bạn đến với công ty DEV";
            string body = "Chào nhân viên mới. Sau đây là tài khoản để bạn đăng nhập vào website của công ty <br /> Tên tài khoản: " + tenTaiKhoan + " <br />Mật khẩu: " + matKhau + " <br /> Vui lòng đổi mật khẩu sau khi đăng nhập";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            }) smtp.Send(message);
        }
        // GET: NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus.Where(x => x.TrangThai == true), "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPB = new SelectList(db.PhongBans.Where(x => x.MaPB != 12), "MaPB", "TenPB", nhanVien.MaPB);
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVien.MaNhanVien);
            NhanVienViewModel nhanVienViewModel = nhanVien;
            return View(nhanVienViewModel);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVienViewModel nhanVienViewModel)
        {
            NhanVien nhanVien;
            if (ModelState.IsValid)
            {
                nhanVien = nhanVienViewModel;
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus.Where(x => x.TrangThai == true), "MaChucVu", "TenChucVu", nhanVienViewModel.MaChucVu);
            ViewBag.MaPB = new SelectList(db.PhongBans.Where(x => x.MaPB != 12), "MaPB", "TenPB", nhanVienViewModel.MaPB);
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVienViewModel.MaNhanVien);
            return View(nhanVienViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<NhanVienViewModel> nhanVienViewModels, string submit)
        {
            try
            {
                if (submit == "xoaNV")
                {
                    try
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        var checkIsChecked = nhanVienViewModels.Where(x => x.IsChecked == true).FirstOrDefault();
                        if (checkIsChecked == null)
                        {
                            this.AddNotification("Vui lòng chọn nhân viên để xóa!", NotificationType.ERROR);
                            return RedirectToAction("Index");
                        }
                        foreach (var item in nhanVienViewModels)
                        {
                            if (item.IsChecked == true)
                            {
                                int maNhanVien = item.MaNhanVien;
                                NhanVien nhanVien = db.NhanViens.Where(x => x.MaNhanVien == maNhanVien).SingleOrDefault();
                                if (nhanVien != null)
                                {
                                    nhanVien.TrangThai = false;
                                    db.SaveChanges();
                                }
                            }
                        }

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        this.AddNotification("Không thể xóa vì thông tin nhân viên đang được sử dụng!", NotificationType.ERROR);
                        return RedirectToAction("Index");
                    }
                }
                else if (submit == "themThuong")
                {
                    try
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;

                        List<NhanVienViewModel> listNV = new List<NhanVienViewModel>();
                        var checkIsChecked = nhanVienViewModels.Where(x => x.IsChecked == true);
                        var checkTrangThai = checkIsChecked.Where(x => x.TrangThai == false).FirstOrDefault();
                        if (checkIsChecked.Count() == 0)
                        {
                            this.AddNotification("Vui lòng chọn nhân viên để thêm thưởng!", NotificationType.ERROR);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            if (checkTrangThai != null)
                            {
                                this.AddNotification("Không thể thêm thưởng cho nhân viên nghỉ việc!", NotificationType.ERROR);
                                return RedirectToAction("Index");
                            }
                            foreach (var item in checkIsChecked)
                            {
                                if (item.TrangThai == true)
                                {
                                    listNV.Add(item);
                                }
                            }

                        }
                        TempData["listNhanVien"] = listNV;
                        return RedirectToAction("ThemThuongNhanVien");
                    }
                    catch
                    {
                        this.AddNotification("Không thể thêm thưởng cho nhân viên... Vui lòng thử lại!", NotificationType.ERROR);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    try
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;

                        List<NhanVienViewModel> listNV = new List<NhanVienViewModel>();
                        var checkIsChecked = nhanVienViewModels.Where(x => x.IsChecked == true).ToList();
                        var checkTrangThai = checkIsChecked.Where(x => x.TrangThai == false).FirstOrDefault();
                        if (checkIsChecked.Count == 0)
                        {
                            this.AddNotification("Vui lòng chọn nhân viên để thêm phạt!", NotificationType.ERROR);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var item in checkIsChecked)
                            {
                                if (item.TrangThai == true)
                                {
                                    listNV.Add(item);
                                }
                            }
                            if (checkTrangThai != null)
                            {
                                this.AddNotification("Không thể thêm phạt cho nhân viên nghỉ việc!", NotificationType.ERROR);
                                return RedirectToAction("Index");
                            }
                        }
                        TempData["listNhanVien"] = listNV;
                        return RedirectToAction("ThemPhatNhanVien");
                    }
                    catch
                    {
                        this.AddNotification("Không thể thêm phạt cho nhân viên... Vui lòng thử lại!", NotificationType.ERROR);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                this.AddNotification("Xảy ra lỗi. Vui lòng thực hiện lại thao tác!", NotificationType.ERROR);
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

        public ActionResult ThemThuongNhanVien()
        {
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs.Where(x => x.TrangThai == true), "MaLoaiThuong", "TenLoaiThuong");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemThuongNhanVien(FormCollection form)
        {
            var listNhanVien = TempData["listNhanVien"] as List<NhanVienViewModel>;
            foreach (var item in listNhanVien)
            {
                if (item.IsChecked == true)
                {
                    var chitietThuong = new Ct_Thuong();
                    chitietThuong.MaNhanVien = item.MaNhanVien;
                    chitietThuong.MaLoaiThuong = Convert.ToInt32(form["MaLoaiThuong"]);
                    chitietThuong.TrangThai = true;
                    chitietThuong.NguoiThuong = form["NguoiSua"].ToString();
                    chitietThuong.NgayThuong = DateTime.Now;
                    chitietThuong.NguoiSua = form["NguoiSua"].ToString();
                    chitietThuong.NgaySua = DateTime.Now;
                    db.Ct_Thuong.Add(chitietThuong);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult ThemPhatNhanVien()
        {
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats.Where(x => x.TrangThai == true && !x.TenLoaiPhat.Equals("Nghỉ", StringComparison.OrdinalIgnoreCase) && !x.TenLoaiPhat.Equals("Đi trễ", StringComparison.OrdinalIgnoreCase)), "MaLoaiPhat", "TenLoaiPhat");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemPhatNhanVien(FormCollection form)
        {
            var listNhanVien = TempData["listNhanVien"] as List<NhanVienViewModel>;
            foreach (var item in listNhanVien)
            {
                if (item.IsChecked == true)
                {
                    var chitietPhat = new Ct_Phat();
                    chitietPhat.MaNhanVien = item.MaNhanVien;
                    chitietPhat.MaLoaiPhat = Convert.ToInt32(form["MaLoaiPhat"]);
                    chitietPhat.TrangThai = true;
                    chitietPhat.NguoiSua = form["NguoiSua"].ToString();
                    chitietPhat.NgaySua = DateTime.Now;
                    chitietPhat.NguoiPhat = form["NguoiSua"].ToString();
                    chitietPhat.NgayPhat = DateTime.Now;
                    db.Ct_Phat.Add(chitietPhat);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
    public class RandomGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
