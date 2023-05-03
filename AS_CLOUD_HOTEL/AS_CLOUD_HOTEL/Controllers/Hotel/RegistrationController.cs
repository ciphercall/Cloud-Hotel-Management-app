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
    public class RegistrationController : AppController
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


        public RegistrationController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }


        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_Registration_LogData(HML_REGN model)
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
            aslLog.TABLEID = "HML_REGN";

            DateTime x = Convert.ToDateTime(model.REGNDT);
            String registrationDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Registration Basic Create Page.Registration Date: " + registrationDate + ",\nRegistration Year" + model.REGNYY + ",\nRegistration-ID: " + model.REGNID + ",\nCheck In: " + checki + ",\nCheck Out: " + ghecko + ",\nReservation: " + model.RESVYN + ",\nReservation ID: " + model.RESVID + ",\nGuest Company: " + model.GCOID + ",\nCurrency Type: " + model.CCYTP + ",\nExchange Rate: " + model.CCYCRT + ",\nRoom Type: " + model.RTPID + ",\nRoom No: " + model.ROOMNO + ",\nRate (Offer): " + model.ROOMRTO + ",\nDiscount Type: " + model.DISCTP + ",\nDiscount Amount: " + model.DISCRT + ",\nRate (Negotiated): " + model.ROOMRTS + ",\nVisit Purpose: " + model.VISITPP + ",\nPreviously visited : " + model.VISITPRE + ",\nComing From: " + model.DESTFR + ",\nNext Destination: " + model.DESTTO + ",\nRF (Guest): " + model.GRFID + ",\nRoom No (Link):  " + model.ROOMNOL + ",\nRegistration ID (Link): " + model.REGNIDL + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_Registration_LogData(HML_REGN model)
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
            aslLog.TABLEID = "HML_REGN";

            DateTime x = Convert.ToDateTime(model.REGNDT);
            String registrationDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Registration Basic Update Page.Registration Date: " + registrationDate + ",\nRegistration Year" + model.REGNYY + ",\nRegistration-ID: " + model.REGNID + ",\nCheck In: " + checki + ",\nCheck Out: " + ghecko + ",\nReservation: " + model.RESVYN + ",\nReservation ID: " + model.RESVID + ",\nGuest Company: " + model.GCOID + ",\nCurrency Type: " + model.CCYTP + ",\nExchange Rate: " + model.CCYCRT + ",\nRoom Type: " + model.RTPID + ",\nRoom No: " + model.ROOMNO + ",\nRate (Offer): " + model.ROOMRTO + ",\nDiscount Type: " + model.DISCTP + ",\nDiscount Amount: " + model.DISCRT + ",\nRate (Negotiated): " + model.ROOMRTS + ",\nVisit Purpose: " + model.VISITPP + ",\nPreviously visited : " + model.VISITPRE + ",\nComing From: " + model.DESTFR + ",\nNext Destination: " + model.DESTTO + ",\nRF (Guest): " + model.GRFID + ",\nRoom No (Link):  " + model.ROOMNOL + ",\nRegistration ID (Link): " + model.REGNIDL + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_Registration_LogData(HML_REGN model)
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
            aslLog.TABLEID = "HML_REGN";

            DateTime x = Convert.ToDateTime(model.REGNDT);
            String registrationDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            aslLog.LOGDATA = Convert.ToString("Registration Basic Delete Page.Registration Date: " + registrationDate + ",\nRegistration Year" + model.REGNYY + ",\nRegistration-ID: " + model.REGNID + ",\nCheck In: " + checki + ",\nCheck Out: " + ghecko + ",\nReservation: " + model.RESVYN + ",\nReservation ID: " + model.RESVID + ",\nGuest Company: " + model.GCOID + ",\nCurrency Type: " + model.CCYTP + ",\nExchange Rate: " + model.CCYCRT + ",\nRoom Type: " + model.RTPID + ",\nRoom No: " + model.ROOMNO + ",\nRate (Offer): " + model.ROOMRTO + ",\nDiscount Type: " + model.DISCTP + ",\nDiscount Amount: " + model.DISCRT + ",\nRate (Negotiated): " + model.ROOMRTS + ",\nVisit Purpose: " + model.VISITPP + ",\nPreviously visited : " + model.VISITPRE + ",\nComing From: " + model.DESTFR + ",\nNext Destination: " + model.DESTTO + ",\nRF (Guest): " + model.GRFID + ",\nRoom No (Link):  " + model.ROOMNOL + ",\nRegistration ID (Link): " + model.REGNIDL + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_Registration_DELETE(HML_REGN model)
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
            AslDelete.TABLEID = "HML_REGN";

            DateTime x = Convert.ToDateTime(model.REGNDT);
            String registrationDate = x.ToString("dd-MMM-yyyy");

            DateTime y = Convert.ToDateTime(model.CHECKI);
            String checki = y.ToString("dd-MMM-yyyy");

            DateTime z = Convert.ToDateTime(model.GHECKO);
            String ghecko = z.ToString("dd-MMM-yyyy");

            AslDelete.DELDATA = Convert.ToString("Registration Basic Delete Page.Registration Date: " + registrationDate + ",\nRegistration Year" + model.REGNYY + ",\nRegistration-ID: " + model.REGNID + ",\nCheck In: " + checki + ",\nCheck Out: " + ghecko + ",\nReservation: " + model.RESVYN + ",\nReservation ID: " + model.RESVID + ",\nGuest Company: " + model.GCOID + ",\nCurrency Type: " + model.CCYTP + ",\nExchange Rate: " + model.CCYCRT + ",\nRoom Type: " + model.RTPID + ",\nRoom No: " + model.ROOMNO + ",\nRate (Offer): " + model.ROOMRTO + ",\nDiscount Type: " + model.DISCTP + ",\nDiscount Amount: " + model.DISCRT + ",\nRate (Negotiated): " + model.ROOMRTS + ",\nVisit Purpose: " + model.VISITPP + ",\nPreviously visited : " + model.VISITPRE + ",\nComing From: " + model.DESTFR + ",\nNext Destination: " + model.DESTTO + ",\nRF (Guest): " + model.GRFID + ",\nRoom No (Link):  " + model.ROOMNOL + ",\nRegistration ID (Link): " + model.REGNIDL + ",\nREMARKS: " + model.REMARKS + ".");
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
        public ActionResult Create(HML_REGN model)
        {
            if (ModelState.IsValid)
            {
                var searchReservID = (from m in db.HmlReserveDbSet where m.COMPID == model.COMPID && m.RESVID == model.RESVID select new { m.RESVID }).ToList();
                var searchRoomNo = (from m in db.HmlRoomDbSet where m.COMPID == model.COMPID && m.RTPID == model.RTPID && m.ROOMNO == model.ROOMNO select new { m.ROOMNO }).ToList();
                if (searchReservID.Count == 0 && model.RESVYN == "YES")
                {
                    ViewBag.ReserveID_ValidationMessage = "Please select valid Reserve ID! ";
                    return View("Create");
                }
                else if (searchRoomNo.Count == 0)
                {
                    ViewBag.RoomNO_ValidationMessage = "Please select valid Room NO! ";
                    return View("Create");
                }
                else
                {
                    String reserveYear = Convert.ToString(model.REGNYY);
                    String subString_Year = reserveYear.Substring(2, 2);

                    Int64 findMax_REGNID = 0;
                    try
                    {
                        findMax_REGNID = Convert.ToInt64((from m in db.HmlRegistrationDbSet
                                                          where m.COMPID == model.COMPID && m.REGNYY == model.REGNYY
                                                          select m.REGNID).Max());
                        model.REGNID = findMax_REGNID + 1;
                    }
                    catch
                    {
                        findMax_REGNID = Convert.ToInt64(subString_Year + "2" + "00001");
                        model.REGNID = findMax_REGNID;
                    }


                    Int64 max = Convert.ToInt64(subString_Year + "2" + "99999");
                    if (model.REGNID <= max)
                    {
                        model.USERPC = strHostName;
                        model.INSIPNO = ipAddress.ToString();
                        model.INSTIME = Convert.ToDateTime(td);
                        Insert_Registration_LogData(model);
                        db.HmlRegistrationDbSet.Add(model);
                        db.SaveChanges();

                        var find_HML_RESVCI = (from m in db.HmlResrveCiDbSet where m.COMPID == model.COMPID && m.RESVID == model.RESVID select new { m.CITEMID }).ToList();
                        foreach (var getData in find_HML_RESVCI)
                        {
                            HML_REGNCI complementaryITtem = new HML_REGNCI()
                            {
                                COMPID = Convert.ToInt64(model.COMPID),
                                REGNID = model.REGNID,
                                CITEMID = getData.CITEMID,

                                INSUSERID = model.INSUSERID,
                                INSIPNO = ipAddress.ToString(),
                                INSTIME = Convert.ToDateTime(td),
                                USERPC = strHostName,
                            };
                            db.HmlRegistrationCiDbSet.Add(complementaryITtem);
                        }
                        db.SaveChanges();


                        TempData["RegistrationCreateMessage"] = "Successfully entry - Reg. ID: " + model.REGNID;
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["RegistrationCreateMessage"] = "Entry Not Possible ! ";
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
        public ActionResult Update(HML_REGN model)
        {
            if (ModelState.IsValid)
            {
                Int64 roomNo = 0;
                if (model.USERPC != null)
                {
                    roomNo = Convert.ToInt64(model.USERPC);
                }
                else
                {
                    roomNo = Convert.ToInt64(model.ROOMNO);
                }
                model.ROOMNO = roomNo;
                var searchRoomNo = (from m in db.HmlRoomDbSet where m.COMPID == model.COMPID && m.RTPID == model.RTPID && m.ROOMNO == model.ROOMNO select new { m.ROOMNO }).ToList();
                if (searchRoomNo.Count == 0)
                {
                    ViewBag.RoomNO_ValidationMessage = "Please select valid Room NO! ";
                    return View("Update");
                }
                else
                {
                    if (model.RESVYN == "NO")
                    {
                        model.RESVID = 0;
                    }
                    db.Entry(model).State = EntityState.Modified;
                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = model.UPDUSERID;

                    Update_Registration_LogData(model);
                    db.SaveChanges();
                    TempData["RegistrationUpdateMessage"] = "Successfully updated - Reg. ID: " + model.REGNID;
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
        public ActionResult Delete(HML_REGN model)
        {
            if (ModelState.IsValid)
            {
                var checkData = (from m in db.HmlRegistrationDbSet where m.ID == model.ID && m.COMPID == model.COMPID && m.REGNYY == model.REGNYY && m.REGNID == model.REGNID select m).ToList();
                if (checkData.Count == 1)
                {
                    HML_REGN deleteModel = db.HmlRegistrationDbSet.Find(model.ID, model.COMPID, model.REGNYY, model.REGNID);

                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = model.UPDUSERID;
                    model.UPDLTUDE = model.UPDLTUDE;

                    Delete_Registration_DELETE(model);
                    Delete_Registration_LogData(model);
                    db.HmlRegistrationDbSet.Remove(deleteModel);
                    db.SaveChanges();

                    var find_HML_REGNCI = (from m in db.HmlRegistrationCiDbSet where m.COMPID == model.COMPID && m.REGNID == model.REGNID select m).ToList();
                    foreach (var getData in find_HML_REGNCI)
                    {
                        db.HmlRegistrationCiDbSet.Remove(getData);
                    }
                    db.SaveChanges();

                    TempData["RegistrationDeleteMessage"] = "Successfully deleted-Reg. ID: " + model.REGNID;
                    return RedirectToAction("Delete");
                }
            }
            return View();
        }





        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult TagSearch_roomNo(String roomT, String compid,String regDT)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            Int64 companyID = Convert.ToInt64(compid);
            Int64 roomType = Convert.ToInt64(roomT);

            DateTime regDate = Convert.ToDateTime(regDT);
            var findroomNo =
                (from m in db.HmlRoomDbSet
                 where m.COMPID == companyID && m.RTPID == roomType
                 select new { m.ROOMNO }).ToList();
            if (findroomNo.Count != 0)
            {

                foreach (var f in findroomNo)
                {
                    var checkRegistrationDate = (from m in db.HmlRegistrationDbSet
                                                 where m.COMPID == companyID && regDate >= m.CHECKI && regDate <= m.GHECKO && m.ROOMNO == f.ROOMNO
                                                 select m).ToList();
                    if (checkRegistrationDate.Count == 0)
                    {
                        {
                            result.Add(new SelectListItem { Text = f.ROOMNO.ToString(), Value = f.ROOMNO.ToString() });
                        }
                    }

                }
            }
            else
            {
                result.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(result, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }



        //[AcceptVerbs(HttpVerbs.Get)]
        //public JsonResult keyword_roomNo(String changedText, String compid, String roomType)
        //{
        //    var companyID = Convert.ToInt16(compid);
        //    String itemId = "";
        //    List<string> list = new List<string>();
        //    Int64 roomtypeID = Convert.ToInt16(roomType);
        //    var findroomNo =
        //        (from m in db.HmlRoomDbSet
        //         where m.COMPID == companyID && m.RTPID == roomtypeID
        //         select new { m.ROOMNO }).ToList();
        //    foreach (var a in findroomNo)
        //    {
        //        list.Add(a.ROOMNO.ToString());
        //    }


        //    var rt = list.Where(t => t.StartsWith(changedText)).ToList();

        //    int lenChangedtxt = changedText.Length;

        //    Int64 cont = rt.Count();
        //    Int64 k = 0;
        //    string status = "";
        //    if (changedText != "" && cont != 0)
        //    {
        //        while (status != "no")
        //        {
        //            k = 0;
        //            foreach (var n in rt)
        //            {
        //                string ss = Convert.ToString(n);
        //                string subss = "";
        //                if (ss.Length >= lenChangedtxt)
        //                {
        //                    subss = ss.Substring(0, lenChangedtxt);
        //                    subss = subss.ToUpper();
        //                }
        //                else
        //                {
        //                    subss = "";
        //                }


        //                if (subss == changedText.ToUpper())
        //                {
        //                    k++;
        //                }
        //                if (k == cont)
        //                {
        //                    status = "yes";
        //                    lenChangedtxt++;
        //                    if (ss.Length > lenChangedtxt - 1)
        //                    {
        //                        changedText = changedText + ss[lenChangedtxt - 1];
        //                    }

        //                }
        //                else
        //                {
        //                    status = "no";
        //                    //lenChangedtxt--;
        //                }

        //            }

        //        }
        //        if (lenChangedtxt == 1)
        //        {
        //            itemId = changedText.Substring(0, lenChangedtxt);
        //        }

        //        else
        //        {
        //            itemId = changedText.Substring(0, lenChangedtxt - 1);
        //        }
        //    }
        //    else
        //    {
        //        itemId = changedText;
        //    }


        //    String roomNO = "";

        //    Regex regex = new Regex("^[0-9]+$");//check its int or string?
        //    if (regex.IsMatch(itemId))
        //    {
        //        Int64 roomNo = Convert.ToInt64(itemId);
        //        var getData = (from m in db.HmlRoomDbSet where m.COMPID == companyID && m.RTPID == roomtypeID && m.ROOMNO == roomNo select m).ToList();
        //        foreach (var get in getData)
        //        {
        //            roomNO = get.ROOMNO.ToString();
        //        }
        //    }

        //    var result = new
        //    {
        //        ROOMNO = itemId,
        //    };
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult RoomTypeChanged(String companyid, String reserveID, String roomType,String CurrencyType)
        {
            Int64 comid = Convert.ToInt64(companyid);
            Int64 RoomType = Convert.ToInt64(roomType);
            Int64 ReserveID = 0;
            if (reserveID != "" && reserveID!= "select")
            {
                ReserveID = Convert.ToInt64(reserveID);
            }

            var getRoomDetails = (from m in db.HmlReserveRoomDbSet where m.COMPID == comid && m.RESVID == ReserveID && m.RTPID == RoomType select new { m.ROOMRTO, m.DISCTP, m.DISCRT, m.ROOMRTS }).ToList();
            String rateoffer = "", discountType = "", discountAmount = "", Rate_Ng = "";
            if (getRoomDetails.Count != 0)
            {
                foreach (var get in getRoomDetails)
                {
                    rateoffer = get.ROOMRTO.ToString();
                    discountType = get.DISCTP.ToString();
                    discountAmount = get.DISCRT.ToString();
                    Rate_Ng = get.ROOMRTS.ToString();
                }
            }
            else
            {
                var getRateOffer = (from m in db.HmlRoomTpDbSet where m.COMPID == comid && m.RTPID == RoomType select new {m.RATEUSD, m.RATEBDT}).ToList();
                foreach (var get in getRateOffer)
                {
                    if (CurrencyType == "BDT")
                    {
                        rateoffer = get.RATEBDT.ToString();
                    }
                    else if (CurrencyType == "USD")
                    {
                        rateoffer = get.RATEUSD.ToString();
                    }
                }
            }


            var result = new
            {
                ROOMRTO = rateoffer,
                DISCTP = discountType,
                DISCRT = discountAmount,
                ROOMRTS = Rate_Ng
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public JsonResult RegistrationIDload(string theDate, string compid)
        {
            Int64 comid = Convert.ToInt64(compid);
            DateTime dt = Convert.ToDateTime(theDate);

            String year = dt.ToString("yyyy");
            Int64 reserveYear = Convert.ToInt64(year);

            List<SelectListItem> registrationList = new List<SelectListItem>();
            var list = (from n in db.HmlRegistrationDbSet
                        where n.REGNDT == dt && n.COMPID == comid && n.REGNYY == reserveYear
                        select new
                        {
                            n.REGNID
                        }
                            )
                            .Distinct()
                            .ToList();

            if (list.Count != 0)
            {
                foreach (var f in list)
                {
                    registrationList.Add(new SelectListItem { Text = f.REGNID.ToString(), Value = f.REGNID.ToString() });
                }
            }
            else
            {
                registrationList.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(registrationList, "Value", "Text"));
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetRegistrationData(string companyid, string datetxt, string txt_REGNID)
        {
            var companyID = Convert.ToInt16(companyid);
            DateTime dt = Convert.ToDateTime(datetxt);
            Int64 registrationID = Convert.ToInt64(txt_REGNID);

            Int64 insertUserId = 0, id = 0, year = 0, resvid = 0, GrFid = 0;
            String inserttime = "", insertIpno = "", insltude = "";
            String checcki = "", ghecKo = "", resvyn = "", gcoID = "", ccytp = "", ccycrt = "", rtpid = "", roomNo = "", roomRto = "", disctp = "", discrt = "", roomrts = "", visitpp = "", visitpre = "", destFr = "", desTTo = "", grfID = "", roomNol = "", regnIdl = "", remarks = "";
            var getData = (from m in db.HmlRegistrationDbSet where m.COMPID == companyID && m.REGNDT == dt && m.REGNID == registrationID select m).ToList();

            foreach (var get in getData)
            {
                id = get.ID;
                year = Convert.ToInt64(get.REGNYY);

                if (get.CHECKI != null)
                {
                    DateTime a = Convert.ToDateTime(get.CHECKI);
                    checcki = a.ToString("dd-MMM-yyyy");
                }

                if (get.GHECKO != null)
                {
                    DateTime b = Convert.ToDateTime(get.GHECKO);
                    ghecKo = b.ToString("dd-MMM-yyyy");
                }

                resvyn = get.RESVYN;
                resvid = Convert.ToInt64(get.RESVID);
                gcoID = Convert.ToString(get.GCOID);
                ccytp = get.CCYTP;
                ccycrt = Convert.ToString(get.CCYCRT);
                rtpid = Convert.ToString(get.RTPID);
                roomNo = Convert.ToString(get.ROOMNO);
                roomRto = Convert.ToString(get.ROOMRTO);
                disctp = get.DISCTP;
                discrt = Convert.ToString(get.DISCRT);
                roomrts = Convert.ToString(get.ROOMRTS);
                visitpp = get.VISITPP;
                visitpre = get.VISITPRE;
                destFr = get.DESTFR;
                desTTo = get.DESTTO;
                grfID = Convert.ToString(get.GRFID);
                roomNol = Convert.ToString(get.ROOMNOL);
                regnIdl = Convert.ToString(get.REGNIDL);
                remarks = get.REMARKS;

                insertUserId = get.INSUSERID;
                inserttime = Convert.ToString(get.INSTIME);
                insertIpno = Convert.ToString(get.INSIPNO);
                insltude = Convert.ToString(get.INSLTUDE);
            }


            var getReserveInformation = (from m in db.HmlReserveDbSet where m.COMPID == companyID && m.RESVID == resvid select m).ToList();
            String reserveDate = "", contactPerson = "";
            foreach (var get in getReserveInformation)
            {
                DateTime x = Convert.ToDateTime(get.RESVDT);
                reserveDate = x.ToString("dd-MMM-yyyy");
                contactPerson = get.CPNM;
            }


            var result = new
            {
                ID = id,
                REGNYY = year,
                CHECKI = checcki,
                GHECKO = ghecKo,
                RESVYN = resvyn,
                RESVID = resvid,

                RESVDATE = reserveDate,
                CPNM = contactPerson,

                GCOID = gcoID,
                CCYTP = ccytp,
                CCYCRT = ccycrt,
                RTPID = rtpid,
                ROOMNO = roomNo,
                ROOMRTO = roomRto,
                DISCTP = disctp,
                DISCRT = discrt,
                ROOMRTS = roomrts,
                VISITPP = visitpp,
                VISITPRE = visitpre,
                DESTFR = destFr,
                DESTTO = desTTo,
                GRFID = grfID,
                ROOMNOL = roomNol,
                REGNIDL = regnIdl,
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
