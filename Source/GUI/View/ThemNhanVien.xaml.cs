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
using System.Collections.ObjectModel;
using DTO;
using BLL;
using GUI.UserControls;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Them_SuaNhanVien.xaml
    /// </summary>
    public partial class ThemNhanVien : Window
    {
        NhanVien nhanvien = new NhanVien();
        public QuanLyNhanVien QuanLyNhanVienScreen { get; set; }
        public ThemNhanVien()
        {
            InitializeComponent();
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ThemNV_Click(object sender, RoutedEventArgs e)
        {
            nhanvien.IDNhanVien = txbMaNV.Text;
            nhanvien.TenNV = txbHoTenNV.Text;
            nhanvien.ChucVu = txbChucVu.Text;
            nhanvien.Email = txbEmail.Text;
            nhanvien.SDT = txbSDT.Text;
            nhanvien.DiaChi = txbDiaChi.Text;
            nhanvien.CCCD = txbCCCD.Text;
            nhanvien.GioiTinh = cbGioiTinh.Text;
            nhanvien.NgSinh = dtNTNS.Text;

            NhanVienBLL nhanvienBLL = new NhanVienBLL();
            string res = nhanvienBLL.CheckLogicThemNhanVien(nhanvien);
            switch (res)
            {
                case "ID_Exist":
                    MessageBox.Show("IDNhanVien đã tồn tại");
                    return;
                case "Required_attriute":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
            }
            nhanvienBLL.ThemNhanVien(nhanvien);
            QuanLyNhanVienScreen.LoadNhanVien();
            MessageBox.Show("Thêm nhân viên thành công!");
            this.Close();
        }
    }
}
