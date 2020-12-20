USE [master]
GO
/****** Object:  Database [HMS]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE DATABASE [HMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HMS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [HMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HMS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HMS] SET RECOVERY FULL 
GO
ALTER DATABASE [HMS] SET  MULTI_USER 
GO
ALTER DATABASE [HMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HMS', N'ON'
GO
ALTER DATABASE [HMS] SET QUERY_STORE = OFF
GO
USE [HMS]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[MaNhanVien] [nvarchar](128) NOT NULL,
	[Username] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BC_DOANHTHU]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BC_DOANHTHU](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[TongDoanhThu] [float] NOT NULL,
	[TongBenhNhan] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BC_DOANHTHU] PRIMARY KEY CLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BC_SUDUNGTHUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BC_SUDUNGTHUOC](
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[MaThuoc] [nvarchar](128) NOT NULL,
	[SoLanDung] [int] NOT NULL,
	[SoLuongDung] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BC_SUDUNGTHUOC] PRIMARY KEY CLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BENH]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BENH](
	[MaBenh] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[TenBenh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.BENH] PRIMARY KEY CLUSTERED 
(
	[MaBenh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BENHNHAN]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BENHNHAN](
	[MaBenhNhan] [nvarchar](128) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SoDienThoai] [nvarchar](20) NOT NULL,
	[SoCMND] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.BENHNHAN] PRIMARY KEY CLUSTERED 
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CACHDUNG]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CACHDUNG](
	[MaCachDung] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[TenCachDung] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.CACHDUNG] PRIMARY KEY CLUSTERED 
(
	[MaCachDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_BCDOANHTHU]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_BCDOANHTHU](
	[Ngay] [int] NOT NULL,
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[SoBenhNhan] [int] NOT NULL,
	[DoanhThu] [float] NOT NULL,
	[TyLe] [float] NOT NULL,
 CONSTRAINT [PK_dbo.CT_BCDOANHTHU] PRIMARY KEY CLUSTERED 
(
	[Ngay] ASC,
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_DONTHUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_DONTHUOC](
	[MaDonThuoc] [nvarchar](128) NOT NULL,
	[MaThuoc] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[MaCachDung] [nvarchar](128) NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CT_DONTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaDonThuoc] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_HOADONTHUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_HOADONTHUOC](
	[MaHoaDon] [nvarchar](128) NOT NULL,
	[MaThuoc] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[ThanhTien] [float] NOT NULL,
 CONSTRAINT [PK_dbo.CT_HOADONTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_PHIEUNHAPTHUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEUNHAPTHUOC](
	[MaPNT] [nvarchar](128) NOT NULL,
	[MaThuoc] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[SoLuongNhap] [int] NOT NULL,
	[DonGiaNhap] [float] NOT NULL,
	[ThanhTien] [float] NOT NULL,
 CONSTRAINT [PK_dbo.CT_PHIEUNHAPTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaPNT] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONTHUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONTHUOC](
	[MaDonThuoc] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LoiDan] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DONTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaDonThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GROUP]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GROUP](
	[MaNhom] [nvarchar](128) NOT NULL,
	[TenNhom] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.GROUP] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHoaDon] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ChiTiet] [nvarchar](max) NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[LoaiHoaDon] [int] NOT NULL,
	[MaBenhNhan] [nvarchar](128) NOT NULL,
	[MaNhanVien] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNhanVien] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[SoDienThoai] [nvarchar](20) NOT NULL,
	[SoCMND] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[MaPhong] [nvarchar](128) NOT NULL,
	[MaNhom] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUNHAPTHUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAPTHUOC](
	[MaPNT] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TongTien] [float] NOT NULL,
	[MaDuocSi] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.PHIEUNHAPTHUOC] PRIMARY KEY CLUSTERED 
(
	[MaPNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[MaPhong] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[TenPhong] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.PHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PKCHUYENKHOA]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PKCHUYENKHOA](
	[MaPKCK] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[NgayKham] [datetime] NOT NULL,
	[YeuCau] [nvarchar](max) NULL,
	[KetQua] [nvarchar](max) NOT NULL,
	[MaNhanVien] [nvarchar](128) NOT NULL,
	[MaPKDaKhoa] [nvarchar](128) NOT NULL,
	[MaBacSi] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.PKCHUYENKHOA] PRIMARY KEY CLUSTERED 
(
	[MaPKCK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PKDAKHOA]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PKDAKHOA](
	[MaPKDK] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[NgayKham] [datetime] NOT NULL,
	[TrieuChung] [nvarchar](max) NULL,
	[ChanDoan] [nvarchar](max) NULL,
	[MaBenhNhan] [nvarchar](128) NOT NULL,
	[MaNhanVien] [nvarchar](128) NOT NULL,
	[MaBacSi] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.PKDAKHOA] PRIMARY KEY CLUSTERED 
(
	[MaPKDK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[TenThamSo] [nvarchar](50) NOT NULL,
	[GiaTri] [int] NOT NULL,
 CONSTRAINT [PK_dbo.THAMSO] PRIMARY KEY CLUSTERED 
(
	[TenThamSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUOC]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUOC](
	[MaThuoc] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DonVi] [nvarchar](50) NOT NULL,
	[TenThuoc] [nvarchar](50) NOT NULL,
	[CongDung] [nvarchar](max) NULL,
	[DonGia] [float] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_dbo.THUOC] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaNhanVien]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaNhanVien] ON [dbo].[ACCOUNT]
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Username]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Username] ON [dbo].[ACCOUNT]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaThuoc]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaThuoc] ON [dbo].[BC_SUDUNGTHUOC]
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SoCMND]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SoCMND] ON [dbo].[BENHNHAN]
(
	[SoCMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Thang_Nam]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_Thang_Nam] ON [dbo].[CT_BCDOANHTHU]
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaCachDung]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaCachDung] ON [dbo].[CT_DONTHUOC]
(
	[MaCachDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaDonThuoc]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaDonThuoc] ON [dbo].[CT_DONTHUOC]
(
	[MaDonThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaThuoc]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaThuoc] ON [dbo].[CT_DONTHUOC]
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaHoaDon]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaHoaDon] ON [dbo].[CT_HOADONTHUOC]
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaThuoc]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaThuoc] ON [dbo].[CT_HOADONTHUOC]
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaPNT]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaPNT] ON [dbo].[CT_PHIEUNHAPTHUOC]
(
	[MaPNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaThuoc]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaThuoc] ON [dbo].[CT_PHIEUNHAPTHUOC]
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaDonThuoc]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaDonThuoc] ON [dbo].[DONTHUOC]
(
	[MaDonThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaBenhNhan]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaBenhNhan] ON [dbo].[HOADON]
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaNhanVien]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaNhanVien] ON [dbo].[HOADON]
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaNhom]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaNhom] ON [dbo].[NHANVIEN]
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaPhong]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaPhong] ON [dbo].[NHANVIEN]
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SoCMND]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SoCMND] ON [dbo].[NHANVIEN]
(
	[SoCMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaDuocSi]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaDuocSi] ON [dbo].[PHIEUNHAPTHUOC]
(
	[MaDuocSi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaBacSi]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaBacSi] ON [dbo].[PKCHUYENKHOA]
(
	[MaBacSi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaNhanVien]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaNhanVien] ON [dbo].[PKCHUYENKHOA]
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaPKDaKhoa]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaPKDaKhoa] ON [dbo].[PKCHUYENKHOA]
(
	[MaPKDaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaBacSi]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaBacSi] ON [dbo].[PKDAKHOA]
(
	[MaBacSi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaBenhNhan]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaBenhNhan] ON [dbo].[PKDAKHOA]
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MaNhanVien]    Script Date: 20/12/2020 10:39:36 CH ******/
CREATE NONCLUSTERED INDEX [IX_MaNhanVien] ON [dbo].[PKDAKHOA]
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ACCOUNT_dbo.NHANVIEN_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ACCOUNT] CHECK CONSTRAINT [FK_dbo.ACCOUNT_dbo.NHANVIEN_MaNhanVien]
GO
ALTER TABLE [dbo].[BC_SUDUNGTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BC_SUDUNGTHUOC_dbo.THUOC_MaThuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BC_SUDUNGTHUOC] CHECK CONSTRAINT [FK_dbo.BC_SUDUNGTHUOC_dbo.THUOC_MaThuoc]
GO
ALTER TABLE [dbo].[CT_BCDOANHTHU]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_BCDOANHTHU_dbo.BC_DOANHTHU_Thang_Nam] FOREIGN KEY([Thang], [Nam])
REFERENCES [dbo].[BC_DOANHTHU] ([Thang], [Nam])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_BCDOANHTHU] CHECK CONSTRAINT [FK_dbo.CT_BCDOANHTHU_dbo.BC_DOANHTHU_Thang_Nam]
GO
ALTER TABLE [dbo].[CT_DONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_DONTHUOC_dbo.CACHDUNG_MaCachDung] FOREIGN KEY([MaCachDung])
REFERENCES [dbo].[CACHDUNG] ([MaCachDung])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_DONTHUOC] CHECK CONSTRAINT [FK_dbo.CT_DONTHUOC_dbo.CACHDUNG_MaCachDung]
GO
ALTER TABLE [dbo].[CT_DONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_DONTHUOC_dbo.DONTHUOC_MaDonThuoc] FOREIGN KEY([MaDonThuoc])
REFERENCES [dbo].[DONTHUOC] ([MaDonThuoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_DONTHUOC] CHECK CONSTRAINT [FK_dbo.CT_DONTHUOC_dbo.DONTHUOC_MaDonThuoc]
GO
ALTER TABLE [dbo].[CT_DONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_DONTHUOC_dbo.THUOC_MaThuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_DONTHUOC] CHECK CONSTRAINT [FK_dbo.CT_DONTHUOC_dbo.THUOC_MaThuoc]
GO
ALTER TABLE [dbo].[CT_HOADONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_HOADONTHUOC_dbo.HOADON_MaHoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOADON] ([MaHoaDon])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_HOADONTHUOC] CHECK CONSTRAINT [FK_dbo.CT_HOADONTHUOC_dbo.HOADON_MaHoaDon]
GO
ALTER TABLE [dbo].[CT_HOADONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_HOADONTHUOC_dbo.THUOC_MaThuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_HOADONTHUOC] CHECK CONSTRAINT [FK_dbo.CT_HOADONTHUOC_dbo.THUOC_MaThuoc]
GO
ALTER TABLE [dbo].[CT_PHIEUNHAPTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_PHIEUNHAPTHUOC_dbo.PHIEUNHAPTHUOC_MaPNT] FOREIGN KEY([MaPNT])
REFERENCES [dbo].[PHIEUNHAPTHUOC] ([MaPNT])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_PHIEUNHAPTHUOC] CHECK CONSTRAINT [FK_dbo.CT_PHIEUNHAPTHUOC_dbo.PHIEUNHAPTHUOC_MaPNT]
GO
ALTER TABLE [dbo].[CT_PHIEUNHAPTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CT_PHIEUNHAPTHUOC_dbo.THUOC_MaThuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_PHIEUNHAPTHUOC] CHECK CONSTRAINT [FK_dbo.CT_PHIEUNHAPTHUOC_dbo.THUOC_MaThuoc]
GO
ALTER TABLE [dbo].[DONTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DONTHUOC_dbo.PKDAKHOA_MaDonThuoc] FOREIGN KEY([MaDonThuoc])
REFERENCES [dbo].[PKDAKHOA] ([MaPKDK])
GO
ALTER TABLE [dbo].[DONTHUOC] CHECK CONSTRAINT [FK_dbo.DONTHUOC_dbo.PKDAKHOA_MaDonThuoc]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HOADON_dbo.BENHNHAN_MaBenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BENHNHAN] ([MaBenhNhan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_dbo.HOADON_dbo.BENHNHAN_MaBenhNhan]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HOADON_dbo.NHANVIEN_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_dbo.HOADON_dbo.NHANVIEN_MaNhanVien]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NHANVIEN_dbo.GROUP_MaNhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[GROUP] ([MaNhom])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_dbo.NHANVIEN_dbo.GROUP_MaNhom]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NHANVIEN_dbo.PHONG_MaPhong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_dbo.NHANVIEN_dbo.PHONG_MaPhong]
GO
ALTER TABLE [dbo].[PHIEUNHAPTHUOC]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PHIEUNHAPTHUOC_dbo.NHANVIEN_MaDuocSi] FOREIGN KEY([MaDuocSi])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHIEUNHAPTHUOC] CHECK CONSTRAINT [FK_dbo.PHIEUNHAPTHUOC_dbo.NHANVIEN_MaDuocSi]
GO
ALTER TABLE [dbo].[PKCHUYENKHOA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PKCHUYENKHOA_dbo.NHANVIEN_MaBacSi] FOREIGN KEY([MaBacSi])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PKCHUYENKHOA] CHECK CONSTRAINT [FK_dbo.PKCHUYENKHOA_dbo.NHANVIEN_MaBacSi]
GO
ALTER TABLE [dbo].[PKCHUYENKHOA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PKCHUYENKHOA_dbo.NHANVIEN_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PKCHUYENKHOA] CHECK CONSTRAINT [FK_dbo.PKCHUYENKHOA_dbo.NHANVIEN_MaNhanVien]
GO
ALTER TABLE [dbo].[PKCHUYENKHOA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PKCHUYENKHOA_dbo.PKDAKHOA_MaPKDaKhoa] FOREIGN KEY([MaPKDaKhoa])
REFERENCES [dbo].[PKDAKHOA] ([MaPKDK])
GO
ALTER TABLE [dbo].[PKCHUYENKHOA] CHECK CONSTRAINT [FK_dbo.PKCHUYENKHOA_dbo.PKDAKHOA_MaPKDaKhoa]
GO
ALTER TABLE [dbo].[PKDAKHOA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PKDAKHOA_dbo.BENHNHAN_MaBenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BENHNHAN] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[PKDAKHOA] CHECK CONSTRAINT [FK_dbo.PKDAKHOA_dbo.BENHNHAN_MaBenhNhan]
GO
ALTER TABLE [dbo].[PKDAKHOA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PKDAKHOA_dbo.NHANVIEN_MaBacSi] FOREIGN KEY([MaBacSi])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PKDAKHOA] CHECK CONSTRAINT [FK_dbo.PKDAKHOA_dbo.NHANVIEN_MaBacSi]
GO
ALTER TABLE [dbo].[PKDAKHOA]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PKDAKHOA_dbo.NHANVIEN_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PKDAKHOA] CHECK CONSTRAINT [FK_dbo.PKDAKHOA_dbo.NHANVIEN_MaNhanVien]
GO
/****** Object:  StoredProcedure [dbo].[proc_Benh_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----insert benh proc
create Proc [dbo].[proc_Benh_insert]
	@tenbenh nvarchar(50)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'BE'
		select @max = COUNT(*) from BENH
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into BENH values (@id, 0, @tenbenh)
		select @id
	END;
GO
/****** Object:  StoredProcedure [dbo].[proc_BenhNhan_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_BenhNhan_insert]
    @hoten nvarchar(50),
    @ngaysinh datetime,
    @gt bit,
    @diachi nvarchar(MAX),
    @sdt nvarchar(20),
    @cmnd nvarchar(20),
    @email nvarchar(50)
AS
BEGIN
    BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(2) = 'BN'
        select @max = COUNT(*) from BENHNHAN
        set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
        insert into BENHNHAN values (@id, @hoten, @ngaysinh, @gt, @diachi, @sdt, @cmnd, @email, 0)
        select @id
        return -9999
    END TRY
    BEGIN CATCH
        declare @code varchar(10)
        set @code = ERROR_NUMBER()
        select @code
        return ERROR_STATE()
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_CachDung_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from BENH
--exec proc_Benh_insert 'HIV'

----insert cachdung proc
create Proc [dbo].[proc_CachDung_insert]
	@tencachdung nvarchar(50)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'CD'
		select @max = COUNT(*) from CACHDUNG
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into CACHDUNG values (@id, 0, @tencachdung)
		select @id
	END;
GO
/****** Object:  StoredProcedure [dbo].[proc_DonThuoc_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------V2.3----------------
--Alter DonThuoc proc
CREATE Proc [dbo].[proc_DonThuoc_insert]
	@id		nvarchar(max),
	@loidan nvarchar(max)
AS
	BEGIN

		insert into DONTHUOC values (@id, 0, @loidan)
		select @id
	END;
GO
/****** Object:  StoredProcedure [dbo].[proc_HoaDon_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[proc_HoaDon_insert]
	@chitiet nvarchar(max),
	@thanhtien float,
	@ngaylap datetime,
	@loaihoadon int,
	@mabenhnhan nvarchar(128),
	@manhanvien nvarchar(128)
AS
BEGIN
	BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(2) = 'HD'
		select @max = COUNT(*) from HOADON
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		if @loaihoadon = 2
			set @thanhtien = 0
		insert into HOADON values (@id, 0, @chitiet, @thanhtien, @ngaylap, @loaihoadon, @mabenhnhan, @manhanvien)
		select @id
        return -9999
    END TRY
    BEGIN CATCH
        --declare @code varchar(10)
        --set @code = ERROR_NUMBER()
        --select @code
		select ERROR_MESSAGE()
        return ERROR_STATE()
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_NhanVien_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_NhanVien_insert]
	@hoten nvarchar(50),
	@ngaysinh datetime,
	@gt bit,
	@diachi nvarchar(MAX),
	@sdt nvarchar(20),
	@cmnd nvarchar(20),
	@email nvarchar(50),
	@manhom nvarchar(128),
	@maphong nvarchar(128)
AS
	BEGIN
		BEGIN TRY
			declare @id nvarchar(128), @max int, @prefix varchar(2) = 'NV'
			select @max = COUNT(*) from NHANVIEN
			set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
			insert into NHANVIEN values (@id, 0, @hoten, @ngaysinh, @gt, @diachi, @sdt, @cmnd, @email, @maphong, @manhom)
			select @id
			return -9999
		END TRY
		BEGIN CATCH
			declare @code varchar(10)
			set @code = ERROR_NUMBER()
			select @code
			return ERROR_STATE()
		END CATCH;
	END;
GO
/****** Object:  StoredProcedure [dbo].[proc_Phong_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from PKCHUYENKHOA
--exec proc_PKCK_insert '2020-2-2', 'Noi soi tim', 'NV00001'

--insert Phong proc
create Proc [dbo].[proc_Phong_insert]
	@tenphong nvarchar(max)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'PH'
		select @max = COUNT(*) from PHONG
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PHONG values (@id, 0, @tenphong)
		select @id
	END;
GO
/****** Object:  StoredProcedure [dbo].[proc_PKCK_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------V2.2-----------------------------------
CREATE Proc [dbo].[proc_PKCK_insert]
	@ngaykham datetime,
	@yeucau nvarchar(max),
	@manhanvien nvarchar(128),
	@maphieukhamdakhoa nvarchar(128)
AS
BEGIN
	BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(4) = 'PKCK'
		select @max = COUNT(*) from PKCHUYENKHOA
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PKCHUYENKHOA values (@id, 0, @ngaykham, @yeucau, '', @manhanvien, @maphieukhamdakhoa, null)
		select @id
        return -9999
    END TRY
    BEGIN CATCH
        declare @code varchar(10)
        set @code = ERROR_NUMBER()
        --select @code
		select ERROR_MESSAGE()
        return ERROR_STATE()
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_PKDK_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[proc_PKDK_insert]
	@ngaykham datetime,
	@mabenhnhan nvarchar(128),
	@manhanvien nvarchar(128)
AS
BEGIN
	BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(4) = 'PKDK'
		select @max = COUNT(*) from PKDAKHOA
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PKDAKHOA values (@id, 0, @ngaykham, null, null, @mabenhnhan, @manhanvien, null)
		select @id
        return -9999
    END TRY
    BEGIN CATCH
        declare @code varchar(10)
        set @code = ERROR_NUMBER()
        --select @code
		select ERROR_MESSAGE()
        return ERROR_STATE()
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_PNhapThuoc_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from PHONG
--exec proc_Phong_insert 'Phong noi soi'

--insert PhieuNhapThuoc proc
create Proc [dbo].[proc_PNhapThuoc_insert]
	@ngaynhap datetime,
	@maduocsi nvarchar(128)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(3) = 'PNT'
		select @max = COUNT(*) from PHIEUNHAPTHUOC
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PHIEUNHAPTHUOC values (@id, 0, @ngaynhap, 0, @maduocsi)
		select @id
	END;
GO
/****** Object:  StoredProcedure [dbo].[proc_Thuoc_insert]    Script Date: 20/12/2020 10:39:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from CACHDUNG
--exec proc_CachDung_insert 'Ngay 3 lan'


----insert Thuoc proc
create Proc [dbo].[proc_Thuoc_insert]
	@donvi nvarchar(50),
	@tenthuoc nvarchar(50),
	@congdung nvarchar(max),
	@dongia float,
	@soluong int
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'TH'
		select @max = COUNT(*) from THUOC
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into THUOC values (@id, 0, @donvi, @tenthuoc, @congdung, @dongia, @soluong)
		select @id
	END;
GO
USE [master]
GO
ALTER DATABASE [HMS] SET  READ_WRITE 
GO
