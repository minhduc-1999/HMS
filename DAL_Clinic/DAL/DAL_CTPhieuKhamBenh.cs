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
    public class DAL_CTPhieuKhamBenh : BaseDAL
    {
        public DAL_CTPhieuKhamBenh()
        {
        }
        public void AddCTPhieuKhamBenh(DTO_CTPhieuKhamBenh cTPhieuKhamBenh)
        {
            SQLServerDBContext.Instant.CTPhieuKhamBenh.Local.Add(cTPhieuKhamBenh);
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.CTPhieuKhamBenh.Load();
        }
        public void LoadNPThuoc(DTO_CTPhieuKhamBenh cTPhieuKhamBenh)
        {
            var entry = SQLServerDBContext.Instant.Entry(cTPhieuKhamBenh);
            entry.Reference(c => c.Thuoc).Load();
        }
        public void LoadNPCachDung(DTO_CTPhieuKhamBenh cTPhieuKhamBenh)
        {
            var entry = SQLServerDBContext.Instant.Entry(cTPhieuKhamBenh);
            entry.Reference(c => c.CachDung).Load();
        }
        public ObservableCollection<DTO_CTPhieuKhamBenh> GetListCTPKB()
        {
            return SQLServerDBContext.Instant.CTPhieuKhamBenh.Local;
        }
    }
}
