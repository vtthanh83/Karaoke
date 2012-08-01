using System;
using System.Collections.Generic;
using System.Text;
namespace BKIT.Entities
{
    public class LoaiKH
    {
        private int _IDLoaiKH;
        public int IDLoaiKH
        {
            get { return _IDLoaiKH; }
            set { _IDLoaiKH = value; }
        }
        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        
    }
}
