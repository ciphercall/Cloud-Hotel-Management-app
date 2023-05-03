using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class ReserveComplementaryItemController : AppController
    {
        //Datetime formet
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;

        CLoudHotelDbContext db = new CLoudHotelDbContext();
        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;


        public ReserveComplementaryItemController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }





        public ASL_LOG aslLog = new ASL_LOG();


        // SAVE ALL INFORMATION from grid(HML_RESVCI data) TO Asl_lOG Database Table.
        public void Insert_HML_RESVCI_LogData(HML_ReserveCiDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }


            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.INSUSERID;
            aslLog.LOGTYPE = "INSERT";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_RESVCI";

            string itemName = "";
            var find_RoomType = (from n in db.HmlCitemDbSet where n.COMPID == model.COMPID &&  n.CITEMID==model.CITEMID select n).ToList();
            foreach (var item in find_RoomType)
            {
                itemName = item.CITEMNM;
            }

            aslLog.LOGDATA = Convert.ToString("Reserve Complementary Item information page. Reserve ID: " + model.RESVID + ",\nComplementary Item : " + itemName + ",\nDefault: " + model.DEFYN + ".");
            aslLog.USERPC = model.USERPC;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }





        // Edit ALL INFORMATION from Grid(HML_RESVCI data) TO Asl_lOG Database Table.
        //public void update_HML_RESVCI_LogData(HML_ReserveCiDTO model)
        //{
        //    TimeZoneInfo timeZoneInfo;
        //    timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        //    DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        //    var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
        //    var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

        //    Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.LOGSLNO).Max());
        //    if (maxSerialNo == 0)
        //    {
        //        aslLog.LOGSLNO = Convert.ToInt64("1");
        //    }
        //    else
        //    {
        //        aslLog.LOGSLNO = maxSerialNo + 1;
        //    }

        //    aslLog.COMPID = Convert.ToInt64(model.COMPID);
        //    aslLog.USERID = model.INSUSERID;
        //    aslLog.LOGTYPE = "UPDATE";
        //    aslLog.LOGSLNO = aslLog.LOGSLNO;
        //    aslLog.LOGDATE = Convert.ToDateTime(date);
        //    aslLog.LOGTIME = Convert.ToString(time);
        //    aslLog.LOGIPNO = ipAddress.ToString();
        //    aslLog.LOGLTUDE = model.INSLTUDE;
        //    aslLog.TABLEID = "HML_RESVCI";
        //    aslLog.LOGDATA = Convert.ToString("Reserve Complementary Item information page. Reserve ID: " + model.RESVID + ",\nComplementary Item : " + model.CITEMNM + ",\nDefault: " + model.DEFYN + ".");
        //    aslLog.USERPC = strHostName;

        //    db.AslLogDbSet.Add(aslLog);
        //    db.SaveChanges();
        //}






        // Delete ALL INFORMATION from Grid(HML_RESVCI data) TO Asl_lOG Database Table.
        public void Delete_HML_RESVCI_LogData(HML_ReserveCiDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.INSUSERID;
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_RESVCI";
            string itemName = "";
            var find_RoomType = (from n in db.HmlCitemDbSet where n.COMPID == model.COMPID && n.CITEMID == model.CITEMID select n).ToList();
            foreach (var item in find_RoomType)
            {
                itemName = item.CITEMNM;
            }
            aslLog.LOGDATA = Convert.ToString("Reserve Complementary Item information page. Reserve ID: " + model.RESVID + ",\nComplementary Item : " + itemName + ",\nDefault: " + model.DEFYN + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }


        public ASL_DELETE AslDelete = new ASL_DELETE();

        // Delete ALL INFORMATION from HML_RESVCI TO ASL_DELETE Database Table.
        public void Delete_HML_RESVCI_LogDelete(HML_ReserveCiDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(model.COMPID);
            AslDelete.USERID = model.INSUSERID;
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = ipAddress.ToString();
            AslDelete.DELLTUDE = model.INSLTUDE;
            AslDelete.TABLEID = "HML_RESVCI";

            string itemName = "";
            var find_RoomType = (from n in db.HmlCitemDbSet where n.COMPID == model.COMPID && n.CITEMID == model.CITEMID select n).ToList();
            foreach (var item in find_RoomType)
            {
                itemName = item.CITEMNM;
            }
            AslDelete.DELDATA = Convert.ToString("Reserve Complementary Item information page. Reserve ID: " + model.RESVID + ",\nComplementary Item : " + itemName + ",\nDefault: " + model.DEFYN + ".");
            AslDelete.USERPC = strHostName;

            db.AslDeleteDbSet.Add(AslDelete);
            db.SaveChanges();
        }



        public ActionResult Index()
        {
            return View();
        }




        public JsonResult ComplementaryItemLoad(String reserveID, String theDate, String companyid)
        {
            Int64 comid = Convert.ToInt64(companyid);
            DateTime dt = Convert.ToDateTime(theDate);
            String year = dt.ToString("yyyy");
            Int64 reserveYear = Convert.ToInt64(year);
            Int64 resvID = Convert.ToInt64(reserveID);

            List<SelectListItem> complementaryItemList = new List<SelectListItem>();
             var list = (from n in db.HmlCitemDbSet
                        where n.COMPID == comid 
                        select new
                        {
                            n.CITEMID,n.CITEMNM
                        }
                            )
                            .Distinct()
                            .ToList();
            
            if (list.Count != 0)
            {
                foreach (var f in list)
                {
                    var list2 = (from n in db.HmlResrveCiDbSet where n.COMPID == comid && n.CITEMID == f.CITEMID && n.RESVID == resvID select n).ToList();
                    if (list2.Count == 0)
                    {
                        complementaryItemList.Add(new SelectListItem { Text = f.CITEMNM.ToString(), Value = f.CITEMID.ToString() });
                    }
                }
            }
            else
            {
                complementaryItemList.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(complementaryItemList, "Value", "Text"));
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
