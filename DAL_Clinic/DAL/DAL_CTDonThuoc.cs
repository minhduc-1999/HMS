using DTO_Clinic.Form;
using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_CTDonThuoc : BaseDAL
    {
        public DAL_CTDonThuoc()
        {
        }
        public void AddCTDonThuoc(DTO_CTDonThuoc cTDonThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.CT_DonThuoc.Add(cTDonThuoc);
                context.SaveChanges();
            }
        }
        public bool LoadNPThuoc(DTO_CTDonThuoc ctDonThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CT_DonThuoc.Attach(ctDonThuoc);
                    var entry = context.Entry(ctDonThuoc);
                        entry.Reference(p => p.Thuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL CTDonThuoc] {e.Message}");
                return false;
            }
        }
        public bool LoadNPCachDung(DTO_CTDonThuoc ctDonThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CT_DonThuoc.Attach(ctDonThuoc);
                    var entry = context.Entry(ctDonThuoc);
                        entry.Reference(p => p.CachDung).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL CTDonThuoc] {e.Message}");
                return false;
            }
        }

        public bool LoadNPDonThuoc (DTO_CTDonThuoc ctDonThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CT_DonThuoc.Attach(ctDonThuoc);
                    var entry = context.Entry(ctDonThuoc);
                    if (!entry.Reference(p => p.DonThuoc).IsLoaded)
                        entry.Reference(p => p.DonThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL CTDonThuoc] {e.Message}");
                return false;
            }
        }


    }
}
