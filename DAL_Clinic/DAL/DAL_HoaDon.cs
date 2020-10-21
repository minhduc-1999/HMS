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
    public class DAL_HoaDon : BaseDAL
    {
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.HoaDon.Load();
        }
        public void AddHoaDon(DTO_HoaDon hd)
        {
            SQLServerDBContext.Instant.HoaDon.Local.Add(hd);
        }

        public void LoadNPPhieuKhamBenh(DTO_HoaDon hoaDon)
        {
            var entry = SQLServerDBContext.Instant.Entry(hoaDon);
            entry.Reference(c => c.PhieuKhamBenh).Load();
        }

        public ObservableCollection<DTO_HoaDon> GetListHoaDon()
        {
            return SQLServerDBContext.Instant.HoaDon.Local;
        }
    }
}
