using DTO;
using System;
using System.Collections.Generic;
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
using BLL;
using GUI.UserControls;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ChiTietPhong.xaml
    /// </summary>


    public partial class ChiTietPhong : Window
    {
        private ThongTinDatPhong ttdp = new ThongTinDatPhong();
        private KhachHang kh = new KhachHang();
        private Phong phong = new Phong();
        public DanhSachPhong_GH DanhSachPhongScreen { get; set; }
        public string idkh;


        public ChiTietPhong(Phong selectedPhong)
        {
            InitializeComponent();
            phong = selectedPhong;
            ttdp = ThongTinDatPhongBLL.TimDataTTPD(phong.IDPhong);
            kh = KhachHangBLL.TimDataKH_IDPhong(phong.IDPhong);
            txblTieuDe.Text = phong.IDPhong;
            if (kh != null && ttdp != null & phong.TrangThai == "Đầy")
            {
                this.idkh = kh.IDKhachHang;
                txblTenKH.Text = kh.TenKH;
                txblSDT.Text = kh.SDT;
                txblEmail.Text = kh.Email;
                txblFax.Text = kh.Fax;
                txblCCCD.Text = kh.CCCD;
                txblNgayCheckIn.Text = ttdp.NgayCheckIn.ToString();
                txblNgayCheckOut.Text = ttdp.NgayCheckOut.ToString();
                txblSoNguoiO.Text = ttdp.SoLuongNguoi.ToString();
                txblTrangThai.Text = phong.TrangThai;
                txblTinhTrang.Text = phong.TinhTrang;
                txblSoNguoi.Text = ttdp.SoLuongNguoi.ToString();
                txblLoaiPhong.Text = phong.LoaiPhong;
                btnDVTour.IsEnabled = true;
                btnDV.IsEnabled = true;
                btnSP.IsEnabled = true;
            }
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void btnDVTour_Click(object sender, RoutedEventArgs e)
        {
            string id = this.idkh;
            ThemDichVuTour themDV = new ThemDichVuTour(id);
            themDV.Show();
        }

        private void btnSP_Click(object sender, RoutedEventArgs e)
        {
            string id = this.idkh;
            ThemSanPham themSP = new ThemSanPham(id);
            themSP.Show();
        }

        private void btnDV_Click(object sender, RoutedEventArgs e)
        {
            string id = this.idkh;
            ThemDichVu themDV = new ThemDichVu(id);
            themDV.Show();
        }

    }
}
