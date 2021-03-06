USE [master]
GO
/****** Object:  Database [QLNhanSu]    Script Date: 11/8/2021 16:29:08 ******/
CREATE DATABASE [QLNhanSu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNhanSu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLNhanSu.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLNhanSu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLNhanSu_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLNhanSu] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNhanSu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNhanSu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNhanSu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNhanSu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNhanSu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNhanSu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNhanSu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNhanSu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNhanSu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNhanSu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNhanSu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNhanSu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNhanSu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLNhanSu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNhanSu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNhanSu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNhanSu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNhanSu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNhanSu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNhanSu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNhanSu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLNhanSu] SET  MULTI_USER 
GO
ALTER DATABASE [QLNhanSu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNhanSu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNhanSu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNhanSu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLNhanSu]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[MaNhanVien] [int] NOT NULL,
	[Ngay] [date] NOT NULL,
	[ThoiGianVao] [time](7) NULL,
	[ThoiGianRa] [time](7) NULL,
	[ThoiGianLamViec] [int] NULL,
	[ThoiGianTangCa] [int] NULL,
	[TrangThai] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChamCong_1] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[Ngay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](max) NOT NULL,
	[HeSoChucVu] [float] NOT NULL,
	[PhuCap] [int] NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ct_Phat]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ct_Phat](
	[MaCTPhat] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[MaLoaiPhat] [int] NOT NULL,
	[NguoiPhat] [nvarchar](500) NULL,
	[NgayPhat] [datetime] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_Ct_Phat] PRIMARY KEY CLUSTERED 
(
	[MaCTPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ct_Thuong]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ct_Thuong](
	[MaCTThuong] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[MaLoaiThuong] [int] NOT NULL,
	[NguoiThuong] [nvarchar](500) NULL,
	[NgayThuong] [datetime] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_Ct_Thuong_1] PRIMARY KEY CLUSTERED 
(
	[MaCTThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonNghiPhep]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonNghiPhep](
	[MaDonNghiPhep] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[NgayNghi] [date] NOT NULL,
	[CaNghi] [nvarchar](200) NOT NULL,
	[LyDo] [nvarchar](max) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiDuyet] [nvarchar](max) NULL,
 CONSTRAINT [PK_DonNghiPhep] PRIMARY KEY CLUSTERED 
(
	[MaDonNghiPhep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhat]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhat](
	[MaLoaiPhat] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiPhat] [nvarchar](max) NOT NULL,
	[GiaTri] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_Phat] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiThuong]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThuong](
	[MaLoaiThuong] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiThuong] [nvarchar](max) NOT NULL,
	[GiaTri] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_Thuong] PRIMARY KEY CLUSTERED 
(
	[MaLoaiThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuongCoBan]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuongCoBan](
	[MaLuongCoBan] [int] IDENTITY(1,1) NOT NULL,
	[TienLuongCoBan] [int] NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_LuongCoBan] PRIMARY KEY CLUSTERED 
(
	[MaLuongCoBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuongThang]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuongThang](
	[MaLuong_Thang] [int] IDENTITY(1,1) NOT NULL,
	[ThangNam] [date] NOT NULL,
	[TongGioLamViec] [int] NOT NULL,
	[TongGioTangCa] [int] NOT NULL,
	[TongThuong] [int] NOT NULL,
	[TongPhat] [int] NOT NULL,
	[MaLuongCoBan] [int] NOT NULL,
	[HeSoLuong] [float] NULL,
	[PhuCap] [int] NULL,
 CONSTRAINT [PK_LuongThang] PRIMARY KEY CLUSTERED 
(
	[MaLuong_Thang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nghi]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nghi](
	[MaNhanVien] [int] NOT NULL,
	[NgayNghi] [date] NOT NULL,
	[Phep] [bit] NOT NULL,
	[NguoiDuyet] [nvarchar](max) NULL,
	[NgaySua] [datetime] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_Nghi] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[NgayNghi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](500) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[QueQuan] [nvarchar](max) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[CMND] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](500) NULL,
	[SDT] [nvarchar](20) NOT NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[MaChucVu] [int] NOT NULL,
	[MaPB] [int] NULL,
	[NguoiTao] [nvarchar](500) NULL,
	[NgayTao] [datetime] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](max) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [int] IDENTITY(1,1) NOT NULL,
	[TenPB] [nvarchar](max) NOT NULL,
	[SoDT] [nvarchar](50) NULL,
	[NguoiSua] [nvarchar](500) NULL,
	[NgaySua] [datetime] NOT NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuyDinhKhac]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyDinhKhac](
	[MaQuyDinh] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyDinh] [nvarchar](max) NOT NULL,
	[GiaTri] [int] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuyDinhKhac] PRIMARY KEY CLUSTERED 
(
	[MaQuyDinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuyDinhThoiGian]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyDinhThoiGian](
	[MaQuyDinh] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyDinh] [nvarchar](max) NOT NULL,
	[GiaTri] [time](1) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuyDinhThoiGian] PRIMARY KEY CLUSTERED 
(
	[MaQuyDinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/8/2021 16:29:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaNhanVien] [int] NOT NULL,
	[TenTK] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[MaQuyen] [int] NOT NULL,
	[ResetPasswordCode] [nvarchar](500) NULL,
 CONSTRAINT [PK_DangNhap_1] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2020-04-27' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2020-04-28' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:07:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:11:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:12:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-06-02' AS Date), CAST(N'08:05:19.9301701' AS Time), CAST(N'21:18:19.8401975' AS Time), 7, 4, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-06-04' AS Date), CAST(N'09:07:59.2802411' AS Time), CAST(N'17:31:07.8569460' AS Time), 6, 0, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-06-09' AS Date), CAST(N'00:11:54.7319728' AS Time), NULL, NULL, NULL, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1002, CAST(N'2021-10-13' AS Date), CAST(N'05:39:24.4492218' AS Time), CAST(N'08:39:39.1473390' AS Time), 0, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1003, CAST(N'2020-04-27' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1003, CAST(N'2020-04-28' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1003, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:03:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1003, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:03:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1003, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:04:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2020-04-27' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2020-04-28' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:00:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:08:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2021-06-04' AS Date), CAST(N'05:54:35.4060797' AS Time), CAST(N'17:30:54.8776491' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2021-06-08' AS Date), CAST(N'09:59:30.3608162' AS Time), CAST(N'22:13:48.2680131' AS Time), 6, 5, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1004, CAST(N'2021-10-27' AS Date), CAST(N'09:56:17.2106958' AS Time), CAST(N'09:56:20.5718887' AS Time), 0, 0, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:03:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:03:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:07:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-10-07' AS Date), CAST(N'08:42:47.8502911' AS Time), CAST(N'20:43:11.2586391' AS Time), 7, 3, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-10-08' AS Date), CAST(N'08:30:28.2000784' AS Time), CAST(N'20:31:00.3839766' AS Time), 7, 3, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-10-11' AS Date), CAST(N'08:33:11.1051634' AS Time), CAST(N'20:33:57.0713596' AS Time), 7, 3, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-10-12' AS Date), CAST(N'06:20:29.3176715' AS Time), CAST(N'12:20:45.9591113' AS Time), 4, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1005, CAST(N'2021-10-13' AS Date), CAST(N'06:17:04.7676870' AS Time), CAST(N'15:17:34.4764309' AS Time), 6, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1006, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:10:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1006, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:02:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1006, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1006, CAST(N'2021-10-04' AS Date), CAST(N'07:34:53.9352878' AS Time), CAST(N'12:35:33.4322111' AS Time), 4, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1006, CAST(N'2021-10-13' AS Date), CAST(N'06:37:52.8751966' AS Time), CAST(N'06:38:02.4519213' AS Time), 0, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1007, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:09:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1007, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:05:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1007, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:10:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1007, CAST(N'2021-06-02' AS Date), CAST(N'09:15:28.0143447' AS Time), NULL, NULL, NULL, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1007, CAST(N'2021-10-04' AS Date), CAST(N'13:34:34.0979934' AS Time), CAST(N'17:36:06.3548169' AS Time), 3, 0, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1007, CAST(N'2021-10-13' AS Date), CAST(N'08:26:38.7405909' AS Time), CAST(N'15:27:01.5555107' AS Time), 6, 0, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1008, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:03:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1008, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1008, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:11:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1009, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:14:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1009, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:05:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1009, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:13:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1009, CAST(N'2021-10-13' AS Date), CAST(N'08:44:08.5734533' AS Time), CAST(N'12:25:31.0062365' AS Time), 3, 0, N'Đi trễ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1010, CAST(N'2021-04-26' AS Date), CAST(N'07:55:00' AS Time), CAST(N'17:03:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1010, CAST(N'2021-04-27' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:00:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1010, CAST(N'2021-04-28' AS Date), CAST(N'07:48:00' AS Time), CAST(N'17:11:00' AS Time), 8, 0, N'Đúng giờ')
INSERT [dbo].[ChamCong] ([MaNhanVien], [Ngay], [ThoiGianVao], [ThoiGianRa], [ThoiGianLamViec], [ThoiGianTangCa], [TrangThai]) VALUES (1010, CAST(N'2021-10-13' AS Date), CAST(N'15:28:30.1323902' AS Time), CAST(N'17:32:18.4638682' AS Time), 1, 0, N'Đi trễ')
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2, N'Phó giám đốc', 5.1, 700000, 1, N'Fraser Clingan', CAST(N'2021-05-21T18:26:03.000' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (3, N'Trưởng phòng', 4.3, 600000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-09-11T19:46:15.740' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (25, N'Nhân viên', 2.1, 210000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-04T16:58:03.403' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (26, N'Nhân viên', 2.7, 100000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-04T17:07:21.667' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (27, N'Nhân viên', 2.2, 220000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-04T17:10:19.197' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (28, N'Nhân viên', 2.3, 230000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-04T17:13:38.883' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (29, N'Nhân viên', 2.4, 240000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-04T17:26:28.097' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (30, N'Nhân viên', 2.5, 250000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-04T17:27:48.327' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (31, N'Nhân viên', 2.6, 200000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T09:57:40.390' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (32, N'Nhân viên', 2.7, 250000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T09:58:39.303' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (33, N'Nhân viên', 2.7, 270000, 1, N'Fraser Clingan', CAST(N'2021-06-08T09:57:57.000' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (35, N'Giám đốc', 6.2, 800000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T22:11:10.917' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (37, N'Giám đốc', 6.3, 800000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T22:11:25.553' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (38, N'Giám đốc', 6.4, 820000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T22:11:48.997' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (39, N'Giám đốc', 6.5, 800000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T22:12:39.447' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (40, N'Giám đốc', 6.6, 910000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-09-11T11:32:03.383' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (43, N'Giám đốc', 6.8, 910000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-09-11T11:39:41.237' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (44, N'Giám đốc', 7, 920000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-09-11T20:06:04.847' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (51, N'Trưởng phòng', 4.4, 600000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-10-16T20:37:58.280' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (56, N'Giám đốc', 7.2, 920000, 1, N'Fraser Clingan', CAST(N'2021-09-11T20:06:02.000' AS DateTime))
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoChucVu], [PhuCap], [TrangThai], [NguoiSua], [NgaySua]) VALUES (57, N'Trưởng phòng', 4.3, 620000, 1, N'Fraser Clingan', CAST(N'2021-10-16T20:37:53.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[Ct_Phat] ON 

INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1, 1001, 3, N'Fraser Clingan', CAST(N'2021-04-07T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2, 1002, 2, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-17T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (3, 1003, 4, N'Fraser Clingan', CAST(N'2021-04-02T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (4, 1004, 3, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (5, 1005, 1, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:14:42.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (6, 1006, 2, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:18:22.213' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (7, 1007, 2, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:18:22.217' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (8, 1008, 3, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (9, 1009, 3, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (10, 1010, 1, N'Fraser Clingan', CAST(N'2021-04-08T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-04-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (52, 1006, 1, N'Fraser Clingan', CAST(N'2021-05-05T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:18:22.210' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (53, 1009, 12, N'Fraser Clingan', CAST(N'2021-05-20T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-05-25T17:26:08.673' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (59, 1002, 1, N'Hệ thống', CAST(N'2021-06-02T08:05:19.943' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-02T08:05:19.943' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (61, 1007, 1, N'Hệ thống', CAST(N'2021-06-02T09:15:28.030' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:18:22.207' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2207, 1002, 24, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2208, 1003, 24, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2209, 1004, 24, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2210, 1007, 24, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:18:22.203' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2211, 1008, 24, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2212, 1010, 24, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-03T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2458, 1004, 1, N'Hệ thống', CAST(N'2021-06-08T09:59:30.370' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-08T09:59:30.370' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2459, 1002, 24, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2460, 1003, 24, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2461, 1007, 24, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:18:22.200' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2462, 1008, 24, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2463, 1010, 24, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-06-08T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2508, 1010, 24, N'Hệ thống', CAST(N'2021-09-10T16:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-09-10T16:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2592, 1004, 1, N'Hệ thống', CAST(N'2021-10-27T09:56:17.233' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-27T09:56:17.233' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2593, 1002, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2594, 1003, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2595, 1003, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2596, 1005, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2597, 1005, 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2598, 1006, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2599, 1007, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2600, 1009, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Phat] ([MaCTPhat], [MaNhanVien], [MaLoaiPhat], [NguoiPhat], [NgayPhat], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2601, 1010, 24, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime), 1, N'Hệ thống', CAST(N'2021-10-31T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Ct_Phat] OFF
GO
SET IDENTITY_INSERT [dbo].[Ct_Thuong] ON 

INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1, 1001, 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2, 1002, 18, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-10-15T20:09:17.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (3, 1003, 2, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (4, 1004, 3, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (5, 1005, 5, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (6, 1006, 18, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-10-15T20:09:38.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (7, 1007, 3, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (8, 1008, 5, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 0, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (9, 1009, 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (10, 1010, 3, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (53, 1009, 20, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-05-25T16:47:57.820' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (55, 1002, 19, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-10-15T20:09:07.000' AS DateTime))
INSERT [dbo].[Ct_Thuong] ([MaCTThuong], [MaNhanVien], [MaLoaiThuong], [NguoiThuong], [NgayThuong], [TrangThai], [NguoiSua], [NgaySua]) VALUES (62, 1009, 19, N'Fraser Clingan', CAST(N'2021-04-21T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-05-26T10:11:52.270' AS DateTime))
SET IDENTITY_INSERT [dbo].[Ct_Thuong] OFF
GO
SET IDENTITY_INSERT [dbo].[DonNghiPhep] ON 

INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (1, 1003, CAST(N'2021-10-01' AS Date), N'Cả ngày', N'Bệnh', 0, NULL)
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (8, 1003, CAST(N'2021-10-06' AS Date), N'Cả ngày', N'Bệnh', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (9, 1003, CAST(N'2021-10-07' AS Date), N'Cả ngày', N'Bệnh', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (10, 1003, CAST(N'2021-10-08' AS Date), N'Cả ngày', N'Bệnh', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (19, 1010, CAST(N'2021-10-04' AS Date), N'Cả ngày', N'Hơi bệnh', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (20, 1009, CAST(N'2021-10-04' AS Date), N'Ca sáng', N'Mẹ e đi khám bệnh', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (21, 1005, CAST(N'2021-10-04' AS Date), N'Ca sáng', N'Cảm thấy hơi mệt', 0, N'')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (22, 1005, CAST(N'2021-10-04' AS Date), N'Ca chiều', N'Dẫn em đi siêu thị', 1, N'Salomon Tole')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (23, 1003, CAST(N'2021-10-11' AS Date), N'Cả ngày', N'Ốm', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (25, 1003, CAST(N'2021-10-04' AS Date), N'Cả ngày', N'Sốt', 0, NULL)
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (26, 1003, CAST(N'2021-10-12' AS Date), N'Cả ngày', N'Quải', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (27, 1003, CAST(N'2021-10-13' AS Date), N'Cả ngày', N'Ho, ói', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (28, 1005, CAST(N'2021-10-12' AS Date), N'Cả ngày', N'Hơi quải', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (29, 1005, CAST(N'2021-10-13' AS Date), N'Cả ngày', N'Bệnh ho ', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (30, 1010, CAST(N'2021-10-13' AS Date), N'Cả ngày', N'Meejt', 1, N'Fraser Clingan')
INSERT [dbo].[DonNghiPhep] ([MaDonNghiPhep], [MaNhanVien], [NgayNghi], [CaNghi], [LyDo], [TrangThai], [NguoiDuyet]) VALUES (32, 1007, CAST(N'2021-11-07' AS Date), N'Cả ngày', N'bệnh', 0, NULL)
SET IDENTITY_INSERT [dbo].[DonNghiPhep] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiPhat] ON 

INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1, N'Đi trễ', 50000, 1, N'Hệ thống - Ẩn danh', CAST(N'2021-05-25T21:16:51.740' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2, N'Thiệt hại tài nguyên của công ty', 500000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-10-16T20:26:23.143' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (3, N'Làm việc riêng', 200000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-05T09:20:24.027' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (4, N'Năng suất kém', 100000, 0, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (12, N'Thiệt hại tài nguyên của công ty', 600000, 0, N'Fraser Clingan', CAST(N'2021-05-24T11:21:39.000' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (24, N'Nghỉ', 500000, 1, N'Hệ thống - Ẩn danh', CAST(N'2021-06-08T21:58:45.163' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (36, N'Làm việc riêng', 210000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-05T09:20:33.157' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (37, N'Làm việc riêng', 220000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-05T09:21:06.160' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (38, N'Làm việc riêng', 215000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T09:49:42.150' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (39, N'Làm việc riêng', 210000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-10-16T20:25:52.527' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (40, N'Làm việc riêng', 220000, 1, N'Fraser Clingan', CAST(N'2021-10-16T20:25:50.000' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (41, N'Thiệt hại tài nguyên của công ty', 510000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-10-16T20:26:34.053' AS DateTime))
INSERT [dbo].[LoaiPhat] ([MaLoaiPhat], [TenLoaiPhat], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (42, N'Thiệt hại tài nguyên của công ty', 520000, 1, N'Fraser Clingan', CAST(N'2021-10-16T20:26:31.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LoaiPhat] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiThuong] ON 

INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1, N'Thưởng tiết kiệm', 100000, 0, N'Hệ thống - Ẩn danh', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2, N'Thưởng năng suất chất lượng', 300000, 0, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (3, N'Thưởng sáng kiến', 250000, 0, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (4, N'Thưởng tỷ lệ sản phẩm hỏng ít', 150000, 0, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (5, N'Thưởng đảm bảo ngày công', 200000, 0, N'Hệ thống - Ẩn danh', CAST(N'2021-05-25T21:20:37.887' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (17, N'Thưởng đảm bảo ngày công', 200000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-05T09:34:49.087' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (18, N'Thưởng năng suất chất lượng', 300000, 1, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (19, N'Thưởng sáng kiến', 250000, 1, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (20, N'Thưởng tiết kiệm', 100000, 0, N'Fraser Clingan', CAST(N'2021-04-28T00:00:00.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (35, N'Thưởng đảm bảo ngày công', 210000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T09:45:18.787' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (36, N'Thưởng đảm bảo ngày công', 220000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T09:45:57.520' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (37, N'Thưởng đảm bảo ngày công', 230000, 1, N'Hệ thống - Fraser Clingan', CAST(N'2021-06-08T21:53:51.930' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (44, N'Thưởng tiết kiệm', 110000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-10-16T20:18:48.267' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (45, N'Thưởng tiết kiệm', 120000, 0, N'Hệ thống - Fraser Clingan', CAST(N'2021-10-16T20:19:05.020' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (46, N'Thưởng tiết kiệm', 130000, 0, N'Fraser Clingan', CAST(N'2021-10-16T20:18:54.000' AS DateTime))
INSERT [dbo].[LoaiThuong] ([MaLoaiThuong], [TenLoaiThuong], [GiaTri], [TrangThai], [NguoiSua], [NgaySua]) VALUES (47, N'Thưởng tiết kiệm', 130000, 1, N'Fraser Clingan', CAST(N'2021-10-16T20:19:33.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LoaiThuong] OFF
GO
SET IDENTITY_INSERT [dbo].[LuongCoBan] ON 

INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1, 3981852, 1001, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (2, 4093037, 1002, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (3, 4846924, 1003, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (4, 5415112, 1004, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (5, 3358284, 1005, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (6, 5733847, 1006, 0, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (7, 3163197, 1007, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (8, 3489117, 1008, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (9, 5874825, 1009, 1, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (10, 6412249, 1010, 0, N'Fraser Clingan', CAST(N'2021-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (14, 6800000, 1010, 1, N'Tấn Lộc', CAST(N'2021-10-16T21:50:12.047' AS DateTime))
INSERT [dbo].[LuongCoBan] ([MaLuongCoBan], [TienLuongCoBan], [MaNhanVien], [TrangThai], [NguoiSua], [NgaySua]) VALUES (15, 6000000, 1006, 1, N'Tấn Lộc', CAST(N'2021-10-16T21:51:17.757' AS DateTime))
SET IDENTITY_INSERT [dbo].[LuongCoBan] OFF
GO
SET IDENTITY_INSERT [dbo].[LuongThang] ON 

INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (2, CAST(N'2021-04-30' AS Date), 173, 2, 550000, 100000, 2, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (3, CAST(N'2021-04-30' AS Date), 154, 8, 300000, 50000, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (4, CAST(N'2021-04-30' AS Date), 171, 9, 500000, 600000, 4, 2.1, 210000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (5, CAST(N'2021-04-30' AS Date), 163, 1, 200000, 50000, 5, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (6, CAST(N'2021-04-30' AS Date), 175, 6, 150000, 100000, 6, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (7, CAST(N'2021-04-30' AS Date), 176, 10, 100000, 700000, 7, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (8, CAST(N'2021-04-30' AS Date), 174, 5, 300000, 300000, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (9, CAST(N'2021-04-30' AS Date), 150, 8, 150000, 50000, 9, 2.1, 210000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (10, CAST(N'2021-04-30' AS Date), 167, 9, 150000, 200000, 10, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (139, CAST(N'2021-05-31' AS Date), 172, 0, 250000, 100000, 2, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (140, CAST(N'2021-05-31' AS Date), 172, 0, 350000, 100000, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (141, CAST(N'2021-05-31' AS Date), 172, 0, 350000, 100000, 4, 2.1, 210000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (142, CAST(N'2021-05-31' AS Date), 172, 0, 350000, 100000, 7, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (143, CAST(N'2021-05-31' AS Date), 172, 0, 350000, 100000, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (144, CAST(N'2021-05-31' AS Date), 172, 0, 350000, 100000, 10, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (183, CAST(N'2020-04-30' AS Date), 172, 2, 300000, 100000, 2, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (184, CAST(N'2020-04-30' AS Date), 176, 5, 350000, 200000, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (185, CAST(N'2020-04-30' AS Date), 162, 10, 400000, 150000, 4, 2.1, 210000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (186, CAST(N'2020-05-31' AS Date), 180, 0, 500000, 100000, 2, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (187, CAST(N'2020-05-31' AS Date), 163, 12, 700000, 250000, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (188, CAST(N'2020-05-31' AS Date), 181, 1, 400000, 500000, 4, 2.1, 210000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (189, CAST(N'2021-06-30' AS Date), 13, 4, 0, 600000, 2, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (190, CAST(N'2021-06-30' AS Date), 0, 0, 0, 500000, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (191, CAST(N'2021-06-30' AS Date), 14, 5, 0, 300000, 4, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (192, CAST(N'2021-06-30' AS Date), 0, 0, 0, 550000, 7, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (193, CAST(N'2021-06-30' AS Date), 0, 0, 0, 500000, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (194, CAST(N'2021-06-30' AS Date), 0, 0, 0, 500000, 10, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (233, CAST(N'2021-07-31' AS Date), 0, 0, 0, 0, 2, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (234, CAST(N'2021-07-31' AS Date), 0, 0, 0, 0, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (235, CAST(N'2021-07-31' AS Date), 0, 0, 0, 0, 4, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (236, CAST(N'2021-07-31' AS Date), 0, 0, 0, 0, 7, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (237, CAST(N'2021-07-31' AS Date), 0, 0, 0, 0, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (238, CAST(N'2021-07-31' AS Date), 0, 0, 0, 0, 10, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (277, CAST(N'2021-08-31' AS Date), 0, 0, 0, 0, 2, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (278, CAST(N'2021-08-31' AS Date), 0, 0, 0, 0, 3, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (279, CAST(N'2021-08-31' AS Date), 0, 0, 0, 0, 4, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (280, CAST(N'2021-08-31' AS Date), 0, 0, 0, 0, 7, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (281, CAST(N'2021-08-31' AS Date), 0, 0, 0, 0, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (282, CAST(N'2021-08-31' AS Date), 0, 0, 0, 0, 10, 4.3, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (283, CAST(N'2021-09-30' AS Date), 0, 0, 0, 0, 2, 4.4, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (284, CAST(N'2021-09-30' AS Date), 0, 0, 0, 0, 3, 4.4, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (285, CAST(N'2021-09-30' AS Date), 0, 0, 0, 0, 4, 4.4, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (286, CAST(N'2021-09-30' AS Date), 0, 0, 0, 0, 7, 4.4, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (287, CAST(N'2021-09-30' AS Date), 0, 0, 0, 0, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (288, CAST(N'2021-09-30' AS Date), 0, 0, 0, 250000, 10, 4.4, 600000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (343, CAST(N'2021-10-31' AS Date), 0, 0, 550000, 500000, 2, 4.3, 620000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (344, CAST(N'2021-10-31' AS Date), 0, 0, 0, 1000000, 3, 4.3, 620000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (345, CAST(N'2021-10-31' AS Date), 0, 0, 0, 50000, 4, 4.3, 620000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (346, CAST(N'2021-10-31' AS Date), 31, 9, 0, 600000, 5, 4.3, 620000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (347, CAST(N'2021-10-31' AS Date), 4, 0, 300000, 1050000, 15, 2.7, 270000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (348, CAST(N'2021-10-31' AS Date), 9, 0, 0, 2050000, 7, 4.3, 620000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (349, CAST(N'2021-10-31' AS Date), 0, 0, 0, 0, 8, 5.1, 700000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (350, CAST(N'2021-10-31' AS Date), 3, 0, 0, 500000, 9, 2.7, 270000)
INSERT [dbo].[LuongThang] ([MaLuong_Thang], [ThangNam], [TongGioLamViec], [TongGioTangCa], [TongThuong], [TongPhat], [MaLuongCoBan], [HeSoLuong], [PhuCap]) VALUES (351, CAST(N'2021-10-31' AS Date), 1, 0, 0, 500000, 14, 4.3, 620000)
SET IDENTITY_INSERT [dbo].[LuongThang] OFF
GO
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-03-27' AS Date), 1, N'Beltran Owtram', CAST(N'2021-03-28T00:00:00.000' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-06-07' AS Date), 0, NULL, CAST(N'2021-06-07T11:58:58.113' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-06-08' AS Date), 0, NULL, CAST(N'2021-06-08T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-07-28' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:53:44.327' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-08-17' AS Date), 0, N'Fraser Clingan', CAST(N'2021-10-02T11:53:44.330' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-09-10' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:51:59.207' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.483' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-04' AS Date), 0, NULL, CAST(N'2021-10-04T18:35:04.910' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:28.943' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-06' AS Date), 0, NULL, CAST(N'2021-10-06T18:38:17.817' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-07' AS Date), 0, NULL, CAST(N'2021-10-07T20:39:37.827' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-08' AS Date), 0, NULL, CAST(N'2021-10-08T20:30:50.530' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-11' AS Date), 0, NULL, CAST(N'2021-10-11T20:33:49.670' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-12' AS Date), 0, NULL, CAST(N'2021-10-12T18:22:54.487' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-13' AS Date), 0, NULL, CAST(N'2021-10-13T17:30:00.027' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.740' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.217' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.643' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1002, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.703' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-03-23' AS Date), 1, N'Fraser Clingan', CAST(N'2021-05-31T21:10:42.483' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-06-04' AS Date), 1, N'Fraser Clingan', CAST(N'2021-06-04T13:57:02.237' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-06-07' AS Date), 0, NULL, CAST(N'2021-06-07T11:58:58.157' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-06-08' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:51:39.800' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-07-28' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:51:39.923' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-08-17' AS Date), 0, NULL, CAST(N'2021-08-17T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-09-10' AS Date), 0, NULL, CAST(N'2021-09-10T12:50:48.737' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.653' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-04' AS Date), 0, NULL, CAST(N'2021-10-04T18:35:05.077' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:29.123' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-06' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-06T18:38:17.990' AS DateTime), N'Nghỉ cả ngày - Lý do: Bệnh')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-07' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-07T20:39:38.000' AS DateTime), N'Nghỉ cả ngày - Lý do: Bệnh')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-08' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-08T20:30:50.697' AS DateTime), N'Nghỉ cả ngày - Lý do: Bệnh')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-11' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-11T20:33:49.837' AS DateTime), N'Nghỉ cả ngày - Lý do: Ốm')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-12' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-12T18:22:54.660' AS DateTime), N'Nghỉ cả ngày - Lý do: Quải')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-13' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-13T17:30:00.033' AS DateTime), N'Nghỉ cả ngày - Lý do: Ho, ói')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.907' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.387' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.867' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1003, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.887' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1004, CAST(N'2021-03-28' AS Date), 0, N'Fraser Clingan', CAST(N'2021-05-31T21:10:29.097' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1004, CAST(N'2021-06-07' AS Date), 0, NULL, CAST(N'2021-06-07T11:58:58.157' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1004, CAST(N'2021-07-28' AS Date), 0, NULL, CAST(N'2021-07-28T14:54:58.293' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1004, CAST(N'2021-08-17' AS Date), 0, NULL, CAST(N'2021-08-17T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1004, CAST(N'2021-09-10' AS Date), 0, NULL, CAST(N'2021-09-10T12:50:48.737' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-03-25' AS Date), 1, N'Fraser Clingan', CAST(N'2021-05-31T12:11:49.000' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.657' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-04' AS Date), 0, N'Salomon Tole', CAST(N'2021-10-04T18:35:05.080' AS DateTime), N'Nghỉ ca chiều - Lý do: Dẫn em đi siêu thị + Nghỉ ca sáng')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:29.127' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-06' AS Date), 0, NULL, CAST(N'2021-10-06T18:38:17.997' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-07' AS Date), 0, NULL, CAST(N'2021-10-07T20:39:38.010' AS DateTime), NULL)
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-08' AS Date), 0, NULL, CAST(N'2021-10-08T20:30:50.707' AS DateTime), NULL)
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-11' AS Date), 0, NULL, CAST(N'2021-10-11T20:33:49.847' AS DateTime), NULL)
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-12' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-12T18:22:54.670' AS DateTime), N'Nghỉ ca chiều - Lý do: Hơi quải')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.913' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.390' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.870' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1005, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.890' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-03-04' AS Date), 1, N'Fraser Clingan', CAST(N'2021-06-06T12:47:30.813' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.660' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-04' AS Date), 0, NULL, CAST(N'2021-10-04T18:35:05.090' AS DateTime), N'Nghỉ ca chiều')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:29.130' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-06' AS Date), 0, NULL, CAST(N'2021-10-06T18:38:18.000' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-07' AS Date), 0, NULL, CAST(N'2021-10-07T20:39:38.017' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-08' AS Date), 0, NULL, CAST(N'2021-10-08T20:30:50.713' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-11' AS Date), 0, NULL, CAST(N'2021-10-11T20:33:49.857' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-12' AS Date), 0, NULL, CAST(N'2021-10-12T18:22:54.677' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-13' AS Date), 0, NULL, CAST(N'2021-10-13T17:30:00.040' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.917' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.393' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.873' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1006, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.893' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-03-01' AS Date), 0, N'null', NULL, N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-06-04' AS Date), 1, N'Fraser Clingan', CAST(N'2021-06-04T13:58:02.283' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-06-07' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:29:44.750' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-06-08' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:29:44.887' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-07-28' AS Date), 0, NULL, CAST(N'2021-07-28T14:54:58.297' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-08-17' AS Date), 0, NULL, CAST(N'2021-08-17T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-09-10' AS Date), 0, NULL, CAST(N'2021-09-10T12:50:48.737' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.663' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-04' AS Date), 0, NULL, CAST(N'2021-10-04T18:35:05.097' AS DateTime), N'Nghỉ ca sáng')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:29.133' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-06' AS Date), 0, NULL, CAST(N'2021-10-06T18:38:18.003' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-07' AS Date), 0, NULL, CAST(N'2021-10-07T20:39:38.020' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-08' AS Date), 0, NULL, CAST(N'2021-10-08T20:30:50.717' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-11' AS Date), 0, NULL, CAST(N'2021-10-11T20:33:49.860' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-12' AS Date), 0, NULL, CAST(N'2021-10-12T18:22:54.683' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.917' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.397' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.877' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1007, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.897' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-03-07' AS Date), 1, N'Beltran Owtram', CAST(N'2021-03-28T00:00:00.000' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-06-04' AS Date), 1, N'Fraser Clingan', CAST(N'2021-06-04T13:58:02.287' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-06-07' AS Date), 0, NULL, CAST(N'2021-06-07T11:58:58.157' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-06-08' AS Date), 0, NULL, CAST(N'2021-06-08T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-07-28' AS Date), 0, NULL, CAST(N'2021-07-28T14:54:58.300' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-08-17' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:52:23.037' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1008, CAST(N'2021-09-10' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-02T11:52:23.040' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-03-24' AS Date), 0, N'Fraser Clingan', CAST(N'2021-06-06T12:45:58.223' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.667' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-04' AS Date), 0, N'Fraser Clingan', CAST(N'2021-10-04T18:35:05.103' AS DateTime), N'Nghỉ ca sáng - Lý do: Mẹ e đi khám bệnh + Nghỉ ca chiều')
GO
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:29.137' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-06' AS Date), 0, NULL, CAST(N'2021-10-06T18:38:18.007' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-07' AS Date), 0, NULL, CAST(N'2021-10-07T20:39:38.023' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-08' AS Date), 0, NULL, CAST(N'2021-10-08T20:30:50.720' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-11' AS Date), 0, NULL, CAST(N'2021-10-11T20:33:49.863' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-12' AS Date), 0, NULL, CAST(N'2021-10-12T18:22:54.687' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-13' AS Date), 0, NULL, CAST(N'2021-10-13T17:30:00.047' AS DateTime), N'Nghỉ ca chiều')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.923' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.400' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.880' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1009, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.897' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-03-18' AS Date), 0, N'null', NULL, N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-06-04' AS Date), 1, N'Fraser Clingan', CAST(N'2021-06-04T13:57:32.437' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-06-07' AS Date), 1, N'Fraser Clingan', CAST(N'2021-06-07T12:04:43.740' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-06-08' AS Date), 0, NULL, CAST(N'2021-06-08T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-07-28' AS Date), 0, NULL, CAST(N'2021-07-28T14:54:58.303' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-08-17' AS Date), 0, NULL, CAST(N'2021-08-17T10:00:00.020' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-09-10' AS Date), 0, NULL, CAST(N'2021-09-10T12:50:48.740' AS DateTime), N'Hôm nay nghỉ')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-01' AS Date), 0, NULL, CAST(N'2021-10-01T18:20:59.670' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-04' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-04T18:35:05.107' AS DateTime), N'Nghỉ cả ngày - Lý do: Hơi bệnh')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-05' AS Date), 0, NULL, CAST(N'2021-10-05T18:35:29.140' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-06' AS Date), 0, NULL, CAST(N'2021-10-06T18:38:18.007' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-07' AS Date), 0, NULL, CAST(N'2021-10-07T20:39:38.027' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-08' AS Date), 0, NULL, CAST(N'2021-10-08T20:30:50.723' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-11' AS Date), 0, NULL, CAST(N'2021-10-11T20:33:49.867' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-12' AS Date), 0, NULL, CAST(N'2021-10-12T18:22:54.687' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-13' AS Date), 1, N'Fraser Clingan', CAST(N'2021-10-13T17:30:00.050' AS DateTime), N'Nghỉ ca sáng - Lý do: Meejt')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-14' AS Date), 0, NULL, CAST(N'2021-10-14T20:36:29.927' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-15' AS Date), 0, NULL, CAST(N'2021-10-15T17:01:29.403' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-25' AS Date), 0, NULL, CAST(N'2021-10-25T17:14:34.887' AS DateTime), N'Nghỉ cả ngày')
INSERT [dbo].[Nghi] ([MaNhanVien], [NgayNghi], [Phep], [NguoiDuyet], [NgaySua], [GhiChu]) VALUES (1010, CAST(N'2021-10-29' AS Date), 0, NULL, CAST(N'2021-10-29T21:53:38.900' AS DateTime), N'Nghỉ cả ngày')
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1001, N'Kim Long', CAST(N'1996-08-13' AS Date), N'Nam', N'Vietnam                                           ', N'59124 Ohio Center', N'50-882-0977 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 56, 1, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Ẩn danh', CAST(N'2021-05-24T21:16:13.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1002, N'Tấn Lộc', CAST(N'1968-08-27' AS Date), N'Nam', N'Vietnam                                           ', N'98 Sundown Center', N'04-007-3097 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 57, 2, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-10-15T17:17:15.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1003, N'Minh Lân', CAST(N'1969-09-24' AS Date), N'Nam', N'Vietnam                                           ', N'23 Merrick Avenue', N'01-333-1848 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 57, 5, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-06-04T16:55:29.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1004, N'Fraser Clingan', CAST(N'1966-05-28' AS Date), N'Nam', N'Vietnam                                           ', N'19603 Carioca Trail', N'22-492-4026 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 57, 1, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-06-02T10:35:58.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1005, N'Lacey Joel', CAST(N'1989-10-12' AS Date), N'Nam', N'Vietnam                                           ', N'0045 Emmet Park', N'19-783-5796 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 57, 3, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-10-15T17:22:47.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1006, N'Barbra Kenwell', CAST(N'1974-04-23' AS Date), N'Nam', N'Vietnam                                           ', N'45246 Maryland Hill', N'98-668-9460 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 33, 1, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-06-02T10:32:42.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1007, N'Roi Bartolijn', CAST(N'1981-09-21' AS Date), N'Nữ', N'Vietnam                                           ', N'1311 Fuller Avenue', N'05-174-8851 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 57, 1, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, NULL, CAST(N'2021-04-15T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1008, N'Salomon Tole', CAST(N'1993-07-13' AS Date), N'Nam', N'Vietnam                                           ', N'5 Alpine Terrace', N'33-210-1904 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 2, 4, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, NULL, CAST(N'2021-04-15T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1009, N'Dulcea Monard', CAST(N'1989-08-23' AS Date), N'Nam', N'Vietnam                                           ', N'86 Carey Pass', N'25-043-4068 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 33, 1, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, NULL, CAST(N'2021-04-15T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [DiaChi], [CMND], [Email], [SDT], [HinhAnh], [MaChucVu], [MaPB], [NguoiTao], [NgayTao], [TrangThai], [NguoiSua], [NgaySua]) VALUES (1010, N'Lianna Simonich 😀', CAST(N'1968-09-25' AS Date), N'Nam', N'Vietnam                                           ', N'67975 Swallow Point', N'36-311-5557 ', N'democnpmnc@gmail.com', N'0652365478', N'https://i.pravatar.cc/300', 57, 3, N'Fraser Clingan', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 1, N'Fraser Clingan', CAST(N'2021-10-15T17:21:20.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (1, N'Nhân viên', N'Xem thông tin, chấm công ra vào')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (2, N'Phòng tài chính', N'Quản lý lương')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (3, N'Quản trị hệ thống', N'Quản lý tài khoản người dùng')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen], [GhiChu]) VALUES (4, N'Phòng nhân sự', N'Quản lý thông tin nhân viên, chấm công')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[PhongBan] ON 

INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (1, N'Phòng Nhân Sự', N'0123456789', N'Fraser Clingan', CAST(N'2021-04-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (2, N'Phòng Tài Chính', N'0215485212', N'Fraser Clingan', CAST(N'2021-06-08T09:55:51.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (3, N'Phòng CNTT', N'0265512545', N'Ẩn danh', CAST(N'2021-06-08T22:07:53.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (4, N'Phòng Giám Đốc', N'0554895542', N'Fraser Clingan', CAST(N'2021-04-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (5, N'Phòng Kinh Doanh', N'0561985653', N'Fraser Clingan', CAST(N'2021-04-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (6, N'Phòng Sản Xuất', N'0269674542', N'Fraser Clingan', CAST(N'2021-04-25T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [SoDT], [NguoiSua], [NgaySua]) VALUES (12, N'Tất cả', N'0111111111', N'Fraser Clingan', CAST(N'2021-04-25T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PhongBan] OFF
GO
SET IDENTITY_INSERT [dbo].[QuyDinhKhac] ON 

INSERT [dbo].[QuyDinhKhac] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (1, N'Lần nghỉ phép', 5, N'Số lần nghỉ có phép tối đa, vượt quá sẽ bị phạt.')
INSERT [dbo].[QuyDinhKhac] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (2, N'Lần nghỉ không phép', 2, N'Số lần nghỉ không phép tối đa, vượt quá sẽ bị phạt.')
INSERT [dbo].[QuyDinhKhac] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (3, N'Lần đi trễ', 2, N'Số lần đi trễ tối đa trong 1 tháng. Vượt quá sẽ bị phạt...')
SET IDENTITY_INSERT [dbo].[QuyDinhKhac] OFF
GO
SET IDENTITY_INSERT [dbo].[QuyDinhThoiGian] ON 

INSERT [dbo].[QuyDinhThoiGian] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (1, N'Bắt đầu ca sáng', CAST(N'08:00:00' AS Time), N'Thời gian bắt đầu ca sáng.')
INSERT [dbo].[QuyDinhThoiGian] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (2, N'Kết thúc ca sáng', CAST(N'12:00:00' AS Time), NULL)
INSERT [dbo].[QuyDinhThoiGian] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (3, N'Bắt đầu ca chiều', CAST(N'13:00:00' AS Time), NULL)
INSERT [dbo].[QuyDinhThoiGian] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (4, N'Kết thúc ca chiều', CAST(N'17:00:00' AS Time), NULL)
INSERT [dbo].[QuyDinhThoiGian] ([MaQuyDinh], [TenQuyDinh], [GiaTri], [GhiChu]) VALUES (5, N'Tạo danh sách nhân viên nghỉ', CAST(N'17:30:00' AS Time), N'Thời gian thêm nhân viên nghỉ vào danh sách nghỉ ')
SET IDENTITY_INSERT [dbo].[QuyDinhThoiGian] OFF
GO
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1001, N'admin', N'admin123', 3, N'')
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1002, N'1002706558', N'a12345', 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1003, N'1003617233', N'a12345', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1004, N'1004559265', N'a12345', 4, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1005, N'1005289606', N'a12345', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1006, N'1006338754', N'a12345', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1007, N'1007946647', N'a12345', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1008, N'1008618959', N'a12345', 4, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1009, N'1009298887', N'a12345', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaNhanVien], [TenTK], [MatKhau], [MaQuyen], [ResetPasswordCode]) VALUES (1010, N'1010397875', N'a12345', 1, NULL)
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_NhanVien]
GO
ALTER TABLE [dbo].[Ct_Phat]  WITH CHECK ADD  CONSTRAINT [FK_Ct_Phat_LoaiPhat] FOREIGN KEY([MaLoaiPhat])
REFERENCES [dbo].[LoaiPhat] ([MaLoaiPhat])
GO
ALTER TABLE [dbo].[Ct_Phat] CHECK CONSTRAINT [FK_Ct_Phat_LoaiPhat]
GO
ALTER TABLE [dbo].[Ct_Phat]  WITH CHECK ADD  CONSTRAINT [FK_Ct_Phat_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[Ct_Phat] CHECK CONSTRAINT [FK_Ct_Phat_NhanVien]
GO
ALTER TABLE [dbo].[Ct_Thuong]  WITH CHECK ADD  CONSTRAINT [FK_Ct_Thuong_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[Ct_Thuong] CHECK CONSTRAINT [FK_Ct_Thuong_NhanVien]
GO
ALTER TABLE [dbo].[Ct_Thuong]  WITH CHECK ADD  CONSTRAINT [FK_Ct_Thuong_Thuong] FOREIGN KEY([MaLoaiThuong])
REFERENCES [dbo].[LoaiThuong] ([MaLoaiThuong])
GO
ALTER TABLE [dbo].[Ct_Thuong] CHECK CONSTRAINT [FK_Ct_Thuong_Thuong]
GO
ALTER TABLE [dbo].[DonNghiPhep]  WITH CHECK ADD  CONSTRAINT [FK_DonNghiPhep_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[DonNghiPhep] CHECK CONSTRAINT [FK_DonNghiPhep_NhanVien]
GO
ALTER TABLE [dbo].[LuongCoBan]  WITH CHECK ADD  CONSTRAINT [FK_LuongCoBan_LuongCoBan] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[LuongCoBan] CHECK CONSTRAINT [FK_LuongCoBan_LuongCoBan]
GO
ALTER TABLE [dbo].[LuongThang]  WITH CHECK ADD  CONSTRAINT [FK_LuongThang_LuongCoBan] FOREIGN KEY([MaLuongCoBan])
REFERENCES [dbo].[LuongCoBan] ([MaLuongCoBan])
GO
ALTER TABLE [dbo].[LuongThang] CHECK CONSTRAINT [FK_LuongThang_LuongCoBan]
GO
ALTER TABLE [dbo].[Nghi]  WITH CHECK ADD  CONSTRAINT [FK_Nghi_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[Nghi] CHECK CONSTRAINT [FK_Nghi_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_PhanQuyen] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[PhanQuyen] ([MaQuyen])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_PhanQuyen]
GO
USE [master]
GO
ALTER DATABASE [QLNhanSu] SET  READ_WRITE 
GO
