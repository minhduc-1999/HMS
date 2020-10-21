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
    public class DAL_CachDung: BaseDAL
    {
        public DAL_CachDung()
        {

        }
        public void AddCachDung(DTO_CachDung cd)
        {
            SQLServerDBContext.Instant.CachDung.Local.Add(cd);
        }
        //public void DelCachDung(DTO_CachDung cd)
        //{
        //    SQLServerDBContext.Instant.CachDung.Local.Remove(cd);
        //}
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.CachDung.Load();
        }
        public ObservableCollection<DTO_CachDung> GetListCD()
        {
            return SQLServerDBContext.Instant.CachDung.Local;
        }
    }
}
