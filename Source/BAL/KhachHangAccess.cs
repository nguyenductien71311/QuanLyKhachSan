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
    public class KhachHangAccess : DatabaseAccess
    {
        public ObservableCollection<KhachHang> LoadDataKhachHang()
        {
            ObservableCollection<KhachHang> DSKhachHang = new ObservableCollection<KhachHang>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("XEM_DANHSACHKHACHHANG", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhachHang KH = new KhachHang();
                    KH.IDKhachHang = reader["IDKhachHang"].ToString();
                    KH.TenKH = reader["TenKH"].ToString();
                    KH.CCCD = reader["CCCD"].ToString();
                    KH.DiaChi = reader["DiaChi"].ToString();
                    KH.SDT = reader["SDT"].ToString();
                    KH.Email = reader["Email"].ToString();
                    DSKhachHang.Add(KH);
                }
                reader.Close();
            }
            return DSKhachHang;
        }
        public ObservableCollection<ChiTietThongTinDatPhong> LoadDataLSDP (KhachHang KH)
        {
            ObservableCollection<ChiTietThongTinDatPhong> lsdp = new ObservableCollection<ChiTietThongTinDatPhong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("XEM_CTTHONGTINDATPHONG", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDKH", KH.IDKhachHang);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ChiTietThongTinDatPhong ct = new ChiTietThongTinDatPhong();
                    ct.IDPhong = reader["IDPhong"].ToString();
                    ct.TenLoaiPhong = reader["Ten"].ToString();
                    ct.NgayCheckIn = Convert.ToDateTime(reader["NgayCheckIn"]);
                    ct.NgayCheckOut = Convert.ToDateTime(reader["NgayCheckOut"]);
                    ct.SoLuongNguoi = Convert.ToInt32(reader["SoLuongNguoi"]);

                    lsdp.Add(ct);
                }
                reader.Close();
            }    

            return lsdp;
        }

        public void SuaTTKH(KhachHang KH)
        {
            using (SqlConnection connection = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("SUA_THONGTINKHACHHANG", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKH", KH.IDKhachHang);
                command.Parameters.AddWithValue("@TENKH", KH.TenKH);
                command.Parameters.AddWithValue("@CCCD", KH.CCCD);
                command.Parameters.AddWithValue("@DIACHI", KH.DiaChi);
                command.Parameters.AddWithValue("@SDT", KH.SDT);
                command.Parameters.AddWithValue("@EMAIL", KH.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<KhachHang> TimDataKH(string CCCD)
        {
            ObservableCollection<KhachHang> dskh = new ObservableCollection<KhachHang>();
            using (SqlConnection connection = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("TIM_THONGTINKHACHHANG", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CCCD", CCCD);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KhachHang KH = new KhachHang();
                    KH.IDKhachHang = reader["IDKhachHang"].ToString();
                    KH.TenKH = reader["TenKH"].ToString();
                    KH.CCCD = reader["CCCD"].ToString();
                    KH.DiaChi = reader["DiaChi"].ToString();
                    KH.SDT = reader["SDT"].ToString();
                    KH.Email = reader["Email"].ToString();
                    dskh.Add(KH);
                }
                reader.Close();
            }
            return dskh;
        }
        
        public void XoaDataKH(KhachHang KH)
        {
            using (SqlConnection connection = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("XOA_THONGTINKHACHHANG", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKH", KH.IDKhachHang);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public KhachHang TimKHData_IDPhong(string idPhong)
        {
            KhachHang kh = new KhachHang();
            kh = TimDataKH_IDPhong(idPhong);
            return kh;
        }

        public ObservableCollection<KhachHang> LoadKhachHangData()
        {
            ObservableCollection<KhachHang> dskh = new ObservableCollection<KhachHang>();
            dskh = LoadDataKhachHang();
            return dskh;
        }

        public void ThemDataKhachHang(KhachHang khachhang)
        {
            ThemKhachHang(khachhang);
        }
    }
}
