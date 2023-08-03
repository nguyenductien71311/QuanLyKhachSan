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
using System.Net;
using System.Data;
using GUI.UserControls;


namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ThemDichVu.xaml
    /// </summary>
    public partial class ThemDichVuTour : Window
    {
        public class DichVu123
        {
            public string TenDichVu { get; set; }
            public string SoLuong { get; set; }
        }

        // Khai báo và khởi tạo danh sách danhSachDichVu

        DichVu123[] danhSachDichVu = new DichVu123[100];
        public string dichvu = "";
        public int count = 0;
        DangKyDichVu dkdv = new DangKyDichVu();
        DichVuBLL dv = new DichVuBLL();
        DichVu dv1 = new DichVu();
        DangKyTour dkt = new DangKyTour();
        TourDuLich tdl = new TourDuLich();
        public string idkh = "";
        public ThemDichVuTour(string id)
        {
            InitializeComponent();

            DataTable dt = TourDuLichBLL.getTenTour();


            foreach (DataRow row in dt.Rows)
            {
                string tenDV = row["IDTour"].ToString(); // Lấy giá trị cột "TenDV"

                // Tạo một ComboBoxItem và thêm vào ComboBox
                ComboBoxItem item = new ComboBoxItem();
                item.Content = tenDV;
                MyComboBox.Items.Add(item);
            }


            // Thêm các mục khác tương tự

            // Chọn mục mặc định (nếu cần)
            MyComboBox.SelectedIndex = 0;
            dkdv.IDKhachHang = id;
            this.idkh = id;
            hienThiDuLieu(id);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();

            this.dichvu = selectedValue;
        }

        private void hienThiDuLieu(string id)
        {
            dkt.IDKhachHang = id;
            DataTable dataTable = DangKyTourBLL.getListDKTour(dkt);
            dgDichVu.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ phần chọn sản phẩm và số lượng
            string ten = MyComboBox.SelectedItem.ToString();
            tdl.IDTour = this.dichvu;



            //dkdv.SL = 12;


            if (txtSLValue1.Text == "" || txtSLValue.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            dkt.GioXuatPhat = txtSLValue1.Text;
            dkt.SoNguoiDi = int.TryParse(txtSLValue.Text, out int songuoi) ? songuoi : 0;
            dkt.GioDK = "12";
            dkt.IDKhachHang = idkh;
            if (dkt.SoNguoiDi <= 0)
            {
                MessageBox.Show("Số người không hợp lệ");
                return;
            }
            DataTable dt = TourDuLichBLL.getTenTour();
            DataTable dataTable = DangKyTourBLL.getListDKTour(dkt);

            foreach (DataRow row in dataTable.Rows)
            {
                string tenDV = row["IDTour"].ToString(); // Lấy giá trị cột "TenDV"
                if (tenDV == this.dichvu)
                {
                    MessageBox.Show("Dịch vụ này đã được thêm");
                    return;
                }
                // Tạo một ComboBoxItem và thêm vào ComboBox
            }
            DangKyTourBLL.addDangKyTour(dkt, tdl);
            dataTable.Clear();
            DataTable dataTable1 = DangKyTourBLL.getListDKTour(dkt);
            dgDichVu.ItemsSource = dataTable1.DefaultView;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dv1.TenDV = "";
            string tendv = (string)((Button)sender).CommandParameter;
            //MessageBox.Show(idNhaXe);
            tdl.NCC = tendv;
            dkt.IDKhachHang = idkh;

            DangKyTourBLL.delDKTour(dkt, tdl);
            DataTable dataTable = DangKyTourBLL.getListDKTour(dkt);
            dgDichVu.ItemsSource = dataTable.DefaultView;
        }

    }
}
