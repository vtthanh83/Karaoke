using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IChiTietHoaDonNhap
    {
        int insertChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap);
        bool updateChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap);
        bool deleteChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap);
        System.Data.DataSet getAllChiTietHoaDonNhap();
        System.Data.DataSet getAllChiTietHoaDonNhapByIDHoaDonNhap(int IDHoaDonNhap);
    }
}
