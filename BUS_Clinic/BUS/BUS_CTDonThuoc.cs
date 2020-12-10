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
        public void LoadNPBenh(DTO_CTDonThuoc ctDonThuoc)
        {
            DALManager.CTDonThuocDAL.LoadNPDonThuoc(ctDonThuoc);
        }
        public void LoadNP_DonThuoc(DTO_CTDonThuoc ctDonThuoc)
        {
            DALManager.CTDonThuocDAL.LoadNPDonThuoc(ctDonThuoc);
        }
        public void LoadNPThuoc(DTO_CTDonThuoc ctDonThuoc)
        {
            DALManager.CTDonThuocDAL.LoadNPThuoc(ctDonThuoc);
        }
        public void LoadNPCachDung(DTO_CTDonThuoc ctDonThuoc)
        {
            DALManager.CTDonThuocDAL.LoadNPCachDung(ctDonThuoc);
        }
    }
}
