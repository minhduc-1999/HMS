using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_DonVi: BaseDAL
    {
        public DAL_DonVi()
        {

        }
        public void AddDonVi(DTO_DonVi dv)
        {
            SQLServerDBContext.Instant.DonVi.Local.Add(dv);
        }
        //public void DelDonVi(DTO_DonVi dv)
        //{
        //    //dv.IsDeleted = true;
        //    SQLServerDBContext.Instant.DonVi.Local.Remove(dv);
        //}
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.DonVi.Load();
        }
        public ObservableCollection<DTO_DonVi> GetListDV()
        {
            return SQLServerDBContext.Instant.DonVi.Local;
        }
    }
}
