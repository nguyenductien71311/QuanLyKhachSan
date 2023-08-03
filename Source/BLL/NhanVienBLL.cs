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
    public class NhanVienBLL
    {
        NhanVienAccess NhanVien = new NhanVienAccess();
        public ObservableCollection<NhanVien> LoadNhanVienData()
        {
            ObservableCollection<NhanVien> DSNhanVien = new ObservableCollection<NhanVien>();
            DSNhanVien = NhanVien.LoadDataNhanVien();
            return DSNhanVien;
        }

        public void ThemNhanVien(NhanVien nhanvien)
        {
            NhanVien.ThemNV(nhanvien);
        }

        public string CheckLogicThemNhanVien(NhanVien nhanvien)
        {
            if (NhanVien.IsIDNhanVienExists(nhanvien.IDNhanVien))
            {
                return "ID_Exist";
            }

            if (string.IsNullOrEmpty(nhanvien.IDNhanVien) ||
                string.IsNullOrEmpty(nhanvien.TenNV) ||
                string.IsNullOrEmpty(nhanvien.ChucVu) ||
                string.IsNullOrEmpty(nhanvien.GioiTinh) ||
                string.IsNullOrEmpty(nhanvien.CCCD) ||
                string.IsNullOrEmpty(nhanvien.DiaChi) ||
                string.IsNullOrEmpty(nhanvien.SDT) ||
                string.IsNullOrEmpty(nhanvien.NgSinh) ||
                string.IsNullOrEmpty(nhanvien.Email))
            {
                return "Required_attriute";
            }


            return "Valid";
        }

        public ObservableCollection<NhanVien> TimNhanVien(string keyword)
        {
            ObservableCollection<NhanVien> allNhanVien = NhanVien.LoadDataNhanVien();

            List<NhanVien> filteredList = allNhanVien.Where(nv => nv.TenNV.Contains(keyword)).ToList();

            ObservableCollection<NhanVien> filteredNhanVien = new ObservableCollection<NhanVien>(filteredList);

            return filteredNhanVien;
        }

        public void XoaNhanVien(string IDNhanVien)
        {
            NhanVien.XoaDataNhanVien(IDNhanVien);
        }
        public void SuaNhanVien(NhanVien nhanvien)
        {
            NhanVien.SuaDataNhanVien(nhanvien);
        }
    }
}
