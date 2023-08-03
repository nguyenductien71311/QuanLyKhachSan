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
    /// Interaction logic for Them_TourDuLich.xaml
    /// </summary>
    public partial class Them_TourDuLich : Window
    {


        TourDuLich tdl = new TourDuLich();
        public Them_TourDuLich()
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
            if (txtNCC.Text == "" || txtGia.Text == "" || txtNoiDung.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }

            string ID = TourDuLichBLL.topTourDuLich();
            string part1 = ID.Substring(0, 5);
            string part2 = ID.Substring(5);
            int dem = int.Parse(part2);
            dem = dem + 1;
            string ID_1 = dem.ToString();
            string ID_new = String.Concat(part1, ID_1);
            tdl.NCC = txtNCC.Text;
            
            tdl.Gia = int.TryParse(txtGia.Text, out int gia) ? gia : 0;
            tdl.NoiDung = txtNoiDung.Text;
            tdl.IDTour = ID_new;


            string result = TourDuLichBLL.addTourDuLich(tdl);
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
                MessageBox.Show("Thêm thành công");
            }


            var edit = new QuanLyDichVuTour();
            edit.LoadTable();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
