using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_BenhNhan : BaseBUS
    {
        
        public BUS_BenhNhan()
        {

        }
        public BUS_BenhNhan(DAL_BenhNhan dAL_BenhNhan) : base(dAL_BenhNhan)
        {

        }
        public DTO_BenhNhan GetBenhNhanById(string maBenhNhan)
        {
            ObservableCollection<DTO_BenhNhan> ListBN = GetListBN();
            var result = ListBN.Where(c => c.Id == maBenhNhan).FirstOrDefault();
            return result;
        }
        public bool AddBenhNhan(DTO_BenhNhan bn)
        {
            if(IsValidInfo(bn.HoTen, bn.SoDienThoai))
            {
                DALManager.BenhNhanDAL.AddBenhNhan(bn);
                return true;
            }
            return false;
        }
        public ObservableCollection<DTO_BenhNhan> GetListBN()
        {
            return DALManager.BenhNhanDAL.GetListBN();
        }
        public int GetPatientAmount()
        {
            int re = DALManager.BenhNhanDAL.GetListBN().Count;
            return re;
        }
        public bool IsValidInfo(string ten, string sdt, string id = "")
        {
            var list = DALManager.BenhNhanDAL.GetListBN();
            var item = list.Where(x => x.HoTen == ten && x.SoDienThoai == sdt).FirstOrDefault();
            if (item != null)
                return item.Id == id;
            return true;
        }
        public bool UpdateInfoBN(DTO_BenhNhan bn, string ten, string diachi, bool gioiTinh, string sdt, DateTime ngaySinh)
        {
            if (IsValidInfo(ten, sdt, bn.Id))
            {
                bn.HoTen = ten;
                bn.DiaChi = diachi;
                bn.GioiTinh = gioiTinh;
                bn.NgaySinh = ngaySinh;
                bn.SoDienThoai = sdt;
                return true;
            }
            else
                return false;

        }
    }
}
