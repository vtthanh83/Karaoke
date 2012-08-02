using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using BKIT.Entities;
using BKIT.Model.IDataService;

namespace BKIT.Model.DataService
{
    public class PhongService : IPhong
    {
        public int insertPhong(BKIT.Entities.Phong objPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO Phong(IDPhong,TenPhong,IDLoaiPhong,Congtac,Trangthai,Ghichu) " +
                "VALUES (@idphong,@tenphong,@idloaiphong,@congtac,@trangthai,@ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objPhong.IDPhong = ID;
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, objPhong.IDPhong);
                db.AddInParameter(dbCommand, "tenphong", DbType.String, objPhong.TenPhong);
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objPhong.IDLoaiPhong);
                db.AddInParameter(dbCommand, "congtac", DbType.Int32, objPhong.Congtac);
                db.AddInParameter(dbCommand, "trangthai", DbType.Boolean, objPhong.Trangthai);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objPhong.Ghichu);
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
        public bool updatePhong(BKIT.Entities.Phong objPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE Phong SET TenPhong = @tenphong, IDLoaiPhong = @idloaiphong, Congtac = @congtac, Trangthai = @trangthai, Ghichu = @ghichu " +
                    "WHERE IDPhong = @idphong";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tenphong", DbType.String, objPhong.TenPhong);
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objPhong.IDLoaiPhong);
                db.AddInParameter(dbCommand, "congtac", DbType.Int32, objPhong.Congtac);
                db.AddInParameter(dbCommand, "trangthai", DbType.Boolean, objPhong.Trangthai);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objPhong.Ghichu);
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, objPhong.IDPhong);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deletePhong(BKIT.Entities.Phong objPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM Phong WHERE IDPhong = @idphong";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, objPhong.IDPhong);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllPhong()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDPhong,TenPhong,IDLoaiPhong,Congtac,Trangthai,Ghichu,1 as [DeletePhong] FROM Phong";
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
        public System.Data.DataSet getAllPhongAndLoaiPhong()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhong.TenLoaiPhong as TenLoaiPhong, Phong.IDPhong as IDPhong, Phong.TenPhong as TenPhong, Phong.Trangthai as Trangthai, Phong.Congtac as Congtac, Phong.Ghichu as Ghichu, "+
                                "IIf([Phong].[Trangthai]=Yes,0,1) AS TT FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong WHERE Phong.IDPhong >= 0;";
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
        public System.Data.DataSet getAllPhongAndLoaiPhong(int diffID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhong.TenLoaiPhong as TenLoaiPhong, Phong.IDPhong as IDPhong, Phong.TenPhong as TenPhong, Phong.Trangthai as Trangthai, Phong.Congtac as Congtac, Phong.Ghichu as Ghichu, " +
                                "IIf([Phong].[Trangthai]=Yes,0,1) AS TT FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong " +
                                "WHERE (Phong.IDPhong)<>@idphong AND (Phong.IDPhong >= 0);";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, diffID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getAllFreePhongAndLoaiPhong(int diffID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand;
            if (diffID >= 0)
            {
                sqlCommand = "SELECT LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhong.TenLoaiPhong as TenLoaiPhong, Phong.IDPhong as IDPhong, Phong.TenPhong as TenPhong, Phong.Trangthai as Trangthai, Phong.Congtac as Congtac, Phong.Ghichu as Ghichu, " +
                                "IIf([Phong].[Trangthai]=Yes,0,1) AS TT FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong " +
                                "WHERE (((Phong.IDPhong)<>@idphong) AND (Phong.IDPhong >= 0)  AND ((Phong.Trangthai)=False));";
            }
            else
            {
                sqlCommand = "SELECT LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhong.TenLoaiPhong as TenLoaiPhong, Phong.IDPhong as IDPhong, Phong.TenPhong as TenPhong, Phong.Trangthai as Trangthai, Phong.Congtac as Congtac, Phong.Ghichu as Ghichu, " +
                                "IIf([Phong].[Trangthai]=Yes,0,1) AS TT FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong " +
                                "WHERE ((Phong.IDPhong >= 0)  AND ((Phong.Trangthai)=False));";
            }
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, diffID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getAllBusyPhongAndLoaiPhong(int diffID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand;
            if (diffID >= 0)
            {
                sqlCommand = "SELECT LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhong.TenLoaiPhong as TenLoaiPhong, Phong.IDPhong as IDPhong, Phong.TenPhong as TenPhong, Phong.Trangthai as Trangthai, Phong.Congtac as Congtac, Phong.Ghichu as Ghichu, " +
                                "IIf([Phong].[Trangthai]=Yes,0,1) AS TT FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong " +
                                "WHERE (((Phong.IDPhong)<>@idphong) AND (Phong.IDPhong >= 0) AND ((Phong.Trangthai)=True));";
            }
            else
            {
                sqlCommand = "SELECT LoaiPhong.IDLoaiPhong as IDLoaiPhong, LoaiPhong.TenLoaiPhong as TenLoaiPhong, Phong.IDPhong as IDPhong, Phong.TenPhong as TenPhong, Phong.Trangthai as Trangthai, Phong.Congtac as Congtac, Phong.Ghichu as Ghichu, " +
                                "IIf([Phong].[Trangthai]=Yes,0,1) AS TT FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong " +
                                "WHERE ((Phong.IDPhong >= 0) AND ((Phong.Trangthai)=True));";
            }
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, diffID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getPhongByIDLoaiPhong(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            /*  string sqlCommand = "SELECT Phong.IDPhong, Phong.TenPhong,Phong.IDLoaiPhong, Phong.Trangthai, Phong.Ghichu, 1 as [DeleteLoaiPhong] " +
                                  "FROM Phong " +
                                  "WHERE IDLoaiPhong = @id";
             */
            string sqlCommand = "SELECT Phong.IDPhong, Phong.TenPhong,Phong.IDLoaiPhong,Phong.Congtac,Phong.Ghichu,Phong.Trangthai, 1 as [DeletePhong] " +
                               "FROM Phong " +
                               "WHERE IDLoaiPhong = @id and Phong.IDPhong >= 0";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, ID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getPhongByIDPhong(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT Phong.IDPhong, Phong.TenPhong,Phong.IDLoaiPhong, Phong.Congtac, Phong.Trangthai, Phong.Ghichu, 1 as [DeleteLoaiPhong] " +
                                "FROM Phong " +
                                "WHERE IDPhong = @id AND (Phong.IDPhong >= 0)";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, ID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool IsCongtacExisted(int congtac)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * " +
                                "FROM Phong " +
                                "WHERE Phong.Congtac = @id";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, congtac);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                if(ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool IsCongtacExistedExceptIDPhong(int congtac, int exceptRoomID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * " +
                                "FROM Phong " +
                                "WHERE Phong.Congtac = @congtac AND IDPhong <> @idPhong";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "congtac", DbType.Int32, congtac);
                db.AddInParameter(dbCommand, "idPhong", DbType.Int32, exceptRoomID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool IsTenPhongExistedExceptIDPhong(string TenPhong, int exceptRoomID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * " +
                                "FROM Phong " +
                                "WHERE Phong.TenPhong = @tenPhong AND IDPhong <> @idPhong";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "tenPhong", DbType.String, TenPhong);
                db.AddInParameter(dbCommand, "idPhong", DbType.Int32, exceptRoomID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }  
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDPhong FROM Phong ORDER BY IDPhong";
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
