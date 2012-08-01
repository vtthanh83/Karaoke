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
    public class QueryService
    {
        public DataSet getDataByQuery(string query)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = query;
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
        public DataSet getDataByQuery(string query, string query1, string query2)
        {
            Database db = DatabaseFactory.CreateDatabase();
            //string sqlCommand = query;
            try
            {
                //DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                //DataSet ds = db.ExecuteDataSet(dbCommand);
                //dbCommand.Connection.Close();


                /////////////////////////////////
                DataSet ds = new DataSet();
                string strCommand = query;
                DbCommand dbCommand = db.GetSqlStringCommand(strCommand);

                DbDataAdapter dbDataAdapter = db.GetDataAdapter();
                dbDataAdapter.SelectCommand = dbCommand;
                dbDataAdapter.SelectCommand.Connection = db.CreateConnection();

                dbDataAdapter.Fill(ds, "HoadonXuat");

                strCommand = query2 + " Where  ChitietHDXuat.IDHoadonXuat in (" + query1 + ");";
                dbCommand = db.GetSqlStringCommand(strCommand);
                dbDataAdapter.SelectCommand = dbCommand;
                dbDataAdapter.SelectCommand.Connection = db.CreateConnection();

                dbDataAdapter.Fill(ds, "ChiTietHDXuat");

                DataColumn keyColumn = ds.Tables["HoadonXuat"].Columns["IDHoadonXuat"];
                DataColumn foreignKeyColumn = ds.Tables["ChiTietHDXuat"].Columns["IDHoadonXuat"];
                ds.Relations.Add("Chi tiết hóa đơn", keyColumn, foreignKeyColumn);

                dbCommand.Connection.Close();
                //////////////////////////////////
                return ds;
            }
            catch
            {
                return null;
            }
        }
        //public DataSet getTienPhong_PTByQuery(string query)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    string sqlCommand = query;
        //    try
        //    {
        //        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
        //        DataSet ds = db.ExecuteDataSet(dbCommand);
        //        dbCommand.Connection.Close();
        //        return ds;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
