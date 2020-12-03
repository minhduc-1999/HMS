using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
namespace BUS_Clinic.BUS
{
    public class BUS_PKChuyenKhoa : BaseBUS
    {
        public BUS_PKChuyenKhoa()
        {

        }
        public void LoadNPPKDaKhoa(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            DALManager.PKChuyenKhoaDAL.LoadNPPKDaKhoa(pKChuyenKhoa);
        }
        public void LoadNPYeuCau(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            DALManager.PKChuyenKhoaDAL.LoadNPYeuCau(pKChuyenKhoa);
        }
        public async Task<string> AddPhieuKhamChuyenKhoaAsync(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            try
            {
                var res = await DALManager.PKChuyenKhoaDAL.AddPhieuKhamChuyenKhoaAsync(pKChuyenKhoa);
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
        public ObservableCollection<DTO_BenhNhan> GetListBNByDate(DateTime date)
        {
            var res = new ObservableCollection<DTO_BenhNhan>(DALManager.PKChuyenKhoaDAL.GetListBNByDate(date));
            return res;
        }
        public async Task<ObservableCollection<DTO_PKChuyenKhoa>> GetListPKCKAsync()
        {
            return await DALManager.PKChuyenKhoaDAL.GetListPKCKAsync();
        }
    }
}
