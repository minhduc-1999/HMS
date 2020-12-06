using BUS_Clinic.BUS;
using DTO_Clinic;
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
        public ObservableCollection<DTO_BenhNhan> ListBN1 { get; set; }
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
                    YeuCau = "them yeu cau vao day",
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

        private async Task InitDataAsync()
        {
            var loadListBN1Task = BUSManager.BenhNhanBUS.GetListBNAsync(); //load benh nhan duoc yeu cau kham chuyen khoa tu dau do
            var loadListThamSo = BUSManager.ThamSoBUS.GetListAsync();

            var initDataTasks = new List<Task> { loadListBN1Task, loadListThamSo };
            while (initDataTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(initDataTasks);
                if (finishedTask == loadListBN1Task)
                {
                    ListBN1 = loadListBN1Task.Result;
                    lvDanhSachDuocYeuCauKhamCK.ItemsSource = ListBN1;
                }
                else if (finishedTask == loadListThamSo)
                {
                    ListThamSo = loadListThamSo.Result;
                }
                initDataTasks.Remove(finishedTask);

            }

            UpdateSelectedBN(null);
        }

        private void lvDanhSachDuocYeuCauKhamCK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachDuocYeuCauKhamCK.SelectedIndex != -1)
            {
                lvDanhSachDaDKKhamCK.SelectedIndex = -1;
                UpdateSelectedBN(lvDanhSachDuocYeuCauKhamCK.SelectedItem as DTO_BenhNhan);
                tblTrangThai.Text = "Chưa đăng ký";
                btnDangKy.Visibility = Visibility.Visible;
                btnHoaDon.Visibility = Visibility.Collapsed;
            }
        }

        private void lvDanhSachDaDKKhamCK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachDaDKKhamCK.SelectedIndex != -1)
            {
                lvDanhSachDuocYeuCauKhamCK.SelectedIndex = -1;
                UpdateSelectedBN(lvDanhSachDaDKKhamCK.SelectedItem as DTO_BenhNhan);
                tblTrangThai.Text = "Đã đăng ký";
                btnDangKy.Visibility = Visibility.Collapsed;
                btnHoaDon.Visibility = Visibility.Visible;
            }
        }

        private void UpdateSelectedBN(DTO_BenhNhan bn)
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
                //Yeucau
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
