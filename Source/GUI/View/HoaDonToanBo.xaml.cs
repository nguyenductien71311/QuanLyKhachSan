using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for HoaDonToanBo.xaml
    /// </summary>
    public partial class HoaDonToanBo : Window
    {
        ThongTinDatPhong ttdp = new ThongTinDatPhong();

        KhachHangBLL khBLL = new KhachHangBLL();
        DoanBLL doanBLL = new DoanBLL();

        ChiTietThongTinDatPhongBLL cttdpBLL = new ChiTietThongTinDatPhongBLL();

        HoaDonBLL hoadonBLL = new HoaDonBLL();
        ChiTietThongTinDatPhongBLL cthdDatPhongBLL = new ChiTietThongTinDatPhongBLL();

        DangKyDichVuBLL dkdvBLL = new DangKyDichVuBLL();
        DangKyTourBLL dktourBLL = new DangKyTourBLL();

        public ThanhToan ThanhToanScreen { get; set; }

        public HoaDonToanBo(ThongTinDatPhong selectedTTDP)
        {
            InitializeComponent();

            ttdp = selectedTTDP;

            LoadThongTinKhachHang(ttdp);
            LoadThongTinDichVu(ttdp);
        }

        public void LoadThongTinKhachHang(ThongTinDatPhong ttdp)
        {
            KhachHang kh = new KhachHang();
            kh = khBLL.TimKhachHangCoIDKhachHang(ttdp.IDKhachHang);

            Doan doan = new Doan();
            doan = doanBLL.LoadDoanData(ttdp.IDKhachHang);

            txtTenDoan.Text = doan.TenDoan;

            if (string.IsNullOrEmpty(doan.IDKhachHang))
            {
                txtTenDoan.Text = "Không có";
            }

            txbTenKH.Text = kh.TenKH;


            DateTime today = DateTime.Now;

            string stoday = today.TimeOfDay.ToString();

            txtMaHoaDon.Text = stoday;
        }

        public void LoadThongTinDichVu(ThongTinDatPhong ttdp)
        {
            ObservableCollection<ChiTietThongTinDatPhong> DSphongdadat = new ObservableCollection<ChiTietThongTinDatPhong>();

            ObservableCollection<DangKyDichVu> DSdkDV = new ObservableCollection<DangKyDichVu>();
            ObservableCollection<DangKyDichVu> DSdkSP = new ObservableCollection<DangKyDichVu>();

            ObservableCollection<DangKyTour> DSdkTour = new ObservableCollection<DangKyTour>();

            DSdkDV = dkdvBLL.LoadDKDV(ttdp.IDKhachHang);
            DSdkSP = dkdvBLL.LoadDKSP(ttdp.IDKhachHang);
            DSdkTour = dktourBLL.LoadDKTour(ttdp.IDKhachHang);

            DSphongdadat = cttdpBLL.LoadCTTTDPData(ttdp);

            txbNgayCheckIn.Text = DSphongdadat[0].NgayCheckIn.Date.ToString();
            txtNgayCheckOut.Text = DSphongdadat[0].NgayCheckOut.Date.ToString();

            DateTime ngaycheckin = DSphongdadat[0].NgayCheckIn;
            DateTime ngaycheckout = DSphongdadat[0].NgayCheckOut;

            TimeSpan songay = ngaycheckout - ngaycheckin;
            int tongsongay = songay.Days;

            if (tongsongay <= 0)
            {
                tongsongay = 1;
            }

            txtSoNgay.Text = tongsongay.ToString();

            List<DichVu_DaChon> ls = new List<DichVu_DaChon>();

            int SoPhongDon = 0;
            int SoPhongDoi = 0;
            int SoPhongGiaDinh = 0;

            int GiaPhongDon = 0;
            int GiaPhongDoi = 0;
            int GiaPhongGiaDinh = 0;

            foreach (var ctttdp in DSphongdadat)
            {
                if (ctttdp.TenLoaiPhong == "Đơn")
                {
                    SoPhongDon += 1;
                    GiaPhongDon = hoadonBLL.Gia_Phong(ctttdp.IDPhong);
                }

                else if (ctttdp.TenLoaiPhong == "Đôi")
                {
                    SoPhongDoi += 1;
                    GiaPhongDoi = hoadonBLL.Gia_Phong(ctttdp.IDPhong);
                }

                else if (ctttdp.TenLoaiPhong == "Gia Đình")
                {
                    SoPhongGiaDinh += 1;
                    GiaPhongGiaDinh = hoadonBLL.Gia_Phong(ctttdp.IDPhong);
                }
            }

            if (SoPhongDon != 0)
            {
                DichVu_DaChon dvphongdon = new DichVu_DaChon();

                dvphongdon.TenDV = "Phòng Đơn (70%)";
                dvphongdon.SoLuong = SoPhongDon;
                dvphongdon.GiaTien = GiaPhongDon;
                dvphongdon.ThanhTien = GiaPhongDon * SoPhongDon * 0.7 * tongsongay;

                ls.Add(dvphongdon);
            }

            if (SoPhongDoi != 0)
            {
                DichVu_DaChon dvphongdoi = new DichVu_DaChon();

                dvphongdoi.TenDV = "Phòng Đôi (70%)";
                dvphongdoi.SoLuong = SoPhongDoi;
                dvphongdoi.GiaTien = GiaPhongDoi;
                dvphongdoi.ThanhTien = GiaPhongDoi * SoPhongDoi * 0.7 * tongsongay;

                ls.Add(dvphongdoi);
            }

            if (SoPhongGiaDinh != 0)
            {
                DichVu_DaChon dvphonggiadinh = new DichVu_DaChon();

                dvphonggiadinh.TenDV = "Phòng Gia đình (70%)";
                dvphonggiadinh.SoLuong = SoPhongGiaDinh;
                dvphonggiadinh.GiaTien = GiaPhongGiaDinh;
                dvphonggiadinh.ThanhTien = GiaPhongGiaDinh * SoPhongGiaDinh * 0.7 * tongsongay;

                ls.Add(dvphonggiadinh);
            }

            double TongTienDichVu = 0;

            foreach (var dkdv in DSdkDV)
            {
                DichVu_DaChon dichvu = new DichVu_DaChon();

                dichvu.TenDV = dkdvBLL.NameDV(dkdv.IDDichVu);
                dichvu.GiaTien = hoadonBLL.Gia_DichVU(dkdv.IDDichVu);
                dichvu.SoLuong = dkdv.SL;
                dichvu.ThanhTien = dkdv.TongTien;

                TongTienDichVu += dkdv.TongTien;

                ls.Add(dichvu);
            }

            foreach (var dksp in DSdkSP)
            {
                DichVu_DaChon sanpham = new DichVu_DaChon();

                sanpham.TenDV = dkdvBLL.NameDV(dksp.IDDichVu);
                sanpham.GiaTien = hoadonBLL.Gia_DichVU(dksp.IDDichVu);
                sanpham.SoLuong = dksp.SL;
                sanpham.ThanhTien = dksp.TongTien;

                TongTienDichVu += dksp.TongTien;

                ls.Add(sanpham);
            }

            foreach (var dktour in DSdkTour)
            {
                DichVu_DaChon tour = new DichVu_DaChon();

                tour.TenDV = dktourBLL.TourName(dktour.IDTour);
                tour.GiaTien = hoadonBLL.Gia_Tour(dktour.IDTour);
                tour.SoLuong = dktour.SoNguoiDi;
                tour.ThanhTien = dktour.TongTien;

                TongTienDichVu += dktour.TongTien;

                ls.Add(tour);
            }

            double TongTienDatPhong = 0;

            double TongTien = 0;


            TongTienDatPhong = (GiaPhongDon * SoPhongDon + GiaPhongDoi * SoPhongDoi + GiaPhongGiaDinh * SoPhongGiaDinh) * 0.7 * tongsongay;

            TongTien = TongTienDichVu + TongTienDatPhong;

            lvDichVuDaSD.ItemsSource = ls;
            txtTongTien.Text = TongTien.ToString();
        }

        public void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hoadontoanbo = new HoaDon();

            ObservableCollection<ChiTietHoaDonDatPhong> DScthddatphong = new ObservableCollection<ChiTietHoaDonDatPhong>();
            ObservableCollection<ChiTietHoaDonKemTheo> DSTourcthdkemtheo = new ObservableCollection<ChiTietHoaDonKemTheo>();
            ObservableCollection<ChiTietHoaDonKemTheo> DSDVcthdkemtheo = new ObservableCollection<ChiTietHoaDonKemTheo>();

            ObservableCollection<ChiTietThongTinDatPhong> DSctttdp = new ObservableCollection<ChiTietThongTinDatPhong>();

            ObservableCollection<DangKyDichVu> DSdkDV = new ObservableCollection<DangKyDichVu>();
            ObservableCollection<DangKyDichVu> DSdkSP = new ObservableCollection<DangKyDichVu>();

            ObservableCollection<DangKyTour> DSdkTour = new ObservableCollection<DangKyTour>();

            DSctttdp = cttdpBLL.LoadCTTTDPData(ttdp);

            DSdkDV = dkdvBLL.LoadDKDV(ttdp.IDKhachHang);
            DSdkSP = dkdvBLL.LoadDKSP(ttdp.IDKhachHang);

            DSdkTour = dktourBLL.LoadDKTour(ttdp.IDKhachHang);


            hoadontoanbo.IDHoaDon = txtMaHoaDon.Text;
            hoadontoanbo.NgayLap = DateTime.Now.Date;
            hoadontoanbo.PTTT = "Chuyển khoản";
            hoadontoanbo.TongTien = Convert.ToInt32(txtTongTien.Text);
            hoadontoanbo.IDNhanVien = "NV_5001";
            hoadontoanbo.IDKhachHang = ttdp.IDKhachHang;

            hoadonBLL.TaoHoaDon(hoadontoanbo);

            DateTime ngaycheckin = Convert.ToDateTime(txbNgayCheckIn.Text);
            DateTime ngaycheckout = Convert.ToDateTime(txtNgayCheckOut.Text);

            TimeSpan songay = ngaycheckout - ngaycheckin;
            int tongsongay = songay.Days;

            if (tongsongay <= 0)
            {
                tongsongay = 1;
            }

            foreach (var ctttdp in DSctttdp)
            {
                ChiTietHoaDonDatPhong cthddatphong = new ChiTietHoaDonDatPhong();
                cthddatphong.IDHoaDon = hoadontoanbo.IDHoaDon;
                cthddatphong.IDPhong = ctttdp.IDPhong;
                cthddatphong.TienCoc = Convert.ToInt32(hoadonBLL.Gia_Phong(ctttdp.IDPhong) * 0.3 * tongsongay);
                cthddatphong.TienSauCheckOut = Convert.ToInt32(hoadonBLL.Gia_Phong(ctttdp.IDPhong) * tongsongay * 0.7);

                DScthddatphong.Add(cthddatphong);
            }

            int stt = 0;
            int soluongDV = 0;
            int soluongTour = 0;

            foreach (var dkdv in DSdkDV)
            {
                stt += 1;
                soluongDV += 1;

                ChiTietHoaDonKemTheo cthdkemtheo = new ChiTietHoaDonKemTheo();
                cthdkemtheo.IDHoaDon = hoadontoanbo.IDHoaDon;
                cthdkemtheo.IDDichVu = dkdv.IDDichVu;
                //cthdkemtheo.IDTour = null;
                cthdkemtheo.STT = stt;

                DSDVcthdkemtheo.Add(cthdkemtheo);

            }

            foreach (var dksp in DSdkSP)
            {
                stt += 1;
                soluongDV += 1;

                ChiTietHoaDonKemTheo cthdkemtheo = new ChiTietHoaDonKemTheo();
                cthdkemtheo.IDHoaDon = hoadontoanbo.IDHoaDon;
                cthdkemtheo.IDDichVu = dksp.IDDichVu;
                //cthdkemtheo.IDTour = null;
                cthdkemtheo.STT = stt;

                DSDVcthdkemtheo.Add(cthdkemtheo);

            }

            foreach (var dktour in DSdkTour)
            {
                stt += 1;
                soluongTour += 1;

                ChiTietHoaDonKemTheo cthdkemtheo = new ChiTietHoaDonKemTheo();
                cthdkemtheo.IDHoaDon = hoadontoanbo.IDHoaDon;
                //cthdkemtheo.IDDichVu = null;
                cthdkemtheo.IDTour = dktour.IDTour;
                cthdkemtheo.STT = stt;

                DSTourcthdkemtheo.Add(cthdkemtheo);

            }

            hoadonBLL.TaoChiTietHoaDonDatPhong(DScthddatphong);

            //if (soluongDV > 0 && soluongTour > 0)
            //{
            //    hoadonBLL.TaoChiTietHoaDonKemTheo(DScthdkemtheo);
            //}
            //else if (soluongDV > 0 && soluongTour == 0)
            //{
            //    hoadonBLL.TaoDVChiTietHoaDonKemTheo(DScthdkemtheo);
            //}
            //else if (soluongDV == 0 && soluongTour > 0)
            //{
            //    hoadonBLL.TaoTOURChiTietHoaDonKemTheo(DScthdkemtheo);
            //}
            //else if (soluongTour == 0 && soluongDV == 0)
            //{
            //    hoadonBLL.TaoChiTietHoaDonKemTheo(DScthdkemtheo);
            //}

            if (soluongDV > 0)
            {
                hoadonBLL.TaoDVChiTietHoaDonKemTheo(DSDVcthdkemtheo);
            }
            
            if (soluongTour > 0)
            {
                hoadonBLL.TaoTOURChiTietHoaDonKemTheo(DSTourcthdkemtheo);
            }


            PhongBLL phongBLL = new PhongBLL();

            foreach (var ctttdp in DSctttdp)
            {
                Phong phongcheckout = new Phong();
                phongcheckout = phongBLL.TimPhongCoIDPhong(ctttdp.IDPhong);
                phongcheckout.TrangThai = "Trống";
                phongcheckout.TinhTrang = "Chưa dọn dẹp";
                phongBLL.SuaPhong(phongcheckout);
            }

            MessageBox.Show("Thanh toán thành công");
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
