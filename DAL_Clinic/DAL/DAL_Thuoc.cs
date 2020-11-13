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
    public class DAL_Thuoc: BaseDAL
    {
        public DAL_Thuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            var entry = SQLServerDBContext.Instant.Entry(thuoc);
            entry.Collection(c => c.DS_CTPhieuNhapThuoc).Load();
        }
        public void LoadNPDonVi(DTO_Thuoc thuoc)
        {
            var entry = SQLServerDBContext.Instant.Entry(thuoc);
            entry.Reference(c => c.DonVi).Load();
        }
        public void AddThuoc(DTO_Thuoc thuoc)
        {
            SQLServerDBContext.Instant.Thuoc.Local.Add(thuoc);
        }
        public override void LoadLocalData()
        {
           // SQLServerDBContext.Instant.Thuoc.Load();
        }
        public ObservableCollection<DTO_Thuoc> GetListThuoc()
        {
            return SQLServerDBContext.Instant.Thuoc.Local;
        }
    }
}
