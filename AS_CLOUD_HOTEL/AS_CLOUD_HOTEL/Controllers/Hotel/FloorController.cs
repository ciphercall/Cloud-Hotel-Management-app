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
    public class FloorController : AppController
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


        public FloorController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }






        public ASL_LOG aslLog = new ASL_LOG();


        // SAVE ALL INFORMATION from grid(Floor data) TO Asl_lOG Database Table.
        public void Insert_HML_FLOOR_LogData(HML_FloorDTO model)
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
            aslLog.TABLEID = "HML_FLOOR";
            aslLog.LOGDATA = Convert.ToString("Floor information page. Floor Name: " + model.FLOORNM + ",\nRemarks:" + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }





        // Edit ALL INFORMATION from Grid(Floor data) TO Asl_lOG Database Table.
        public void update_HML_FLOOR_LogData(HML_FloorDTO model)
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
            aslLog.TABLEID = "HML_FLOOR";
            aslLog.LOGDATA = Convert.ToString("Floor information page. Floor Name: " + model.FLOORNM + ",\nRemarks:" + model.REMARKS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }






        // Delete ALL INFORMATION from Grid(Floor data) TO Asl_lOG Database Table.
        public void Delete_HML_FLOOR_LogData(HML_FloorDTO model)
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
            aslLog.TABLEID = "HML_FLOOR";
            aslLog.LOGDATA = Convert.ToString("Floor information page. Floor Name: " + model.FLOORNM + ",\nRemarks:" + model.REMARKS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }











        // SAVE ALL INFORMATION from grid(FloorPlan data) TO Asl_lOG Database Table.
        public void Insert_HML_FLOORPLAN_LogData(HML_FloorPlanDTO model)
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
            aslLog.TABLEID = "HML_FLOORPLAN";

            string roomType = "", floorName = "";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }
            var find_FloorType = (from n in db.HmlFloorDbSet where n.COMPID == model.COMPID && n.FLOORID == model.FLOORID select n).ToList();
            foreach (var item in find_FloorType)
            {
                floorName = item.FLOORNM;
            }

            aslLog.LOGDATA = Convert.ToString("Floor wise plan info. Floor Name: " + floorName + ",\nRoom Type: " + roomType + ",\nRoom No: " + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }

        
        // Delete ALL INFORMATION from Grid(FloorPlan data) TO Asl_lOG Database Table.
        public void Delete_HML_FLOORPLAN_LogData(HML_FloorPlanDTO model)
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
            aslLog.TABLEID = "HML_FLOORPLAN";

            string roomType = "",floorName="";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }
            var find_FloorType = (from n in db.HmlFloorDbSet where n.COMPID == model.COMPID && n.FLOORID == model.FLOORID select n).ToList();
            foreach (var item in find_FloorType)
            {
                floorName = item.FLOORNM;
            }

            aslLog.LOGDATA = Convert.ToString("Floor wise plan info. Floor Name: " + floorName +",\nRoom Type: "+roomType+ ",\nRoom No: " + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }








        public ASL_DELETE AslDelete = new ASL_DELETE();

        // Delete ALL INFORMATION from Floor TO ASL_DELETE Database Table.
        public void Delete_HML_FLOOR_LogDelete(HML_FloorDTO model)
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
            AslDelete.TABLEID = "HML_FLOOR";
            AslDelete.DELDATA = Convert.ToString("Floor information page. Floor Name: " + model.FLOORNM + ",\nRemarks:" + model.REMARKS + ".");
            AslDelete.USERPC = strHostName;

            db.AslDeleteDbSet.Add(AslDelete);
            db.SaveChanges();
        }


        // Delete ALL INFORMATION from FloorPlan TO ASL_DELETE Database Table.
        public void Delete_HML_FLOORPLAN_LogDelete(HML_FloorPlanDTO model)
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
            AslDelete.TABLEID = "HML_FLOORPLAN";

            string roomType = "", floorName = "";
            var find_RoomType = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in find_RoomType)
            {
                roomType = item.RTPNM;
            }
            var find_FloorType = (from n in db.HmlFloorDbSet where n.COMPID == model.COMPID && n.FLOORID == model.FLOORID select n).ToList();
            foreach (var item in find_FloorType)
            {
                floorName = item.FLOORNM;
            }

            AslDelete.DELDATA = Convert.ToString("Floor wise plan info. Floor Name: " + floorName + ",\nRoom Type: " + roomType + ",\nRoom No: " + model.ROOMNO + ",\nRemarks :" + model.REMARKS + ".");
            AslDelete.USERPC = strHostName;

            db.AslDeleteDbSet.Add(AslDelete);
            db.SaveChanges();
        }




        // GET: get_RoomTypeInformation
        public ActionResult Floor()
        {
            return View();
        }



        // GET: TypeWiseRoomInformation
        public ActionResult FloorPlan()
        {
            return View();
        }





        public JsonResult RoomNoload(String type, String compid)
        {
            List<SelectListItem> rooms = new List<SelectListItem>();
            if (type == "")
            {
                rooms.Add(new SelectListItem { Text = null, Value = null });
            }
            else
            {
                Int64 companyid = Convert.ToInt64(compid);
                Int64 Rtpid = Convert.ToInt64(type);

                var transres = (from n in db.HmlRoomDbSet
                                where n.COMPID == companyid && n.RTPID == Rtpid
                                select new
                                {
                                    n.ROOMNO
                                }
                                ).OrderBy(e => e.ROOMNO)
                                .Distinct()
                                .ToList();

                String roomNO = null;
                foreach (var f in transres)
                {
                    rooms.Add(new SelectListItem { Text = f.ROOMNO.ToString(), Value = f.ROOMNO.ToString() });
                }
            }
            return Json(new SelectList(rooms, "Value", "Text"));
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
