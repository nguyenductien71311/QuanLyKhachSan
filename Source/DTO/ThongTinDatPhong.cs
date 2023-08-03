using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinDatPhong
    {
        public string IDKhachHang { get; set; }
        public string IDPhong { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayCheckIn { get; set; }
        public DateTime NgayCheckOut { get; set; }
        public string SoLuongNguoi { get; set; }

    }
}
