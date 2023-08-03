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
    public class KhachHangBLL
    {
        KhachHangAccess KHAccess = new KhachHangAccess();

        public ObservableCollection<KhachHang> LoadKHData()
        {
            ObservableCollection<KhachHang> KH = new ObservableCollection<KhachHang>();
            KH = KHAccess.LoadDataKhachHang();
            return KH;
        }

        public ObservableCollection<ChiTietThongTinDatPhong> LoadLSDPData(KhachHang KH)
        {
            ObservableCollection<ChiTietThongTinDatPhong> LSDP = new ObservableCollection<ChiTietThongTinDatPhong>();
            LSDP = KHAccess.LoadDataLSDP(KH);
            return LSDP;
        }    

        public void SuaTTKhachHang(KhachHang KH)
        {
            KHAccess.SuaTTKH(KH);
        }

        public int CheckLogicSuaTTKH(KhachHang KH)
        {
            if (KH.IDKhachHang == "" || KH.TenKH == "" || KH.SDT == "" || KH.DiaChi == "" || KH.CCCD == "" || KH.Email == "")
            {
                return 0;
            }
            return 1;
        }
        
        public ObservableCollection<KhachHang> TimKhachHang(string CCCD)
        {
            ObservableCollection<KhachHang> dskh = new ObservableCollection<KhachHang>();
            dskh = KHAccess.TimDataKH(CCCD);
            return dskh;
        }

        public static KhachHang TimDataKH_IDPhong(string idPhong)
        {
            // Thực hiện truy vấn và xử lý dữ liệu ở đây
            KhachHang resTTKH = KhachHangAccess.TimDataKH_IDPhong(idPhong);
            return resTTKH;
        }

        public void XoaKH (KhachHang KH)
        {
            KHAccess.XoaDataKH(KH);
        }
        public void ThemKhacHang(KhachHang khachHang)
        {
            KHAccess.ThemDataKhachHang(khachHang);
        }

        public string CheckLogicThemKhachHang(KhachHang khachhang)
        {
            if (string.IsNullOrEmpty(khachhang.IDKhachHang))
            {
                return "Required_attriute";
            }

            if (KHAccess.IsIDKhacHangExists(khachhang.IDKhachHang))
            {
                return "ID_Exist";
            }

            if (string.IsNullOrEmpty(khachhang.TenKH) || string.IsNullOrEmpty(khachhang.DiaChi) || string.IsNullOrEmpty(khachhang.CCCD) || string.IsNullOrEmpty(khachhang.Email) || string.IsNullOrEmpty(khachhang.Fax) || string.IsNullOrEmpty(khachhang.SDT))
            {
                return "Required_attriute";
            }

            return "Valid";
        }

        public KhachHang TimKhachHangCoIDKhachHang(string IDkh)
        {
            ObservableCollection<KhachHang> allKhachHang = KHAccess.LoadKhachHangData();
            KhachHang kh = new KhachHang();

            kh = allKhachHang.Where(k => k.IDKhachHang.Contains(IDkh)).First();

            return kh;
        }
    }
}
