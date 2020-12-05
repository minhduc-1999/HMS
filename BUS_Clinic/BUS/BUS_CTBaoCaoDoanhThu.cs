using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_CTBaoCaoDoanhThu : BaseBUS
    {
        public BUS_CTBaoCaoDoanhThu()
        {

        }
        public void AddCTBaoCaoDoanhThu(DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu)
        {
            DALManager.CTBaoCaoDoanhThuDAL.AddCTBaoCaoDoanhThu(cTBaoCaoDoanhThu);
        }
        public void UpdateCTBCDoanhThu(DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu)
        {
            DALManager.CTBaoCaoDoanhThuDAL.UpdateCTBaoCaoDoanhThu(cTBaoCaoDoanhThu);
        }
        public List<DTO_CTBaoCaoDoanhThu> GetListByMonth(int month, int year)
        {
            return DALManager.CTBaoCaoDoanhThuDAL.GetListByMonth(month, year);
        }

    }
}
