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
    /// Interaction logic for Them_DichVu.xaml
    /// </summary>
    public partial class Them_DichVu : Window
    {
        DichVu dv = new DichVu();
        public Them_DichVu()
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
            if (txtTenDV.Text == "" || txtGia.Text == "" || txtSL.Text == "" || txtKM.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            string ID = DichVuBLL.topDichVu();
            string part1 = ID.Substring(0, 3);
            string part2 = ID.Substring(3);
            int dem = int.Parse(part2);
            dem = dem + 1;
            string ID_1 = dem.ToString();
            string ID_new = String.Concat(part1, ID_1);
            dv.TenDV = txtTenDV.Text;
            dv.Gia = int.TryParse(txtGia.Text, out int gia) ? gia : 0;
            dv.SL = int.TryParse(txtSL.Text, out int sl) ? sl : 0;
            dv.KM = float.TryParse(txtKM.Text, out float KM) ? KM : 0;
            //dv.Gia = int.Parse(txtGia.Text);
            //dv.SL = int.Parse(txtSL.Text);
            //dv.KM = float.Parse(txtKM.Text);
            dv.TinhTrang = txtTinhTrang.Text;
            dv.TenDV = txtTenDV.Text;
            dv.IDDichVu = ID_new;


            string result = DichVuBLL.addDichVu(dv);
            if (result == "Sai giá")
            {
                MessageBox.Show("Giá không được nhỏ hơn 10,000 VND");
                return;
            }

            if (result == "Sai số lượng")
            {
                MessageBox.Show("Số lượng nhập không được nhỏ hơn 100");
                return;
            }

            if (result == "Sai khuyến mãi")
            {
                MessageBox.Show("Phần trăm khuyến mãi từ 0 đến 50");
                return;
            }

            if (txtGia.Text == "" || txtSL.Text == "" || txtKM.Text == "")
            {
                MessageBox.Show("Bạn không thể để trống bất kỳ dòng nào");
                return;
            }

            if (result == "Trống")
            {
                MessageBox.Show("Bạn không thể để trống bất kỳ dòng nào");
                return;
            }

            if (result == "Thành công")
            {
                MessageBox.Show("Thêm thành công");
            }


            var edit = new QuanLyDichVu();
            edit.LoadTable();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}

