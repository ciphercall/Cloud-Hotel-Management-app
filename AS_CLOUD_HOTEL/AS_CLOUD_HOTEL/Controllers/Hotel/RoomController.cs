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
    public class RoomController : AppController
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


        public RoomController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }






        public ASL_LOG aslLog = new ASL_LOG();


        // SAVE ALL INFORMATION from grid(HmlRoomType data) TO Asl_lOG Database Table.
        public void Insert_HML_ROOMTP_LogData(HML_RoomTpDTO model)
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
            aslLog.TABLEID = "HML_ROOMTP";
            aslLog.LOGDATA = Convert.ToString("Room Type Information Page. Room Type: " + model.RTPNM + ",\nRate (BDT):" + model.RATEBDT + ",\nRate (USD):" + model.RATEUSD + ",\nStatus:" + model.STATUS + ".");
            aslLog.USERPC = model.USERPC;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }





        // Edit ALL INFORMATION from Grid(HmlRoomType data) TO Asl_lOG Database Table.
        public void update_HML_ROOMTP_LogData(HML_RoomTpDTO model)
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
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_ROOMTP";
            aslLog.LOGDATA = Convert.ToString("Room Type Information Page. Room Type: " + model.RTPNM + ",\nRate (BDT):" + model.RATEBDT + ",\nRate (USD):" + model.RATEUSD + ",\nStatus:" + model.STATUS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }






        // Delete ALL INFORMATION from Grid(HmlRoomType data) TO Asl_lOG Database Table.
        public void Delete_HML_ROOMTP_LogData(HML_RoomTpDTO model)
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
            aslLog.TABLEID = "HML_ROOMTP";
            aslLog.LOGDATA = Convert.ToString("Room Type Information Page. Room Type: " + model.RTPNM + ",\nRate (BDT):" + model.RATEBDT + ",\nRate (USD):" + model.RATEUSD + ",\nStatus:" + model.STATUS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }








        // SAVE ALL INFORMATION from grid(HMLRoomNO data) TO Asl_lOG Database Table.
        public void Insert_HML_ROOM_LogData(HML_RoomDTO model)
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
            aslLog.TABLEID = "HML_ROOM";

            string roomType = "";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID==model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }

            aslLog.LOGDATA = Convert.ToString("Type wise Room No info. Room Type: " + roomType + ",\nRoom No:" + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }





        // Edit ALL INFORMATION from Grid(HMLRoomNO data) TO Asl_lOG Database Table.
        public void update_HML_ROOM_LogData(HML_RoomDTO model)
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
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_ROOM";
            
            string roomType = "";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }

            aslLog.LOGDATA = Convert.ToString("Type wise Room No info. Room Type: " + roomType + ",\nRoom No:" + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }






        // Delete ALL INFORMATION from Grid(HMLRoomNO data) TO Asl_lOG Database Table.
        public void Delete_HML_ROOM_LogData(HML_RoomDTO model)
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
            aslLog.TABLEID = "HML_ROOM";
            
            string roomType = "";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }
            aslLog.LOGDATA = Convert.ToString("Type wise Room No info. Room Type: " + roomType + ",\nRoom No:" + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }








        public ASL_DELETE AslDelete = new ASL_DELETE();

        // Delete ALL INFORMATION from HmlRoomType TO ASL_DELETE Database Table.
        public void Delete_HML_ROOMTP_LogDelete(HML_RoomTpDTO model)
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
            AslDelete.TABLEID = "HML_ROOMTP";
            AslDelete.DELDATA = Convert.ToString("Room Type Information Page. Room Type: " + model.RTPNM + ",\nRate (BDT):" + model.RATEBDT + ",\nRate (USD):" + model.RATEUSD + ",\nStatus:" + model.STATUS + ".");
            AslDelete.USERPC = strHostName;

            db.AslDeleteDbSet.Add(AslDelete);
            db.SaveChanges();
        }


        // Delete ALL INFORMATION from HmlRoomNO TO ASL_DELETE Database Table.
        public void Delete_HML_ROOM_LogDelete(HML_RoomDTO model)
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
            AslDelete.TABLEID = "HML_ROOM";
            
            string roomType = "";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }
            AslDelete.DELDATA = Convert.ToString("Type wise Room No info. Room Type: " + roomType + ",\nRoom No:" + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            AslDelete.USERPC = strHostName;

            db.AslDeleteDbSet.Add(AslDelete);
            db.SaveChanges();
        }




        // GET: get_RoomTypeInformation
        public ActionResult RoomTypeInformation()
        {
            return View();
        }


        public JsonResult Check_RoomType(string rtpnm)
        {
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());
            var result = db.HmlRoomTpDbSet.Count(d => d.RTPNM == rtpnm && d.COMPID == compid) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        // GET: TypeWiseRoomInformation
        public ActionResult TypeWiseRoomInformation()
        {
            return View();
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
