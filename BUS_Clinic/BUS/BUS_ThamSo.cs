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
        public void UpdateThamSo(List<DTO_ThamSo> ts)
        {
            try
            {
                DALManager.ThamSoDAL.UpdateThamSo(ts);
            } catch 
            {
                throw new Exception("Có lỗi xảy ra. Vui lòng thử lại sau");
            }
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
