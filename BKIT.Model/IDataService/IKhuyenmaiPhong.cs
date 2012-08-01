using System;
using System.Collections.Generic;
using System.Text;

using BKIT.Entities;

namespace BKIT.Model.IDataService
{
	interface IKhuyenmaiPhong
	{
        int insertKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai);
        bool updateKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai);
        bool deleteKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai);
        System.Data.DataSet getAllKhuyenmaiPhong();

        System.Data.DataSet getKhuyenmaiByIDLoaiPhong(int IDLoaiPhong, DateTime now);
	}
}
