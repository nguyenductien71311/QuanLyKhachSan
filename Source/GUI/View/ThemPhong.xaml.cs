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
    /// Interaction logic for Them_SuaPhong.xaml
    /// </summary>
    public partial class ThemPhong : Window
    {
        Phong phong = new Phong();
        public QuanLyPhong QuanLyPhongScreen { get; set; }
        public ThemPhong()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            phong.IDPhong = txtSoPhong.Text;
            phong.TinhTrang = cmbTinhTrang.Text;
            phong.LoaiPhong = cmbLoaiPhong.Text;
            phong.TrangThai = cmbTrangThai.Text;

            PhongBLL phongBLL = new PhongBLL();
            string res = phongBLL.CheckLogicThemPhong(phong);
            switch (res)
            {
                case "ID_Exist":
                    MessageBox.Show("IDPhong đã tồn tại");
                    return;
                case "Required_attriute":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
            }
            phongBLL.ThemPhong(phong);
            QuanLyPhongScreen.LoadPhong();
            MessageBox.Show("Thêm loại phòng thành công!");
            this.Close();
        }
    }
}
