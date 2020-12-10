using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Person;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
namespace BUS_Clinic.BUS
{
    public class BUS_DonThuoc : BaseBUS
    {
        public BUS_DonThuoc()
        {

        }
        public void AddDonThuoc(DTO_DonThuoc donThuoc)
        {
            DALManager.DonThuocDAL.AddDonThuoc(donThuoc);
        }
      
        public void LoadNPPKDaKhoa(DTO_DonThuoc donThuoc)
        {
            DALManager.DonThuocDAL.LoadNPPKDaKhoa(donThuoc);
        }
        public void LoadNP_CTDonThuoc(DTO_DonThuoc donThuoc)
        {
            DALManager.DonThuocDAL.LoadNP_CTDonThuoc(donThuoc);
        }

    }
}
