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
    public class NhanvienService : INhanvien
    {
        public int insertNhanvien(BKIT.Entities.Nhanvien objNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO Nhanvien(IDNhanvien,Ten,Gioitinh,Chucvu,Diachi,SoDT,Ngaysinh,Loai,Username,[Password]) " +
                "VALUES (@idnhanvien,@ten,@gioitinh,@chucvu,@diachi,@sodt,@ngaysinh,@loai,@username,@password)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objNhanvien.IDNhanvien = ID;
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objNhanvien.IDNhanvien);
                db.AddInParameter(dbCommand, "ten", DbType.String, objNhanvien.Ten);
                db.AddInParameter(dbCommand, "gioitinh", DbType.String, objNhanvien.Gioitinh);
                db.AddInParameter(dbCommand, "chucvu", DbType.String, objNhanvien.Chucvu);
                db.AddInParameter(dbCommand, "diachi", DbType.String, objNhanvien.Diachi);
                db.AddInParameter(dbCommand, "sodt", DbType.String, objNhanvien.SoDT);
                db.AddInParameter(dbCommand, "ngaysinh", DbType.DateTime, objNhanvien.Ngaysinh);
                db.AddInParameter(dbCommand, "loai", DbType.String, objNhanvien.Loai);
                db.AddInParameter(dbCommand, "username", DbType.String, objNhanvien.Username);
                db.AddInParameter(dbCommand, "password", DbType.String, objNhanvien.Password);
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
        public bool updateNhanvien(BKIT.Entities.Nhanvien objNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE Nhanvien SET Ten = @ten, Gioitinh = @gioitinh, Chucvu = @chucvu, Diachi = @diachi, SoDT = @sodt, Ngaysinh = @ngaysinh, Loai = @loai, Username = @username, [Password] = @password " +
                    "WHERE IDNhanvien = @idnhanvien";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "ten", DbType.String, objNhanvien.Ten);
                db.AddInParameter(dbCommand, "gioitinh", DbType.String, objNhanvien.Gioitinh);
                db.AddInParameter(dbCommand, "chucvu", DbType.String, objNhanvien.Chucvu);
                db.AddInParameter(dbCommand, "diachi", DbType.String, objNhanvien.Diachi);
                db.AddInParameter(dbCommand, "sodt", DbType.String, objNhanvien.SoDT);
                db.AddInParameter(dbCommand, "ngaysinh", DbType.DateTime, objNhanvien.Ngaysinh);
                db.AddInParameter(dbCommand, "loai", DbType.String, objNhanvien.Loai);
                db.AddInParameter(dbCommand, "username", DbType.String, objNhanvien.Username);
                db.AddInParameter(dbCommand, "password", DbType.String, objNhanvien.Password);
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objNhanvien.IDNhanvien);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNhanvien(BKIT.Entities.Nhanvien objNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM Nhanvien WHERE IDNhanvien = @idnhanvien";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objNhanvien.IDNhanvien);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllNhanvien()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Nhanvien";
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
        public System.Data.DataSet getAllIDandNameNhanvien()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDNhanvien, Ten FROM Nhanvien";
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
        public Nhanvien getNhanvienByUsername_Password(string username, string password)
        {
            Nhanvien nv = null;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Nhanvien WHERE username = '" + username + 
                "' and [Password] = '" + password + "'";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        nv = new Nhanvien();
                        nv = (Nhanvien)getNhanvien(dataReader);
                    }
                    dataReader.Close();
                    dbCommand.Connection.Close();
                }
            }
            catch
            {
                return null;
            }
            return nv;
        }

        public Nhanvien getNhanvienByUsername(string p)
        {
            Nhanvien nv = null;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Nhanvien WHERE username = '" + p + "'";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        nv = new Nhanvien();
                        nv = (Nhanvien)getNhanvien(dataReader);
                    }
                    dataReader.Close();
                    dbCommand.Connection.Close();
                }
            }
            catch
            {
                return null;
            }
            return nv;
        }

        private Nhanvien getNhanvien(IDataReader dataReader)
        {

            Nhanvien nv = new Nhanvien();
            try
            {
                if (!DBNull.Value.Equals(dataReader["IDNhanvien"]))
                    nv.IDNhanvien = Convert.ToInt32(dataReader["IDNhanvien"].ToString().Trim());
                else
                    nv.IDNhanvien = 0;
                if (!DBNull.Value.Equals(dataReader["Ten"]))
                    nv.Ten = dataReader["Ten"].ToString().Trim();
                else
                    nv.Ten = "";
                if (!DBNull.Value.Equals(dataReader["GioiTinh"]))
                    nv.Gioitinh = dataReader["GioiTinh"].ToString().Trim();
                else
                    nv.Gioitinh = "Nam";
                if (!DBNull.Value.Equals(dataReader["Chucvu"]))
                    nv.Chucvu = dataReader["Chucvu"].ToString().Trim();
                else
                    nv.Chucvu = "";
                if (!DBNull.Value.Equals(dataReader["Diachi"]))
                    nv.Diachi = dataReader["Diachi"].ToString().Trim();
                else
                    nv.Diachi = "";
                if (!DBNull.Value.Equals(dataReader["SoDT"]))
                    nv.SoDT = dataReader["SoDT"].ToString().Trim();
                else
                    nv.SoDT = "";
                if (!DBNull.Value.Equals(dataReader["Ngaysinh"]))
                    nv.Ngaysinh = Convert.ToDateTime(dataReader["Ngaysinh"].ToString().Trim());
                else
                    nv.Ngaysinh = DateTime.Now;
                if (!DBNull.Value.Equals(dataReader["Loai"]))
                    nv.Loai = dataReader["Loai"].ToString().Trim();
                else
                    nv.Loai = "3";
                if (!DBNull.Value.Equals(dataReader["Username"]))
                    nv.Username = dataReader["Username"].ToString().Trim();
                else
                    nv.Username = "Guest";
                if (!DBNull.Value.Equals(dataReader["Password"]))
                    nv.Password = dataReader["Password"].ToString().Trim();
                else
                    nv.Password = "";
                if (!DBNull.Value.Equals(dataReader["IDQuyenTruyCap"]))
                    nv.IDQuyenTruycap = Convert.ToInt32(dataReader["IDQuyenTruyCap"].ToString().Trim());
                else
                    nv.IDQuyenTruycap = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred in getPerson function: -" + e.ToString());
            }
            return nv;
        }
        public int getIDNVByUsername(string usernameNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDNhanvien " +
                "FROM Nhanvien where Username='" + usernameNhanvien + "'";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return Convert.ToInt32(ds.Tables[0].Rows[0]["IDNhanvien"]);
            }
            catch
            {
                return -1;
            }
        }
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDNhanvien FROM Nhanvien ORDER BY IDNhanvien";
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
