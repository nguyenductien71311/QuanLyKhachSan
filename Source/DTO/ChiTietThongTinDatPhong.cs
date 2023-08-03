using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietThongTinDatPhong
    {
        public string IDPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public DateTime NgayCheckIn { get; set; }
        public DateTime NgayCheckOut { get; set; }
        public int SoLuongNguoi { get; set; }
    }
}
