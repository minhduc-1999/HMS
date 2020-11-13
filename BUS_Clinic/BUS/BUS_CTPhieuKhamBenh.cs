using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
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
        //public DTO_CTDonThuoc GetCTPhieuKhamBenh(int maCTPhieuKhamBenh)
        //{
        //    ObservableCollection<DTO_CTDonThuoc> ListCTPKB = GetListCTPKB();
        //    foreach (DTO_CTDonThuoc item in ListCTPKB)
        //    {
        //        if (item.Id == maCTPhieuKhamBenh)
        //        {
        //            return item;
        //        }
        //    }

        //    return null;
        //}
        public void AddCTPhieuKhamBenh(DTO_CTDonThuoc cTPhieuKhamBenh)
        {
           // DALManager.CTPhieuKhamBenhDAL.AddCTPhieuKhamBenh(cTPhieuKhamBenh);
        }
        public void LoadNPThuoc(DTO_CTDonThuoc cTPhieuKhamBenh)
        {
            //DALManager.CTPhieuKhamBenhDAL.LoadNPThuoc(cTPhieuKhamBenh);
        }
        public void LoadNPCachDung(DTO_CTDonThuoc cTPhieuKhamBenh)
        {
           // DALManager.CTPhieuKhamBenhDAL.LoadNPCachDung(cTPhieuKhamBenh);
        }
        public override void LoadLocalData()
        {
           // DALManager.CTPhieuKhamBenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_CTDonThuoc> GetListCTPKB()
        {
            return null;
        }
    }
}
