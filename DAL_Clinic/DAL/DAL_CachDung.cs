using DTO_Clinic.Component;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace DAL_Clinic.DAL
{
    public class DAL_CachDung: BaseDAL
    {
        public DAL_CachDung()
        {

        }
        public void AddCachDung(DTO_CachDung cd)
        {
        }
        //public void DelCachDung(DTO_CachDung cd)
        //{
        //    SQLServerDBContext.Instant.CachDung.Local.Remove(cd);
        //}
    
        public ObservableCollection<DTO_CachDung> GetListCD()
        {
            return null;
        }
    }
}
