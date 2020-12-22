using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdThietLap.xaml
    /// </summary>
    public partial class wdThietLap : Window
    {
        private ObservableCollection<DTO_ThamSo> thamSos;
        public wdThietLap()
        {
            InitializeComponent();
            InitCommand();
            InitDataAsync();
            this.DataContext = this;
        }
        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region Property
        public int TienKham { get; set; }
        public int SoBNToiDa { get; set; }
        public int TienKhamCK { get; set; }
        #endregion
        private async System.Threading.Tasks.Task InitDataAsync()
        {
            thamSos = await BUSManager.ThamSoBUS.GetListAsync();
            TienKham = thamSos.Where(ts => ts.TenThamSo == "Tiền khám").Select(ts => ts.GiaTri).FirstOrDefault();
            SoBNToiDa = thamSos.Where(ts => ts.TenThamSo == "Số bệnh nhân tối đa 1 ngày").Select(ts => ts.GiaTri).FirstOrDefault();
            TienKhamCK = thamSos.Where(ts => ts.TenThamSo == "Tiền Chụp X-Quang").Select(ts => ts.GiaTri).FirstOrDefault();
            tbxTienKhamCK.Text = TienKhamCK.ToString();
            tbxTienKham.Text = TienKham.ToString();
            tbxSoBNToiDa.Text = SoBNToiDa.ToString();
        }
        private bool IsValueChanged(int curTienKham, int curBNMax, int curTienKhamCK)
        {
            if (curBNMax != thamSos.Where(ts => ts.TenThamSo == "Số bệnh nhân tối đa 1 ngày").Select(ts => ts.GiaTri).FirstOrDefault())
                return true;
            if (curTienKham != thamSos.Where(ts => ts.TenThamSo == "Tiền khám").Select(ts => ts.GiaTri).FirstOrDefault())
                return true;
            if (curTienKhamCK != thamSos.Where(ts => ts.TenThamSo == "Tiền Chụp X-Quang").Select(ts => ts.GiaTri).FirstOrDefault())
                return true;
            return false;
        }
        private void InitCommand()
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (!IsValueChanged(TienKham, SoBNToiDa, TienKhamCK) ||
                    string.IsNullOrEmpty(tbxTienKham.Text) || tbxTienKham.Text == "0" ||
                    string.IsNullOrEmpty(tbxSoBNToiDa.Text) || tbxSoBNToiDa.Text == "0")
                    return false;
                return true;
            }, (p) =>
            {
                List<DTO_ThamSo> list = new List<DTO_ThamSo>()
                {
                    new DTO_ThamSo()
                    {
                        TenThamSo = "Số bệnh nhân tối đa 1 ngày",
                        GiaTri = SoBNToiDa
                    },
                    new DTO_ThamSo()
                    {
                        TenThamSo = "Tiền khám",
                        GiaTri = TienKham
                    },
                    new DTO_ThamSo()
                    {
                        TenThamSo = "Tiền Chụp X-Quang",
                        GiaTri = TienKhamCK
                    }
                };
                try
                {
                    BUSManager.ThamSoBUS.UpdateThamSo(list);
                    MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info, MessageButtons.Ok);

                }
                catch (Exception e)
                {
                    MsgBox.Show(e.Message, MessageType.Error, MessageButtons.Ok);
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
