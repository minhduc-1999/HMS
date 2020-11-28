using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_CachDung : BaseBUS
    {
        public BUS_CachDung()
        {

        }
        public async Task<DTO_CachDung> AddCachDungAsync(DTO_CachDung cachDung)
        {
            ObservableCollection<DTO_CachDung> cachDungs = await DALManager.CachDungDAL.GetListCDAsync();

            if (cachDungs.Any(b => b.TenCachDung.Equals(cachDung.TenCachDung, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }
            cachDung.MaCachDung = await DALManager.CachDungDAL.AddCachDungAsync(cachDung);
            return cachDung;

        }
        public bool UpdateCachDung(DTO_CachDung cachDung, string tenCachDungMoi)
        {
            return DALManager.CachDungDAL.UpdateCachDung(cachDung, tenCachDungMoi);
            
        }
     
        public async Task<ObservableCollection<DTO_CachDung>> GetListCDAsync()
        {
            return await DALManager.CachDungDAL.GetListCDAsync();
        }
    
    }
}
