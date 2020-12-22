using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Form;
using DTO_Clinic.Component;
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
    public partial class wdHoaDonThuoc : Window
    {
        public double ThanhTien { get; set; }
        public wdHoaDonThuoc(ObservableCollection<DTO_CTHDThuoc> listThuoc)
        {
            InitializeComponent();
            this.DataContext = this;
            ThanhTien = 0;
            lvMedicine.ItemsSource = listThuoc;
            foreach (DTO_CTHDThuoc item in listThuoc)
            {
                item.ThanhTien = item.SoLuong * item.DonGia;
                ThanhTien += item.ThanhTien;
            }
        }

        private void btnInPhieu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(grdMain, "");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
