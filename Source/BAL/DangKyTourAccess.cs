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
    public class DangKyTourAccess : DatabaseAccess
    {
        //public void ThemDKDVTourData()
        //{
        //    DangKyTour dktour = new DangKyTour();
        //    ThemDataDKDichVuTour(dktour);
        //}
        public static void addDangKyTour(DangKyTour dkt, TourDuLich tdl)
        {
            addDangKyTourDTO(dkt, tdl);
        }

        public static DataTable getListDKTour(DangKyTour dkt)
        {
            return getListDKTourDTO(dkt);
        }

        public static void delDKTour(DangKyTour dkt, TourDuLich tdl)
        {
            delDKTourDTO(dkt, tdl);
        }

        public ObservableCollection<DangKyTour> LoadDKTourData(string IDKhachHang)
        {
            return LoadDataDKTour(IDKhachHang);
        }

        public string NameOfTour(string IDTour)
        {
            return TenTour(IDTour);
        }

    }
}
