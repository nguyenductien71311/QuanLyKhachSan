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
    /// Interaction logic for Them_SuaPhong.xaml
    /// </summary>
    public partial class SuaPhong : Window
    {
        private Phong phong = new Phong();
        public bool DaCapNhat { get; private set; }
        public QuanLyPhong QuanLyPhongScreen { get; set; }
        public SuaPhong(Phong selectedPhong)
        {
            InitializeComponent();
            phong = selectedPhong;
            cmbLoaiPhong.Text = phong.LoaiPhong;
            cmbTinhTrang.Text = phong.TinhTrang;
            cmbTrangThai.Text = phong.TrangThai;
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            phong.TinhTrang = cmbTinhTrang.Text;
            phong.TrangThai = cmbTrangThai.Text;
            phong.LoaiPhong = cmbLoaiPhong.Text;

            PhongBLL phongBLL = new PhongBLL();
            phongBLL.SuaPhong(phong);
            QuanLyPhongScreen.LoadPhong();
            MessageBox.Show("Sửa phòng thành công!");
            this.Close();
        }
    }
}
