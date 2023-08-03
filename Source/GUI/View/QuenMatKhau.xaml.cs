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
using System.Security.Principal;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for QuenMatKhau_XacNhanNV.xaml
    /// </summary>
    public partial class QuenMatKhau : Window
    {
        TaiKhoan taikhoan = new TaiKhoan();

        TaiKhoanBLL TKBLL = new TaiKhoanBLL();

        public DangNhap DangNhapScreen { get; set; } 

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            string idNhanVien = txtMaNhanVien.Text;

            string pw = txtMatKhauMoi.Text;
            string repeatpw = txtXacNhanMatKhau.Text;

            taikhoan.IDNhanVien = idNhanVien;
            taikhoan.quyen = 1;

            string res = TKBLL.CheckLogicSuaTaiKhoan(taikhoan);
            switch (res)
            {
                case "Invalid":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
                case "ID Nhan Vien not exist":
                    MessageBox.Show("Nhân viên không tồn tại");
                    return;
            }

            taikhoan = TKBLL.TimTaiKhoanCoIDNhanVien(idNhanVien);

            if (repeatpw != pw)
            {
                MessageBox.Show("Mật khẩu không đúng");
                return;
            }
            
            taikhoan.pw = pw;
            TKBLL.SuaTaiKhoan(taikhoan);
            MessageBox.Show("Lấy lại mật khẩu thành công");

            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
