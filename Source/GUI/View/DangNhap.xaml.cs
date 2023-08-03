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
using System.Net;
using GUI.UserControls;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        //thông tin người dùng nhập
        TaiKhoan taikhoan = new TaiKhoan();


        TaiKhoanBLL TKBLL = new TaiKhoanBLL();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            taikhoan.Username = txtTenDN.Text;

            string password = new NetworkCredential(string.Empty, txtMK1.SecurePassword).Password;
            taikhoan.pw = password;

            string getuser = TKBLL.CheckLogic(taikhoan);
            //Trả lại kết quả
            switch (getuser)
            {
                case "requied_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống");
                    return;
                case "requied_matkhau":
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;
                case "Tài khoản hoặc mật khẩu không chính xác":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                    return;
            }

            int quyen = TKBLL.QuyenTaiKhoan(taikhoan);
            taikhoan.quyen = quyen;

            contentDisplayMain.Content = new DanhSachPhong(taikhoan);
            //MessageBox.Show("Đăng nhập thành công");

        }

        private void btnQuenMatKhau_Click(object sender, RoutedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.DangNhapScreen = this;
            quenMatKhau.ShowDialog();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
