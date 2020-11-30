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
    public class BUS_PKDaKhoa : BaseBUS
    {
        public BUS_PKDaKhoa()
        {

        }
        public void LoadNPBenh(DTO_PKDaKhoa pKDaKhoa)
        {
            DALManager.PKDaKhoaDAL.LoadNPBenh(pKDaKhoa);
        }
        public void LoadNPBenhNhan(DTO_PKDaKhoa pKDaKhoa)
        {
            DALManager.PKDaKhoaDAL.LoadNPBenhNhan(pKDaKhoa);
        }
        public async Task AddPhieuKhamDaKhoaAsync (DTO_PKDaKhoa pKDaKhoa)
        {
            await DALManager.PKDaKhoaDAL.AddPhieuKhamDaKhoaAsync(pKDaKhoa);
        }
        public async Task<ObservableCollection<DTO_PKDaKhoa>> GetListPKDKAsync()
        {
            return await DALManager.PKDaKhoaDAL.GetListPKDKAsync();
        }
    }
}
