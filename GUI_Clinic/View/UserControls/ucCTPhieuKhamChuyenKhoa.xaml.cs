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
            InitCommmand();
        }

        #region Property
        public DTO_PKChuyenKhoa phieuKhamChuyenKhoa { get; set; }

        public DTO_NhanVien CurrentNV { get; set; }
        private bool IsSave = false;
        #endregion

        #region Command
        public ICommand InPhieuKhamCommand { get; set; }
        public ICommand LuuPhieuKhamCommand { get; set; }
        #endregion

        #region Event
        public event EventHandler Finish;
        #endregion

        public void GetNewPKCK(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            EnablePKB();
            ResetPKB();
            IsSave = false;
            BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(pKChuyenKhoa);
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pKChuyenKhoa.PhieuKhamDaKhoa);
            tblTenBenhNhan.Text = pKChuyenKhoa.PhieuKhamDaKhoa.BenhNhan.HoTen;
            tblMaBenhNhan.Text = pKChuyenKhoa.PhieuKhamDaKhoa.BenhNhan.MaBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
            tblMaPKDK.Text = pKChuyenKhoa.PhieuKhamDaKhoa.MaPKDK;
            tblYeuCauKhamChuyenKhoa.Text = pKChuyenKhoa.YeuCau;
            phieuKhamChuyenKhoa = pKChuyenKhoa;
        }

        public void GetPKCK(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            ResetPKB();
            IsSave = true;
            BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(pKChuyenKhoa);
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pKChuyenKhoa.PhieuKhamDaKhoa);
            tblTenBenhNhan.Text = pKChuyenKhoa.PhieuKhamDaKhoa.BenhNhan.HoTen;
            tblMaBenhNhan.Text = pKChuyenKhoa.PhieuKhamDaKhoa.BenhNhan.MaBenhNhan;
            tblNgayKham.Text = DateTime.Now.ToString();
            tblMaPKDK.Text = pKChuyenKhoa.PhieuKhamDaKhoa.MaPKDK;
            tblYeuCauKhamChuyenKhoa.Text = pKChuyenKhoa.YeuCau;
            tbxKetQuaKhamChuyenKhoa.Text = pKChuyenKhoa.KetQua;
            phieuKhamChuyenKhoa = pKChuyenKhoa;
            DisablePKB();
        }

        public void InitCommmand()
        {

            InPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (tbxKetQuaKhamChuyenKhoa.Text == "")
                    return false;
                return true;
            }, (p) =>
            {

                phieuKhamChuyenKhoa.KetQua = tbxKetQuaKhamChuyenKhoa.Text;
                wdPhieuKhamChuyenKhoa wdPhieuKhamChuyenKhoa = new wdPhieuKhamChuyenKhoa(phieuKhamChuyenKhoa);
                wdPhieuKhamChuyenKhoa.ShowDialog();
            });
            LuuPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (tbxKetQuaKhamChuyenKhoa.Text == "" || IsSave == true)
                    return false;
                return true;
            }, async (p) =>
            {
                if (IsSave == false)
                    if (MsgBox.Show1("Xác nhận lưu kết quả?", MessageType.Info, MessageButtons.YesNo))
                    {
                        phieuKhamChuyenKhoa.KetQua = tbxKetQuaKhamChuyenKhoa.Text;
                        phieuKhamChuyenKhoa.MaBacSi = CurrentNV.MaNhanVien;
                        BUSManager.PKChuyenKhoaBUS.UpdatePKCK(phieuKhamChuyenKhoa);
                        Finish(phieuKhamChuyenKhoa, new EventArgs());
                        IsSave = true;
                    }
            });
        }


        private void DisablePKB()
        {
            btnLuu.Visibility = Visibility.Collapsed;

            tbxKetQuaKhamChuyenKhoa.IsHitTestVisible = false;
        }

        private void EnablePKB()
        {
            btnLuu.Visibility = Visibility.Visible;
            tbxKetQuaKhamChuyenKhoa.IsHitTestVisible = true;
        }

        private void ResetPKB()
        {
            tblTenBenhNhan.Text = null;
            tblMaBenhNhan.Text = null;
            tblNgayKham.Text = null;
            tblMaPKDK.Text = null;
            tblYeuCauKhamChuyenKhoa.Text = null;
            tbxKetQuaKhamChuyenKhoa.Text = "";
        }
    }
}
