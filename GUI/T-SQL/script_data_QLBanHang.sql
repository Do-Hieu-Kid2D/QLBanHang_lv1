USE [master]
GO
/****** Object:  Database [BanHanglv1]    Script Date: 30/05/2023 5:35:02 SA ******/
CREATE DATABASE [BanHanglv1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BanHanglv1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SEVERID\MSSQL\DATA\BanHanglv1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BanHanglv1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SEVERID\MSSQL\DATA\BanHanglv1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BanHanglv1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BanHanglv1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BanHanglv1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BanHanglv1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BanHanglv1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BanHanglv1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BanHanglv1] SET ARITHABORT OFF 
GO
ALTER DATABASE [BanHanglv1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BanHanglv1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BanHanglv1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BanHanglv1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BanHanglv1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BanHanglv1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BanHanglv1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BanHanglv1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BanHanglv1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BanHanglv1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BanHanglv1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BanHanglv1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BanHanglv1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BanHanglv1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BanHanglv1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BanHanglv1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BanHanglv1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BanHanglv1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BanHanglv1] SET  MULTI_USER 
GO
ALTER DATABASE [BanHanglv1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BanHanglv1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BanHanglv1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BanHanglv1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BanHanglv1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BanHanglv1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BanHanglv1] SET QUERY_STORE = ON
GO
ALTER DATABASE [BanHanglv1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BanHanglv1]
GO
/****** Object:  UserDefinedFunction [dbo].[maHang_NhapTrongNgay]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
		create function [dbo].[maHang_NhapTrongNgay]
	(
		@ngay  int = 11,
		@thang  int =5,
		@nam  int = 2023
	) 
	RETURNS 
	@KQ TABLE(maHang nvarchar(20), tienNhap int)
	as
	begin
	insert into @KQ(maHang,tienNhap)
	select  CHITIETDONHANG.maHang, sum(  CHITIETDONHANG.soLuong * MATHANG.giaBan) from (CHITIETDONHANG inner join DONDATHANG on CHITIETDONHANG.soHoaDon = DONDATHANG.soHoaDon )
	inner join MATHANG on CHITIETDONHANG.maHang = MATHANG.maHang 
	-- where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
	where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
	group by CHITIETDONHANG.maHang
	
	return
	end
GO
/****** Object:  UserDefinedFunction [dbo].[maHang_TienTrongNgay]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE function [dbo].[maHang_TienTrongNgay]
	(
		@ngay  int = 11,
		@thang  int =5,
		@nam  int = 2023
	) 
	RETURNS 
	@KQ TABLE(maHang nvarchar(20), tienBan int)
	as
	begin
	insert into @KQ(maHang,tienBan)
	select CHITIETDONHANG.maHang, sum( (MATHANG.giaBan - (MATHANG.giaBan * CHITIETDONHANG.mucGiamGia)) * CHITIETDONHANG.soluong) from (CHITIETDONHANG inner join DONDATHANG on CHITIETDONHANG.soHoaDon = DONDATHANG.soHoaDon )
	inner join MATHANG on CHITIETDONHANG.maHang = MATHANG.maHang 
	where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
	group by CHITIETDONHANG.maHang
	
	return
	end
GO
/****** Object:  UserDefinedFunction [dbo].[tinhTongTien]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Tạo hàm tính tổng tiền 1 đơn hàng khi truyền vào số hóa đơn!
CREATE FUNCTION [dbo].[tinhTongTien]
(
	@soHD NVARCHAR(20)
)
RETURNS money 
BEGIN
	DECLARE @soHDT NVARCHAR(20)
	DECLARE @rowCount INT
	DECLARE @col INT
	DECLARE @sl INT;
	DECLARE @mucGiam real;
	DECLARE @giaBan real;
	DECLARE @tongTienChuan money;
	-- DECLARE @tongTienChuan real;
	
	SET @col = 1
	set @tongTienChuan = 0;
	set @soHDT = @soHD;
	with T1 as
		(
		SELECT C.soLuong,C.mucGiamGia,M.giaBan FROM CHITIETDONHANG C INNER JOIN MATHANG M ON M.maHang = C.maHang WHERE C.soHoaDon = @soHDT
		)
		select @rowCount = count(*) from T1
    WHILE(@col <= @rowCount)
		BEGIN
		with T as
		(
		SELECT C.soLuong,C.mucGiamGia,M.giaBan FROM CHITIETDONHANG C INNER JOIN MATHANG M ON M.maHang = C.maHang WHERE C.soHoaDon = @soHDT
		)
		SELECT @sl = soLuong, @mucGiam = mucGiamGia, @giaBan = giaBan
		FROM (
				SELECT soLuong, mucGiamGia, giaBan, ROW_NUMBER() OVER (ORDER BY soLuong) AS RowNum
				FROM T
			) AS Subquery
			WHERE RowNum = @col
		set @tongTienChuan = @tongTienChuan + @sl * (@giaBan - (@giaBan * @mucGiam))
		SET @col = @col + 1
	   END
	   return @tongTienChuan 
		
END

GO
/****** Object:  UserDefinedFunction [dbo].[tinhTongTienHDTheoGiaNhap]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[tinhTongTienHDTheoGiaNhap]
(
	@soHD NVARCHAR(20)
)
RETURNS money 
BEGIN
	DECLARE @rowCount INT
	DECLARE @col INT
	DECLARE @sl INT;
	DECLARE @giaNhapHang real;
	DECLARE @tongTienChuan money;
	-- DECLARE @tongTienChuan real;
	
	SET @col = 1
	set @tongTienChuan = 0;
	with T1 as
		(
		SELECT C.soLuong,M.giaNhap FROM CHITIETDONHANG C INNER JOIN MATHANG M ON M.maHang = C.maHang WHERE C.soHoaDon = @soHD
		)
		select @rowCount = count(*) from T1
    WHILE(@col <= @rowCount)
		BEGIN
		with T as
		(
		SELECT C.soLuong,M.giaNhap as gn FROM CHITIETDONHANG C INNER JOIN MATHANG M ON M.maHang = C.maHang WHERE C.soHoaDon = @soHD
		)
		SELECT @sl = soLuong, @giaNhapHang = gn
		FROM (
				SELECT soLuong, gn , ROW_NUMBER() OVER (ORDER BY soLuong) AS RowNum
				FROM T
			) AS Subquery
			WHERE RowNum = @col
		set @tongTienChuan = @tongTienChuan + (@sl *@giaNhapHang)
		SET @col = @col + 1
	   END
	   return @tongTienChuan 
		
END
GO
/****** Object:  UserDefinedFunction [dbo].[tinhTongTienNhap]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[tinhTongTienNhap]
(
	@soHD NVARCHAR(20)
)
RETURNS money 
BEGIN
	DECLARE @soHDT NVARCHAR(20)
	DECLARE @rowCount INT
	DECLARE @col INT
	DECLARE @sl INT;
	DECLARE @giaNhap real;
	DECLARE @tongTienChuan money;
	-- DECLARE @tongTienChuan real;
	
	SET @col = 1
	set @tongTienChuan = 0;
	set @soHDT = @soHD;
	with T1 as
		(
		SELECT C.soLuong,C.mucGiamGia,M.giaBan FROM CHITIETDONHANG C INNER JOIN MATHANG M ON M.maHang = C.maHang WHERE C.soHoaDon = @soHDT
		)
		select @rowCount = count(*) from T1
    WHILE(@col <= @rowCount)
		BEGIN
		with T as
		(
		SELECT C.soLuong,M.giaNhap FROM CHITIETDONHANG C INNER JOIN MATHANG M ON M.maHang = C.maHang WHERE C.soHoaDon = @soHDT
		)
		SELECT @sl = soLuong, @giaNhap = giaNhap
		FROM (
				SELECT soLuong, giaNhap, ROW_NUMBER() OVER (ORDER BY soLuong) AS RowNum
				FROM T
			) AS Subquery
			WHERE RowNum = @col
		set @tongTienChuan = @tongTienChuan + @sl * @giaNhap
		SET @col = @col + 1
	   END
	   return @tongTienChuan 
		
END
GO
/****** Object:  UserDefinedFunction [dbo].[TongThu1Ngay]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TongThu1Ngay]
(
	@ngay  int = 11,
	@thang  int =5,
	@nam  int = 2023
)
RETURNS money 
BEGIN
	DECLARE @rowCount INT
	DECLARE @col INT
	DECLARE @sl INT;
	DECLARE @tienBan money;
	DECLARE @tienNhap money
	DECLARE @tongTienLai money;
	-- DECLARE @tongTienChuan real;
	
	SET @col = 1
	set @tongTienLai = 0;
	with T1 as
		(
		SELECT soHoaDon FROM DONDATHANG where  Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
		)
		-- Bảng T có số hóa đơn ngày cần tính rồi - mục đích của đoạn này chỉ là đếm lượt vòng while
	select @rowCount = count(*) from T1
	declare @soHD nvarchar(20)
    WHILE(@col <= @rowCount)
		BEGIN
		with T as
		(
		SELECT soHoaDon FROM DONDATHANG where  Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
		)
		SELECT @soHD = soHoaDon 
		FROM (
				SELECT soHoaDon, ROW_NUMBER() OVER (ORDER BY soHoaDon) AS RowNum
				FROM T
			) AS Subquery
			WHERE RowNum = @col
		set @tienBan = dbo.tinhTongTien(@soHD)	
		set @tienNhap = dbo.tinhTongTienHDTheoGiaNhap(@soHD)
		set @tongTienLai += @tienBan - @tienNhap
		SET @col = @col + 1
	   END
	   return @tongTienLai  
END
GO
/****** Object:  Table [dbo].[CHITIETDONHANG]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDONHANG](
	[soHoaDon] [nvarchar](20) NOT NULL,
	[maHang] [nvarchar](20) NOT NULL,
	[soLuong] [int] NOT NULL,
	[mucGiamGia] [real] NOT NULL,
 CONSTRAINT [pk_chitietdathang] PRIMARY KEY CLUSTERED 
(
	[soHoaDon] ASC,
	[maHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONDATHANG]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONDATHANG](
	[soHoaDon] [nvarchar](20) NOT NULL,
	[maKhachHang] [nvarchar](20) NOT NULL,
	[maNhanVien] [nvarchar](20) NOT NULL,
	[ngayDatHang] [date] NOT NULL,
	[ngayGiaoHang] [date] NULL,
	[diaChiGiaoHang] [nvarchar](50) NULL,
	[mahinhThucThanhToan] [nvarchar](20) NULL,
	[tongTien] [varchar](15) NULL,
 CONSTRAINT [pk_dondathang] PRIMARY KEY CLUSTERED 
(
	[soHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[maKhachHang] [nvarchar](20) NOT NULL,
	[tenKhachHang] [nvarchar](50) NULL,
	[gioiTinh] [bit] NULL,
	[tenCongTy] [nvarchar](50) NULL,
	[diaChi] [nvarchar](100) NULL,
	[email] [nvarchar](30) NOT NULL,
	[dienThoai] [nvarchar](10) NOT NULL,
 CONSTRAINT [pk_khachhang] PRIMARY KEY CLUSTERED 
(
	[maKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIHANG]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIHANG](
	[maLoaiHang] [nvarchar](20) NOT NULL,
	[tenLoaiHang] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_loaiHang] PRIMARY KEY CLUSTERED 
(
	[maLoaiHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATHANG]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATHANG](
	[maHang] [nvarchar](20) NOT NULL,
	[tenHang] [nvarchar](50) NOT NULL,
	[maNhaCC] [nvarchar](20) NOT NULL,
	[maLoaiHang] [nvarchar](20) NOT NULL,
	[soluong] [int] NULL,
	[donViTinh] [nvarchar](50) NULL,
	[giaNhap] [money] NOT NULL,
	[giaBan] [money] NOT NULL,
	[hinhAnh] [varchar](100) NULL,
 CONSTRAINT [pk_matHang] PRIMARY KEY CLUSTERED 
(
	[maHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[maNhaCC] [nvarchar](20) NOT NULL,
	[tenNhaCC] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[dienThoai] [nvarchar](10) NULL,
	[email] [nvarchar](50) NULL,
	[nguoiDaiDien] [nvarchar](50) NULL,
 CONSTRAINT [pk_nhaCungCap] PRIMARY KEY CLUSTERED 
(
	[maNhaCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[maNhanVien] [nvarchar](20) NOT NULL,
	[hoVaTen] [nvarchar](50) NOT NULL,
	[gioiTinh] [bit] NULL,
	[ngaySinh] [date] NULL,
	[ngayLamViec] [date] NULL,
	[diaChi] [nvarchar](100) NOT NULL,
	[dienThoai] [nvarchar](10) NOT NULL,
	[luongCoBan] [money] NOT NULL,
	[phuCap] [money] NULL,
	[taiKhoan] [nvarchar](50) NOT NULL,
	[matKhau] [nvarchar](50) NOT NULL,
 CONSTRAINT [pk_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUANLY]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUANLY](
	[id] [nvarchar](10) NOT NULL,
	[taiKhoan] [nchar](50) NOT NULL,
	[matKhau] [nchar](50) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[ngaySinh] [date] NULL,
 CONSTRAINT [pk_idQuanLy] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[taiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THANHTOAN]    Script Date: 30/05/2023 5:35:02 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THANHTOAN](
	[mahinhThucThanhToan] [nvarchar](20) NOT NULL,
	[tenhinhThucThanhToan] [nvarchar](50) NULL,
 CONSTRAINT [pk_hinhThucThanhToan] PRIMARY KEY CLUSTERED 
(
	[mahinhThucThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'1', N'MH027', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'12112', N'MH014', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'12112', N'MH023', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'121s', N'MH011', 2, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'121s', N'MH015', 3, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'121s', N'MH022', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'121s', N'MH023', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'123', N'MH012', 23, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'123', N'MH022', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'123x', N'MH011', 1, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'123x', N'MH013', 2, 0.03)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'123x', N'MH023', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'13', N'MH012', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'13', N'MH018', 11, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'13', N'MH029', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'21', N'MH005', 123, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'21', N'MH030', 12, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'301', N'MH007', 2, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'301', N'MH018', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'301', N'MH023', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'302', N'MH013', 12, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'302', N'MH023', 2, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'302', N'MH024', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'a', N'MH001', 123, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'aa', N'MH020', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'asx', N'MH020', 123, 0.43)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'asx', N'MH023', 12, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'asx', N'MH024', 12, 0.32)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'asx', N'MH025', 132, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'bbb', N'MH008', 1, 0.09)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'bbb', N'MH015', 20, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'bbb', N'MH016', 3, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'bbb', N'MH023', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'bbb', N'MH026', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'cx', N'MH025', 111, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'd', N'MH008', 25, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'd', N'MH017', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'd', N'MH018', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'd', N'MH023', 12, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'da', N'MH021', 54, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'dfd', N'MH019', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'dfd', N'MH024', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH001', N'MH001', 5, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH001', N'MH004', 5, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH001', N'MH006', 8, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH001', N'MH009', 8, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH001', N'MH019', 10, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH002', N'MH001', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH002', N'MH003', 3, 0.15)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH002', N'MH006', 2, 0.4)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH002', N'MH017', 3, 0.15)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH002', N'MH030', 7, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH003', N'MH004', 4, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH003', N'MH006', 6, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH003', N'MH007', 9, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH004', N'MH001', 1, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH004', N'MH002', 3, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH004', N'MH003', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH004', N'MH007', 3, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH004', N'MH008', 1, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH005', N'MH005', 6, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH005', N'MH012', 4, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH005', N'MH013', 2, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH006', N'MH013', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH006', N'MH016', 7, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH006', N'MH021', 3, 0.03)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH006', N'MH024', 5, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH006', N'MH026', 7, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH007', N'MH005', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH007', N'MH019', 5, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH007', N'MH020', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH007', N'MH030', 8, 0.15)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH008', N'MH018', 4, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH008', N'MH023', 3, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH008', N'MH024', 6, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH009', N'MH001', 7, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH009', N'MH019', 5, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH009', N'MH022', 4, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH009', N'MH025', 1, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH009', N'MH026', 7, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH009', N'MH027', 9, 0.002)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH010', N'MH002', 3, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH010', N'MH020', 4, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH010', N'MH028', 5, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH010', N'MH029', 2, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH011', N'MH016', 1, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH011', N'MH017', 3, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH011', N'MH019', 8, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH011', N'MH029', 6, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH012', N'MH004', 6, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH012', N'MH011', 4, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH012', N'MH015', 3, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH012', N'MH019', 2, 0.07)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH012', N'MH021', 9, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH013', N'MH011', 5, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH013', N'MH017', 1, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH013', N'MH022', 4, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH014', N'MH002', 3, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH014', N'MH009', 6, 0.2)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH014', N'MH011', 7, 0.05)
GO
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH014', N'MH012', 2, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH014', N'MH028', 9, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH015', N'MH001', 4, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH015', N'MH012', 5, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'DH015', N'MH022', 8, 0.15)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'dxa', N'MH006', 12, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'dxa', N'MH009', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'dxa', N'MH012', 1, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'dxa', N'MH023', 1, 0.1)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'HD1', N'MH022', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'HD1', N'MH030', 1, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'HD201', N'MH004', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'HD201', N'MH009', 1, 0.05)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'HD201', N'MH023', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'l', N'MH008', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'l', N'MH009', 123, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'l', N'MH016', 121, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'l', N'MH026', 123, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'ngon', N'MH022', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'ngon', N'MH024', 2, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'ngon', N'MH027', 3, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N's', N'MH006', 11, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N's', N'MH007', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N's', N'MH015', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sa', N'MH010', 12, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sa', N'MH014', 12, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sa', N'MH017', 1, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sa', N'MH024', 1, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sá', N'MH028', 54, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sda', N'MH011', 3, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sda', N'MH016', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'sda', N'MH023', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'so1', N'MH019', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'so1', N'MH023', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'vip', N'MH012', 4, 0.04)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'vip', N'MH014', 10, 0.5)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'vip', N'MH025', 1, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'vip', N'MH027', 2, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'vv', N'MH004', 39, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'x', N'MH030', 19, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'xxx', N'MH010', 33, 0.02)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'xxx', N'MH013', 23, 0.01)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'xxx', N'MH023', 1, 0)
INSERT [dbo].[CHITIETDONHANG] ([soHoaDon], [maHang], [soLuong], [mucGiamGia]) VALUES (N'xxx', N'MH024', 1, 0.01)
GO
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'1', N'KH003', N'NV001', CAST(N'2023-05-29' AS Date), CAST(N'2023-05-31' AS Date), N'1', N'NH', N'4280000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'12112', N'KH003', N'NV001', CAST(N'2023-05-29' AS Date), CAST(N'2023-05-29' AS Date), N'2', N'TM', N'410000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'121s', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'12', N'NH', N'1604000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'123', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'1', N'NH', N'1104000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'123x', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'123', N'NH', N'534800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'13', N'KH004', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'11', N'ATM', N'35002800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'21', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'1', N'NH', N'11640000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'301', N'KH005', N'NV001', CAST(N'2023-05-30' AS Date), CAST(N'2023-05-30' AS Date), N'1', N'NH', N'36100000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'302', N'KH004', N'NV001', CAST(N'2023-05-30' AS Date), CAST(N'2023-05-30' AS Date), N'`', N'PAYPAL', N'46992000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'a', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'a', N'PAYPAL', N'4822800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'aa', N'KH003', N'NV001', CAST(N'2023-05-25' AS Date), CAST(N'2023-05-25' AS Date), N'a', N'NH', N'673000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'asx', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'q', N'PAYPAL', N'2246800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'bbb', N'KH003', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'de', N'NH', N'1598500')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'cx', N'KH003', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'xxxx', N'NH', N'2012800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'd', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'd', N'NH', N'25880000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'da', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N's', N'NH', N'13850200')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'dfd', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N's', N'ATM', N'10098000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH001', N'KH001', N'NV001', CAST(N'2023-03-03' AS Date), CAST(N'2023-05-05' AS Date), N'123 ABC, Hà Nội', N'ATM', N'1000000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH002', N'KH002', N'NV002', CAST(N'2023-05-06' AS Date), CAST(N'2023-05-08' AS Date), N'456 XYZ, Quận ACD, TP.HCM', N'NH', N'1220000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH003', N'KH003', N'NV003', CAST(N'2023-05-07' AS Date), CAST(N'2023-05-09' AS Date), N'456 XYZ, Hải Phòng', N'PAYPAL', N'4800000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH004', N'KH004', N'NV004', CAST(N'2023-05-08' AS Date), CAST(N'2023-05-10' AS Date), N'321 LMN, Quận 4, TP.HCM', N'ATM', N'1211000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH005', N'KH005', N'NV002', CAST(N'2023-05-09' AS Date), CAST(N'2023-05-11' AS Date), N'321 LMN, Bắc Ninh', N'TM', N'3240000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH006', N'KH006', N'NV003', CAST(N'2023-05-10' AS Date), CAST(N'2023-05-12' AS Date), N'789 ABC, Thái Nguyên', N'NH', N'87000000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH007', N'KH007', N'NV005', CAST(N'2023-05-11' AS Date), CAST(N'2023-05-13' AS Date), N'321 XYZ, Lạng Sơn', N'TM', N'4500000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH008', N'KH008', N'NV002', CAST(N'2023-05-12' AS Date), CAST(N'2023-05-14' AS Date), N'654 KLM, Hưng Yên', N'ATM', N'8677000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH009', N'KH009', N'NV003', CAST(N'2023-05-13' AS Date), CAST(N'2023-05-15' AS Date), N'456 PQR, Yên Bái', N'TM', N'424243')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH010', N'KH010', N'NV004', CAST(N'2023-05-14' AS Date), CAST(N'2023-05-16' AS Date), N'987 LMN, Hà Nam', N'TM', N'6238000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH011', N'KH011', N'NV002', CAST(N'2023-05-15' AS Date), CAST(N'2023-05-17' AS Date), N'654 MNP, Bắc Giang', N'TTD', N'2322100')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH012', N'KH012', N'NV003', CAST(N'2023-05-16' AS Date), CAST(N'2023-05-18' AS Date), N'789 ABC, Sơn La', N'TTD', N'56490000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH013', N'KH013', N'NV001', CAST(N'2023-05-17' AS Date), CAST(N'2023-05-19' AS Date), N'321 Đường XYZ, Tuyên Quang', N'NH', N'3432000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH014', N'KH014', N'NV005', CAST(N'2023-05-18' AS Date), CAST(N'2023-05-20' AS Date), N'654 MNP, Lào Cai', N'VNP', N'3425000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'DH015', N'KH015', N'NV004', CAST(N'2023-05-19' AS Date), CAST(N'2023-05-21' AS Date), N'654 MNP, Quận ABD, TP.HCM', N'VNP', N'8000000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'dxa', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'a', N'ATM', N'1124400')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'HD1', N'KH002', N'NV001', CAST(N'2023-05-27' AS Date), CAST(N'2023-05-27' AS Date), N'Xóm Hanh - Nhã L?ng - Phú Bình - Thái Nguyên', N'VNP', N'1900000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'Hd2', N'KH008', N'NV001', CAST(N'2023-05-27' AS Date), CAST(N'2023-05-27' AS Date), N'Xóm Trung2 - Nhã L?ng - Phú Bình -TN', N'VNP', NULL)
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'HD201', N'KH003', N'NV001', CAST(N'2023-05-27' AS Date), CAST(N'2023-05-27' AS Date), N'Xóm Hanh - Nhã Lộng - Phú Bình - Thái Nguyên', N'VNP', N'2110000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'ii', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'i', N'NH', NULL)
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'l', N'KH009', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'l', N'NH', N'626490000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'ngon', N'KH012', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'1234tgf', N'PAYPAL', N'1342000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N's', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N's', N'ATM', N'1058400')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'sa', N'KH003', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'a', N'NH', N'16302400')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'sá', N'KH003', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'a', N'NH', N'521022800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'sda', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'ádf', N'PAYPAL', N'850000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'so1', N'KH003', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'1', N'PAYPAL', N'12300000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'vip', N'KH007', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'3edsc', N'PAYPAL', N'6228000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'vv', N'KH002', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'v', N'NH', N'18502800')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'x', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'z', N'ATM', N'26060000')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'xxx', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'c', N'ATM', N'1385900')
INSERT [dbo].[DONDATHANG] ([soHoaDon], [maKhachHang], [maNhanVien], [ngayDatHang], [ngayGiaoHang], [diaChiGiaoHang], [mahinhThucThanhToan], [tongTien]) VALUES (N'xxxz', N'KH001', N'NV001', CAST(N'2023-05-28' AS Date), CAST(N'2023-05-28' AS Date), N'z', N'ATM', NULL)
GO
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH001', N'Nguyễn Văn Anh', 1, N'Công ty ABC', N'Số 10, Lê Hồng Phong, Quang Trung, Hà Nội', N'nguyenvana@cany.com', N'0123456789')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH002', N'Trần thị Bắc', 0, N'Công ty XYZ', N'53 Lý Tự Trọng, Phường Bến Thành, Quận 1,Hồ Chí Minh', N'tranthib@any.com', N'0987654321')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH003', N'Phạm văn Sáng', 1, N'Công ty DEF', N'112 Nguyễn Văn Linh, Hải Châu, Đà Nẵng', N'phamvanc@any.com', N'0123123123')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH004', N'Lê Hồng Đào', 0, N'Công ty UVW', N'23 Võ Thị Sáu, Thống Nhất, Biên Hòa, Đồng Nai', N'lethid@any.com', N'0909090909')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH005', N'Võ Văn Mạnh', 1, N'Công ty GHI', N'63 Nguyễn Thái Học, Phường 4, Tuy Hòa, Phú Yên', N'vovane@any.com', N'0989898989')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH006', N'Nguyễn Hồng Hương', 0, N'Công ty KLM', N'98 Trần Hưng Đạo, Trung Đô, Vinh, Nghệ An', N'nguyenthif@any.com', N'0908080808')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH007', N'trần Văn Giang', 1, N'Công ty PQR', N'115 Hoàng Diệu 2, Linh Chiểu, TP. Thủ Đức, TPHCM', N'tranvang@any.com', N'0999999999')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH008', N'Phạm Thị Lý', 0, N'Công ty STU', N'17 Trần Phú, Hải Châu 1, TP. Đà Nẵng', N'phamthih@any.com', N'0123456789')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH009', N'Le Văn Hiếu', 1, N'Công ty VXY', N'27 Hoàng Diệu , Hòa Thuận Tây, TP. Đà Nẵng', N'levani@any.com', N'0988888888')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH010', N'Võ thị Nga', 0, N'Công ty ZAB', N'64 Lê Lợi, Phường 3, TP. Bến Tre, Bến Tre', N'vothik@any.com', N'0906060606')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH011', N'Nguyễn Văn Lợi', 1, N'Công ty CDE', N'52 Lê Lợi, Phường 6, TP. Cà Mau, Cà Mau', N'nguyenvanl@any.com', N'0123654789')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH012', N'Trần Thị Minh', 0, N'Công ty FGH', N'22 Lê Lợi, Quang Trung,  Hà Tĩnh, Hà Tĩnh', N'tranthim@any.com', N'0987531590')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH013', N'Phạm Văn Nghĩa', 1, N'Công ty JKL', N'15 Trần Quang Khải, Phường 5, Ninh Bình, Ninh Bình', N'phamvann@any.com', N'0123456789')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH014', N'Lê Thị Phương', 0, N'Công ty MNO', N'33 Đinh Bộ Lĩnh, Phường 15, Bình Thạnh, TPHCM', N'lethip@any.com', N'0909090909')
INSERT [dbo].[KHACHHANG] ([maKhachHang], [tenKhachHang], [gioiTinh], [tenCongTy], [diaChi], [email], [dienThoai]) VALUES (N'KH015', N'Võ Văn Quỳnh', 1, N'Công ty RST', N'81 Lê Duẩn, Xuân Khanh, TP. Nha Trang, Khánh Hòa', N'vovanq@any.com', N'0989898989')
GO
INSERT [dbo].[LOAIHANG] ([maLoaiHang], [tenLoaiHang]) VALUES (N'congNghe', N'Đồ công nghệ')
INSERT [dbo].[LOAIHANG] ([maLoaiHang], [tenLoaiHang]) VALUES (N'doChoi', N'Đồ chơi')
INSERT [dbo].[LOAIHANG] ([maLoaiHang], [tenLoaiHang]) VALUES (N'giaDung', N'Đồ gia dụng')
INSERT [dbo].[LOAIHANG] ([maLoaiHang], [tenLoaiHang]) VALUES (N'hocTap', N'Học tập')
INSERT [dbo].[LOAIHANG] ([maLoaiHang], [tenLoaiHang]) VALUES (N'sucKhoe', N'Sức khỏe')
INSERT [dbo].[LOAIHANG] ([maLoaiHang], [tenLoaiHang]) VALUES (N'thoiTrang', N'Thời trang')
GO
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH001', N'Áo khoác nam', N'nccG', N'thoiTrang', 20, N'Cái', 500000.0000, 600000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH002', N'Váy đầm nữ', N'nccG', N'thoiTrang', 25, N'Cái', 350000.0000, 370000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH003', N'Quần jean nam', N'nccG', N'thoiTrang', 30, N'Cái', 300000.0000, 500000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH004', N'Bếp từ', N'nccG', N'giaDung', 80, N'Cái', 100000.0000, 120000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH005', N'Máy rửa bát', N'nccF', N'giaDung', 50, N'Cái', 700000.0000, 800000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH006', N'Máy hút bụi', N'nccI', N'giaDung', 20, N'Cái', 400000.0000, 900000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH007', N'Thiết bị Xbox', N'nccB', N'congNghe', 15, N'Cái', 900000.0000, 1000000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH008', N'Bình nóng lạnh', N'nccI', N'giaDung', 10, N'Cái', 6000000.0000, 8000000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH009', N'Tủ lạnh', N'nccK', N'giaDung', 12, N'Cái', 150000.0000, 180000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH010', N'Máy sấy quần áo', N'nccK', N'giaDung', 60, N'Cái', 3000000.0000, 4000000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH011', N'Điện thoại bàn', N'nccI', N'congNghe', 70, N'Cái', 100000.0000, 140000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH012', N'Vitamin D3', N'nccG', N'sucKhoe', 200, N'hộp', 250000.0000, 280000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH013', N'Tinh dầu tràm trà', N'nccD', N'sucKhoe', 100, N'chai', 120000.0000, 170000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH014', N'Tinh dầu bưởi', N'nccE', N'sucKhoe', 50, N'chai', 180000.0000, 200000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH015', N'Vitamin C 1000mg', N'nccE', N'sucKhoe', 500, N'vỉ', 150000.0000, 160000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH016', N'Bộ đồ chơi Le', N'nccA', N'doChoi', 50, N'Bộ', 340000.0000, 350000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH017', N'Đồng hồ định vị GPS', N'nccA', N'congNghe', 20, N'Cái', 1700000.0000, 1800000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH018', N'Tivi LCD', N'nccA', N'congNghe', 15, N'Cái', 125000.0000, 126000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH019', N'Máy bay điều khiển', N'nccB', N'doChoi', 50, N'Cái', 8500000.0000, 8600000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH020', N'Máy tập chạy điện', N'nccB', N'sucKhoe', 80, N'Cái', 2800000.0000, 2900000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH021', N'Ghế phòng khách', N'nccB', N'giaDung', 3, N'Bộ', 150000.0000, 160000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH022', N'Tủ quần áo', N'nccC', N'giaDung', 20, N'Cái', 450000.0000, 460000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH023', N'Bàn làm việc', N'nccC', N'hocTap', 50, N'Cái', 3500000.0000, 3700000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH024', N'Kệ sách', N'nccC', N'hocTap', 10, N'Cái', 120000.0000, 160000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH025', N'Đèn trang trí', N'nccE', N'giaDung', 25, N'Cái', 350000.0000, 360000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH026', N'Bộ nồi inox', N'nccE', N'giaDung', 30, N'Bộ', 750000.0000, 780000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH027', N'Bếp ga', N'nccF', N'giaDung', 10, N'Cái', 18000.0000, 19000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH028', N'Nồi cơm điện', N'nccF', N'giaDung', 12, N'Cái', 1500000.0000, 1800000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH029', N'Máy làm kem', N'nccF', N'giaDung', 30, N'Cái', 350000.0000, 450000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
INSERT [dbo].[MATHANG] ([maHang], [tenHang], [maNhaCC], [maLoaiHang], [soluong], [donViTinh], [giaNhap], [giaBan], [hinhAnh]) VALUES (N'MH030', N'Điều hòa', N'nccF', N'giaDung', 50, N'Cái', 120000.0000, 140000.0000, N'D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png')
GO
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccA', N'Nhà cung cấp A', N'Quang Trung - TP Thái Nguyên - Thái Nguyên', N'0123456789', N'NhaCungCapVip1@gmail.com', N'Nguyễn Thị Anh')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccB', N'Nhà cung cấp B', N'Quan Hoa - quận Cầu Giấy - TP Hà Nội', N'0173256789', N'NhaCungCapVip2@gmail.com', N'Lê Văn Tú')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccC', N'Nhà cung cấp C', N'Tích Lương - TP Thái Nguyên - Thái Nguyên', N'0232467895', N'NhaCungCapVip3@gmail.com', N'Trần Thị Hương')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccD', N'Nhà cung cấp D', N'Nhân Chính - quận Thanh Xuân - TP Hà Nội', N'0124256289', N'NhaCungCapVip4@gmail.com', N'Đặng Văn Quân')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccE', N'Nhà cung cấp E', N'Khương Trung - quận Thanh Xuân - TP Hà Nội', N'0435216789', N'NhaCungCapVip5@gmail.com', N'Lê Thị Thu')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccF', N'Nhà cung cấp F', N'Đại Xuân -  Quế Võ - Bắc Ninh', N'0463456739', N'NhaCungCapVip6@gmail.com', N'Bùi Thị Hồng')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccG', N'Nhà cung cấp G', N'Quang Trung - TP Thái Nguyên - Thái Nguyên', N'0242421789', N'NhaCungCapVip7@gmail.com', N'Vũ Thị Mai')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccH', N'Nhà cung cấp H', N'Nguyên Xá - Yên Phong - Bắc Ninh', N'0257967892', N'NhaCungCapVip8@gmail.com', N'Hoàng Văn Minh')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccI', N'Nhà cung cấp I', N'Nhã Lộng  - Phú Bình - Thái Nguyên', N'0123246289', N'NhaCungCapVip9@gmail.com', N'Ngô Văn Tuấn')
INSERT [dbo].[NHACUNGCAP] ([maNhaCC], [tenNhaCC], [diaChi], [dienThoai], [email], [nguoiDaiDien]) VALUES (N'nccK', N'Nhà cung cấp K', N'Thượng Đình  - Phú Bình - Thái Nguyên', N'0123371143', N'NhaCungCapVip10@gmail.com', N'Lương Thị Ngọc')
GO
INSERT [dbo].[NHANVIEN] ([maNhanVien], [hoVaTen], [gioiTinh], [ngaySinh], [ngayLamViec], [diaChi], [dienThoai], [luongCoBan], [phuCap], [taiKhoan], [matKhau]) VALUES (N'NV001', N'Đặng văn Đắng', 1, CAST(N'2001-09-04' AS Date), CAST(N'2022-03-02' AS Date), N'Tích Lương - TP Thái Nguyên - Thái Nguyên', N'0122328645', 2500000.0000, 5000000.0000, N'nv001', N'123')
INSERT [dbo].[NHANVIEN] ([maNhanVien], [hoVaTen], [gioiTinh], [ngaySinh], [ngayLamViec], [diaChi], [dienThoai], [luongCoBan], [phuCap], [taiKhoan], [matKhau]) VALUES (N'NV002', N'Nguyễn Thị Hương', 0, CAST(N'1998-05-08' AS Date), CAST(N'2021-01-01' AS Date), N'Đồng Quang - TP Thái Nguyên - Thái Nguyên', N'0987654321', 3000000.0000, 6000000.0000, N'nv002', N'456')
INSERT [dbo].[NHANVIEN] ([maNhanVien], [hoVaTen], [gioiTinh], [ngaySinh], [ngayLamViec], [diaChi], [dienThoai], [luongCoBan], [phuCap], [taiKhoan], [matKhau]) VALUES (N'NV003', N'Lê Văn Bình', 1, CAST(N'1996-12-12' AS Date), CAST(N'2018-01-06' AS Date), N'Phố Rùa - TP Hà Nội - Hà Nội', N'0912345678', 3500000.0000, 7000000.0000, N'nv003', N'789')
INSERT [dbo].[NHANVIEN] ([maNhanVien], [hoVaTen], [gioiTinh], [ngaySinh], [ngayLamViec], [diaChi], [dienThoai], [luongCoBan], [phuCap], [taiKhoan], [matKhau]) VALUES (N'NV004', N'Phạm Thị Hạnh', 0, CAST(N'1994-03-07' AS Date), CAST(N'2017-01-03' AS Date), N'Đồng Xuân - TP Hà Nội - Hà Nội', N'0976543210', 4000000.0000, 800000.0000, N'nv004', N'123')
INSERT [dbo].[NHANVIEN] ([maNhanVien], [hoVaTen], [gioiTinh], [ngaySinh], [ngayLamViec], [diaChi], [dienThoai], [luongCoBan], [phuCap], [taiKhoan], [matKhau]) VALUES (N'NV005', N'Nguyễn Minh Hoàng', 1, CAST(N'2000-09-04' AS Date), CAST(N'2022-03-02' AS Date), N'Tích Lương - TP Thái Nguyên - Thái Nguyên', N'0122328645', 2500000.0000, 5000000.0000, N'nv005', N'567')
GO
INSERT [dbo].[QUANLY] ([id], [taiKhoan], [matKhau], [ten], [ngaySinh]) VALUES (N'adminG', N'admin                                                 ', N'123                                               ', N'Quản lý siêu cấp', CAST(N'2002-06-06' AS Date))
GO
INSERT [dbo].[THANHTOAN] ([mahinhThucThanhToan], [tenhinhThucThanhToan]) VALUES (N'ATM', N'TT qua máy ATM')
INSERT [dbo].[THANHTOAN] ([mahinhThucThanhToan], [tenhinhThucThanhToan]) VALUES (N'NH', N'TT qua ngân hàng')
INSERT [dbo].[THANHTOAN] ([mahinhThucThanhToan], [tenhinhThucThanhToan]) VALUES (N'PAYPAL', N'TT qua PayPal')
INSERT [dbo].[THANHTOAN] ([mahinhThucThanhToan], [tenhinhThucThanhToan]) VALUES (N'TM', N'TT bằng tiền mặt')
INSERT [dbo].[THANHTOAN] ([mahinhThucThanhToan], [tenhinhThucThanhToan]) VALUES (N'TTD', N'TT trả góp qua thẻ tín dụng')
INSERT [dbo].[THANHTOAN] ([mahinhThucThanhToan], [tenhinhThucThanhToan]) VALUES (N'VNP', N'TT qua VNPAY')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NHANVIEN__B4C4531804BABCFD]    Script Date: 30/05/2023 5:35:03 SA ******/
ALTER TABLE [dbo].[NHANVIEN] ADD UNIQUE NONCLUSTERED 
(
	[taiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHITIETDONHANG] ADD  CONSTRAINT [DF_soLuong]  DEFAULT ((1)) FOR [soLuong]
GO
ALTER TABLE [dbo].[MATHANG] ADD  CONSTRAINT [DF_duongDanAnh]  DEFAULT ('D:\Ki3_53\HQT_CSDL\Project\QLBanHang\data_img\order.png') FOR [hinhAnh]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [fk_chitietdathang_dondathang] FOREIGN KEY([soHoaDon])
REFERENCES [dbo].[DONDATHANG] ([soHoaDon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [fk_chitietdathang_dondathang]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [fk_chitietdathang_mathang] FOREIGN KEY([maHang])
REFERENCES [dbo].[MATHANG] ([maHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [fk_chitietdathang_mathang]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [fk_dondathang_khachhang] FOREIGN KEY([maKhachHang])
REFERENCES [dbo].[KHACHHANG] ([maKhachHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [fk_dondathang_khachhang]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [fk_dondathang_nhanvien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NHANVIEN] ([maNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [fk_dondathang_nhanvien]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [fk_dondathang_thanhtoan] FOREIGN KEY([mahinhThucThanhToan])
REFERENCES [dbo].[THANHTOAN] ([mahinhThucThanhToan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [fk_dondathang_thanhtoan]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [fk_mathang_loaihang] FOREIGN KEY([maLoaiHang])
REFERENCES [dbo].[LOAIHANG] ([maLoaiHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [fk_mathang_loaihang]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [fk_mathang_nhacungcap] FOREIGN KEY([maNhaCC])
REFERENCES [dbo].[NHACUNGCAP] ([maNhaCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [fk_mathang_nhacungcap]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [CHK_mucGiamGia] CHECK  (([mucGiamGia]>=(0) AND [mucGiamGia]<(100)))
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [CHK_mucGiamGia]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [CHK_soLuongg] CHECK  (([soLuong]>(0)))
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [CHK_soLuongg]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [CHK_ngayDatVaGiao] CHECK  (([ngayDatHang]<=[ngayGiaoHang]))
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [CHK_ngayDatVaGiao]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [CHK_dienThoaikhachHang] CHECK  (([dienThoai] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [CHK_dienThoaikhachHang]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [CHK_giaBan] CHECK  (([giaBan]>(0)))
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [CHK_giaBan]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [CHK_giaNhap] CHECK  (([giaNhap]>(0)))
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [CHK_giaNhap]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [CHK_soLuong] CHECK  (([soLuong]>(0)))
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [CHK_soLuong]
GO
ALTER TABLE [dbo].[NHACUNGCAP]  WITH CHECK ADD  CONSTRAINT [CHK_dienThoaiNCC] CHECK  (([dienThoai] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[NHACUNGCAP] CHECK CONSTRAINT [CHK_dienThoaiNCC]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [CHK_dienThoaiNhanVien] CHECK  (([dienThoai] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [CHK_dienThoaiNhanVien]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [CHK_luongCoBan] CHECK  (([luongCoBan]>(0)))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [CHK_luongCoBan]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [CHK_phuCap] CHECK  (([phuCap]>=(0)))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [CHK_phuCap]
GO
/****** Object:  StoredProcedure [dbo].[ADD_EDIT_DONHANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ADD_EDIT_DONHANG]
	@action NVARCHAR(50), 
	@soHD NVARCHAR(20) = null, 
	@soHDCu NVARCHAR(20) = null, 
	@maKH NVARCHAR(20) = null,
	@maNV NVARCHAR(20) = null,
	@ngayDat DATE = null,
	@ngayGiao DATE = null,
	@diaChiGiaoHang NVARCHAR(50) = null, 
	@maHTTT NVARCHAR(20) = null
AS
BEGIN
IF(@action = 'ADD')
BEGIN
	IF(EXISTS(SELECT * FROM DONDATHANG WHERE soHoaDon = @soHD))
	BEGIN
	RaisError(N'Số hóa đơn: %s đã tồn tại rồi! K thể thêm lại! :((', 16, 1, @soHD);
	RETURN; --thoát luôn sp này, ko chạy lệnh INSERT bên dưới
	END;
		  -- nếu chưa có khóa chính này tồn tại thì oke
	INSERT INTO [dbo].[DONDATHANG]
           ([soHoaDon],[maKhachHang],[maNhanVien],[ngayDatHang],[ngayGiaoHang],[diaChiGiaoHang],[mahinhThucThanhToan])
     VALUES
         (@soHD,@maKH,@maNV,@ngayDat,@ngayGiao,@diaChiGiaoHang,@maHTTT);
	end
	ELSE IF(@action = 'EDIT')
	BEGIN
		
	IF(EXISTS(SELECT * FROM DONDATHANG WHERE soHoaDon = @soHD AND soHoaDon != @soHDCu))
	BEGIN
	RaisError(N'Số hóa đơn: %s đã có rồi, không thể sửa số hóa đơn %s hiện tại thành %s nữa!', 16, 1, @soHD, @soHdCu ,@soHD);
	RETURN; --thoát luôn sp này, ko chạy lệnh UPDATE bên dưới
	END;
			
	UPDATE [dbo].[DONDATHANG]
	   SET [soHoaDon] = @soHD
		  ,[maKhachHang] = @maKH
		  ,[maNhanVien] = @maNV
		  ,[ngayDatHang] = @ngayDat
		  ,[ngayGiaoHang] = @ngayGiao
		  ,[diaChiGiaoHang] = @diaChiGiaoHang
		  ,[mahinhThucThanhToan] = @maHTTT
	 WHERE soHoaDon = @soHDCu
		END
END
GO
/****** Object:  StoredProcedure [dbo].[ADD_EDIT_KHACHHANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ADD_EDIT_KHACHHANG]
	@action NVARCHAR(50), 
	@maKH NVARCHAR(20) = null, 
	@maKHCu nvarchar(20) = null,
	@tenKH NVARCHAR(50) = null,
	@gioiTinh bit = null,
	@tenCT VARCHAR(50) = null, 
	@diaChi VARCHAR(100) = null, 
	@email nvarchar(30) = null,
	@sdt nvarchar(10) = null
AS
BEGIN
	IF(@action = 'ADD')
	BEGIN
		IF(EXISTS(SELECT * FROM KHACHHANG WHERE maKhachHang = @maKH))
		  BEGIN
			SELECT @tenKH = tenKhachHang FROM KHACHHANG WHERE maKhachHang = @maKH;
			RaisError(N'Mã khách hàng: %s với tên %s đã tồn tại rồi bạn ơi :((', 16, 1, @maKH, @tenKH);
			RETURN; --thoát luôn sp này, ko chạy lệnh INSERT bên dưới
		  END;
		  -- nếu chưa có khóa chính này tồn tại thì oke
INSERT INTO [dbo].[KHACHHANG]
           ([maKhachHang],[tenKhachHang],[gioiTinh],[tenCongTy],[diaChi],[email],[dienThoai])
     VALUES
           (@maKH,@tenKH,@gioiTinh,@tenCT,@diaChi,@email,@sdt);
	 end
	ELSE IF(@action = 'EDIT')
		BEGIN
		
			IF(EXISTS(SELECT * FROM KHACHHANG WHERE maKhachHang = @maKH AND maKhachHang != @maKHCu))
			  BEGIN
				-- lấy tên của cái mã hàng mk muốn sửa đổi đè lên báo rằng nó đã tồn tại!
				SELECT @tenKH = tenKhachHang  FROM KHACHHANG WHERE maKhachHang = @maKH;
				RaisError(N'Mã khách hàng: %s với tên %s đã có rồi, không thể sửa khách hàng này thành mã khách hàng %s nữa!', 16, 1, @maKH, @tenKH ,@maKH);
				RETURN; --thoát luôn sp này, ko chạy lệnh UPDATE bên dưới
				END;
			UPDATE [dbo].KHACHHANG
			   SET
			   maKhachHang = @maKH
			   ,tenKhachHang = @tenKH
			   ,gioiTinh = @gioiTinh
			   ,tenCongTy = @tenCT
			   ,diaChi = @diaChi
			   ,email = @email
			   ,dienThoai = @sdt
				WHERE maKhachHang = @maKHCu;		
		END
end
GO
/****** Object:  StoredProcedure [dbo].[ADD_EDIT_MATHANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ADD_EDIT_MATHANG]
	@action NVARCHAR(50), 
	@maMH NVARCHAR(20) = null, 
	@maMHCu nvarchar(20) = null,
	@ten NVARCHAR(50) = null,
	@maNCC NVARCHAR(20) = null,
	@maLH NVARCHAR(20) = null,
	@dvTinh VARCHAR(50) = null, 
	@sl int = null, 
	@giaNhap money = null, 
	@giaBan money = null, 
	@hinhAnh nvarchar(100) = null
AS
BEGIN
	IF(@action = 'ADD')
	BEGIN
		IF(EXISTS(SELECT * FROM MATHANG WHERE maHang = @maMH))
		  BEGIN
			SELECT @ten = tenHang FROM MATHANG WHERE maHang = @maMH;
			RaisError(N'Mã mặt hàng: %s với tên %s đã tồn tại rồi bạn ơi :((', 16, 1, @maMH, @ten);
			RETURN; --thoát luôn sp này, ko chạy lệnh INSERT bên dưới
		  END;

		INSERT INTO [dbo].[MATHANG]
			   ([maHang],[tenHang],[maNhaCC],[maLoaiHang],[soluong],[donViTinh],[giaNhap],[giaBan],[hinhAnh])
		 VALUES
		 (@maMH, @ten, @maNCC,@maLH,@sl,@dvTinh,@giaNhap,@giaBan,@hinhAnh);
	END
	ELSE IF(@action = 'EDIT')
		BEGIN
		-- Tìm xem trong DB có thằng mặt hàng nào:
			-- Nếu mà k sửa lại mã hàng thì mã cũ @maMHCu bằng mã mới @maMH ! vậy thì câu lênh And kia k trả về thằng nào!
			-- Nếu mà mã mới @maMH khác với mã cũ -> ngoài dòng mà mk đang muốn thay đổi ra thì tất cả các dòng còn lại!
			-- đều trả cái  " maHang != @maMHCu " về true -> vậy nên maHang = @maMH điều kiện này chạy kiểm tra xem có 
			-- dòng nào ngoài dòng ta muốn thay đổi mà có mã hàng trùng không nếu mà mã hàng mới muốn thay đổi mà 
			-- không trùng với mã hàng cũ song lại trùng với mã hàng có sẵn trong DB thì nó sẽ trả về có kq
			-- mà mk không thể sửa mã thành mã đã có sẵn nên báo lỗi!
			-- 
			IF(EXISTS(SELECT * FROM MATHANG WHERE maHang = @maMH AND maHang != @maMHCu))
			  BEGIN
				-- lấy tên của cái mã hàng mk muốn sửa đổi đè lên báo rằng nó đã tồn tại!
				SELECT @ten = tenHang  FROM MATHANG WHERE maHang = @maMH;
				RaisError(N'Mã hàng: %s với tên %s đã có rồi, không thể sửa mặt hàng này thành mã hàng %s nữa!', 16, 1, @maMH, @ten,@maMH);
				RETURN; --thoát luôn sp này, ko chạy lệnh UPDATE bên dưới
				END;
			UPDATE [dbo].[MATHANG]
			   SET maHang = @maMH
				  ,tenHang = @ten
				  ,maNhaCC = @maNCC
				  ,maLoaiHang = @maLH
				  ,soluong = @sl
				  ,donViTinh = @dvTinh
				  ,giaNhap = @giaNhap
				  ,giaBan = @giaBan
				  ,hinhAnh = @hinhAnh
				WHERE maHang = @maMHCu;		
			END
END
GO
/****** Object:  StoredProcedure [dbo].[BAO_DONHANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[BAO_DONHANG]
	@soHD nvarchar(20),
	@action nvarchar(10) = ''
as 
BEGIN
	declare @br char(2)=char(10)+char(13);  -- để xuống dòng
	declare @kq nvarchar(max)='';  -- để chứa kq cuối cùng
	declare @stt int =1;

	if(@action != '')
	begin
		set @kq = FORMATMESSAGE(N'☎️ THÊM MỘT HÓA ĐƠN%s',@br)
	end
	-- Chuẩn bị từng chút một:
	set @kq += FORMATMESSAGE(N'🔖Số hóa đơn: %s%s',@soHD,@br)

	-- Khách hàng: -> có thêm tên khách hàng
	select @kq += FORMATMESSAGE(N'Tên khách hàng: %s%s',tenKhachHang,@br) from KHACHHANG 
		where maKhachHang = ( select maKhachHang from DONDATHANG where soHoaDon = @soHD)

	set @kq += FORMATMESSAGE(N'Mặt hàng  : Số lượng%s',@br)

	--where giúp tìm thấy nhiều bản ghi (hoặc 1, hoặc 0)
	--select @kq +=  : nhấn mạnh vào +=  : ghép chuỗi vào sau @kq đã có
	-- khi select có nhiều bản ghi, ghi mỗi bản ghi đc tạo ra chuỗi, ghép vào sau @kq
	-- khi chạy xong select -> chỉ tạo ra 1 chuỗi @kq dài dài
	select @kq += FORMATMESSAGE(N'%d. %s  :  %d%s',@stt,m.tenHang,c.soLuong,@br),
	       @stt=@stt+1
	from  CHITIETDONHANG c inner join MATHANG m on c.maHang = m.maHang
	where soHoaDon = @soHD

	-- Song các mặt hàng - giờ thì tổng tiền!
	declare @tongTien nvarchar(50)
	set @tongTien = FORMAT(dbo.tinhTongTien(@soHD), '#,##0.')
	--set @kq += FORMATMESSAGE(N'💰Tổng giá trị đơn hàng: %s VNĐ',str(dbo.tinhTongTien(@soHD),10,6))
	set @kq += FORMATMESSAGE(N'💰Tổng giá trị đơn hàng: %s VNĐ',@tongTien)
	if(@kq='' or @kq is null or @stt =1)
		set @kq=N'🆘Không tìm thấy gì liên quan';

	select @kq as msg;  -- trả về 1 dòng, 1 cột tên là MSG
	print @kq; -- in nó ra xem
END
GO
/****** Object:  StoredProcedure [dbo].[BAO_KHACHHANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[BAO_KHACHHANG]
	@tenKH nvarchar(50)
as 
BEGIN
	declare @br char(2)=char(10)+char(13);  -- để xuống dòng
	declare @kq nvarchar(max)='';  -- để chứa kq cuối cùng
	declare @stt int =1;

	set @kq = FORMATMESSAGE(N'✅ KẾT QUẢ TÌM ĐƯỢC:%s%s',@br,@br)

	--where giúp tìm thấy nhiều bản ghi (hoặc 1, hoặc 0)
	--select @kq +=  : nhấn mạnh vào +=  : ghép chuỗi vào sau @kq đã có
	-- khi select có nhiều bản ghi, ghi mỗi bản ghi đc tạo ra chuỗi, ghép vào sau @kq
	-- khi chạy xong select -> chỉ tạo ra 1 chuỗi @kq dài dài
	select  @kq += FORMATMESSAGE(N'%d. %s%sSĐT:%s%sCông ty:%s%sĐịa chỉ:%s%s%s',@stt,tenKhachHang,@br,dienThoai,@br,tenCongTy,@br,diaChi,@br,@br),
	       @stt=@stt+1
	from  KHACHHANG

	where tenKhachHang like @tenKH
	if(@kq='' or @kq is null or @stt =1)
		set @kq=N'🆘Không tìm thấy gì liên quan';
	else 
		set @kq += FORMATMESSAGE(N'➡️Tìm được %d anh chị cô gì chú bác ông bà.',@stt-1,@tenKH)
	select @kq as msg;  -- trả về 1 dòng, 1 cột tên là MSG
	print @kq; -- in nó ra xem
END
GO
/****** Object:  StoredProcedure [dbo].[lisAllDonHangDk]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[lisAllDonHangDk]
	@dk nvarchar(20)
AS
	BEGIN
		set @dk = '%' + @dk + '%'
		select soHoaDon,maKhachHang,maNhanVien,ngayDatHang,ngayDatHang,mahinhThucThanhToan,diaChiGiaoHang from DONDATHANG
			where (soHoaDon like @dk)
				or(maKhachHang like @dk) 
				or(maNhanVien like @dk) 
				or(diaChiGiaoHang like @dk) 
				or(mahinhThucThanhToan like @dk) 
	End
GO
/****** Object:  StoredProcedure [dbo].[listALLKhachHang]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[listALLKhachHang]
AS
BEGIN
   SELECT  maKhachHang,tenKhachHang,
    CASE 
        WHEN khachhang.gioiTinh = 1 THEN 'Nam' 
        WHEN khachhang.gioiTinh = 0 THEN N'Nữ'  
    END as [gT],
	tenCongTy,diaChi,email,dienThoai
FROM KHACHHANG
END
GO
/****** Object:  StoredProcedure [dbo].[listALLKhachHangDk]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[listALLKhachHangDk]
@dk nvarchar(50)
AS
BEGIN
	set @dk = '%'+ @dk + '%'
   SELECT  maKhachHang,tenKhachHang,
    CASE 
        WHEN khachhang.gioiTinh = 1 THEN 'Nam' 
        WHEN khachhang.gioiTinh = 0 THEN N'Nữ'  
    END as [gT],
	tenCongTy,diaChi,email,dienThoai
FROM KHACHHANG
	where tenKhachHang like @dk
END
GO
/****** Object:  StoredProcedure [dbo].[listAllNhanVien]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[listAllNhanVien]
AS
BEGIN
    SELECT maNhanVien,hoVaTen,
		CASE 
        WHEN NHANVIEN.gioiTinh = 1 THEN 'Nam' 
        WHEN NHANVIEN.gioiTinh = 0 THEN N'Nữ'  
    END AS [gT],
		ngaySinh,ngayLamViec,dienThoai,luongCoBan,phuCap,diaChi,taiKhoan,matKhau
	FROM NHANVIEN;
END
GO
/****** Object:  StoredProcedure [dbo].[PRO_VIEW_DONHANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[PRO_VIEW_DONHANG]
	@action nvarchar(50) = null,
	@soHD nvarchar(20) =null
as
begin
	if(@action = 'LIST_ALL_WITH_1_DONHANG' )
	begin
		select * from CHITIETDONHANG where soHoaDon = @soHD;
	end
end
GO
/****** Object:  StoredProcedure [dbo].[themCHiTietDonHang]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[themCHiTietDonHang]
@soHD nvarchar(20),
@sl int,
@maHang nvarchar(20),
@giamGia real
as
begin
	INSERT INTO [dbo].[CHITIETDONHANG]
                ([soHoaDon],[maHang],[soLuong],[mucGiamGia])
                VALUES (@soHD,@maHang,@sl,@giamGia)
end
GO
/****** Object:  StoredProcedure [dbo].[THONG_KE_TONG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create proc [dbo].[THONG_KE_TONG]
 as
 begin
SELECT
    (SELECT COUNT(*) FROM MatHang) AS mh,
    (SELECT COUNT(*) FROM khachHang) AS kh,
    (SELECT COUNT(*) FROM DONDATHANG) AS dh,
    (SELECT COUNT(*) FROM NHANVIEN) AS nv,
    (SELECT COUNT(*) FROM NHACUNGCAP) AS ncc
end
GO
/****** Object:  StoredProcedure [dbo].[THONGKE_NGAY]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE proc [dbo].[THONGKE_NGAY]
	@ngay  int = 30,
	@thang  int =5,
	@nam  int = 2023
	as
	begin
		declare @kq nvarchar(max)
		declare @sign nvarchar(3) = N'>>>'
		-- Lấy tổng số HĐ:
		select @kq = FORMATMESSAGE(N'%d%s',COUNT(*),@sign) from DONDATHANG where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay

		-- Tổng doanh thu:
		select @kq += FORMATMESSAGE(N'%d%s',sum( CAST(tongTien as int)),@sign) from DONDATHANG 
			where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay

		-- Tổng tiền lãi 1 ngày
		set @kq += FORMATMESSAGE(N'%d%s',CAST(dbo.TongThu1Ngay(@ngay,@thang,@nam) AS INT),@sign) 

		-- mặt hàng bán đc lãi cao nhất
		declare @maHangDoanhThu nvarchar(20)
		declare @tenHangDoanhThu nvarchar(50)
		declare @tienDoanhThu int
		;WITH t AS (
		SELECT a.maHang, MAX(a.tienBan - b.tienNhap) AS tien
		FROM (SELECT * FROM dbo.maHang_TienTrongNgay(@ngay,@thang,@nam)) AS a
		INNER JOIN (SELECT * FROM dbo.maHang_NhapTrongNgay(@ngay,@thang,@nam)) AS b
			ON a.maHang = b.maHang
		GROUP BY a.maHang
		)
		select top 1 @maHangDoanhThu = maHang, @tienDoanhThu = tien from t where tien = (select max(tien) from t);
		select @tenHangDoanhThu = tenHang from MATHANG where maHang = @maHangDoanhThu

		set @kq += FORMATMESSAGE(N'%s%s%d%s',@tenHangDoanhThu,@sign,@tienDoanhThu,@sign)

		-- Hóa đơn giá trị cao nhất:
			declare @soHDMax nvarchar(20)
			declare @max int
			;with t as (
			select soHoaDon from DONDATHANG
			where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay ),
			t2 as( select soHoaDon, dbo.tinhTongTien(soHoaDon) as tien from t)
			select @soHDMax = soHoaDon, @max = tien from t2 where tien = (select max(tien) from t2)

			set @kq += FORMATMESSAGE(N'%s%s%d%s',@soHDMax,@sign,@max,@sign)

			-- Số+ tiền hóa đơn lãi nhiều nhất
				declare @soHoaDonLaiNhat nvarchar(20)
				declare @soTienHDLAiNhat int
					;with t as (
				select soHoaDon from DONDATHANG
				where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay ),
				t2 as( select soHoaDon, dbo.tinhTongTien(soHoaDon) as tienBan from t),
				t3 as( select soHoaDon, tienBan, dbo.tinhTongTienNhap(soHoaDon) as tienNhap from t2),
				t4 as( select soHoaDon, (tienBan - tienNhap) as tienLai from t3)
				select @soHoaDonLaiNhat = soHoaDon, @soTienHDLAiNhat = tienLai from t4 where tienLai = (select max(tienLai) from t4)

				set @kq += FORMATMESSAGE(N'%s%s%d',@soHoaDonLaiNhat,@sign,@soTienHDLAiNhat)
			
		select @kq
		print @kq
 	end
GO
/****** Object:  StoredProcedure [dbo].[THONGKE_NGAY_HOI]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[THONGKE_NGAY_HOI]
	@ngay  int = 30,
	@thang  int =5,
	@nam  int = 2023
	as
	begin
		declare @br char(2)=char(10)+char(13);  -- để xuống dòng
		declare @kq nvarchar(max)='';  -- để chứa kq cuối cùng

		set @kq = FORMATMESSAGE(N'🔊Thống kê ngày: %d/%d/%d%s',@ngay,@thang,@nam,@br)

		-- Lấy tổng số HĐ:
		declare @t int
		 select @t = COUNT(*) from DONDATHANG where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
		set @kq += FORMATMESSAGE(N'✅ Tổng hóa đơn: %d%s',@t,@br) 

		-- Tổng doanh thu:
		declare @dt int
		set @dt = 0
		select @dt += sum( CAST(tongTien as int)) from DONDATHANG where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay
		select @kq += FORMATMESSAGE(N'💰 Tổng doanh thu: %d VNĐ%s',@dt,@br) 
			

		-- Tổng tiền lãi 1 ngày
		set @kq += FORMATMESSAGE(N'💰 Tổng tiền lãi: %d VNĐ%s',CAST(dbo.TongThu1Ngay(@ngay,@thang,@nam) AS INT),@br) 

		-- mặt hàng bán đc lãi cao nhất
		declare @maHangDoanhThu nvarchar(20)
		declare @tenHangDoanhThu nvarchar(50)
		declare @tienDoanhThu int
		;WITH t AS (
		SELECT a.maHang, MAX(a.tienBan - b.tienNhap) AS tien
		FROM (SELECT * FROM dbo.maHang_TienTrongNgay(@ngay,@thang,@nam)) AS a
		INNER JOIN (SELECT * FROM dbo.maHang_NhapTrongNgay(@ngay,@thang,@nam)) AS b
			ON a.maHang = b.maHang
		GROUP BY a.maHang
		)
		select top 1 @maHangDoanhThu = maHang, @tienDoanhThu = tien from t where tien = (select max(tien) from t);
		select @tenHangDoanhThu = tenHang from MATHANG where maHang = @maHangDoanhThu

		set @kq += FORMATMESSAGE(N'🛒 Mặt hàng thu lãi nhiều nhất:%s %s Thu được: %d VNĐ%s',@br,@tenHangDoanhThu,@tienDoanhThu,@br)

		-- Hóa đơn giá trị cao nhất:
			declare @soHDMax nvarchar(20)
			declare @max int
			;with t as (
			select soHoaDon from DONDATHANG
			where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay ),
			t2 as( select soHoaDon, dbo.tinhTongTien(soHoaDon) as tien from t)
			select @soHDMax = soHoaDon, @max = tien from t2 where tien = (select max(tien) from t2)

			set @kq += FORMATMESSAGE(N'🔖 Hóa đơn giá trị cao nhất:%s : %d VNĐ%s',@soHDMax,@max,@br)

			-- Số+ tiền hóa đơn lãi nhiều nhất
				declare @soHoaDonLaiNhat nvarchar(20)
				declare @soTienHDLAiNhat int
					;with t as (
				select soHoaDon from DONDATHANG
				where Year(ngayDatHang) = @nam and MONTH(ngayDatHang) = @thang and day(ngayDatHang) = @ngay ),
				t2 as( select soHoaDon, dbo.tinhTongTien(soHoaDon) as tienBan from t),
				t3 as( select soHoaDon, tienBan, dbo.tinhTongTienNhap(soHoaDon) as tienNhap from t2),
				t4 as( select soHoaDon, (tienBan - tienNhap) as tienLai from t3)
				select @soHoaDonLaiNhat = soHoaDon, @soTienHDLAiNhat = tienLai from t4 where tienLai = (select max(tienLai) from t4)

				set @kq += FORMATMESSAGE(N'🔖 Hóa đơn lãi nhiều nhất: %s : %d VNĐ%s❤️❤️❤️',@soHoaDonLaiNhat,@soTienHDLAiNhat,@br)
			
		 select @kq
		 print @kq
 	end
GO
/****** Object:  StoredProcedure [dbo].[THONGKE_THANG]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Thống kê tháng

CREATE proc [dbo].[THONGKE_THANG]
	@thang int = 5,
	@nam int = 2023
as
begin
	declare @kq nvarchar(max) = ''
	declare @sign nvarchar(3) = '>>>'
	-- sl Hoa don
	select @kq += count(soHoaDon) from dondathang where year(ngaydathang) = @nam and month(ngaydathang) = @thang
	set @kq += @sign
	select @kq
	print @kq
	
end
GO
/****** Object:  StoredProcedure [dbo].[xoaDonHang]    Script Date: 30/05/2023 5:35:03 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[xoaDonHang] 
	@soHoaDon nvarchar(20)
	as
	begin 
		delete from DONDATHANG where soHoaDon = @soHoaDon
	end
GO
USE [master]
GO
ALTER DATABASE [BanHanglv1] SET  READ_WRITE 
GO
