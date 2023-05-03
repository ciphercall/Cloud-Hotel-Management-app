using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class ReservePaymentController : AppController
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


        public ReservePaymentController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_ReservationPayment_LogData(HML_RESVPAY model)
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
            aslLog.TABLEID = "HML_RESVPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Reservation Payment Create Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nRESERVE-ID: " + model.RESVID + ",\nTRMODE: " + model.TRMODE + ",\nCCYTP: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_ReservationPayment_LogData(HML_RESVPAY model)
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
            aslLog.TABLEID = "HML_RESVPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Reservation Payment Update Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nRESERVE-ID: " + model.RESVID + ",\nTRMODE: " + model.TRMODE + ",\nCCYTP: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_ReservationPayment_LogData(HML_RESVPAY model)
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
            aslLog.TABLEID = "HML_RESVPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Reservation Payment Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nRESERVE-ID: " + model.RESVID + ",\nTRMODE: " + model.TRMODE + ",\nCCYTP: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_ReservationPayment_DELETE(HML_RESVPAY model)
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
            AslDelete.TABLEID = "HML_RESVPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            AslDelete.DELDATA = Convert.ToString("Reservation Payment Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nRESERVE-ID: " + model.RESVID + ",\nTRMODE: " + model.TRMODE + ",\nCCYTP: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
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
        public ActionResult Create(HML_RESVPAY model, String command)
        {
            if (ModelState.IsValid)
            {
                var searchReservID = (from m in db.HmlReserveDbSet where m.COMPID == model.COMPID && m.RESVID==model.RESVID select new { m.RESVID }).ToList();

                if (searchReservID.Count == 0)
                {
                    ViewBag.ReserveID_ValidationMessage = "Please select valid Reserve ID! ";
                    return View("Create");
                }
                else
                {
                    String reserveYear = Convert.ToString(model.TRANSMY);
                    String subString_Year = reserveYear.Substring(4, 2);

                    DateTime transDate = Convert.ToDateTime(model.TRANSDT);
                    String date = transDate.ToString("MM");

                    Int64 findMax_TRANSNO = 0;
                    try
                    {
                        findMax_TRANSNO = Convert.ToInt64((from m in db.HmlReservePayDbSet
                                                           where m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY
                                                           select m.TRANSNO).Max());
                        model.TRANSNO = findMax_TRANSNO + 1;
                    }
                    catch
                    {
                        findMax_TRANSNO = Convert.ToInt64(subString_Year + date + "0001");
                        model.TRANSNO = findMax_TRANSNO;
                    }


                    Int64 max = Convert.ToInt64(subString_Year + date + "99999");
                    if (model.TRANSNO <= max)
                    {
                        model.USERPC = strHostName;
                        model.INSIPNO = ipAddress.ToString();
                        model.INSTIME = Convert.ToDateTime(td);
                        Insert_ReservationPayment_LogData(model);
                        db.HmlReservePayDbSet.Add(model);
                        db.SaveChanges();

                        TempData["ReservePaymentCreateMessage"] = "Successfully created-Transaction NO: "+model.TRANSNO;
                        if (command == "Memo")
                        {
                            TempData["ReservePaymentViewModel"] = model;
                            return RedirectToAction("ReservePayment_ReportPage", "HotelReport");
                        }
                        else
                        {
                            return RedirectToAction("Create");
                        }
                    }
                    else
                    {
                        TempData["ReservePaymentCreateMessage"] = "Entry Not Possible ! ";
                        return RedirectToAction("Create");
                    }
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
        public ActionResult Update(HML_RESVPAY model, String command)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                model.USERPC = strHostName;
                model.UPDIPNO = ipAddress.ToString();
                model.UPDTIME = Convert.ToDateTime(td);
                model.UPDUSERID = model.UPDUSERID;

                Update_ReservationPayment_LogData(model);
                db.SaveChanges();
                TempData["ReservePaymentUpdateMessage"] = "Successfully updated-Transaction NO: " + model.TRANSNO;
                if (command == "Memo")
                {
                    TempData["ReservePaymentViewModel"] = model;
                    return RedirectToAction("ReservePayment_ReportPage", "HotelReport");
                }
                else
                {
                    return RedirectToAction("Update");
                }

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
        public ActionResult Delete(HML_RESVPAY model)
        {
            if (ModelState.IsValid)
            {
                var checkData = (from m in db.HmlReservePayDbSet where m.ID == model.ID && m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY && m.TRANSNO == model.TRANSNO select m).ToList();
                if (checkData.Count == 1)
                {
                    HML_RESVPAY deleteModel = db.HmlReservePayDbSet.Find(model.ID, model.COMPID, model.TRANSMY, model.TRANSNO);

                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.UPDLTUDE = model.UPDLTUDE;

                    Delete_ReservationPayment_DELETE(model);
                    Delete_ReservationPayment_LogData(model);
                    db.SaveChanges();
                    db.HmlReservePayDbSet.Remove(deleteModel);
                    db.SaveChanges();
                    TempData["ReservePaymentDeleteMessage"] = "Successfully deleted-Transaction NO: " + model.TRANSNO; 
                    return RedirectToAction("Delete");
                }
            }
            return View();
        }




        public JsonResult GetMonthYear(String theDate)
        {
            DateTime dt = Convert.ToDateTime(theDate);
            String monthYear = dt.ToString("MMM-yy");
            var myear = new { MonthYear = monthYear };
            return Json(myear, JsonRequestBehavior.AllowGet);
        }


        public JsonResult TagSearch_reserveID(String character, String compid, String reservdate)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);

            if (reservdate != "")
            {
                DateTime resrvDate = Convert.ToDateTime(reservdate);
                var findReferName =
                    (from m in db.HmlReserveDbSet
                     where m.COMPID == companyID && m.RESVDT == resrvDate
                     select new { m.RESVID }).ToList();
                foreach (var a in findReferName)
                {
                    result.Add(a.RESVID.ToString());
                }
            }
            else
            {
                var findReferName =
                    (from m in db.HmlReserveDbSet
                     where m.COMPID == companyID
                     select new { m.RESVID }).ToList();
                foreach (var a in findReferName)
                {
                    result.Add(a.RESVID.ToString());
                }
            }


            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_reserveID(String changedText, String compid, String reservdate)
        {
            var companyID = Convert.ToInt16(compid);
            String itemId = "";
            List<string> list = new List<string>();
            if (reservdate != "")
            {
                DateTime resrvDate = Convert.ToDateTime(reservdate);
                var findReferName =
                    (from m in db.HmlReserveDbSet
                     where m.COMPID == companyID && m.RESVDT == resrvDate
                     select new { m.RESVID }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.RESVID.ToString());
                }
            }
            else
            {
                var findReferName =
                    (from m in db.HmlReserveDbSet
                     where m.COMPID == companyID
                     select new { m.RESVID }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.RESVID.ToString());
                }
            }


            var rt = list.Where(t => t.StartsWith(changedText)).ToList();

            int lenChangedtxt = changedText.Length;

            Int64 cont = rt.Count();
            Int64 k = 0;
            string status = "";
            if (changedText != "" && cont != 0)
            {
                while (status != "no")
                {
                    k = 0;
                    foreach (var n in rt)
                    {
                        string ss = Convert.ToString(n);
                        string subss = "";
                        if (ss.Length >= lenChangedtxt)
                        {
                            subss = ss.Substring(0, lenChangedtxt);
                            subss = subss.ToUpper();
                        }
                        else
                        {
                            subss = "";
                        }


                        if (subss == changedText.ToUpper())
                        {
                            k++;
                        }
                        if (k == cont)
                        {
                            status = "yes";
                            lenChangedtxt++;
                            if (ss.Length > lenChangedtxt - 1)
                            {
                                changedText = changedText + ss[lenChangedtxt - 1];
                            }

                        }
                        else
                        {
                            status = "no";
                            //lenChangedtxt--;
                        }

                    }

                }
                if (lenChangedtxt == 1)
                {
                    itemId = changedText.Substring(0, lenChangedtxt);
                }

                else
                {
                    itemId = changedText.Substring(0, lenChangedtxt - 1);
                }
            }
            else
            {
                itemId = changedText;
            }


            String reserveDate = "", id = "",contactPerson="", grfid="";

            Regex regex = new Regex("^[0-9]+$");//check its int or string?
            if (regex.IsMatch(itemId))
            {
                Int64 reserveID = Convert.ToInt64(itemId);

                if (reservdate != "")
                {
                    DateTime resrvDate = Convert.ToDateTime(reservdate);
                    var getData = (from m in db.HmlReserveDbSet where m.COMPID == companyID && m.RESVID == reserveID && m.RESVDT == resrvDate select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.RESVID.ToString();
                        
                        DateTime x = Convert.ToDateTime(get.RESVDT);
                        reserveDate = x.ToString("dd-MMM-yyyy");
                        
                        contactPerson = get.CPNM;
                        grfid = get.GRFID.ToString();
                    }
                }
                else
                {
                    var getData = (from m in db.HmlReserveDbSet where m.COMPID == companyID && m.RESVID == reserveID select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.RESVID.ToString();
                        
                        DateTime x = Convert.ToDateTime(get.RESVDT);
                        reserveDate = x.ToString("dd-MMM-yyyy");

                        contactPerson = get.CPNM;
                        grfid = get.GRFID.ToString();
                    }

                }
            }
            
            var result = new
            {
                ID = itemId,
                DATE = reserveDate,
                CONTACTP = contactPerson,
                GRFID = grfid,
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }






        public JsonResult TagSearch_TransNO(String character, String monthYear, String compid)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);

            if (monthYear != "")
            {
                var find =
                    (from m in db.HmlReservePayDbSet
                     where m.COMPID == companyID && m.TRANSMY == monthYear
                     select new { m.TRANSNO }).ToList();
                foreach (var a in find)
                {
                    result.Add(a.TRANSNO.ToString());
                }
            }
            else
            {
                var find =
                    (from m in db.HmlReservePayDbSet
                     where m.COMPID == companyID
                     select new { m.TRANSNO }).ToList();
                foreach (var a in find)
                {
                    result.Add(a.TRANSNO.ToString());
                }
            }


            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetData(String changedText, String transMonthYear, String companyID)
        {
            var compid = Convert.ToInt16(companyID);
            String itemId = "";
            List<string> list = new List<string>();
            if (transMonthYear != "")
            {
                var findReferName = (from m in db.HmlReservePayDbSet
                                     where m.COMPID == compid && m.TRANSMY == transMonthYear
                     select new { m.TRANSNO }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.TRANSNO.ToString());
                }
            }
            else
            {
                var findReferName = (from m in db.HmlReservePayDbSet
                                     where m.COMPID == compid
                                     select new { m.TRANSNO }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.TRANSNO.ToString());
                }
            }


            var rt = list.Where(t => t.StartsWith(changedText)).ToList();

            int lenChangedtxt = changedText.Length;

            Int64 cont = rt.Count();
            Int64 k = 0;
            string status = "";
            if (changedText != "" && cont != 0)
            {
                while (status != "no")
                {
                    k = 0;
                    foreach (var n in rt)
                    {
                        string ss = Convert.ToString(n);
                        string subss = "";
                        if (ss.Length >= lenChangedtxt)
                        {
                            subss = ss.Substring(0, lenChangedtxt);
                            subss = subss.ToUpper();
                        }
                        else
                        {
                            subss = "";
                        }


                        if (subss == changedText.ToUpper())
                        {
                            k++;
                        }
                        if (k == cont)
                        {
                            status = "yes";
                            lenChangedtxt++;
                            if (ss.Length > lenChangedtxt - 1)
                            {
                                changedText = changedText + ss[lenChangedtxt - 1];
                            }

                        }
                        else
                        {
                            status = "no";
                            //lenChangedtxt--;
                        }

                    }

                }
                if (lenChangedtxt == 1)
                {
                    itemId = changedText.Substring(0, lenChangedtxt);
                }

                else
                {
                    itemId = changedText.Substring(0, lenChangedtxt - 1);
                }
            }
            else
            {
                itemId = changedText;
            }


            String reserveDate = "", TransactionDate = "", amount = "", remarks = "", monthYear = "", trMode = "", ccytp = "", contactPerson="";
            Int64 insertUserId = 0, id = 0, reserveID=0;
            String inserttime = "", insertIpno = "", insltude = "";

            Regex regex = new Regex("^[0-9]+$");//check its int or string?
            if (regex.IsMatch(itemId))
            {
                Int64 transNo = Convert.ToInt64(itemId);

                if (transMonthYear != "")
                {
                    var getData = (from m in db.HmlReservePayDbSet where m.COMPID == compid && m.TRANSMY == transMonthYear && m.TRANSNO == transNo select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.ID;
                        monthYear = transMonthYear;

                        DateTime x = Convert.ToDateTime(get.TRANSDT);
                        TransactionDate = x.ToString("dd-MMM-yyyy");
                        reserveID = get.RESVID;
                        ccytp = get.CCYTP;
                        trMode = get.TRMODE;
                        amount = get.AMOUNT.ToString();
                        remarks = get.REMARKS;

                        insertUserId = get.INSUSERID;
                        inserttime = Convert.ToString(get.INSTIME);
                        insertIpno = Convert.ToString(get.INSIPNO);
                        insltude = Convert.ToString(get.INSLTUDE);
                    }
                }
                else
                {
                    var getData = (from m in db.HmlReservePayDbSet where m.COMPID == compid && m.TRANSNO == transNo select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.ID;
                        monthYear = get.TRANSMY;

                        DateTime x = Convert.ToDateTime(get.TRANSDT);
                        TransactionDate = x.ToString("dd-MMM-yyyy");
                        reserveID = get.RESVID;
                        ccytp = get.CCYTP;
                        trMode = get.TRMODE;
                        amount = get.AMOUNT.ToString();
                        remarks = get.REMARKS;

                        insertUserId = get.INSUSERID;
                        inserttime = Convert.ToString(get.INSTIME);
                        insertIpno = Convert.ToString(get.INSIPNO);
                        insltude = Convert.ToString(get.INSLTUDE);
                    }

                }


                var getReserveDate = (from m in db.HmlReserveDbSet where m.COMPID == compid && m.RESVID == reserveID select new{m.RESVDT,m.CPNM}).ToList();
                foreach (var get in getReserveDate)
                {
                    DateTime x = Convert.ToDateTime(get.RESVDT);
                    reserveDate = x.ToString("dd-MMM-yyyy");
                    contactPerson = get.CPNM;
                }
            }

            var result = new
            {
                ID = id,
                TRANSMY = monthYear,
                TRANSDT = TransactionDate,
                TRANSNO = itemId,
                RESVID = reserveID,
                RESVDT = reserveDate,
                CONTACTP = contactPerson,
                TRMODE = trMode,
                CCYTP = ccytp,
                AMOUNT = amount,
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
