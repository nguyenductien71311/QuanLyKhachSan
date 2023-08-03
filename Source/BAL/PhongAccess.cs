using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTO;

namespace DAL
{
    public class PhongAccess : DatabaseAccess
    {
        public ObservableCollection<Phong> LoadPhongData()
        {
            ObservableCollection<Phong> DSPhong = new ObservableCollection<Phong>();
            DSPhong = LoadDataPhong();
            return DSPhong;
        }

        public void ThemPhong()
        {
            Phong phong = new Phong();
            ThemPhong(phong);
        }

        public ObservableCollection<Phong> TimPhong()
        {
            ObservableCollection<Phong> roomTypes = new ObservableCollection<Phong>();
            roomTypes = TimDataPhong();
            return roomTypes;
        }

        public void XoaPhong(string IDPhong)
        {
            XoaDataPhong(IDPhong);
        }

        public void SuaPhong(Phong phong)
        {
            SuaDataPhong(phong);
        }

        public ObservableCollection <Phong> LoadPhongTrongData() 
        {
            ObservableCollection<Phong> DSPhongTrong = new ObservableCollection<Phong>();
            DSPhongTrong = LoadDataPhongTrong();
            return DSPhongTrong;
        }

        public Phong TimPhongCoIDPhong(string IDPhong)
        {
            Phong phong = new Phong();
            phong = TimPhongCoID(IDPhong);
            return phong;
        }
        
    }
}
