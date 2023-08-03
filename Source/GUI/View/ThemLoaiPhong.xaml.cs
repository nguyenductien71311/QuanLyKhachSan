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
    /// Interaction logic for Them_SuaLoaiPhong.xaml
    /// </summary>
    public partial class ThemLoaiPhong : Window
    {
        LoaiPhong loaiphong = new LoaiPhong();
        public QuanLyLoaiPhong QuanLyLoaiPhongScreen { get; set; }

        public ThemLoaiPhong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            loaiphong.IDLoai = txtMaLoaiPhong.Text;
            loaiphong.Ten = txtTenLoaiPhong.Text;
            loaiphong.Gia = int.TryParse(txtGia.Text, out int gia) ? gia : 0;
            loaiphong.SoNguoi = int.TryParse(txtSoNguoi.Text, out int soNguoi) ? soNguoi : 0;

            LoaiPhongBLL loaiphongBLL = new LoaiPhongBLL();
            string res = loaiphongBLL.CheckLogicThemLoaiPhong(loaiphong);
            switch (res)
            {
                case "ID_Exist":
                    MessageBox.Show("IDLoaiPhong đã tồn tại");
                    return;
                case "Required_attriute":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
            }

            loaiphongBLL.ThemLoaiPhong(loaiphong);
            QuanLyLoaiPhongScreen.LoadRoomTypes();
            MessageBox.Show("Thêm loại phòng thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
