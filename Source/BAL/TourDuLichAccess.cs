using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace DAL
{
    public class TourDuLichAccess : DatabaseAccess
    {
        public static DataTable getListTourDuLich()
        {
            return getListTourDuLichDTO();
        }

        public static DataTable getIDTourDuLich(TourDuLich tdl)
        {
            return getIDTourDuLichDTO(tdl);
        }

        public static void editTourDuLich(TourDuLich tdl)
        {
            editTourDuLichDTO(tdl);

        }

        public static DataTable getListTenTourDuLich(TourDuLich tdl)
        {
            return getListTenTourDuLichDTO(tdl);
        }

        public static string topTourDuLich()
        {
            return topTourDuLichDTO();

        }

        public static void addTourDuLich(TourDuLich tdl)
        {
            addTourDuLichDTO(tdl);

        }

        public static void delTourDuLich(TourDuLich tdl)
        {
            delTourDuLichDTO(tdl);

        }

        public static DataTable getTenTour()
        {
            return getTenTourDTO();
        }
    }
}
