using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class HoaDonAccess : DatabaseAccess
    {
        public ObservableCollection<HoaDon> LoadDataHoaDon()
        {
            ObservableCollection<HoaDon> DSHD = new ObservableCollection<HoaDon>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("QUANLYHOADON", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HoaDon HD = new HoaDon();
                    HD.IDHoaDon = reader["IDHoaDon"].ToString();
                    HD.IDKhachHang = reader["IDKhachHang"].ToString();
                    HD.TenKH = reader["TenKH"].ToString();               
                    HD.NgayCheckIn = Convert.ToDateTime(reader["NgayCheckIn"]);
                    HD.NgayCheckOut = Convert.ToDateTime(reader["NgayCheckOut"]);
                    HD.ThanhTien = Convert.ToInt32(reader["TongTien"]);
                    DSHD.Add(HD);
                }
                reader.Close();
            }
            return DSHD;
        }

        public ObservableCollection<HoaDon> TimDataHD(string TenKH)
        {
            ObservableCollection<HoaDon> dshd = new ObservableCollection<HoaDon>();
            using (SqlConnection connection = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("TIM_HOADONKHACHHANG", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TENKH", TenKH);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    HoaDon HD = new HoaDon();
                    HD.IDHoaDon = reader["IDHoaDon"].ToString();
                    HD.IDKhachHang = reader["IDKhachHang"].ToString();
                    HD.TenKH = reader["TenKH"].ToString();
                    HD.NgayCheckIn = Convert.ToDateTime(reader["NgayCheckIn"]);
                    HD.NgayCheckOut = Convert.ToDateTime(reader["NgayCheckOut"]);
                    HD.ThanhTien = Convert.ToInt32(reader["TongTien"]);
                    dshd.Add(HD);
                }
                reader.Close();
            }
            return dshd;
        }

        public void ThemDataHoaDon(HoaDon hoadon)
        {
            themHoaDon(hoadon);
        }

        public void ThemDataCTHDDatPhong(ChiTietHoaDonDatPhong cthoadondatphong)
        {
            themCTHDDatPhong(cthoadondatphong);
        }

        public void ThemDataCTHDKemTheo(ChiTietHoaDonKemTheo cthoadonkemtheo)
        {
            themCTHDKemTheo(cthoadonkemtheo);
        }

        public void ThemDVDataCTHDKemTheo(ChiTietHoaDonKemTheo cthoadonkemtheo)
        {
            ThemDVCTHDKemTheo(cthoadonkemtheo);
        }

        public void ThemTOURDataCTHDKemTheo(ChiTietHoaDonKemTheo cthoadonkemtheo)
        {
            ThemTOURCTHDKemTheo(cthoadonkemtheo);
        }

        public int GiaPhong(string idPhong)
        {
            int gia = new int();
            gia = GiaPhongCoID(idPhong);
            return gia;
        }

        public int GiaDichVu(string idDichVu)
        {
            int gia = new int();
            gia = GiaDichVuCoID(idDichVu);
            return gia;
        }

        public int GiaTourDuLich(string idTour)
        {
            int gia = new int();
            gia = GiaTourDuLichCoID(idTour);
            return gia;
        }
    }
}
