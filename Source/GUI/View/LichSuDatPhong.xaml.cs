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
using System.Windows.Shapes;
using DTO;
using BLL;
using GUI.UserControls;
using System.Collections.ObjectModel;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for LichSuDatPhong.xaml
    /// </summary>
    public partial class LichSuDatPhong : Window
    {
        private KhachHangBLL KhachHangBLL;
        private ObservableCollection<ChiTietThongTinDatPhong> LSDP;
        public QuanLyKhachHang qlkhScreen { get; set; }
        public LichSuDatPhong(KhachHang selectedKhachHang)
        {
            InitializeComponent();
            KhachHangBLL = new KhachHangBLL();
            LSDP = new ObservableCollection<ChiTietThongTinDatPhong>();
            LoadLSDP(selectedKhachHang);
        }

        public void LoadLSDP(KhachHang selectedKhachHang)
        {
            ObservableCollection<ChiTietThongTinDatPhong> LSDPfromBLL = KhachHangBLL.LoadLSDPData(selectedKhachHang);
            foreach (var LS in LSDPfromBLL)
            {
                LSDP.Add(LS);
            }
            lsdp.ItemsSource = LSDP;
        }    

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
