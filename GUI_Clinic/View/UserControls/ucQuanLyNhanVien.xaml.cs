using BUS_Clinic.BUS;
using DTO_Clinic.Person;
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
    /// Interaction logic for ucQuanLyNhanVien.xaml
    /// </summary>
    public partial class ucQuanLyNhanVien : UserControl
    {
        public ObservableCollection<DTO_NhanVien> ListNV { get; set; }
        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            this.DataContext = this;

            InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            ListNV = await BUSManager.NhanVienBUS.GetListNVAsync();

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
                //else if (cbxLoaiTiemKiem.SelectedIndex == 2)
                //{
                //    return ((item as DTO_NhanVien).ChucVu.IndexOf(tbxTimKiem.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                //}
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

        private void lvNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
