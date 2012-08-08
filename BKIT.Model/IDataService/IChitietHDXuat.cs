using System;
using System.Collections.Generic;
using System.Text;

using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IChitietHDXuat
    {
        int insertChitietHDXuat(ChitietHDXuat objChitietHDXuat);
        bool updateChitietHDXuat(ChitietHDXuat objChitietHDXuat);
        bool deleteChitietHDXuat(ChitietHDXuat objChitietHDXuat);
        System.Data.DataSet getAllChitietHDXuat();
        System.Data.DataSet getChitietHDXuatByID(int ID);
        System.Data.DataSet getSumChitietHDXuatByID(int ID);
        System.Data.DataSet getChitietHDXuatByIDSanphamAndIDHoadon(int IDSanpham,int IDHoadon);
        bool deleteChitietHDXuatOfHDXuat(BKIT.Entities.Hoadonxuat objHDXuat);
    }
}
