using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class PhuongTienAccess : DatabaseAccess
    {
        public static DataTable getListPhuongTien()
        {
            return getListPhuongTienDTO();
        }

        public static DataTable getListGioPhuongTien(PhuongTien pt)
        {
            return getListGioPhuongTienDTO(pt);
        }

        public static void delPhuongTien(PhuongTien pt)
        {
            delPhuongTienDTO(pt);

        }

        public static void editPhuongTien(PhuongTien pt)
        {
            editPhuongTienDTO(pt);

        }


        public static DataTable getID(PhuongTien pt)
        {
            return getIDDTO(pt);
        }

        public static void addPhuongTien(PhuongTien pt)
        {
            addPhuongTienDTO(pt);

        }

        public static string topPhuongTien()
        {
            return topPhuongTienDTO();

        }
    }
}
