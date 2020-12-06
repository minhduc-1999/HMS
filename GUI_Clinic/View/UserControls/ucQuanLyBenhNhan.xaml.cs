using BUS_Clinic.BUS;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
using GUI_Clinic.View.Windows;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucQuanLyBenhNhan.xaml
    /// </summary>
    public partial class ucQuanLyBenhNhan : UserControl
    {
        public ucQuanLyBenhNhan()
        {
            InitializeComponent();
            this.DataContext = this;
            InitDataAsync();
        }

        #region Property                
        public ObservableCollection<DTO_BenhNhan> ListBN { get; set; }
        public ObservableCollection<DTO_PKDaKhoa> ListPKDK { get; set; }
        #endregion
        #region Command

        #endregion
        public async Task InitDataAsync()
        {
            ListBN = await BUSManager.BenhNhanBUS.GetListBNAsync();
            lvBenhNhan.ItemsSource = ListBN;

            CollectionView viewBenhNhan = (CollectionView)CollectionViewSource.GetDefaultView(lvBenhNhan.ItemsSource);
            viewBenhNhan.Filter = BenhNhanFilter;
        }

        private bool BenhNhanFilter(Object item)
        {
            if (String.IsNullOrEmpty(tbxTimKiem.Text))
            {
                return true;
            }
            else
            {
                switch (cbxLoaiTiemKiem.SelectedIndex)
                {
                    case 0:
                        return ((item as DTO_BenhNhan).HoTen.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                    case 1:
                        return ((item as DTO_BenhNhan).DiaChi.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                    case 2:
                        return ((item as DTO_BenhNhan).SoDienThoai.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                    case 3:
                        return ((item as DTO_BenhNhan).SoCMND.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                    default:
                        return false;
                }
            }
        }

        private void tbxTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvBenhNhan.ItemsSource).Refresh();
        }

        private void lvBenhNhan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBenhNhan.SelectedItem != null)
            {
                var bn = lvBenhNhan.SelectedItem as DTO_BenhNhan;
                BUSManager.BenhNhanBUS.LoadNP_DSPKDK(bn);
                ListPKDK = new ObservableCollection<DTO_PKDaKhoa>(bn.DS_PKDaKhoa);
                lvDanhSachPKB.ItemsSource = ListPKDK;
            }
        }

        private void lvDanhSachPKB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PKDaKhoa;
            if (item != null)
            {
                //Mo PKB tuong ung
                wdPhieuKhamBenh phieuKhamBenh = new wdPhieuKhamBenh(item);
                phieuKhamBenh.ShowDialog();
            }
        }

        private void lvBenhNhan_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_BenhNhan;
            var item = lvBenhNhan.SelectedItem as DTO_BenhNhan;
            if (item != null)
            {
                //Mo thong tin benh nhan tuong ung
                wdBenhNhan benhNhan = new wdBenhNhan(item, wdBenhNhan.Action.Watch);
                benhNhan.ShowDialog();
            }
        }
        public void ThemBenhNhan(DTO_BenhNhan bn)
        {
            if (bn != null)
                ListBN.Add(bn);
        }
    }
}
