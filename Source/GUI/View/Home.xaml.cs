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
    /// Interaction logic for Home.xaml
    /// </summary>
    public class ItemMenuMainWindow
    {
        public string name { get; set; }
        public string foreColor { get; set; }
        public string kind_Icon { get; set; }

        public ItemMenuMainWindow() { }

    }
    public partial class Home : Window
    {
        #region Define variable
        public List<ItemMenuMainWindow> listMenu { get; set; }
        public readonly int CapDoQuyen = 1;
        #endregion
        #region Init Function
        public Home()
        {
            InitializeComponent();
        }
        private void initListViewMenu()
        {
            listMenu = new List<ItemMenuMainWindow>();
            //Khoi tao Menu
            if (CapDoQuyen == 1)
            {
                listMenu.Add(new ItemMenuMainWindow() { name = "Đặt phòng", foreColor = "Gray", kind_Icon = "RoomService" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Danh sách phòng", foreColor = "#FFF08033", kind_Icon = "Bed" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý phòng", foreColor = "Green", kind_Icon = "Book" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý loại phòng", foreColor = "#FFD41515", kind_Icon = "Receipt" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý nhân viên", foreColor = "#FFD41515", kind_Icon = "AccountCircleOutline" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý dịch vụ", foreColor = "#FFD41515", kind_Icon = "Account" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý dịch vụ tour", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý khách hàng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý hóa đơn", foreColor = "Blue", kind_Icon = "ReceiptText" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý tài khoản", foreColor = "Blue", kind_Icon = "FaceAgent" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Phương tiện di chuyển", foreColor = "#FFF08033", kind_Icon = "PlaneCar" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Đăng xuất", foreColor = "#FFF08033", kind_Icon = "Fridge" });
            }

            lisviewMenu.ItemsSource = listMenu;
            lisviewMenu.SelectedValuePath = "name";
        }
        #endregion

        #region Event

        private void btnVisibleMenuBar_Click(object sender, RoutedEventArgs e)
        {
            menuBar.Visibility = Visibility.Visible;
            initListViewMenu();
        }

        private void btnHidenMenuBar_Click(object sender, RoutedEventArgs e)
        {
            menuBar.Visibility = Visibility.Hidden;
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ControlMainDisplayContentHandler(object sender, MouseButtonEventArgs e)
        {
            if (lisviewMenu.SelectedValue != null)
            {
                switch (lisviewMenu.SelectedIndex)
                {
                    case 0:
                        contentDisplayMain.Content = new QuanLyDatPhong();
                        break;
                    case 2:
                        contentDisplayMain.Content = new QuanLyPhong();
                        break;
                    case 3:
                        contentDisplayMain.Content = new QuanLyLoaiPhong();
                        break;
                    case 4:
                        contentDisplayMain.Content = new QuanLyNhanVien();
                        break;
                    case 5:
                        contentDisplayMain.Content = new QuanLyDichVu();
                        break;
                    case 6:
                        contentDisplayMain.Content = new QuanLyDichVuTour();
                        break;
                    case 7:
                        contentDisplayMain.Content = new QuanLyKhachHang();
                        break;
                    case 8:
                        contentDisplayMain.Content = new QuanLyHoaDon();
                        break;
                    case 9:
                        contentDisplayMain.Content = new QuanLyTaiKhoan();
                        break;
                    case 10:
                        contentDisplayMain.Content = new PhuongTienDiChuyen();
                        break;
                }
                btnHidenMenuBar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        #endregion



    }
}
