using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
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
        public async Task AddPhieuKhamChuyenKhoaAsync(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            await DALManager.PKChuyenKhoaDAL.AddPhieuKhamChuyenKhoaAsync(pKChuyenKhoa);
        }
        public async Task<ObservableCollection<DTO_PKChuyenKhoa>> GetListPKCKAsync()
        {
            return await DALManager.PKChuyenKhoaDAL.GetListPKCKAsync();
        }
    }
}
