using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;

namespace DAL
{
    public class TaikhoanAccess : DatabaseAccess
    {

        public string CheckLogic(TaiKhoan taikhoan)
        {
            string info = CheckLogicDTO(taikhoan);
            return info;
        }

        public ObservableCollection<TaiKhoan> LoadTaiKhoanData()
        {
            ObservableCollection<TaiKhoan> accounts = new ObservableCollection<TaiKhoan>();
            accounts = LoadDataTaiKhoan();
            return accounts;
        }

        public void ThemTaiKhoan(TaiKhoan account)
        {
            ThemDataTaiKhoan(account);
        }

        public ObservableCollection<TaiKhoan> TimTaiKhoan()
        {
            ObservableCollection<TaiKhoan> accounts = new ObservableCollection<TaiKhoan>();
            accounts = TimDataTaiKhoan();
            return accounts;
        }

        public TaiKhoan DataTaiKhoanCoIDNhanVien(string idNhanVien)
        {
            TaiKhoan account = new TaiKhoan();
            account = TaiKhoanCoIDNhanVien(idNhanVien);
            return account;
        }

        public void XoaTaiKhoan(string IDTK)
        {
            XoaDataTaiKhoan(IDTK);
        }

        public void SuaTaiKhoan(TaiKhoan taiKhoan)
        {
            SuaDataTaiKhoan(taiKhoan);
        }

        public int QuyenHanTaiKhoan(TaiKhoan taiKhoan)
        {
            return CapDoQuyenTaiKhoan(taiKhoan);
        }
    }
}
