using BUS_Clinic.BUS;
using DTO_Clinic.Permission;
using DTO_Clinic.Person;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
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

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdTaiKhoan.xaml
    /// </summary>
    public partial class wdTaiKhoan : Window
    {
        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region
        public ObservableCollection<DTO_NhanVien> ListNV { get; set; }
        public DTO_Account currentAcc { get; set; }
        public DTO_Account newAcc { get; set; }
        #endregion
        public wdTaiKhoan(DTO_Account acc)
        {
            InitializeComponent();
            this.DataContext = this;
            btnCapNhat.Content = "Cập nhật";
            InitCommand();
            currentAcc = acc;
        }
        public wdTaiKhoan(ObservableCollection<DTO_NhanVien> listNV)
        {
            InitializeComponent();
            ListNV = listNV;
            newAcc = new DTO_Account();
            btnCapNhat.Content = "Đăng ký";
            this.DataContext = this;
            InitCreateNewAccCommand();
        }

        private bool IsHasDifference()
        {
            bool rel = currentAcc.Username == tbxUsername.Text
                && currentAcc.Password == tbxPassword.Text;
            return !rel;
        }

        private void InitCommand()
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxUsername.Text) ||
                   string.IsNullOrEmpty(tbxPassword.Text))
                    return false;
                if (!IsHasDifference())
                    return false;
                return true;
            }, (p) =>
            {
                if (BUSManager.AccountBUS.UpdateInfoAcc(currentAcc, tbxUsername.Text, tbxPassword.Text))
                {
                    MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info);
                    this.Close();
                }
                else
                {
                    MsgBox.Show("Tài khoản này đã tồn tại", MessageType.Error);
                }
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                this.Close();
            });
        }

        private void InitCreateNewAccCommand()
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxUsername.Text) ||
                   string.IsNullOrEmpty(tbxPassword.Text))
                    return false;
                return true;
            }, (p) =>
            {
                newAcc.Username = tbxUsername.Text;
                newAcc.Password = tbxPassword.Text;
                if (!BUSManager.AccountBUS.IsAccDaTonTai(newAcc))
                {
                    wdNhanVien newNhanVien = new wdNhanVien(newAcc, ListNV);
                    newNhanVien.ShowDialog();
                    this.Close();
                }
                else
                {
                    MsgBox.Show("Tên tài khoản đã tồn tại", MessageType.Error);
                }
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                this.Close();
            });
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
