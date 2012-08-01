using System;
using System.Collections.Generic;
using System.Text;

using BKIT.Entities;

namespace BKIT.Model.IDataService
{
	interface ILoaiphongSPBandau
{
	int insertLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau);
	bool updateLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau);
	bool deleteLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau);
	System.Data.DataSet getAllLoaiphongSPBandau();
        System.Data.DataSet getAllSPBandauIDLoaiPhong(int IDLoaiPhong);
	}
}
