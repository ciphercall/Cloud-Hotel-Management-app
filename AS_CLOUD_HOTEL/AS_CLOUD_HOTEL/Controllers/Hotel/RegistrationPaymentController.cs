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
    public class RegistrationPaymentController : AppController
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


        public RegistrationPaymentController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_RegistrationPayment_LogData(HML_REGNPAY model)
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
            aslLog.TABLEID = "HML_REGNPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Registration Payment Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nREGISTRATION-ID: " + model.REGNID + ",\nTransaction For: " + model.TRFOR + ",\nPayment Mode: " + model.TRMODE + ",\nCurrency Type: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_RegistrationPayment_LogData(HML_REGNPAY model)
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
            aslLog.TABLEID = "HML_REGNPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Registration Payment Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nREGISTRATION-ID: " + model.REGNID + ",\nTransaction For: " + model.TRFOR + ",\nPayment Mode: " + model.TRMODE + ",\nCurrency Type: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_RegistrationPayment_LogData(HML_REGNPAY model)
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
            aslLog.TABLEID = "HML_REGNPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Registration Payment Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nREGISTRATION-ID: " + model.REGNID + ",\nTransaction For: " + model.TRFOR + ",\nPayment Mode: " + model.TRMODE + ",\nCurrency Type: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_RegistrationPayment_DELETE(HML_REGNPAY model)
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
            AslDelete.TABLEID = "HML_REGNPAY";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            AslDelete.DELDATA = Convert.ToString("Registration Payment Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nREGISTRATION-ID: " + model.REGNID + ",\nTransaction For: " + model.TRFOR + ",\nPayment Mode: " + model.TRMODE + ",\nCurrency Type: " + model.CCYTP + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
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
        public ActionResult Create(HML_REGNPAY model, string command)
        {
            if (ModelState.IsValid)
            {
                var searchRegistrationID = (from m in db.HmlRegistrationDbSet where m.COMPID == model.COMPID && m.REGNID == model.REGNID select new { m.REGNID }).ToList();

                if (searchRegistrationID.Count == 0)
                {
                    ViewBag.RegistrationID_ValidationMessage = "Please select valid Registration ID! ";
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
                        findMax_TRANSNO = Convert.ToInt64((from m in db.HmlRegistrationPaymentDbSet
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
                        Insert_RegistrationPayment_LogData(model);
                        db.HmlRegistrationPaymentDbSet.Add(model);
                        db.SaveChanges();

                        TempData["RegistrationPaymentCreateMessage"] = "Successfully entry ! ";

                        if (command == "Memo")
                        {
                            TempData["RegistrationPaymentViewModel"] = model;
                            return RedirectToAction("RegistrationPaymnet_ReportPage", "HotelReport");
                        }
                        else
                        {
                            return RedirectToAction("Create");
                        }
                    }
                    else
                    {
                        TempData["RegistrationPaymentCreateMessage"] = "Entry Not Possible ! ";
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
        public ActionResult Update(HML_REGNPAY model, String command)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                model.USERPC = strHostName;
                model.UPDIPNO = ipAddress.ToString();
                model.UPDTIME = Convert.ToDateTime(td);
                model.UPDUSERID = model.UPDUSERID;

                Update_RegistrationPayment_LogData(model);
                db.SaveChanges();
                TempData["RegistrationPaymentUpdateMessage"] = "Successfully updated!";
                if (command == "Memo")
                {
                    TempData["RegistrationPaymentViewModel"] = model;
                    return RedirectToAction("RegistrationPaymnet_ReportPage", "HotelReport");
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
        public ActionResult Delete(HML_REGNPAY model)
        {
            if (ModelState.IsValid)
            {
                var checkData = (from m in db.HmlRegistrationPaymentDbSet where m.ID == model.ID && m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY && m.TRANSNO == model.TRANSNO select m).ToList();
                if (checkData.Count == 1)
                {
                    HML_REGNPAY deleteModel = db.HmlRegistrationPaymentDbSet.Find(model.ID, model.COMPID, model.TRANSMY, model.TRANSNO);

                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.UPDLTUDE = model.UPDLTUDE;

                    Delete_RegistrationPayment_DELETE(model);
                    Delete_RegistrationPayment_LogData(model);
                    db.SaveChanges();
                    db.HmlRegistrationPaymentDbSet.Remove(deleteModel);
                    db.SaveChanges();
                    TempData["RegistrationPaymentDeleteMessage"] = "Successfully deleted!";
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


        public JsonResult TagSearch_registrationID(String character, String compid, String registrationdate)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);

            if (registrationdate != "")
            {
                DateTime date = Convert.ToDateTime(registrationdate);
                var findReferName = (from m in db.HmlRegistrationDbSet where m.COMPID == companyID && m.REGNDT == date select new { m.REGNID }).ToList();
                foreach (var a in findReferName)
                {
                    result.Add(a.REGNID.ToString());
                }
            }
            else
            {
                var findReferName =
                    (from m in db.HmlRegistrationDbSet
                     where m.COMPID == companyID
                     select new { m.REGNID }).ToList();
                foreach (var a in findReferName)
                {
                    result.Add(a.REGNID.ToString());
                }
            }


            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_registrationID(String changedText, String compid, String registrationDate)
        {
            var companyID = Convert.ToInt16(compid);
            String itemId = "";
            List<string> list = new List<string>();
            if (registrationDate != "")
            {
                DateTime Date = Convert.ToDateTime(registrationDate);
                var findReferName =
                    (from m in db.HmlRegistrationDbSet
                     where m.COMPID == companyID && m.REGNDT == Date
                     select new { m.REGNID }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.REGNID.ToString());
                }
            }
            else
            {
                var findReferName =
                    (from m in db.HmlRegistrationDbSet
                     where m.COMPID == companyID
                     select new { m.REGNID }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.REGNID.ToString());
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


            String regDate = "", id = "", roomNO = "";

            Regex regex = new Regex("^[0-9]+$");//check its int or string?
            if (regex.IsMatch(itemId))
            {
                Int64 registrationID = Convert.ToInt64(itemId);

                if (regDate != "")
                {
                    DateTime date = Convert.ToDateTime(regDate);
                    var getData = (from m in db.HmlRegistrationDbSet where m.COMPID == companyID && m.REGNID == registrationID && m.REGNDT == date select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.REGNID.ToString();

                        DateTime x = Convert.ToDateTime(get.REGNDT);
                        regDate = x.ToString("dd-MMM-yyyy");

                        roomNO = Convert.ToString(get.ROOMNO);
                    }
                }
                else
                {
                    var getData = (from m in db.HmlRegistrationDbSet where m.COMPID == companyID && m.REGNID == registrationID select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.REGNID.ToString();

                        DateTime x = Convert.ToDateTime(get.REGNDT);
                        regDate = x.ToString("dd-MMM-yyyy");

                        roomNO = Convert.ToString(get.ROOMNO);
                    }
                }
            }

            var result = new
            {
                REGNID = itemId,
                REGNDT = regDate,
                ROOMNO = roomNO,
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
                    (from m in db.HmlRegistrationPaymentDbSet
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
                    (from m in db.HmlRegistrationPaymentDbSet
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
                var findReferName = (from m in db.HmlRegistrationPaymentDbSet
                                     where m.COMPID == compid && m.TRANSMY == transMonthYear
                     select new { m.TRANSNO }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.TRANSNO.ToString());
                }
            }
            else
            {
                var findReferName = (from m in db.HmlRegistrationPaymentDbSet
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


            String reserveDate = "", TransactionDate = "", amount = "", remarks = "", monthYear = "", trMode = "", ccytp = "", trfor="";
            Int64 insertUserId = 0, id = 0, registrationID=0;
            String inserttime = "", insertIpno = "", insltude = "";
            String regDate = "", roomNO = "";

            Regex regex = new Regex("^[0-9]+$");//check its int or string?
            if (regex.IsMatch(itemId))
            {
                Int64 transNo = Convert.ToInt64(itemId);

                if (transMonthYear != "")
                {
                    var getData = (from m in db.HmlRegistrationPaymentDbSet where m.COMPID == compid && m.TRANSMY == transMonthYear && m.TRANSNO == transNo select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.ID;
                        monthYear = transMonthYear;

                        DateTime x = Convert.ToDateTime(get.TRANSDT);
                        TransactionDate = x.ToString("dd-MMM-yyyy");
                        registrationID = get.REGNID;
                        trfor = get.TRFOR;
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
                    var getData = (from m in db.HmlRegistrationPaymentDbSet where m.COMPID == compid && m.TRANSNO == transNo select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.ID;
                        monthYear = get.TRANSMY;

                        DateTime x = Convert.ToDateTime(get.TRANSDT);
                        TransactionDate = x.ToString("dd-MMM-yyyy");
                        registrationID = get.REGNID;
                        trfor = get.TRFOR;
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

               
                var getRegistrationDate = (from m in db.HmlRegistrationDbSet where m.COMPID == compid && m.REGNID == registrationID select m).ToList();
                foreach (var get in getRegistrationDate)
                {
                    DateTime x = Convert.ToDateTime(get.REGNDT);
                    regDate = x.ToString("dd-MMM-yyyy");
                    roomNO = Convert.ToString(get.ROOMNO);
                }
            }

            var result = new
            {
                ID = id,
                TRANSMY = monthYear,
                TRANSDT = TransactionDate,
                TRANSNO = itemId,
                REGNID = registrationID,
                REGNDT = regDate,
                ROOMNO = roomNO,
                TRFOR = trfor,
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
