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
    public class KhunggioService : IKhunggio
    {
        public int insertKhunggio(BKIT.Entities.Khunggio objKhunggio)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO Khunggio(IDKhunggio,Ten,GioBD,GioKT,Ghichu) " +
                "VALUES (@idkhunggio,@ten,@giobd,@giokt,@ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objKhunggio.IDKhunggio = ID;
                db.AddInParameter(dbCommand, "idkhunggio", DbType.Int32, objKhunggio.IDKhunggio);
                db.AddInParameter(dbCommand, "ten", DbType.String, objKhunggio.Ten);
                db.AddInParameter(dbCommand, "giobd", DbType.String, objKhunggio.GioBD);
                db.AddInParameter(dbCommand, "giokt", DbType.String, objKhunggio.GioKT);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objKhunggio.Ghichu);
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
        public bool updateKhunggio(BKIT.Entities.Khunggio objKhunggio)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE Khunggio SET Ten = @ten, GioBD = @giobd, GioKT = @giokt, Ghichu = @ghichu " +
                    "WHERE IDKhunggio = @idkhunggio";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "ten", DbType.String, objKhunggio.Ten);
                db.AddInParameter(dbCommand, "giobd", DbType.String, objKhunggio.GioBD);
                db.AddInParameter(dbCommand, "giokt", DbType.String, objKhunggio.GioKT);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objKhunggio.Ghichu);
                db.AddInParameter(dbCommand, "idkhunggio", DbType.Int32, objKhunggio.IDKhunggio);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKhunggio(BKIT.Entities.Khunggio objKhunggio)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM Khunggio WHERE IDKhunggio = @idkhunggio";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idkhunggio", DbType.Int32, objKhunggio.IDKhunggio);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllKhunggio()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT Khunggio.IDKhunggio, Khunggio.Ten, Khunggio.GioBD, Khunggio.GioKT, Khunggio.Ghichu, 1 as [DeleteKhunggio] FROM Khunggio ORDER BY Khunggio.IDKhunggio ASC";
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
        public int getIDKhunggiofromTenKhunggio(string str)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT Khunggio.IDKhunggio " +
                "FROM Khunggio where Khunggio.Ten='" + str + "';";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return Convert.ToInt32(ds.Tables[0].Rows[0]["IDKhunggio"]);
            }
            catch
            {
                return 0;
            }
        }
        public bool IsGiaLoaiPhongKhungGioExisted(int IDKhungGio, int IDLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * " +
                                "FROM GiaLoaiPhong " +
                                "WHERE IDKhunggio = @idKhungGio And IDLoaiPhong = @idLoaiPhong";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);                
                db.AddInParameter(dbCommand, "idKhungGio", DbType.Int32, IDKhungGio);
                db.AddInParameter(dbCommand, "idLoaiPhong", DbType.Int32, IDLoaiPhong);
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
            string sqlCommand = "SELECT IDKhunggio FROM Khunggio ORDER BY IDKhunggio";
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
