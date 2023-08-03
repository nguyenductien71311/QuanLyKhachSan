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
    /// Interaction logic for QuanLyPhong.xaml
    /// </summary>
    public partial class QuanLyPhong : UserControl
    {
        private PhongBLL PhongBLL;
        private ObservableCollection<Phong> DSPhong;
        private ObservableCollection<Phong> filteredPhong;
        public QuanLyPhong()
        {
            InitializeComponent();
            PhongBLL = new PhongBLL();
            DSPhong = new ObservableCollection<Phong>();
            filteredPhong = new ObservableCollection<Phong>();

            LoadPhong();
        }

        public void LoadPhong()
        {
            DSPhong.Clear();

            // Lấy danh sách loại phòng từ BLL
            ObservableCollection<Phong> PhongFromBLL = PhongBLL.LoadDataPhong();

            // Sao chép các phần tử vào roomTypes
            foreach (var Phong in PhongFromBLL)
            {
                DSPhong.Add(Phong);
            }

            // Gán danh sách loại phòng cho ItemsSource của ListView
            lsvPhong.ItemsSource = DSPhong;
        }
        private void btnThemPhong_Click(object sender, RoutedEventArgs e)
        {
            ThemPhong themPhong = new ThemPhong();
            themPhong.QuanLyPhongScreen = this;
            themPhong.Show();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            DSPhong.Clear();
            string keyword = txtFilter.Text;
            filteredPhong = PhongBLL.TimPhong(keyword);
            foreach (var roomType in filteredPhong)
            {
                DSPhong.Add(roomType);
            }
            lsvPhong.ItemsSource = DSPhong;
        }

        private void Phong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DSPhong.Clear();
                string keyword = txtFilter.Text;

                filteredPhong = PhongBLL.TimPhong(keyword);
                foreach (var roomType in filteredPhong)
                {
                    DSPhong.Add(roomType);
                }
                lsvPhong.ItemsSource = DSPhong;

                // Xóa nội dung trong TextBox sau khi tác động đã được thực hiện
                txtFilter.Text = string.Empty;
            }
        }

        private void btnXoaPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btnXoaPhong = (Button)sender;
            string idPhong = btnXoaPhong.Tag.ToString();

            PhongBLL.XoaPhong(idPhong);
            DSPhong.Clear();
            ObservableCollection<Phong> PhongfromBLL = PhongBLL.LoadDataPhong();

            foreach (var roomType in PhongfromBLL)
            {
                DSPhong.Add(roomType);
            }
            lsvPhong.ItemsSource = DSPhong;
        }

        private void btnSuaPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedPhong = listViewItem.DataContext as Phong;

            if (selectedPhong != null)
            {
                SuaPhong suaPhong = new SuaPhong(selectedPhong);
                suaPhong.QuanLyPhongScreen = this;
                suaPhong.ShowDialog();
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
