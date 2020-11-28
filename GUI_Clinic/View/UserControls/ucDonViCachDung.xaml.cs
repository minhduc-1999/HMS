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

            InitDataAsync();
            InitCommand();

            //lvCachDung.ItemsSource = ListCD;
        }
        #region Property                
        public ObservableCollection<DTO_Benh> ListBenh { get; set; }
        public ObservableCollection<DTO_Phong> ListPhong { get; set; }
        public ObservableCollection<DTO_CachDung> ListCD { get; set; }
        public string TenBenhInput { get; set; }
        public string TenPhongInput { get; set; }
        public string TenCachDungInput { get; set; }
        //public CollectionView benhView { get; set; }
        #endregion
        #region Command
        public ICommand ThemBenhCommand { get; set; }
        //public ICommand XoaBenhCommand { get; set; }
        public ICommand SuaBenhCommand { get; set; }

        public ICommand ThemPhongCommand { get; set; }
        //public ICommand XoaDonViCommand { get; set; }
        public ICommand SuaPhongCommand { get; set; }

        public ICommand ThemCachDungCommand { get; set; }
        //public ICommand XoaCachDungCommand { get; set; }
        public ICommand SuaCachDungCommand { get; set; }
        #endregion
        public async Task InitDataAsync()
        {
            ListBenh = await BUSManager.BenhBUS.GetListBenhAsync();
            ListPhong = await BUSManager.PhongBUS.GetListPhongAsync();
            ListCD = await BUSManager.CachDungBUS.GetListCDAsync();

            lvBenh.ItemsSource = ListBenh;
            lvPhong.ItemsSource = ListPhong;
            lvCachDung.ItemsSource = ListCD;
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
            }, async (p) =>
            {
                
                DTO_Benh benh = new DTO_Benh();
                benh.TenBenh = tbxTenBenh.Text;
                var benhMoi = await BUSManager.BenhBUS.AddBenhAsync(benh);
                if (benhMoi != null)
                {
                    ListBenh.Add(benhMoi);
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
                DTO_Benh tempBenh = ListBenh.ElementAt(lvBenh.SelectedIndex);
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

            ThemPhongCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenPhongInput))
                    return false;
                return true;
            }, async (p) =>
            {
                DTO_Phong phong = new DTO_Phong();
                phong.TenPhong = tbxTenPhong.Text;
                var phongMoi = await BUSManager.PhongBUS.AddPhongAsync(phong);
                if (phongMoi != null)
                {
                    ListPhong.Add(phongMoi);
                    tbxTenPhong.Clear();
                }
                else
                {
                    MsgBox.Show("Tên phòng đã tồn tại", MessageType.Error);
                    tbxTenPhong.Clear();
                }
            });

            SuaPhongCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenPhongInput) || lvPhong.SelectedIndex == -1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                DTO_Phong tempPhong = ListPhong.ElementAt(lvPhong.SelectedIndex);
                if (!BUSManager.PhongBUS.UpdatePhong(tempPhong, TenPhongInput))
                {
                    MsgBox.Show("Tên phòng mới đã tồn tại", MessageType.Error);
                }
            });


            ThemCachDungCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(TenCachDungInput))
                    return false;
                return true;
            }, async (p) =>
            {
                DTO_CachDung cachDung = new DTO_CachDung();
                cachDung.TenCachDung = tbxTenCachDung.Text;
                var cachDungMoi = await BUSManager.CachDungBUS.AddCachDungAsync(cachDung);
                if (cachDungMoi != null)
                {
                    ListCD.Add(cachDungMoi);
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
                DTO_CachDung tempCachDung = ListCD.ElementAt(lvCachDung.SelectedIndex);
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
                TenBenhInput = ListBenh.ElementAt(lvBenh.SelectedIndex).TenBenh;
                tbxTenBenh.Text = TenBenhInput;
                //btnThemBenh.IsEnabled = false;
            }
            else
            {
                TenBenhInput = null;
                tbxTenBenh.Text = TenBenhInput;
            }
        }

        private void lvPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPhong.SelectedIndex != -1)
            {
                TenPhongInput = ListPhong.ElementAt(lvPhong.SelectedIndex).TenPhong;
                tbxTenPhong.Text = TenPhongInput;
            }
            else
            {
                TenPhongInput = null;
                tbxTenPhong.Text = TenPhongInput;
            }
        }

        private void lvCachDung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCachDung.SelectedIndex != -1)
            {
                TenCachDungInput = ListCD.ElementAt(lvCachDung.SelectedIndex).TenCachDung;
                tbxTenCachDung.Text = TenCachDungInput;
            }
            else
            {
                TenCachDungInput = null;
                tbxTenCachDung.Text = TenCachDungInput;
            }
        }

        private async void tbxTenBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(TenBenhInput) || lvBenh.SelectedIndex != -1)
                {
                    return;
                }

                DTO_Benh benh = new DTO_Benh();
                benh.TenBenh = tbxTenBenh.Text;
                var benhMoi = await BUSManager.BenhBUS.AddBenhAsync(benh);
                if (benhMoi != null)
                {
                    ListBenh.Add(benhMoi);
                    tbxTenBenh.Clear();
                    //benhView.Refresh();
                }
                else
                {
                    MsgBox.Show("Tên bệnh đã tồn tại", MessageType.Error);
                    tbxTenBenh.Clear();
                }
            }
        }

        private async void tbxTenPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(TenPhongInput) || lvPhong.SelectedIndex != -1)
                {
                    return;
                }

                DTO_Phong phong = new DTO_Phong();
                phong.TenPhong = tbxTenPhong.Text;
                var phongMoi = await BUSManager.PhongBUS.AddPhongAsync(phong);
                if (phongMoi != null)
                {
                    ListPhong.Add(phongMoi);
                    tbxTenPhong.Clear();
                    //benhView.Refresh();
                }
                else
                {
                    MsgBox.Show("Tên phòng đã tồn tại", MessageType.Error);
                    tbxTenPhong.Clear();
                }
            }
        }

        private async void tbxTenCachDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(TenCachDungInput) || lvCachDung.SelectedIndex != -1)
                {
                    return;
                }

                DTO_CachDung cachDung = new DTO_CachDung();
                cachDung.TenCachDung = tbxTenCachDung.Text;
                var cachDungMoi = await BUSManager.CachDungBUS.AddCachDungAsync(cachDung);
                if (cachDungMoi != null)
                {
                    ListCD.Add(cachDungMoi);
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
