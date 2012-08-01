using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class LoaiNhanvien
    {
        private int _IDLoaiNhanvien;
        public int IDLoaiNhanvien
        {
            get { return _IDLoaiNhanvien; }
            set { _IDLoaiNhanvien = value; }
        }
        private string _TenLoaiNV;
        public string TenLoaiNV
        {
            get { return _TenLoaiNV; }
            set { _TenLoaiNV = value; }
        }
    }
}
