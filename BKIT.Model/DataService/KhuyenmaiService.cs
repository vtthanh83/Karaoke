using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BKIT.Model.IDataService;

namespace BKIT.Model.DataService
{
    public class KhuyenmaiService:IKhuyenmai
{
	public int insertKhuyenmai(BKIT.Entities.Khuyenmai objKhuyenmai)
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "INSERT INTO Khuyenmai(IDKhuyenmai,IDNhomSP,NgayBD,NgayKT,Giam,Ghichu) " + 
			"VALUES (@idkhuyenmai,@idnhomsp,@ngaybd,@ngaykt,@giam,@ghichu)";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			int ID = GetNextAVailableID();
			objKhuyenmai.IDKhuyenmai = ID;
			db.AddInParameter(dbCommand, "idkhuyenmai", DbType.Int32, objKhuyenmai.IDKhuyenmai);
			db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objKhuyenmai.IDNhomSP);
			db.AddInParameter(dbCommand, "ngaybd", DbType.DateTime, objKhuyenmai.NgayBD);
			db.AddInParameter(dbCommand, "ngaykt", DbType.DateTime, objKhuyenmai.NgayKT);
			db.AddInParameter(dbCommand, "giam", DbType.Int32, objKhuyenmai.Giam);
			db.AddInParameter(dbCommand, "ghichu", DbType.String, objKhuyenmai.Ghichu);
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
	public bool updateKhuyenmai(BKIT.Entities.Khuyenmai objKhuyenmai)
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "UPDATE Khuyenmai SET IDNhomSP = @idnhomsp, NgayBD = @ngaybd, NgayKT = @ngaykt, Giam = @giam, Ghichu = @ghichu " +
				"WHERE IDKhuyenmai = @idkhuyenmai";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objKhuyenmai.IDNhomSP);
			db.AddInParameter(dbCommand, "ngaybd", DbType.Date, objKhuyenmai.NgayBD.Date);
			db.AddInParameter(dbCommand, "ngaykt", DbType.Date, objKhuyenmai.NgayKT.Date);
			db.AddInParameter(dbCommand, "giam", DbType.Int32, objKhuyenmai.Giam);
			db.AddInParameter(dbCommand, "ghichu", DbType.String, objKhuyenmai.Ghichu);
			db.AddInParameter(dbCommand, "idkhuyenmai", DbType.Int32, objKhuyenmai.IDKhuyenmai);
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return true;
		}
		catch
		{
			 return false;
		}
	}
	public bool deleteKhuyenmai(BKIT.Entities.Khuyenmai objKhuyenmai)
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "DELETE FROM Khuyenmai WHERE IDKhuyenmai = @idkhuyenmai";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			db.AddInParameter(dbCommand, "idkhuyenmai", DbType.Int32, objKhuyenmai.IDKhuyenmai);
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}
	public System.Data.DataSet getAllKhuyenmai()
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "SELECT Khuyenmai.IDKhuyenmai, Khuyenmai.IDNhomSP, NhomSP.TenNhomSP, Khuyenmai.NgayBD, Khuyenmai.NgayKT, Khuyenmai.Giam, Khuyenmai.Ghichu,1 as [DeleteKMSP]"
                            +" FROM Khuyenmai INNER JOIN NhomSP ON Khuyenmai.IDNhomSP = NhomSP.IDNhomSP;";
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
    public System.Data.DataSet getKhuyenmaiByIDLoaiSP(int IDLoaiSP,DateTime now)
    {
        Database db = DatabaseFactory.CreateDatabase();
        string sqlCommand = "SELECT * FROM Khuyenmai WHERE ((((Khuyenmai.IDNhomSP)=@id) OR ((Khuyenmai.IDNhomSP)=0)) AND ((Khuyenmai.NgayBD)<=@now1) AND ((Khuyenmai.NgayKT)>=@now2)) ORDER BY Khuyenmai.NgayBD DESC";
        try
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "id", DbType.Int32, IDLoaiSP);
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
