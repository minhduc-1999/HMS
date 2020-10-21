using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using GUI_Clinic.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucBaoCaoSuDungThuoc.xaml
    /// </summary>
    public partial class ucBaoCaoSuDungThuoc : UserControl
    {
        public ucBaoCaoSuDungThuoc()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();
            InitCommand();
        }

        #region Property
        private ObservableCollection<DTO_BCSudungThuoc> ListBCSDT { get; set; }
        private List<int> ListThang { get; set; }
        private List<int> ListNam { get; set; }

        private CollectionView viewBC { get; set;}
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
            ListNam = Enumerable.Range(1950, 100).ToList();
            cbxNam.ItemsSource = ListNam;
            cbxNam.SelectedIndex = DateTime.Now.Year - 1950;

            ListBCSDT = BUSManager.BCSuDungThuocBUS.GetListBCSuDungThuoc();
            lvBCSDT.ItemsSource = ListBCSDT;
        }

        public void InitCommand()
        {
            FilterBaoCaoCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                viewBC = (CollectionView)CollectionViewSource.GetDefaultView(ListBCSDT);
                viewBC.Filter = BCSuDungThuocFilter;
            });
            InBaoCaoCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                wdInBaoCaoSuDungThuoc baoCaoSuDungThuoc = new wdInBaoCaoSuDungThuoc(ListBCSDT.Where(c => c.Nam == (cbxNam.SelectedIndex + 1950) && c.Thang == (cbxThang.SelectedIndex + 1)).ToList(), cbxThang.SelectedIndex + 1, cbxNam.SelectedIndex + 1950);
                baoCaoSuDungThuoc.ShowDialog();
            });
        }

        private bool BCSuDungThuocFilter(Object item)
        {
            if (ListBCSDT != null)
                return ((item as DTO_BCSudungThuoc).Thang == int.Parse(cbxThang.Text) &&
                        (item as DTO_BCSudungThuoc).Nam == int.Parse(cbxNam.Text));
            return false;
        }
    }
}
