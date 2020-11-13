using DTO_Clinic;
using DTO_Clinic.Component;
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
        }
        //public void DelDonVi(DTO_DonVi dv)
        //{
        //    //dv.IsDeleted = true;
        //    SQLServerDBContext.Instant.DonVi.Local.Remove(dv);
        //}
        
        public ObservableCollection<DTO_DonVi> GetListDV()
        {
            return null;
        }
    }
}
