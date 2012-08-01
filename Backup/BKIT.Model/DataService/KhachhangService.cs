using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using BKIT.Entities;
using BKIT.Model.IDataService;
using System.Data.SqlClient;

namespace BKIT.Model.DataService
{
    public class KhachhangService : IKhachhang
    {
        public int insertKhachhang(BKIT.Entities.Khachhang objKhachhang)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO Khachhang(IDKhachhang,Tongdiem,NgayBD,IDLoaiKH,Ngaysinh,SoDT,Diachi,Chucvu,Gioitinh,Ten) " +
                "VALUES (@idkhachhang,@tongdiem,@ngaybd,@idloaikh,@ngaysinh,@sodt,@diachi,@chucvu,@gioitinh,@ten)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objKhachhang.IDKhachhang = ID;
                db.AddInParameter(dbCommand, "idkhachhang", DbType.Int32, objKhachhang.IDKhachhang);
                db.AddInParameter(dbCommand, "tongdiem", DbType.Int32, objKhachhang.Tongdiem);
                db.AddInParameter(dbCommand, "ngaybd", DbType.DateTime, objKhachhang.NgayBD);
                db.AddInParameter(dbCommand, "idloaikh", DbType.Int32, objKhachhang.IDLoaiKH);
                db.AddInParameter(dbCommand, "ngaysinh", DbType.DateTime, objKhachhang.Ngaysinh);
                db.AddInParameter(dbCommand, "sodt", DbType.String, objKhachhang.SoDT);
                db.AddInParameter(dbCommand, "diachi", DbType.String, objKhachhang.Diachi);
                db.AddInParameter(dbCommand, "chucvu", DbType.String, objKhachhang.Chucvu);
                db.AddInParameter(dbCommand, "gioitinh", DbType.String, objKhachhang.Gioitinh);
                db.AddInParameter(dbCommand, "ten", DbType.String, objKhachhang.Ten);
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
        public bool updateKhachhang(BKIT.Entities.Khachhang objKhachhang)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE Khachhang SET Tongdiem = @tongdiem, NgayBD = @ngaybd, IDLoaiKH = @idloaikh, Ngaysinh = @ngaysinh, SoDT = @sodt, Diachi = @diachi, Chucvu = @chucvu, Gioitinh = @gioitinh, Ten = @ten " +
                    "WHERE IDKhachhang = @idkhachhang";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tongdiem", DbType.Int32, objKhachhang.Tongdiem);
                db.AddInParameter(dbCommand, "ngaybd", DbType.DateTime, objKhachhang.NgayBD);
                db.AddInParameter(dbCommand, "idloaikh", DbType.Int32, objKhachhang.IDLoaiKH);
                db.AddInParameter(dbCommand, "ngaysinh", DbType.DateTime, objKhachhang.Ngaysinh);
                db.AddInParameter(dbCommand, "sodt", DbType.String, objKhachhang.SoDT);
                db.AddInParameter(dbCommand, "diachi", DbType.String, objKhachhang.Diachi);
                db.AddInParameter(dbCommand, "chucvu", DbType.String, objKhachhang.Chucvu);
                db.AddInParameter(dbCommand, "gioitinh", DbType.String, objKhachhang.Gioitinh);
                db.AddInParameter(dbCommand, "ten", DbType.String, objKhachhang.Ten);
                db.AddInParameter(dbCommand, "idkhachhang", DbType.Int32, objKhachhang.IDKhachhang);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKhachhang(BKIT.Entities.Khachhang objKhachhang)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM Khachhang WHERE IDKhachhang = @idkhachhang";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idkhachhang", DbType.Int32, objKhachhang.IDKhachhang);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllKhachhang()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Khachhang";
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
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDKhachhang FROM Khachhang ORDER BY IDKhachhang";
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
