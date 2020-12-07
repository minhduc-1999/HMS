using BUS_Clinic.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using GUI_Clinic.Command;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DTO_Clinic.Form;
using System.Windows.Data;
using GUI_Clinic.View.Windows;
using DTO_Clinic.Person;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucBaoCaoDoanhThu.xaml
    /// </summary>
    public partial class ucBaoCaoDoanhThu : UserControl
    {
        public DTO_NhanVien CurrentNhanVien { get; set; }
        public ucBaoCaoDoanhThu()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();
            InitCommand();
        }

        #region Property
        public DTO_BCDoanhThu BCDoanhThu { get; set; }
        public List<int> ListThang { get; set; }
        public List<int> ListNam { get; set; }

        #endregion

        #region Command
        public ICommand FilterBaoCaoCommand { get; set; }
        public ICommand InBaoCaoCommand { get; set; }
        #endregion

        public void InitData()
        {
            ListThang = Enumerable.Range(1, 12).ToList();
            cbxThang.ItemsSource = ListThang;
            cbxThang.SelectedIndex = DateTime.Now.Month - 1;
            var curYear = DateTime.Now.Year;
            ListNam = Enumerable.Range(2000, curYear - 2000 + 1).ToList();
            cbxNam.ItemsSource = ListNam;
            cbxNam.SelectedIndex = DateTime.Now.Year - 2000;

            BCDoanhThu = null;
        }

        public void InitCommand()
        {
            FilterBaoCaoCommand = new RelayCommand<Window>((p) =>
            {
                if (String.IsNullOrEmpty(cbxThang.Text) ||
                    String.IsNullOrEmpty(cbxNam.Text))
                    return false;
                if (BCDoanhThu != null)
                {
                    if (cbxThang.Text == BCDoanhThu.Thang.ToString() && cbxNam.Text == BCDoanhThu.Nam.ToString() 
                    && cbxThang.Text != DateTime.Now.Month.ToString()
                    && cbxNam.Text != DateTime.Now.Year.ToString())
                    {
                        return false;
                    }
                }
                return true;
            }, (p) =>
            {
                var month = Convert.ToInt32(cbxThang.Text);
                var year = Convert.ToInt32(cbxNam.Text);
                BCDoanhThu = BUSManager.BCDoanhThuBUS.GetBCDoanhThu(month, year);
                if (BCDoanhThu != null)
                {
                    lvCTBaoCaoDoanhThu.ItemsSource = BCDoanhThu.DS_CTBaoCaoDoanhThu;
                    crdTongDoanhThu.Visibility = Visibility.Visible;
                    var binding = new Binding
                    {
                        Source = BCDoanhThu,
                        Path = new PropertyPath("TongDoanhThu"),
                        StringFormat = "{0:N0} VNĐ"
                    };
                    tblTongDoanhThu.SetBinding(TextBlock.TextProperty, binding);
                }
                else
                {
                    crdTongDoanhThu.Visibility = Visibility.Collapsed;
                }

            });
            InBaoCaoCommand = new RelayCommand<Window>((p) =>
            {
                if (String.IsNullOrEmpty(cbxThang.Text) ||
                    String.IsNullOrEmpty(cbxNam.Text) ||
                    BCDoanhThu == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                wdInBaoCaoDoanhThu baoCaoDoanhThu = new wdInBaoCaoDoanhThu(BCDoanhThu, CurrentNhanVien);
                baoCaoDoanhThu.ShowDialog();
            });
        }
    }
}
