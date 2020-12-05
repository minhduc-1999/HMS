using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Component;
using DTO_Clinic.Person;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using GUI_Clinic.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using DTO_Clinic.Form;
using System.Linq;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDanhSachKhamBenh.xaml
    /// </summary>
    public partial class ucDanhSachKhamBenh : UserControl
    {
        public ucDanhSachKhamBenh()
        {
            InitializeComponent();
            this.DataContext = this;
            InitDataAsync();
            InitCommand();
        }
        #region Property
        public ObservableCollection<DTO_Phong> ListRoom { get; set; }
        public ObservableCollection<DTO_BenhNhan> ListPatient { get; set; }
        public ObservableCollection<DTO_BenhNhan> ExaminedPatientList { get; set; }
        public List<string> MatchBNList { get; set; }
        public ObservableCollection<DTO_ThamSo> ListThamSo { get; set; }
        public DTO_NhanVien CurrentNV { get; set; }
        public int CurrentPatientAmount { get; set; }
        #endregion
        #region Command
        public ICommand SignedCommand { get; set; }
        #endregion
        #region
        public event EventHandler PatientSigned;
        #endregion
        public async Task InitDataAsync()
        {
            dpkNgayKham.SelectedDate = DateTime.Now;
            CurrentPatientAmount = BUSManager.PKDaKhoaBUS.GetAmountByDate(DateTime.Now);
            var loadListPatientTask = BUSManager.BenhNhanBUS.GetListBNAsync();
            var loadListRoomTask = BUSManager.PhongBUS.GetListPhongAsync();
            var loadListThamSo = BUSManager.ThamSoBUS.GetListAsync();
            var initDataTasks = new List<Task> { loadListPatientTask, loadListRoomTask, loadListThamSo };
            while (initDataTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(initDataTasks);
                if (finishedTask == loadListPatientTask)
                {
                    ListPatient = loadListPatientTask.Result;
                    cbxDSBenhNhan.ItemsSource = ListPatient;
                    //Debug.WriteLine("[INFO] Init data done!\n");
                }
                else if (finishedTask == loadListRoomTask)
                {
                    ListRoom = loadListRoomTask.Result;
                    cbxPhong.ItemsSource = ListRoom;
                }
                else if (finishedTask == loadListThamSo)
                {
                    ListThamSo = loadListThamSo.Result;
                }
                initDataTasks.Remove(finishedTask);
            }
        }
        public void InitCommand()
        {
            SignedCommand = new RelayCommand<Window>((p) =>
            {
                if (cbxPhong.SelectedIndex == -1 || cbxDSBenhNhan.SelectedIndex == -1)
                    return false;
                return true;
            }, async (p) =>
            {
                var maxPatient = ListThamSo.Where(ts => ts.TenThamSo == "Số bệnh nhân tối đa 1 ngày").FirstOrDefault().GiaTri;
                if(CurrentPatientAmount >= maxPatient)
                {
                    MsgBox.Show("Đã tiếp nhận đủ số bệnh nhân trong ngày", MessageType.Error);
                    return;
                }
                var benhNhan = cbxDSBenhNhan.SelectedItem as DTO_BenhNhan;
                var hoaDon = new DTO_HoaDon()
                {
                    ChiTiet = "Tiền khám bệnh",
                    ThanhTien = ListThamSo.Where(ts => ts.TenThamSo == "Tiền khám").FirstOrDefault().GiaTri,
                    NgayLap = DateTime.Now,
                    LoaiHoaDon = DTO_HoaDon.LoaiHD.HDKhamDaKhoa,
                    MaBenhNhan = benhNhan.MaBenhNhan,
                    MaNhanVien = CurrentNV.MaNhanVien
                };
                var res = await BUSManager.HoaDonBUS.AddHoaDonAsync(hoaDon);
                if(string.IsNullOrEmpty(res))
                {
                    MsgBox.Show("Tạo hoá đơn không thành công, vui lòng thử lại", MessageType.Error);
                    return;
                }
                var phong = cbxPhong.SelectedItem as DTO_Phong;
                var phieuKhamDaKhoa = new DTO_PKDaKhoa()
                {
                    NgayKham = DateTime.Now,
                    MaNhanVien = CurrentNV.MaNhanVien,
                    MaBenhNhan = benhNhan.MaBenhNhan
                };
                try
                {
                    var maPKDK = await BUSManager.PKDaKhoaBUS.AddPhieuKhamDaKhoaAsync(phieuKhamDaKhoa);
                    if (!string.IsNullOrEmpty(maPKDK))
                    {
                        MsgBox.Show("Đăng ký khám bệnh thành công", MessageType.Info);
                        if(dpkNgayKham.SelectedDate.Value.Date == DateTime.Now.Date)
                        {
                            ExaminedPatientList.Add(benhNhan);
                        }
                    }
                }
                catch (Exception e)
                {
                    MsgBox.Show(e.Message, MessageType.Error);
                }
                cbxDSBenhNhan.SelectedIndex = -1;
                cbxPhong.SelectedIndex = -1;
            });
        }
        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpkNgayKham.SelectedDate.HasValue)
            {
                var curDate = (sender as DatePicker).SelectedDate.Value;
                ExaminedPatientList = BUSManager.PKDaKhoaBUS.GetListBNByDate(curDate);
                lvDSKham.ItemsSource = ExaminedPatientList;
            }
        }
        private void cbxDSBenhNhan_KeyUp(object sender, KeyEventArgs e)
        {
            var Cmb = sender as ComboBox;
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Cmb.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(Cmb.Text))
                    return true;
                else
                {
                    return ((o as DTO_BenhNhan).HoTen.IndexOf(Cmb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
            });
            itemsViewOriginal.Refresh();
        }
        public bool RemovePatientSigned(DTO_BenhNhan bn)
        {
            return true;
        }

        private void btnThemBN_Click(object sender, RoutedEventArgs e)
        {
            wdBenhNhan wdbenhNhan = new wdBenhNhan(null, wdBenhNhan.Action.Add);
            wdbenhNhan.Closing += WdbenhNhan_Closing;
            wdbenhNhan.ShowDialog();
        }

        private void WdbenhNhan_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var wd = sender as wdBenhNhan;
            if (wd.BenhNhan != null)
                ListPatient.Add(wd.BenhNhan);
        }

        private void cbxPhong_KeyUp(object sender, KeyEventArgs e)
        {
            var Cmb = sender as ComboBox;
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Cmb.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(Cmb.Text))
                    return true;
                else
                {
                    return ((o as DTO_Phong).TenPhong.IndexOf(Cmb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
            });
            itemsViewOriginal.Refresh();
        }
    }
}
