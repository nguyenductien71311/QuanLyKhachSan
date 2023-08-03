using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string IDHoaDon { get; set; }
        public string IDKhachHang { get; set; }
        public string TenKH { get; set; }
        public string Doan { get; set; }
        public DateTime NgayCheckIn { get; set; }
        public DateTime NgayCheckOut { get; set; }
        public int ThanhTien { get; set; }
        public string IDNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public string PTTT { get; set; }
        public int TongTien { get; set; }
    }
}
