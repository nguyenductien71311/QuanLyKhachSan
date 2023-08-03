using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Collections.ObjectModel;

namespace BLL
{
    public class DangKyTourBLL
    {
        DangKyTourAccess DKTour = new DangKyTourAccess();
        //public void ThemDKTourData(DangKyTour dktour)
        //{
        //    DKTour.ThemDataDKDichVuTour(dktour);
        //}

        public static void addDangKyTour(DangKyTour dkt, TourDuLich tdl)
        {
            DangKyTourAccess.addDangKyTour(dkt, tdl);
        }

        public static DataTable getListDKTour(DangKyTour dkt)
        {
            return DangKyTourAccess.getListDKTour(dkt);
        }

        public static void delDKTour(DangKyTour dkt, TourDuLich tdl)
        {
            DangKyTourAccess.delDKTour(dkt, tdl);
        }

        public ObservableCollection<DangKyTour> LoadDKTour(string IDKhachHang)
        {
            return DKTour.LoadDataDKTour(IDKhachHang);
        }

        public string TourName(string IDTour)
        {
            return DKTour.NameOfTour(IDTour);
        }
    }
}
