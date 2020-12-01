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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
        public ObservableCollection<DTO_BenhNhan> CurSignedList { get; set; }
        public DTO_ThamSo thamSo { get; set; }
        public CollectionView ListDKView { get; set; }
        #endregion
        #region Command
        public ICommand AddPatientCommand { get; set; }
        public ICommand SignedCommand { get; set; }
        #endregion
        #region
        public event EventHandler PatientSigned;
        #endregion
        public async System.Threading.Tasks.Task InitDataAsync()
        {
            dpkNgayKham.SelectedDate = DateTime.Now;
            ListPatient = await BUSManager.BenhNhanBUS.GetListBNAsync();
            cbxDSBenhNhan.ItemsSource = ListPatient;
            //lvDSKham.ItemsSource = CurSignedList;
            ////Lọc danh sách khám theo ngày
            //PreLoadCurListBN();
            ////Khoi tao filter danh sach kham
            //ListDKView = (CollectionView)CollectionViewSource.GetDefaultView(ListBN1);
            //ListDKView.Filter = BenhNhanFilterDate;
            //Load tham so
            thamSo = BUSManager.ThamSoBUS.GetThamSoSoBNToiDa();
        }
        public void InitCommand()
        {

        }
        private bool BenhNhanFilterDate(Object item)
        {
            if (String.IsNullOrEmpty(dpkNgayKham.Text))
            {
                return false;
            }
            else
            {
                if (MatchBNList != null)
                    return (MatchBNList.Contains((item as DTO_BenhNhan).MaBenhNhan));
                return false;
            }
        }
        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dpkNgayKham.SelectedDate.HasValue)
            //{
            //    if (dpkNgayKham.SelectedDate.Value.ToString("d") == DateTime.Now.ToString("d"))
            //    {
            //        lvDSKham.ItemsSource = CurSignedList;
            //    }
            //    else
            //    {
            //        //lvDSKham.ItemsSource = ListBN1;
            //        RefreshList();
            //    }
            //}
        }
        private void RefreshList()
        {
            //MatchBNList = BUSManager.PhieuKhamBenhBUS.GetListPKB(dpkNgayKham.SelectedDate.Value.ToString("d"));
            ListDKView.Refresh();
        }
        private void DangKyKham(DTO_BenhNhan bn)
        {
            if (CheckConstraintMaxPatient())
            {
                if (CurSignedList.Contains(bn))
                {
                    MsgBox.Show("Bệnh nhân này đã được đăng ký", MessageType.Error);
                    return;
                }
                CurSignedList.Add(bn);
                if (PatientSigned != null)
                    PatientSigned(bn, new EventArgs());
            }
            else
                MsgBox.Show("Số lượt khám của hôm nay đã hết", MessageType.Error);
        }
        private bool CheckConstraintMaxPatient()
        {
            if (CurSignedList.Count < thamSo.GiaTri)
                return true;
            return false;
        }
        private void PreLoadCurListBN()
        {
            //var listBN = BUSManager.PhieuKhamBenhBUS.GetListPKB(DateTime.Now.ToString("d"));
            //foreach (var id in listBN)
            //{
            //    var bn = BUSManager.BenhNhanBUS.GetBenhNhanById(id);
            //    CurSignedList.Add(bn);
            //}
        }

        private void cbxDSBenhNhan_KeyUp(object sender, KeyEventArgs e)
        {
            //var Cmb = sender as ComboBox;
            //CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(Cmb.ItemsSource);

            //itemsViewOriginal.Filter = ((o) =>
            //{
            //    if (String.IsNullOrEmpty(Cmb.Text))
            //        return true;
            //    else
            //    {
            //        return ((o as DTO_BenhNhan).TenBenhNhan.IndexOf(Cmb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            //    }
            //});
            //itemsViewOriginal.Refresh();
        }
        public bool RemovePatientSigned(DTO_BenhNhan bn)
        {
            if (CurSignedList.Contains(bn))
            {
                return CurSignedList.Remove(bn);
            }
            else
            {
                return false;
            }

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
            ListPatient.Add(wd.BenhNhan);
        }

        private void cbxPhong_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
