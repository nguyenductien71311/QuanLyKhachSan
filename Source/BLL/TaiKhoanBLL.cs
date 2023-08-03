using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaikhoanAccess TaiKhoan = new TaikhoanAccess();
        NhanVienAccess NhanVien = new NhanVienAccess(); 
        public string CheckLogic(TaiKhoan taikhoan)
        {
            //kiểm tra nghiệp vụ
            if (taikhoan.Username == "")
            {
                return "requied_taikhoan";
            }

            if (taikhoan.pw == "")
            {
                return "requied_matkhau";
            }

            string info = TaiKhoan.CheckLogic(taikhoan);
            return info;
        }

        public ObservableCollection<TaiKhoan> LoadTaiKhoanData()
        {
            ObservableCollection<TaiKhoan> accounts = new ObservableCollection<TaiKhoan>();
            accounts = TaiKhoan.LoadTaiKhoanData();
            return accounts;
        }

        public void ThemTaiKhoan(TaiKhoan account)
        {
            TaiKhoan.ThemTaiKhoan(account);
        }

        public string CheckLogicThemTaiKhoan(TaiKhoan account)
        {
            if (string.IsNullOrEmpty(account.IDTK))
            {
                return "Required_attriute";
            }

            if (TaiKhoan.IsIDTaiKhoanExists(account.IDTK))
            {
                return "ID_Exist";
            }

            if (!NhanVien.IsIDNhanVienExists(account.IDNhanVien))
            {
                return "ID Nhan Vien not exist";
            }    

            if (string.IsNullOrEmpty(account.Username) || account.quyen <= 0 || string.IsNullOrEmpty(account.pw) || string.IsNullOrEmpty(account.IDNhanVien))
            {
                return "Required_attriute";
            }

            return "Valid";
        }

        public ObservableCollection<TaiKhoan> TimTaiKhoan(string keyword)
        {
            ObservableCollection<TaiKhoan> allTaiKhoan = TaiKhoan.LoadTaiKhoanData();

            List<TaiKhoan> filteredList = allTaiKhoan.Where(nv => nv.IDNhanVien.Contains(keyword)).ToList();

            ObservableCollection<TaiKhoan> filteredTaiKhoan = new ObservableCollection<TaiKhoan>(filteredList);

            return filteredTaiKhoan;
        }

        public TaiKhoan TimTaiKhoanCoIDNhanVien(string IDnhanvien)
        {
            TaiKhoan account = TaiKhoan.DataTaiKhoanCoIDNhanVien(IDnhanvien);
            return account;
        }

        public void XoaTaiKhoan(string IDTK)
        {
            TaiKhoan.XoaTaiKhoan(IDTK);
        }

        public void SuaTaiKhoan(TaiKhoan account)
        {
            TaiKhoan.SuaTaiKhoan(account);
        }

        public string CheckLogicSuaTaiKhoan(TaiKhoan account)
        {
            if (account.quyen <= 0 || account.quyen >= 3)
            {
                return "Invalid";
            }

            if(!NhanVien.IsIDNhanVienExists(account.IDNhanVien))
            {
                return "ID Nhan Vien not exist";
            }

            return "Valid";
        }

        public int QuyenTaiKhoan(TaiKhoan account)
        {
            return TaiKhoan.QuyenHanTaiKhoan(account);
        }
    }
}
