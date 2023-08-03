using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class DichVuAccess : DatabaseAccess
    {
        public static DataTable getListDichVu()
        {
            return getListDichVuDTO();
        }

        public static DataTable getIDDichVu(DichVu dv)
        {
            return getIDDICHVUDTO(dv);
        }

        public static void editDichVu(DichVu dv)
        {
            editDichVuDTO(dv);

        }

        public static DataTable getListTenDichVu(DichVu dv)
        {
            return getListTenDichVuDTO(dv);
        }

        public static string topDichVu()
        {
            return topDichVuDTO();

        }

        public static void addDichVu(DichVu dv)
        {
            addDichVuDTO(dv);

        }

        public static void delDichVu(DichVu dv)
        {
            delDichVuDTO(dv);

        }

        public static DataTable getTenDV()
        {
            return getTenDVDTO();
        }

        public static DataTable getTenSP()
        {
            return getTenSPDTO();
        }
    }
}
