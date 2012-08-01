using System;
using System.Collections.Generic;
using System.Text;

using BKIT.Entities;

namespace BKIT.Model.IDataService
{
	interface IKhuyenmai
	{
		int insertKhuyenmai(Khuyenmai objKhuyenmai);
		bool updateKhuyenmai(Khuyenmai objKhuyenmai);
		bool deleteKhuyenmai(Khuyenmai objKhuyenmai);
		System.Data.DataSet getAllKhuyenmai();

        System.Data.DataSet getKhuyenmaiByIDLoaiSP(int IDLoaiSP, DateTime now);
	}
}
