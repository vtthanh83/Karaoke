using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Phong
    {
        private int _IDPhong;
        public int IDPhong
        {
            get { return _IDPhong; }
            set { _IDPhong = value; }
        }
        private string _TenPhong;
        public string TenPhong
        {
            get { return _TenPhong; }
            set { _TenPhong = value; }
        }
        private int _IDLoaiPhong;
        public int IDLoaiPhong
        {
            get { return _IDLoaiPhong; }
            set { _IDLoaiPhong = value; }
        }
        private int _Congtac;
        public int Congtac
        {
            get { return _Congtac; }
            set { _Congtac = value; }
        }
        private bool _Trangthai;
        public bool Trangthai
        {
            get { return _Trangthai; }
            set { _Trangthai = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
    }
}
