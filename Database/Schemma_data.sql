USE [QLKS]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[IDTK] [varchar](50) NOT NULL,
	[Username] [varchar](50) NULL,
	[pw] [varchar](50) NULL,
	[quyenhan] [int] NULL,
	[IDNhanVien] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[IDTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTHDDatPhong]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTHDDatPhong](
	[IDHoaDon] [varchar](50) NOT NULL,
	[IDPhong] [varchar](50) NOT NULL,
	[TienCoc] [int] NULL,
	[TienSauCheckOut] [int] NULL,
 CONSTRAINT [PK_CTHDDatPhong] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC,
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTHDKemTheo]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTHDKemTheo](
	[STT] [int] NOT NULL,
	[IDHoaDon] [varchar](50) NOT NULL,
	[IDTour] [varchar](50) NULL,
	[IDDichVu] [varchar](50) NULL,
 CONSTRAINT [PK_CTHDKemTheo] PRIMARY KEY CLUSTERED 
(
	[STT] ASC,
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DangKyDichVu]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DangKyDichVu](
	[IDKhachHang] [varchar](50) NOT NULL,
	[IDDichVu] [varchar](50) NOT NULL,
	[GioDK] [varchar](50) NULL,
	[SL] [int] NULL,
	[LichSD] [varchar](50) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_DangKyDichVu] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC,
	[IDDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DangKyTour]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DangKyTour](
	[IDKhachHang] [varchar](50) NOT NULL,
	[IDTour] [varchar](50) NOT NULL,
	[GioDK] [varchar](50) NULL,
	[GioXuatPhat] [varchar](50) NULL,
	[SoNguoiDi] [int] NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_DangKyTour] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC,
	[IDTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DichVu](
	[IDDichVu] [varchar](50) NOT NULL,
	[TenDV] [nvarchar](50) NULL,
	[Gia] [int] NULL,
	[SL] [int] NULL,
	[KM] [float] NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[IDDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Doan]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Doan](
	[IDDoan] [varchar](50) NOT NULL,
	[TenDoan] [nvarchar](50) NULL,
	[NguoiDaiDien] [nvarchar](50) NULL,
	[SoNguoi] [int] NULL,
	[IDKhachHang] [varchar](50) NULL,
 CONSTRAINT [PK_Doan] PRIMARY KEY CLUSTERED 
(
	[IDDoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IDHoaDon] [varchar](50) NOT NULL,
	[NgayLap] [date] NULL,
	[PTTT] [nvarchar](50) NULL,
	[TongTien] [int] NULL,
	[IDNhanVien] [varchar](50) NULL,
	[IDKhachHang] [varchar](50) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [varchar](50) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[CCCD] [varchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Fax] [varchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[IDLoai] [varchar](50) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Gia] [int] NULL,
	[SoNguoi] [int] NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[IDLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IDNhanVien] [varchar](50) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[NgSinh] [date] NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[CCCD] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phong](
	[IDPhong] [varchar](50) NOT NULL,
	[TrangThai] [nvarchar](50) NULL,
	[IDLoai] [varchar](50) NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhuongTien]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhuongTien](
	[IDNhaXe] [varchar](50) NOT NULL,
	[TenNhaXe] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[GioDen] [int] NULL,
	[Gia] [int] NULL,
 CONSTRAINT [PK_PhuongTien] PRIMARY KEY CLUSTERED 
(
	[IDNhaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TourDuLich]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TourDuLich](
	[IDTour] [varchar](50) NOT NULL,
	[NCC] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](50) NULL,
	[Gia] [int] NULL,
 CONSTRAINT [PK_TourDuLich] PRIMARY KEY CLUSTERED 
(
	[IDTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinChuyenPhong]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinChuyenPhong](
	[IDKhachHang] [varchar](50) NOT NULL,
	[IDPhong] [varchar](50) NOT NULL,
	[LyDo] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThongTinChuyenPhong] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC,
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinDatPhong]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinDatPhong](
	[IDKhachHang] [varchar](50) NOT NULL,
	[IDPhong] [varchar](50) NOT NULL,
	[NgayDat] [date] NULL,
	[NgayCheckIn] [date] NULL,
	[NgayCheckOut] [date] NULL,
	[SoLuongNguoi] [int] NULL,
 CONSTRAINT [PK_ThongTinDatPhong] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC,
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[YCDacBiet]    Script Date: 7/3/2023 3:58:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[YCDacBiet](
	[IDYeuCau] [varchar](50) NOT NULL,
	[TenYC] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](50) NULL,
	[IDKH] [varchar](50) NULL,
 CONSTRAINT [PK_YCDacBiet] PRIMARY KEY CLUSTERED 
(
	[IDYeuCau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_001', N'nvhai', N'123456', 1, N'NV_5001')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_002', N'ptduong', N'123456', 1, N'NV_5002')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_003', N'lduc', N'123456', 2, N'NV_5003')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_004', N'ttttien', N'123456', 2, N'NV_5004')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_005', N'lttho', N'123456', 1, N'NV_5005')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_006', N'dvhop', N'123456', 1, N'NV_5006')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_007', N'vxha', N'123456', 2, N'NV_5007')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_008', N'dvphong', N'123456', 3, N'NV_5008')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_009', N'btcam', N'123456', 1, N'NV_5009')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_010', N'phha', N'123456', 1, N'NV_5010')
INSERT [dbo].[Account] ([IDTK], [Username], [pw], [quyenhan], [IDNhanVien]) VALUES (N'acc_011', N'ltha', N'123456', 1, N'NV_5011')
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_101', N'DOI_201', 450000, 1050000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_102', N'DON_101', 750000, 1750000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_103', N'DON_103', 300000, 700000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_104', N'DON_102', 1200000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_301', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_302', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_303', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_304', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_305', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_306', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_105', N'GD_307', 1680000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_106', N'DOI_201', 1050000, 2450000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_107', N'DOI_202', 1200000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_107', N'DOI_203', 1200000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_107', N'DOI_204', 1200000, 3800000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_107', N'DON_101', 720000, 1680000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_108', N'DOI_206', 1350000, 3150000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_108', N'DON_102', 810000, 1400000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_109', N'DOI_201', 600000, 1400000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_109', N'DOI_203', 600000, 1400000)
INSERT [dbo].[CTHDDatPhong] ([IDHoaDon], [IDPhong], [TienCoc], [TienSauCheckOut]) VALUES (N'HD_110', N'DOI_204', 1500000, 3500000)
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (1, N'HD_101', NULL, N'SP_101')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (2, N'HD_101', N'TOUR_1001', NULL)
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (3, N'HD_101', NULL, N'SP_102')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (4, N'HD_101', NULL, N'DV_101')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (5, N'HD_102', NULL, N'SP_103')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (6, N'HD_105', N'TOUR_1002', NULL)
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (7, N'HD_105', NULL, N'SP_101')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (8, N'HD_105', NULL, N'SP_102')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (9, N'HD_105', NULL, N'SP_103')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (10, N'HD_105', NULL, N'SP_106')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (11, N'HD_105', NULL, N'SP_105')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (12, N'HD_106', NULL, N'DV_101')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (13, N'HD_107', NULL, N'DV_102')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (14, N'HD_108', NULL, N'SP_106')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (15, N'HD_109', NULL, N'SP_105')
INSERT [dbo].[CTHDKemTheo] ([STT], [IDHoaDon], [IDTour], [IDDichVu]) VALUES (16, N'HD_110', NULL, N'SP_106')
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1001', N'DV_101', N'12', 2, N'14', 400000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1001', N'SP_101', N'15', 2, N'14', 400000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1001', N'SP_102', N'16', 2, N'14', 1800000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1002', N'SP_103', N'13', 1, NULL, 20000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1005', N'SP_101', N'14', 2, NULL, 40000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1005', N'SP_102', N'14', 2, NULL, 40000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1005', N'SP_103', N'14', 3, NULL, 60000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1005', N'SP_105', N'14', 1, NULL, 50000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1005', N'SP_106', N'14', 1, NULL, 50000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1006', N'DV_101', N'12', 2, NULL, 400000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1007', N'DV_101', N'10', 9, NULL, 800000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1008', N'SP_106', N'13', 1, NULL, 50000)
INSERT [dbo].[DangKyDichVu] ([IDKhachHang], [IDDichVu], [GioDK], [SL], [LichSD], [TongTien]) VALUES (N'1010', N'SP_106', N'14', 1, NULL, 50000)
INSERT [dbo].[DangKyTour] ([IDKhachHang], [IDTour], [GioDK], [GioXuatPhat], [SoNguoiDi], [TongTien]) VALUES (N'1001', N'TOUR_1001', N'12', N'15', 2, 400000)
INSERT [dbo].[DangKyTour] ([IDKhachHang], [IDTour], [GioDK], [GioXuatPhat], [SoNguoiDi], [TongTien]) VALUES (N'1005', N'TOUR_1002', N'12', N'14', 28, 5600000)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'DV_101', N'Spa
', 200000, 100, 0, N'Trống')
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'DV_102', N'Massage
', 300000, 100, 10, N'Đầy')
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_101', N'Sting', 20000, 200, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_102', N'Bo huc', 20000, 256, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_103', N'Mi tom', 20000, 231, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_104', N'Tra dao', 50000, 456, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_105', N'Tra vai', 50000, 156, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_106', N'Tra hoa lai', 50000, 153, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_107', N'Olong', 20000, 312, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_108', N'Nuoc khoang', 20000, 115, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_109', N'Buffet', 150000, 132, 10, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_110', N'Ruou vang', 500000, 156, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_111', N'Bia Tiger', 50000, 132, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_112', N'Bia 333', 50000, 156, 0, NULL)
INSERT [dbo].[DichVu] ([IDDichVu], [TenDV], [Gia], [SL], [KM], [TinhTrang]) VALUES (N'SP_113', N'Tra da', 11000, 200, 10, N'Đầy')
INSERT [dbo].[Doan] ([IDDoan], [TenDoan], [NguoiDaiDien], [SoNguoi], [IDKhachHang]) VALUES (N'D_101
', N'Cỏ mây
', N'Hoàng Minh Duy
', 28, N'1005')
INSERT [dbo].[Doan] ([IDDoan], [TenDoan], [NguoiDaiDien], [SoNguoi], [IDKhachHang]) VALUES (N'D_102
', N'Cỏ hoa', N'Võ Thị Hương', 9, N'1007')
INSERT [dbo].[Doan] ([IDDoan], [TenDoan], [NguoiDaiDien], [SoNguoi], [IDKhachHang]) VALUES (N'D_103
', N'Cỏ lá', N'Đặng Quốc Khánh', 3, N'1008')
INSERT [dbo].[Doan] ([IDDoan], [TenDoan], [NguoiDaiDien], [SoNguoi], [IDKhachHang]) VALUES (N'D_104', N'Cỏ cây', N'Bùi Thị Lan', 6, N'1009')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_101', CAST(N'2023-06-10' AS Date), N'Tiền mặt
', 1930000, N'NV_5008', N'1001')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_102', CAST(N'2023-06-17' AS Date), N'Tiền mặt
', 1770000, N'NV_5009', N'1002')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_103', CAST(N'2023-06-14' AS Date), N'Tiền mặt
', 700000, N'NV_5010', N'1003')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_104', CAST(N'2023-06-21' AS Date), N'Chuyển khoản
', 3800000, N'NV_5011', N'1004')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_105', CAST(N'2023-06-29' AS Date), N'Tiền mặt
', 38880000, N'NV_5009', N'1005')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_106', CAST(N'2023-06-28' AS Date), N'Chuyển khoản
', 2850000, N'NV_5010', N'1006')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_107', CAST(N'2023-06-30' AS Date), N'Chuyển khoản
', 18680000, N'NV_5011', N'1007')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_108', CAST(N'2023-07-02' AS Date), N'Tiền mặt
', 5090000, N'NV_5008', N'1008')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_109', CAST(N'2023-07-05' AS Date), N'Chuyển khoản
', 2850000, N'NV_5009', N'1009')
INSERT [dbo].[HoaDon] ([IDHoaDon], [NgayLap], [PTTT], [TongTien], [IDNhanVien], [IDKhachHang]) VALUES (N'HD_110', CAST(N'2023-07-12' AS Date), N'Tiền mặt
', 3550000, N'NV_5010', N'1010')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1001', N'Nguyễn Văn Anh', N'364487456415', N'0349326565', N'anh@gmail.com', N'144 Nguyễn Công Trứ, Quận 12, TP.HCM', N'6582635987
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1002', N'Trần Thị Bình', N'125486523569
', N'0359658586
', N'binh@gmail.com
', N'103/20/1 Nguyễn Bỉnh Khiêm, Quận 1, TP.HCM
', N'2563487596
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1003', N'Lê Hoàng Chung
', N'256359875625
', N'0325858969
', N'chung@gmail.com
', N'65 Nguyễn Thị Thập, Quận 7, TP.HCM
', N'6365259875
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1004', N'Phạm Thanh Dương
', N'685478542231
', N'0347525636
', N'duong@gmail.com
', N'47 Cách Mạng Tháng 8, Quận 1, TP.HCM
', N'2658745896
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1005', N'Hoàng Minh Duy
', N'252635478759
', N'0359636525
', N'duy@gmail.com
', N'9 Lê Văn Lợi, Quận Bình Thạnh, TP.HCM
', N'2369857487
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1006', N'Đỗ Xuân Hòa
', N'352654978653
', N'0859545656
', N'hoa@gmail.com
', N'99 Lê Văn Lợi, Quận Bình Tân, TP.HCM', N'6598569778
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1007', N'Võ Thị Hương
', N'154976352649
', N'0359654989
', N'huong@gmail.com
', N'265 Lê Thánh Tông, Quận 5, TP.HCM
', N'2365487535
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1008', N'Đặng Quốc Khánh
', N'365985264785
', N'0358745859
', N'khanh@gmail.com
', N'625 Phạm Văn Đồng, Quận Gò Vấp, TP.HCM
', N'5598956498
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1009', N'Bùi Thị Lan
', N'365985264785
', N'0358695847
', N'lan@gmail.com
', N'25 Chu Văn An, Quận 2, TP.HCM
', N'4564984894
')
INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [CCCD], [SDT], [Email], [DiaChi], [Fax]) VALUES (N'1010', N'Lý Văn Tuấn', N'236523547851', N'0369585956', N'tuan@gmail.com', N'159 Lê Thị Định, Quận 7, TP.HCM', N'6232164984
')
INSERT [dbo].[LoaiPhong] ([IDLoai], [Ten], [Gia], [SoNguoi]) VALUES (N'DOI', N'Đôi', 500000, 2)
INSERT [dbo].[LoaiPhong] ([IDLoai], [Ten], [Gia], [SoNguoi]) VALUES (N'DON', N'Đơn', 300000, 1)
INSERT [dbo].[LoaiPhong] ([IDLoai], [Ten], [Gia], [SoNguoi]) VALUES (N'GIADINH', N'Gia Đình', 800000, 4)
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5001', N'Nguyễn Văn Hải', N'Lễ tân
', CAST(N'2001-12-05' AS Date), N'0562547995
', N'nvh@gmail.com
', N'Nam', N'265478964758 
', N'14 Nguyễn Công Trứ, Quận 12, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5002', N'Phạm Thành Dương', N'Lễ tân
', CAST(N'1999-05-16' AS Date), N'0659874265
', N'ptd@gmail.com
', N'Nam', N'131456487897 
', N'103/20/1 Nguyễn Bỉnh Khiêm, Quận Thủ Đức, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5003', N'Lê Đức', N'Quản lý', CAST(N'1995-08-17' AS Date), N'0326412578
', N'ld@gmail.com
', N'Nam', N'165156489797 
', N'5 Nguyễn Thị Thập, Quận 7, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5004', N'Trần Thị Thủy Tiên', N'Quản lý', CAST(N'1996-06-15' AS Date), N'0232543629
', N'tt@gmail.com
', N'Nữ', N'231514564656 
', N'47 Cách Mạng Tháng 8, Quận 5, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5005', N'Lê Thị Thơ', N'Lễ tân
', CAST(N'1997-12-12' AS Date), N'0264789624
', N'lttho@gmail.com
', N'Nữ', N'321564897897 
', N'9 Lê Lợi, Quận Bình Thạnh, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5006', N'Đỗ Văn Hợp', N'Lễ tân
', CAST(N'1996-01-23' AS Date), N'0264891456
', N'vhop@gmail.com
', N'Nam', N'654846132135 
', N'99 Lê Lợi, Quận Bình Tân, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5007', N'Võ Xuân Hạ', N'Quản lý', CAST(N'1998-08-25' AS Date), N'0236489955
', N'vxh@gmail.com
', N'Nam', N'561849446465 
', N'265 Lê Thánh Tông, Quận 5, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5008', N'Đặng Văn Phong', N'Kỹ sư phần mềm', CAST(N'1998-05-04' AS Date), N'021348947
', N'vphong@gmail.com
', N'Nam', N'165165146849 
', N'555 Phạm Văn Đồng, Quận Gò Vấp, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5009', N'Bùi Thị Cẩm', N'Lễ tân
', CAST(N'1997-07-05' AS Date), N'015648498
', N'btcam@gmail.com
', N'Nữ', N'175161984561 
', N'25 Chu Văn An, Quận 9, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5010', N'Phạm Hải Hà', N'Lễ tân
', CAST(N'2000-04-08' AS Date), N'0165484897
', N'phh@gmail.com
', N'Nữ', N'884156165132 
', N'19 Lê Thị Định, Quận 7, TP.HCM
')
INSERT [dbo].[NhanVien] ([IDNhanVien], [TenNV], [ChucVu], [NgSinh], [SDT], [Email], [GioiTinh], [CCCD], [DiaChi]) VALUES (N'NV_5011', N'Lý Thị Hà', N'Lễ tân
', CAST(N'2000-04-27' AS Date), N'0265785497
', N'ltha@gmail.com
', N'Nữ', N'484561515313 
', N'14 Lương Định Của, Quận Gò vấp, TP.HCM
')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_201', N'Đầy', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_202', N'Đầy', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_203', N'Đầy', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_204', N'Đầy', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_205', N'Trống', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_206', N'Trống', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_207', N'Trống', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DOI_208', N'Trống', N'DOI', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_101', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_102', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_103', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_104', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_105', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_106', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_107', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'DON_108', N'Trống', N'DON', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_301', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_302', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_303', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_304', N'Trống', N'GIADINH', N'Đã dọn dẹp
')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_305', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_306', N'Trống', N'GIADINH', N'Đã dọn dẹp
')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_307', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_308', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[Phong] ([IDPhong], [TrangThai], [IDLoai], [TinhTrang]) VALUES (N'GD_310', N'Trống', N'GIADINH', N'Đã dọn dẹp')
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1001', N'Phương Trang
', N'0349326565
', 11, 350000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1002', N'Đức Hải
', N'0315147897
', 12, 500000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1003', N'Hải Vân
', N'0564896532
', 11, 300000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1004', N'Phương Trinh', N'0454894231
', 12, 350000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1005', N'Thành Bưởi', N'0135498765
', 20, 300000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1006', N'Mai Linh', N'0489465165
', 12, 400000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1007', N'Thiên Kim', N'0321549889
', 12, 300000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1008', N'Tiến Oanh', N'0132184894
', 13, 250000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1009', N'Hải Duyên', N'0316498984
', 14, 200000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1010', N'Bá Hải', N'0154984484
', 15, 350000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1011', N'Đức Nguyên', N'0756846513
', 16, 300000)
INSERT [dbo].[PhuongTien] ([IDNhaXe], [TenNhaXe], [SDT], [GioDen], [Gia]) VALUES (N'NX_1012', N'Phương Trang', N'0123456789', 15, 300000)
INSERT [dbo].[TourDuLich] ([IDTour], [NCC], [NoiDung], [Gia]) VALUES (N'TOUR_1001', N'Công ty Phương Nam
', N'Khám phá khu du lịch sinh thái Phương Nam
', 200000)
INSERT [dbo].[TourDuLich] ([IDTour], [NCC], [NoiDung], [Gia]) VALUES (N'TOUR_1002', N'Công ty Á Đông
', N'Khám Phá khu du lịch sinh thái Á Đông
', 200000)
INSERT [dbo].[ThongTinChuyenPhong] ([IDKhachHang], [IDPhong], [LyDo]) VALUES (N'1009', N'DOI_202', N'Giường hư
')
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1001', N'DOI_201', CAST(N'2023-06-05' AS Date), CAST(N'2023-06-05' AS Date), CAST(N'2023-06-10' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1002', N'DON_101', CAST(N'2023-06-12' AS Date), CAST(N'2023-06-12' AS Date), CAST(N'2023-06-17' AS Date), 1)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1003', N'DON_103', CAST(N'2023-06-12' AS Date), CAST(N'2023-06-12' AS Date), CAST(N'2023-06-14' AS Date), 1)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1004', N'DON_102', CAST(N'2023-06-13' AS Date), CAST(N'2023-06-13' AS Date), CAST(N'2023-06-21' AS Date), 1)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_301', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_302', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_303', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_304', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_305', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_306', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1005', N'GD_307', CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(N'2023-06-29' AS Date), 4)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1006', N'DOI_201', CAST(N'2023-06-21' AS Date), CAST(N'2023-06-21' AS Date), CAST(N'2023-06-28' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1007', N'DOI_202', CAST(N'2023-06-22' AS Date), CAST(N'2023-06-22' AS Date), CAST(N'2023-06-30' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1007', N'DOI_203', CAST(N'2023-06-22' AS Date), CAST(N'2023-06-22' AS Date), CAST(N'2023-06-30' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1007', N'DOI_204', CAST(N'2023-06-22' AS Date), CAST(N'2023-06-22' AS Date), CAST(N'2023-06-30' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1007', N'DOI_205', CAST(N'2023-06-22' AS Date), CAST(N'2023-06-22' AS Date), CAST(N'2023-06-30' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1007', N'DON_101', CAST(N'2023-06-22' AS Date), CAST(N'2023-06-22' AS Date), CAST(N'2023-06-30' AS Date), 1)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1008', N'DOI_206', CAST(N'2023-06-23' AS Date), CAST(N'2023-06-23' AS Date), CAST(N'2023-07-02' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1008', N'DON_102', CAST(N'2023-06-23' AS Date), CAST(N'2023-06-23' AS Date), CAST(N'2023-07-02' AS Date), 1)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1009', N'DOI_201', CAST(N'2023-07-01' AS Date), CAST(N'2023-07-01' AS Date), CAST(N'2023-07-05' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1009', N'DOI_202', CAST(N'2023-07-01' AS Date), CAST(N'2023-07-01' AS Date), CAST(N'2023-07-05' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1009', N'DOI_203', CAST(N'2023-07-01' AS Date), CAST(N'2023-07-01' AS Date), CAST(N'2023-07-05' AS Date), 2)
INSERT [dbo].[ThongTinDatPhong] ([IDKhachHang], [IDPhong], [NgayDat], [NgayCheckIn], [NgayCheckOut], [SoLuongNguoi]) VALUES (N'1010', N'DOI_204', CAST(N'2023-07-02' AS Date), CAST(N'2023-07-02' AS Date), CAST(N'2023-07-12' AS Date), 2)
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_101
', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1001')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_102', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1002')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_103', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1003')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_104', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1002')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_105', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1005')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_112', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1006')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_117', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1007')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_119', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1008')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_122', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1009')
INSERT [dbo].[YCDacBiet] ([IDYeuCau], [TenYC], [NoiDung], [IDKH]) VALUES (N'YC_123', N'Vận chuyển
', N'Đưa hành lý lên phòng
', N'1010')
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_NhanVien]
GO
ALTER TABLE [dbo].[CTHDDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_CTHDDatPhong_HoaDon] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDon] ([IDHoaDon])
GO
ALTER TABLE [dbo].[CTHDDatPhong] CHECK CONSTRAINT [FK_CTHDDatPhong_HoaDon]
GO
ALTER TABLE [dbo].[CTHDDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_CTHDDatPhong_Phong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[Phong] ([IDPhong])
GO
ALTER TABLE [dbo].[CTHDDatPhong] CHECK CONSTRAINT [FK_CTHDDatPhong_Phong]
GO
ALTER TABLE [dbo].[CTHDKemTheo]  WITH CHECK ADD  CONSTRAINT [FK_CTHDKemTheo_DichVu] FOREIGN KEY([IDDichVu])
REFERENCES [dbo].[DichVu] ([IDDichVu])
GO
ALTER TABLE [dbo].[CTHDKemTheo] CHECK CONSTRAINT [FK_CTHDKemTheo_DichVu]
GO
ALTER TABLE [dbo].[CTHDKemTheo]  WITH CHECK ADD  CONSTRAINT [FK_CTHDKemTheo_HoaDon] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDon] ([IDHoaDon])
GO
ALTER TABLE [dbo].[CTHDKemTheo] CHECK CONSTRAINT [FK_CTHDKemTheo_HoaDon]
GO
ALTER TABLE [dbo].[CTHDKemTheo]  WITH CHECK ADD  CONSTRAINT [FK_CTHDKemTheo_TourDuLich] FOREIGN KEY([IDTour])
REFERENCES [dbo].[TourDuLich] ([IDTour])
GO
ALTER TABLE [dbo].[CTHDKemTheo] CHECK CONSTRAINT [FK_CTHDKemTheo_TourDuLich]
GO
ALTER TABLE [dbo].[DangKyDichVu]  WITH CHECK ADD  CONSTRAINT [FK_DangKyDichVu_DichVu] FOREIGN KEY([IDDichVu])
REFERENCES [dbo].[DichVu] ([IDDichVu])
GO
ALTER TABLE [dbo].[DangKyDichVu] CHECK CONSTRAINT [FK_DangKyDichVu_DichVu]
GO
ALTER TABLE [dbo].[DangKyDichVu]  WITH CHECK ADD  CONSTRAINT [FK_DangKyDichVu_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[DangKyDichVu] CHECK CONSTRAINT [FK_DangKyDichVu_KhachHang]
GO
ALTER TABLE [dbo].[DangKyTour]  WITH CHECK ADD  CONSTRAINT [FK_DangKyTour_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[DangKyTour] CHECK CONSTRAINT [FK_DangKyTour_KhachHang]
GO
ALTER TABLE [dbo].[DangKyTour]  WITH CHECK ADD  CONSTRAINT [FK_DangKyTour_TourDuLich] FOREIGN KEY([IDTour])
REFERENCES [dbo].[TourDuLich] ([IDTour])
GO
ALTER TABLE [dbo].[DangKyTour] CHECK CONSTRAINT [FK_DangKyTour_TourDuLich]
GO
ALTER TABLE [dbo].[Doan]  WITH CHECK ADD  CONSTRAINT [FK_Doan_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[Doan] CHECK CONSTRAINT [FK_Doan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang1] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang1]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([IDLoai])
REFERENCES [dbo].[LoaiPhong] ([IDLoai])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
ALTER TABLE [dbo].[ThongTinChuyenPhong]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinChuyenPhong_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[ThongTinChuyenPhong] CHECK CONSTRAINT [FK_ThongTinChuyenPhong_KhachHang]
GO
ALTER TABLE [dbo].[ThongTinChuyenPhong]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinChuyenPhong_Phong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[Phong] ([IDPhong])
GO
ALTER TABLE [dbo].[ThongTinChuyenPhong] CHECK CONSTRAINT [FK_ThongTinChuyenPhong_Phong]
GO
ALTER TABLE [dbo].[ThongTinDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinDatPhong_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[ThongTinDatPhong] CHECK CONSTRAINT [FK_ThongTinDatPhong_KhachHang]
GO
ALTER TABLE [dbo].[ThongTinDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinDatPhong_Phong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[Phong] ([IDPhong])
GO
ALTER TABLE [dbo].[ThongTinDatPhong] CHECK CONSTRAINT [FK_ThongTinDatPhong_Phong]
GO
ALTER TABLE [dbo].[YCDacBiet]  WITH CHECK ADD  CONSTRAINT [FK_YCDacBiet_KhachHang] FOREIGN KEY([IDKH])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[YCDacBiet] CHECK CONSTRAINT [FK_YCDacBiet_KhachHang]
GO
