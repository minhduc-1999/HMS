﻿using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public static class BUSManager
    {
        private static BUS_BenhNhan _benhNhanBUS;
        private static BUS_NhanVien _nhanVienBUS;
        private static BUS_CachDung _cachDungBUS;
        private static BUS_Benh _benhBUS;
        private static BUS_Thuoc _thuocBUS;
        private static BUS_PhieuNhapThuoc _phieuNhapThuocBUS;
        private static BUS_CTPhieuNhapThuoc _cTPhieuNhapThuocBUS;
        private static BUS_BCSuDungThuoc _bcSuDungThuocBUS;
        private static BUS_BCDoanhThu _bcDoanhThuBUS;
        private static BUS_CTBaoCaoDoanhThu _cTBaoCaoDoanhThuBUS;
        private static BUS_HoaDon _hoaDonBUS;
        private static BUS_ThamSo _thamSoBUS;
        private static BUS_Account _accountBUS;
        private static BUS_Group _groupBUS;
        private static BUS_Phong _phongBUS;
        private static BUS_PKDaKhoa _pkDaKhoaBUS;
        private static BUS_PKChuyenKhoa _pkChuyenKhoaBUS;
        private static BUS_DonThuoc _donThuocBUS;
        private static BUS_CTDonThuoc _ctDonThuocBUS;
        private static BUS_CTHDThuoc _cTHDThuocBUS;
        public static BUS_PKChuyenKhoa PKChuyenKhoaBUS
        {
            get
            {
                if (_pkChuyenKhoaBUS == null)
                    _pkChuyenKhoaBUS = new BUS_PKChuyenKhoa();
                return _pkChuyenKhoaBUS;
            }
        }
        public static BUS_PKDaKhoa PKDaKhoaBUS
        {
            get
            {
                if (_pkDaKhoaBUS == null)
                    _pkDaKhoaBUS = new BUS_PKDaKhoa();
                return _pkDaKhoaBUS;
            }
        }
        public static BUS_BenhNhan BenhNhanBUS
        {
            get
            {
                if (_benhNhanBUS == null)
                    _benhNhanBUS = new BUS_BenhNhan();
                return _benhNhanBUS;
            }
        }

        public static BUS_NhanVien NhanVienBUS
        {
            get
            {
                if (_nhanVienBUS == null)
                    _nhanVienBUS = new BUS_NhanVien();
                return _nhanVienBUS;
            }
        }
        public static BUS_CachDung CachDungBUS
        {
            get
            {
                if (_cachDungBUS == null)
                    _cachDungBUS = new BUS_CachDung();
                return _cachDungBUS;
            }
        }

        public static BUS_Benh BenhBUS
        {
            get
            {
                if (_benhBUS == null)
                    _benhBUS = new BUS_Benh();
                return _benhBUS;
            }
        }

        public static BUS_Thuoc ThuocBUS
        {
            get
            {
                if (_thuocBUS == null)
                    _thuocBUS = new BUS_Thuoc();
                return _thuocBUS;
            }
        }

        public static BUS_PhieuNhapThuoc PhieuNhapThuocBUS
        {
            get
            {
                if (_phieuNhapThuocBUS == null)
                    _phieuNhapThuocBUS = new BUS_PhieuNhapThuoc();
                return _phieuNhapThuocBUS;
            }
        }

        public static BUS_CTPhieuNhapThuoc CTPhieuNhapThuocBUS
        {
            get
            {
                if (_cTPhieuNhapThuocBUS == null)
                    _cTPhieuNhapThuocBUS = new BUS_CTPhieuNhapThuoc();
                return _cTPhieuNhapThuocBUS;
            }
        }
        public static BUS_BCSuDungThuoc BCSuDungThuocBUS
        {
            get
            {
                if (_bcSuDungThuocBUS == null)
                    _bcSuDungThuocBUS = new BUS_BCSuDungThuoc();
                return _bcSuDungThuocBUS;
            }
        }

        public static BUS_BCDoanhThu BCDoanhThuBUS
        {
            get
            {
                if (_bcDoanhThuBUS == null)
                    _bcDoanhThuBUS = new BUS_BCDoanhThu();
                return _bcDoanhThuBUS;
            }
        }

        public static BUS_CTBaoCaoDoanhThu CTBaoCaoDoanhThuBUS
        {
            get
            {
                if (_cTBaoCaoDoanhThuBUS == null)
                    _cTBaoCaoDoanhThuBUS = new BUS_CTBaoCaoDoanhThu();
                return _cTBaoCaoDoanhThuBUS;
            }
        }

        public static BUS_HoaDon HoaDonBUS
        {
            get
            {
                if (_hoaDonBUS == null)
                    _hoaDonBUS = new BUS_HoaDon();
                return _hoaDonBUS;
            }
        }

        public static BUS_ThamSo ThamSoBUS
        {
            get
            {
                if (_thamSoBUS == null)
                    _thamSoBUS = new BUS_ThamSo();
                return _thamSoBUS;
            }
        }

        public static BUS_Account AccountBUS
        {
            get
            {
                if (_accountBUS == null)
                    _accountBUS = new BUS_Account();
                return _accountBUS;
            }
        }

        public static BUS_Group GroupBUS
        {
            get
            {
                if (_groupBUS == null)
                    _groupBUS = new BUS_Group();
                return _groupBUS;
            }
        }

        public static BUS_Phong PhongBUS
        {
            get
            {
                if (_phongBUS == null)
                    _phongBUS = new BUS_Phong();
                return _phongBUS;
            }
        }

        public static BUS_DonThuoc DonThuocBUS
        {
            get
            {
                if (_donThuocBUS == null)
                    _donThuocBUS = new BUS_DonThuoc();
                return _donThuocBUS;
            }
        }

        public static BUS_CTDonThuoc CTDonThuocBUS
        {
            get
            {
                if (_ctDonThuocBUS == null)
                    _ctDonThuocBUS = new BUS_CTDonThuoc();
                return _ctDonThuocBUS;
            }
        }

        public static BUS_CTHDThuoc CTHDThuocBUS
        {
            get
            {
                if (_cTHDThuocBUS == null)
                    _cTHDThuocBUS = new BUS_CTHDThuoc();
                return _cTHDThuocBUS;
            }
        }
    }
}
