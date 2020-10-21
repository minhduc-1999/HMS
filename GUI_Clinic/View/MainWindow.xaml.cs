using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.View.Windows;
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

namespace GUI_Clinic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uc_DanhSachKhamBenh.PatientSigned += Uc_DanhSachKhamBenh_PatientSigned;
            uc_DanhSachPhieuKhamBenh.WaitingPatientRemoved += Uc_DanhSachPhieuKhamBenh_WaitingPatientRemoved;
        }

        private void Uc_DanhSachPhieuKhamBenh_WaitingPatientRemoved(object sender, EventArgs e)
        {
            uc_DanhSachKhamBenh.RemovePatientSigned(sender as DTO_BenhNhan);
        }

        private void Uc_DanhSachKhamBenh_PatientSigned(object sender, EventArgs e)
        {
            uc_DanhSachPhieuKhamBenh.UpdateWaitingList(sender);
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Visible;
                    grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                    break;
                case 1:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Visible;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    break;
                case 2:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Visible;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 120, 0, 0);
                    break;
                case 3:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Visible;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 180, 0, 0);
                    break;
                case 4:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Visible;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 240, 0, 0);
                    break;
                case 5:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Visible;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 300, 0, 0);
                    break;
                case 6:
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Visible;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 360, 0, 0);
                    break;
                default:
                    break;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BUSManager.BenhNhanBUS.SaveChange();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            wdThietLap wdThietLap = new wdThietLap();
            wdThietLap.ShowDialog();
        }
    }
}
