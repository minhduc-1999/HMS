﻿using BUS_Clinic.BUS;
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
        public DTO_PKDaKhoa phieuKhamBenh = new DTO_PKDaKhoa();
        private DTO_DonThuoc newDonThuoc = new DTO_DonThuoc();

        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_CachDung> ListCachDung { get; set; }
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }
        public ObservableCollection<DTO_YeuCau> ListYeuCau { get; set; }
        public ObservableCollection<DTO_CTDonThuoc> ListCTDonThuoc { get; set; }
        public ObservableCollection<DTO_DonThuoc> ListDonThuoc { get; set; }

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
            btnXuatDon.Content = "Đơn thuốc";

            BUSManager.PKDaKhoaBUS.LoadNPBenh(pkb);
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pkb);
            BUSManager.PKDaKhoaBUS.LoadNPDonThuoc(pkb);
            benhNhan = pkb.BenhNhan;
            tblTenBenhNhan.Text = benhNhan.HoTen;
            tblMaBenhNhan.Text = benhNhan.MaBenhNhan;
            tblNgayKham.Text = pkb.NgayKham.ToString();
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
                if (this.phieuKhamBenh.DonThuoc == null)
                {
                    newDonThuoc.MaDonThuoc = phieuKhamBenh.MaPKDK;
                    phieuKhamBenh.DonThuoc = newDonThuoc;
                    newDonThuoc.PKDaKhoa = phieuKhamBenh;
                    newDonThuoc.DS_CTDonThuoc = new ObservableCollection<DTO_CTDonThuoc>();
                }
                DTO_Thuoc newThuoc = cbxThuoc.SelectedItem as DTO_Thuoc;
                DTO_CachDung newCachDung = cbxCachDung.SelectedItem as DTO_CachDung;
                DTO_CTDonThuoc ctDonThuoc = new DTO_CTDonThuoc();
                ctDonThuoc.Thuoc = newThuoc;
                ctDonThuoc.MaThuoc = newThuoc.MaThuoc;
                ctDonThuoc.MaCachDung = newCachDung.MaCachDung;
                ctDonThuoc.SoLuong = Int32.Parse(tbxSoLuong.Text);
                ctDonThuoc.MaDonThuoc = newDonThuoc.MaDonThuoc;
                if (newDonThuoc.DS_CTDonThuoc.Count == 0)
                {
                    newDonThuoc.DS_CTDonThuoc.Add(ctDonThuoc);
                    ListCTDonThuoc.Add(ctDonThuoc);
                    lvThuoc.ItemsSource = ListCTDonThuoc;
                }
                else
                {
                    foreach (DTO_CTDonThuoc item in newDonThuoc.DS_CTDonThuoc)
                    {
                        if (item.MaThuoc == ctDonThuoc.MaThuoc)
                        {
                            item.SoLuong += Int32.Parse(tbxSoLuong.Text);
                            lvThuoc.ItemsSource = ListCTDonThuoc;
                        }
                        else
                        {
                            newDonThuoc.DS_CTDonThuoc.Add(ctDonThuoc);
                            ListCTDonThuoc.Add(ctDonThuoc);
                            lvThuoc.ItemsSource = ListCTDonThuoc;
                        }
                    }
                }
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
                //BUSManager.DonThuocBUS.AddDonThuoc(newDonThuoc);

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

            //ListCTPKB.Clear();
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

        private void btnXuatDon_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
