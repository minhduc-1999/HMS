using BUS_Clinic.BUS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_Clinic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoadLocalData();
        }
        private void LoadLocalData()
        {
            BUSManager.BCDoanhThuBUS.LoadLocalData();
            BUSManager.BCSuDungThuocBUS.LoadLocalData();
            BUSManager.BenhBUS.LoadLocalData();
            BUSManager.BenhNhanBUS.LoadLocalData();
            BUSManager.CachDungBUS.LoadLocalData();
            BUSManager.CTBaoCaoDoanhThuBUS.LoadLocalData();
            BUSManager.CTPhieuKhamBenhBUS.LoadLocalData();
            BUSManager.CTPhieuNhapThuocBUS.LoadLocalData();
            BUSManager.DonViBUS.LoadLocalData();
            BUSManager.HoaDonBUS.LoadLocalData();
            BUSManager.PhieuKhamBenhBUS.LoadLocalData();
            BUSManager.PhieuNhapThuocBUS.LoadLocalData();
            BUSManager.ThuocBUS.LoadLocalData();
            BUSManager.ThamSoBUS.LoadLocalData();
        }
    }
}
