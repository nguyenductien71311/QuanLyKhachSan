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
    public class DoanBLL
    {
        DoanAccess Doan = new DoanAccess();

        public Doan LoadDoanData(string IDKhachHang) 
        {
            Doan doan = new Doan();
            doan = Doan.LoadDoanData(IDKhachHang);
            return doan;
        }

        public void ThemDoan(Doan doan) 
        {
            Doan.ThemDataDoan(doan);
        }

        public string CheckLogicThemDoan(Doan doan)
        {
            if (string.IsNullOrEmpty(doan.IDDoan))
            {
                return "Required_attriute";
            }

            if (Doan.IsIDDoanExists(doan.IDDoan))
            {
                return "ID_Exist";
            }

            if (string.IsNullOrEmpty(doan.TenDoan) || string.IsNullOrEmpty(doan.NguoiDaiDien) || string.IsNullOrEmpty(doan.IDKhachHang) || doan.SoNguoi <= 0)
            {
                return "Required_attriute";
            }

            return "Valid";
        }
    }
}
