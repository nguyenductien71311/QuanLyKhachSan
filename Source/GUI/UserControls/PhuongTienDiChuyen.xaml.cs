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
    /// Interaction logic for PhuongTienDiChuyen.xaml
    /// </summary>
    public partial class PhuongTienDiChuyen : UserControl
    {
        public string Data;



        PhuongTien pt = new PhuongTien();
        PhuongTienBLL ptBLL = new PhuongTienBLL();

        public PhuongTienDiChuyen()
        {
            InitializeComponent();

            LoadTable();

        }


        public void LoadTable()
        {
            DataTable dataTable = PhuongTienBLL.getListPhuongTien();
            dgPhuongTien.ItemsSource = dataTable.DefaultView;


        }
        private void lsvPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void dgPhuongTien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void PhuongTien_KeyDown(object sender, KeyEventArgs e)
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

            DataTable dataTable = PhuongTienBLL.getListPhuongTien();
            dgPhuongTien.ItemsSource = dataTable.DefaultView;
            dataTable.Clear();

            string Gio = txtFilter.Text;
            if (txtFilter.Text == "")
            {
                MessageBox.Show("Giờ bạn chọn hiện không có");
                dataTable = PhuongTienBLL.getListPhuongTien();
                dgPhuongTien.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                pt.GioDen = Int32.Parse(Gio);
                dataTable = PhuongTienBLL.getListGioPhuongTien(pt);
                dgPhuongTien.ItemsSource = dataTable.DefaultView;
            }



        }

        private void dete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnTimPhuongTien_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = PhuongTienBLL.getListPhuongTien();
            dgPhuongTien.ItemsSource = dataTable.DefaultView;
            dataTable.Clear();

            string Gio = txtFilter.Text;
            if (txtFilter.Text == "")
            {
                MessageBox.Show("Giờ bạn chọn hiện không có");
                dataTable = PhuongTienBLL.getListPhuongTien();
                dgPhuongTien.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                pt.GioDen = Int32.Parse(Gio);
                dataTable = PhuongTienBLL.getListGioPhuongTien(pt);
                dgPhuongTien.ItemsSource = dataTable.DefaultView;
            }

        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            pt.IDNhaXe = "";
            string idNhaXe = (string)((Button)sender).CommandParameter;
            //MessageBox.Show(idNhaXe);
            pt.IDNhaXe = idNhaXe;
            PhuongTienBLL.delPhuongTien(pt);
            DataTable dataTable = PhuongTienBLL.getListPhuongTien();
            dgPhuongTien.ItemsSource = dataTable.DefaultView;
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string id = (string)((Button)sender).CommandParameter;
            var edit = new Sua_PhuongTien(id);
            edit.dataValue = id;
            edit.Closed += Edit_Closed;
            edit.Show();


        }

        private void Edit_Closed(object sender, EventArgs e)
        {
            // Xử lý sự kiện đóng của cửa sổ con ở đây
            // ...
            DataTable dataTable = PhuongTienBLL.getListPhuongTien();
            dgPhuongTien.ItemsSource = dataTable.DefaultView;
        }

        private void btnThemPhuongTien_Click(object sender, RoutedEventArgs e)
        {

            var edit = new Them_PhuongTien();
            edit.Closed += Edit_Closed;
            edit.Show();
        }
    }
}
