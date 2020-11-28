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

            InitDataAsync();
            InitCommmand();
        }

        #region Property
        public int SoLuong { get; set; }
        private DTO_BenhNhan benhNhan = new DTO_BenhNhan();
        private DTO_PKDaKhoa phieuKhamBenh = new DTO_PKDaKhoa();
        public ObservableCollection<DTO_PKDaKhoa> ListCTPKB { get; set; }
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_CachDung> ListCachDung { get; set; }
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }

        private bool IsSave = false;
        #endregion

        #region Command
        public ICommand LuuPhieuKhamBenhCommand { get; set; }
        public ICommand ThemThuocCommand { get; set; }
        public ICommand InPhieuKhamCommand { get; set; }
        public ICommand ThanhToanPhieuKhamCommand { get; set; }
        #endregion

        #region Event
        public event EventHandler PKBAdded;
        #endregion
        public void GetBenhNhan(DTO_BenhNhan bn)
        {
            EnablePKB();
            ResetPKB();
            IsSave = false;
            btnThanhToan.Content = "Thanh toán";

            benhNhan = bn;
            tblTenBenhNhan.Text = bn.HoTen;
            tblMaBenhNhan.Text = bn.MaBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
            lvThuoc.ItemsSource = ListCTPKB;

            phieuKhamBenh = new DTO_PKDaKhoa();
        }

        public void GetPKB(DTO_PKDaKhoa pkb)
        {
            ResetPKB();
            IsSave = true;
            btnThanhToan.Content = "Hóa đơn";

            //BUSManager.PhieuKhamBenhBUS.LoadNPBenh(pkb);
            //BUSManager.PhieuKhamBenhBUS.LoadNPBenhNhan(pkb);
            //BUSManager.PhieuKhamBenhBUS.LoadNPDSCTPhieuKhamBenh(pkb);
            //foreach (DTO_CTPhieuKhamBenh item in pkb.DSCTPhieuKhamBenh)
            //{
            //    BUSManager.CTPhieuKhamBenhBUS.LoadNPThuoc(item);
            //    BUSManager.ThuocBUS.LoadNPDonVi(item.Thuoc);
            //    BUSManager.CTPhieuKhamBenhBUS.LoadNPCachDung(item);
            //}
            benhNhan = pkb.BenhNhan;
            tblTenBenhNhan.Text = benhNhan.HoTen;
            tblMaBenhNhan.Text = benhNhan.MaBenhNhan;
            tblNgayKham.Text = pkb.NgayKham.ToString();
            //lvThuoc.ItemsSource = pkb.DSCTPhieuKhamBenh;
            tbxTrieuChung.Text = pkb.TrieuChung;
            cbxChanDoan.Text = pkb.Benh.TenBenh;

            phieuKhamBenh = pkb;

            DisablePKB();
        }

        public async Task InitDataAsync()
        {
            ListThuoc = await BUSManager.ThuocBUS.GetListThuocAsync();
            ListCachDung = await BUSManager.CachDungBUS.GetListCDAsync();
            ListBenh = await BUSManager.BenhBUS.GetListBenhAsync();
           // ListCTPKB = new ObservableCollection<DTO_CTPhieuKhamBenh>();
            lvThuoc.ItemsSource = ListCTPKB;
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
            }, (p) =>
            {
                DTO_Thuoc newThuoc = cbxThuoc.SelectedItem as DTO_Thuoc;
                //if (BUSManager.ThuocBUS.CheckIfSoLuongThuocDu(newThuoc, SoLuong))
                //{
                //    DTO_CTPhieuKhamBenh cTPhieuKhamBenh = new DTO_CTPhieuKhamBenh(phieuKhamBenh.Id, newThuoc.Id, (cbxCachDung.SelectedItem as DTO_CachDung).Id, SoLuong, newThuoc.DonGia);
                //    BUSManager.ThuocBUS.LoadNPDonVi(newThuoc);
                //    cTPhieuKhamBenh.Thuoc = newThuoc;
                //    cTPhieuKhamBenh.CachDung = cbxCachDung.SelectedItem as DTO_CachDung;

                //    bool flag = true;
                //    foreach (DTO_CTPhieuKhamBenh item in ListCTPKB)
                //    {
                //        if (item.Thuoc.Id == cTPhieuKhamBenh.Thuoc.Id)
                //        {
                //            flag = false;
                //            break;
                //        }
                //    }
                //    if (flag)
                //    {
                //        ListCTPKB.Add(cTPhieuKhamBenh);
                //    }
                //    else
                //    {
                //        MsgBox.Show("Thuốc đã có trong danh sách", MessageType.Error, MessageButtons.Ok);
                //    }
                //    ResetThuocInput();
                //}
                //else
                //{
                //    MsgBox.Show("Số lượng thuốc còn lại trong kho không đủ");
                //}
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
                //wdPhieuKhamBenh wDPhieuKhamBenh = new wdPhieuKhamBenh(phieuKhamBenh);
                //wDPhieuKhamBenh.ShowDialog();
            });

            ThanhToanPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTrieuChung.Text) ||
                    string.IsNullOrEmpty(cbxChanDoan.Text) ||
                    lvThuoc.Items == null)
                    return false;
                return true;
            }, (p) =>
            {
                //if (IsSave == false)
                //{
                //    DTO_PKDaKhoa newPhieuKhamBenh = new DTO_PKDaKhoa(benhNhan.Id, DateTime.Now, (cbxChanDoan.SelectedItem as DTO_Benh).Id, tbxTrieuChung.Text);
                //    BUSManager.PhieuKhamBenhBUS.AddPhieuKhamBenh(newPhieuKhamBenh);
                //    foreach (DTO_CTPhieuKhamBenh item in ListCTPKB)
                //    {
                //        item.MaPKB = newPhieuKhamBenh.Id;
                //        BUSManager.ThuocBUS.SuDungThuoc(item.MaThuoc, item.SoLuong);
                //        DTO_BCSudungThuoc bCSudungThuoc = new DTO_BCSudungThuoc(item.MaThuoc, item.SoLuong, DateTime.Now);
                //        BUSManager.BCSuDungThuocBUS.AddBCSuDungThuoc(bCSudungThuoc);
                //        BUSManager.CTPhieuKhamBenhBUS.AddCTPhieuKhamBenh(item);
                //    }
                //    phieuKhamBenh = BUSManager.PhieuKhamBenhBUS.GetPhieuKhamBenh(newPhieuKhamBenh.Id);
                //    BUSManager.PhieuKhamBenhBUS.SaveChange();
                //    if (PKBAdded != null)
                //        PKBAdded(newPhieuKhamBenh, new EventArgs());

                //    DTO_HoaDon newHoaDon = new DTO_HoaDon(newPhieuKhamBenh);
                //    BUSManager.HoaDonBUS.XuatHoaDon(newHoaDon, newPhieuKhamBenh);
                //    DisablePKB();
                //    wdHoaDon hoaDon = new wdHoaDon(newHoaDon);
                //    hoaDon.ShowDialog();
                //}
                //else
                //{
                //    wdHoaDon hoaDon = new wdHoaDon(BUSManager.HoaDonBUS.GetHoaDonById(phieuKhamBenh.Id));
                //    hoaDon.ShowDialog();
                //}
                //IsSave = true;
            });
        }

        private void RemoveCategory(object sender, RoutedEventArgs e)
        {
            //if (IsSave == false)
            //{
            //    Button b = sender as Button;
            //    DTO_CTPhieuKhamBenh item = b.CommandParameter as DTO_CTPhieuKhamBenh;
            //    ListCTPKB.Remove(item);
            //}
            
        }
        private void ResetThuocInput()
        {
            cbxThuoc.SelectedIndex = -1;
            cbxCachDung.SelectedIndex = -1;
            tbxSoLuong.Clear();
        }
        private void DisablePKB()
        {
            cbxChanDoan.IsHitTestVisible = false;
            //tbxTrieuChung.IsEnabled = false;
            tbxTrieuChung.IsHitTestVisible = false;
            grdNhapThuoc.Visibility = Visibility.Collapsed;
        }

        private void EnablePKB()
        {
            cbxChanDoan.IsHitTestVisible = true;
            tbxTrieuChung.IsHitTestVisible = true;
            grdNhapThuoc.Visibility = Visibility.Visible;
        }

        private void ResetPKB()
        {
            tblTenBenhNhan.Text = null;
            tblMaBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tbxTrieuChung.Clear();
            cbxChanDoan.SelectedIndex = -1;

            ListCTPKB.Clear();
            lvThuoc.ItemsSource = null;
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
            wdYeuCauKhamChuyenKhoa wd = new wdYeuCauKhamChuyenKhoa();
            wd.ShowDialog();
        }

    }
}
