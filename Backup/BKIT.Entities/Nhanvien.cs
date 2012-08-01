using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Nhanvien
    {
        private int _IDNhanvien;
        public int IDNhanvien
        {
            get { return _IDNhanvien; }
            set { _IDNhanvien = value; }
        }
        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        private string _Gioitinh;
        public string Gioitinh
        {
            get { return _Gioitinh; }
            set { _Gioitinh = value; }
        }
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
        private string _SoDT;
        public string SoDT
        {
            get { return _SoDT; }
            set { _SoDT = value; }
        }
        private DateTime _Ngaysinh;
        public DateTime Ngaysinh
        {
            get { return _Ngaysinh; }
            set { _Ngaysinh = value; }
        }
        private string _Loai;
        public string Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private int _IDQuyenTruycap;
        public int IDQuyenTruycap
        {
            get { return _IDQuyenTruycap; }
            set { _IDQuyenTruycap = value; }
        }
    }
}
