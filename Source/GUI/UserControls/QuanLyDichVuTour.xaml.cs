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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BLL;
using System.Net;
using System.Data;
using GUI.View;


namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for QuanLyDichVuTour.xaml
    /// </summary>
    public partial class QuanLyDichVuTour : UserControl
    {
        TourDuLich tdl = new TourDuLich();
        TourDuLichBLL tdlBLL = new TourDuLichBLL();
        public QuanLyDichVuTour()
        {
            InitializeComponent();
            LoadTable();
        }

        public void LoadTable()
        {
            DataTable dataTable = TourDuLichBLL.getListTourDuLich();
            dgTourDuLich.ItemsSource = dataTable.DefaultView;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
        private void Edit_Closed(object sender, EventArgs e)
        {
            // Xử lý sự kiện đóng của cửa sổ con ở đây
            // ...
            DataTable dataTable = TourDuLichBLL.getListTourDuLich();
            dgTourDuLich.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = (string)((Button)sender).CommandParameter;
            var edit = new Sua_TourDuLich(id);
            edit.Closed += Edit_Closed;
            edit.Show();
        }

        private void btnTimTourDuLich_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = TourDuLichBLL.getListTourDuLich();
            dgTourDuLich.ItemsSource = dataTable.DefaultView;
            dataTable.Clear();

            string Gio = txtFilter.Text;
            if (txtFilter.Text == "")
            {
                MessageBox.Show("Nội dung bạn chọn hiện không có");
                dataTable = TourDuLichBLL.getListTourDuLich();
                dgTourDuLich.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                tdl.NoiDung = txtFilter.Text;

                dataTable = TourDuLichBLL.getListTenTourDuLich(tdl);
                dgTourDuLich.ItemsSource = dataTable.DefaultView;
            }
        }

        private void TourDuLich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Thực hiện hành động tìm kiếm ở đây
                // Ví dụ: 
                timKiem(sender, e);
            }
        }

        private void timKiem(object sender, RoutedEventArgs e)
        {

            DataTable dataTable = TourDuLichBLL.getListTourDuLich();
            dgTourDuLich.ItemsSource = dataTable.DefaultView;
            dataTable.Clear();

            if (txtFilter.Text == "")
            {
                MessageBox.Show("Giờ bạn chọn hiện không có");
                dataTable = TourDuLichBLL.getListTourDuLich();
                dgTourDuLich.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                tdl.NoiDung = txtFilter.Text;

                dataTable = TourDuLichBLL.getListTenTourDuLich(tdl);
                dgTourDuLich.ItemsSource = dataTable.DefaultView;
            }

        }

        private void btnThemTourDuLich_Click(object sender, RoutedEventArgs e)
        {

            var edit = new Them_TourDuLich();
            edit.Closed += Edit_Closed;
            edit.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            tdl.IDTour = "";
            string id = (string)((Button)sender).CommandParameter;
            //MessageBox.Show(idNhaXe);
            tdl.IDTour = id;
            TourDuLichBLL.delTourDuLich(tdl);
            DataTable dataTable = TourDuLichBLL.getListTourDuLich();
            dgTourDuLich.ItemsSource = dataTable.DefaultView;
        }

        private void btnTimTourDuLich_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
