using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Khachhang
    {
        private string _Chucvu;
        public string Chucvu
        {
            get { return _Chucvu; }
            set { _Chucvu = value; }
        }
        private string _Diachi;
        public string Diachi
        {
            get { return _Diachi; }
            set { _Diachi = value; }
        }
        private string _Gioitinh;
        public string Gioitinh
        {
            get { return _Gioitinh; }
            set { _Gioitinh = value; }
        }
        private int _IDKhachhang;
        public int IDKhachhang
        {
            get { return _IDKhachhang; }
            set { _IDKhachhang = value; }
        }
        private int _IDLoaiKH;
        public int IDLoaiKH
        {
            get { return _IDLoaiKH; }
            set { _IDLoaiKH = value; }
        }
        private DateTime _NgayBD;
        public DateTime NgayBD
        {
            get { return _NgayBD; }
            set { _NgayBD = value; }
        }
        private DateTime _Ngaysinh;
        public DateTime Ngaysinh
        {
            get { return _Ngaysinh; }
            set { _Ngaysinh = value; }
        }
        private string _SoDT;
        public string SoDT
        {
            get { return _SoDT; }
            set { _SoDT = value; }
        }
        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        private int _Tongdiem;
        public int Tongdiem
        {
            get { return _Tongdiem; }
            set { _Tongdiem = value; }
        }
    }
}
