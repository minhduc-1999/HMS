using BUS_Clinic.BUS;
using DTO_Clinic.Person;
using GUI_Clinic.View.Windows;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucQuanLyNhanVien.xaml
    /// </summary>
    public partial class ucQuanLyNhanVien : UserControl
    {
        public ObservableCollection<DTO_NhanVien> ListNV { get; set; }
        public DTO_NhanVien currentNV { get; set; }
        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            this.DataContext = this;

            InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            ListNV = await BUSManager.NhanVienBUS.GetListNVAsync();
            foreach (DTO_NhanVien item in ListNV)
            {
                BUSManager.NhanVienBUS.LoadNPGroup(item);
                BUSManager.NhanVienBUS.LoadNPPhong(item);
            }

            lvNhanVien.ItemsSource = ListNV;

            CollectionView viewNhanVien = (CollectionView)CollectionViewSource.GetDefaultView(lvNhanVien.ItemsSource);
            viewNhanVien.Filter = NhanVienFilter;
        }

        private bool NhanVienFilter(Object item)
        {
            if (String.IsNullOrEmpty(tbxTimKiem.Text))
            {
                return true;
            }
            else
            {
                if (cbxLoaiTiemKiem.SelectedIndex == 0)
                {
                    return ((item as DTO_NhanVien).HoTen.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (cbxLoaiTiemKiem.SelectedIndex == 1)
                {
                    return ((item as DTO_NhanVien).MaNhanVien.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (cbxLoaiTiemKiem.SelectedIndex == 2)
                {
                    BUSManager.NhanVienBUS.LoadNPGroup(item as DTO_NhanVien);
                    return ((item as DTO_NhanVien).Nhom.TenNhom.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    return false;
                }
            }
        }

        private void tbxTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvNhanVien.ItemsSource).Refresh();
        }

        private void lvNhanVien_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_NhanVien;
            if (item != null)
            {
                wdNhanVien nhanVien = new wdNhanVien(item);
                nhanVien.ShowDialog();
            }
        }

        private void btnThemNV_Click(object sender, RoutedEventArgs e)
        {
            wdTaiKhoan newTaiKhoan = new wdTaiKhoan(currentNV);
            newTaiKhoan.ShowDialog();
        }
    }
}
