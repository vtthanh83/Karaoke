using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IQuyenTruycap
    {
        int insertQuyenTruycap(QuyenTruycap objQuyenTruycap);
        bool updateQuyenTruycap(QuyenTruycap objQuyenTruycap);
        bool deleteQuyenTruycap(QuyenTruycap objQuyenTruycap);
        System.Data.DataSet getAllQuyenTruycap();
        System.Data.DataSet getQuyenTruycapByDate(string dt, string tenloainhanvien);
    }
}
