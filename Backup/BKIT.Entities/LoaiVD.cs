using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class LoaiVD
    {
        private int _IDLoaiVD;
        public int IDLoaiVD
        {
            get { return _IDLoaiVD; }
            set { _IDLoaiVD = value; }
        }
        private string _TenVD;
        public string TenVD
        {
            get { return _TenVD; }
            set { _TenVD = value; }
        }
        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        
    }
}
