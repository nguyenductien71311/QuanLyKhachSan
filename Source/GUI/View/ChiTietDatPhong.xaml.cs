using BLL;
using DTO;
using GUI.UserControls;
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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ChiTietDatPhong.xaml
    /// </summary>
    public partial class ChiTietDatPhong : Window
    {
        private ChiTietThongTinDatPhongBLL ctttdpBLL = new ChiTietThongTinDatPhongBLL();
        private ObservableCollection<ChiTietThongTinDatPhong> DSctttDP = new ObservableCollection<ChiTietThongTinDatPhong>();
        private ThongTinDatPhong ttdp;
        private DoanBLL doanBLL = new DoanBLL();

        public QuanLyDatPhong QuanLyDatPhongScreen { get; set; }

        public ChiTietDatPhong(ThongTinDatPhong selectedThongTinDatPhong)
        {
            InitializeComponent();

            ttdp = selectedThongTinDatPhong;
            
            txtTenKH.Text = ttdp.TenKH;
            txtNgayDat.Text = ttdp.NgayDat.ToString();

            LoadChiTietThongTinDatPhong();

            Doan doanFromBLL = doanBLL.LoadDoanData(ttdp.IDKhachHang);

            txtTenDoan.Text = doanFromBLL.TenDoan;
            txtSoNguoi.Text = doanFromBLL.SoNguoi.ToString();  
        }

        public void LoadChiTietThongTinDatPhong()
        {
            //DSctttDP.Clear();

            ObservableCollection<ChiTietThongTinDatPhong> ctttDPFromBLL = ctttdpBLL.LoadCTTTDPData(ttdp);

            foreach (var ctttDP in ctttDPFromBLL)
            {
                DSctttDP.Add(ctttDP);
            }
            lsvChiTietThongTinDatPhong.ItemsSource = DSctttDP;

        }

        //public Doan LoadThongTinDoan()
        //{
            

        //    return doanFromBLL;
        //}

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
