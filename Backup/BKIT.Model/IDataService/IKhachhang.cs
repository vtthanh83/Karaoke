using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;
namespace BKIT.Model.IDataService
{
    interface IKhachhang
    {
        int insertKhachhang(Khachhang objKhachhang);
        bool updateKhachhang(Khachhang objKhachhang);
        bool deleteKhachhang(Khachhang objKhachhang);
        System.Data.DataSet getAllKhachhang();
    }
}
