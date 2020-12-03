using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_ThamSo : BaseBUS
    {
        public void UpdateThamSo(int TienKham, int SoBNToiDa)
        {
            DALManager.ThamSoDAL.UpdateThamSo(TienKham, SoBNToiDa);
        }
        public int GetTienKham()
        {
            //return DALManager.ThamSoDAL.GetListAsync().Where(x => x.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri;
            return 1;
        }
        public int GetSoBNToiDa()
        {
            //return DALManager.ThamSoDAL.GetListAsync().Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault().GiaTri;
            return 1;
        }
        public DTO_ThamSo GetThamSoSoBNToiDa()
        {
            //return DALManager.ThamSoDAL.GetListAsync().Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault();
            return null;
        }
        public async Task<ObservableCollection<DTO_ThamSo>> GetListAsync()
        {
            try
            {
                var res = await DALManager.ThamSoDAL.GetListAsync();
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
