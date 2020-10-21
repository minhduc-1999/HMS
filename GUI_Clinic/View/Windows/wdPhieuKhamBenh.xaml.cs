using BUS_Clinic.BUS;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdPhieuKhamBenh.xaml
    /// </summary>
    public partial class wdPhieuKhamBenh : Window
    {
        public wdPhieuKhamBenh(DTO_PhieuKhamBenh phieuKhamBenh)
        {
            InitializeComponent();
            this.DataContext = this;

            BUSManager.PhieuKhamBenhBUS.LoadNPBenh(phieuKhamBenh);
            BUSManager.PhieuKhamBenhBUS.LoadNPBenhNhan(phieuKhamBenh);
            BUSManager.PhieuKhamBenhBUS.LoadNPDSCTPhieuKhamBenh(phieuKhamBenh);
            foreach (DTO_CTPhieuKhamBenh item in phieuKhamBenh.DSCTPhieuKhamBenh)
            {
                BUSManager.CTPhieuKhamBenhBUS.LoadNPThuoc(item);
                BUSManager.ThuocBUS.LoadNPDonVi(item.Thuoc);
                BUSManager.CTPhieuKhamBenhBUS.LoadNPCachDung(item);
            }

            tblTenBenhNhan.Text = phieuKhamBenh.BenhNhan.TenBenhNhan;
            tblNgayKham.Text = phieuKhamBenh.NgayKham.ToString();
            tblTrieuChung.Text = phieuKhamBenh.TrieuChung;
            tblDuDoanLoaiBenh.Text = phieuKhamBenh.Benh.TenBenh;
            lvMedicine.ItemsSource = phieuKhamBenh.DSCTPhieuKhamBenh;
        }

        private void btnInPhieu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(grdMain, "PhieuKhamBenh");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
