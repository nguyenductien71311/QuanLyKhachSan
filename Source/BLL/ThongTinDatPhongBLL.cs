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
    public class ThongTinDatPhongBLL
    {
        ThongTinDatPhongAccess TTDatPhong = new ThongTinDatPhongAccess();
        public ObservableCollection<ThongTinDatPhong> LoadTTDPData()
        {
            ObservableCollection<ThongTinDatPhong> DSttdp = new ObservableCollection<ThongTinDatPhong>();
            DSttdp = TTDatPhong.LoadTTDPData();
            return DSttdp;
        }

        public static ThongTinDatPhong TimDataTTPD(string idPhong)
        {
            // Thực hiện truy vấn và xử lý dữ liệu ở đây
            ThongTinDatPhong resTTDP = ThongTinDatPhongAccess.TimDataTTPD(idPhong);
            return resTTDP;
        }

        public void XoaTTDPData(string IDKhachHang)
        {
            TTDatPhong.XoaDatPhongData(IDKhachHang);
        }

        public ObservableCollection<ThongTinDatPhong> TimThongTinDatPhong(string keyword)
        {
            ObservableCollection<ThongTinDatPhong> allTTDP = TTDatPhong.LoadTTDPData();

            List<ThongTinDatPhong> filteredList = allTTDP.Where(ttdp => ttdp.TenKH.Contains(keyword)).ToList();

            ObservableCollection<ThongTinDatPhong> filteredTTDP = new ObservableCollection<ThongTinDatPhong>(filteredList);

            return filteredTTDP;
        }

        public void ThemDataTTDPvaCTTTDP(ThongTinDatPhong ttdp, ChiTietThongTinDatPhong ctttdp)
        {
            TTDatPhong.ThemDataTTDPvaCTTTDP(ttdp, ctttdp);
        }

        //public void SuaDataTTDPvaCTTTDP(ThongTinDatPhong ttdp, ChiTietThongTinDatPhong ctttdp)
        //{
        //    TTDatPhong.SuaDataTTDPvaCTTTDP(ttdp, ctttdp);
        //}
    }
}
