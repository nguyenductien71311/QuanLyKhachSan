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
    /// Interaction logic for SuaThongTinKhachHang.xaml
    /// </summary>
    public partial class SuaThongTinKhachHang : Window
    {
        private KhachHang KH = new KhachHang();

        public QuanLyKhachHang QLKHScreen { get; set; }
        public SuaThongTinKhachHang(KhachHang selectedKhachHang)
        {
            InitializeComponent();

            KH = selectedKhachHang;
            txtTenKH.Text = KH.TenKH;
            txtCCCD.Text = KH.CCCD;
            txtDiaChi.Text = KH.DiaChi;
            txtSDT.Text = KH.SDT;
            txtEmail.Text = KH.Email;
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            KH.TenKH = txtTenKH.Text;
            KH.CCCD = txtCCCD.Text;
            KH.DiaChi = txtDiaChi.Text;
            KH.SDT = txtSDT.Text;
            KH.Email = txtEmail.Text;

            KhachHangBLL KhachHangBLL = new KhachHangBLL();
            int check = KhachHangBLL.CheckLogicSuaTTKH(KH);
            switch(check)
            {
                case 0:
                    MessageBox.Show("Chưa nhập đầy đủ thông tin!");
                    return;
            }
            KhachHangBLL.SuaTTKhachHang(KH);
            MessageBox.Show("Sửa thông tin khách hàng thành công!");
            QLKHScreen.LoadDataKH();
            this.Close();
        }
    }
}
