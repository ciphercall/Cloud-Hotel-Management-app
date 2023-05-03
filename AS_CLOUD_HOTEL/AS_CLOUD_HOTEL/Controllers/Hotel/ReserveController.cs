using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class ReserveController : AppController
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


        public ReserveController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }





        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_Reserve_LogData(HML_RESERVE model)
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
            aslLog.LOGIPNO = model.INSIPNO;
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_RESERVE";

            DateTime x = Convert.ToDateTime(model.RESVDT);
            String reserveDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Reservation Basic Creation Page.Reserve Date: " + reserveDate + ",\nReserve Year" + model.RESVYY + ",\nRESERVE-ID: " + model.RESVID + ",\nCHECKI: " + checki + ",\nGHECKO: " + ghecko + ",\nArrive Time: " + model.ARRIVETM + ",\nReserve Type: " + model.RESVTP + ",\nReserve Mode: " + model.RESVMODE + ",\nCustomer Name: " + model.CPNM + ",\nTelePhone: " + model.CPTELNO + ",\nEmail: " + model.CPEMAIL + ",\nMobile: " + model.CPMOBNO + ",\nGuest Name: " + model.GUESTNM + ",\nAdult No: " + model.ADULTQP + ",\nChild No: " + model.CHILDQP + ",\nCash Type: " + model.CCYTP + ",\nGRFID: " + model.GRFID + ",\nRESVSTATS: " + model.RESVSTATS + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_Reserve_LogData(HML_RESERVE model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.UPDUSERID;
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = model.UPDIPNO;
            aslLog.LOGLTUDE = model.UPDLTUDE;
            aslLog.TABLEID = "HML_RESERVE";

            DateTime x = Convert.ToDateTime(model.RESVDT);
            String reserveDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Reservation Basic Update Page.Reserve Date: " + reserveDate + ",\nReserve Year" + model.RESVYY + ",\nRESERVE-ID: " + model.RESVID + ",\nCHECKI: " + checki + ",\nGHECKO: " + ghecko + ",\nArrive Time: " + model.ARRIVETM + ",\nReserve Type: " + model.RESVTP + ",\nReserve Mode: " + model.RESVMODE + ",\nCustomer Name: " + model.CPNM + ",\nTelePhone: " + model.CPTELNO + ",\nEmail: " + model.CPEMAIL + ",\nMobile: " + model.CPMOBNO + ",\nGuest Name: " + model.GUESTNM + ",\nAdult No: " + model.ADULTQP + ",\nChild No: " + model.CHILDQP + ",\nCash Type: " + model.CCYTP + ",\nGRFID: " + model.GRFID + ",\nRESVSTATS: " + model.RESVSTATS + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_Reserve_LogData(HML_RESERVE model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.UPDUSERID;
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = model.UPDIPNO;
            aslLog.LOGLTUDE = model.UPDLTUDE;
            aslLog.TABLEID = "HML_RESERVE";

            DateTime x = Convert.ToDateTime(model.RESVDT);
            String reserveDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Reservation Basic Delete Page.Reserve Date: " + reserveDate + ",\nReserve Year" + model.RESVYY + ",\nRESERVE-ID: " + model.RESVID + ",\nCHECKI: " + checki + ",\nGHECKO: " + ghecko + ",\nArrive Time: " + model.ARRIVETM + ",\nReserve Type: " + model.RESVTP + ",\nReserve Mode: " + model.RESVMODE + ",\nCustomer Name: " + model.CPNM + ",\nTelePhone: " + model.CPTELNO + ",\nEmail: " + model.CPEMAIL + ",\nMobile: " + model.CPMOBNO + ",\nGuest Name: " + model.GUESTNM + ",\nAdult No: " + model.ADULTQP + ",\nChild No: " + model.CHILDQP + ",\nCash Type: " + model.CCYTP + ",\nGRFID: " + model.GRFID + ",\nRESVSTATS: " + model.RESVSTATS + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_Reserve_DELETE(HML_RESERVE model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("HH:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == model.COMPID && n.USERID == model.UPDUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(model.COMPID);
            AslDelete.USERID = model.UPDUSERID;
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = model.UPDIPNO;
            AslDelete.DELLTUDE = model.UPDLTUDE;
            AslDelete.TABLEID = "HML_RESERVE";

            DateTime x = Convert.ToDateTime(model.RESVDT);
            String reserveDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            AslDelete.DELDATA = Convert.ToString("Reservation Basic Delete Page.Reserve Date: " + reserveDate + ",\nReserve Year" + model.RESVYY + ",\nRESERVE-ID: " + model.RESVID + ",\nCHECKI: " + checki + ",\nGHECKO: " + ghecko + ",\nArrive Time: " + model.ARRIVETM + ",\nReserve Type: " + model.RESVTP + ",\nReserve Mode: " + model.RESVMODE + ",\nCustomer Name: " + model.CPNM + ",\nTelePhone: " + model.CPTELNO + ",\nEmail: " + model.CPEMAIL + ",\nMobile: " + model.CPMOBNO + ",\nGuest Name: " + model.GUESTNM + ",\nAdult No: " + model.ADULTQP + ",\nChild No: " + model.CHILDQP + ",\nCash Type: " + model.CCYTP + ",\nGRFID: " + model.GRFID + ",\nRESVSTATS: " + model.RESVSTATS + ",\nREMARKS: " + model.REMARKS + ".");
            AslDelete.USERPC = model.USERPC;
            db.AslDeleteDbSet.Add(AslDelete);
        }







        // GET: /Reserve/
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HML_RESERVE model)
        {
            if (ModelState.IsValid)
            {

                String reserveYear = Convert.ToString(model.RESVYY);
                String subString_Year = reserveYear.Substring(2, 2);

                Int64 findMax_RESVID = 0;
                try
                {
                    findMax_RESVID = Convert.ToInt64((from m in db.HmlReserveDbSet
                                                      where m.COMPID == model.COMPID && m.RESVYY == model.RESVYY
                                                      select m.RESVID).Max());
                    model.RESVID = findMax_RESVID + 1;
                }
                catch
                {
                    findMax_RESVID = Convert.ToInt64(subString_Year + "1" + "00001");
                    model.RESVID = findMax_RESVID;
                }


                Int64 max = Convert.ToInt64(subString_Year + "1" + "99999");
                if (model.RESVID <= max)
                {
                    model.USERPC = strHostName;
                    model.INSIPNO = ipAddress.ToString();
                    model.INSTIME = Convert.ToDateTime(td);
                    Insert_Reserve_LogData(model);
                    db.HmlReserveDbSet.Add(model);
                    db.SaveChanges();

                    var find_HML_CITEM = (from m in db.HmlCitemDbSet where m.COMPID == model.COMPID && m.DEFYN == "YES" select new{m.CITEMID}).ToList();
                    foreach (var getData in find_HML_CITEM)
                    {
                        HML_RESVCI complementaryITtem = new HML_RESVCI()
                        {
                            COMPID = Convert.ToInt64(model.COMPID),
                            RESVID = model.RESVID,
                            CITEMID = getData.CITEMID,

                            INSUSERID = model.INSUSERID,
                            INSIPNO = ipAddress.ToString(),
                            INSTIME = Convert.ToDateTime(td),
                            USERPC = strHostName,
                        };
                        db.HmlResrveCiDbSet.Add(complementaryITtem);   
                    }
                    db.SaveChanges();


                    TempData["ReserveCreateMessage"] = "Successfully created! Reservation ID: " + model.RESVID;
                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["ReserveCreateMessage"] = "Entry Not Possible ! ";
                    return RedirectToAction("Create");
                }
            }
            return View("Create");
        }







        //Get
        public ActionResult Update()
        {
            return View();
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(HML_RESERVE model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                model.USERPC = strHostName;
                model.UPDIPNO = ipAddress.ToString();
                model.UPDTIME = Convert.ToDateTime(td);
                model.UPDUSERID = model.UPDUSERID;

                Update_Reserve_LogData(model);
                db.SaveChanges();
                TempData["ReserveUpdateMessage"] = "Successfully updated! Reservation ID: "+model.RESVID;
                return RedirectToAction("Update");

            }
            return View("Update");

        }







        //Get
        public ActionResult Delete()
        {
            return View();
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HML_RESERVE model)
        {
            if (ModelState.IsValid)
            {
                var checkData = (from m in db.HmlReserveDbSet where m.ID == model.ID && m.COMPID == model.COMPID && m.RESVYY == model.RESVYY && m.RESVID == model.RESVID select m).ToList();
                if (checkData.Count == 1)
                {
                    HML_RESERVE deleteModel = db.HmlReserveDbSet.Find(model.ID, model.COMPID, model.RESVYY, model.RESVID);

                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.UPDLTUDE = model.UPDLTUDE;

                    var checkReserveRoom = (from m in db.HmlReserveRoomDbSet where m.COMPID == model.COMPID && m.RESVID == model.RESVID select m).ToList();
                    var checkReservePayment = (from m in db.HmlReservePayDbSet where m.COMPID == model.COMPID && m.RESVID == model.RESVID select m).ToList();

                    if (checkReserveRoom.Count == 0 && checkReservePayment.Count == 0)
                    { 
                        Delete_Reserve_DELETE(model);
                        Delete_Reserve_LogData(model);
                        db.HmlReserveDbSet.Remove(deleteModel);
                        db.SaveChanges();

                        var find_HML_RESVCI = (from m in db.HmlResrveCiDbSet where m.COMPID == model.COMPID && m.RESVID == model.RESVID select m).ToList();
                        foreach (var getData in find_HML_RESVCI)
                        {
                            db.HmlResrveCiDbSet.Remove(getData);
                        }
                        db.SaveChanges();

                        TempData["ReserveDeleteMessage"] = "Successfully deleted! Reservation ID: " + model.RESVID;
                    }
                    else
                    {
                        TempData["ReserveDeleteMessage"] = "Firsty Delete Reserve-ID wise Room & Payment details!";
                    }



                    return RedirectToAction("Delete");
                }
            }
            return View();
        }





        public JsonResult ReserveIDload(string theDate, string compid)
        {
            Int64 comid = Convert.ToInt64(compid);
            DateTime dt = Convert.ToDateTime(theDate);

            String year = dt.ToString("yyyy");
            Int64 reserveYear = Convert.ToInt64(year);

            List<SelectListItem> reservidList = new List<SelectListItem>();
            var list = (from n in db.HmlReserveDbSet
                        where n.RESVDT == dt && n.COMPID == comid && n.RESVYY == reserveYear
                        select new
                        {
                            n.RESVID
                        }
                            )
                            .Distinct()
                            .ToList();

            if (list.Count != 0)
            {
                foreach (var f in list)
                {
                    reservidList.Add(new SelectListItem { Text = f.RESVID.ToString(), Value = f.RESVID.ToString() });
                }
            }
            else
            {
                reservidList.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(reservidList, "Value", "Text"));
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReserveData(string companyid, string datetxt, string txt_RESVID)
        {
            var companyID = Convert.ToInt16(companyid);
            DateTime dt = Convert.ToDateTime(datetxt);
            Int64 reserveID = Convert.ToInt64(txt_RESVID);

            Int64 insertUserId = 0, id = 0, year = 0, AdultQp = 0, ChildQp = 0, GrFid = 0;
            String inserttime = "", insertIpno = "", insltude = "";
            String checcki = "", ghecKo = "", arrivetm = "", resVtp = "", resvMode = "", cpName = "", CpTelNo = "", CpEmail = "", CpmobileNo = "", GuestName = "", CcyTp = "", ResvStats = "", remarks = "";
            var getData = (from m in db.HmlReserveDbSet where m.COMPID == companyID && m.RESVDT == dt && m.RESVID == reserveID select m).ToList();

            foreach (var get in getData)
            {
                id = get.ID;
                year = Convert.ToInt64(get.RESVYY);

                DateTime a = Convert.ToDateTime(get.CHECKI);
                checcki = a.ToString("dd-MMM-yyyy");

                DateTime b = Convert.ToDateTime(get.GHECKO);
                ghecKo = b.ToString("dd-MMM-yyyy");

                arrivetm = get.ARRIVETM;
                resVtp = get.RESVTP;
                resvMode = get.RESVMODE;
                cpName = get.CPNM;
                CpTelNo = get.CPTELNO;
                CpEmail = get.CPEMAIL;
                CpmobileNo = Convert.ToString(get.CPMOBNO);
                GuestName = get.GUESTNM;
                AdultQp = get.ADULTQP;
                ChildQp = get.CHILDQP;
                CcyTp = Convert.ToString(get.CCYTP);
                if (get.GRFID != null)
                {
                    GrFid = Convert.ToInt64(get.GRFID);
                }
                
                ResvStats = get.RESVSTATS;
                remarks = get.REMARKS;

                insertUserId = get.INSUSERID;
                inserttime = Convert.ToString(get.INSTIME);
                insertIpno = Convert.ToString(get.INSIPNO);
                insltude = Convert.ToString(get.INSLTUDE);
            }

            var result = new
            {
                ID = id,
                RESVYY = year,
                CHECKI = checcki,
                GHECKO = ghecKo,
                ARRIVETM = arrivetm,
                RESVTP = resVtp,
                RESVMODE = resvMode,
                CPNM = cpName,
                CPTELNO = CpTelNo,
                CPEMAIL = CpEmail,
                CPMOBNO = CpmobileNo,
                GUESTNM = GuestName,
                ADULTQP = AdultQp,
                CHILDQP = ChildQp,
                CCYTP = CcyTp,
                GRFID = GrFid,
                RESVSTATS = ResvStats,
                REMARKS = remarks,

                INSUSERID = insertUserId,
                INSTIME = inserttime,
                INSIPNO = insertIpno,
                INSLTUDE = insltude
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
