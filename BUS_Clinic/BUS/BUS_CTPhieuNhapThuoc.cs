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

        public async Task AddCTPhieuNhapThuocAsync(ObservableCollection<DTO_Thuoc> listThuoc, DTO_PhieuNhapThuoc phieuNhapThuoc, ObservableCollection<DTO_PhieuNhapThuoc> listPNT, ObservableCollection<DTO_CTPhieuNhapThuoc> listCTPNT)
        {
            string tempID = await BUSManager.PhieuNhapThuocBUS.AddPhieuNhapThuocAsync(phieuNhapThuoc);

            if (tempID == null)
                return;

            phieuNhapThuoc.MaPNT = tempID;

            foreach (DTO_Thuoc item in listThuoc)
            {
                DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc;
                if (!BUSManager.ThuocBUS.IsThuocDaTonTai(item))
                {
                    item.MaThuoc = await BUSManager.ThuocBUS.AddThuocAsync(item);

                    cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(tempID, item.MaThuoc, item.SoLuong, item.DonGia);
                }
                else
                {
                    cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(tempID, item.MaThuoc, item.SoLuong, item.DonGia);
                }
                DALManager.CTPhieuNhapThuocDAL.AddCTPhieuNhapThuoc(cTPhieuNhapThuoc);

                LoadNP_Thuoc(cTPhieuNhapThuoc);
                listCTPNT.Add(cTPhieuNhapThuoc);
            }


            BUSManager.PhieuNhapThuocBUS.UpdatePNT(listPNT, phieuNhapThuoc, listCTPNT);
        }
    }
}
