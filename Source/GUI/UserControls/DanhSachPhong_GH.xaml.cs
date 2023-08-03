using BLL;
using DTO;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for DanhSachPhong_GH.xaml
    /// </summary>
    public partial class DanhSachPhong_GH : UserControl
    {
        private PhongBLL phongBLL;
        private ObservableCollection<Phong> DSPhong;
        private ObservableCollection<Phong> DSPhongFilter;

        public DanhSachPhong_GH()
        {
            InitializeComponent();

            phongBLL = new PhongBLL();
            DSPhong = new ObservableCollection<Phong>();

            LoadDanhSachPhong();
        }

        public void LoadDanhSachPhong()
        {
            DSPhong.Clear();

            ObservableCollection<Phong> DSPhongFromBLL = phongBLL.LoadDataPhong();

            foreach (var p in DSPhongFromBLL)
            {
                DSPhong.Add(p);
            }

            lvPhong.ItemsSource = DSPhong;
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedPhong = listViewItem.DataContext as Phong;

            //if (selectedPhong != null)
            //{
            //    SuaPhong suaPhong = new SuaPhong(selectedPhong);
            //    suaPhong.QuanLyPhongScreen = this;
            //    suaPhong.ShowDialog();
            //}

            // Kiểm tra xem có phòng được chọn không
            if (selectedPhong != null)
            {
                // Tạo một instance của màn hình ChiTietPhong và truyền thông tin phòng
                ChiTietPhong chiTietPhongWindow = new ChiTietPhong(selectedPhong);
                chiTietPhongWindow.DanhSachPhongScreen = this;
                // Hiển thị màn hình ChiTietPhong
                chiTietPhongWindow.Show();
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

        private void btnLoc_Click(object sender, RoutedEventArgs e)
        {
            DSPhong.Clear();

            string trangthai = cbbTrangThai.Text;
            string loai = cbbLoai.Text;
            string tinhtrang = cbbTinhTrang.Text;

            DSPhongFilter = phongBLL.LoadDataPhongFilter(trangthai, loai, tinhtrang);

            foreach (var p in DSPhongFilter)
            {
                DSPhong.Add(p);
            }

            lvPhong.ItemsSource = DSPhong;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
