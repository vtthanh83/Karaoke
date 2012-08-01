using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class QuyenTruycap
    {
        private int _IDQuyentruycap;
        public int IDQuyentruycap
        {
            get { return _IDQuyentruycap; }
            set { _IDQuyentruycap = value; }
        }
        private DateTime _Ngaythietlap;
        public DateTime Ngaythietlap
        {
            get { return _Ngaythietlap; }
            set { _Ngaythietlap = value; }
        }
        private string _TenLoaiNV;
        public string TenLoaiNV
        {
            get { return _TenLoaiNV; }
            set { _TenLoaiNV = value; }
        }
        private int _Vanhanh;
        public int Vanhanh
        {
            get { return _Vanhanh; }
            set { _Vanhanh = value; }
        }
        private int _HoadonNhap;
        public int HoadonNhap
        {
            get { return _HoadonNhap; }
            set { _HoadonNhap = value; }
        }
        private int _Setting;
        public int Setting
        {
            get { return _Setting; }
            set { _Setting = value; }
        }
        private int _Nhanvien;
        public int Nhanvien
        {
            get { return _Nhanvien; }
            set { _Nhanvien = value; }
        }
        private int _HoadonxuatSP;
        public int HoadonxuatSP
        {
            get { return _HoadonxuatSP; }
            set { _HoadonxuatSP = value; }
        }
        private int _Sanpham;
        public int Sanpham
        {
            get { return _Sanpham; }
            set { _Sanpham = value; }
        }
        private int _Phong;
        public int Phong
        {
            get { return _Phong; }
            set { _Phong = value; }
        }
        private int _Report;
        public int Report
        {
            get { return _Report; }
            set { _Report = value; }
        }
        private int _Khachhang;
        public int Khachhang
        {
            get { return _Khachhang; }
            set { _Khachhang = value; }
        }
        private int _Khuyenmai;
        public int Khuyenmai
        {
            get { return _Khuyenmai; }
            set { _Khuyenmai = value; }
        }
        private int _Tonkho;
        public int Tonkho
        {
            get { return _Tonkho; }
            set { _Tonkho = value; }
        }

        public QuyenTruycap()
        {
            this._IDQuyentruycap = -1;
            this._TenLoaiNV = "";
            this._Ngaythietlap = DateTime.Now.Date;
            this._Vanhanh = 0;
            this._HoadonNhap = 0;
            this._Setting = 0;
            this._Nhanvien = 0;
            this._HoadonxuatSP = 0;
            this._Sanpham = 0;
            this._Phong = 0;
            this._Report = 0;
            this._Khachhang = 0;
            this._Khuyenmai = 0;
            this._Tonkho = 0;
        }

        public QuyenTruycap(int Vanhanh, int Hoadonnhap, int Caidat, int Nhanvien, 
                            int HoadonxuatSP, int Sanpham, int Phong, int Baocao, 
                            int Khachhang, int Khuyenmai, int Tonkho)
        {
            this._Vanhanh = Vanhanh;
            this._HoadonNhap = Hoadonnhap;
            this._Setting = Caidat;
            this._Nhanvien = Nhanvien;
            this._HoadonxuatSP = HoadonxuatSP;
            this._Sanpham = Sanpham;
            this._Phong = Phong;
            this._Report = Baocao;
            this._Khachhang = Khachhang;
            this._Khuyenmai = Khuyenmai;
            this._Tonkho = Tonkho;
        }
    }
}
