using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface ILoaiNhanvien
    {
        int insertLoaiNhanvien(LoaiNhanvien objLoaiNhanvien);
        bool updateLoaiNhanvien(LoaiNhanvien objLoaiNhanvien);
        bool deleteLoaiNhanvien(LoaiNhanvien objLoaiNhanvien);
        System.Data.DataSet getAllLoaiNhanvien();
    }
}
