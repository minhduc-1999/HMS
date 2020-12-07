using BUS_Clinic.BUS;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdInBaoCaoDoanhThu.xaml
    /// </summary>
    public partial class wdInBaoCaoDoanhThu : Window
    {
        public DTO_NhanVien NguoiTao { get; set; }
        private ICollection<DTO_CTBaoCaoDoanhThu> ListCTBCDT { get; set; }
        public wdInBaoCaoDoanhThu(DTO_BCDoanhThu bCDoanhThu, DTO_NhanVien nv)
        {
            InitializeComponent();
            this.DataContext = this;
            BUSManager.BCDoanhThuBUS.LoadNPCTBaoCaoDoanhThu(bCDoanhThu);
            ListCTBCDT = bCDoanhThu.DS_CTBaoCaoDoanhThu;
            NguoiTao = nv;

            lvTongHop.ItemsSource = new List<DTO_BCDoanhThu>() { bCDoanhThu };
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
}
