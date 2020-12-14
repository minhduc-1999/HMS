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
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ucCTPhieuKhamBenh.xaml
    /// </summary>
    public partial class ucCTPhieuKhamChuyenKhoa : UserControl
    {
        public ucCTPhieuKhamChuyenKhoa()
        {
            InitializeComponent();
            this.DataContext = this;
            DisablePKB();
            InitDataAsync();
            InitCommmand();
        }

        #region Property
        private DTO_BenhNhan benhNhan { get; set; }
        public DTO_PKDaKhoa phieuKhamBenh { get; set; }
        private DTO_DonThuoc newDonThuoc { get; set; }
        private DTO_Thuoc thuoc { get; set; }
        private DTO_CachDung cachDung { get; set; }
        private DTO_CTDonThuoc ctDonThuoc { get; set; }

        public DTO_NhanVien CurrentNV { get; set; }
        public ucDanhSachKhamChuyenKhoa _ucDanhSachKhamChuyenKhoa { get; set; }


        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_CachDung> ListCachDung { get; set; }
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }
        public ObservableCollection<DTO_YeuCau> ListYeuCau { get; set; }
        public ObservableCollection<DTO_CTDonThuoc> ListCTDonThuoc { get; set; }
        public ObservableCollection<DTO_DonThuoc> ListDonThuoc { get; set; }

        private bool IsSave = false;
        #endregion

        #region Command
        public ICommand ThemThuocCommand { get; set; }
        public ICommand InPhieuKhamCommand { get; set; }
        public ICommand XuatDonThuocCommand { get; set; }
        #endregion

        #region Event
        public event EventHandler Finish;
        #endregion

        public void setUCDSKCK(ucDanhSachKhamChuyenKhoa uc)
        {
            _ucDanhSachKhamChuyenKhoa = uc;
        }
        public void GetBenhNhan(DTO_BenhNhan bn)
        {
            EnablePKB();
            ResetPKB();
            IsSave = false;

            benhNhan = bn;
            tblTenBenhNhan.Text = bn.HoTen;
            tblMaBenhNhan.Text = bn.MaBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
            cbxChanDoan.ItemsSource = ListBenh;
            phieuKhamBenh = new DTO_PKDaKhoa();
        }

        public void GetPKB(DTO_PKDaKhoa pkb)
        {
            ResetPKB();
            IsSave = true;
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pkb);
            BUSManager.PKDaKhoaBUS.LoadNPDonThuoc(pkb);
            BUSManager.DonThuocBUS.LoadNP_DSCTDonThuoc(pkb.DonThuoc);
            if (pkb.DonThuoc != null)
            {
                foreach (DTO_CTDonThuoc item in pkb.DonThuoc.DS_CTDonThuoc)
                {
                    BUSManager.CTDonThuocBUS.LoadNPThuoc(item);
                    BUSManager.CTDonThuocBUS.LoadNPCachDung(item);
                }
            }
            benhNhan = pkb.BenhNhan;
            tblTenBenhNhan.Text = benhNhan.HoTen;
            tblMaBenhNhan.Text = benhNhan.MaBenhNhan;
            tblNgayKham.Text = pkb.NgayKham.ToString();
            if (pkb.DonThuoc != null)
            cbxChanDoan.Text = pkb.ChanDoan;
            tbxTrieuChung.Text = pkb.TrieuChung;
            phieuKhamBenh = pkb;
            DisablePKB();
        }

        public async Task InitDataAsync()
        {
            ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            ListCachDung = await BUSManager.CachDungBUS.GetListCDAsync();
            ListBenh = await BUSManager.BenhBUS.GetListBenhAsync();
            ListYeuCau = new ObservableCollection<DTO_YeuCau>();
            ListCTDonThuoc = new ObservableCollection<DTO_CTDonThuoc>();
            cbxChanDoan.ItemsSource = ListBenh;

        }
        public void InitCommmand()
        {

            InPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(cbxChanDoan.Text) ||
                    IsSave == false)
                    return false;
                return true;
            }, (p) =>
            {
                wdPhieuKhamBenh wDPhieuKhamBenh = new wdPhieuKhamBenh(phieuKhamBenh);
                wDPhieuKhamBenh.ShowDialog();
            });
            XuatDonThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(cbxChanDoan.Text))
                    return false;
                return true;
            }, async (p) =>
            {

                if (IsSave == false)
                {
                    if (this.phieuKhamBenh.DonThuoc == null)
                    {
                        newDonThuoc = new DTO_DonThuoc();
                        this.phieuKhamBenh.DonThuoc = newDonThuoc;
                        newDonThuoc.MaDonThuoc = phieuKhamBenh.MaPKDK;
                        phieuKhamBenh.ChanDoan = cbxChanDoan.Text;
                        phieuKhamBenh.TrieuChung = tbxTrieuChung.Text;
                        phieuKhamBenh.MaBacSi = CurrentNV.MaNhanVien;
                        BUSManager.PKDaKhoaBUS.UpdatePKDK(phieuKhamBenh);
                    }
                    if (newDonThuoc.MaDonThuoc != null)
                        await BUSManager.DonThuocBUS.AddDonThuocAsync(newDonThuoc);
                    foreach (DTO_CTDonThuoc item in ListCTDonThuoc)
                    {
                        item.CachDung = null;
                        item.DonThuoc = null;
                        item.Thuoc = null;
                        BUSManager.CTDonThuocBUS.AddCTDonThuoc(item);
                    }
                    wdPhieuKhamBenh wDPhieuKhamBenh = new wdPhieuKhamBenh(phieuKhamBenh);
                    wDPhieuKhamBenh.ShowDialog();
                    ResetPKB();
                    Finish(benhNhan, new EventArgs());
                }
                IsSave = true;

            });
        }

        private void RemoveCategory(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            DTO_CTDonThuoc item = b.CommandParameter as DTO_CTDonThuoc;
            ListCTDonThuoc.Remove(item);
        }

        private void DisablePKB()
        {

        }

        private void EnablePKB()
        {
        
        }

        private void ResetPKB()
        {
            tblTenBenhNhan.Text = null;
            tblMaBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tbxTrieuChung.Clear();
            cbxChanDoan.SelectedIndex = -1;
        }
        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void tbxSoLuong_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void tbxSoLuong_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }



    }
}
