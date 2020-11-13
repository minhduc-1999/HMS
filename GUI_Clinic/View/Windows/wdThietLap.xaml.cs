using BUS_Clinic.BUS;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdThietLap.xaml
    /// </summary>
    public partial class wdThietLap : Window
    {
        public wdThietLap()
        {
            InitializeComponent();
            InitCommand();
            InitData();
            this.DataContext = this;
        }
        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region Property
        public int TienKham { get; set; }
        public int SoBNToiDa { get; set; }
        #endregion
        private void InitData()
        {
            TienKham = BUSManager.ThamSoBUS.GetTienKham();
            SoBNToiDa = BUSManager.ThamSoBUS.GetSoBNToiDa();
        }
        private bool IsValueChanged(int curTienKham, int curBNMax)
        {
            if (curBNMax != BUSManager.ThamSoBUS.GetSoBNToiDa())
                return true;
            if (curTienKham != BUSManager.ThamSoBUS.GetTienKham())
                return true;
            return false;
        }
        private void InitCommand()
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (!IsValueChanged(TienKham, SoBNToiDa) ||
                    string.IsNullOrEmpty(tbxTienKham.Text) || tbxTienKham.Text == "0" ||
                    string.IsNullOrEmpty(tbxSoBNToiDa.Text) || tbxSoBNToiDa.Text == "0")
                    return false;
                return true;
            }, (p) =>
            {
                BUSManager.ThamSoBUS.UpdateThamSo(TienKham, SoBNToiDa);
                MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info);
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                    this.Close();
            });
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void tbxTienKham_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void tbxTienKham_Pasting(object sender, DataObjectPastingEventArgs e)
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
    }
}
