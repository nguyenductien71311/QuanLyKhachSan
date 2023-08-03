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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ThanhToan.xaml
    /// </summary>
    public partial class ThanhToan : Window
    {
        ThongTinDatPhong ttdp = new ThongTinDatPhong();

        public QuanLyDatPhong QuanLyDatPhongScreen { get; set; }

        public ThanhToan(ThongTinDatPhong selectedThongTinDatPhong)
        {
            InitializeComponent();

            ttdp = selectedThongTinDatPhong;
        }

        private void btnTienCoc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HoaDonTienCoc hoaDonTienCoc = new HoaDonTienCoc(ttdp);
            hoaDonTienCoc.ThanhToanScreen = this;
            hoaDonTienCoc.ShowDialog();
        }

        private void btnToanBo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HoaDonToanBo hoaDonToanBo = new HoaDonToanBo(ttdp);
            hoaDonToanBo.ThanhToanScreen = this;
            hoaDonToanBo.ShowDialog();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
