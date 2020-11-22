using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Component;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDonViCachDung.xaml
    /// </summary>
    public partial class ucDonViCachDung : UserControl
    {
        public ucDonViCachDung()
        {
            InitializeComponent();
            this.DataContext = this;

            InitData();
            InitCommand();
        }
        #region Property                
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }
        public ObservableCollection<DTO_CachDung> ListCD { get; set; }
        public string TenBenhInput { get; set; }
        public string TenDonViInput { get; set; }
        public string TenCachDungInput { get; set; }
        //public CollectionView benhView { get; set; }
        #endregion
        #region Command
        public ICommand ThemBenhCommand { get; set; }
        //public ICommand XoaBenhCommand { get; set; }
        public ICommand SuaBenhCommand { get; set; }

        public ICommand ThemDonViCommand { get; set; }
        //public ICommand XoaDonViCommand { get; set; }
        public ICommand SuaDonViCommand { get; set; }

        public ICommand ThemCachDungCommand { get; set; }
        //public ICommand XoaCachDungCommand { get; set; }
        public ICommand SuaCachDungCommand { get; set; }
        #endregion
        public void InitData()
        {
            ListBenh = BUSManager.BenhBUS.GetListBenh();
            ListCD = BUSManager.CachDungBUS.GetListCD();
            //benhView = (CollectionView)CollectionViewSource.GetDefaultView(ListBenh);
            //benhView.Filter = BUSManager.BenhBUS.BenhFilter;
        }
        public void InitCommand()
        {
            ThemBenhCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenBenhInput))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_Benh benh = new DTO_Benh();
                if (BUSManager.BenhBUS.AddBenh(benh))
                {
                    tbxTenBenh.Clear();
                    //benhView.Refresh();
                }
                else
                {
                    MsgBox.Show("Tên bệnh đã tồn tại", MessageType.Error);
                    tbxTenBenh.Clear();
                }
            });

            SuaBenhCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenBenhInput) || lvBenh.SelectedIndex == -1)
                {
                    return false;
                }
                //benhView.Refresh();
                return true;
            }, (p) =>
            {
                DTO_Benh tempBenh = ListBenh.ElementAt<DTO_Benh>(lvBenh.SelectedIndex);
                if (!BUSManager.BenhBUS.UpdateBenh(tempBenh, TenBenhInput))
                {
                    MsgBox.Show("Tên bệnh mới đã tồn tại", MessageType.Error);
                }    
            });

            //XoaBenhCommand = new RelayCommand<Window>((p) =>
            //{
            //    if (string.IsNullOrEmpty(TenBenhInput) || lvBenh.SelectedIndex == -1)
            //        return false;
            //    return true;
            //}, (p) =>
            //{
            //    ObservableCollection<DTO_Benh> listBenhXoa = new ObservableCollection<DTO_Benh>();
            //    foreach (DTO_Benh item in lvBenh.SelectedItems)
            //    {
            //        listBenhXoa.Add(item);
            //    }

            //    foreach (DTO_Benh item in listBenhXoa)
            //    {
            //        BUSManager.BenhBUS.Delbenh(item);
            //        benhView.Refresh();
            //    }
            //});

            ThemDonViCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenDonViInput))
                    return false;
                return true;
            }, (p) =>
            {
               
            });

            SuaDonViCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenDonViInput) || lvDonVi.SelectedIndex == -1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                   
            });

            //XoaDonViCommand = new RelayCommand<Window>((p) =>
            //{
            //    if (string.IsNullOrEmpty(TenDonViInput) || lvDonVi.SelectedIndex == -1)
            //        return false;
            //    return true;
            //}, (p) =>
            //{
            //    ObservableCollection<DTO_DonVi> listDonViXoa = new ObservableCollection<DTO_DonVi>();
            //    foreach (DTO_DonVi item in lvDonVi.SelectedItems)
            //    {
            //        listDonViXoa.Add(item);
            //    }

            //    foreach (DTO_DonVi item in listDonViXoa)
            //    {
            //        BUSManager.DonViBUS.DelDonVi(item);
            //    }
            //});


            ThemCachDungCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenCachDungInput))
                    return false;
                return true;
            }, (p) =>
            {
                DTO_CachDung cachDung = new DTO_CachDung();
                if (BUSManager.CachDungBUS.AddCachDung(cachDung))
                {
                    tbxTenCachDung.Clear();
                }
                else
                {
                    MsgBox.Show("Tên cách dùng đã tồn tại", MessageType.Error);
                    tbxTenCachDung.Clear();
                }    
            });

            SuaCachDungCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenCachDungInput) || lvCachDung.SelectedIndex == -1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                DTO_CachDung tempCachDung = ListCD.ElementAt<DTO_CachDung>(lvCachDung.SelectedIndex);
                if (!BUSManager.CachDungBUS.UpdateCachDung(tempCachDung, TenCachDungInput))
                {
                    MsgBox.Show("Tên cách dùng mới đã tồn tại", MessageType.Error);
                }    
            });

            //XoaCachDungCommand = new RelayCommand<Window>((p) =>
            //{
            //    if (string.IsNullOrEmpty(TenCachDungInput) || lvCachDung.SelectedIndex == -1)
            //        return false;
            //    return true;
            //}, (p) =>
            //{
            //    ObservableCollection<DTO_CachDung> listCachDungXoa = new ObservableCollection<DTO_CachDung>();
            //    foreach (DTO_CachDung item in lvCachDung.SelectedItems)
            //    {
            //        listCachDungXoa.Add(item);
            //    }

            //    foreach (DTO_CachDung item in listCachDungXoa)
            //    {
            //        BUSManager.CachDungBUS.DelCachDung(item);
            //    }
            //});
        }

        private void lvBenh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBenh.SelectedIndex != -1)
            {
                TenBenhInput = ListBenh.ElementAt<DTO_Benh>(lvBenh.SelectedIndex).TenBenh;
                tbxTenBenh.Text = TenBenhInput;
            }
            else
            {
                TenBenhInput = null;
                tbxTenBenh.Text = TenBenhInput;
            }
        }

        private void lvDonVi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void lvCachDung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCachDung.SelectedIndex != -1)
            {
                TenCachDungInput = ListCD.ElementAt<DTO_CachDung>(lvCachDung.SelectedIndex).TenCachDung;
                tbxTenCachDung.Text = TenCachDungInput;
            }
            else
            {
                TenCachDungInput = null;
                tbxTenCachDung.Text = TenCachDungInput;
            }
        }

        private void tbxTenBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(TenBenhInput))
                {
                    return;
                }

                DTO_Benh benh = new DTO_Benh();
                if (BUSManager.BenhBUS.AddBenh(benh))
                {
                    //benhView.Refresh();
                    tbxTenBenh.Clear();
                }
                else
                {
                    MsgBox.Show("Tên bệnh đã tồn tại", MessageType.Error);
                    tbxTenBenh.Clear();
                }
            }
        }

        private void tbxTenDonVi_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxTenCachDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(TenCachDungInput))
                {
                    return;
                }

                DTO_CachDung cachDung = new DTO_CachDung();
                if (BUSManager.CachDungBUS.AddCachDung(cachDung))
                {
                    tbxTenCachDung.Clear();
                }
                else
                {
                    MsgBox.Show("Tên cách dùng đã tồn tại", MessageType.Error);
                    tbxTenCachDung.Clear();
                }
            }
        }
    }
}
