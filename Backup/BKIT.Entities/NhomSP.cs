using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class NhomSP
    {
        private int _IDNhomSP;
        public int IDNhomSP
        {
            get { return _IDNhomSP; }
            set { _IDNhomSP = value; }
        }
        private string _TenNhomSP;
        public string TenNhomSP
        {
            get { return _TenNhomSP; }
            set { _TenNhomSP = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
    }
}
