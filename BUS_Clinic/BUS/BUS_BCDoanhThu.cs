using DAL_Clinic.DAL;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BUS_Clinic.BUS
{
    public class BUS_BCDoanhThu : BaseBUS
    {
        public BUS_BCDoanhThu()
        {

        }
        public void AddBCDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            ObservableCollection<DTO_BCDoanhThu> ListBCDT = GetListBCDoanhThu();
            foreach (DTO_BCDoanhThu item in ListBCDT)
            {
                if (bCDoanhThu.Thang == item.Thang &&
                    bCDoanhThu.Nam == item.Nam)
                {
                    return;
                }
            }
            DALManager.BCDoanhThuDAL.AddBCDoanhThu(bCDoanhThu);
        }
        public DTO_BCDoanhThu GetBCDoanhThu(int month, int year)
        {
            var isExisted = DALManager.BCDoanhThuDAL.IsExisted(month, year);
            //if not exists -> calculate
            if(!isExisted)
            {
                List<DTO_CTBaoCaoDoanhThu> listCT = new List<DTO_CTBaoCaoDoanhThu>();
                
                var listHD = BUSManager.HoaDonBUS.GetListByMonth(month, year);
                var hdGroup = listHD.GroupBy(hd => hd.NgayLap.Day).OrderBy(g => g.Key);
                foreach (var gr in hdGroup)
                {
                    int soBN = gr.Count();
                    double doanhThu = 0;
                    foreach (var hd in gr)
                    {
                        doanhThu += hd.ThanhTien;
                    }
                    DTO_CTBaoCaoDoanhThu temp = new DTO_CTBaoCaoDoanhThu()
                    {
                        Ngay = gr.Key,
                        Thang = month,
                        Nam = year,
                        SoBenhNhan = soBN,
                        DoanhThu = doanhThu
                    };
                    listCT.Add(temp);
                }
                DTO_BCDoanhThu newBC = new DTO_BCDoanhThu()
                {
                    Nam = year,
                    Thang = month,
                    DS_CTBaoCaoDoanhThu = listCT,
                    TongBenhNhan = 0,
                    TongDoanhThu = 0
                };
                DALManager.BCDoanhThuDAL.AddBCDoanhThu(newBC);
            }
            else
            {
                if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                {
                    var listCTBCDT = BUSManager.CTBaoCaoDoanhThuBUS.GetListByMonth(month, year);               
                    var lastCT = listCTBCDT.OrderBy(ct => ct.Ngay).LastOrDefault();
                    var listHD = BUSManager.HoaDonBUS.GetListByMonth(month, year);
                    int lastDay;
                    if (lastCT == null)
                        lastDay = 0;
                    else
                        lastDay = lastCT.Ngay;
                    var grHD = listHD.Where(hd => hd.NgayLap.Day >= lastDay)
                        .GroupBy(hd => hd.NgayLap.Day);
                    foreach (var gr in grHD)
                    {
                        int soBN = gr.Count();
                        double doanhThu = 0;
                        foreach (var hd in gr)
                        {
                            doanhThu += hd.ThanhTien;
                        }
                        if (gr.Key != lastDay)
                        {
                            DTO_CTBaoCaoDoanhThu temp = new DTO_CTBaoCaoDoanhThu()
                            {
                                Ngay = gr.Key,
                                Thang = month,
                                Nam = year,
                                SoBenhNhan = soBN,
                                DoanhThu = doanhThu
                            };
                            DALManager.CTBaoCaoDoanhThuDAL.AddCTBaoCaoDoanhThu(temp);
                        }
                        else
                        {
                            lastCT.SoBenhNhan = soBN;
                            lastCT.DoanhThu = doanhThu;
                            DALManager.CTBaoCaoDoanhThuDAL.UpdateCTBaoCaoDoanhThu(lastCT);
                        }
                    }
                }
            }
            var result = DALManager.BCDoanhThuDAL.GetBCDoanhThu(month, year);
            DALManager.BCDoanhThuDAL.LoadNPCTBaoCaoDoanhThu(result);
            return result;
        }
        public void LoadNPCTBaoCaoDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            DALManager.BCDoanhThuDAL.LoadNPCTBaoCaoDoanhThu(bCDoanhThu);
        }
        public ObservableCollection<DTO_BCDoanhThu> GetListBCDoanhThu()
        {
            return DALManager.BCDoanhThuDAL.GetListBCDoanhThu();
        }
        public void LapBaoCao(int month, int year)
        {

        }
    }
}
