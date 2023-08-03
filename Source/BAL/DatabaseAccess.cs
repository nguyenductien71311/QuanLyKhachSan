using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Principal;

namespace DAL
{
    public class SqlConnectData
    {
        // Tạo chuỗi kết nối CSDL

        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=NHUTTT\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon); // khởi tạo connect
            return conn;
        }
    }
    public class DatabaseAccess
    {

        //Table Account
        public static string CheckLogicDTO(TaiKhoan taikhoan)
        {
            string user = null;
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("login", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user", taikhoan.Username);
            command.Parameters.AddWithValue("@pass", taikhoan.pw);
            //kiểm tra quyền

            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                    return user;
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                return "Tài khoản hoặc mật khẩu không chính xác";
            }

            return user;
        }

        public ObservableCollection<TaiKhoan> LoadDataTaiKhoan() 
        {
            ObservableCollection<TaiKhoan> accounts = new ObservableCollection<TaiKhoan>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("XemAccount", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) 
                {
                    TaiKhoan account = new TaiKhoan();
                    account.IDTK = reader["IDTK"].ToString();
                    account.Username = reader["Username"].ToString();
                    account.pw = reader["pw"].ToString();
                    account.quyen = Convert.ToInt32(reader["quyenhan"]);
                    account.IDNhanVien = reader["IDNhanVien"].ToString();

                    accounts.Add(account);
                }

                reader.Close();
            }
            return accounts;
        }

        public void ThemDataTaiKhoan(TaiKhoan account)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("themaccount", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTK", account.IDTK);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@password", account.pw);
                command.Parameters.AddWithValue("@quyenhan", account.quyen);
                command.Parameters.AddWithValue("@IDNhanVien", account.IDNhanVien);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool IsIDTaiKhoanExists(string idTK)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT COUNT(*) FROM Account WHERE IDTK = @IDTK";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDTK", idTK);

                conn.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public TaiKhoan TaiKhoanCoIDNhanVien(string idNhanVien)
        {
            TaiKhoan account = new TaiKhoan();
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT * FROM Account WHERE IDNhanVien = @IDNhanVien";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDNhanVien", idNhanVien);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {                    
                    account.IDTK = reader["IDTK"].ToString();
                    account.Username = reader["Username"].ToString();
                    account.pw = reader["pw"].ToString();
                    account.quyen = Convert.ToInt32(reader["quyenhan"]);
                    account.IDNhanVien = reader["IDNhanVien"].ToString();                
                }

                reader.Close();
            }
            return account;
        }

        public ObservableCollection<TaiKhoan> TimDataTaiKhoan()
        {
            ObservableCollection<TaiKhoan> resTaiKhoan = new ObservableCollection<TaiKhoan>();
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("timaccount", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TaiKhoan account = new TaiKhoan();
                    account.IDTK = reader["IDTK"].ToString();
                    account.Username = reader["Username"].ToString();
                    account.pw = reader["pw"].ToString();
                    account.quyen = Convert.ToInt32(reader["quyenhan"]);
                    account.IDNhanVien = reader["IDNhanVien"].ToString();

                    resTaiKhoan.Add(account);
                }

                reader.Close();
            }
            return resTaiKhoan;
        }

        public void XoaDataTaiKhoan(string IDTK)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {

                SqlCommand command = new SqlCommand("xoaaccount", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTK", IDTK);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SuaDataTaiKhoan(TaiKhoan account)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("suaaccount", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTK", account.IDTK);
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@password", account.pw);
                command.Parameters.AddWithValue("@quyenhan", account.quyen);
                command.Parameters.AddWithValue("@IDNhanVien", account.IDNhanVien);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public int CapDoQuyenTaiKhoan(TaiKhoan account)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT quyenhan FROM Account WHERE Username = @username";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", account.Username);

                conn.Open();
                int quyen = (int)command.ExecuteScalar();

                return quyen;
            }
        }


        //Table Loai Phong
        public ObservableCollection<LoaiPhong> LoadDataLoaiPhong()
        {
            ObservableCollection<LoaiPhong> roomTypes = new ObservableCollection<LoaiPhong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("XemLoaiPhong", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LoaiPhong roomType = new LoaiPhong();
                    roomType.IDLoai = reader["IDLoai"].ToString();
                    roomType.Ten = reader["Ten"].ToString();
                    roomType.Gia = Convert.ToInt32(reader["Gia"]);
                    roomType.SoNguoi = Convert.ToInt32(reader["SoNguoi"]);

                    roomTypes.Add(roomType);
                }

                reader.Close();
            }

            return roomTypes;
        }

        public void ThemLoaiPhong(LoaiPhong loaiPhong)
        {
            using (SqlConnection conn = SqlConnectData.Connect()){
                SqlCommand command = new SqlCommand("themloaiphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDLoai", loaiPhong.IDLoai);
                command.Parameters.AddWithValue("@Ten", loaiPhong.Ten);
                command.Parameters.AddWithValue("@Gia", loaiPhong.Gia);
                command.Parameters.AddWithValue("@SoNguoi", loaiPhong.SoNguoi);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool IsIDLoaiPhongExists(string idLoai)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT COUNT(*) FROM LoaiPhong WHERE IDLoai = @IDLoai";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDLoai", idLoai);

                conn.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public ObservableCollection<LoaiPhong> TimDataLoaiPhong()
        {
            ObservableCollection<LoaiPhong> resLoaiPhong = new ObservableCollection<LoaiPhong>();
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("timloaiphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LoaiPhong roomType = new LoaiPhong();
                    roomType.IDLoai = reader["IDLoai"].ToString();
                    roomType.Ten = reader["Ten"].ToString();
                    roomType.Gia = Convert.ToInt32(reader["Gia"]);
                    roomType.SoNguoi = Convert.ToInt32(reader["SoNguoi"]);

                    resLoaiPhong.Add(roomType);
                }

                reader.Close();
            }
            return resLoaiPhong;
        }

        public void XoaDataLoaiPhong(string IDLoai)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                
                SqlCommand command = new SqlCommand("xoaloaiphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDLoai", IDLoai);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SuaDataLoaiPhong(LoaiPhong loaiPhong)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("sualoaiphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDLoai", loaiPhong.IDLoai);
                command.Parameters.AddWithValue("@Ten", loaiPhong.Ten);
                command.Parameters.AddWithValue("@Gia", loaiPhong.Gia);
                command.Parameters.AddWithValue("@SoNguoi", loaiPhong.SoNguoi);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        
        //Table NhanVien
        public ObservableCollection<NhanVien> LoadDataNhanVien()
        {
            ObservableCollection<NhanVien> DSNhanVien = new ObservableCollection<NhanVien>();

            using(SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("xemnhanvien", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NhanVien NV = new NhanVien();
                    NV.IDNhanVien = reader["IDNhanVien"].ToString();
                    NV.TenNV = reader["TenNV"].ToString();
                    NV.ChucVu = reader["Chucvu"].ToString();
                    NV.NgSinh = reader["NgSinh"].ToString();
                    NV.SDT = reader["SDT"].ToString();
                    NV.Email = reader["Email"].ToString();
                    NV.GioiTinh = reader["GioiTinh"].ToString();
                    NV.CCCD = reader["CCCD"].ToString();
                    NV.DiaChi = reader["DiaChi"].ToString();

                    DSNhanVien.Add(NV);
                }

                reader.Close();
            }

            return DSNhanVien;
        }
        public void ThemNV(NhanVien nhanvien)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("themnhanvien", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDNhanVien", nhanvien.IDNhanVien);
                command.Parameters.AddWithValue("@TenNV", nhanvien.TenNV);
                command.Parameters.AddWithValue("@ChucVu", nhanvien.ChucVu);
                command.Parameters.AddWithValue("@NgSinh", nhanvien.NgSinh);
                command.Parameters.AddWithValue("@SDT", nhanvien.SDT);
                command.Parameters.AddWithValue("@Email", nhanvien.Email);
                command.Parameters.AddWithValue("@GioiTinh", nhanvien.GioiTinh);
                command.Parameters.AddWithValue("@CCCD", nhanvien.CCCD);
                command.Parameters.AddWithValue("@DiaChi", nhanvien.DiaChi);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool IsIDNhanVienExists(string idNhanVien)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE IDNhanVien = @idNhanVien";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@idNhanVien", idNhanVien);

                conn.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public ObservableCollection<NhanVien> TimDataNhanVien()
        {
            ObservableCollection<NhanVien> resNhanVien = new ObservableCollection<NhanVien>();
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("timnhanvien", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NhanVien NV = new NhanVien();
                    NV.IDNhanVien = reader["IDNhanVien"].ToString();
                    NV.TenNV = reader["TenNV"].ToString();
                    NV.ChucVu = reader["Chucvu"].ToString();
                    NV.NgSinh = reader["NgSinh"].ToString();
                    NV.SDT = reader["SDT"].ToString();
                    NV.Email = reader["Email"].ToString();
                    NV.GioiTinh = reader["GioiTinh"].ToString();
                    NV.CCCD = reader["CCCD"].ToString();
                    NV.DiaChi = reader["DiaChi"].ToString();

                    resNhanVien.Add(NV);
                }

                reader.Close();
            }
            return resNhanVien;
        }

        public void SuaDataNhanVien(NhanVien nhanvien)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("suanhanvien", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDNhanVien", nhanvien.IDNhanVien);
                command.Parameters.AddWithValue("@TenNV", nhanvien.TenNV);
                command.Parameters.AddWithValue("@ChucVu", nhanvien.ChucVu);
                command.Parameters.AddWithValue("@NgSinh", nhanvien.NgSinh);
                command.Parameters.AddWithValue("@SDT", nhanvien.SDT);
                command.Parameters.AddWithValue("@Email", nhanvien.Email);
                command.Parameters.AddWithValue("@GioiTinh", nhanvien.GioiTinh);
                command.Parameters.AddWithValue("@CCCD", nhanvien.CCCD);
                command.Parameters.AddWithValue("@DiaChi", nhanvien.DiaChi);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void XoaDataNhanVien(string IDNhanVien)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("xoanhanvien", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }


        //Table Phong
        public ObservableCollection<Phong> LoadDataPhong()
        {
            ObservableCollection<Phong> DSPhong = new ObservableCollection<Phong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("XemPhong", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Phong phong = new Phong();
                    phong.IDPhong = reader["IDPhong"].ToString();
                    phong.LoaiPhong = reader["IDLoai"].ToString();
                    phong.TrangThai = reader["TrangThai"].ToString();
                    phong.TinhTrang = reader["TinhTrang"].ToString();

                    DSPhong.Add(phong);
                }

                reader.Close();
            }

            return DSPhong;
        }
        public void ThemPhong(Phong phong)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("themphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDPhong", phong.IDPhong);
                command.Parameters.AddWithValue("@TrangThai", phong.TrangThai);
                command.Parameters.AddWithValue("@IDLoai", phong.LoaiPhong);
                command.Parameters.AddWithValue("@TinhTrang", phong.TinhTrang);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool IsIDPhongExists(string idPhong)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT COUNT(*) FROM Phong WHERE IDPhong = @IDPhong";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDPhong", idPhong);

                conn.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public ObservableCollection<Phong> TimDataPhong()
        {
            ObservableCollection<Phong> resPhong = new ObservableCollection<Phong>();
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("timphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Phong phong = new Phong();
                    phong.IDPhong = reader["IDPhong"].ToString();
                    phong.TinhTrang = reader["TinhTrang"].ToString();
                    phong.LoaiPhong = reader["LoaiPhong"].ToString();
                    phong.TrangThai = reader["TrangThai"].ToString();

                    resPhong.Add(phong);
                }

                reader.Close();
            }
            return resPhong;
        }

        public void SuaDataPhong(Phong phong)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("suaphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDPhong", phong.IDPhong);
                command.Parameters.AddWithValue("@TinhTrang", phong.TinhTrang);
                command.Parameters.AddWithValue("@IDLoai", phong.LoaiPhong);
                command.Parameters.AddWithValue("@TrangThai", phong.TrangThai);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void XoaDataPhong(string IDPhong)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("xoaphong", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDPhong", IDPhong);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public ObservableCollection<Phong> LoadDataPhongTrong()
        {
            ObservableCollection<Phong> DSphongtrong = new ObservableCollection<Phong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DanhSachPhongTrong", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Phong phongtrong = new Phong();
                    phongtrong.IDPhong = reader["IDPhong"].ToString();
                    phongtrong.LoaiPhong = reader["Ten"].ToString();
                    phongtrong.TrangThai = reader["TrangThai"].ToString();
                    phongtrong.TinhTrang = reader["TinhTrang"].ToString();

                    DSphongtrong.Add(phongtrong);
                }

                reader.Close();
            }

            return DSphongtrong;
        }

         public Phong TimPhongCoID(string idPhong)
        {
            Phong phong = new Phong();

            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT * FROM Phong WHERE IDPhong = @IDPhong";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDPhong", idPhong);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    phong.IDPhong = reader["IDPhong"].ToString();
                    phong.TinhTrang = reader["TinhTrang"].ToString();
                    phong.LoaiPhong = reader["LoaiPhong"].ToString();
                    phong.TrangThai = reader["TrangThai"].ToString();
                }

                reader.Close() ;
            }

            return phong;
        }

        //Table Khach Hang
        public ObservableCollection<KhachHang> LoadDataKhachHang()
        {
            ObservableCollection<KhachHang> DSKhachHang = new ObservableCollection<KhachHang>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("XEM_DANHSACHKHACHHANG", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KhachHang kh = new KhachHang();

                    kh.IDKhachHang = reader["IDKhachHang"].ToString();
                    kh.TenKH = reader["TenKH"].ToString();
                    kh.CCCD = reader["CCCD"].ToString();
                    kh.SDT = reader["SDT"].ToString();
                    kh.Email = reader["Email"].ToString();
                    kh.DiaChi = reader["DiaChi"].ToString();
                    kh.Fax = reader["Fax"].ToString();

                    DSKhachHang.Add(kh);
                }

                reader.Close();
            }

            return DSKhachHang;
        }

        public void ThemKhachHang(KhachHang khachhang)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("them_thongtinkhachhang", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDKH", khachhang.IDKhachHang);
                command.Parameters.AddWithValue("@TENKH", khachhang.TenKH);
                command.Parameters.AddWithValue("@CCCD", khachhang.CCCD);
                command.Parameters.AddWithValue("@SDT", khachhang.SDT);
                command.Parameters.AddWithValue("@DIACHI", khachhang.DiaChi);
                command.Parameters.AddWithValue("@EMAIL", khachhang.Email);
                command.Parameters.AddWithValue("@FAX", khachhang.Fax);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool IsIDKhacHangExists(string idKhachHang)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT COUNT(*) FROM KHACHHANG WHERE IDKhachHang = @IDKhachHang";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDKhachHang", idKhachHang);

                conn.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        //----------------------------------------------------Table Thong Tin Dat Phong----------------------------------------------------
        public ObservableCollection<ThongTinDatPhong> LoadDataTTDP()
        {
            ObservableCollection<ThongTinDatPhong> DSThongTinDatPhong = new ObservableCollection<ThongTinDatPhong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Xem_DanhSachDatPhong", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ThongTinDatPhong ttdatphong = new ThongTinDatPhong();

                    ttdatphong.IDKhachHang = reader["IDKhachHang"].ToString();
                    ttdatphong.TenKH = reader["TenKH"].ToString();
                    ttdatphong.NgayDat = Convert.ToDateTime(reader["NgayDat"]);

                    DSThongTinDatPhong.Add(ttdatphong);
                }

                reader.Close();
            }

            return DSThongTinDatPhong;
        }

        public void XoaDataDatPhong (string IDKhachHang)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("XOA_THONGTINDATPHONG", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKH", IDKhachHang);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ThemTTDPvaCTTTDP(ThongTinDatPhong ttdp, ChiTietThongTinDatPhong ctttdp)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("them_thongtindatphong", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDKH", ttdp.IDKhachHang);
                command.Parameters.AddWithValue("@NGAYDAT", ttdp.NgayDat);
                
                command.Parameters.AddWithValue("@IDP", ctttdp.IDPhong);
                command.Parameters.AddWithValue("@NGAYCHECKIN", ctttdp.NgayCheckIn);
                command.Parameters.AddWithValue("@NGAYCHECKOUT", ctttdp.NgayCheckOut);
                command.Parameters.AddWithValue("@SOLUONGNGUOI", ctttdp.SoLuongNguoi);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        //----------------------------Chi Tiet Thong Tin Dat Phong----------------------------
        public ObservableCollection<ChiTietThongTinDatPhong> LoadDataCTTTDP(ThongTinDatPhong ttdatphong)
        {
            ObservableCollection<ChiTietThongTinDatPhong> DSCTThongTinDatPhong = new ObservableCollection<ChiTietThongTinDatPhong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Xem_CTThongTinDatPhong", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("IDKH", ttdatphong.IDKhachHang);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ChiTietThongTinDatPhong ctttdatphong = new ChiTietThongTinDatPhong();

                    ctttdatphong.IDPhong = reader["IDPhong"].ToString();
                    ctttdatphong.TenLoaiPhong = reader["Ten"].ToString();
                    ctttdatphong.NgayCheckIn = Convert.ToDateTime(reader["NgayCheckIn"]);
                    ctttdatphong.NgayCheckOut = Convert.ToDateTime(reader["NgayCheckOut"]);
                    ctttdatphong.SoLuongNguoi = Convert.ToInt32(reader["SoLuongNguoi"]);

                    DSCTThongTinDatPhong.Add(ctttdatphong);
                }
                reader.Close();
            }

            return DSCTThongTinDatPhong;
        }

        //Table Doan
        public Doan LoadDataDoan(string IDKhachHang)
        {
            Doan doan = new Doan();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                string query = "SELECT * FROM Doan WHERE IDKhachHang = @IDKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDKH", IDKhachHang);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    doan.IDDoan = reader["IDDoan"].ToString();
                    doan.TenDoan = reader["TenDoan"].ToString();
                    doan.NguoiDaiDien = reader["NguoiDaiDien"].ToString();
                    doan.SoNguoi = Convert.ToInt32(reader["SoNguoi"]);
                    doan.IDKhachHang = IDKhachHang;
                }

                reader.Close();
            }
            return doan;
        }

        public void ThemDoan(Doan doan) 
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                SqlCommand command = new SqlCommand("themdoan", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDDOAN", doan.IDDoan);
                command.Parameters.AddWithValue("@TENDOAN", doan.TenDoan);
                command.Parameters.AddWithValue("@NGUOIDAIDIEN", doan.NguoiDaiDien);
                command.Parameters.AddWithValue("@SONGUOI", doan.SoNguoi);
                command.Parameters.AddWithValue("@IDKhachHang", doan.IDKhachHang);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool IsIDDoanExists(string idDoan)
        {
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                string query = "SELECT COUNT(*) FROM Doan WHERE IDDoan = @IDdoan";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IDdoan", idDoan);

                conn.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        //------------------------------------------------PHUONGTIEN----------------------------------------------------
        public static DataTable getListPhuongTienDTO()
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEMPHUONGTIEN", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static DataTable getIDDTO(PhuongTien pt)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TIMPHUONGTIEN_ID", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@KEYWORD", pt.IDNhaXe);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static DataTable getListGioPhuongTienDTO(PhuongTien pt)
        {


            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TIMPHUONGTIEN", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@KEYWORD", pt.GioDen);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public static void delPhuongTienDTO(PhuongTien pt)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XOAPHUONGTIEN", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDNHAXE", pt.IDNhaXe);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();

        }

        public static void editPhuongTienDTO(PhuongTien pt)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("SUAPHUONGTIEN", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDNHAXE", pt.IDNhaXe);
            command.Parameters.AddWithValue("@TENNHAXE", pt.TenNhaXe);
            command.Parameters.AddWithValue("@SDT", pt.SDT);
            command.Parameters.AddWithValue("@GIODIEN", pt.GioDen);
            command.Parameters.AddWithValue("@GIA", pt.Gia);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static void addPhuongTienDTO(PhuongTien pt)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("THEMPHUONGTIEN", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDNHAXE", pt.IDNhaXe);
            command.Parameters.AddWithValue("@TENNHAXE", pt.TenNhaXe);
            command.Parameters.AddWithValue("@SDT", pt.SDT);
            command.Parameters.AddWithValue("@GIODIEN", pt.GioDen);
            command.Parameters.AddWithValue("@GIA", pt.Gia);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static string topPhuongTienDTO()
        {
            string user = null;
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TOPPHUONGTIEN", conn);
            command.CommandType = CommandType.StoredProcedure;


            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
            return user;
        }
        //----------------------------------------------------------------DICHVU---------------------------------------------------
        public static DataTable getListDichVuDTO()
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEMDICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static DataTable getIDDICHVUDTO(DichVu dv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TIMDICHVU_ID", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@KEYWORD", dv.IDDichVu);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static void editDichVuDTO(DichVu dv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("SUADICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDDICHVU", dv.IDDichVu);
            command.Parameters.AddWithValue("@TENDV", dv.TenDV);
            command.Parameters.AddWithValue("@GIA", dv.Gia);
            command.Parameters.AddWithValue("@SL", dv.SL);
            command.Parameters.AddWithValue("@KM", dv.KM);
            command.Parameters.AddWithValue("@TINHTRANG", dv.TinhTrang);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static DataTable getListTenDichVuDTO(DichVu dv)
        {


            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TIMDICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@KEYWORD", dv.TenDV);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public static string topDichVuDTO()
        {
            string user = null;
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TOPDICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;


            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
            return user;
        }

        public static void addDichVuDTO(DichVu dv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("THEMDICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDDICHVU", dv.IDDichVu);
            command.Parameters.AddWithValue("@TENDV", dv.TenDV);
            command.Parameters.AddWithValue("@GIA", dv.Gia);
            command.Parameters.AddWithValue("@SL", dv.SL);
            command.Parameters.AddWithValue("@KM", dv.KM);
            command.Parameters.AddWithValue("@TINHTRANG", dv.TinhTrang);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static void delDichVuDTO(DichVu dv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XOADICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDDICHVU", dv.IDDichVu);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();

        }

        //------------------------------------------------------------------------------TOURDULICH----------------------------------------------------------------

        public static DataTable getListTourDuLichDTO()
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEMTOURDULICH", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static DataTable getIDTourDuLichDTO(TourDuLich tdl)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TIMTOURDULICH_ID", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@KEYWORD", tdl.IDTour);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static void editTourDuLichDTO(TourDuLich tdl)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("SUATOURDULICH", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDTOUR", tdl.IDTour);
            command.Parameters.AddWithValue("@NCC", tdl.NCC);
            command.Parameters.AddWithValue("@NOIDUNG", tdl.NoiDung);
            command.Parameters.AddWithValue("@GIA", tdl.Gia);

            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static DataTable getListTenTourDuLichDTO(TourDuLich tdl)
        {


            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TIMTOURDULICH", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@KEYWORD", tdl.NoiDung);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        public static string topTourDuLichDTO()
        {
            string user = null;
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TOPTOURDULICH", conn);
            command.CommandType = CommandType.StoredProcedure;


            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
            return user;
        }

        public static void addTourDuLichDTO(TourDuLich tdl)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("THEMTOURDULICH", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDTOUR", tdl.IDTour);
            command.Parameters.AddWithValue("@NCC", tdl.NCC);
            command.Parameters.AddWithValue("@NOIDUNG", tdl.NoiDung);
            command.Parameters.AddWithValue("@GIA", tdl.Gia);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static void delTourDuLichDTO(TourDuLich tdl)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XOATOURDULICH", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDTOUR", tdl.IDTour);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();

        }

        public static ThongTinDatPhong TimDataTTPD(string idPhong)
        {
            ThongTinDatPhong resTTDP = null;

            // Thực hiện truy vấn database để lấy dữ liệu của ThongTinDatPhong
            // Sử dụng idPhong để tìm kiếm thông tin đặt phòng

            // Ví dụ:
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                conn.Open();
                SqlCommand command = new SqlCommand("TIM_THONGTINDATPHONG_1", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idPhong", idPhong);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    resTTDP = new ThongTinDatPhong();
                    resTTDP.IDKhachHang = reader["IDKhachHang"].ToString();
                    resTTDP.NgayCheckIn = Convert.ToDateTime(reader["NgayCheckIn"]);
                    resTTDP.NgayCheckOut = Convert.ToDateTime(reader["NgayCheckOut"]);
                    resTTDP.SoLuongNguoi = reader["SoLuongNguoi"].ToString();
                }

                reader.Close();
            }

            return resTTDP;
        }

        public static KhachHang TimDataKH_IDPhong(string idPhong)
        {
            KhachHang resTTKH = null;
            using (SqlConnection conn = SqlConnectData.Connect())
            {
                conn.Open();
                SqlCommand command = new SqlCommand("TIM_THONGTINKHACHHANG_1", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idPhong", idPhong);
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    resTTKH = new KhachHang();
                    resTTKH.IDKhachHang = reader["IDKhachHang"].ToString();
                    resTTKH.TenKH = reader["TenKH"].ToString();
                    resTTKH.CCCD = reader["CCCD"].ToString();
                    resTTKH.SDT = reader["SDT"].ToString();
                    resTTKH.Email = reader["Email"].ToString();
                    resTTKH.Fax = reader["Fax"].ToString();
         
                }

                reader.Close();
            }

            return resTTKH;
        }

        //        public void ThemDataDKDichVuTour(DangKyTour dkTour)
        //        {
        //            using (SqlConnection conn = SqlConnectData.Connect())
        //            {
        //                SqlCommand command = new SqlCommand("THEM_DANGKYDVTOUR", conn);
        //                command.CommandType = CommandType.StoredProcedure;
        //                //command.Parameters.AddWithValue("@IDKH", dkTour.IDKhachHang);
        //                command.Parameters.AddWithValue("@IDTour", dkTour.IDTour);
        //                command.Parameters.AddWithValue("@GIOXP", dkTour.GioXuatPhat);
        //                command.Parameters.AddWithValue("@SL", dkTour.SoNguoiDi);
        //;
        //                conn.Open();
        //                command.ExecuteNonQuery();
        //            }
        //        }


        //------------------------------------------DANGKYDICHVU-----------------------------------------------------------
        public static void addDangKyDichVuDTO(DangKyDichVu dkdv, DichVu dv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("THEM_DANGKYDVSP", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDKH", dkdv.IDKhachHang);
            command.Parameters.AddWithValue("@TENDV", dv.TenDV);
            command.Parameters.AddWithValue("@SL", dkdv.SL);
            command.Parameters.AddWithValue("@LICHSD", dkdv.LichSD);
            command.Parameters.AddWithValue("@GIODK", dkdv.GioDK);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static DataTable getListDKDVDTO(DangKyDichVu dkdv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEM_DANGKYDV", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDKH", dkdv.IDKhachHang);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }


        public static void delDKDVDTO(DangKyDichVu dkdv, DichVu dv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XOA_DANGKYDVSP", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TENDV", dv.TenDV);
            command.Parameters.AddWithValue("@IDKH", dkdv.IDKhachHang);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();

        }

        public static DataTable getTenDVDTO()
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TENDV", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static DataTable getTenSPDTO()
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TENSP", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public static DataTable getListDKDTO(DangKyDichVu dkdv)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEM_DANGKYSP", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDKH", dkdv.IDKhachHang);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        //---------------------------------DANGKYTOUR----------------------------------------------------

        public static void addDangKyTourDTO(DangKyTour dkt, TourDuLich tdl)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("THEM_DANGKYTOUR", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDKH", dkt.IDKhachHang);
            command.Parameters.AddWithValue("@ID", tdl.IDTour);
            command.Parameters.AddWithValue("@GIODK", dkt.GioDK);
            command.Parameters.AddWithValue("@GIOXUATPHAT", dkt.GioXuatPhat);
            command.Parameters.AddWithValue("@SONGUOIDI", dkt.SoNguoiDi);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static DataTable getListDKTourDTO(DangKyTour dkt)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEM_DANGKYTOUR", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDKH", dkt.IDKhachHang);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }


        public static void delDKTourDTO(DangKyTour dkt, TourDuLich tdl)
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XOA_DANGKYTOUR", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NCC", tdl.NCC);
            command.Parameters.AddWithValue("@IDKH", dkt.IDKhachHang);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            conn.Close();

        }

        public static DataTable getTenTourDTO()
        {
            //hàm connect tới CSDL
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("TENTOUR", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;

        }

        public ObservableCollection<Phong> LoadDataPhongFilter(string trangthai, string loai, string tinhtrang)
        {
            ObservableCollection<Phong> DSPhongFilter = new ObservableCollection<Phong>();

            using (SqlConnection connection = SqlConnectData.Connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("XemPhongFilter", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TrangThai", trangthai);
                command.Parameters.AddWithValue("@LoaiPhong", loai);
                command.Parameters.AddWithValue("@TinhTrang", tinhtrang);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Phong phong = new Phong();
                    phong.IDPhong = reader["IDPhong"].ToString();
                    phong.LoaiPhong = reader["IDLoai"].ToString();
                    phong.TrangThai = reader["TrangThai"].ToString();
                    phong.TinhTrang = reader["TinhTrang"].ToString();

                    DSPhongFilter.Add(phong);
                }

                reader.Close();
            }

            return DSPhongFilter;
        }

        //---------------------------------HoaDon----------------------------------------------------
        public void themHoaDon(HoaDon hoaDon)
        {
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();

            SqlCommand command = new SqlCommand("TAO_HOADON", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDHOADON", hoaDon.IDHoaDon);
            command.Parameters.AddWithValue("@NGAYLAP", hoaDon.NgayLap);
            command.Parameters.AddWithValue("@PTTT", hoaDon.PTTT);
            command.Parameters.AddWithValue("@TONGTIEN", hoaDon.TongTien);
            command.Parameters.AddWithValue("@IDNHANVIEN", hoaDon.IDNhanVien);
            command.Parameters.AddWithValue("@IDKHACHHANG", hoaDon.IDKhachHang);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            conn.Close();
        }

        public void themCTHDDatPhong(ChiTietHoaDonDatPhong cthdDatPhong)
        {
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();

            SqlCommand command = new SqlCommand("TAO_CTHDDATPHONG", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDHOADON", cthdDatPhong.IDHoaDon);
            command.Parameters.AddWithValue("@IDPHONG", cthdDatPhong.IDPhong);
            command.Parameters.AddWithValue("@TIENCOC", cthdDatPhong.TienCoc);
            command.Parameters.AddWithValue("@TIENSAUCHECKOUT", cthdDatPhong.TienSauCheckOut);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            conn.Close();
        }

        public void themCTHDKemTheo(ChiTietHoaDonKemTheo cthdKemTheo)
        {
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();

            SqlCommand command = new SqlCommand("TAO_CTHDKEMTHEO", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@STT", cthdKemTheo.STT);
            command.Parameters.AddWithValue("@IDHOADON", cthdKemTheo.IDHoaDon);
            command.Parameters.AddWithValue("@IDTOUR", cthdKemTheo.IDTour);
            command.Parameters.AddWithValue("@IDDICHVU", cthdKemTheo.IDDichVu);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            conn.Close();
        }

        public void ThemDVCTHDKemTheo(ChiTietHoaDonKemTheo cthdKemTheo)
        {
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();

            SqlCommand command = new SqlCommand("THEMDV_CTHDKEMTHEO", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@STT", cthdKemTheo.STT);
            command.Parameters.AddWithValue("@IDHOADON", cthdKemTheo.IDHoaDon);
            //command.Parameters.AddWithValue("@IDTOUR", cthdKemTheo.IDTour);
            command.Parameters.AddWithValue("@IDDICHVU", cthdKemTheo.IDDichVu);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            conn.Close();
        }

        public void ThemTOURCTHDKemTheo(ChiTietHoaDonKemTheo cthdKemTheo)
        {
            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();

            SqlCommand command = new SqlCommand("THEMTOUR_CTHDKEMTHEO", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@STT", cthdKemTheo.STT);
            command.Parameters.AddWithValue("@IDHOADON", cthdKemTheo.IDHoaDon);
            command.Parameters.AddWithValue("@IDTOUR", cthdKemTheo.IDTour);
            //command.Parameters.AddWithValue("@IDDICHVU", cthdKemTheo.IDDichVu);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            conn.Close();
        }

        public int GiaPhongCoID(string IDPhong)
        {
            int GiaPhong = new int();

            SqlConnection conn = SqlConnectData.Connect();
            conn.Open();

            SqlCommand command = new SqlCommand("GIA_PHONG", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDPHONG", IDPhong);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            GiaPhong = Convert.ToInt32(reader["GIA"]);

            reader.Close();

            conn.Close();

            return GiaPhong;
        }

        public int GiaDichVuCoID(string IDDichVu)
        {
            int GiaDichVu = new int();

            SqlConnection conn = SqlConnectData.Connect();
            conn.Open();

            SqlCommand command = new SqlCommand("GIA_DICHVU", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDDICHVU", IDDichVu);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            GiaDichVu = Convert.ToInt32(reader["Gia"]);

            reader.Close();

            conn.Close();

            return GiaDichVu;
        }

        public int GiaTourDuLichCoID(string IDTourDuLich)
        {
            int GiaTourDuLich = new int();

            SqlConnection conn = SqlConnectData.Connect();
            conn.Open();

            SqlCommand command = new SqlCommand("GIA_DICHVUTOUR", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@TOUR", IDTourDuLich);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            GiaTourDuLich = Convert.ToInt32(reader["Gia"]);

            reader.Close();

            conn.Close();

            return GiaTourDuLich;
        }

        public ObservableCollection<DangKyDichVu> LoadDataDKDV(string IDKhachHang)
        {
            ObservableCollection<DangKyDichVu> DSdkdv = new ObservableCollection<DangKyDichVu>();

            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEM_DANGKYDV", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDKH", IDKhachHang);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DangKyDichVu dkdv = new DangKyDichVu();
                dkdv.IDDichVu = reader["IDDichVu"].ToString();
                dkdv.IDKhachHang = IDKhachHang;
                dkdv.SL = Convert.ToInt32(reader["SL"]);
                dkdv.TongTien = Convert.ToInt32(reader["TongTien"]);

                DSdkdv.Add(dkdv);
            }

            reader.Close();
            conn.Close();

            return DSdkdv;
        }

        public ObservableCollection<DangKyDichVu> LoadDataDKSP(string IDKhachHang)
        {
            ObservableCollection<DangKyDichVu> DSdksp = new ObservableCollection<DangKyDichVu>();

            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEM_DANGKYSP", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDKH", IDKhachHang);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DangKyDichVu dksp = new DangKyDichVu();
                dksp.IDDichVu = reader["IDDichVu"].ToString();
                dksp.IDKhachHang = IDKhachHang;
                dksp.SL = Convert.ToInt32(reader["SL"]);
                dksp.TongTien = Convert.ToInt32(reader["TongTien"]);

                DSdksp.Add(dksp);
            }

            reader.Close();
            conn.Close();

            return DSdksp;
        }

        public ObservableCollection<DangKyTour> LoadDataDKTour(string IDKhachHang)
        {
            ObservableCollection<DangKyTour> DSdktour = new ObservableCollection<DangKyTour>();

            SqlConnection conn = SqlConnectData.Connect();

            conn.Open();
            SqlCommand command = new SqlCommand("XEM_DANGKYTOUR", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IDKH", IDKhachHang);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DangKyTour dktour = new DangKyTour();
                dktour.IDTour = reader["IDTour"].ToString();
                dktour.IDKhachHang = IDKhachHang;
                dktour.SoNguoiDi = Convert.ToInt32(reader["SoNguoiDi"]);
                dktour.TongTien = Convert.ToInt32(reader["TongTien"]);

                DSdktour.Add(dktour);
            }

            reader.Close();
            conn.Close();

            return DSdktour;
        }

        public string TenDichVu(string IDDichVu)
        {
            string ten;

            SqlConnection conn = SqlConnectData.Connect();
            conn.Open();

            string query = "SELECT TenDV FROM  DichVu WHERE IDDichVu = @IDDichVu";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@IDDichVu", IDDichVu);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            ten = reader["TenDV"].ToString();

            reader.Close();

            conn.Close();

            return ten;
        }

        public string TenTour(string IDTour)
        {
            string ten;

            SqlConnection conn = SqlConnectData.Connect();
            conn.Open();

            string query = "SELECT NCC FROM TourDuLich WHERE IDTour = @IDTour";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@IDTour", IDTour);

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            ten = reader["NCC"].ToString();

            reader.Close();

            conn.Close();

            return ten;
        }
    }
}
