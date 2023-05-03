using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class ServiceController : AppController
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


        public ServiceController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_Service_LogData(HML_SERVICES model)
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
            aslLog.TABLEID = "HML_SERVICES";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Service Create Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nGuest-Type: " + model.GUESTTP + ",\nRoom-No: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill-ID: " + model.BILLID + ",\nQuantity: " + model.QTY + ",\nRate: " + model.RATE + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_Service_LogData(HML_SERVICES model)
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
            aslLog.TABLEID = "HML_SERVICES";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Service Update Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nGuest-Type: " + model.GUESTTP + ",\nRoom-No: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill-ID: " + model.BILLID + ",\nQuantity: " + model.QTY + ",\nRate: " + model.RATE + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_Service_LogData(HML_SERVICES model)
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
            aslLog.TABLEID = "HML_SERVICES";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Service Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nGuest-Type: " + model.GUESTTP + ",\nRoom-No: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill-ID: " + model.BILLID + ",\nQuantity: " + model.QTY + ",\nRate: " + model.RATE + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_Service_DELETE(HML_SERVICES model)
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
            AslDelete.TABLEID = "HML_SERVICES";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");

            AslDelete.DELDATA = Convert.ToString("Service Delete Page.Transaction Date: " + transDate + ",\nTransaction Month-Year: " + model.TRANSMY + ",\nTransaction NO: " + model.TRANSNO + ",\nGuest-Type: " + model.GUESTTP + ",\nRoom-No: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill-ID: " + model.BILLID + ",\nQuantity: " + model.QTY + ",\nRate: " + model.RATE + ",\nAmount: " + model.AMOUNT + ",\nREMARKS: " + model.REMARKS + ".");
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
        public ActionResult Create(HML_SERVICES model)
        {
            if (ModelState.IsValid)
            {

                String reserveYear = Convert.ToString(model.TRANSMY);
                String subString_Year = reserveYear.Substring(4, 2);

                DateTime transDate = Convert.ToDateTime(model.TRANSDT);
                String date = transDate.ToString("MM");

                Int64 findMax_TRANSNO = 0;
                try
                {
                    findMax_TRANSNO = Convert.ToInt64((from m in db.HmlServicesDbSet
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
                    Insert_Service_LogData(model);
                    db.HmlServicesDbSet.Add(model);
                    db.SaveChanges();

                    TempData["ServiceCreateMessage"] = "Successfully generated transaction No-" + model.TRANSNO + ".";
                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["ServiceCreateMessage"] = "Entry Not Possible ! ";
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
        public ActionResult Update(HML_SERVICES model)
        {
            if (ModelState.IsValid)
            {
                var find_BillDteails_Data = (from m in db.HmlBillDetailsDbSet
                    where m.COMPID == model.COMPID && m.ROOMNO == model.ROOMNO && m.REGNID == model.REGNID select m).ToList();
                if (find_BillDteails_Data.Count == 0)
                {
                    db.Entry(model).State = EntityState.Modified;
                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = model.UPDUSERID;

                    Update_Service_LogData(model);
                    db.SaveChanges();
                    TempData["ServiceUpdateMessage"] = "Successfully updated transaction No-" + model.TRANSNO + ".";
                }
                else
                {
                    TempData["ServiceUpdateMessage"] = "Update Not Possible!!! Bill already created against this transaction No-" + model.TRANSNO + ".";
                }

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
        public ActionResult Delete(HML_SERVICES model)
        {
            if (ModelState.IsValid)
            {
                var checkData = (from m in db.HmlServicesDbSet where m.ID == model.ID && m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY && m.TRANSNO == model.TRANSNO select m).ToList();
                if (checkData.Count == 1)
                {
                    HML_SERVICES deleteModel = db.HmlServicesDbSet.Find(model.ID, model.COMPID, model.TRANSMY, model.TRANSNO);

                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = model.UPDUSERID;
                    model.UPDLTUDE = model.UPDLTUDE;

                    Delete_Service_DELETE(model);
                    Delete_Service_LogData(model);
                    db.SaveChanges();
                    db.HmlServicesDbSet.Remove(deleteModel);
                    db.SaveChanges();
                    TempData["ServiceDeleteMessage"] = "Successfully deleted transaction No-" + model.TRANSNO + ".";
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





        public JsonResult Get_RATE(String changedText, String compid)
        {
            Int64 companyid = Convert.ToInt64(compid);
            Int64 billId = Convert.ToInt64(changedText);
            var findRate =
                (from m in db.HmlBillHpDbSet where m.COMPID == companyid && m.BILLID == billId select new {m.BILLRT})
                    .ToList();
            String rate = "";
            foreach (var get in findRate)
            {
                rate = get.BILLRT.ToString();
            }

            var Billrate = new { BILLRT = rate };
            return Json(Billrate, JsonRequestBehavior.AllowGet);
        }



        public JsonResult TagSearch_roomID(String character, String compid, String transdate)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);
            Int64 roomNo = Convert.ToInt64(character);
            DateTime transactionDate = Convert.ToDateTime(transdate);
            var findReferName =
                (from m in db.HmlRegistrationDbSet
                 where m.COMPID == companyID && m.CHECKI <= transactionDate && transactionDate <= m.GHECKO
                 select new { m.ROOMNO }).ToList();
            foreach (var a in findReferName)
            {
                result.Add(a.ROOMNO.ToString());
            }


            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_roomID(String changedText, String compid, String transDate)
        {
            var companyID = Convert.ToInt16(compid);
            Int64 roomNo = Convert.ToInt64(changedText);
            String itemId = "";
            List<string> list = new List<string>();

            DateTime transactionDate = Convert.ToDateTime(transDate);
            var findReferName =
                (from m in db.HmlRegistrationDbSet
                 where m.COMPID == companyID && m.CHECKI <= transactionDate && transactionDate <= m.GHECKO
                 select new { m.ROOMNO }).ToList();
            foreach (var a in findReferName)
            {
                list.Add(a.ROOMNO.ToString());
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


            String reserveDate = "", contactPerson = "", guestName = "";
            Int64 regnid = 0;
            Regex regex = new Regex("^[0-9]+$");//check its int or string?
            if (regex.IsMatch(itemId))
            {
                Int64 roomNumber = Convert.ToInt64(itemId);

                var getData = (from m in db.HmlRegistrationDbSet
                               where m.COMPID == companyID && m.CHECKI <= transactionDate && transactionDate <= m.GHECKO && m.ROOMNO == roomNumber
                               select new { m.REGNID }).ToList();
                foreach (var get in getData)
                {
                    regnid = get.REGNID;
                }

                var findGuestName = (from HML_REGN in db.HmlRegistrationDbSet
                                     join HML_GUESTS in db.HmlRegistrationGuestsDbSet on HML_REGN.COMPID equals HML_GUESTS.COMPID
                                     where HML_REGN.COMPID == companyID && HML_REGN.REGNID == regnid && HML_GUESTS.REGNID == HML_REGN.REGNID
                                     select new { HML_GUESTS.GUESTNM }).ToList();
                foreach (var x in findGuestName)
                {
                    guestName = x.GUESTNM;
                    break;
                }

            }

            var result = new
            {
                ROOMNO = itemId,
                REGNID = regnid,
                GUESTNAME=guestName
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
                    (from m in db.HmlServicesDbSet
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
                    (from m in db.HmlServicesDbSet
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
                var findReferName = (from m in db.HmlServicesDbSet
                                     where m.COMPID == compid && m.TRANSMY == transMonthYear
                                     select new { m.TRANSNO }).ToList();
                foreach (var a in findReferName)
                {
                    list.Add(a.TRANSNO.ToString());
                }
            }
            else
            {
                var findReferName = (from m in db.HmlServicesDbSet
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


            String billID = "", TransactionDate = "", amount = "", remarks = "", monthYear = "", guesttp = "", roomNo = "",  qty = "", rate = "", guestName="";
            Int64 insertUserId = 0, id = 0, reserveID = 0, regNid=0;
            String inserttime = "", insertIpno = "", insltude = "";

            Regex regex = new Regex("^[0-9]+$");//check its int or string?
            if (regex.IsMatch(itemId))
            {
                Int64 transNo = Convert.ToInt64(itemId);

                if (transMonthYear != "")
                {
                    var getData = (from m in db.HmlServicesDbSet where m.COMPID == compid && m.TRANSMY == transMonthYear && m.TRANSNO == transNo select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.ID;
                        monthYear = transMonthYear;

                        DateTime x = Convert.ToDateTime(get.TRANSDT);
                        TransactionDate = x.ToString("dd-MMM-yyyy");
                        guesttp = get.GUESTTP;
                        roomNo = get.ROOMNO.ToString();
                        regNid = get.REGNID;
                        billID = get.BILLID.ToString();
                        qty = get.QTY.ToString();
                        rate = get.RATE.ToString();
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
                    var getData = (from m in db.HmlServicesDbSet where m.COMPID == compid && m.TRANSNO == transNo select m).ToList();
                    foreach (var get in getData)
                    {
                        id = get.ID;
                        monthYear = get.TRANSMY;

                        DateTime x = Convert.ToDateTime(get.TRANSDT);
                        TransactionDate = x.ToString("dd-MMM-yyyy");
                        guesttp = get.GUESTTP;
                        roomNo = get.ROOMNO.ToString();
                        regNid = get.REGNID;
                        billID = get.BILLID.ToString();
                        qty = get.QTY.ToString();
                        rate = get.RATE.ToString();
                        amount = get.AMOUNT.ToString();
                        remarks = get.REMARKS;

                        insertUserId = get.INSUSERID;
                        inserttime = Convert.ToString(get.INSTIME);
                        insertIpno = Convert.ToString(get.INSIPNO);
                        insltude = Convert.ToString(get.INSLTUDE);
                    }

                }

                var findGuestName = (from HML_REGN in db.HmlRegistrationDbSet
                                     join HML_GUESTS in db.HmlRegistrationGuestsDbSet on HML_REGN.COMPID equals HML_GUESTS.COMPID
                                     where HML_REGN.COMPID == compid && HML_REGN.REGNID == regNid && HML_GUESTS.REGNID == HML_REGN.REGNID
                                     select new { HML_GUESTS.GUESTNM }).ToList();
                foreach (var x in findGuestName)
                {
                    guestName = x.GUESTNM;
                    break;
                }

            }

            var result = new
            {
                ID = id,
                TRANSMY = monthYear,
                TRANSDT = TransactionDate,
                TRANSNO = itemId,
                GUESTTP = guesttp,
                ROOMNO = roomNo,
                REGNID = regNid,
                GUESTNAME = guestName,
                BILLID = billID,
                QTY = qty,
                RATE = rate,
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
