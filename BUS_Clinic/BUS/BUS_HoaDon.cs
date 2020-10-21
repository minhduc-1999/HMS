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
    public class BUS_HoaDon : BaseBUS
    {
        public override void LoadLocalData()
        {
            DALManager.HoaDonDAL.LoadLocalData();
        }

        public void LoadNPPhieuKhamBenh(DTO_HoaDon hoaDon)
        {
            DALManager.HoaDonDAL.LoadNPPhieuKhamBenh(hoaDon);
        }

        public void AddHoaDon(DTO_HoaDon hd, DTO_PhieuKhamBenh pkb)
        {
            hd.Id = pkb.Id;
            DALManager.HoaDonDAL.AddHoaDon(hd);
            DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu = new DTO_CTBaoCaoDoanhThu(hd);
            BUSManager.CTBaoCaoDoanhThuBUS.AddCTBaoCaoDoanhThu(cTBaoCaoDoanhThu);
        }
        public double TinhTienThuoc(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            BUSManager.PhieuKhamBenhBUS.LoadNPDSCTPhieuKhamBenh(phieuKhamBenh);
            double tienThuoc = 0;
            foreach (DTO_CTPhieuKhamBenh item in phieuKhamBenh.DSCTPhieuKhamBenh)
            {
                tienThuoc += item.ThanhTien;
            }
            return tienThuoc;
        }

        public ObservableCollection<DTO_HoaDon> GetListHoaDon()
        {
            return DALManager.HoaDonDAL.GetListHoaDon();
        }

        public void XuatHoaDon(DTO_HoaDon hoaDon, DTO_PhieuKhamBenh phieuKhamBenh)
        {
            hoaDon.TienKham = BUSManager.ThamSoBUS.GetTienKham();
            hoaDon.TienThuoc = TinhTienThuoc(phieuKhamBenh);
            hoaDon.ThanhTien = hoaDon.TienKham + hoaDon.TienThuoc;
            AddHoaDon(hoaDon, phieuKhamBenh);
        }

        public DTO_HoaDon GetHoaDonById (string id)
        {
            DTO_HoaDon hoaDon = GetListHoaDon().Where(x => x.Id == id).FirstOrDefault();
            return hoaDon;
        }
    }
}
