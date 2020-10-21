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
        public override void LoadLocalData()
        {
            DALManager.ThamSoDAL.LoadLocalData();
        }
        public void UpdateThamSo(int TienKham, int SoBNToiDa)
        {
            DALManager.ThamSoDAL.UpdateThamSo(TienKham, SoBNToiDa);
        }
        public int GetTienKham()
        {
            return DALManager.ThamSoDAL.GetListThamSo().Where(x => x.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri;
        }
        public int GetSoBNToiDa()
        {
            return DALManager.ThamSoDAL.GetListThamSo().Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault().GiaTri;
        }
        public DTO_ThamSo GetThamSoSoBNToiDa()
        {
            return DALManager.ThamSoDAL.GetListThamSo().Where(x => x.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault();
        }
    }
}
