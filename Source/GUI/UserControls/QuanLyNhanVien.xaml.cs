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
using System.Collections.ObjectModel;
using GUI.View;
using DTO;
using BLL;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for QuanLyNhanVien.xaml
    /// </summary>
    public partial class QuanLyNhanVien : UserControl
    {
        private NhanVienBLL NhanVienBLL;
        private ObservableCollection<NhanVien> DSNhanVien;
        private ObservableCollection<NhanVien> filteredNhanVien;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            NhanVienBLL = new NhanVienBLL();
            DSNhanVien = new ObservableCollection<NhanVien>();
            filteredNhanVien = new ObservableCollection<NhanVien>();
            LoadNhanVien();
            
        }
        public void LoadNhanVien()
        {
            DSNhanVien.Clear();

            ObservableCollection<NhanVien> NhanVienFromBLL = NhanVienBLL.LoadNhanVienData();

            foreach (var NV in NhanVienFromBLL)
            {
                DSNhanVien.Add(NV);
            }
            lsvNhanVien.ItemsSource = DSNhanVien;
        }
        private void btnThemNhanVien_Click(object sender, RoutedEventArgs e)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            themNhanVien.QuanLyNhanVienScreen = this;
            themNhanVien.Show();
        }

        private void NhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DSNhanVien.Clear();
                string keyword = txtFilter.Text;

                filteredNhanVien = NhanVienBLL.TimNhanVien(keyword);
                foreach (var NV in filteredNhanVien)
                {
                    DSNhanVien.Add(NV);
                }
                lsvNhanVien.ItemsSource = DSNhanVien;

                // Xóa nội dung trong TextBox sau khi tác động đã được thực hiện
                txtFilter.Text = string.Empty;
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            DSNhanVien.Clear();
            string keyword = txtFilter.Text;
            filteredNhanVien = NhanVienBLL.TimNhanVien(keyword);
            foreach (var NV in filteredNhanVien)
            {
                DSNhanVien.Add(NV);
            }
            lsvNhanVien.ItemsSource = DSNhanVien;
        }

        private void btnXoaNhanVien_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btnXoaNhanVien = (Button)sender;
            string idNhanVien = btnXoaNhanVien.Tag.ToString();

            NhanVienBLL.XoaNhanVien(idNhanVien);
            DSNhanVien.Clear();
            ObservableCollection<NhanVien> NhanVienFromBLL = NhanVienBLL.LoadNhanVienData();

            foreach (var NV in NhanVienFromBLL)
            {
                DSNhanVien.Add(NV);
            }
            lsvNhanVien.ItemsSource = DSNhanVien;
        }

        private void btnSuaNhanVien_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedNhanVien = listViewItem.DataContext as NhanVien;

            if (selectedNhanVien != null)
            {
                SuaNhanVien suaNhanVien = new SuaNhanVien(selectedNhanVien);
                suaNhanVien.QuanLyNhanVienScreen = this;
                suaNhanVien.ShowDialog();
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

        private void Tat_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            // Kiểm tra nếu đối tượng Window tồn tại
            if (parentWindow != null)
            {
                // Đóng màn hình
                parentWindow.Close();
            }
        }
    }
}
