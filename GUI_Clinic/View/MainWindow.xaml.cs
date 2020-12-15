using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Permission;
using DTO_Clinic.Person;
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
using System.Windows.Shapes;

namespace GUI_Clinic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<DTO_Group> ListNhom { get; set; }
        public MainWindow(DTO_NhanVien currentNV, ObservableCollection<DTO_Group> ListNhom)
        {
            InitializeComponent();
            ucControlBar.SetProfileInfo(currentNV);
            uc_QuanLyNhanVien.currentNV = currentNV;
            uc_DanhSachKhamChuyenKhoa.CurrentNV = currentNV;
            uc_QuanLyThuoc.maDuocSi = currentNV.MaNhanVien;
            uc_DanhSachKhamBenh.CurrentNV = currentNV;
            uc_BaoCaoDoanhThu.CurrentNhanVien = currentNV;
            uc_DanhSachDonThuoc.maNhanvien = currentNV.MaNhanVien;
            uc_DanhSachPhieuKhamBenh.CurrentNV = currentNV;
            uc_DanhSachPhieuKhamChuyenKhoa.CurrentNV = currentNV;
            GetListNhomAsync();
            uc_DanhSachKhamBenh.PatientAdded += Uc_DanhSachKhamBenh_PatientAdded;
            uc_DanhSachKhamBenh.PatientSigned += Uc_DanhSachKhamBenh_PatientSigned;
            uc_DanhSachKhamChuyenKhoa.PatientSigned += Uc_DanhSachKhamChuyenKhoa_PatientSigned;
            uc_DanhSachPhieuKhamBenh.WaitingPatientRemoved += Uc_DanhSachPhieuKhamBenh_WaitingPatientRemoved;
            uc_DanhSachDonThuoc.ListThuoc = uc_QuanLyThuoc.ListThuoc;
            uc_DanhSachPhieuKhamBenh.setUCDSKCK(uc_DanhSachKhamChuyenKhoa);
            uc_DanhSachPhieuKhamChuyenKhoa.SavingPKCK += Uc_DanhSachPhieuKhamChuyenKhoa_SavingPKCK;
            if (ListNhom != null)
            {
                int index = -1;
                for (int i = 0; i < ListNhom.Count; i++)
                {
                    if (currentNV.Nhom.MaNhom == ListNhom[i].MaNhom)
                    {
                        index = i;
                        break;
                    }
                }
                switch (index)
                {
                    case 0: //ADMIN
                    //    itemBCDoanhThu.Visibility = Visibility.Collapsed;
                    //    itemBCSuDungThuoc.Visibility = Visibility.Collapsed;
                    //    itemDSDonThuoc.Visibility = Visibility.Collapsed;
                    //    itemQLBenhNhan.Visibility = Visibility.Collapsed;
                    //    itemQLThuoc.Visibility = Visibility.Collapsed;
                    //    itemDSKhamBenh.Visibility = Visibility.Collapsed;
                    //    itemDSKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    //    itemQLPKB.Visibility = Visibility.Collapsed;
                    //    itemQLPKCK.Visibility = Visibility.Collapsed;
                    //    itemThietLapKhac.Visibility = Visibility.Visible;
                    //    itemQLNhanVien.Visibility = Visibility.Visible;
                    //    btnSetting.Visibility = Visibility.Visible;
                    //    ListViewMenu.SelectedIndex = 9;

                    //test
                     itemBCDoanhThu.Visibility = Visibility.Visible;
                itemBCSuDungThuoc.Visibility = Visibility.Visible;
                itemDSDonThuoc.Visibility = Visibility.Visible;
                itemQLBenhNhan.Visibility = Visibility.Visible;
                itemQLThuoc.Visibility = Visibility.Visible;
                itemDSKhamBenh.Visibility = Visibility.Visible;
                itemDSKhamChuyenKhoa.Visibility = Visibility.Visible;
                itemQLPKB.Visibility = Visibility.Visible;
                itemQLPKCK.Visibility = Visibility.Visible;
                itemThietLapKhac.Visibility = Visibility.Visible;
                itemQLNhanVien.Visibility = Visibility.Visible;
                btnSetting.Visibility = Visibility.Visible;
                ListViewMenu.SelectedIndex = 0;
                break;
                    case 1: //BSDK
                        itemBCDoanhThu.Visibility = Visibility.Collapsed;
                        itemBCSuDungThuoc.Visibility = Visibility.Collapsed;
                        itemDSDonThuoc.Visibility = Visibility.Collapsed;
                        itemQLBenhNhan.Visibility = Visibility.Visible;
                        itemQLThuoc.Visibility = Visibility.Collapsed;
                        itemDSKhamBenh.Visibility = Visibility.Collapsed;
                        itemDSKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                        itemQLPKB.Visibility = Visibility.Visible;
                        itemQLPKCK.Visibility = Visibility.Collapsed;
                        itemThietLapKhac.Visibility = Visibility.Collapsed;
                        itemQLNhanVien.Visibility = Visibility.Collapsed;
                        btnSetting.Visibility = Visibility.Collapsed;
                        ListViewMenu.SelectedIndex = 0;
                        break;
                    case 2: //BSCK
                        itemBCDoanhThu.Visibility = Visibility.Collapsed;
                        itemBCSuDungThuoc.Visibility = Visibility.Collapsed;
                        itemDSDonThuoc.Visibility = Visibility.Collapsed;
                        itemQLBenhNhan.Visibility = Visibility.Visible;
                        itemQLThuoc.Visibility = Visibility.Collapsed;
                        itemDSKhamBenh.Visibility = Visibility.Collapsed;
                        itemDSKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                        itemQLPKB.Visibility = Visibility.Collapsed;
                        itemQLPKCK.Visibility = Visibility.Visible;
                        itemThietLapKhac.Visibility = Visibility.Collapsed;
                        itemQLNhanVien.Visibility = Visibility.Collapsed;
                        btnSetting.Visibility = Visibility.Collapsed;
                        ListViewMenu.SelectedIndex = 0;
                        break;
                    case 3: //DUOCSI
                        itemBCDoanhThu.Visibility = Visibility.Collapsed;
                        itemBCSuDungThuoc.Visibility = Visibility.Collapsed;
                        itemDSDonThuoc.Visibility = Visibility.Visible;
                        itemQLBenhNhan.Visibility = Visibility.Collapsed;
                        itemQLThuoc.Visibility = Visibility.Visible;
                        itemDSKhamBenh.Visibility = Visibility.Collapsed;
                        itemDSKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                        itemQLPKB.Visibility = Visibility.Collapsed;
                        itemQLPKCK.Visibility = Visibility.Collapsed;
                        itemThietLapKhac.Visibility = Visibility.Collapsed;
                        itemQLNhanVien.Visibility = Visibility.Collapsed;
                        btnSetting.Visibility = Visibility.Collapsed;
                        ListViewMenu.SelectedIndex = 5;
                        break;
                    case 4: //THUTUC
                        itemBCDoanhThu.Visibility = Visibility.Visible;
                        itemBCSuDungThuoc.Visibility = Visibility.Visible;
                        itemDSDonThuoc.Visibility = Visibility.Collapsed;
                        itemQLBenhNhan.Visibility = Visibility.Visible;
                        itemQLThuoc.Visibility = Visibility.Collapsed;
                        itemDSKhamBenh.Visibility = Visibility.Visible;
                        itemDSKhamChuyenKhoa.Visibility = Visibility.Visible;
                        itemQLPKB.Visibility = Visibility.Collapsed;
                        itemQLPKCK.Visibility = Visibility.Collapsed;
                        itemThietLapKhac.Visibility = Visibility.Collapsed;
                        itemQLNhanVien.Visibility = Visibility.Collapsed;
                        btnSetting.Visibility = Visibility.Collapsed;
                        ListViewMenu.SelectedIndex = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Uc_DanhSachKhamBenh_PatientAdded(object sender, EventArgs e)
        {
            uc_QuanLyBenhNhan.ThemBenhNhan(sender as DTO_BenhNhan);
        }

        public async Task GetListNhomAsync()
        {
            //ListNhom = await BUSManager.GroupBUS.GetListNhomAsync();
        }

        private void Uc_DanhSachPhieuKhamBenh_WaitingPatientRemoved(object sender, EventArgs e)
        {
            uc_DanhSachKhamBenh.RemovePatientSigned(sender as DTO_BenhNhan);
        }

        private void Uc_DanhSachKhamBenh_PatientSigned(object sender, EventArgs e)
        {
            uc_DanhSachPhieuKhamBenh.UpdateWaitingList(sender);
        }
        private void Uc_DanhSachKhamChuyenKhoa_PatientSigned(object sender, EventArgs e)
        {
            uc_DanhSachPhieuKhamChuyenKhoa.UpdateWaitingList(sender);
        }
        private void Uc_DanhSachPhieuKhamChuyenKhoa_SavingPKCK(object sender, EventArgs e)
        {
            uc_DanhSachPhieuKhamBenh.UpdatePKCKList(sender);
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Visible;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                    ucControlBar.Tag = "Quản lý bệnh nhân";
                    break;
                case 1:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Visible;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    ucControlBar.Tag = "Danh sách khám bệnh";
                    break;
                case 2:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Visible;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 120, 0, 0);
                    ucControlBar.Tag = "Danh sách khám chuyên khoa";
                    break;
                case 3:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Visible;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    ucControlBar.Tag = "Quản lý phiếu khám bệnh";
                    break;
                case 4:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Visible;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    ucControlBar.Tag = "Quản lý phiếu khám chuyên khoa";
                    break;
                case 5:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Visible;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                    ucControlBar.Tag = "Danh sách đơn thuốc";
                    break;
                case 6:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Visible;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    ucControlBar.Tag = "Quản lý thuốc";
                    break;
                case 7:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Visible;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 180, 0, 0);
                    ucControlBar.Tag = "Báo cáo sử dụng thuốc";
                    break;
                case 8:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Visible;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 240, 0, 0);
                    ucControlBar.Tag = "Báo cáo doanh thu";
                    break;
                case 9:
                    uc_QuanLyNhanVien.Visibility = Visibility.Visible;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Collapsed;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 0, 0, 0);
                    ucControlBar.Tag = "Quản lý nhân viên";
                    break;
                case 10:
                    uc_QuanLyNhanVien.Visibility = Visibility.Collapsed;
                    uc_BaoCaoDoanhThu.Visibility = Visibility.Collapsed;
                    uc_BaoCaoSuDungThuoc.Visibility = Visibility.Collapsed;
                    uc_DonViCachDung.Visibility = Visibility.Visible;
                    uc_QuanLyThuoc.Visibility = Visibility.Collapsed;
                    uc_QuanLyBenhNhan.Visibility = Visibility.Collapsed;
                    uc_DanhSachDonThuoc.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachPhieuKhamBenh.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamChuyenKhoa.Visibility = Visibility.Collapsed;
                    uc_DanhSachKhamBenh.Visibility = Visibility.Collapsed;
                    grdSelectedButton.Margin = new Thickness(0, 60, 0, 0);
                    ucControlBar.Tag = "Các thiết lập khác";
                    break;
                default:
                    break;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // BUSManager.BenhNhanBUS.SaveChange();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            //wdThietLap wdThietLap = new wdThietLap();
            //wdThietLap.ShowDialog();
        }
    }
}
