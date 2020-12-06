using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Component;
using DTO_Clinic.Form;
using GUI_Clinic.Command;
using GUI_Clinic.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucQuanLyThuoc.xaml
    /// </summary>
    public partial class ucQuanLyThuoc : UserControl
    {
        public ucQuanLyThuoc()
        {
            InitializeComponent();
            this.DataContext = this;
            InitDataAsync();
        }

        #region Property
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_PhieuNhapThuoc> ListPNT { get; set; }
        public ObservableCollection<DTO_CTPhieuNhapThuoc> ListCTPNT { get; set; }
        public DTO_Thuoc thuoc { get; set; }
        public DTO_PhieuNhapThuoc phieuNhapThuoc { get; set; }
        public DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc { get; set; }
        private string MaPNTSelected;
        public string maDuocSi;

        #endregion

        #region Command

        #endregion

        private async Task InitDataAsync()
        {
            //thuoc = new DTO_Thuoc("thuoc ngu", 2, 50000, 10, "ngu");
            //BUSManager.ThuocBUS.AddThuoc(thuoc);

            //phieuNhapThuoc = new DTO_PhieuNhapThuoc(Convert.ToDateTime("06/06/2020"), 500000000);
            //BUSManager.PhieuNhapThuocBUS.AddPhieuNhapThuoc(phieuNhapThuoc);

            //cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(0, 0, 12, 500);
            //BUSManager.CTPhieuNhapThuocBUS.AddCTPhieuNhapThuoc(cTPhieuNhapThuoc);

            ListThuoc = await BUSManager.ThuocBUS.GetListThuocAsync();
            ListPNT = await BUSManager.PhieuNhapThuocBUS.GetListPNTAsync();
            ListCTPNT = await BUSManager.CTPhieuNhapThuocBUS.GetListCTPNTAsync();

            foreach (DTO_PhieuNhapThuoc item in ListPNT)
            {
                BUSManager.PhieuNhapThuocBUS.LoadNP_NhanVien(item);
            }
            foreach (DTO_CTPhieuNhapThuoc item in ListCTPNT)
            {
                BUSManager.CTPhieuNhapThuocBUS.LoadNP_Thuoc(item);
            }

            lvThuoc.ItemsSource = ListThuoc;
            lvPhieuNhapThuoc.ItemsSource = ListPNT;
            lvCTPhieuNhapThuoc.ItemsSource = ListCTPNT;

            CollectionView viewThuoc = (CollectionView)CollectionViewSource.GetDefaultView(lvThuoc.ItemsSource);
            viewThuoc.Filter = ThuocFilter;

            CollectionView viewPNT = (CollectionView)CollectionViewSource.GetDefaultView(lvPhieuNhapThuoc.ItemsSource);
            viewPNT.Filter = PNTFilter;

            CollectionView viewCTPNT = (CollectionView)CollectionViewSource.GetDefaultView(lvCTPhieuNhapThuoc.ItemsSource);
            viewCTPNT.Filter = CTPNTFilter;
        }

        private bool ThuocFilter(object item)
        {
            if (String.IsNullOrEmpty(tbxTimThuoc.Text))
                return true;
            else
                return ((item as DTO_Thuoc).TenThuoc.IndexOf(tbxTimThuoc.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool PNTFilter(object item)
        {
            if (dpkTimPNT.SelectedDate == null)
                return true;
            else
                return (item as DTO_PhieuNhapThuoc).NgayNhap.Date == dpkTimPNT.SelectedDate;
        }

        private bool CTPNTFilter(Object item)
        {
            if (MaPNTSelected == null)
            {
                return true;
            }
            else
            {
                return (item as DTO_CTPhieuNhapThuoc).MaPNT == MaPNTSelected;
            }
        }
        private void tbx_TimThuoc_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvThuoc.ItemsSource).Refresh();
        }

        private void dpTimPNT_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvPhieuNhapThuoc.ItemsSource).Refresh();
        }

        private void lvPhieuNhapThuoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tempMaPNTSelected = lvPhieuNhapThuoc.SelectedItem;
            if (tempMaPNTSelected != null)
            {
                MaPNTSelected = (lvPhieuNhapThuoc.SelectedItem as DTO_PhieuNhapThuoc).MaPNT;
                CollectionViewSource.GetDefaultView(lvCTPhieuNhapThuoc.ItemsSource).Refresh();
            }
            else
            {
                return;
            }
        }

        private void btnNhapThuoc_Click(object sender, RoutedEventArgs e)
        {
            wdPhieuNhapThuoc wd = new wdPhieuNhapThuoc(maDuocSi);
            wd.Closing += Wd_Closing;

            wd.ShowDialog();

        }

        private async void Wd_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ListThuoc = await BUSManager.ThuocBUS.GetListThuocAsync();
            //ListPNT = await BUSManager.PhieuNhapThuocBUS.GetListPNTAsync();
            //ListCTPNT = await BUSManager.CTPhieuNhapThuocBUS.GetListCTPNTAsync();

            lvThuoc.ItemsSource = null;
            lvThuoc.ItemsSource = ListThuoc;
            lvThuoc.SelectedIndex = 0;
            //CollectionViewSource.GetDefaultView(lvThuoc.ItemsSource).Refresh();
            //lvPhieuNhapThuoc.ItemsSource = ListPNT;
            //lvCTPhieuNhapThuoc.ItemsSource = ListCTPNT;
        }

        private void lvThuoc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_Thuoc;
            if (item != null)
            {
                //Mo Thong tin thuoc tuong ung
                wdThongTinThuoc wdInfo = new wdThongTinThuoc(item);
                wdInfo.ShowDialog();
            }
        }
    }
}
