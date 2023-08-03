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
    public class PhongBLL
    {
        public PhongAccess Phong = new PhongAccess();
        public ObservableCollection<Phong> LoadDataPhong()
        {
            ObservableCollection<Phong> DSPhong = new ObservableCollection<Phong>();
            DSPhong = Phong.LoadDataPhong();
            return DSPhong;
        }

        public void ThemPhong(Phong phong)
        {
            Phong.ThemPhong(phong);
        }

        public string CheckLogicThemPhong(Phong phong)
        {
            if (string.IsNullOrEmpty(phong.IDPhong))
            {
                return "Required_attriute";
            }

            if (Phong.IsIDPhongExists(phong.IDPhong))
            {
                return "ID_Exist";
            }
            if (string.IsNullOrEmpty(phong.TrangThai) || string.IsNullOrEmpty(phong.LoaiPhong) || string.IsNullOrEmpty(phong.TinhTrang))
            {
                return "Required_attriute";
            }

            return "Valid";
        }

        public ObservableCollection<Phong> TimPhong(string keyword)
        {
            ObservableCollection<Phong> allPhong = Phong.LoadDataPhong();

            List<Phong> filteredList = allPhong.Where(p => p.IDPhong.Contains(keyword)).ToList();

            ObservableCollection<Phong> filteredLoaiPhong = new ObservableCollection<Phong>(filteredList);

            return filteredLoaiPhong;
        }

        public void XoaPhong(string IDPhong)
        {
            Phong.XoaDataPhong(IDPhong);
        }
        public void SuaPhong(Phong phong)
        {
            Phong.SuaDataPhong(phong);
        }

        public Phong TimPhongCoIDPhong(string IDPhong)
        {
            ObservableCollection<Phong> allPhong = Phong.LoadDataPhong();
            Phong phong = new Phong();

            phong = allPhong.Where(p => p.IDPhong.Contains(IDPhong)).First();
            
            return phong;
        }
        public ObservableCollection<Phong> LoadDataPhongTrong()
        {
            ObservableCollection<Phong> DSPhongTrong = new ObservableCollection<Phong>(); ;
            DSPhongTrong = Phong.LoadPhongTrongData();
            return DSPhongTrong;
        }

        public ObservableCollection<Phong> LoadDataPhongFilter(string trangthai, string loai, string tinhtrang)
        {
            ObservableCollection<Phong> DSPhongFilter = new ObservableCollection<Phong>();
            DSPhongFilter = Phong.LoadDataPhongFilter(trangthai, loai, tinhtrang);
            return DSPhongFilter;
        }

    }
}
