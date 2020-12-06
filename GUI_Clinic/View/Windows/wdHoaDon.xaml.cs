using BUS_Clinic.BUS;
using DTO_Clinic.Form;
using System.Windows;
using System.Windows.Controls;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdHoaDon.xaml
    /// </summary>
    public partial class wdHoaDon : Window
    {
        public wdHoaDon(DTO_HoaDon hoaDon)
        {
            InitializeComponent();
            this.DataContext = this;
            BUSManager.HoaDonBUS.LoadNPBenhNhan(hoaDon);
            HoaDon = hoaDon;
        }        
        #region Property
        public DTO_HoaDon HoaDon { get; set; }
        #endregion

        private void btnInHoaDon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(grdMain, "HoaDon");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
