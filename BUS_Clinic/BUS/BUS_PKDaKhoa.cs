using DAL_Clinic.DAL;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace BUS_Clinic.BUS
{
    public class BUS_PKDaKhoa : BaseBUS
    {
        public void LoadNPBenh(DTO_PKDaKhoa pKDaKhoa)
        {
            DALManager.PKDaKhoaDAL.LoadNPBenh(pKDaKhoa);
        }
        public void LoadNPBenhNhan(DTO_PKDaKhoa pKDaKhoa)
        {
            DALManager.PKDaKhoaDAL.LoadNPBenhNhan(pKDaKhoa);
        }
        public async Task<string> AddPhieuKhamDaKhoaAsync(DTO_PKDaKhoa pKDaKhoa)
        {
            try
            {
                var res = await DALManager.PKDaKhoaDAL.AddPhieuKhamDaKhoaAsync(pKDaKhoa);
                if (res.Count == 2)
                {
                    var code = Convert.ToInt32(res[0]);
                    if (code == SUCCESS_CODE)
                        return res[1];
                }
                throw new Exception("Đã có lỗi xảy ra. Vui lòng thực hiện lại.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ObservableCollection<DTO_PKDaKhoa>> GetListPKDKAsync()
        {
            return await DALManager.PKDaKhoaDAL.GetListPKDKAsync();
        }
        public ObservableCollection<DTO_BenhNhan> GetListBNByDate(DateTime date)
        {
            //try
            //{
                var res = new ObservableCollection<DTO_BenhNhan>(DALManager.PKDaKhoaDAL.GetListBNByDate(date));
                return res;
            //}
            //catch(Exception e)
            //{
            //    throw e;
            //}

        }
        public int GetAmountByDate(DateTime dt)
        {
            return DALManager.PKDaKhoaDAL.GetAmountByDate(dt);
        }
    }
}
