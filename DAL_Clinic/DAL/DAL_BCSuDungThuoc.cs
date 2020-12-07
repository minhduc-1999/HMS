using DTO_Clinic;
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
        public async Task<ObservableCollection<DTO_BCSudungThuoc>> GetListBCSuDungThuocAsync()
        {
            ObservableCollection<DTO_BCSudungThuoc> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    await context.BaoCaoSuDungThuoc.LoadAsync();
                    res = new ObservableCollection<DTO_BCSudungThuoc>(context.BaoCaoSuDungThuoc.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }
      
    }
}
