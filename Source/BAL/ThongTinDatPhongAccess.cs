using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;


namespace DAL
{
    public class ThongTinDatPhongAccess : DatabaseAccess
    {
        public ObservableCollection<ThongTinDatPhong> LoadTTDPData()
        {
            ObservableCollection<ThongTinDatPhong> DSttdp = new ObservableCollection<ThongTinDatPhong>();
            DSttdp = LoadDataTTDP();
            return DSttdp;
        }

        public ThongTinDatPhong TimTTDPData(string idPhong)
        {
            ThongTinDatPhong ttdp = new ThongTinDatPhong();
            ttdp = TimDataTTPD(idPhong);
            return ttdp;
        }

        public void ThemDataTTDPvaCTTTDP(ThongTinDatPhong ttdp, ChiTietThongTinDatPhong ctttdp)
        {
            ThemTTDPvaCTTTDP(ttdp, ctttdp);
        }

        public void XoaDatPhongData(string IDKhachHang)
        {
            XoaDataDatPhong(IDKhachHang);
        }
    }
}
