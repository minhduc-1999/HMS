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
    public class DAL_ThamSo : BaseDAL
    {
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.ThamSo.Load();
        }
        public ObservableCollection<DTO_ThamSo> GetListThamSo()
        {
            return SQLServerDBContext.Instant.ThamSo.Local;
        }
        public void UpdateThamSo(int TienKham, int SoBNToiDa)
        {
            SQLServerDBContext.Instant.ThamSo.Local.Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault().GiaTri = SoBNToiDa;
            SQLServerDBContext.Instant.ThamSo.Local.Where(x => x.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri = TienKham;
        }
    }
}
