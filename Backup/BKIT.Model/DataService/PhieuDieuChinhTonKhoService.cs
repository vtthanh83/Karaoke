
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
    public class PhieuDieuChinhTonKhoService : IPhieuDieuChinhTonKho
    {
        public int insertPhieuDieuChinhTonKho(BKIT.Entities.PhieuDieuChinhTonKho objPhieuDieuChinhTonKho)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO PhieuDieuChinhTonKho(ID,IDSanpham,SoluongDC,NgayDieuChinh,GhiChu) " +//
                "VALUES (@ID,@IDSanpham,@SoluongDC,@NgayDieuChinh,@GhiChu)";//,
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objPhieuDieuChinhTonKho.ID = ID;
                db.AddInParameter(dbCommand, "ID", DbType.Int32, objPhieuDieuChinhTonKho.ID);
                db.AddInParameter(dbCommand, "IDSanpham", DbType.Int32, objPhieuDieuChinhTonKho.IDSanpham);

                db.AddInParameter(dbCommand, "SoluongDC", DbType.Int32, objPhieuDieuChinhTonKho.SoluongDC);
                db.AddInParameter(dbCommand, "NgayDieuChinh", DbType.DateTime, objPhieuDieuChinhTonKho.NgayDieuChinh);
                db.AddInParameter(dbCommand, "GhiChu", DbType.String, objPhieuDieuChinhTonKho.GhiChu);
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
        public bool updatePhieuDieuChinhTonKho(BKIT.Entities.PhieuDieuChinhTonKho objPhieuDieuChinhTonKho)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE PhieuDieuChinhTonKho SET IDSanpham = @idsanpham, SoluongDC = @SoluongDC, NgayDieuChinh = @NgayDieuChinh, GhiChu = @GhiChu" +
                    " WHERE ID = @ID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                
                db.AddInParameter(dbCommand, "IDSanpham", DbType.Int32, objPhieuDieuChinhTonKho.IDSanpham);

                db.AddInParameter(dbCommand, "SoluongDC", DbType.Int32, objPhieuDieuChinhTonKho.SoluongDC);
                db.AddInParameter(dbCommand, "NgayDieuChinh", DbType.DateTime, objPhieuDieuChinhTonKho.NgayDieuChinh);
                db.AddInParameter(dbCommand, "GhiChu", DbType.String, objPhieuDieuChinhTonKho.GhiChu);
                
                db.AddInParameter(dbCommand, "ID", DbType.Int32, objPhieuDieuChinhTonKho.ID);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deletePhieuDieuChinhTonKho(BKIT.Entities.PhieuDieuChinhTonKho objPhieuDieuChinhTonKho)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM PhieuDieuChinhTonKho WHERE ID = @ID";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "ID", DbType.Int32, objPhieuDieuChinhTonKho.ID);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllPhieuDieuChinhTonKho()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT PhieuDieuChinhTonKho.*,SanPham.TenSanPham FROM PhieuDieuChinhTonKho,SanPham where PhieuDieuChinhTonKho.IDSanPham = SanPham.IDSanPham";
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
       
        //get all detail of a receipt
        public System.Data.DataSet getPhieuDieuChinhTonKhoByID(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * from PhieuDieuChinhTonKho WHERE ID = @ID";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ID", DbType.Int32, ID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getSLSPPhieuDieuChinhTonKhoByIDSanPham(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SUM(SoLuongDC) from PhieuDieuChinhTonKho WHERE IDSanPham = @IDSanPham";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "IDSanPham", DbType.Int32, IDSanPham);
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
            string sqlCommand = "SELECT ID FROM PhieuDieuChinhTonKho ORDER BY ID";
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
