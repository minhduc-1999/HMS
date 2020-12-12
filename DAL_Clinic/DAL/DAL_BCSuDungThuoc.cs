using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_BCSuDungThuoc : BaseDAL
    {
        public DAL_BCSuDungThuoc()
        {

        }
        public void AddBCSuDungThuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.BaoCaoSuDungThuoc.Add(bCSudungThuoc);
                context.SaveChanges();
            }
        }
        public ObservableCollection<DTO_BCSudungThuoc> GetListBCSuDungThuoc()
        {
            ObservableCollection<DTO_BCSudungThuoc> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.BaoCaoSuDungThuoc.Load();
                    res = new ObservableCollection<DTO_BCSudungThuoc>(context.BaoCaoSuDungThuoc.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public void CapNhatBCSDThuoc(string maThuoc, DateTime ngaySuDung, int soLuongDung)
        {
            using (var context = new SQLServerDBContext())
            {
                var res = context.BaoCaoSuDungThuoc.Where(t => (t.MaThuoc == maThuoc) && (t.Thang == ngaySuDung.Month) && (t.Nam == ngaySuDung.Year)).FirstOrDefault();

                if (res != null)
                {
                    res.SoLanDung++;
                    res.SoLuongDung += soLuongDung;
                }

                context.SaveChanges();
            }
        }

        public bool LoadNP_Thuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.BaoCaoSuDungThuoc.Attach(bCSudungThuoc);
                    var entry = context.Entry(bCSudungThuoc);
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
