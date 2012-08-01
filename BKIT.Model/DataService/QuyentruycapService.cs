using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Model.IDataService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BKIT.Entities;

namespace BKIT.Model.DataService
{
    public class QuyenTruycapService : IQuyenTruycap
    {
        public int insertQuyenTruycap(BKIT.Entities.QuyenTruycap objQuyenTruycap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO QuyenTruycap(IDQuyentruycap,Ngaythietlap,TenLoaiNV,Vanhanh,HoadonNhap,Setting,Nhanvien,HoadonxuatSP,Sanpham,Phong,Report,Khachhang,Khuyenmai,Tonkho) " +
                "VALUES (@idquyentruycap,@ngaythietlap,@tenloainv,@vanhanh,@hoadonnhap,@setting,@nhanvien,@hoadonxuatsp,@sanpham,@phong,@report,@khachhang,@khuyenmai,@tonkho)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objQuyenTruycap.IDQuyentruycap = ID;
                db.AddInParameter(dbCommand, "idquyentruycap", DbType.Int32, objQuyenTruycap.IDQuyentruycap);
                db.AddInParameter(dbCommand, "ngaythietlap", DbType.DateTime, objQuyenTruycap.Ngaythietlap);
                db.AddInParameter(dbCommand, "tenloainv", DbType.String, objQuyenTruycap.TenLoaiNV);
                db.AddInParameter(dbCommand, "vanhanh", DbType.Int32, objQuyenTruycap.Vanhanh);
                db.AddInParameter(dbCommand, "hoadonnhap", DbType.Int32, objQuyenTruycap.HoadonNhap);
                db.AddInParameter(dbCommand, "setting", DbType.Int32, objQuyenTruycap.Setting);
                db.AddInParameter(dbCommand, "nhanvien", DbType.Int32, objQuyenTruycap.Nhanvien);
                db.AddInParameter(dbCommand, "hoadonxuatsp", DbType.Int32, objQuyenTruycap.HoadonxuatSP);
                db.AddInParameter(dbCommand, "sanpham", DbType.Int32, objQuyenTruycap.Sanpham);
                db.AddInParameter(dbCommand, "phong", DbType.Int32, objQuyenTruycap.Phong);
                db.AddInParameter(dbCommand, "report", DbType.Int32, objQuyenTruycap.Report);
                db.AddInParameter(dbCommand, "khachhang", DbType.Int32, objQuyenTruycap.Khachhang);
                db.AddInParameter(dbCommand, "khuyenmai", DbType.Int32, objQuyenTruycap.Khuyenmai);
                db.AddInParameter(dbCommand, "tonkho", DbType.Int32, objQuyenTruycap.Tonkho);
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
        public bool updateQuyenTruycap(BKIT.Entities.QuyenTruycap objQuyenTruycap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE QuyenTruycap SET Ngaythietlap = @ngaythietlap, TenLoaiNV = @tenloainv, Vanhanh = @vanhanh, HoadonNhap = @hoadonnhap, Setting = @setting, Nhanvien = @nhanvien, HoadonxuatSP = @hoadonxuatsp, Sanpham = @sanpham, Phong = @phong, Report = @report, Khachhang = @khachhang, Khuyenmai = @khuyenmai, Tonkho = @tonkho " +
                    "WHERE IDQuyentruycap = @idquyentruycap";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "ngaythietlap", DbType.DateTime, objQuyenTruycap.Ngaythietlap);
                db.AddInParameter(dbCommand, "tenloainv", DbType.String, objQuyenTruycap.TenLoaiNV);
                db.AddInParameter(dbCommand, "vanhanh", DbType.Int32, objQuyenTruycap.Vanhanh);
                db.AddInParameter(dbCommand, "hoadonnhap", DbType.Int32, objQuyenTruycap.HoadonNhap);
                db.AddInParameter(dbCommand, "setting", DbType.Int32, objQuyenTruycap.Setting);
                db.AddInParameter(dbCommand, "nhanvien", DbType.Int32, objQuyenTruycap.Nhanvien);
                db.AddInParameter(dbCommand, "hoadonxuatsp", DbType.Int32, objQuyenTruycap.HoadonxuatSP);
                db.AddInParameter(dbCommand, "sanpham", DbType.Int32, objQuyenTruycap.Sanpham);
                db.AddInParameter(dbCommand, "phong", DbType.Int32, objQuyenTruycap.Phong);
                db.AddInParameter(dbCommand, "report", DbType.Int32, objQuyenTruycap.Report);
                db.AddInParameter(dbCommand, "khachhang", DbType.Int32, objQuyenTruycap.Khachhang);
                db.AddInParameter(dbCommand, "khuyenmai", DbType.Int32, objQuyenTruycap.Khuyenmai);
                db.AddInParameter(dbCommand, "tonkho", DbType.Int32, objQuyenTruycap.Tonkho);
                db.AddInParameter(dbCommand, "idquyentruycap", DbType.Int32, objQuyenTruycap.IDQuyentruycap);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteQuyenTruycap(BKIT.Entities.QuyenTruycap objQuyenTruycap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM QuyenTruycap WHERE IDQuyentruycap = @idquyentruycap";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idquyentruycap", DbType.Int32, objQuyenTruycap.IDQuyentruycap);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllQuyenTruycap()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM QuyenTruycap";
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
        public System.Data.DataSet getQuyenTruycapByDate(string dt, string tenloainhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "";
            if (dt == "")
            {
                sqlCommand = "SELECT * FROM QuyenTruycap Where QuyenTruycap.TenLoaiNV = '" + 
                    tenloainhanvien + "' ORDER BY Ngaythietlap DESC";
            }
            else
            {
                sqlCommand = "SELECT * FROM QuyenTruycap WHERE QuyenTruycap.Ngaythietlap = #" + dt + 
                    "# and QuyenTruycap.TenLoaiNV = '" + tenloainhanvien + "' ORDER BY Ngaythietlap DESC;";
            }
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

        public QuyenTruycap getQuyenTruycapByID(int p)
        {
            QuyenTruycap quyentruycap = null;
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "";
            sqlCommand = "SELECT * FROM QuyenTruycap Where QuyenTruycap.IDQuyenTruycap = " + p.ToString();

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        quyentruycap = new QuyenTruycap();
                        quyentruycap = (QuyenTruycap)getQuyenTruycap(dataReader);
                    }
                    dataReader.Close();
                    dbCommand.Connection.Close();
                }
            }
            catch
            {
                return null;
            }
            return quyentruycap;

        }

        private QuyenTruycap getQuyenTruycap(IDataReader dataReader)
        {
            QuyenTruycap quyentruycap = new QuyenTruycap();
            try
            {
                if (!DBNull.Value.Equals(dataReader["IDQuyentruycap"]))
                    quyentruycap.IDQuyentruycap = Convert.ToInt32(dataReader["IDQuyentruycap"].ToString().Trim());
                else
                    quyentruycap.IDQuyentruycap = 0;
                
                if (!DBNull.Value.Equals(dataReader["Ngaythietlap"]))
                    quyentruycap.Ngaythietlap = Convert.ToDateTime(dataReader["Ngaythietlap"].ToString().Trim());
                else
                    quyentruycap.Ngaythietlap = DateTime.Now;

                if (!DBNull.Value.Equals(dataReader["TenLoaiNV"]))
                    quyentruycap.TenLoaiNV = dataReader["TenLoaiNV"].ToString().Trim();
                else
                    quyentruycap.TenLoaiNV = "";
                
                if (!DBNull.Value.Equals(dataReader["Vanhanh"]))
                    quyentruycap.Vanhanh = Convert.ToInt32(dataReader["Vanhanh"].ToString().Trim());
                else
                    quyentruycap.Vanhanh = 0;
               
                if (!DBNull.Value.Equals(dataReader["Hoadonnhap"]))
                    quyentruycap.HoadonNhap = Convert.ToInt32(dataReader["Hoadonnhap"].ToString().Trim());
                else
                    quyentruycap.HoadonNhap = 0;

                if (!DBNull.Value.Equals(dataReader["Setting"]))
                    quyentruycap.Setting = Convert.ToInt32(dataReader["Setting"].ToString().Trim());
                else
                    quyentruycap.Setting = 0;

                if (!DBNull.Value.Equals(dataReader["Nhanvien"]))
                    quyentruycap.Nhanvien = Convert.ToInt32(dataReader["Nhanvien"].ToString().Trim());
                else
                    quyentruycap.Nhanvien = 0;

                if (!DBNull.Value.Equals(dataReader["HoadonxuatSP"]))
                    quyentruycap.HoadonxuatSP = Convert.ToInt32(dataReader["HoadonxuatSP"].ToString().Trim());
                else
                    quyentruycap.HoadonxuatSP = 0;

                if (!DBNull.Value.Equals(dataReader["Sanpham"]))
                    quyentruycap.Sanpham = Convert.ToInt32(dataReader["Sanpham"].ToString().Trim());
                else
                    quyentruycap.Sanpham = 0;

                if (!DBNull.Value.Equals(dataReader["Phong"]))
                    quyentruycap.Phong = Convert.ToInt32(dataReader["Phong"].ToString().Trim());
                else
                    quyentruycap.Phong = 0;

                if (!DBNull.Value.Equals(dataReader["Report"]))
                    quyentruycap.Report = Convert.ToInt32(dataReader["Report"].ToString().Trim());
                else
                    quyentruycap.Report = 0;

                if (!DBNull.Value.Equals(dataReader["Khachhang"]))
                    quyentruycap.Khachhang = Convert.ToInt32(dataReader["Khachhang"].ToString().Trim());
                else
                    quyentruycap.Khachhang = 0;

                if (!DBNull.Value.Equals(dataReader["Khuyenmai"]))
                    quyentruycap.Khuyenmai = Convert.ToInt32(dataReader["Khuyenmai"].ToString().Trim());
                else
                    quyentruycap.Khuyenmai = 0;

                if (!DBNull.Value.Equals(dataReader["Tonkho"]))
                    quyentruycap.Tonkho = Convert.ToInt32(dataReader["Tonkho"].ToString().Trim());
                else
                    quyentruycap.Tonkho = 0;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred in getPerson function: -" + e.ToString());
            }
            return quyentruycap;
        }

        public bool IsSettingQuyenTruycap(string dt, string tenloainhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM QuyenTruycap where QuyenTruycap.Ngaythietlap = #" + dt + "# and QuyenTruycap.TenLoaiNV = '" + tenloainhanvien + "';";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
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
            string sqlCommand = "SELECT IDQuyentruycap FROM QuyenTruycap ORDER BY IDQuyentruycap";
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
