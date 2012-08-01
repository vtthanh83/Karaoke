using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class LoaiPhong
    {
        private int _IDLoaiPhong;
        public int IDLoaiPhong
        {
            get { return _IDLoaiPhong; }
            set { _IDLoaiPhong = value; }
        }
        private string _TenLoaiPhong;
        public string TenLoaiPhong
        {
            get { return _TenLoaiPhong; }
            set { _TenLoaiPhong = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
    }
}
