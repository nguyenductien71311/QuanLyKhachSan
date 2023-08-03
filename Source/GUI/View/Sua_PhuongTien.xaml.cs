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
    /// Interaction logic for Sua_PhuongTien.xaml
    /// </summary>

    public partial class Sua_PhuongTien : Window
    {

        public string dataValue;
        public string temp123;

        PhuongTien pt = new PhuongTien();

        public Sua_PhuongTien(string temp)
        {

            InitializeComponent();
            pt.IDNhaXe = temp;
            DataTable dataTable = PhuongTienBLL.getID(pt);
            string tenNhaXe = "";
            string sdt = "";
            string gia = "";
            string gioDen = "";
            //dgPhuongTien.ItemsSource = dataTable.DefaultView;
            foreach (DataRow row in dataTable.Rows)
            {
                tenNhaXe = row["TenNhaXe"].ToString();

                sdt = row["SDT"].ToString();

                gia = row["Gia"].ToString();

                gioDen = row["GioDen"].ToString();


                // Sử dụng dữ liệu



            }
            txtTenNhaXe.Text = tenNhaXe;
            txtSDT.Text = sdt;
            txtGia.Text = gia;
            txtGioDen.Text = gioDen;
            //loadData(temp);


            this.temp123 = temp;


        }



        private void loadData(string temp)
        {

            pt.IDNhaXe = temp;
            DataTable dataTable = PhuongTienBLL.getID(pt);
            //dgPhuongTien.ItemsSource = dataTable.DefaultView;
            foreach (DataRow row in dataTable.Rows)
            {
                string tenNhaXe = row["TenNhaXe"].ToString();

                string sdt = row["SDT"].ToString();

                string gia = row["Gia"].ToString();

                string gioDen = row["GioDen"].ToString();


                // Sử dụng dữ liệu
                //MessageBox.Show($"Tên nhà xe: {tenNhaXe}\nSĐT: {sdt}\nGiá: {gia}\nGiờ đến: {gioDen}");


            }



        }



        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();

        }

        private void dgPhuongTien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (txtTenNhaXe.Text == "" || txtSDT.Text == "" || txtGia.Text == "" || txtGioDen.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            pt.TenNhaXe = txtTenNhaXe.Text;
            pt.SDT = txtSDT.Text;
            pt.Gia = int.Parse(txtGia.Text);
            pt.GioDen = int.Parse(txtGioDen.Text);
            string result = PhuongTienBLL.editPhuongTien(pt);
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
                MessageBox.Show("Giờ có thể từ 1h đến 23h");
                return;
            }

            if (result == "Thành công")
            {
                MessageBox.Show("Sửa thành công");
            }

            var edit = new PhuongTienDiChuyen();
            edit.LoadTable();

            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();

        }
    }
}
