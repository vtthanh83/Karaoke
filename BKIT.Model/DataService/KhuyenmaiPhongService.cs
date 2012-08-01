using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BKIT.Model.IDataService;

namespace BKIT.Model.DataService
{
    public class KhuyenmaiPhongService : IKhuyenmaiPhong
{
        public int insertKhuyenmaiPhong(BKIT.Entities.KhuyenmaiPhong objKhuyenmaiPhong)
	{
		Database db = DatabaseFactory.CreateDatabase();
        string sqlCommand = "INSERT INTO KhuyenmaiPhong(IDKhuyenmai,IDNhomSP,NgayBD,NgayKT,Giam,Ghichu) " + 
			"VALUES (@idkhuyenmai,@idnhomsp,@ngaybd,@ngaykt,@giam,@ghichu)";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			int ID = GetNextAVailableID();
			objKhuyenmaiPhong.IDKhuyenmai = ID;
			db.AddInParameter(dbCommand, "idkhuyenmai", DbType.Int32, objKhuyenmaiPhong.IDKhuyenmai);
			db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objKhuyenmaiPhong.IDNhomSP);
			db.AddInParameter(dbCommand, "ngaybd", DbType.DateTime, objKhuyenmaiPhong.NgayBD);
			db.AddInParameter(dbCommand, "ngaykt", DbType.DateTime, objKhuyenmaiPhong.NgayKT);
			db.AddInParameter(dbCommand, "giam", DbType.Int32, objKhuyenmaiPhong.Giam);
			db.AddInParameter(dbCommand, "ghichu", DbType.String, objKhuyenmaiPhong.Ghichu);
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return ID;
		}
		catch
		{
			dbCommand.Connection.Close();
			return -1;
		}
	}
        public bool updateKhuyenmaiPhong(BKIT.Entities.KhuyenmaiPhong objKhuyenmaiPhong)
	{
		Database db = DatabaseFactory.CreateDatabase();
        string sqlCommand = "UPDATE KhuyenmaiPhong SET IDNhomSP = @idnhomsp, NgayBD = @ngaybd, NgayKT = @ngaykt, Giam = @giam, Ghichu = @ghichu " +
				"WHERE IDKhuyenmai = @idkhuyenmai";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objKhuyenmaiPhong.IDNhomSP);
			db.AddInParameter(dbCommand, "ngaybd", DbType.DateTime, objKhuyenmaiPhong.NgayBD);
			db.AddInParameter(dbCommand, "ngaykt", DbType.DateTime, objKhuyenmaiPhong.NgayKT);
			db.AddInParameter(dbCommand, "giam", DbType.Int32, objKhuyenmaiPhong.Giam);
			db.AddInParameter(dbCommand, "ghichu", DbType.String, objKhuyenmaiPhong.Ghichu);
			db.AddInParameter(dbCommand, "idkhuyenmai", DbType.Int32, objKhuyenmaiPhong.IDKhuyenmai);
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return true;
		}
		catch
		{
			 return false;
		}
	}
        public bool deleteKhuyenmaiPhong(BKIT.Entities.KhuyenmaiPhong objKhuyenmaiPhong)
	{
		Database db = DatabaseFactory.CreateDatabase();
        string sqlCommand = "DELETE FROM KhuyenmaiPhong WHERE IDKhuyenmai = @idkhuyenmai";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			db.AddInParameter(dbCommand, "idkhuyenmai", DbType.Int32, objKhuyenmaiPhong.IDKhuyenmai);
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}
        public System.Data.DataSet getAllKhuyenmaiPhong()
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "SELECT KhuyenmaiPhong.IDKhuyenmai, KhuyenmaiPhong.IDNhomSP, LoaiPhong.TenLoaiPhong, KhuyenmaiPhong.NgayBD, KhuyenmaiPhong.NgayKT, KhuyenmaiPhong.Giam, KhuyenmaiPhong.Ghichu"
                            +" FROM LoaiPhong INNER JOIN KhuyenmaiPhong ON LoaiPhong.IDLoaiPhong = KhuyenmaiPhong.IDNhomSP;";
		try
		{
			DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			dbCommand.Connection.Close();
			return ds;
		}
		catch
		{
			return null;
		}
	}
    public System.Data.DataSet getKhuyenmaiByIDLoaiPhong(int IDLoaiPhong,DateTime now)
    {
        Database db = DatabaseFactory.CreateDatabase();
        string sqlCommand = "SELECT * FROM KhuyenmaiPhong WHERE ((((KhuyenmaiPhong.IDNhomSP)=@id) OR ((KhuyenmaiPhong.IDNhomSP)=0)) AND ((KhuyenmaiPhong.NgayBD)<=@now1) AND ((KhuyenmaiPhong.NgayKT)>=@now2)) ORDER BY KhuyenmaiPhong.NgayBD DESC";
        try
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "id", DbType.Int32, IDLoaiPhong);
            db.AddInParameter(dbCommand, "now1", DbType.Date, DateTime.Now.Date);
            db.AddInParameter(dbCommand, "now2", DbType.Date, DateTime.Now.Date);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            dbCommand.Connection.Close();
            return ds;
        }
        catch
        {
            return null;
        }
    }
    
	#region Helpers
	internal int GetNextAVailableID()
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "SELECT IDKhuyenmai FROM Khuyenmai ORDER BY IDKhuyenmai";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		int result = 0;
		using (IDataReader dataReader = db.ExecuteReader(dbCommand))
		{
			while (dataReader.Read())
			{
				if (result != (int)dataReader[0])
				{
					dataReader.Close();
					dbCommand.Connection.Close();
					return result;
				}
				result++;
			}
			dataReader.Close();
			dbCommand.Connection.Close();
			return result;
		}
	}
	#endregion
}
}
