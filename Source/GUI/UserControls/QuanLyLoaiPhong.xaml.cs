using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using DTO;
using BLL;
using GUI.View;
using System.Net;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for QuanLyLoaiPhong.xaml
    /// </summary>
    public partial class QuanLyLoaiPhong : UserControl
    {
        private LoaiPhongBLL roomTypeBLL;
        private ObservableCollection<LoaiPhong> roomTypes;
        private ObservableCollection<LoaiPhong> filteredLoaiPhong;

        public QuanLyLoaiPhong()
        {
            InitializeComponent();

            roomTypeBLL = new LoaiPhongBLL();
            roomTypes = new ObservableCollection<LoaiPhong>();
            filteredLoaiPhong = new ObservableCollection<LoaiPhong>();
            LoadRoomTypes();
        }

        public void LoadRoomTypes()
        {
            roomTypes.Clear();

            ObservableCollection<LoaiPhong> roomTypesFromBLL = roomTypeBLL.LoadLoaiPhongData();

            foreach (var roomType in roomTypesFromBLL)
            {
                roomTypes.Add(roomType);
            }
            lsvLoaiPhong.ItemsSource = roomTypes;
        }

        private void btnThemLoaiPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ThemLoaiPhong themLoaiPhong = new ThemLoaiPhong();
            themLoaiPhong.QuanLyLoaiPhongScreen = this;
            themLoaiPhong.ShowDialog();
        }

        private void btnFilter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            roomTypes.Clear();
            string keyword = txtFilter.Text;
            filteredLoaiPhong = roomTypeBLL.TimLoaiPhong(keyword);
            foreach (var roomType in filteredLoaiPhong)
            {
                roomTypes.Add(roomType);
            }
            lsvLoaiPhong.ItemsSource = roomTypes;
        }

        private void LoaiPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                roomTypes.Clear();
                string keyword = txtFilter.Text;

                filteredLoaiPhong = roomTypeBLL.TimLoaiPhong(keyword);
                foreach (var roomType in filteredLoaiPhong)
                {
                    roomTypes.Add(roomType);
                }
                lsvLoaiPhong.ItemsSource = roomTypes;
                txtFilter.Text = string.Empty;
            }
        }


        private void btnXoaLoaiPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btnXoaLoaiPhong = (Button)sender;
            string idLoai = btnXoaLoaiPhong.Tag.ToString();

            roomTypeBLL.XoaLoaiPhong(idLoai);
            roomTypes.Clear();
            ObservableCollection<LoaiPhong> roomTypesFromBLL = roomTypeBLL.LoadLoaiPhongData();

            foreach (var roomType in roomTypesFromBLL)
            {
                roomTypes.Add(roomType);
            }
            lsvLoaiPhong.ItemsSource = roomTypes;
        }

        private void btnSuaLoaiPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedLoaiPhong = listViewItem.DataContext as LoaiPhong;

            if (selectedLoaiPhong != null)
            {
                SuaLoaiPhong suaLoaiPhong = new SuaLoaiPhong(selectedLoaiPhong);
                suaLoaiPhong.QuanLyLoaiPhongScreen = this;
                suaLoaiPhong.ShowDialog();
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
