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
    public partial class ThemSanPham : Window
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
        public string idkh = "";
        public ThemSanPham(string id)
        {




            InitializeComponent();

            DataTable dt = DichVuBLL.get_TenSP();


            foreach (DataRow row in dt.Rows)
            {
                string tenDV = row["TenDV"].ToString(); // Lấy giá trị cột "TenDV"

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
            hienThiDuLieu();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();

            this.dichvu = selectedValue;
        }

        private void hienThiDuLieu()
        {
            DataTable dataTable = DangKyDichVuBLL.getListDK(dkdv);
            dgSanPham.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ phần chọn sản phẩm và số lượng
            string ten = MyComboBox.SelectedItem.ToString();
            dv1.TenDV = this.dichvu;
            if (txtSLValue.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            //string sl = txtSL.Text;
            dkdv.SL = int.TryParse(txtSLValue.Text, out int sl) ? sl : 0;
            //dkdv.SL = 12;
            dkdv.IDKhachHang = this.idkh;
            dkdv.LichSD = "12";
            dkdv.GioDK = "12";
            if (dkdv.SL<=0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                return;
            }
            DangKyDichVuBLL.addDangKyDichVu(dkdv, dv1);

            DataTable dataTable = DangKyDichVuBLL.getListDK(dkdv);
            dgSanPham.ItemsSource = dataTable.DefaultView;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dv1.TenDV = "";
            string tendv = (string)((Button)sender).CommandParameter;
            //MessageBox.Show(idNhaXe);
            dv1.TenDV = tendv;
            dkdv.IDKhachHang = this.idkh;

            //PhuongTienBLL.delPhuongTien(pt);
            DangKyDichVuBLL.delDKDV(dkdv, dv1);
            DataTable dataTable = DangKyDichVuBLL.getListDK(dkdv);
            dgSanPham.ItemsSource = dataTable.DefaultView;
        }
    }
}
