using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;

namespace DAL
{
    public class ChiTietThongTinDatPhongAccess : DatabaseAccess
    {
        public ObservableCollection<ChiTietThongTinDatPhong> LoadCTTTDPData(ThongTinDatPhong ttdatphong)
        {
            ObservableCollection<ChiTietThongTinDatPhong> DSctttdp = new ObservableCollection<ChiTietThongTinDatPhong>();
            DSctttdp = LoadDataCTTTDP(ttdatphong);
            return DSctttdp;
        }
    }
}
