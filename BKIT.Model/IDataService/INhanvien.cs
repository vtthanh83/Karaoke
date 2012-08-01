using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;
namespace BKIT.Model.IDataService
{
    interface INhanvien
    {
        int insertNhanvien(Nhanvien objNhanvien);
        bool updateNhanvien(Nhanvien objNhanvien);
        bool deleteNhanvien(Nhanvien objNhanvien);
        System.Data.DataSet getAllNhanvien();
        System.Data.DataSet getAllIDandNameNhanvien();
        int getIDNVByUsername(string usernameNhanvien);
    }
}
