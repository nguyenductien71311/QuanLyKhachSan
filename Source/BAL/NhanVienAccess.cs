using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;

namespace DAL
{
    public class NhanVienAccess : DatabaseAccess
    {
        public ObservableCollection<NhanVien> LoadNhanVienData()
        {
            ObservableCollection<NhanVien> DSNhanVien = new ObservableCollection<NhanVien>();
            DSNhanVien = LoadDataNhanVien();
            return DSNhanVien;
        }

        public void ThemNhanVien()
        {
            NhanVien NhanVien = new NhanVien();
            ThemNV(NhanVien);
        }

        public ObservableCollection<NhanVien> TimNhanVien()
        {
            ObservableCollection<NhanVien> DSNhanVien = new ObservableCollection<NhanVien>();
            DSNhanVien = TimDataNhanVien();
            return DSNhanVien;
        }

        public void XoaNhanVien(string IDNhanVien)
        {
            XoaDataNhanVien(IDNhanVien);
        }

        public void SuaNhanVien(NhanVien nhanvien)
        {
            SuaDataNhanVien(nhanvien);
        }
    }
}
