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
    /// Interaction logic for QuanLyHoaDon.xaml
    /// </summary>
    public partial class QuanLyHoaDon : UserControl
    {
        private HoaDonBLL HoaDonBLL;
        private ObservableCollection<HoaDon> DSHoaDon;
        private ObservableCollection<HoaDon> filteredHD;

        public QuanLyHoaDon()
        {
            HoaDonBLL = new HoaDonBLL();
            DSHoaDon = new ObservableCollection<HoaDon>();
            InitializeComponent();
            LoadDataHD();
        }

        public void LoadDataHD()
        {
            DSHoaDon.Clear();

            ObservableCollection<HoaDon> DSHDfromBLL = HoaDonBLL.LoadHDData();
            foreach (var HD in DSHDfromBLL)
            {
                DSHoaDon.Add(HD);
            }
            lsvDSHD.ItemsSource = DSHoaDon;
        }

        private void BtnChiTiet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DSHoaDon.Clear();
                string TenKH = txtFilter.Text;

                filteredHD = HoaDonBLL.TimHoaDon(TenKH);
                foreach (var HD in filteredHD)
                {
                    DSHoaDon.Add(HD);
                }
                lsvDSHD.ItemsSource = DSHoaDon;
                txtFilter.Text = string.Empty;
            }
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
    }
}
