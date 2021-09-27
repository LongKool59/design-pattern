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
            else if(month == null && year != null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) &&  x.Ngay.Year == year);
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
            var nhanVien = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay == ngayHomNay).SingleOrDefault();
            if (nhanVien != null)
            {

                nhanVien.ThoiGianVao = DateTime.Now.TimeOfDay;
                //TimeSpan thoiGianBatDauCaSang = DateTime.Parse("8:00 AM").TimeOfDay;
                //TimeSpan thoiGianKhongChoVao = DateTime.Parse("10:00 AM").TimeOfDay;
                //if (nhanVien.ThoiGianVao < thoiGianBatDauCaSang)
                //{
                //    nhanVien.TrangThai = "Đúng giờ";
                //}
                //else if(nhanVien.ThoiGianVao < thoiGianKhongChoVao && nhanVien.ThoiGianVao > thoiGianBatDauCaSang)
                //{
                //    nhanVien.TrangThai = "Đi trễ";
                //    var tenphat = db.LoaiPhats.Where(s => s.TenLoaiPhat == "Đi trễ" && s.TrangThai == true).SingleOrDefault();
                //    if (tenphat != null)
                //    {
                //        Ct_Phat phat = new Ct_Phat();
                //        phat.MaNhanVien = nhanVien.MaNhanVien;
                //        phat.MaLoaiPhat = tenphat.MaLoaiPhat;
                //        phat.NgayPhat = DateTime.Now;
                //        phat.NguoiPhat = "Hệ thống";
                //        phat.NguoiSua = "Hệ thống";
                //        phat.NgaySua = DateTime.Now;
                //        phat.TrangThai = true;
                //        db.Ct_Phat.Add(phat);
                //        db.SaveChanges();
                //    }
                //}
                //else
                //{
                //    this.AddNotification("Không được check in vì đã quá giờ quy định.", NotificationType.WARNING);
                //    return RedirectToAction("ChamCongNgay");
                //}


                if (nhanVien.ThoiGianVao < thoiGianBatDauCaSang || (nhanVien.ThoiGianVao > thoiGianKetThucCaSang && nhanVien.ThoiGianVao < thoiGianBatDauCaChieu))
                {
                    nhanVien.TrangThai = "Đúng giờ";
                }
                else if ( (nhanVien.ThoiGianVao > thoiGianBatDauCaSang && nhanVien.ThoiGianVao < thoiGianKetThucCaSang) || 
                    (nhanVien.ThoiGianVao > thoiGianBatDauCaChieu && nhanVien.ThoiGianVao < thoiGianKetThucCaChieu))
                {
                    nhanVien.TrangThai = "Đi trễ";
                    var tenphat = db.LoaiPhats.Where(s => s.TenLoaiPhat == "Đi trễ" && s.TrangThai == true).SingleOrDefault();
                    if (tenphat != null)
                    {
                        Ct_Phat phat = new Ct_Phat();
                        phat.MaNhanVien = nhanVien.MaNhanVien;
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
                    this.AddNotification("Không được check in vì đã quá giờ quy định.", NotificationType.WARNING);
                    return RedirectToAction("ChamCongNgay");
                }
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
                //nếu nhân viên chấm công vào trước thời gian bắt đầu ca sáng và ra sau thòi gian kết thúc ca chiều sẽ được tính full 8h làm việc
                if (nhanVien.ThoiGianVao < thoiGianBatDauCaSang && nhanVien.ThoiGianRa > thoiGianKetThucCaChieu)
                {
                        nhanVien.ThoiGianLamViec = 8;
                }
                else if(nhanVien.ThoiGianVao < thoiGianKetThucCaSang && nhanVien.ThoiGianRa > thoiGianBatDauCaChieu)
                {
                    int gioNghiTrua = 1;
                    var soGioLamViec =  nhanVien.ThoiGianRa - nhanVien.ThoiGianVao;
                    nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours - gioNghiTrua;
                }
                else 
                {
                    var soGioLamViec = nhanVien.ThoiGianRa - nhanVien.ThoiGianVao;
                    nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours;
                }
                var thoiGianTangCa = nhanVien.ThoiGianRa - thoiGianKetThucCaChieu;
                nhanVien.ThoiGianTangCa = thoiGianTangCa.Value.Hours;
                db.SaveChanges();

            }
            return RedirectToAction("ChamCongNgay");
        }
    }
}