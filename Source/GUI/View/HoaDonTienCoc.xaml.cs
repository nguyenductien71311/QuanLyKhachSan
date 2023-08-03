using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for HoaDonTienCoc.xaml
    /// </summary>
    public partial class HoaDonTienCoc : Window
    {
        ThongTinDatPhong ttdp = new ThongTinDatPhong();

        KhachHangBLL khBLL = new KhachHangBLL();
        DoanBLL doanBLL = new DoanBLL();

        ChiTietThongTinDatPhongBLL cttdpBLL = new ChiTietThongTinDatPhongBLL();

        HoaDonBLL hoadonBLL = new HoaDonBLL();
        ChiTietThongTinDatPhongBLL cthdDatPhongBLL = new ChiTietThongTinDatPhongBLL();

        public ThanhToan ThanhToanScreen { get; set; }


        public HoaDonTienCoc(ThongTinDatPhong selectedTTDP)
        {
            InitializeComponent();

            ttdp = selectedTTDP;

            LoadThongTinKhachHang(ttdp);
            LoadTienThongTinDatPhong(ttdp);
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

        public void LoadTienThongTinDatPhong(ThongTinDatPhong ttdp)
        {
            ObservableCollection<ChiTietThongTinDatPhong> DSphongdadat = new ObservableCollection<ChiTietThongTinDatPhong>();

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

            int SoPhongDon = 0;
            int SoPhongDoi = 0;
            int SoPhongGiaDinh = 0;

            double TongTien = 0;

            int GiaPhongDon = 0;
            int GiaPhongDoi = 0;
            int GiaPhongGiaDinh = 0;

            List<DichVu_DaChon> ls = new List<DichVu_DaChon>();

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

            TongTien = (GiaPhongDon * SoPhongDon + GiaPhongDoi * SoPhongDoi + GiaPhongGiaDinh * SoPhongGiaDinh) * 0.3 * tongsongay;

            txtTongTien.Text = TongTien.ToString();

            if (SoPhongDon != 0)
            {
                DichVu_DaChon dvphongdon = new DichVu_DaChon();

                dvphongdon.TenDV = "Phòng Đơn (30%)";
                dvphongdon.SoLuong = SoPhongDon;
                dvphongdon.GiaTien = GiaPhongDon;
                dvphongdon.ThanhTien = GiaPhongDon * SoPhongDon * 0.3 * tongsongay;

                ls.Add(dvphongdon);
            }

            if (SoPhongDoi != 0)
            {
                DichVu_DaChon dvphongdoi = new DichVu_DaChon();

                dvphongdoi.TenDV = "Phòng Đôi (30%)";
                dvphongdoi.SoLuong = SoPhongDoi;
                dvphongdoi.GiaTien = GiaPhongDoi;
                dvphongdoi.ThanhTien = GiaPhongDoi * SoPhongDoi * 0.3 * tongsongay;

                ls.Add(dvphongdoi);
            }

            if (SoPhongGiaDinh != 0)
            {
                DichVu_DaChon dvphonggiadinh = new DichVu_DaChon();

                dvphonggiadinh.TenDV = "Phòng Gia đình (30%)";
                dvphonggiadinh.SoLuong = SoPhongGiaDinh;
                dvphonggiadinh.GiaTien = GiaPhongGiaDinh;
                dvphonggiadinh.ThanhTien = GiaPhongGiaDinh * SoPhongGiaDinh * 0.3 * tongsongay;

                ls.Add(dvphonggiadinh);
            }

            lsvPhongDaDat.ItemsSource = ls;
        }

        public void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ChiTietThongTinDatPhong> DSctttdp = new ObservableCollection<ChiTietThongTinDatPhong>();
            DSctttdp = cttdpBLL.LoadCTTTDPData(ttdp);

            HoaDon hoadontiencoc = new HoaDon();

            ObservableCollection<ChiTietHoaDonDatPhong> DScthddatphong = new ObservableCollection<ChiTietHoaDonDatPhong>();

            hoadontiencoc.IDHoaDon = txtMaHoaDon.Text;
            hoadontiencoc.NgayLap = DateTime.Now.Date;
            hoadontiencoc.PTTT = "Chuyển khoản";
            hoadontiencoc.TongTien = Convert.ToInt32(txtTongTien.Text);
            hoadontiencoc.IDNhanVien = "NV_5001";
            hoadontiencoc.IDKhachHang = ttdp.IDKhachHang;

            hoadonBLL.TaoHoaDon(hoadontiencoc);

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
                cthddatphong.IDHoaDon = hoadontiencoc.IDHoaDon;
                cthddatphong.IDPhong = ctttdp.IDPhong;
                cthddatphong.TienCoc = Convert.ToInt32(hoadonBLL.Gia_Phong(ctttdp.IDPhong) * 0.3 * tongsongay);
                cthddatphong.TienSauCheckOut = Convert.ToInt32(hoadonBLL.Gia_Phong(ctttdp.IDPhong) * tongsongay * 0.7);

                DScthddatphong.Add(cthddatphong);
            }

            hoadonBLL.TaoChiTietHoaDonDatPhong(DScthddatphong);

            MessageBox.Show("Thanh toán tiền cọc thành công");
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
