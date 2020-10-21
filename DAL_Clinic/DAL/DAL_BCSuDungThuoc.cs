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
    public class DAL_BCSuDungThuoc : BaseDAL
    {
        public DAL_BCSuDungThuoc()
        {

        }
        public void AddBCSuDungThuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            SQLServerDBContext.Instant.BaoCaoSuDungThuoc.Local.Add(bCSudungThuoc);
        }
        public ObservableCollection<DTO_BCSudungThuoc> GetListBCSuDungThuoc()
        {
            return SQLServerDBContext.Instant.BaoCaoSuDungThuoc.Local;
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.BaoCaoSuDungThuoc.Load();
        }
    }
}
