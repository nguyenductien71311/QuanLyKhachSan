using BLL;
using DTO;
using GUI.UserControls;
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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ThemTaiKhoan.xaml
    /// </summary>
    public partial class ThemTaiKhoan : Window
    {
        TaiKhoan account = new TaiKhoan();

        public QuanLyTaiKhoan QuanLyTaiKhoanScreen { get; set; }

        public ThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            account.IDTK = txtMaTaiKhoan.Text;
            account.Username = txtUsername.Text;
            account.pw = txtPassword.Text;
            account.quyen = int.TryParse(txtQuyenHan.Text, out int quyenHan) ? quyenHan : 0;
            account.IDNhanVien = txtMaNhanVien.Text;

            TaiKhoanBLL accountBLL = new TaiKhoanBLL();
            string res = accountBLL.CheckLogicThemTaiKhoan(account);
            switch (res)
            {
                case "ID_Exist":
                    MessageBox.Show("ID Tai Khoan đã tồn tại");
                    return;
                case "Required_attriute":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
                case "ID Nhan Vien not exist":
                    MessageBox.Show("ID Nhan Vien không tồn tại");
                    return;
            }

            accountBLL.ThemTaiKhoan(account);
            QuanLyTaiKhoanScreen.LoadTaiKhoan();
            MessageBox.Show("Thêm tài khoản thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
