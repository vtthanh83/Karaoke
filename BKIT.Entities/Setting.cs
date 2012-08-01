using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Setting
    {
        private int _IDSetting;
        public int IDSetting
        {
            get { return _IDSetting; }
            set { _IDSetting = value; }
        }
        private DateTime _Ngay;
        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        private string _TenCT;
        public string TenCT
        {
            get { return _TenCT; }
            set { _TenCT = value; }
        }
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        private string _Diachi;
        public string Diachi
        {
            get { return _Diachi; }
            set { _Diachi = value; }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _Khuyenmai;
        public string Khuyenmai
        {
            get { return _Khuyenmai; }
            set { _Khuyenmai = value; }
        }
        private string _Loichao1;
        public string Loichao1
        {
            get { return _Loichao1; }
            set { _Loichao1 = value; }
        }
        private string _Loichao2;
        public string Loichao2
        {
            get { return _Loichao2; }
            set { _Loichao2 = value; }
        }
        private int _TGKetthuc;
        public int TGKetthuc
        {
            get { return _TGKetthuc; }
            set { _TGKetthuc = value; }
        }
        private string _MayInBep;
        public string MayInBep
        {
            get { return _MayInBep; }
            set { _MayInBep = value; }
        }
        private string _MayInKho;
        public string MayInKho
        {
            get { return _MayInKho; }
            set { _MayInKho = value; }
        }
        private string _MayInHoadon;
        public string MayInHoadon
        {
            get { return _MayInHoadon; }
            set { _MayInHoadon = value; }
        }
    }
}
