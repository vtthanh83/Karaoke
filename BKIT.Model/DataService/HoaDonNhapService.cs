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
    public class HoaDonNhapService : IHoaDonNhap
    {
        public int insertHoaDonNhap(BKIT.Entities.HoaDonNhap objHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO HoaDonNhap(IDHoaDonNhap,Ngay,Ghichu,IDNhanvien) " +
                "VALUES (@idhoadonnhap,@ngay,@ghichu,@idnhanvien)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objHoaDonNhap.IDHoaDonNhap = ID;
                db.AddInParameter(dbCommand, "idhoadonnhap", DbType.Int32, objHoaDonNhap.IDHoaDonNhap);
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objHoaDonNhap.Ngay);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objHoaDonNhap.Ghichu);
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objHoaDonNhap.IDNhanvien);
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
        public bool updateHoaDonNhap(BKIT.Entities.HoaDonNhap objHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE HoaDonNhap SET Ngay = @ngay, Ghichu = @ghichu, IDNhanvien = @idnhanvien " +
                    "WHERE IDHoaDonNhap = @idhoadonnhap";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objHoaDonNhap.Ngay);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objHoaDonNhap.Ghichu);
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objHoaDonNhap.IDNhanvien);
                db.AddInParameter(dbCommand, "idhoadonnhap", DbType.Int32, objHoaDonNhap.IDHoaDonNhap);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteHoaDonNhap(BKIT.Entities.HoaDonNhap objHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM HoaDonNhap WHERE IDHoaDonNhap = @idhoadonnhap";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idhoadonnhap", DbType.Int32, objHoaDonNhap.IDHoaDonNhap);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllHoaDonNhap()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT TOP 100 HoaDonNhap.IDHoaDonNhap, HoaDonNhap.Ngay, HoaDonNhap.IDNhanvien, HoaDonNhap.Ghichu, Nhanvien.Ten, 1 as [DeleteHoaDonNhap] " +
                                "FROM Nhanvien INNER JOIN HoaDonNhap ON Nhanvien.IDNhanvien = HoaDonNhap.IDNhanvien " +
                                "ORDER BY Nhanvien.Ten , HoaDonNhap.Ngay DESC";
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
        public System.Data.DataSet getHoaDonNhap(DateTime dateFrom, DateTime dateTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT HoaDonNhap.IDHoaDonNhap, HoaDonNhap.Ngay, HoaDonNhap.IDNhanvien, HoaDonNhap.Ghichu, Nhanvien.Ten, 1 as [DeleteHoaDonNhap] " +
                                "FROM Nhanvien INNER JOIN HoaDonNhap ON Nhanvien.IDNhanvien = HoaDonNhap.IDNhanvien " +
                                "WHERE HoaDonNhap.Ngay >= @datefrom and HoaDonNhap.Ngay <=@dateto " +
                                "ORDER BY Nhanvien.Ten , HoaDonNhap.Ngay DESC";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "datefrom", DbType.DateTime, dateFrom);
                db.AddInParameter(dbCommand, "dateto", DbType.DateTime, dateTo);
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
            string sqlCommand = "SELECT IDHoaDonNhap FROM HoaDonNhap ORDER BY IDHoaDonNhap";
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
