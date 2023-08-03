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
using GUI.View;
using System.Collections.ObjectModel;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for QuanLyKhachHang.xaml
    /// </summary>
    public partial class QuanLyKhachHang : UserControl
    {
        private KhachHangBLL KhachHangBLL;
        private ObservableCollection<KhachHang> DSKhachHang;
        private ObservableCollection<KhachHang> filteredKH;
        public QuanLyKhachHang()
        {
            InitializeComponent();

            KhachHangBLL = new KhachHangBLL();
            DSKhachHang = new ObservableCollection<KhachHang>();
            filteredKH = new ObservableCollection<KhachHang>();
            LoadDataKH();
        }
        public void LoadDataKH()
        {
            DSKhachHang.Clear();

            ObservableCollection<KhachHang> DSKHfromBLL = KhachHangBLL.LoadKHData();
            foreach (var KH in DSKHfromBLL)
            {
                DSKhachHang.Add(KH);
            }
            lsvdsKhachHang.ItemsSource = DSKhachHang;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            // Kiểm tra nếu đối tượng Window tồn tại
            if (parentWindow != null)
            {
                // Đóng màn hình
                parentWindow.Close();
            }
        }

        private void BtnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedKhachHang = listViewItem.DataContext as KhachHang;

            if (selectedKhachHang != null)
            {
                LichSuDatPhong lsdp = new LichSuDatPhong(selectedKhachHang);
                lsdp.ShowDialog();
            }
        }

        private T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            if (parentObject is T parent)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedKhachHang = listViewItem.DataContext as KhachHang;

            if (selectedKhachHang != null)
            {
                SuaThongTinKhachHang suaTTKH = new SuaThongTinKhachHang(selectedKhachHang);
                suaTTKH.QLKHScreen = this;
                suaTTKH.ShowDialog();
            }
        }

        private void TimKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DSKhachHang.Clear();
                string CCCD = txtFilter.Text;

                filteredKH = KhachHangBLL.TimKhachHang(CCCD);
                foreach (var KH in filteredKH)
                {
                    DSKhachHang.Add(KH);
                }
                lsvdsKhachHang.ItemsSource = DSKhachHang;
                txtFilter.Text = string.Empty;
            }
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            DSKhachHang.Clear();
            string CCCD = txtFilter.Text;

            filteredKH = KhachHangBLL.TimKhachHang(CCCD);
            foreach (var KH in filteredKH)
            {
                DSKhachHang.Add(KH);
            }
            lsvdsKhachHang.ItemsSource = DSKhachHang;
            txtFilter.Text = string.Empty;
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedKhachHang = listViewItem.DataContext as KhachHang;

            if (selectedKhachHang != null)
            {
                KhachHangBLL.XoaKH(selectedKhachHang);
                MessageBox.Show("Xoá khách hàng thành công!");
                LoadDataKH();
            }
        }
    }
}
