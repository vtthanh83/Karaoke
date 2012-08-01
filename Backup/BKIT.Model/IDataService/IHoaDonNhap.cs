using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IHoaDonNhap
    {
        int insertHoaDonNhap(HoaDonNhap objHoaDonNhap);
        bool updateHoaDonNhap(HoaDonNhap objHoaDonNhap);
        bool deleteHoaDonNhap(HoaDonNhap objHoaDonNhap);
        System.Data.DataSet getAllHoaDonNhap();
        System.Data.DataSet getHoaDonNhap(DateTime dateFrom, DateTime dateTo);
    }
}
