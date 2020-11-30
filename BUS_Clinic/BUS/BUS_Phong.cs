using DAL_Clinic.DAL;
using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_Phong : BaseBUS
    {
        public BUS_Phong()
        {

        }
        public BUS_Phong(DAL_Phong dAL_Phong) : base(dAL_Phong)
        {

        }
        public async Task<ObservableCollection<DTO_Phong>> GetListPhongAsync()
        {
            return await DALManager.PhongDAL.GetListPhongAsync();
        }
        public async Task<DTO_Phong> GetPhongByID(string strMaPhong)
        {
            return await DALManager.PhongDAL.GetPhongById(strMaPhong);
        }
    }
}
