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
    /// Interaction logic for Them_SuaLoaiPhong.xaml
    /// </summary>
    public partial class SuaLoaiPhong : Window
    {
        private LoaiPhong loaiphong = new LoaiPhong();
        //public bool DaCapNhat { get; private set; }
        public QuanLyLoaiPhong QuanLyLoaiPhongScreen { get; set; }
        public SuaLoaiPhong(LoaiPhong selectedLoaiPhong)
        {
            InitializeComponent();
            loaiphong = selectedLoaiPhong;
            txtTenLoaiPhong.Text = loaiphong.Ten;
            txtGia.Text = loaiphong.Gia.ToString();
            txtSoNguoi.Text = loaiphong.SoNguoi.ToString();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            loaiphong.Ten = txtTenLoaiPhong.Text;
            loaiphong.Gia = int.TryParse(txtGia.Text, out int gia) ? gia : 0;
            loaiphong.SoNguoi = int.TryParse(txtSoNguoi.Text, out int soNguoi) ? soNguoi : 0;

            LoaiPhongBLL loaiphongBLL = new LoaiPhongBLL();
            string res = loaiphongBLL.CheckLogicSuaLoaiPhong(loaiphong);
            switch (res)
            {
                case "Invalid":
                    MessageBox.Show("Thông tin không hợp lệ!");
                    return;
            }
            loaiphongBLL.SuaLoaiPhong(loaiphong);
            QuanLyLoaiPhongScreen.LoadRoomTypes();
            MessageBox.Show("Sửa loại phòng thành công!");
            this.Close();

        }
    }
}
