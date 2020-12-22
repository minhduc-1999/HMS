using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Clinic.Form;

namespace DAL_Clinic.DAL
{
    public class DAL_CTHDThuoc : BaseDAL
    {
        public void AddCTHDThuoc(DTO_CTHDThuoc cTHDThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.CTHoaDdonThuoc.Add(cTHDThuoc);
                context.SaveChanges();
            }
        }

        public ObservableCollection<DTO_CTHDThuoc> GetListCTHDThuoc()
        {
            ObservableCollection<DTO_CTHDThuoc> res = null;

            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.CTHoaDdonThuoc.Load();
                    res = new ObservableCollection<DTO_CTHDThuoc>(context.CTHoaDdonThuoc.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR]" + e.Message);
                }
            }

            return res;
        }

        public bool LoadNPHoaDon(DTO_CTHDThuoc cTHDThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CTHoaDdonThuoc.Attach(cTHDThuoc);
                    var entry = context.Entry(cTHDThuoc);
                    if (!entry.Reference(p => p.HoaDon).IsLoaded)
                        entry.Reference(p => p.HoaDon).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL BENH] {e.Message}");
                return false;
            }
        }

        public bool LoadNPThuoc(DTO_CTHDThuoc cTHDThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CTHoaDdonThuoc.Attach(cTHDThuoc);
                    var entry = context.Entry(cTHDThuoc);
                    if (!entry.Reference(p => p.Thuoc).IsLoaded)
                        entry.Reference(p => p.Thuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL BENH] {e.Message}");
                return false;
            }
        }

    }
}
