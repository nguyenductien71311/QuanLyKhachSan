using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Collections.ObjectModel;

namespace DAL
{
    public class DangKyDichVuAccess : DatabaseAccess
    {
        public static void addDangKyDichVu(DangKyDichVu dkdv, DichVu dv)
        {
            addDangKyDichVuDTO(dkdv, dv);
        }

        public static DataTable getListDKDV(DangKyDichVu dkdv)
        {
            return getListDKDVDTO(dkdv);
        }

        public static void delDKDV(DangKyDichVu dkdv, DichVu dv)
        {
            delDKDVDTO(dkdv, dv);
        }

        public static DataTable getListDK(DangKyDichVu dkdv)
        {
            return getListDKDTO(dkdv);
        }

        public ObservableCollection<DangKyDichVu> LoadDKDVData(string IDKhachHang)
        {
            return LoadDataDKDV(IDKhachHang);
        }

        public ObservableCollection<DangKyDichVu> LoadDKSPData(string IDKhachHang)
        {
            return LoadDataDKSP(IDKhachHang);
        }

        public string NameOfDV(string IDDichVu)
        {
            return TenDichVu(IDDichVu);
        }
    }
}
