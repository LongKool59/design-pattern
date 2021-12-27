using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using PagedList;
using PagedList.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class CCRaVaoController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();
        // GET: CCRaVao
        public ActionResult ChamCongNgay(int? page, int? month, int? year)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var maNhanVien = Session["MaNhanVien"].ToString();

            IQueryable<ChamCong> chamCongs;
            List<ChamCongViewModel> chamCongViewModels;
            if (month != null && year != null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Month == month && x.Ngay.Year == year);
                chamCongViewModels = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                return View(chamCongViewModels.ToPagedList(pageNumber, pageSize));
            }
            else if (month == null && year != null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Year == year);
                chamCongViewModels = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                return View(chamCongViewModels.ToPagedList(pageNumber, pageSize));
            }
            else if (month != null && year == null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Month == month);
                chamCongViewModels = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
                return View(chamCongViewModels.ToPagedList(pageNumber, pageSize));
            }
            chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Month == DateTime.Now.Month && x.Ngay.Year == DateTime.Now.Year);
            chamCongViewModels = chamCongs.ToList().ConvertAll<ChamCongViewModel>(x => x);
            return View(chamCongViewModels.ToPagedList(pageNumber, pageSize));
        }




        [HttpPost]
        public ActionResult CheckIn()
        {
            TimeSpan thoiGianBatDauCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 1).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianKetThucCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 2).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianBatDauCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 3).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianKetThucCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 4).Select(x => x.GiaTri).Single();

            var maNhanVien = Session["MaNhanVien"].ToString();
            var ngayHomNay = DateTime.Today;
            var nhanVienChamCong = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay == ngayHomNay).SingleOrDefault();
            if (nhanVienChamCong == null)
            {
                ChamCong chamCong = new ChamCong();
                chamCong.MaNhanVien = Convert.ToInt32(maNhanVien);
                chamCong.Ngay = ngayHomNay;
                chamCong.ThoiGianVao = DateTime.Now.TimeOfDay;

                if (chamCong.ThoiGianVao < thoiGianBatDauCaSang || (chamCong.ThoiGianVao > thoiGianKetThucCaSang && chamCong.ThoiGianVao < thoiGianBatDauCaChieu))
                {
                    chamCong.TrangThai = "Đúng giờ";
                }
                else if ((chamCong.ThoiGianVao > thoiGianBatDauCaSang && chamCong.ThoiGianVao < thoiGianKetThucCaSang) ||
                    (chamCong.ThoiGianVao > thoiGianBatDauCaChieu && chamCong.ThoiGianVao < thoiGianKetThucCaChieu))
                {
                    chamCong.TrangThai = "Đi trễ";
                    var tenphat = db.LoaiPhats.Where(s => s.TenLoaiPhat == "Đi trễ" && s.TrangThai == true).SingleOrDefault();
                    if (tenphat != null)
                    {
                        Ct_Phat phat = new Ct_Phat();
                        phat.MaNhanVien = Convert.ToInt32(maNhanVien);
                        phat.MaLoaiPhat = tenphat.MaLoaiPhat;
                        phat.NgayPhat = DateTime.Now;
                        phat.NguoiPhat = "Hệ thống";
                        phat.NguoiSua = "Hệ thống";
                        phat.NgaySua = DateTime.Now;
                        phat.TrangThai = true;
                        db.Ct_Phat.Add(phat);
                        db.SaveChanges();
                    }
                }
                else
                {
                    StrategyPatternController CheckInLate = new StrategyPatternController();
                    CheckInLate.SetChamCongBehavior(new LateBehaviorController());
                    CheckInLate.PrintNotification();
                    return RedirectToAction("ChamCongNgay");
                }
                db.ChamCongs.Add(chamCong);
                db.SaveChanges();
            }
            return RedirectToAction("ChamCongNgay");
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
            TimeSpan thoiGianBatDauCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 1).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianKetThucCaSang = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 2).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianBatDauCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 3).Select(x => x.GiaTri).Single();
            TimeSpan thoiGianKetThucCaChieu = db.QuyDinhThoiGians.Where(x => x.MaQuyDinh == 4).Select(x => x.GiaTri).Single();

            var maNhanVien = Session["MaNhanVien"].ToString();
            var ngayHomNay = DateTime.Today;
            var nhanVien = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay == ngayHomNay).SingleOrDefault();
            if (nhanVien != null)
            {
                nhanVien.ThoiGianRa = DateTime.Now.TimeOfDay;
                if (nhanVien.ThoiGianVao >= thoiGianKetThucCaSang && nhanVien.ThoiGianVao <= thoiGianBatDauCaChieu && nhanVien.ThoiGianRa <= thoiGianBatDauCaChieu)
                {
                    StrategyPatternController CheckOutEarly = new StrategyPatternController();
                    CheckOutEarly.SetChamCongBehavior(new EarlyBehaviorController());
                    CheckOutEarly.PrintNotification();
                    return RedirectToAction("ChamCongNgay");
                }

                int gioNghiTrua = 1;

                if (nhanVien.ThoiGianVao < thoiGianBatDauCaSang)
                {
                    if (nhanVien.ThoiGianRa < thoiGianBatDauCaChieu)
                    {
                        var soGioLamViec = nhanVien.ThoiGianRa - thoiGianBatDauCaSang ;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours < 0 ? 0 : soGioLamViec.Value.Hours;
                    }
                    else if(nhanVien.ThoiGianRa >= thoiGianBatDauCaChieu && nhanVien.ThoiGianRa < thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = nhanVien.ThoiGianRa - thoiGianBatDauCaSang;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours - gioNghiTrua;
                    }
                    else if(nhanVien.ThoiGianRa > thoiGianKetThucCaChieu)
                    {
                        nhanVien.ThoiGianLamViec = 8;
                    }
                }
                else if (nhanVien.ThoiGianVao >= thoiGianBatDauCaSang && nhanVien.ThoiGianVao < thoiGianKetThucCaSang)
                {
                    if (nhanVien.ThoiGianRa < thoiGianBatDauCaChieu)
                    {
                        var soGioLamViec = nhanVien.ThoiGianRa - nhanVien.ThoiGianVao;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours;
                    }
                    else if (nhanVien.ThoiGianRa >= thoiGianBatDauCaChieu && nhanVien.ThoiGianRa < thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = nhanVien.ThoiGianRa - nhanVien.ThoiGianVao;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours - gioNghiTrua;
                    }
                    else if (nhanVien.ThoiGianRa > thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = thoiGianKetThucCaChieu - nhanVien.ThoiGianVao;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours - gioNghiTrua;
                    }
                }
                else if(nhanVien.ThoiGianVao >= thoiGianKetThucCaSang && nhanVien.ThoiGianVao < thoiGianBatDauCaChieu)
                {
                    if (nhanVien.ThoiGianRa >= thoiGianBatDauCaChieu && nhanVien.ThoiGianRa < thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = nhanVien.ThoiGianRa - thoiGianBatDauCaChieu;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours;
                    }
                    else if (nhanVien.ThoiGianRa > thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = thoiGianKetThucCaChieu - thoiGianBatDauCaChieu;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Hours;
                    }
                }
                else if(nhanVien.ThoiGianVao >= thoiGianBatDauCaChieu)
                {
                    if (nhanVien.ThoiGianRa >= thoiGianBatDauCaChieu && nhanVien.ThoiGianRa < thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = nhanVien.ThoiGianRa - nhanVien.ThoiGianVao;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours;
                    }
                    else if (nhanVien.ThoiGianRa > thoiGianKetThucCaChieu)
                    {
                        var soGioLamViec = thoiGianKetThucCaChieu - nhanVien.ThoiGianVao;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours;
                    }
                }


                var thoiGianTangCa = nhanVien.ThoiGianRa - thoiGianKetThucCaChieu;
                if (thoiGianTangCa.Value.Hours <= 0)
                {
                    nhanVien.ThoiGianTangCa = 0;
                }
                else
                {
                    nhanVien.ThoiGianTangCa = thoiGianTangCa.Value.Hours;
                }
                db.SaveChanges();

            }
            return RedirectToAction("ChamCongNgay");
        }
    }
}