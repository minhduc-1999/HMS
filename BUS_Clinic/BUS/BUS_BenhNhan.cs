using DAL_Clinic.DAL;
using DTO_Clinic.Person;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        public async Task<DTO_BenhNhan> GetBenhNhanByIdAsync(string maBenhNhan)
        {
            return await DALManager.BenhNhanDAL.GetBNByID(maBenhNhan);
        }
        public async Task AddBenhNhanAsync(DTO_BenhNhan bn, ObservableCollection<DTO_BenhNhan> listBN)
        {
            //if (!IsValidInfo(bn, listBN))
            //    return;
            var res = await DALManager.BenhNhanDAL.AddBenhNhanAsync(bn);
            if (res != null)
            {
                bn.MaBenhNhan = res;
                listBN.Add(bn);
            }
        }
        public async Task<ObservableCollection<DTO_BenhNhan>> GetListBNAsync()
        {
            return await DALManager.BenhNhanDAL.GetListBNAsync();
        }
        public bool IsValidInfo(DTO_BenhNhan bn, ObservableCollection<DTO_BenhNhan> list)
        {
            var item = list.Where(x => x.HoTen == bn.HoTen && x.SoDienThoai == bn.SoDienThoai && x.SoCMND == bn.SoCMND).FirstOrDefault();
            if (item != null)
                return false;
            return true;
        }
        public bool UpdateInfoBN(DTO_BenhNhan bn, string ten, string diachi, bool gioiTinh, string sdt, DateTime ngaySinh)
        {
            //TODO
            return true;

        }
        public bool LoadNP_DSPKDK(DTO_BenhNhan bn)
        {
            return DALManager.BenhNhanDAL.LoadNP_DSPKDK(bn);
        }
    }
}
