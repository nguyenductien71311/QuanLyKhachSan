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
using DTO;
using BLL;
using GUI.UserControls;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Them_SuaNhanVien.xaml
    /// </summary>
    public partial class SuaNhanVien : Window
    {
        private NhanVien nhanvien = new NhanVien();
        public QuanLyNhanVien QuanLyNhanVienScreen { get; set; }
        public SuaNhanVien(NhanVien selectedNhanVien)
        {
            InitializeComponent();
            nhanvien = selectedNhanVien;
            txbHoTenNV.Text = nhanvien.TenNV;
            txbEmail.Text = nhanvien.Email;
            txbCCCD.Text = nhanvien.CCCD;
            txbChucVu.Text = nhanvien.ChucVu;
            txbSDT.Text = nhanvien.SDT;
            dtNTNS.SelectedDate = DateTime.Parse(nhanvien.NgSinh);
            cbGioiTinh.Text = nhanvien.GioiTinh;
            txbDiaChi.Text = nhanvien.DiaChi;
        }

        private void CapNhat_Click(object sender, RoutedEventArgs e)
        {
            nhanvien.TenNV = txbHoTenNV.Text;
            nhanvien.ChucVu = txbChucVu.Text;
            nhanvien.CCCD = txbCCCD.Text;
            nhanvien.DiaChi = txbDiaChi.Text;
            nhanvien.SDT = txbSDT.Text;
            nhanvien.Email = txbEmail.Text;
            nhanvien.GioiTinh = cbGioiTinh.Text;
            nhanvien.NgSinh = dtNTNS.Text;

            NhanVienBLL nhanvienBLL = new NhanVienBLL();

            nhanvienBLL.SuaNhanVien(nhanvien);
            QuanLyNhanVienScreen.LoadNhanVien();
            MessageBox.Show("Sửa thông tin nhân viên thành công!");
            this.Close();
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
