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
    /// Interaction logic for SuaDatPhong.xaml
    /// </summary>
    public partial class SuaDatPhong : Window
    {
        ThongTinDatPhong TTDP = new ThongTinDatPhong();
        ObservableCollection<ChiTietThongTinDatPhong> CTTTDP = new ObservableCollection<ChiTietThongTinDatPhong>();
        Doan doan = new Doan();
        KhachHang khachhang = new KhachHang();
        PhongBLL phongBLL = new PhongBLL();

        ObservableCollection<Phong> PhongTrong = new ObservableCollection<Phong>();

        List<Phong> PhongCatches = new List<Phong>();

        public QuanLyDatPhong QuanLyDatPhongScreen { get; set; }

        public SuaDatPhong(ThongTinDatPhong selectedTTDP)
        {
            InitializeComponent();

            TTDP = selectedTTDP;

            ChiTietThongTinDatPhongBLL ctBLL = new ChiTietThongTinDatPhongBLL();
            KhachHangBLL khBLL = new KhachHangBLL();
            DoanBLL doanBLL = new DoanBLL();

            CTTTDP = ctBLL.LoadCTTTDPData(selectedTTDP);

            dtpNgayCheckIn.SelectedDate = CTTTDP.First().NgayCheckIn;
            dtpNgayCheckOut.SelectedDate = CTTTDP.First().NgayCheckOut;

            khachhang = khBLL.TimKhachHangCoIDKhachHang(selectedTTDP.IDKhachHang);
            doan = doanBLL.LoadDoanData(selectedTTDP.IDKhachHang);

            txtHoTen.Text = khachhang.TenKH;
            txtCCCD.Text = khachhang.CCCD;
            txtDiaChi.Text = khachhang.DiaChi;
            txtSDT.Text = khachhang.SDT;
            txtEmail.Text = khachhang.Email;
            txtSofax.Text = khachhang.Fax;

            txtIDdoan.Text = doan.IDDoan;
            txtTenDoan.Text = doan.TenDoan;
            txtSoNguoi.Text = doan.SoNguoi.ToString();

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

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            ////Thông tin khách hàng từ màn hình
            //khachhang.IDKhachHang = txtCCCD.Text; //Lấy CCCD làm id luôn
            //khachhang.TenKH = txtHoTen.Text;
            //khachhang.CCCD = txtCCCD.Text;
            //khachhang.DiaChi = txtDiaChi.Text;
            //khachhang.SDT = txtSDT.Text;
            //khachhang.Email = txtEmail.Text;
            //khachhang.Fax = txtSofax.Text;

            ////Thông tin Đoàn nếu có
            //doan.IDDoan = txtIDdoan.Text;
            //doan.TenDoan = txtTenDoan.Text;
            //doan.NguoiDaiDien = txtHoTen.Text;
            //doan.IDKhachHang = txtCCCD.Text;
            //doan.SoNguoi = int.TryParse(txtSoNguoi.Text, out int songuoi) ? songuoi : 0;

            //Thông tin đạt phòng
            TTDP.NgayDat = DateTime.Now;
            ThongTinDatPhongBLL ttdpBLL = new ThongTinDatPhongBLL();

            ttdpBLL.XoaTTDPData(TTDP.IDKhachHang);

            foreach (var ctttdp in CTTTDP)
            {
                if(TTDP == null)
                {
                    MessageBox.Show("Thông tin đặt phòng null");
                    return;
                }    

                ttdpBLL.ThemDataTTDPvaCTTTDP(TTDP, ctttdp);

                Phong phongdadat = new Phong();
                phongdadat = phongBLL.TimPhongCoIDPhong(ctttdp.IDPhong);
                phongdadat.TrangThai = "Đầy";
                phongBLL.SuaPhong(phongdadat);
            }

            QuanLyDatPhongScreen.LoadThongTinDatPhong();
            MessageBox.Show("Sửa thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

                ChiTietThongTinDatPhong phongdachon = new ChiTietThongTinDatPhong()
                {
                    IDPhong = selectedPhongTrong.IDPhong,
                    TenLoaiPhong = selectedPhongTrong.LoaiPhong,
                    SoLuongNguoi = songuoi,
                    NgayCheckIn = dtpNgayCheckIn.DisplayDate,
                    NgayCheckOut = dtpNgayCheckOut.DisplayDate
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
                foreach (ChiTietThongTinDatPhong p in CTTTDP)
                {
                    if (p.IDPhong.Equals(selectedPhongDaChon.IDPhong))
                    {
                        Phong phongtrong = new Phong();
                        phongtrong = phongBLL.TimPhongCoIDPhong(p.IDPhong);
                        phongtrong.TrangThai = "Trống";
                        phongBLL.SuaPhong(phongtrong);

                        if (phongtrong.LoaiPhong == "DON")
                        {
                            phongtrong.LoaiPhong = "Đơn";
                        }
                        else if (phongtrong.LoaiPhong == "DOI")
                        {
                            phongtrong.LoaiPhong = "Đôi";
                        }
                        else if (phongtrong.LoaiPhong == "GIADINH")
                        {
                            phongtrong.LoaiPhong = "Gia Đình";
                        }
                        else
                        {
                            MessageBox.Show("Lỗi loại phòng");
                            return;
                        }

                        PhongTrong.Add(phongtrong);
                        //CTTTDP.Remove(p);

                        break;
                    }
                }

                foreach (Phong p in PhongCatches)
                {
                    if (p.IDPhong.Equals(selectedPhongDaChon.IDPhong))
                    {
                        Phong phongtrong = new Phong();
                        phongtrong = phongBLL.TimPhongCoIDPhong(p.IDPhong);
                        phongtrong.TrangThai = "Trống";
                        phongBLL.SuaPhong(phongtrong);

                        PhongTrong.Add(p);
                        PhongCatches.Remove(p);

                        break;
                    }
                }
            }
            CTTTDP.Remove(selectedPhongDaChon);
            //LoadDanhSachPhongTrong();
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
