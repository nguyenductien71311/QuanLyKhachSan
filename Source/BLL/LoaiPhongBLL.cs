using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using DTO;
using DAL;

namespace BLL
{
    public class LoaiPhongBLL
    {
        LoaiPhongAccess LoaiPhong = new LoaiPhongAccess();
        public ObservableCollection<LoaiPhong> LoadLoaiPhongData()
        {
            ObservableCollection<LoaiPhong> roomTypes = new ObservableCollection<LoaiPhong>();
            roomTypes = LoaiPhong.LoadDataLoaiPhong();
            return roomTypes;
        }

        public void ThemLoaiPhong(LoaiPhong loaiPhong)
        {
            LoaiPhong.ThemLoaiPhong(loaiPhong);
        }

        public string CheckLogicThemLoaiPhong(LoaiPhong loaiPhong)
        {
            if (string.IsNullOrEmpty(loaiPhong.IDLoai))
            {
                return "Required_attriute";
            }

            if (LoaiPhong.IsIDLoaiPhongExists(loaiPhong.IDLoai))
            {
                return "ID_Exist";
            }
            if (string.IsNullOrEmpty(loaiPhong.Ten) || loaiPhong.Gia <= 0 || loaiPhong.SoNguoi <= 0)
            {
                return "Required_attriute";
            }

            return "Valid";
        }

        public ObservableCollection<LoaiPhong> TimLoaiPhong(string keyword)
        {
            ObservableCollection<LoaiPhong> allLoaiPhong = LoaiPhong.LoadDataLoaiPhong();

            List<LoaiPhong> filteredList = allLoaiPhong.Where(lp => lp.Ten.Contains(keyword)).ToList();

            ObservableCollection<LoaiPhong> filteredLoaiPhong = new ObservableCollection<LoaiPhong>(filteredList);

            return filteredLoaiPhong;
        }

        public void XoaLoaiPhong(string IDLoai)
        {
            LoaiPhong.XoaDataLoaiPhong(IDLoai);
        }
        public void SuaLoaiPhong(LoaiPhong loaiPhong)
        {
            LoaiPhong.SuaDataLoaiPhong(loaiPhong);
        }
        public string CheckLogicSuaLoaiPhong(LoaiPhong loaiPhong)
        {
            if (loaiPhong.Gia <= 0 || loaiPhong.SoNguoi <= 0)
            {
                return "Invalid";
            }

            return "Valid";
        }
    }
}
