﻿using DTO_Clinic.Component;
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
