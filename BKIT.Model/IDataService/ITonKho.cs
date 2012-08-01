using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BKIT.Model.IDataService
{
    interface ITonKho
    {
        int getTonKhoDauKi(int IDSanPham);
        DataSet getHoaDonNhap(int IDSanPham);
        DataSet getHoaDonXuat(int IDSanPham);

    }
}
