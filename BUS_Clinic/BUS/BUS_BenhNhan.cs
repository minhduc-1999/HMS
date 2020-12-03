using DAL_Clinic.DAL;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
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
        public async Task<DTO_BenhNhan> GetBenhNhanByIdAsync(string maBenhNhan)
        {
            return await DALManager.BenhNhanDAL.GetBNByID(maBenhNhan);
        }
        public async Task<string> AddBenhNhanAsync(DTO_BenhNhan bn)
        {
            try
            {
                var res = await DALManager.BenhNhanDAL.AddBenhNhanAsync(bn);
                if (res.Count == 2)
                {
                    var code = Convert.ToInt32(res[0]);
                    if (code == SUCCESS_CODE)
                        return res[1];
                    var errorNumber = Convert.ToInt32(res[1]);
                    if (code == 1 && errorNumber == 2601)
                        throw new Exception("Số CMND này đã tồn tại. Vui lòng kiểm tra lại.");
                }               
                throw new Exception("Đã có lỗi xảy ra. Vui lòng thực hiện lại.");
            }
            catch (Exception e)
            {
                throw e;
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

        public DTO_PKDaKhoa GetPKDKMoiNhat(DTO_BenhNhan bn)
        {
            DTO_PKDaKhoa res = null;
            LoadNP_DSPKDK(bn);
            foreach (DTO_PKDaKhoa item in bn.DS_PKDaKhoa)
            {
                if (item != null)
                {
                    if (res != null)
                    {
                        if (res.NgayKham < item.NgayKham)
                        {
                            res = item;
                        }
                    }
                    else
                    {
                        res = item;
                    }
                }
            }
            return res;
        }
    }
}
