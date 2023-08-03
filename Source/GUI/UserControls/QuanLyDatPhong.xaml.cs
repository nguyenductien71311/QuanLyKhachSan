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
using System.Security.Principal;
using System.Collections.ObjectModel;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for QuanLyDatPhong.xaml
    /// </summary>
    public partial class QuanLyDatPhong : UserControl
    {
        private ThongTinDatPhongBLL TTDatPhongBLL;
        private ObservableCollection<ThongTinDatPhong> DSttDP;
        private ObservableCollection<ThongTinDatPhong> filterDSttDP;
        private ChiTietThongTinDatPhongBLL ctttdpBLL = new ChiTietThongTinDatPhongBLL();

        public QuanLyDatPhong()
        {
            InitializeComponent();

            TTDatPhongBLL = new ThongTinDatPhongBLL();
            DSttDP = new ObservableCollection<ThongTinDatPhong>();
            filterDSttDP = new ObservableCollection<ThongTinDatPhong>();

            LoadThongTinDatPhong();
        }

        public void LoadThongTinDatPhong()
        {
            DSttDP.Clear();

            ObservableCollection<ThongTinDatPhong> ttDPFromBLL = TTDatPhongBLL.LoadTTDPData();
            ObservableCollection<ChiTietThongTinDatPhong> DSphongdadat = new ObservableCollection<ChiTietThongTinDatPhong>();

            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);

            foreach (var ttDP in ttDPFromBLL)
            {
                DSphongdadat = ctttdpBLL.LoadCTTTDPData(ttDP);

                int result = DateTime.Compare(DSphongdadat[0].NgayCheckOut, yesterday);
                
                if (result >= 0)
                {
                    DSttDP.Add(ttDP);
                }
                
            }

            lsvThongTinDatPhong.ItemsSource = DSttDP;

        }

        private void btnDatPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DatPhong datphong = new DatPhong();
            datphong.QuanLyDatPhongScreen = this;
            datphong.ShowDialog();
        }

        public void btnFilter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DSttDP.Clear();
            string keyword = txtFilter.Text;
            filterDSttDP = TTDatPhongBLL.TimThongTinDatPhong(keyword);
            foreach (var ttdp in filterDSttDP)
            {
                DSttDP.Add(ttdp);
            }
            lsvThongTinDatPhong.ItemsSource = DSttDP;
        }

        private void TenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DSttDP.Clear();
                string keyword = txtFilter.Text;
                filterDSttDP = TTDatPhongBLL.TimThongTinDatPhong(keyword);
                foreach (var ttdp in filterDSttDP)
                {
                    DSttDP.Add(ttdp);
                }
                lsvThongTinDatPhong.ItemsSource = DSttDP;
                txtFilter.Text = string.Empty;
            }
        }

        public void btnChiTietDatPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedThongTinDatPhong = listViewItem.DataContext as ThongTinDatPhong;

            if (selectedThongTinDatPhong != null)
            {
                ChiTietDatPhong ctttdp = new ChiTietDatPhong(selectedThongTinDatPhong);
                ctttdp.QuanLyDatPhongScreen = this;
                ctttdp.ShowDialog();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        public void btnXoaDatPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btnXoaDatPhong = (Button)sender;
            string idkh = btnXoaDatPhong.Tag.ToString();

            TTDatPhongBLL.XoaTTDPData(idkh);
            DSttDP.Clear();
            ObservableCollection<ThongTinDatPhong> ttdpFromBLL = TTDatPhongBLL.LoadTTDPData();

            //foreach (var ttdp in ttdpFromBLL)
            //{
            //    DSttDP.Add(ttdp);
            //}
            //lsvThongTinDatPhong.ItemsSource = DSttDP;

            ObservableCollection<ChiTietThongTinDatPhong> DSphongdadat = new ObservableCollection<ChiTietThongTinDatPhong>();
            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);

            foreach (var ttDP in ttdpFromBLL)
            {
                DSphongdadat = ctttdpBLL.LoadCTTTDPData(ttDP);

                int result = DateTime.Compare(DSphongdadat[0].NgayCheckOut, yesterday);

                if (result >= 0)
                {
                    DSttDP.Add(ttDP);
                }
            }

            lsvThongTinDatPhong.ItemsSource = DSttDP;
        }

        public void btnSuaDatPhong_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedThongTinDatPhong = listViewItem.DataContext as ThongTinDatPhong;

            if (selectedThongTinDatPhong != null)
            {
                SuaDatPhong suadatphong = new SuaDatPhong(selectedThongTinDatPhong);
                suadatphong.QuanLyDatPhongScreen = this;
                suadatphong.ShowDialog();
            }
        }

        public void btnThanhToan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedThongTinDatPhong = listViewItem.DataContext as ThongTinDatPhong;

            if (selectedThongTinDatPhong != null)
            {
                ThanhToan thanhtoan = new ThanhToan(selectedThongTinDatPhong);
                thanhtoan.QuanLyDatPhongScreen = this;
                thanhtoan.ShowDialog();
            }
        }
    }
}
