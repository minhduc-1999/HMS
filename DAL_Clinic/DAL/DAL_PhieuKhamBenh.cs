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
    public class DAL_PhieuKhamBenh: BaseDAL
    {
        public DAL_PhieuKhamBenh()
        {
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.PhieuKhamBenh.Load();
        }
        public void AddPhieuKhamBenh(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            SQLServerDBContext.Instant.PhieuKhamBenh.Local.Add(phieuKhamBenh);
        }
        public void LoadNPBenh (DTO_PhieuKhamBenh phieuKhamBenh)
        {
            
            var entry = SQLServerDBContext.Instant.Entry(phieuKhamBenh);
            entry.Reference(c => c.Benh).Load();
        }
        public void LoadNPBenhNhan(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            var entry = SQLServerDBContext.Instant.Entry(phieuKhamBenh);
            entry.Reference(c => c.BenhNhan).Load();
        }
        public void LoadNPDSCTPhieuKhamBenh(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            var entry = SQLServerDBContext.Instant.Entry(phieuKhamBenh);
            entry.Collection(c => c.DSCTPhieuKhamBenh).Load();
        }
        public ObservableCollection<DTO_PhieuKhamBenh> GetListPKB()
        {
            return SQLServerDBContext.Instant.PhieuKhamBenh.Local;      
        }
        public void LoadNPDSCTPhieuKB(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            var entry = SQLServerDBContext.Instant.Entry(phieuKhamBenh);
            entry.Collection(c => c.DSCTPhieuKhamBenh).Load();
        }
    }
}
