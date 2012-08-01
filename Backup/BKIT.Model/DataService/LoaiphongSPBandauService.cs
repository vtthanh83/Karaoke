using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BKIT.Model.IDataService;

namespace BKIT.Model.DataService
{
    public class LoaiphongSPBandauService:ILoaiphongSPBandau
{
	public int insertLoaiphongSPBandau(BKIT.Entities.LoaiphongSPBandau objLoaiphongSPBandau)
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "INSERT INTO LoaiphongSPBandau(IDLPSP,IDSanPham,IDLoaiPhong,Soluong,Ghichu) " + 
			"VALUES (@idlpsp,@idsanpham,@idloaiphong,@soluong,@ghichu)";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			int ID = GetNextAVailableID();
			objLoaiphongSPBandau.IDLPSP = ID;
			db.AddInParameter(dbCommand, "idlpsp", DbType.Int32, objLoaiphongSPBandau.IDLPSP);
			db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objLoaiphongSPBandau.IDSanPham);
			db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objLoaiphongSPBandau.IDLoaiPhong);
			db.AddInParameter(dbCommand, "soluong", DbType.Int32, objLoaiphongSPBandau.Soluong);
            db.AddInParameter(dbCommand, "ghichu", DbType.String, objLoaiphongSPBandau.Ghichu);
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
	public bool updateLoaiphongSPBandau(BKIT.Entities.LoaiphongSPBandau objLoaiphongSPBandau)
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "UPDATE LoaiphongSPBandau SET IDSanPham = @idsanpham, IDLoaiPhong = @idloaiphong, Soluong = @soluong, Ghichu = @ghichu " +
				"WHERE IDLPSP = @idlpsp";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objLoaiphongSPBandau.IDSanPham);
			db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objLoaiphongSPBandau.IDLoaiPhong);
			db.AddInParameter(dbCommand, "soluong", DbType.Int32, objLoaiphongSPBandau.Soluong);

            db.AddInParameter(dbCommand, "ghichu", DbType.String, objLoaiphongSPBandau.Ghichu);
			db.AddInParameter(dbCommand, "idlpsp", DbType.Int32, objLoaiphongSPBandau.IDLPSP);
            
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return true;
		}
		catch
		{
			 return false;
		}
	}
	public bool deleteLoaiphongSPBandau(BKIT.Entities.LoaiphongSPBandau objLoaiphongSPBandau)
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "DELETE FROM LoaiphongSPBandau WHERE IDLPSP = @idlpsp";
		DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
		try
		{
			db.AddInParameter(dbCommand, "idlpsp", DbType.Int32, objLoaiphongSPBandau.IDLPSP);
			db.ExecuteNonQuery(dbCommand);
			dbCommand.Connection.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}
	public System.Data.DataSet getAllLoaiphongSPBandau()
	{
		Database db = DatabaseFactory.CreateDatabase();
		string sqlCommand = "SELECT * FROM LoaiphongSPBandau";
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
    public System.Data.DataSet getAllSPBandauIDLoaiPhong(int IDLoaiPhong)
    {
        Database db = DatabaseFactory.CreateDatabase();
        string sqlCommand = "SELECT LoaiPhongSPBandau.IDLPSP as IDLPSP, LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhongSPBandau.IDSanPham AS IDSanPham, LoaiPhongSPBandau.Ghichu AS Ghichu, LoaiPhongSPBandau.Soluong AS Soluong, SanPham.TenSanPham AS TenSanPham, SanPham.IDNhomSP AS IDNhomSP, 1 as [DeleteSPBD]"
                            +" FROM SanPham INNER JOIN (LoaiPhong INNER JOIN LoaiPhongSPBandau ON LoaiPhong.IDLoaiPhong = LoaiPhongSPBandau.IDLoaiPhong) ON SanPham.IDSanPham = LoaiPhongSPBandau.IDSanPham"
                            +" WHERE (((LoaiPhong.IDLoaiPhong)=@id));";
        try
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            db.AddInParameter(dbCommand, "id", DbType.Int32, IDLoaiPhong);
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
		string sqlCommand = "SELECT IDLPSP FROM LoaiphongSPBandau ORDER BY IDLPSP";
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
