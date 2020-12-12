using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Clinic.Form;
using DTO_Clinic.Component;
using DAL_Clinic.DAL;
using System.Collections.ObjectModel;

namespace BUS_Clinic.BUS
{
    public class BUS_CTHDThuoc : BaseBUS
    {
        public BUS_CTHDThuoc()
        {

        }

        public bool LoadNP_HoaDon(DTO_CTHDThuoc cTHDThuoc)
        {
            return DALManager.CTHDThuocDAL.LoadNPHoaDon(cTHDThuoc);
        }

        public bool LoadNP_Thuoc(DTO_CTHDThuoc cTHDThuoc)
        {
            return DALManager.CTHDThuocDAL.LoadNPThuoc(cTHDThuoc);
        }

        public ObservableCollection<DTO_CTHDThuoc> GetListCTHDThuoc()
        {
            return DALManager.CTHDThuocDAL.GetListCTHDThuoc();
        }

        public void AddCTHDThuoc(DTO_CTHDThuoc cTHDThuoc)
        {
            DALManager.CTHDThuocDAL.AddCTHDThuoc(cTHDThuoc);
        }

        public bool CheckIfThuocNhapTrung(ObservableCollection<DTO_CTHDThuoc> list, DTO_Thuoc thuocSuDung)
        {
            if (list == null)
                return false;
            return list.Any(c => c.MaThuoc == thuocSuDung.MaThuoc);
        }
    }
}
