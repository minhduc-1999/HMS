using DAL_Clinic.DAL;
using DTO_Clinic.Component;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BUS_Clinic.BUS
{
    public class BUS_DonVi : BaseBUS
    {
        public BUS_DonVi()
        {

        }
        public bool AddDonVi(DTO_DonVi donVi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();

            if (donvis.Any(d => d.TenDonVi.Equals(donVi.TenDonVi, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            DALManager.DonViDAL.AddDonVi(donVi);
            return true;
        }
        public bool UpdateDonVi(DTO_DonVi donVi, string tenDonViMoi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();

            if (donVi.TenDonVi == tenDonViMoi || donvis.Any(d => d.TenDonVi.Equals(tenDonViMoi, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            donVi.TenDonVi = tenDonViMoi;
            return true;
        }
        //public bool DelDonVi(DTO_DonVi donVi)
        //{
        //    ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();
        //    if (donVi != null)
        //    {
        //        if (donvis.Any(d => d.TenDonVi.Equals(donVi.TenDonVi, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            DALManager.DonViDAL.DelDonVi(donVi);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public DTO_DonVi GetDonViById(string maDonVi)
        {
            ObservableCollection<DTO_DonVi> donvis = DALManager.DonViDAL.GetListDV();

            var dv = donvis.Where(c => c.MaDonVi == maDonVi).FirstOrDefault();
            
            return dv;
        }
    
        public ObservableCollection<DTO_DonVi> GetListDV()
        {
            return DALManager.DonViDAL.GetListDV();
        }
        public int DemSoDonVi()
        {
            int re = DALManager.DonViDAL.GetListDV().Count;
            return re;
        }
    }
}
