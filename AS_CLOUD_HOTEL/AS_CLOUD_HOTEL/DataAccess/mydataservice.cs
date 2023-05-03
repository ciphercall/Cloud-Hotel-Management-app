using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.DataAccess
{
    public class mydataservice
    {

        public IEnumerable TopcategoriesListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format("SELECT STK_ITEMMST.CATNM AS CATNM, SUM(STK_TRANS.GROSSAMT) AS VALUE " +
                       " FROM  STK_ITEM INNER JOIN " +
                  " STK_TRANS ON STK_ITEM.COMPID = STK_TRANS.COMPID AND STK_ITEM.ITEMID = STK_TRANS.ITEMID INNER JOIN " +
                "  STK_ITEMMST ON STK_ITEM.CATID = STK_ITEMMST.CATID " +
                " WHERE STK_TRANS.TRANSTP = 'SALE' AND STK_TRANS.COMPID='" + loggedcompid + "' AND STK_TRANS.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "' " +
                " GROUP BY STK_ITEMMST.CATNM " +
                " ORDER BY VALUE DESC ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["CATNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }



        public IEnumerable TopItemsByQtyListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format("SELECT STK_ITEM.ITEMNM AS ITEMNM, SUM(STK_TRANS.QTY) QTY " +
                      " FROM  STK_ITEM INNER JOIN " +
                      " STK_TRANS ON STK_ITEM.COMPID = STK_TRANS.COMPID AND STK_ITEM.ITEMID = STK_TRANS.ITEMID " +
                      " WHERE STK_TRANS.TRANSTP = 'SALE' AND STK_TRANS.COMPID='" + loggedcompid + "' AND STK_TRANS.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "' " +
                      " GROUP BY STK_ITEM.ITEMNM " +
                      " ORDER BY QTY DESC  ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["QTY"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }




        public IEnumerable TopItemsByValueListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format("SELECT STK_ITEM.ITEMNM AS ITEMNM, SUM(STK_TRANS.GROSSAMT) VALUE  " +
                    " FROM STK_ITEM INNER JOIN " +
                   "   STK_TRANS ON STK_ITEM.COMPID = STK_TRANS.COMPID AND STK_ITEM.ITEMID = STK_TRANS.ITEMID " +
                    " WHERE STK_TRANS.TRANSTP = 'SALE' AND STK_TRANS.COMPID='" + loggedcompid + "' AND STK_TRANS.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'" +
                   "   GROUP BY STK_ITEM.ITEMNM " +
                    "  ORDER BY VALUE DESC");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }




        public IEnumerable CollectionDataListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format(" SELECT  CONVERT(NVARCHAR(20),TRANSDT,103) AS TRANSDT, SUM(TOTNET) COLLECT " +
                " FROM STK_TRANSMST " +
                " WHERE TRANSTP='SALE' AND COMPID='" + loggedcompid + "' AND TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'  " +
                " GROUP BY TRANSDT");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["TRANSDT"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["COLLECT"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }



        public IEnumerable TimeWiseSellDataListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format(" SELECT DISTINCT CONVERT(NVARCHAR(20),dateadd(hour, datediff(hour, 0, dateadd(mi, 30, INSTIME)), 0) ,108) AS INSTIME, SUM(TOTGROSS) AMOUNT " +
                " FROM STK_TRANSMST " +
                " WHERE TRANSTP='SALE' AND COMPID='" + loggedcompid + "' AND TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'" +
               " GROUP BY CONVERT(NVARCHAR(20),dateadd(hour, datediff(hour, 0, dateadd(mi, 30, INSTIME)), 0) ,108)");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["INSTIME"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["AMOUNT"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }





        //Hotel
        public IEnumerable TopServiceByValueListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format("SELECT HML_BILLHP.BILLNM AS ITEMNM, SUM(HML_BILLDTL.AMOUNT) VALUE  " +
                    " FROM HML_BILLHP INNER JOIN " +
                   "   HML_BILLDTL ON HML_BILLHP.COMPID = HML_BILLDTL.COMPID AND HML_BILLHP.BILLID = HML_BILLDTL.BILLID " +
                    " WHERE HML_BILLDTL.COMPID='" + loggedcompid + "' AND HML_BILLDTL.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'" +
                   "   GROUP BY HML_BILLHP.BILLNM " +
                    "  ORDER BY VALUE DESC");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }




        //Hotel
        public IEnumerable TopRoomsByQtyListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format("SELECT HML_BILL.ROOMNO AS ITEMNM, COUNT(*) AS QTY " +
                      " FROM  HML_BILL " +
                      " WHERE HML_BILL.COMPID='" + loggedcompid + "' AND HML_BILL.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "' " +
                      " GROUP BY HML_BILL.ROOMNO " +
                      " ORDER BY QTY DESC  ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["QTY"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }




        //Hotel
        public IEnumerable TopRoomCategoriesListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format("SELECT HML_ROOMTP.RTPNM AS CATNM, SUM(HML_BILLDTL.AMOUNT) AS VALUE " +
                        "   FROM  HML_ROOM INNER JOIN " +
                   "   HML_BILLDTL ON HML_ROOM.COMPID = HML_BILLDTL.COMPID AND HML_ROOM.ROOMNO = HML_BILLDTL.ROOMNO INNER JOIN " +
                   "  HML_ROOMTP ON HML_ROOM.COMPID = HML_ROOMTP.COMPID AND HML_ROOM.RTPID = HML_ROOMTP.RTPID " +
                  "  WHERE HML_BILLDTL.COMPID='" + loggedcompid + "' AND HML_BILLDTL.BILLID = '" + loggedcompid + "'+'01' AND HML_BILLDTL.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "' " +
                  "  GROUP BY HML_ROOMTP.RTPNM " +
                  "  ORDER BY VALUE DESC ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["CATNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }






        //Hotel

        public IEnumerable Reserve_Reggistration_CollectionDataListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CLoudHotelDbContext"].ToString());

            var query = string.Format(" SELECT  CONVERT(NVARCHAR(20),TRANSDT,103) AS TRANSDT, SUM(DEBITAMT) COLLECT " +
                  " FROM GL_MASTER " +
                  " WHERE TRANSTP='MREC' AND COMPID='" + loggedcompid + "' AND TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'  AND TABLEID IN ('HML_BILL','HML_RESVPAY','HML_REGNPAY') " +
                  " GROUP BY TRANSDT");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["TRANSDT"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["COLLECT"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }
    }
}