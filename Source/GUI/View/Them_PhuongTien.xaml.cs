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
using System.Data;
using GUI.UserControls;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Them_PhuongTien.xaml
    /// </summary>
    public partial class Them_PhuongTien : Window
    {
        PhuongTien pt = new PhuongTien();
        public Them_PhuongTien()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {

            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();


        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

            if (txtTenNhaXe.Text == "" || txtSDT.Text == "" || txtGia.Text == "" || txtGioDen.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            string ID = PhuongTienBLL.topPhuongTien();
            string part1 = ID.Substring(0, 3);
            string part2 = ID.Substring(3);
            int dem = int.Parse(part2);
            dem = dem + 1;
            string ID_1 = dem.ToString();
            string ID_new = String.Concat(part1, ID_1);

            pt.TenNhaXe = txtTenNhaXe.Text;
            pt.SDT = txtSDT.Text;
            pt.Gia = int.TryParse(txtGia.Text, out int gia) ? gia : 0;
            pt.GioDen = int.TryParse(txtGioDen.Text, out int gio) ? gio : -1;
            //pt.Gia = int.Parse(txtGia.Text);
            //pt.GioDen = int.Parse(txtGioDen.Text);
            pt.IDNhaXe = ID_new;


            string result = PhuongTienBLL.addPhuongTien(pt);
            if (result == "Sai SDT")
            {
                MessageBox.Show("Số điện thoại gồm 10 chữ số");
                return;
            }

            if (result == "Sai giá")
            {
                MessageBox.Show("Giá bán không được nhỏ hơn 100.000 VND");
                return;
            }

            if (result == "Sai giờ")
            {
                MessageBox.Show("Giờ có thể thêm từ 1h đến 23h");
                return;
            }

            if (result == "Thành công")
            {
                MessageBox.Show("Thêm thành công");
            }


            var edit = new PhuongTienDiChuyen();
            edit.LoadTable();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
