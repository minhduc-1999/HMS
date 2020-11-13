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
        private const string _idPrefix = "CD";
        public BUS_CachDung()
        {

        }
        public bool AddCachDung(DTO_CachDung cachDung)
        {
            ObservableCollection<DTO_CachDung> cachdungs = DALManager.CachDungDAL.GetListCD();

            if(cachdungs.Any(c => c.TenCachDung.Equals(cachDung.TenCachDung, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            cachDung.Id = AutoGenerateID();
            DALManager.CachDungDAL.AddCachDung(cachDung);
            return true;
            
        }
        public bool UpdateCachDung(DTO_CachDung cachDung, string tenCachDungMoi)
        {
            ObservableCollection<DTO_CachDung> cachdungs = DALManager.CachDungDAL.GetListCD();

            if(cachDung.TenCachDung == tenCachDungMoi || cachdungs.Any(c => c.TenCachDung.Equals(tenCachDungMoi, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            cachDung.TenCachDung = tenCachDungMoi;
            return true;
            
        }
        //public bool DelCachDung(DTO_CachDung cachDung)
        //{
        //    ObservableCollection<DTO_CachDung> cachdungs = DALManager.CachDungDAL.GetListCD();
        //    if (cachDung != null)
        //    {
        //        if (cachdungs.Any(c => c.TenCachDung.Equals(cachDung.TenCachDung, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            DALManager.CachDungDAL.DelCachDung(cachDung);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public override void LoadLocalData()
        {
            DALManager.CachDungDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_CachDung> GetListCD()
        {
            return DALManager.CachDungDAL.GetListCD();
        }
        public int DemSoCachDung()
        {
            int re = DALManager.CachDungDAL.GetListCD().Count;
            return re;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (DemSoCachDung() + 1).ToString("D5");
        }
    }
}
