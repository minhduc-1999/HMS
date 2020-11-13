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
    /// Interaction logic for wdHoaDon.xaml
    /// </summary>
    public partial class wdHoaDon : Window
    {
        public wdHoaDon(DTO_HoaDon hoaDon)
        {
            InitializeComponent();
            this.DataContext = this;
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
