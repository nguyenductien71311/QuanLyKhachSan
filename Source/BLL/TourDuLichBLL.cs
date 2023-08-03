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
    public class TourDuLichBLL
    {
        public static DataTable getListTourDuLich()
        {

            return TourDuLichAccess.getListTourDuLich();
        }

        public static DataTable getIDTourDuLich(TourDuLich tdl)
        {
            return TourDuLichAccess.getIDTourDuLich(tdl);
        }

        public static string editTourDuLich(TourDuLich tdl)
        {

            if (tdl.NCC == "" || tdl.NoiDung == "")
            {
                return "Trống";
            }
            if (tdl.Gia < 100000)
            {
                return "Giá tiền";
            }
            TourDuLichAccess.editTourDuLich(tdl);
            return "Thành công";

        }

        public static DataTable getListTenTourDuLich(TourDuLich tdl)
        {
            return TourDuLichAccess.getListTenTourDuLich(tdl);
        }

        public static string topTourDuLich()
        {
            return TourDuLichAccess.topTourDuLich();

        }

        public static string addTourDuLich(TourDuLich tdl)
        {


            if (tdl.NCC == "" || tdl.NoiDung == "")
            {
                return "Trống";
            }

            if (tdl.Gia < 100000)
            {
                return "Giá tiền";
            }
            TourDuLichAccess.addTourDuLich(tdl);

            return "Thành công";

        }

        public static void delTourDuLich(TourDuLich tdl)
        {
            TourDuLichAccess.delTourDuLich(tdl);
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

        public static DataTable getTenTour()
        {
            return TourDuLichAccess.getTenTour();
        }
    }
}
