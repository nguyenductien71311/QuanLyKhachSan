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
    public class HoaDonBLL
    {
        HoaDonAccess HDAccess = new HoaDonAccess();
        HoaDonAccess HoaDon = new HoaDonAccess();

        public ObservableCollection<HoaDon> LoadHDData()
        {
            ObservableCollection<HoaDon> DSHD = new ObservableCollection<HoaDon>();
            DSHD = HDAccess.LoadDataHoaDon();
            return DSHD;
        }
        public ObservableCollection<HoaDon> TimHoaDon(string TenKH)
        {
            ObservableCollection<HoaDon> DSHD = new ObservableCollection<HoaDon>();
            DSHD = HDAccess.TimDataHD(TenKH);
            return DSHD;
        }

        public void TaoHoaDon(HoaDon hoadon)
        {
            HoaDon.ThemDataHoaDon(hoadon);
        }

        public void TaoChiTietHoaDonDatPhong(ObservableCollection<ChiTietHoaDonDatPhong> hoadondatphong)
        {
            foreach (var hoadon in hoadondatphong)
            {
                HoaDon.ThemDataCTHDDatPhong(hoadon);
            }
        }

        public void TaoChiTietHoaDonKemTheo(ObservableCollection<ChiTietHoaDonKemTheo> hoadonkemtheo)
        {
            foreach (var hoadon in hoadonkemtheo)
            {
                HoaDon.ThemDataCTHDKemTheo(hoadon);
            }
        }

        public void TaoDVChiTietHoaDonKemTheo(ObservableCollection<ChiTietHoaDonKemTheo> hoadonkemtheo)
        {
            foreach (var hoadon in hoadonkemtheo)
            {
                HoaDon.ThemDVDataCTHDKemTheo(hoadon);
            }
        }

        public void TaoTOURChiTietHoaDonKemTheo(ObservableCollection<ChiTietHoaDonKemTheo> hoadonkemtheo)
        {
            foreach (var hoadon in hoadonkemtheo)
            {
                HoaDon.ThemTOURDataCTHDKemTheo(hoadon);
            }
        }

        public int Gia_Phong(string idPhong)
        {
            int gia = new int();
            gia = HoaDon.GiaPhong(idPhong);
            return gia;
        }

        public int Gia_DichVU(string idDichVu)
        {
            int gia = new int();
            gia = HoaDon.GiaDichVu(idDichVu);
            return gia;
        }

        public int Gia_Tour(string idTour)
        {
            int gia = new int();
            gia = HoaDon.GiaTourDuLich(idTour);
            return gia;
        }
    }
}
