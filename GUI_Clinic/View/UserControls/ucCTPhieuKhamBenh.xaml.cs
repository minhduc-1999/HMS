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
    public partial class ucCTPhieuKhamBenh : UserControl
    {
        public ucCTPhieuKhamBenh()
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
        public void GetBenhNhan(DTO_BenhNhan bn)
        {
            EnablePKB();
            ResetPKB();
            IsSave = false;
            btnXuatDon.Content = "Xuất đơn thuốc";

            benhNhan = bn;
            tblTenBenhNhan.Text = bn.HoTen;
            tblMaBenhNhan.Text = bn.MaBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
            lvThuoc.ItemsSource = ListCTDonThuoc;
            cbxChanDoan.ItemsSource = ListBenh;
            cbxCachDung.ItemsSource = ListCachDung;
            cbxThuoc.ItemsSource = ListThuoc;

            phieuKhamBenh = new DTO_PKDaKhoa();
        }

        public void GetPKB(DTO_PKDaKhoa pkb)
        {
            ResetPKB();
            IsSave = true;
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pkb);
            BUSManager.PKDaKhoaBUS.LoadNPDonThuoc(pkb);
            BUSManager.DonThuocBUS.LoadNP_DSCTDonThuoc(pkb.DonThuoc);
            foreach (DTO_CTDonThuoc item in pkb.DonThuoc.DS_CTDonThuoc)
            {
                BUSManager.CTDonThuocBUS.LoadNPThuoc(item);
                BUSManager.CTDonThuocBUS.LoadNPCachDung(item);
            }
            benhNhan = pkb.BenhNhan;
            tblTenBenhNhan.Text = benhNhan.HoTen;
            tblMaBenhNhan.Text = benhNhan.MaBenhNhan;
            tblNgayKham.Text = pkb.NgayKham.ToString();
            if (pkb.DonThuoc != null)
            {
                lvThuoc.ItemsSource = pkb.DonThuoc.DS_CTDonThuoc;
                tbxLoiDan.Text = pkb.DonThuoc.LoiDan;
            }
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
            lvThuoc.ItemsSource = ListCTDonThuoc;
            cbxCachDung.ItemsSource = ListCachDung;
            cbxThuoc.ItemsSource = ListThuoc;
            cbxChanDoan.ItemsSource = ListBenh;
            
        }
        public void InitCommmand()
        {
            
            ThemThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(cbxThuoc.Text) ||
                    string.IsNullOrEmpty(tbxSoLuong.Text) || tbxSoLuong.Text == "0" ||
                    string.IsNullOrEmpty(cbxCachDung.Text) ||
                    IsSave == true)
                    return false;
                return true;
            },  (p) =>
            {
                ctDonThuoc = new DTO_CTDonThuoc();
                thuoc = cbxThuoc.SelectedItem as DTO_Thuoc;
                cachDung = cbxCachDung.SelectedItem as DTO_CachDung;
                ctDonThuoc.MaThuoc = thuoc.MaThuoc;
                ctDonThuoc.Thuoc = thuoc;
                ctDonThuoc.MaCachDung = cachDung.MaCachDung;
                ctDonThuoc.CachDung = cachDung;
                ctDonThuoc.SoLuong = Int32.Parse(tbxSoLuong.Text);
                ctDonThuoc.MaDonThuoc = phieuKhamBenh.MaPKDK;
                int temp = ListCTDonThuoc.Where(pk => pk.MaThuoc == ctDonThuoc.MaThuoc).Count();
                if (temp != 0)
                {
                    MsgBox.Show("Thuốc đã tồn tại trong đơn, vui lòng xóa đi nếu muốn nhập lại");
                    cbxThuoc.SelectedIndex = -1;
                    cbxCachDung.SelectedIndex = -1;
                    tbxSoLuong.Text = "0";
                }
                else
                {
                    ListCTDonThuoc.Add(ctDonThuoc);
                    cbxThuoc.SelectedIndex = -1;
                    cbxCachDung.SelectedIndex = -1;
                    tbxSoLuong.Text = "0";
                }
                //BUSManager.CTDonThuocBUS.LoadNPThuoc(ctDonThuoc);
                //BUSManager.CTDonThuocBUS.LoadNPCachDung(ctDonThuoc);
                lvThuoc.ItemsSource = ListCTDonThuoc;
            });

            InPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(cbxChanDoan.Text) ||
                    lvThuoc.Items == null ||
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
                    string.IsNullOrEmpty(cbxChanDoan.Text) ||
                    lvThuoc.Items == null)
                    return false;
                return true;
            }, async (p)  =>
            {

                if (IsSave == false)
                {       
                    if (this.phieuKhamBenh.DonThuoc == null)
                    {
                        newDonThuoc = new DTO_DonThuoc();
                        this.phieuKhamBenh.DonThuoc = newDonThuoc;
                        newDonThuoc.MaDonThuoc = phieuKhamBenh.MaPKDK;
                        newDonThuoc.LoiDan = tbxLoiDan.Text;
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
                        BUSManager.CTDonThuocBUS.AddCTDonThuoc(item);
                    }
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
            cbxChanDoan.IsHitTestVisible = false;
            tbxTrieuChung.IsHitTestVisible = false;
            tbxLoiDan.IsHitTestVisible = false;
            btnXuatDon.Visibility = Visibility.Collapsed;
            btnKhamChuyenKhoa.Visibility = Visibility.Collapsed;
            grdNhapThuoc.Visibility = Visibility.Collapsed;
        }

        private void EnablePKB()
        {
            cbxChanDoan.IsHitTestVisible = true;
            tbxTrieuChung.IsHitTestVisible = true;
            tbxLoiDan.IsHitTestVisible = true;
            btnXuatDon.Visibility = Visibility.Visible;
            grdNhapThuoc.Visibility = Visibility.Visible;
            btnKhamChuyenKhoa.Visibility = Visibility.Visible;
        }

        private void ResetPKB()
        {
            tblTenBenhNhan.Text = null;
            tblMaBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tbxTrieuChung.Clear();
            cbxChanDoan.SelectedIndex = -1;
            cbxThuoc.SelectedIndex = -1;
            cbxCachDung.SelectedIndex = -1;
            tbxSoLuong.Text="0";
            ListCTDonThuoc.Clear();
            lvThuoc.ItemsSource = null;
            tbxLoiDan.Clear();
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


         private void btnKhamChuyenKhoa_Click(object sender, RoutedEventArgs e)
        {
            wdYeuCauKhamChuyenKhoa wdYeuCau = new wdYeuCauKhamChuyenKhoa();
            wdYeuCau.benhNhan = this.benhNhan;
            wdYeuCau.Closing += WdYeuCau_Closing;
            wdYeuCau.ShowDialog();
        }

        private void WdYeuCau_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var wd = sender as wdYeuCauKhamChuyenKhoa;
            if (wd.yeuCau != null)
                ListYeuCau.Add(wd.yeuCau);
        }
    }
}
