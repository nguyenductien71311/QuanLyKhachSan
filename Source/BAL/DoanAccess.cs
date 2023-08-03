using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;


namespace DAL
{
    public class DoanAccess : DatabaseAccess
    {
        public Doan LoadDoanData(string IDKhachHang)
        {
            Doan doan = new Doan();
            doan = LoadDataDoan(IDKhachHang);
            return doan;
        }
        public void ThemDataDoan(Doan doan)
        {
            ThemDoan(doan);
        }

        public string CheckLogicThemDoan(Doan doan)
        {
            if (string.IsNullOrEmpty(doan.IDDoan))
            {
                return "Required_attriute";
            }

            if (string.IsNullOrEmpty(doan.TenDoan) || string.IsNullOrEmpty(doan.NguoiDaiDien) || doan.SoNguoi <= 0 || string.IsNullOrEmpty(doan.IDKhachHang))
            {
                return "Required_attriute";
            }

            return "Valid";
        }
    }
}
