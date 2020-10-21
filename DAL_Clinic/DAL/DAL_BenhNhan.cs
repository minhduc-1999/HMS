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
    public class DAL_BenhNhan:BaseDAL
    {
        public DAL_BenhNhan()
        {

        }
        public void AddBenhNhan(DTO_BenhNhan bn)
        {
            SQLServerDBContext.Instant.BenhNhan.Local.Add(bn);
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.BenhNhan.Load();
        }
        public ObservableCollection<DTO_BenhNhan> GetListBN()
        {
            return SQLServerDBContext.Instant.BenhNhan.Local;
        }
    }
}
