using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IGiaLoaiPhong
    {
        int insertGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong);
        bool updateGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong);
        bool deleteGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong);
        System.Data.DataSet getAllGiaLoaiPhong();
        System.Data.DataSet getGiaLoaiPhongByIDLoaiPhong(int ID);
        System.Data.DataSet getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(int IDLoaiphong, int IDKhunggio);
    }
}
