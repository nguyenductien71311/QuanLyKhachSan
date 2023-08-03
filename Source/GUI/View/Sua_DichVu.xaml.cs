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
    /// Interaction logic for Sua_dichVu.xaml
    /// </summary>
    public partial class Sua_DichVu : Window
    {
        public string dataValue;
        public string temp123;

        DichVu dv = new DichVu();
        public Sua_DichVu(string temp)
        {
            InitializeComponent();
            dv.IDDichVu = temp;
            DataTable dataTable = DichVuBLL.getIDDichVu(dv);
            string tendv = "";
            string gia = "";
            string sl = "";
            string km = "";
            string tinhtrang = "";
            //dgPhuongTien.ItemsSource = dataTable.DefaultView;
            foreach (DataRow row in dataTable.Rows)
            {
                tendv = row["TenDV"].ToString();

                gia = row["Gia"].ToString();

                sl = row["SL"].ToString();

                km = row["KM"].ToString();

                tinhtrang = row["TinhTrang"].ToString();

            }

            txtTenDichVu.Text = tendv;
            txtGia.Text = gia;
            txtSL.Text = sl;
            txtKM.Text = km;
            txtTinhTrang.Text = tinhtrang;
            //loadData(temp);


            this.temp123 = temp;


        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (txtTenDichVu.Text == "" || txtGia.Text == "" || txtSL.Text == "" || txtKM.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            dv.TenDV = txtTenDichVu.Text;
            dv.Gia = int.TryParse(txtGia.Text, out int gia) ? gia : 0;
            dv.SL = int.TryParse(txtSL.Text, out int sl) ? sl : 0;
            dv.KM = float.TryParse(txtKM.Text, out float km) ? km : 0;
            dv.TinhTrang = txtTinhTrang.Text;

            string result = DichVuBLL.editDichVu(dv);
            if (result == "Sai giá")
            {
                MessageBox.Show("Giá không được nhỏ hơn 100,000 VND");
                return;
            }

            if (result == "Sai số lượng")
            {
                MessageBox.Show("Số lượng nhập không được nhỏ hơn 100");
                return;
            }

            if (result == "Sai khuyến mãi")
            {
                MessageBox.Show("Phần trăm khuyến mãi từ 0 đến 50");
                return;
            }

            if (txtGia.Text == "" || txtSL.Text == "" || txtKM.Text == "")
            {
                MessageBox.Show("Bạn không thể để trống bất kỳ dòng nào");
                return;
            }

            if (result == "Trống")
            {
                MessageBox.Show("Bạn không thể để trống bất kỳ dòng nào");
                return;
            }


            if (result == "Thành công")
            {
                MessageBox.Show("Sửa thành công");
            }

            var edit = new DichVu();


            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
