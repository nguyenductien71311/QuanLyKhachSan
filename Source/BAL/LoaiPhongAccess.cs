using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;

namespace DAL
{
    public class LoaiPhongAccess : DatabaseAccess
    {
        public ObservableCollection<LoaiPhong> LoadLoaiPhongData()
        {
            ObservableCollection<LoaiPhong> roomTypes = new ObservableCollection<LoaiPhong>();
            roomTypes = LoadDataLoaiPhong();
            return roomTypes;
        }

        public void ThemLoaiPhong()
        {
            LoaiPhong loaiPhong = new LoaiPhong();
            ThemLoaiPhong(loaiPhong);
        }

        public ObservableCollection<LoaiPhong> TimloaiPhong()
        {
            ObservableCollection<LoaiPhong> roomTypes = new ObservableCollection<LoaiPhong>();
            roomTypes = TimDataLoaiPhong();
            return roomTypes;
        }

        public void XoaLoaiPhong(string IDLoai)
        {
            XoaDataLoaiPhong(IDLoai);
        }

        public void SuaLoaiPhong(LoaiPhong loaiphong)
        {
            SuaDataLoaiPhong(loaiphong);
        }
    }
}
