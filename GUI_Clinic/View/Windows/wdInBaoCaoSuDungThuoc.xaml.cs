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
    /// Interaction logic for wdInBaoCaoSuDungThuoc.xaml
    /// </summary>
    public partial class wdInBaoCaoSuDungThuoc : Window
    {
        private List<DTO_BCSudungThuoc> ListBCSDT { get; set; }
        public wdInBaoCaoSuDungThuoc(List<DTO_BCSudungThuoc> listBCSDT, int thang, int nam)
        {
            InitializeComponent();
            this.DataContext = this;
            ListBCSDT = listBCSDT;
            lvBCSDT.ItemsSource = ListBCSDT;
            tblThangNam.Text = thang.ToString() + "/" + nam.ToString();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(grdMain, "BaoCaoDoanhThu");
                }
            }
            finally
            {

                this.IsEnabled = true;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement window = GetWindowParent(grdTieuDe);
            var w = window as Window;
            if (w != null)
            {
                w.DragMove();
            }
        }

        FrameworkElement GetWindowParent(Grid p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
