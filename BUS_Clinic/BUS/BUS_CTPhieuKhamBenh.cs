using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_CTPhieuKhamBenh : BaseBUS
    {
        public BUS_CTPhieuKhamBenh()
        {

        }
        //public DTO_CTPhieuKhamBenh GetCTPhieuKhamBenh(int maCTPhieuKhamBenh)
        //{
        //    ObservableCollection<DTO_CTPhieuKhamBenh> ListCTPKB = GetListCTPKB();
        //    foreach (DTO_CTPhieuKhamBenh item in ListCTPKB)
        //    {
        //        if (item.Id == maCTPhieuKhamBenh)
        //        {
        //            return item;
        //        }
        //    }

        //    return null;
        //}
        public void AddCTPhieuKhamBenh(DTO_CTPhieuKhamBenh cTPhieuKhamBenh)
        {
            DALManager.CTPhieuKhamBenhDAL.AddCTPhieuKhamBenh(cTPhieuKhamBenh);
        }
        public void LoadNPThuoc(DTO_CTPhieuKhamBenh cTPhieuKhamBenh)
        {
            DALManager.CTPhieuKhamBenhDAL.LoadNPThuoc(cTPhieuKhamBenh);
        }
        public void LoadNPCachDung(DTO_CTPhieuKhamBenh cTPhieuKhamBenh)
        {
            DALManager.CTPhieuKhamBenhDAL.LoadNPCachDung(cTPhieuKhamBenh);
        }
        public override void LoadLocalData()
        {
            DALManager.CTPhieuKhamBenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_CTPhieuKhamBenh> GetListCTPKB()
        {
            return DALManager.CTPhieuKhamBenhDAL.GetListCTPKB();
        }
    }
}
