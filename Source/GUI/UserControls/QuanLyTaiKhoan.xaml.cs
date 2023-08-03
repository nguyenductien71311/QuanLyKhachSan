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
using System.Collections.ObjectModel;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for QuanLyTaiKhoan.xaml
    /// </summary>
    public partial class QuanLyTaiKhoan : UserControl
    {
        private TaiKhoanBLL accountBLL;
        private ObservableCollection<TaiKhoan> accounts;
        private ObservableCollection<TaiKhoan> filteredAccount;

        public QuanLyTaiKhoan()
        {
            InitializeComponent();

            accountBLL = new TaiKhoanBLL();
            accounts = new ObservableCollection<TaiKhoan>();
            filteredAccount = new ObservableCollection<TaiKhoan>();

            LoadTaiKhoan();
        }

        public void LoadTaiKhoan()
        {
            accounts.Clear();

            ObservableCollection<TaiKhoan> accountsFromBLL = accountBLL.LoadTaiKhoanData();

            foreach (var account in accountsFromBLL)
            {
                accounts.Add(account);
            }
            lsvTaiKhoan.ItemsSource = accounts;
        }
        private void btnThemTaiKhoan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ThemTaiKhoan themTaiKhoan = new ThemTaiKhoan();
            themTaiKhoan.QuanLyTaiKhoanScreen = this;
            themTaiKhoan.ShowDialog();
        }

        private void btnFilter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            accounts.Clear();
            string keyword = txtFilter.Text;
            filteredAccount = accountBLL.TimTaiKhoan(keyword);
            foreach (var account in filteredAccount)
            {
                accounts.Add(account);
            }
            lsvTaiKhoan.ItemsSource = accounts;
        }

        private void TaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                accounts.Clear();
                string keyword = txtFilter.Text;

                filteredAccount = accountBLL.TimTaiKhoan(keyword);
                foreach (var account in filteredAccount)
                {
                    accounts.Add(account);
                }
                lsvTaiKhoan.ItemsSource = accounts;
                txtFilter.Text = string.Empty;
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btnXoaTaiKhoan = (Button)sender;
            string idtk = btnXoaTaiKhoan.Tag.ToString();

            accountBLL.XoaTaiKhoan(idtk);
            accounts.Clear();
            ObservableCollection<TaiKhoan> accoutsFromBLL = accountBLL.LoadTaiKhoanData();

            foreach (var account in accoutsFromBLL)
            {
                accounts.Add(account);
            }
            lsvTaiKhoan.ItemsSource = accounts;
        }

        private void btnSuaTaiKhoan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Lấy dòng được chọn từ ListView
            var button = sender as Button;
            var listViewItem = FindVisualParent<ListViewItem>(button);
            var selectedTaiKhoan = listViewItem.DataContext as TaiKhoan;

            if (selectedTaiKhoan != null)
            {
                SuaTaiKhoan suaTaiKhoan = new SuaTaiKhoan(selectedTaiKhoan);
                suaTaiKhoan.QuanLyTaiKhoanScreen = this;
                suaTaiKhoan.ShowDialog();
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
