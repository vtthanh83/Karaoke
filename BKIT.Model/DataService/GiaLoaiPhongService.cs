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
    public class GiaLoaiPhongService : IGiaLoaiPhong
    {
        public int insertGiaLoaiPhong(BKIT.Entities.GiaLoaiPhong objGiaLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO GiaLoaiPhong(IDGiaLoaiPhong,Gia,IDLoaiPhong,Ngay,IDKhunggio) " +
                "VALUES (@idgialoaiphong,@gia,@idloaiphong,@ngay,@idkhunggio)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objGiaLoaiPhong.IDGiaLoaiPhong = ID;
                db.AddInParameter(dbCommand, "idgialoaiphong", DbType.Int32, objGiaLoaiPhong.IDGiaLoaiPhong);
                db.AddInParameter(dbCommand, "gia", DbType.Decimal, objGiaLoaiPhong.Gia);
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objGiaLoaiPhong.IDLoaiPhong);
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objGiaLoaiPhong.Ngay);
                db.AddInParameter(dbCommand, "idkhunggio", DbType.Int32, objGiaLoaiPhong.IDKhunggio);
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
        public bool updateGiaLoaiPhong(BKIT.Entities.GiaLoaiPhong objGiaLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE GiaLoaiPhong SET Gia = @gia, Ngay = @ngay,IDLoaiPhong = @idloaiphong,  IDKhunggio = @idkhunggio  " +
                    "WHERE IDGiaLoaiPhong = @idgialoaiphong";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "gia", DbType.Decimal, objGiaLoaiPhong.Gia);
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objGiaLoaiPhong.Ngay);
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objGiaLoaiPhong.IDLoaiPhong);
                
                db.AddInParameter(dbCommand, "idgialoaiphong", DbType.Int32, objGiaLoaiPhong.IDGiaLoaiPhong);
                db.AddInParameter(dbCommand, "idkhunggio", DbType.Int32, objGiaLoaiPhong.IDKhunggio);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteGiaLoaiPhong(BKIT.Entities.GiaLoaiPhong objGiaLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM GiaLoaiPhong WHERE IDGiaLoaiPhong = @idgialoaiphong";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idgialoaiphong", DbType.Int32, objGiaLoaiPhong.IDGiaLoaiPhong);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllGiaLoaiPhong()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM GiaLoaiPhong";
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
        public System.Data.DataSet getGiaLoaiPhongByIDGiaLoaiPhong(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT GiaLoaiPhong.IDGiaLoaiPhong, GiaLoaiPhong.IDLoaiPhong, GiaLoaiPhong.Gia, GiaLoaiPhong.Ngay, GiaLoaiPhong.IDKhunggio, 1 as [DeleteGiaLoaiPhong] " +
                                "FROM GiaLoaiPhong " +
                                "WHERE IDGiaLoaiPhong = @id ORDER BY GiaLoaiPhong.Ngay DESC";

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
        public System.Data.DataSet getGiaLoaiPhongByIDLoaiPhong(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT GiaLoaiPhong.IDGiaLoaiPhong, GiaLoaiPhong.IDLoaiPhong, GiaLoaiPhong.Gia, GiaLoaiPhong.Ngay, GiaLoaiPhong.IDKhunggio, 1 as [DeleteGiaLoaiPhong] " +
                                "FROM GiaLoaiPhong " +
                                "WHERE IDLoaiPhong = @id";

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
        public System.Data.DataSet getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(int IDLoaiphong, int IDKhunggio)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT GiaLoaiPhong.IDGiaLoaiPhong, GiaLoaiPhong.IDLoaiPhong, GiaLoaiPhong.Gia, GiaLoaiPhong.Ngay, 1 as [DeleteLoaiPhong] " +
                                "FROM GiaLoaiPhong " +
                                "WHERE (IDLoaiPhong = @id AND IDKhunggio = @idkhunggio) " +
                                "ORDER BY GiaLoaiPhong.Ngay DESC";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, IDLoaiphong);
                db.AddInParameter(dbCommand, "idkhunggio", DbType.Int32, IDKhunggio);
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
            string sqlCommand = "SELECT IDGiaLoaiPhong FROM GiaLoaiPhong ORDER BY IDGiaLoaiPhong";
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
