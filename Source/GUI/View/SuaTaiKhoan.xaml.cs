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
    /// Interaction logic for SuaTaiKhoan.xaml
    /// </summary>
    public partial class SuaTaiKhoan : Window
    {
        private TaiKhoan taikhoan = new TaiKhoan();

        public QuanLyTaiKhoan QuanLyTaiKhoanScreen { get; set; }
        public SuaTaiKhoan(TaiKhoan selectedTaiKhoan)
        {
            InitializeComponent();

            taikhoan = selectedTaiKhoan;

            txtUsername.Text = taikhoan.Username;
            txtPassword.Text = taikhoan.pw;
            txtQuyenHan.Text = taikhoan.quyen.ToString();
            txtMaNhanVien.Text = taikhoan.IDNhanVien; 
        }
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            taikhoan.Username = txtUsername.Text;
            taikhoan.pw = txtPassword.Text;
            taikhoan.quyen = int.TryParse(txtQuyenHan.Text, out int quyen) ? quyen : 0;
            taikhoan.IDNhanVien = txtMaNhanVien.Text;

            TaiKhoanBLL taikhoanBLL = new TaiKhoanBLL();
            string res = taikhoanBLL.CheckLogicSuaTaiKhoan(taikhoan);
            switch (res)
            {
                case "Invalid":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
                case "ID Nhan Vien not exist":
                    MessageBox.Show("Nhân viên không tồn tại");
                    return;
            }
            taikhoanBLL.SuaTaiKhoan(taikhoan);
            QuanLyTaiKhoanScreen.LoadTaiKhoan();
            MessageBox.Show("Sửa tài khoản thành công!");
            this.Close();

        }
    }
}
