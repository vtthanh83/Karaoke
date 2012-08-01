using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Khunggio
    {
        private int _IDKhunggio;
        public int IDKhunggio
        {
            get { return _IDKhunggio; }
            set { _IDKhunggio = value; }
        }
        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        private string _GioBD;
        public string GioBD
        {
            get { return _GioBD; }
            set { _GioBD = value; }
        }
        private string _GioKT;
        public string GioKT
        {
            get { return _GioKT; }
            set { _GioKT = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
    }
}
