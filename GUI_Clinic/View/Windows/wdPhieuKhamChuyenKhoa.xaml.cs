using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Form;
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
    public partial class wdPhieuKhamChuyenKhoa : Window
    {
        public DTO_PKChuyenKhoa PKChuyenKhoa { get; set; }
        public wdPhieuKhamChuyenKhoa(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            InitializeComponent();
            this.DataContext = this;
            BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(pKChuyenKhoa);
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pKChuyenKhoa.PhieuKhamDaKhoa);
            PKChuyenKhoa = pKChuyenKhoa;     
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
