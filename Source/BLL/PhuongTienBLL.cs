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
    public class PhuongTienBLL
    {
        PhuongTienAccess ptt = new PhuongTienAccess();

        public static DataTable getListPhuongTien()
        {
            return PhuongTienAccess.getListPhuongTien();
        }

        public static DataTable getListGioPhuongTien(PhuongTien pt)
        {

            string gio = pt.GioDen.ToString();
            //nếu rỗng trả về table ban đầu
            if (gio == "")
            {
                return PhuongTienAccess.getListPhuongTien();
            }
            // nếu giờ không rỗng thì trả ra danh sách theo giờ cần tìm
            return PhuongTienAccess.getListGioPhuongTien(pt);
        }

        public static void delPhuongTien(PhuongTien pt)
        {
            PhuongTienAccess.delPhuongTien(pt);
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

        public static string editPhuongTien(PhuongTien pt)
        {
            int numberOfDigits = pt.SDT.ToString().Length;
            if (numberOfDigits != 10)
            {
                return "Sai SDT";
            }
            else if (pt.Gia < 100000)
            {
                return "Sai giá";
            }
            else if (pt.GioDen <= 0 || pt.GioDen > 23)
            {
                return "Sai giờ";
            }
            PhuongTienAccess.editPhuongTien(pt);

            return "Thành công";

        }

        public static DataTable getID(PhuongTien pt1)
        {
            // nếu giờ không rỗng thì trả ra danh sách theo giờ cần tìm
            return PhuongTienAccess.getID(pt1);
        }

        public static string addPhuongTien(PhuongTien pt)
        {
            int numberOfDigits = pt.SDT.ToString().Length;
            if (numberOfDigits != 10)
            {
                return "Sai SDT";
            }
            else if (pt.Gia < 100000)
            {
                return "Sai giá";
            }
            else if (pt.GioDen <= 0 || pt.GioDen > 23)
            {
                return "Sai giờ";
            }
            PhuongTienAccess.addPhuongTien(pt);

            return "Thành công";

        }

        public static string topPhuongTien()
        {

            return PhuongTienAccess.topPhuongTien();

        }
    }
}
