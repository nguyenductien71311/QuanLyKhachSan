using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Collections.ObjectModel;

namespace BLL
{
    public class DichVuBLL
    {
        public static DataTable getListDichVu()
        {

            return DichVuAccess.getListDichVu();
        }

        public static DataTable getIDDichVu(DichVu dv)
        {
            return DichVuAccess.getIDDichVu(dv);
        }

        public static string editDichVu(DichVu dv)
        {

            if (dv.Gia < 100000)
            {
                return "Sai giá";
            }
            else if (dv.SL < 100)
            {
                return "Sai số lượng";
            }
            else if (dv.KM < 0)
            {
                return "Sai khuyến mãi";
            }
            else if (dv.TenDV == "")
            {
                return "Trống";
            }
            DichVuAccess.editDichVu(dv);
            return "Thành công";

        }

        public static DataTable getListTenDichVu(DichVu dv)
        {
            return DichVuAccess.getListTenDichVu(dv);
        }

        public static string topDichVu()
        {
            return DichVuAccess.topDichVu();

        }

        public static string addDichVu(DichVu dv)
        {
            if (dv.Gia < 10000)
            {
                return "Sai giá";
            }
            else if (dv.SL < 100)
            {
                return "Sai số lượng";
            }
            else if (dv.KM < 0 || dv.KM > 50)
            {
                return "Sai khuyến mãi";
            }
            else if (dv.TenDV == "")
            {
                return "Trống";
            }
            DichVuAccess.addDichVu(dv);

            return "Thành công";

        }

        public static void delDichVu(DichVu dv)
        {
            DichVuAccess.delDichVu(dv);
            /*if(info == "Xóa thành công")
            {
                return "Success";
            } 
            
            if(info == "ID NHÀ XE KHÔNG TỒN TẠI")
            {
                return "Fail";
            }    
            
            return "Fail";*/

        }

        public static DataTable get_TenDV()
        {
            return DichVuAccess.getTenDV();
        }

        public static DataTable get_TenSP()
        {
            return DichVuAccess.getTenSP();
        }
    }
}
