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
    public class ChiTietThongTinDatPhongBLL
    {
        ChiTietThongTinDatPhongAccess CTTTDatPhong = new ChiTietThongTinDatPhongAccess();

        public ObservableCollection<ChiTietThongTinDatPhong> LoadCTTTDPData(ThongTinDatPhong ttdatphong)
        {
            ObservableCollection<ChiTietThongTinDatPhong> DSctttdp = new ObservableCollection<ChiTietThongTinDatPhong>();
            DSctttdp = CTTTDatPhong.LoadCTTTDPData(ttdatphong);
            return DSctttdp;
        }
    }
}
