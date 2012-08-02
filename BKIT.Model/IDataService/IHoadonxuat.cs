using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.DataService
{
    interface IHoadonxuat
    {
	    int insertHoadonxuat(Hoadonxuat objHoadonxuat);
	    bool updateHoadonxuat(Hoadonxuat objHoadonxuat);
	    bool deleteHoadonxuat(Hoadonxuat objHoadonxuat);
	    System.Data.DataSet getAllHoadonxuat();
        System.Data.DataSet getLastHoadonxuatByIDPhong(int ID);
        System.Data.DataSet getHoadonxuatByIDHoadonXuat(int ID);
        System.Data.DataSet getLastHoadonxuatByIDPhongAndDate(int ID, DateTime Date);
        System.Data.DataSet getAllOpenningHoadonxuatWithDeposit();
        System.Data.DataSet getAllNotClosedHDXOfProductID(int ProductID);
        System.Data.DataSet getSoLuongSPBanRa();
		 System.Data.DataSet getAllHoadonxuatSanpham();
        System.Data.DataSet getAllHoadonxuatPhong();
        System.Data.DataSet getLastOpeningHoadonxuatByIDPhong(int ID);
    }
    
}
