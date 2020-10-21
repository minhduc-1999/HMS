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

    public class DAL_BCDoanhThu : BaseDAL
    {
        public DAL_BCDoanhThu()
        {

        }
        public void AddBCDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            SQLServerDBContext.Instant.BaoCaoDoanhThu.Local.Add(bCDoanhThu);
        }
        public void LoadNPCTBaoCaoDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            var entry = SQLServerDBContext.Instant.Entry(bCDoanhThu);
            entry.Collection(c => c.DS_CTBaoCaoDoanhThu).Load();
        }
        public ObservableCollection<DTO_BCDoanhThu> GetListBCDoanhThu()
        {
            return SQLServerDBContext.Instant.BaoCaoDoanhThu.Local;
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.BaoCaoDoanhThu.Load();
        }
    }
}
