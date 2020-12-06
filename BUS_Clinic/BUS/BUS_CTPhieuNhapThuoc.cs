using DAL_Clinic.DAL;
using DTO_Clinic.Form;
using DTO_Clinic.Component;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_CTPhieuNhapThuoc : BaseBUS
    {
        public BUS_CTPhieuNhapThuoc()
        {

        }
        public void LoadNP_Thuoc(DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc)
        {
            DALManager.CTPhieuNhapThuocDAL.LoadNP_Thuoc(cTPhieuNhapThuoc);
        }
        public void LoadNP_PhieuNhapThuoc(DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc)
        {
            DALManager.CTPhieuNhapThuocDAL.LoadNP_PhieuNhapThuoc(cTPhieuNhapThuoc);
        }

        public async Task<ObservableCollection<DTO_CTPhieuNhapThuoc>> GetListCTPNTAsync()
        {
            return await DALManager.CTPhieuNhapThuocDAL.GetListCTPNTAsync();
        }

        public async Task AddCTPhieuNhapThuocAsync(ObservableCollection<DTO_Thuoc> listThuoc, DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            string tempID = await DALManager.PhieuNhapThuocDAL.AddPhieuNhapThuocAsync(phieuNhapThuoc);

            if (tempID == null)
                return;

            foreach (DTO_Thuoc item in listThuoc)
            {
                DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc;
                if (!BUSManager.ThuocBUS.IsThuocDaTonTai(item))
                {
                    string thuocID = await BUSManager.ThuocBUS.AddThuocAsync(item);

                    cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(tempID, thuocID, item.SoLuong, item.DonGia);
                }
                else
                {
                    cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(tempID, item.MaThuoc, item.SoLuong, item.DonGia);
                }

                DALManager.CTPhieuNhapThuocDAL.AddCTPhieuNhapThuoc(cTPhieuNhapThuoc);
            }
        }
    }
}
