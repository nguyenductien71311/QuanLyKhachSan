using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Collections.ObjectModel;

namespace BLL
{
    public class DangKyDichVuBLL
    {
        DangKyDichVuAccess dkDV = new DangKyDichVuAccess();

        public static void addDangKyDichVu(DangKyDichVu dkdv, DichVu dv)
        {
            DangKyDichVuAccess.addDangKyDichVu(dkdv, dv);
        }

        public static DataTable getListDKDV(DangKyDichVu dkdv)
        {
            return DangKyDichVuAccess.getListDKDV(dkdv);
        }

        public static void delDKDV(DangKyDichVu dkdv, DichVu dv)
        {
            DangKyDichVuAccess.delDKDV(dkdv, dv);
        }

        public static DataTable getListDK(DangKyDichVu dkdv)
        {
            return DangKyDichVuAccess.getListDK(dkdv);
        }

        public ObservableCollection<DangKyDichVu> LoadDKDV(string IDKhachHang)
        {
            return dkDV.LoadDKDVData(IDKhachHang);
        }

        public ObservableCollection<DangKyDichVu> LoadDKSP(string IDKhachHang)
        {
            return dkDV.LoadDKSPData(IDKhachHang);
        }

        public string NameDV(string IDDichVu)
        {
            return dkDV.NameOfDV(IDDichVu);
        }
    }
}
