using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
namespace BUS_Clinic.BUS
{
    public class BUS_CTDonThuoc : BaseBUS
    {
        public BUS_CTDonThuoc()
        {

        }
        public void LoadNPBenh(DTO_DonThuoc donThuoc)
        {
            DALManager.DonThuocDAL.LoadNPPKDaKhoa(donThuoc);
        }
        public void LoadNP_CTDonThuoc(DTO_DonThuoc donThuoc)
        {
            DALManager.DonThuocDAL.LoadNP_CTDonThuoc(donThuoc);
        }
    }
}
