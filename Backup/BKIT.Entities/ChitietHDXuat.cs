using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class ChitietHDXuat
    {
        private int _IDChitietHDXuat;
        public int IDChitietHDXuat
        {
            get { return _IDChitietHDXuat; }
            set { _IDChitietHDXuat = value; }
        }
        private int _IDHoadonXuat;
        public int IDHoadonXuat
        {
            get { return _IDHoadonXuat; }
            set { _IDHoadonXuat = value; }
        }
        private int _IDSanpham;
        public int IDSanpham
        {
            get { return _IDSanpham; }
            set { _IDSanpham = value; }
        }
        private int _IDGiaxuat;
        public int IDGiaxuat
        {
            get { return _IDGiaxuat; }
            set { _IDGiaxuat = value; }
        }
        private int _Soluong;
        public int Soluong
        {
            get { return _Soluong; }
            set { _Soluong = value; }
        }
        private int _Giam;
        public int Giam
        {
            get { return _Giam; }
            set { _Giam = value; }
        }
        private bool _Bep;
        public bool Bep
        {
            get { return _Bep; }
            set { _Bep = value; }
        }
        private bool _Kho;
        public bool Kho
        {
            get { return _Kho; }
            set { _Kho = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
    }
}
