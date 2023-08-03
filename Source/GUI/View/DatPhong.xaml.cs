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
    /// Interaction logic for DatPhong.xaml
    /// </summary>
    public partial class DatPhong : Window
    {
        ThongTinDatPhong TTDP = new ThongTinDatPhong();
        ObservableCollection<ChiTietThongTinDatPhong> CTTTDP = new ObservableCollection<ChiTietThongTinDatPhong>();
        Doan doan = new Doan();
        KhachHang khachhang = new KhachHang();
        PhongBLL phongBLL = new PhongBLL();

        ObservableCollection<Phong> PhongTrong = new ObservableCollection<Phong>();

        List<Phong> PhongCatches = new List<Phong>();

        public QuanLyDatPhong QuanLyDatPhongScreen { get; set; }

        public DatPhong()
        {
            InitializeComponent();

            LoadDanhSachPhongTrong();

            LoadDanhSachPhongDaChon();
        }


        public void LoadDanhSachPhongTrong()
        {
            PhongTrong.Clear();

            ObservableCollection<Phong> phongtrongFromBLL = phongBLL.LoadDataPhongTrong();

            foreach (var phongtrong in phongtrongFromBLL)
            {
                PhongTrong.Add(phongtrong);
            }
            lsvPhongTrong.ItemsSource = PhongTrong;
        }

        public void LoadDanhSachPhongDaChon()
        {
            lsvPhongDaChon.ItemsSource = CTTTDP;
        }

        private void btnDat_Click(object sender, RoutedEventArgs e)
        {
            //Thông tin khách hàng từ màn hình
            khachhang.IDKhachHang = txtCCCD.Text; //Lấy CCCD làm id luôn
            khachhang.TenKH = txtHoTen.Text;
            khachhang.CCCD = txtCCCD.Text;
            khachhang.DiaChi = txtDiaChi.Text;
            khachhang.SDT = txtSDT.Text;
            khachhang.Email = txtEmail.Text;
            khachhang.Fax = txtSofax.Text;

            //Thông tin Đoàn nếu có
            doan.IDDoan = txtIDdoan.Text;
            doan.TenDoan = txtTenDoan.Text;
            doan.NguoiDaiDien = txtHoTen.Text;
            doan.IDKhachHang = txtCCCD.Text;
            doan.SoNguoi = int.TryParse(txtSoNguoi.Text, out int songuoi) ? songuoi : 0;

            //Thông tin đạt phòng
            TTDP.IDKhachHang = txtCCCD.Text;
            TTDP.NgayDat = DateTime.Now;
            TTDP.TenKH = txtHoTen.Text;

            KhachHangBLL khachhangBLL = new KhachHangBLL();
            DoanBLL doanBLL = new DoanBLL();
            ThongTinDatPhongBLL ttdpBLL = new ThongTinDatPhongBLL();

            string res_khachhang = khachhangBLL.CheckLogicThemKhachHang(khachhang);

            string res_doan = doanBLL.CheckLogicThemDoan(doan);

            if (res_khachhang == "Required_attriute")
            {
                MessageBox.Show("Thông tin khách hàng không hợp lệ");
                return;
            }

            if (res_khachhang == "Valid")
            {
                khachhangBLL.ThemKhacHang(khachhang);
            }

            if (res_doan == "ID_Exist")
            {
                MessageBox.Show("ID Doan đã tồn tại");
                return;
            }

            if (res_doan == "Valid")
            {
                doanBLL.ThemDoan(doan);
            }


            foreach (var ctttdp in CTTTDP)
            {
                ttdpBLL.ThemDataTTDPvaCTTTDP(TTDP, ctttdp);

                Phong phongdadat = new Phong();
                phongdadat = phongBLL.TimPhongCoIDPhong(ctttdp.IDPhong);
                phongdadat.TrangThai = "Đầy";
                phongBLL.SuaPhong(phongdadat);
            }

            QuanLyDatPhongScreen.LoadThongTinDatPhong();
            MessageBox.Show("Đặt thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void rdPhongDon_Click(object sender, RoutedEventArgs e)
        {
            string fileter = "Đơn";

            LoadDanhSachPhongTrongFilter(fileter);
        }

        private void rdPhongDoi_Click(object sender, RoutedEventArgs e)
        {
            string fileter = "Đôi";

            LoadDanhSachPhongTrongFilter(fileter);
        }

        private void rdPhongGiaDinh_Click(object sender, RoutedEventArgs e)
        {
            string fileter = "Gia Đình";

            LoadDanhSachPhongTrongFilter(fileter);
        }

        private void rdTatCaLoai_Click(object sender, RoutedEventArgs e)
        {
            LoadDanhSachPhongTrong();
        }

        private void LoadDanhSachPhongTrongFilter(string filter)
        {
            PhongTrong.Clear();

            ObservableCollection<Phong> phongtrongFromBLL = phongBLL.LoadDataPhongTrong();

            foreach (var phongtrong in phongtrongFromBLL)
            {
                if (phongtrong.LoaiPhong == filter)
                {
                    PhongTrong.Add(phongtrong);
                }
            }

            lsvPhongTrong.ItemsSource = PhongTrong;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedPhongTrong = listViewItem.DataContext as Phong;

            if (selectedPhongTrong != null)
            {
                PhongCatches.Add(selectedPhongTrong);
                PhongTrong.Remove(selectedPhongTrong);

                int songuoi = 1;

                if (selectedPhongTrong.LoaiPhong == "Đơn")
                {
                    songuoi = 1;
                }
                else if (selectedPhongTrong.LoaiPhong == "Đôi")
                {
                    songuoi = 2;
                }
                else if (selectedPhongTrong.LoaiPhong == "Gia Đình")
                {
                    songuoi = 4;
                }
                else
                {
                    MessageBox.Show("Lỗi loại phòng");
                    return;
                }

                string ngaycheckin = dtpNgayCheckIn.Text;
                string ngaycheckout = dtpNgayCheckOut.Text;

                ChiTietThongTinDatPhong phongdachon = new ChiTietThongTinDatPhong()
                {
                    IDPhong = selectedPhongTrong.IDPhong,
                    TenLoaiPhong = selectedPhongTrong.LoaiPhong,
                    NgayCheckIn = Convert.ToDateTime(ngaycheckin),
                    NgayCheckOut = Convert.ToDateTime(ngaycheckout),
                    SoLuongNguoi = songuoi
                };

                CTTTDP.Add(phongdachon);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedPhongDaChon = listViewItem.DataContext as ChiTietThongTinDatPhong;

            if (selectedPhongDaChon != null)
            {
                foreach (Phong p in PhongCatches)
                {
                    if (p.IDPhong.Equals(selectedPhongDaChon.IDPhong))
                    {
                        PhongTrong.Add(p);
                        PhongCatches.Remove(p);
                        break;
                    }
                }
            }
            CTTTDP.Remove(selectedPhongDaChon);
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
    }
}
