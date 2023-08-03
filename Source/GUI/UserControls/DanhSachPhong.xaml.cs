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

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for DanhSachPhong.xaml
    /// </summary>

    public class ItemMenuMainWindow
    {
        public string name { get; set; }
        public string foreColor { get; set; }
        public string kind_Icon { get; set; }

        public ItemMenuMainWindow() { }

    }
    public partial class DanhSachPhong : UserControl
    {
        #region Define variable
        public List<ItemMenuMainWindow> listMenu { get; set; }
        public readonly int CapDoQuyen = 0;
        TaiKhoan tk = new TaiKhoan();
        #endregion
        #region Init Function
        public DanhSachPhong(TaiKhoan selectedTaiKhoan)
        {
            InitializeComponent();

            tk = selectedTaiKhoan;
            CapDoQuyen = selectedTaiKhoan.quyen;
        }
        private void initListViewMenu()
        {
            listMenu = new List<ItemMenuMainWindow>();
            //Khoi tao Menu
            if (CapDoQuyen == 3)
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
            else if(CapDoQuyen == 2)
            {
                listMenu.Add(new ItemMenuMainWindow() { name = "Đặt phòng", foreColor = "Gray", kind_Icon = "RoomService" });
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
            else if(CapDoQuyen == 1)
            {
                listMenu.Add(new ItemMenuMainWindow() { name = "Đặt phòng", foreColor = "Gray", kind_Icon = "RoomService" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Danh sách phòng", foreColor = "#FFF08033", kind_Icon = "Bed" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý hóa đơn", foreColor = "Blue", kind_Icon = "ReceiptText" });
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
                if(CapDoQuyen == 3)
                {
                    switch (lisviewMenu.SelectedIndex)
                    {
                        case 0:
                            contentDisplayMain.Content = new QuanLyDatPhong();
                            break;
                        case 1:
                            contentDisplayMain.Content = new DanhSachPhong_GH();
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
                        case 11:
                            DangNhap dangNhap = new DangNhap();
                            dangNhap.Show();
                            Window parentWindow = Window.GetWindow(this);
                            parentWindow.Close();
                            break;
                    }
                    btnHidenMenuBar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }    
                else if(CapDoQuyen == 2)
                {
                    switch (lisviewMenu.SelectedIndex)
                    {
                        case 0:
                            contentDisplayMain.Content = new QuanLyDatPhong();
                            break;
                        //case 1:
                        //    contentDisplayMain.Content = new DanhSachPhong_GH();
                        //    break;
                        case 1:
                            contentDisplayMain.Content = new QuanLyPhong();
                            break;
                        case 2:
                            contentDisplayMain.Content = new QuanLyLoaiPhong();
                            break;
                        case 3:
                            contentDisplayMain.Content = new QuanLyNhanVien();
                            break;
                        case 4:
                            contentDisplayMain.Content = new QuanLyDichVu();
                            break;
                        case 5:
                            contentDisplayMain.Content = new QuanLyDichVuTour();
                            break;
                        case 6:
                            contentDisplayMain.Content = new QuanLyKhachHang();
                            break;
                        case 7:
                            contentDisplayMain.Content = new QuanLyHoaDon();
                            break;
                        case 8:
                            contentDisplayMain.Content = new QuanLyTaiKhoan();
                            break;
                        case 9:
                            contentDisplayMain.Content = new PhuongTienDiChuyen();
                            break;
                        case 10:
                            DangNhap dangNhap = new DangNhap();
                            dangNhap.Show();
                            Window parentWindow = Window.GetWindow(this);
                            parentWindow.Close();
                            break;
                    }
                    btnHidenMenuBar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else if(CapDoQuyen == 1)
                {
                    switch (lisviewMenu.SelectedIndex)
                    {
                        case 0:
                            contentDisplayMain.Content = new QuanLyDatPhong();
                            break;
                        case 1:
                            contentDisplayMain.Content = new DanhSachPhong_GH();
                            break;
                        //case 1:
                        //    contentDisplayMain.Content = new QuanLyPhong();
                        //    break;
                        //case 2:
                        //    contentDisplayMain.Content = new QuanLyLoaiPhong();
                        //    break;
                        //case 3:
                        //    contentDisplayMain.Content = new QuanLyNhanVien();
                        //    break;
                        //case 4:
                        //    contentDisplayMain.Content = new QuanLyDichVu();
                        //    break;
                        //case 5:
                        //    contentDisplayMain.Content = new QuanLyDichVuTour();
                        //    break;
                        //case 6:
                        //    contentDisplayMain.Content = new QuanLyKhachHang();
                        //    break;
                        case 2:
                            contentDisplayMain.Content = new QuanLyHoaDon();
                            break;
                        //case 8:
                        //    contentDisplayMain.Content = new QuanLyTaiKhoan();
                        //    break;
                        case 3:
                            contentDisplayMain.Content = new PhuongTienDiChuyen();
                            break;
                        case 4:
                            DangNhap dangNhap = new DangNhap();
                            dangNhap.Show();
                            Window parentWindow = Window.GetWindow(this);
                            parentWindow.Close();
                            break;
                    }
                    btnHidenMenuBar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }    
            }
        }


        #endregion

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
