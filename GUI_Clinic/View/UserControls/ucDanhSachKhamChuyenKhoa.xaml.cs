using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Component;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using GUI_Clinic.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDanhSachKhamChuyenKhoa.xaml
    /// </summary>
    public partial class ucDanhSachKhamChuyenKhoa : UserControl
    {
        #region Properties
        public ObservableCollection<DTO_BenhNhan> ListBNYC { get; set; }

        public ObservableCollection<DTO_YeuCau> ListYC { get; set; }
        public ObservableCollection<DTO_YeuCau> ListYCDaDK { get; set; }
        public ObservableCollection<DTO_BenhNhan> ListBNDaDK { get; set; }
        public ObservableCollection<DTO_ThamSo> ListThamSo { get; set; }
        public ObservableCollection<DTO_HoaDon> ListHDCuaBNDaDK { get; set; }
        public DTO_NhanVien CurrentNV { get; set; }
        public DTO_BenhNhan selectedBN { get; set; }

        #endregion
        #region Command
        public ICommand SignedCommand { get; set; }
        public ICommand XemHoaDonCommand { get; set; }
        #endregion

        public ucDanhSachKhamChuyenKhoa()
        {
            InitializeComponent();
            this.DataContext = this;
            lvDanhSachDaDKKhamCK.ItemsSource = ListBNDaDK;
            InitDataAsync();
            InitCommand();
        }

        private void InitCommand()
        {
            SignedCommand = new RelayCommand<Window>((p) =>
            {
                if (selectedBN == null)
                    return false;
                return true;
            }, async (p) =>
            {
                var hoaDon = new DTO_HoaDon()
                {
                    ChiTiet = "Tiền khám chuyên khoa",
                    ThanhTien = ListThamSo.Where(ts => ts.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri,
                    NgayLap = DateTime.Now,
                    LoaiHoaDon = DTO_HoaDon.LoaiHD.HDKhamChuyenKhoa,
                    MaBenhNhan = selectedBN.MaBenhNhan,
                    MaNhanVien = CurrentNV.MaNhanVien
                };
                var res = await BUSManager.HoaDonBUS.AddHoaDonAsync(hoaDon);
                if (string.IsNullOrEmpty(res))
                {
                    MsgBox.Show("Tạo hoá đơn không thành công, vui lòng thử lại", MessageType.Error);
                    return;
                }
                var phieuKhamChuyenKhoa = new DTO_PKChuyenKhoa()
                {
                    NgayKham = DateTime.Now,
                    MaNhanVien = CurrentNV.MaNhanVien,
                    YeuCau = tblYeuCau.Text,
                    MaPKDaKhoa = BUSManager.BenhNhanBUS.GetPKDKMoiNhat(selectedBN).MaPKDK,
                    PhieuKhamDaKhoa = BUSManager.BenhNhanBUS.GetPKDKMoiNhat(selectedBN)
                };
                try
                {
                    //BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(phieuKhamChuyenKhoa);
                    var maPKCK = await BUSManager.PKChuyenKhoaBUS.AddPhieuKhamChuyenKhoaAsync(phieuKhamChuyenKhoa);
                    if (!string.IsNullOrEmpty(maPKCK))
                    {
                        MsgBox.Show("Đăng ký khám chuyên khoa thành công", MessageType.Info);
                        if (dpkNgayKham.SelectedDate.Value.Date == DateTime.Now.Date)
                        {
                            ListBNDaDK.Add(selectedBN);
                            if (ListYCDaDK == null)
                            {
                                ListYCDaDK = new ObservableCollection<DTO_YeuCau>();
                            }
                            ListYCDaDK.Add(ListYC[lvDanhSachDuocYeuCauKhamCK.SelectedIndex]);
                            //BUSManager.HoaDonBUS.LoadNPBenhNhan(hoaDon);
                            //ListHDCuaBNDaDK.Add(hoaDon);
                        }
                    }
                }
                catch (Exception e)
                {
                    MsgBox.Show(e.Message, MessageType.Error);
                }

            });

            XemHoaDonCommand = new RelayCommand<Window>((p) =>
            {
                if (selectedBN == null)
                    return false;
                return true;
            }, async (p) =>
            {
                ListHDCuaBNDaDK = BUSManager.HoaDonBUS.GetListHDCKByDate(dpkNgayKham.SelectedDate.Value);
                wdHoaDon hoaDon = new wdHoaDon(ListHDCuaBNDaDK[lvDanhSachDaDKKhamCK.SelectedIndex]);
                hoaDon.ShowDialog();
            });
        }

        public async Task UpdateListBNYCAsync(DTO_YeuCau newYC)
        {
            DTO_BenhNhan newBNYC = await BUSManager.BenhNhanBUS.GetBenhNhanByIdAsync(newYC.MaBenhNhan);
            if (ListYC == null)
            {
                ListYC = new ObservableCollection<DTO_YeuCau>();
            }
            ListYC.Add(newYC);
            if (ListBNYC == null)
            {
                ListBNYC = new ObservableCollection<DTO_BenhNhan>();
            }
            ListBNYC.Add(newBNYC);
            lvDanhSachDuocYeuCauKhamCK.ItemsSource = ListBNYC;
        }

        private async Task InitDataAsync()
        {
            lvDanhSachDuocYeuCauKhamCK.ItemsSource = ListBNYC;

            var loadListThamSo = BUSManager.ThamSoBUS.GetListAsync();

            var initDataTasks = new List<Task> { loadListThamSo };
            while (initDataTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(initDataTasks);
                //if (finishedTask == loadListBN1Task)
                //{
                //    ListBN1 = loadListBN1Task.Result;
                //    lvDanhSachDuocYeuCauKhamCK.ItemsSource = ListBN1;
                //}
                //else 
                if (finishedTask == loadListThamSo)
                {
                    ListThamSo = loadListThamSo.Result;
                }
                initDataTasks.Remove(finishedTask);

            }

            UpdateSelectedBN(null, -1);
        }

        private void lvDanhSachDuocYeuCauKhamCK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachDuocYeuCauKhamCK.SelectedIndex != -1)
            {
                lvDanhSachDaDKKhamCK.SelectedIndex = -1;
                tblTrangThai.Text = "Chưa đăng ký";
                UpdateSelectedBN(lvDanhSachDuocYeuCauKhamCK.SelectedItem as DTO_BenhNhan, lvDanhSachDuocYeuCauKhamCK.SelectedIndex);
                btnDangKy.Visibility = Visibility.Visible;
                btnHoaDon.Visibility = Visibility.Collapsed;
            }
        }

        private void lvDanhSachDaDKKhamCK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachDaDKKhamCK.SelectedIndex != -1)
            {
                lvDanhSachDuocYeuCauKhamCK.SelectedIndex = -1;
                tblTrangThai.Text = "Đã đăng ký";
                UpdateSelectedBN(lvDanhSachDaDKKhamCK.SelectedItem as DTO_BenhNhan, lvDanhSachDaDKKhamCK.SelectedIndex);
                btnDangKy.Visibility = Visibility.Collapsed;
                btnHoaDon.Visibility = Visibility.Visible;
            }
        }

        private void UpdateSelectedBN(DTO_BenhNhan bn, int index)
        {
            selectedBN = bn;
            if (selectedBN != null)
            {
                grdBNInfo.Visibility = Visibility.Visible;
                tblMaBN.Text = selectedBN.MaBenhNhan;
                tblHoTen.Text = selectedBN.HoTen;
                tblNgaySinh.Text = selectedBN.NgaySinh.ToShortDateString();
                tblGioiTinh.Text = (selectedBN.GioiTinh) ? "Nữ" : "Nam" ;
                tblDiaChi.Text = selectedBN.DiaChi;
                tblSDT.Text = selectedBN.SoDienThoai;
                tblCMND.Text = selectedBN.SoCMND;
                if (tblTrangThai.Text == "Đã đăng ký")
                {
                    tblYeuCau.Text = ListYCDaDK[index].NoiDung;
                }
                else
                {
                    tblYeuCau.Text = ListYC[index].NoiDung;
                }
            }
            else
            {
                grdBNInfo.Visibility = Visibility.Collapsed;
            }
        }

        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpkNgayKham.SelectedDate.HasValue)
            {
                var curDate = (sender as DatePicker).SelectedDate.Value;
                ListBNDaDK = BUSManager.PKChuyenKhoaBUS.GetListBNByDate(curDate);
                ListHDCuaBNDaDK = BUSManager.HoaDonBUS.GetListHDCKByDate(curDate);
                if (ListBNDaDK != null 
                    && lvDanhSachDaDKKhamCK != null)
                {
                    lvDanhSachDaDKKhamCK.ItemsSource = ListBNDaDK;
                }
            }
        }
    }
}
