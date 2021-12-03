using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentScheduler;
using WebApplication1.Models;
using System.Data.Entity.Validation;
using System.Dynamic;
namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        QLNhanSuEntities ql = QLNhanSuEntities.getInstance();

        protected void Application_Start()
        {
            JobManager.Initialize(new MyRegistry());

            TinhLuongThangChoNhanVien();
            TaoDSNhanVienNghiTrongNgay();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        
        public void TinhLuongThangChoNhanVien()
        {
            DateTime now = DateTime.Now;
            int month, year;
            if (now.Month == 1)
            {
                month = 12;
                year = now.Year - 1;
            }
            else
            {
                month = now.Month - 1;
                year = now.Year;
            }
            var day = DateTime.DaysInMonth(year, month);
            DateTime ngayCuoiThang = new DateTime(year, month, day);
            var luong = ql.LuongThangs.Where(s => s.ThangNam.Month.ToString() == month.ToString() && s.ThangNam.Year.ToString() == year.ToString()).FirstOrDefault();
            if (luong == null)
            {
                var nhanvien = ql.NhanViens.Where(s => s.TrangThai == true && s.MaNhanVien != 1001);
                foreach (var nv in nhanvien.ToList())
                {
                    PhatNhanVienNghi(nv, month, year, ngayCuoiThang);
                    PhatNhanVienDiTre(nv, month, year, ngayCuoiThang);

                    int gtthuong = 0;
                    int gtphat = 0;
                    int giolam = 0;
                    int giotangca = 0;
                    var thuong = ql.Ct_Thuong.Where(s => s.NgaySua.Month == month && s.NgaySua.Year == year && s.MaNhanVien == nv.MaNhanVien);
                    foreach (var t in thuong)
                    {
                        var giatrithuong = ql.LoaiThuongs.Where(s => s.MaLoaiThuong == t.MaLoaiThuong).SingleOrDefault();
                        gtthuong = gtthuong + giatrithuong.GiaTri;
                    }
                    var phat = ql.Ct_Phat.Where(s => s.NgaySua.Month == month && s.NgaySua.Year == year && s.MaNhanVien == nv.MaNhanVien);
                    foreach (var t in phat)
                    {
                        var giatriphat = ql.LoaiPhats.Where(s => s.MaLoaiPhat == t.MaLoaiPhat).SingleOrDefault();
                        gtphat = gtphat + giatriphat.GiaTri;
                    }
                    var cc = ql.ChamCongs.Where(s => s.MaNhanVien == nv.MaNhanVien && s.Ngay.Month.ToString() == month.ToString() && s.Ngay.Year.ToString() == year.ToString() && s.TrangThai != null);
                    if (cc.Count() > 0)
                    {
                        foreach (var c in cc)
                        {
                            if (c.ThoiGianLamViec != null)
                            {
                                giolam = (int)(giolam + c.ThoiGianLamViec);
                                giotangca = (int)(giotangca + c.ThoiGianTangCa);
                            }

                        }
                    }
                    var luongcoban = ql.LuongCoBans.Where(s => s.MaNhanVien == nv.MaNhanVien && s.TrangThai == true).SingleOrDefault();
                    if (luongcoban != null)
                    {
                        LuongThang l = new LuongThang();
                        l.MaLuongCoBan = luongcoban.MaLuongCoBan;
                        l.ThangNam = ngayCuoiThang;
                        l.TongGioLamViec = giolam;
                        l.TongGioTangCa = giotangca;
                        l.TongThuong = gtthuong;
                        l.TongPhat = gtphat;
                        l.HeSoLuong = luongcoban.NhanVien.ChucVu.HeSoChucVu;
                        l.PhuCap = luongcoban.NhanVien.ChucVu.PhuCap;
                        ql.LuongThangs.Add(l);
                    }
                }
                ql.SaveChanges();
            }
        }

        public void PhatNhanVienNghi(NhanVien nhanVien, int month, int year, DateTime ngayCuoiThang)
        {
            var soNgayNghiPhepToiDa = ql.QuyDinhKhacs.Where(x => x.MaQuyDinh == 1).Select(x => x.GiaTri).Single();
            var soNgayNghiKhongPhepToiDa = ql.QuyDinhKhacs.Where(x => x.MaQuyDinh == 2).Select(x => x.GiaTri).Single();
            var soNgayNghiCoPhepCuaNhanVien = ql.Nghis.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.Phep == true && x.NgayNghi.Month == month && x.NgayNghi.Year == year);
            var soNgayNghiKhongPhepCuaNhanVien = ql.Nghis.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.Phep == false && x.NgayNghi.Month == month && x.NgayNghi.Year == year);

            if (soNgayNghiCoPhepCuaNhanVien.Count() > soNgayNghiPhepToiDa)
            {
                ThemPhatNghi(nhanVien, ngayCuoiThang);
            }

            if (soNgayNghiKhongPhepCuaNhanVien.Count() > soNgayNghiKhongPhepToiDa)
            {
                ThemPhatNghi(nhanVien, ngayCuoiThang);
            }

        }
        public void ThemPhatNghi(NhanVien nhanVien, DateTime ngayCuoiThang)
        {
            var tenPhat = ql.LoaiPhats.Where(s => s.TenLoaiPhat == "Nghỉ" && s.TrangThai == true).FirstOrDefault();
            if (tenPhat != null)
            {
                Ct_Phat phat = new Ct_Phat();
                phat.MaNhanVien = nhanVien.MaNhanVien;
                phat.MaLoaiPhat = tenPhat.MaLoaiPhat;
                phat.NgayPhat = ngayCuoiThang;
                phat.NguoiPhat = "Hệ thống";
                phat.NguoiSua = "Hệ thống";
                phat.NgaySua = ngayCuoiThang;
                phat.TrangThai = true;
                ql.Ct_Phat.Add(phat);
                ql.SaveChanges();
            }
        } 

        public void PhatNhanVienDiTre(NhanVien nhanVien, int month, int year, DateTime ngayCuoiThang)
        {
            var soLanDiTreToiDa = ql.QuyDinhKhacs.Where(x => x.MaQuyDinh == 3).Select(x => x.GiaTri).Single();
            var soLanDiTreCuaNhanVien = ql.ChamCongs.Where(x => x.MaNhanVien == nhanVien.MaNhanVien &&x.TrangThai == "Đi trễ" && x.Ngay.Month == month && x.Ngay.Year == year);
            var a = soLanDiTreCuaNhanVien.Count();
            if (soLanDiTreCuaNhanVien.Count() > soLanDiTreToiDa)
            {
                var tenPhat = ql.LoaiPhats.Where(s => s.TenLoaiPhat == "Đi trễ" && s.TrangThai == true).FirstOrDefault();
                if (tenPhat != null)
                {
                    Ct_Phat phat = new Ct_Phat();
                    phat.MaNhanVien = nhanVien.MaNhanVien;
                    phat.MaLoaiPhat = tenPhat.MaLoaiPhat;
                    phat.NgayPhat = ngayCuoiThang;
                    phat.NguoiPhat = "Hệ thống";
                    phat.NguoiSua = "Hệ thống";
                    phat.NgaySua = ngayCuoiThang;
                    phat.TrangThai = true;
                    ql.Ct_Phat.Add(phat);
                    ql.SaveChanges();
                }
            }
        }

        public void TaoDSNhanVienNghiTrongNgay()
        {
            TimeSpan thoiGianKetThucCaSang = ql.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 2).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianBatDauCaChieu = ql.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 3).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianKetThucCaChieu = ql.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 4).Select(x => x.GiaTri).Single();
            string nghiCaSangCoLyDo = "Nghỉ ca sáng - Lý do: ";
            string nghiCaChieuCoLyDo = "Nghỉ ca chiều - Lý do: ";
            string nghiCaNgayCoLyDo = "Nghỉ cả ngày - Lý do: ";
            string nghiCaSangKhongLyDo = "Nghỉ ca sáng";
            string nghiCaChieuKhongLyDo = "Nghỉ ca chiều";
            string nghiCaNgayKhongLyDo = "Nghỉ cả ngày";
            string caSang = "Ca sáng";
            string caChieu = "Ca chiều";
            string caNgay = "Cả ngày";
            DateTime homNay = DateTime.Today;

            var dsNhanVienNghi = ql.Nghis.Where(x => x.NgayNghi == DateTime.Today).ToList();
            if (dsNhanVienNghi.Count == 0)
            {
                if (homNay.DayOfWeek != DayOfWeek.Saturday && homNay.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (DateTime.Now.TimeOfDay > thoiGianKetThucCaChieu)
                    {
                        var dsNhanVien = ql.NhanViens.Where(x => x.TrangThai == true && x.MaNhanVien != 1001 && x.TaiKhoan.PhanQuyen.MaQuyen != 4).ToList();
                        foreach (var nhanVien in dsNhanVien)
                        {
                            var chamCongTrongNgay = ql.ChamCongs.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.Ngay == DateTime.Today).SingleOrDefault();
                            Nghi nhanVienNghi = new Nghi();

                            if (chamCongTrongNgay == null)
                            {

                                nhanVienNghi.MaNhanVien = nhanVien.MaNhanVien;
                                nhanVienNghi.NgayNghi = DateTime.Today;
                                nhanVienNghi.NgaySua = DateTime.Now;

                                var dsDonNghiPhepTrongNgayCuaNhanVien = ql.DonNghiPheps.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.NgayNghi == DateTime.Today && x.TrangThai == true).ToList();
                                if (dsDonNghiPhepTrongNgayCuaNhanVien.Count == 0)
                                {
                                    nhanVienNghi.Phep = false;
                                    nhanVienNghi.GhiChu = nghiCaNgayKhongLyDo;
                                }
                                else if (dsDonNghiPhepTrongNgayCuaNhanVien.Count == 1)
                                {
                                    foreach (var donNghiPhep in dsDonNghiPhepTrongNgayCuaNhanVien)
                                    {
                                        nhanVienNghi.NguoiDuyet = donNghiPhep.NguoiDuyet;
                                        if (donNghiPhep.CaNghi == caSang)
                                        {
                                            nhanVienNghi.Phep = false;
                                            nhanVienNghi.GhiChu = nghiCaSangCoLyDo + donNghiPhep.LyDo + " + " + nghiCaChieuKhongLyDo;
                                        }
                                        else if (donNghiPhep.CaNghi == caChieu)
                                        {
                                            nhanVienNghi.Phep = false;
                                            nhanVienNghi.GhiChu = nghiCaChieuCoLyDo + donNghiPhep.LyDo + " + " + nghiCaSangKhongLyDo;
                                        }
                                        else
                                        {
                                            nhanVienNghi.Phep = true;
                                            nhanVienNghi.GhiChu = nghiCaNgayCoLyDo + donNghiPhep.LyDo;
                                        }
                                    }
                                }
                                else
                                {
                                    string lyDoCaSang = "";
                                    string lyDoCaChieu = "";
                                    string nguoiDuyetCaSang = "";
                                    string nguoiDuyetCaChieu = "";

                                    foreach (var donNghiPhep in dsDonNghiPhepTrongNgayCuaNhanVien)
                                    {
                                        if (donNghiPhep.CaNghi == caSang)
                                        {
                                            lyDoCaSang = donNghiPhep.LyDo;
                                            nguoiDuyetCaSang = donNghiPhep.NguoiDuyet;
                                        }
                                        else
                                        {
                                            lyDoCaChieu = donNghiPhep.LyDo;
                                            nguoiDuyetCaChieu = donNghiPhep.NguoiDuyet;
                                        }
                                    }

                                    nhanVienNghi.Phep = true;
                                    nhanVienNghi.NguoiDuyet = nguoiDuyetCaSang + " + " + nguoiDuyetCaChieu;
                                    nhanVienNghi.GhiChu = nghiCaSangCoLyDo + lyDoCaSang + " + " + nghiCaChieuCoLyDo + lyDoCaChieu;
                                }
                            }
                            else
                            {
                                //var dsDonNghiPhepTrongNgayCuaNhanVien = ql.DonNghiPheps.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.NgayNghi == DateTime.Today && x.TrangThai == true).FirstOrDefault();
                                if (chamCongTrongNgay.ThoiGianVao <= thoiGianKetThucCaSang && chamCongTrongNgay.ThoiGianRa >= thoiGianBatDauCaChieu)
                                {
                                    continue;
                                }

                                nhanVienNghi.MaNhanVien = nhanVien.MaNhanVien;
                                nhanVienNghi.NgayNghi = DateTime.Today;
                                nhanVienNghi.NgaySua = DateTime.Now;
                                var donNghiPhepCaSangCuaNhanVien = ql.DonNghiPheps.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.NgayNghi == DateTime.Today && x.TrangThai == true && x.CaNghi == caSang).FirstOrDefault();
                                var donNghiPhepCaChieuCuaNhanVien = ql.DonNghiPheps.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.NgayNghi == DateTime.Today && x.TrangThai == true && x.CaNghi == caChieu).FirstOrDefault();
                                var donNghiPhepCaNgayCuaNhanVien = ql.DonNghiPheps.Where(x => x.MaNhanVien == nhanVien.MaNhanVien && x.NgayNghi == DateTime.Today && x.TrangThai == true && x.CaNghi == caNgay).FirstOrDefault();

                                if (chamCongTrongNgay.ThoiGianRa >= thoiGianKetThucCaSang && chamCongTrongNgay.ThoiGianRa < thoiGianBatDauCaChieu)
                                {

                                    if (donNghiPhepCaChieuCuaNhanVien == null)
                                    {
                                        if (donNghiPhepCaNgayCuaNhanVien == null)
                                        {
                                            nhanVienNghi.Phep = false;
                                            nhanVienNghi.GhiChu = nghiCaChieuKhongLyDo;
                                        }
                                        else
                                        {
                                            nhanVienNghi.Phep = true;
                                            nhanVienNghi.GhiChu = nghiCaChieuCoLyDo + donNghiPhepCaNgayCuaNhanVien.LyDo;
                                            nhanVienNghi.NguoiDuyet = donNghiPhepCaNgayCuaNhanVien.NguoiDuyet;
                                        }
                                    }
                                    else
                                    {
                                        nhanVienNghi.Phep = true;
                                        nhanVienNghi.GhiChu = nghiCaChieuCoLyDo + donNghiPhepCaChieuCuaNhanVien.LyDo;
                                        nhanVienNghi.NguoiDuyet = donNghiPhepCaChieuCuaNhanVien.NguoiDuyet;
                                    }
                                }
                                else if (chamCongTrongNgay.ThoiGianVao >= thoiGianKetThucCaSang && chamCongTrongNgay.ThoiGianVao < thoiGianKetThucCaChieu)
                                {

                                    if (donNghiPhepCaSangCuaNhanVien == null)
                                    {
                                        if (donNghiPhepCaNgayCuaNhanVien == null)
                                        {
                                            nhanVienNghi.Phep = false;
                                            nhanVienNghi.GhiChu = nghiCaSangKhongLyDo;
                                        }
                                        else
                                        {
                                            nhanVienNghi.Phep = true;
                                            nhanVienNghi.GhiChu = nghiCaSangCoLyDo + donNghiPhepCaNgayCuaNhanVien.LyDo;
                                            nhanVienNghi.NguoiDuyet = donNghiPhepCaNgayCuaNhanVien.NguoiDuyet;
                                        }

                                    }
                                    else
                                    {
                                        nhanVienNghi.Phep = true;
                                        nhanVienNghi.GhiChu = nghiCaSangCoLyDo + donNghiPhepCaSangCuaNhanVien.LyDo;
                                        nhanVienNghi.NguoiDuyet = donNghiPhepCaSangCuaNhanVien.NguoiDuyet;
                                    }
                                }
                                else
                                {
                                    nhanVienNghi.Phep = false;
                                    nhanVienNghi.GhiChu = nghiCaNgayKhongLyDo;
                                }
                            }
                            ql.Nghis.Add(nhanVienNghi);
                            ql.SaveChanges();
                        }
                    }
                }
            }
        }
    }

    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            QLNhanSuEntities ql = QLNhanSuEntities.getInstance();
            TimeSpan thoiGianTaoDSNVNghi = ql.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 5).Select(x => x.GiaTri).Single();
            MvcApplication mvcApplication = new MvcApplication();

            Action taoDSNhanVienNghiVaTinhLuongThang = new Action(() =>
            {
                mvcApplication.TaoDSNhanVienNghiTrongNgay();
                mvcApplication.TinhLuongThangChoNhanVien();
            });
            this.Schedule(taoDSNhanVienNghiVaTinhLuongThang).ToRunEvery(0).Days().At(thoiGianTaoDSNVNghi.Hours, thoiGianTaoDSNVNghi.Minutes);
        }
    }
}
