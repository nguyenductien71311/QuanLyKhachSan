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
    /// Interaction logic for Sua_TourDuLich.xaml
    /// </summary>
    public partial class Sua_TourDuLich : Window
    {


        public string dataValue;
        public string temp123;

        TourDuLich tdl = new TourDuLich();
        public Sua_TourDuLich(string temp)
        {
            InitializeComponent();
            tdl.IDTour = temp;
            DataTable dataTable = TourDuLichBLL.getIDTourDuLich(tdl);
            string ncc = "";
            string noidung = "";
            string gia = "";

            //dgPhuongTien.ItemsSource = dataTable.DefaultView;
            foreach (DataRow row in dataTable.Rows)
            {
                ncc = row["NCC"].ToString();

                noidung = row["NoiDung"].ToString();

                gia = row["Gia"].ToString();



            }
            txtNCC.Text = ncc;
            txtNoiDung.Text = noidung;
            txtGia.Text = gia;

            //loadData(temp);


            this.temp123 = temp;


        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {

            if (txtNCC.Text == "" || txtGia.Text == "" || txtNoiDung.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }

            tdl.NCC = txtNCC.Text;
            tdl.Gia = int.Parse(txtGia.Text);
            tdl.NoiDung = txtNoiDung.Text;

            string result = TourDuLichBLL.editTourDuLich(tdl);
            if (txtGia.Text == "")
            {
                MessageBox.Show("Bạn không thể để trống bất kỳ dòng nào");
                return;
            }
            if (result == "Trống")
            {
                MessageBox.Show("Bạn không thể để trống bất kỳ dòng nào");
                return;
            }

            if (result == "Giá tiền")
            {
                MessageBox.Show("Giá không thể nhỏ hơn hoặc bằng 100,000 VND");
                return;
            }




            if (result == "Thành công")
            {
                MessageBox.Show("Sửa thành công");
            }

            var edit = new QuanLyDichVuTour();


            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
