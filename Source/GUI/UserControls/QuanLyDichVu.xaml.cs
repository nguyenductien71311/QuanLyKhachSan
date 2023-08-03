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
    /// Interaction logic for QuanLyDichVu.xaml
    /// </summary>
    public partial class QuanLyDichVu : UserControl
    {
        DichVu dv = new DichVu();
        DichVuBLL dvBLL = new DichVuBLL();
        public QuanLyDichVu()
        {
            InitializeComponent();
            LoadTable();
        }

        public void LoadTable()
        {
            DataTable dataTable = DichVuBLL.getListDichVu();
            dgDichVu.ItemsSource = dataTable.DefaultView;


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
            DataTable dataTable = DichVuBLL.getListDichVu();
            dgDichVu.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = (string)((Button)sender).CommandParameter;
            var edit = new Sua_DichVu(id);
            edit.Closed += Edit_Closed;
            edit.Show();
        }

        private void btnTimDichVu_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = DichVuBLL.getListDichVu();
            dgDichVu.ItemsSource = dataTable.DefaultView;
            dataTable.Clear();

            string Gio = txtFilter.Text;
            if (txtFilter.Text == "")
            {
                MessageBox.Show("Tên dịch vụ bạn chọn hiện không có");
                dataTable = DichVuBLL.getListDichVu();
                dgDichVu.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                dv.TenDV = txtFilter.Text;

                dataTable = DichVuBLL.getListTenDichVu(dv);
                dgDichVu.ItemsSource = dataTable.DefaultView;
            }
        }

        private void DichVu_KeyDown(object sender, KeyEventArgs e)
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

            DataTable dataTable = DichVuBLL.getListDichVu();
            dgDichVu.ItemsSource = dataTable.DefaultView;
            dataTable.Clear();

            if (txtFilter.Text == "")
            {
                MessageBox.Show("Giờ bạn chọn hiện không có");
                dataTable = DichVuBLL.getListDichVu();
                dgDichVu.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                dv.TenDV = txtFilter.Text;

                dataTable = DichVuBLL.getListTenDichVu(dv);
                dgDichVu.ItemsSource = dataTable.DefaultView;
            }

        }

        private void btnThemDichVu_Click(object sender, RoutedEventArgs e)
        {

            var edit = new Them_DichVu();
            edit.Closed += Edit_Closed;
            edit.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            dv.IDDichVu = "";
            string id = (string)((Button)sender).CommandParameter;
            //MessageBox.Show(idNhaXe);
            dv.IDDichVu = id;
            DichVuBLL.delDichVu(dv);
            DataTable dataTable = DichVuBLL.getListDichVu();
            dgDichVu.ItemsSource = dataTable.DefaultView;
        }
    }
}
