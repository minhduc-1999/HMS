using BUS_Clinic.BUS;
using DTO_Clinic;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for wdInBaoCaoDoanhThu.xaml
    /// </summary>
    public partial class wdInBaoCaoDoanhThu : Window
    {
        private ICollection<DTO_CTBaoCaoDoanhThu> ListCTBCDT { get; set; }
        private int TongSoBenhNhan { get; set; }
        public wdInBaoCaoDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            InitializeComponent();
            this.DataContext = this;
            TongSoBenhNhan = 0;
            BUSManager.BCDoanhThuBUS.LoadNPCTBaoCaoDoanhThu(bCDoanhThu);
            ListCTBCDT = bCDoanhThu.DS_CTBaoCaoDoanhThu;
            foreach (DTO_CTBaoCaoDoanhThu item in ListCTBCDT)
            {
                TongSoBenhNhan += item.SoBenhNhan;
            }
            lvTongHop.Items.Add(new MyItem { TongBenhNhan = TongSoBenhNhan, TongDoanhThu = bCDoanhThu.TongDoanhThu});
            lvCTBCDT.ItemsSource = ListCTBCDT;
            tblThangNam.Text = bCDoanhThu.Thang.ToString() + "/" + bCDoanhThu.Nam.ToString();
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

    public class MyItem
    {
        public int TongBenhNhan { get; set; }
        public float TongDoanhThu { get; set; }
    }
}
