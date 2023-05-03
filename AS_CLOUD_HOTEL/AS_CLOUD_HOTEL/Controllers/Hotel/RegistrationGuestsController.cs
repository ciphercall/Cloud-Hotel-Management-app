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
    public class RegistrationGuestsController : AppController
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


        public RegistrationGuestsController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }


        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_RegistrationGuests_LogData(HML_GUESTS model)
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
            aslLog.TABLEID = "HML_GUESTS";

            String DateofBirth = "";
            if (model.DOB != null)
            {
                DateTime dob = Convert.ToDateTime(model.DOB);
                DateofBirth = dob.ToString("dd-MMM-yyyy");
            }

            String visaidt = "";
            if (model.VISAIDT != null)
            {
                DateTime x = Convert.ToDateTime(model.VISAIDT);
                visaidt = x.ToString("dd-MMM-yyyy");
            }

            String visaedt = "";
            if (model.VISAEDT != null)
            {
                DateTime y = Convert.ToDateTime(model.VISAEDT);
                visaedt = y.ToString("dd-MMM-yyyy");
            }

            String ppidt = "";
            if (model.PPIDT != null)
            {
                DateTime z = Convert.ToDateTime(model.PPIDT);
                ppidt = z.ToString("dd-MMM-yyyy");
            }

            String ppedt = "";
            if (model.PPEDT != null)
            {
                DateTime a = Convert.ToDateTime(model.PPEDT);
                ppedt = a.ToString("dd-MMM-yyyy");
            }


            aslLog.LOGDATA = Convert.ToString("Reservation Guests Delete Page. Registration-ID: " + model.REGNID + ",\nGuest Name: " + model.GUESTNM + ",\nDate of Birth: " + DateofBirth + ",\nGender: " + model.GENDER + ",\nAddress: " + model.ADDRESS + ",\nCity: " + model.CITY + ",\nZipCode: " + model.ZIPCODE + ",\nCountry: " + model.COUNTRY + ",\nNationality: " + model.NATIONALITY + ",\nEmailID: " + model.EMAILID + ",\nTelePhone: " + model.TELNO + ",\nMobile No: " + model.MOBNO + ",\nNational ID: " + model.NIDNO + ",\nDriving license No: " + model.DRLICNO + ",\nVisa No: " + model.VISANO + ",\nVisa Issue Date: " + visaidt + ",\nVisa Expire Date: " + visaedt + ",\nPassport No: " + model.PPNO + ",\nPassport Issue Place: " + model.PPIPLACE + ",\nPassport Issue Date: " + ppidt + ",\nPassport Expire Date: " + ppedt + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_RegistrationGuests_LogData(HML_GUESTS model)
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
            aslLog.TABLEID = "HML_GUESTS";

            String DateofBirth = "";
            if (model.DOB != null)
            {
                DateTime dob = Convert.ToDateTime(model.DOB);
                DateofBirth = dob.ToString("dd-MMM-yyyy");
            }

            String visaidt = "";
            if (model.VISAIDT != null)
            {
                DateTime x = Convert.ToDateTime(model.VISAIDT);
                visaidt = x.ToString("dd-MMM-yyyy");
            }

            String visaedt = "";
            if (model.VISAEDT != null)
            {
                DateTime y = Convert.ToDateTime(model.VISAEDT);
                visaedt = y.ToString("dd-MMM-yyyy");
            }

            String ppidt = "";
            if (model.PPIDT != null)
            {
                DateTime z = Convert.ToDateTime(model.PPIDT);
                ppidt = z.ToString("dd-MMM-yyyy");
            }

            String ppedt = "";
            if (model.PPEDT != null)
            {
                DateTime a = Convert.ToDateTime(model.PPEDT);
                ppedt = a.ToString("dd-MMM-yyyy");
            }

            aslLog.LOGDATA = Convert.ToString("Reservation Guests Delete Page. Registration-ID: " + model.REGNID + ",\nGuest Name: " + model.GUESTNM + ",\nDate of Birth: " + DateofBirth + ",\nGender: " + model.GENDER + ",\nAddress: " + model.ADDRESS + ",\nCity: " + model.CITY + ",\nZipCode: " + model.ZIPCODE + ",\nCountry: " + model.COUNTRY + ",\nNationality: " + model.NATIONALITY + ",\nEmailID: " + model.EMAILID + ",\nTelePhone: " + model.TELNO + ",\nMobile No: " + model.MOBNO + ",\nNational ID: " + model.NIDNO + ",\nDriving license No: " + model.DRLICNO + ",\nVisa No: " + model.VISANO + ",\nVisa Issue Date: " + visaidt + ",\nVisa Expire Date: " + visaedt + ",\nPassport No: " + model.PPNO + ",\nPassport Issue Place: " + model.PPIPLACE + ",\nPassport Issue Date: " + ppidt + ",\nPassport Expire Date: " + ppedt + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_RegistrationGuests_LogData(HML_GUESTS model)
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
            aslLog.TABLEID = "HML_GUESTS";

            String DateofBirth = "";
            if (model.DOB != null)
            {
                DateTime dob = Convert.ToDateTime(model.DOB);
                DateofBirth = dob.ToString("dd-MMM-yyyy");
            }

            String visaidt = "";
            if (model.VISAIDT != null)
            {
                DateTime x = Convert.ToDateTime(model.VISAIDT);
                visaidt = x.ToString("dd-MMM-yyyy");
            }

            String visaedt = "";
            if (model.VISAEDT != null)
            {
                DateTime y = Convert.ToDateTime(model.VISAEDT);
                visaedt = y.ToString("dd-MMM-yyyy");
            }

            String ppidt = "";
            if (model.PPIDT != null)
            {
                DateTime z = Convert.ToDateTime(model.PPIDT);
                ppidt = z.ToString("dd-MMM-yyyy");
            }

            String ppedt = "";
            if (model.PPEDT != null)
            {
                DateTime a = Convert.ToDateTime(model.PPEDT);
                ppedt = a.ToString("dd-MMM-yyyy");
            }

            aslLog.LOGDATA = Convert.ToString("Reservation Guests Delete Page. Registration-ID: " + model.REGNID + ",\nGuest Name: " + model.GUESTNM + ",\nDate of Birth: " + DateofBirth + ",\nGender: " + model.GENDER + ",\nAddress: " + model.ADDRESS + ",\nCity: " + model.CITY + ",\nZipCode: " + model.ZIPCODE + ",\nCountry: " + model.COUNTRY + ",\nNationality: " + model.NATIONALITY + ",\nEmailID: " + model.EMAILID + ",\nTelePhone: " + model.TELNO + ",\nMobile No: " + model.MOBNO + ",\nNational ID: " + model.NIDNO + ",\nDriving license No: " + model.DRLICNO + ",\nVisa No: " + model.VISANO + ",\nVisa Issue Date: " + visaidt + ",\nVisa Expire Date: " + visaedt + ",\nPassport No: " + model.PPNO + ",\nPassport Issue Place: " + model.PPIPLACE + ",\nPassport Issue Date: " + ppidt + ",\nPassport Expire Date: " + ppedt + ",\nREMARKS: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_RegistrationGuests_DELETE(HML_GUESTS model)
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
            AslDelete.TABLEID = "HML_GUESTS";

            String DateofBirth = "";
            if (model.DOB != null)
            {
                DateTime dob = Convert.ToDateTime(model.DOB);
                DateofBirth = dob.ToString("dd-MMM-yyyy");
            }

            String visaidt = "";
            if (model.VISAIDT != null)
            {
                DateTime x = Convert.ToDateTime(model.VISAIDT);
                visaidt = x.ToString("dd-MMM-yyyy");
            }

            String visaedt = "";
            if (model.VISAEDT != null)
            {
                DateTime y = Convert.ToDateTime(model.VISAEDT);
                visaedt = y.ToString("dd-MMM-yyyy");
            }

            String ppidt = "";
            if (model.PPIDT != null)
            {
                DateTime z = Convert.ToDateTime(model.PPIDT);
                ppidt = z.ToString("dd-MMM-yyyy");
            }

            String ppedt = "";
            if (model.PPEDT != null)
            {
                DateTime a = Convert.ToDateTime(model.PPEDT);
                ppedt = a.ToString("dd-MMM-yyyy");
            }

            AslDelete.DELDATA = Convert.ToString("Reservation Guests Delete Page. Registration-ID: " + model.REGNID + ",\nGuest Name: " + model.GUESTNM + ",\nDate of Birth: " + DateofBirth + ",\nGender: " + model.GENDER + ",\nAddress: " + model.ADDRESS + ",\nCity: " + model.CITY + ",\nZipCode: " + model.ZIPCODE + ",\nCountry: " + model.COUNTRY + ",\nNationality: " + model.NATIONALITY + ",\nEmailID: " + model.EMAILID + ",\nTelePhone: " + model.TELNO + ",\nMobile No: " + model.MOBNO + ",\nNational ID: " + model.NIDNO + ",\nDriving license No: " + model.DRLICNO + ",\nVisa No: " + model.VISANO + ",\nVisa Issue Date: " + visaidt + ",\nVisa Expire Date: " + visaedt + ",\nPassport No: " + model.PPNO + ",\nPassport Issue Place: " + model.PPIPLACE + ",\nPassport Issue Date: " + ppidt + ",\nPassport Expire Date: " + ppedt + ",\nREMARKS: " + model.REMARKS + ".");
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
        public ActionResult Create(HML_GUESTS model)
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
                    Int64 findMax_GUESTID = 0;
                    try
                    {
                        findMax_GUESTID = Convert.ToInt64((from m in db.HmlRegistrationGuestsDbSet
                                                           where m.COMPID == model.COMPID && m.REGNID == model.REGNID
                                                           select m.GUESTID).Max());
                        model.GUESTID = findMax_GUESTID + 1;
                    }
                    catch
                    {
                        findMax_GUESTID = Convert.ToInt64(model.REGNID + "01");
                        model.GUESTID = findMax_GUESTID;
                    }

                    Int64 max = Convert.ToInt64(model.REGNID + "99");
                    if (model.REGNID <= max)
                    {
                        model.USERPC = strHostName;
                        model.INSIPNO = ipAddress.ToString();
                        model.INSTIME = Convert.ToDateTime(td);
                        Insert_RegistrationGuests_LogData(model);
                        db.HmlRegistrationGuestsDbSet.Add(model);
                        db.SaveChanges();

                        TempData["GuestsCreateMessage"] = "Successfully entry ! ";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["GuestsCreateMessage"] = "Entry Not Possible ! ";
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
        public ActionResult Update(HML_GUESTS model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                model.USERPC = strHostName;
                model.UPDIPNO = ipAddress.ToString();
                model.UPDTIME = Convert.ToDateTime(td);
                model.UPDUSERID = model.UPDUSERID;

                Update_RegistrationGuests_LogData(model);
                db.SaveChanges();
                TempData["GuestsUpdateMessage"] = "Successfully updated!";
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
        public ActionResult Delete(HML_GUESTS model)
        {
            if (ModelState.IsValid)
            {
                var checkData = (from m in db.HmlRegistrationGuestsDbSet where m.ID == model.ID && m.COMPID == model.COMPID && m.GUESTID == model.GUESTID && m.REGNID == model.REGNID select m).ToList();
                if (checkData.Count == 1)
                {
                    model.USERPC = strHostName;
                    model.UPDIPNO = ipAddress.ToString();
                    model.UPDTIME = Convert.ToDateTime(td);
                    model.UPDUSERID = model.UPDUSERID;
                    model.UPDLTUDE = model.UPDLTUDE;

                    Delete_RegistrationGuests_DELETE(model);
                    Delete_RegistrationGuests_LogData(model);
                    db.SaveChanges();
                    foreach (var getData in checkData)
                    {
                        db.HmlRegistrationGuestsDbSet.Remove(getData);
                    }

                    db.SaveChanges();
                    TempData["GuestsDeleteMessage"] = "Successfully deleted!";
                    return RedirectToAction("Delete");
                }
            }
            return View();
        }








        public JsonResult GuestIDLoad(string companyid, string regid)
        {
            Int64 comid = Convert.ToInt64(companyid);
            Int64 registrationID = Convert.ToInt64(regid);

            List<SelectListItem> registrationList = new List<SelectListItem>();
            var list = (from n in db.HmlRegistrationGuestsDbSet
                        where n.COMPID == comid && n.REGNID == registrationID
                        select new
                        {
                            n.GUESTID
                        }
                            )
                            .Distinct()
                            .ToList();

            if (list.Count != 0)
            {
                foreach (var f in list)
                {
                    registrationList.Add(new SelectListItem { Text = f.GUESTID.ToString(), Value = f.GUESTID.ToString() });
                }
            }
            else
            {
                registrationList.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(registrationList, "Value", "Text"));
        }





        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetData(String changedText, String companyID, String registrationID)
        {
            var compid = Convert.ToInt64(companyID);
            var guestsID = Convert.ToInt64(changedText);
            var regID = Convert.ToInt64(registrationID);

            String guestnm = "",
                dob = "",
                gender = "",
                address = "",
                city = "",
                zipcode = "",
                country = "",
                nationality = "",
                emailid = "",
                telno = "",
                mobno = "",
                nidno = "",
                drlicno = "",
                visano = "",
                visaidt = "",
                visaedt = "",
                ppno = "",
                ppiplace = "",
                ppidt = "",
                ppedt = "",
                remarks = "";

            Int64 insertUserId = 0, id = 0;
            String inserttime = "", insertIpno = "", insltude = "";

            var getData = (from m in db.HmlRegistrationGuestsDbSet where m.COMPID == compid && m.REGNID == regID && m.GUESTID == guestsID select m).ToList();
            foreach (var get in getData)
            {
                id = get.ID;
                guestnm = get.GUESTNM;
                if (get.DOB != null)
                {
                    DateTime x = Convert.ToDateTime(get.DOB);
                    dob = x.ToString("dd-MMM-yyyy");
                }
                gender = get.GENDER;
                address = get.ADDRESS;
                city = get.CITY;
                zipcode = Convert.ToString(get.ZIPCODE);
                country = get.COUNTRY;
                nationality = get.NATIONALITY;
                emailid = get.EMAILID;
                telno = get.TELNO;
                mobno = get.MOBNO;
                nidno = get.NIDNO;
                drlicno = get.DRLICNO;
                visano = get.VISANO;
                if (get.VISAIDT != null)
                {
                    DateTime y = Convert.ToDateTime(get.VISAIDT);
                    visaidt = y.ToString("dd-MMM-yyyy");
                }
                if (get.VISAEDT != null)
                {
                    DateTime z = Convert.ToDateTime(get.VISAEDT);
                    visaedt = z.ToString("dd-MMM-yyyy");
                }
                ppno = get.PPNO;
                ppiplace = get.PPIPLACE;
                if (get.PPIDT != null)
                {
                    DateTime a = Convert.ToDateTime(get.PPIDT);
                    ppidt = a.ToString("dd-MMM-yyyy");
                }
                if (get.PPEDT != null)
                {
                    DateTime b = Convert.ToDateTime(get.PPEDT);
                    ppedt = b.ToString("dd-MMM-yyyy");
                }
                remarks = get.REMARKS;

                insertUserId = get.INSUSERID;
                inserttime = Convert.ToString(get.INSTIME);
                insertIpno = Convert.ToString(get.INSIPNO);
                insltude = Convert.ToString(get.INSLTUDE);
            }



            var result = new
            {
                ID = id,
                GUESTNM = guestnm,
                DOB = dob,
                GENDER = gender,
                ADDRESS = address,
                CITY = city,
                ZIPCODE = zipcode,
                COUNTRY = country,
                NATIONALITY = nationality,
                EMAILID = emailid,
                TELNO = telno,
                MOBNO = mobno,
                NIDNO = nidno,
                DRLICNO = drlicno,
                VISANO = visano,
                VISAIDT = visaidt,
                VISAEDT = visaedt,
                PPNO = ppno,
                PPIPLACE = ppiplace,
                PPIDT = ppidt,
                PPEDT = ppedt,
                REMARKS = remarks,

                INSUSERID = insertUserId,
                INSTIME = inserttime,
                INSIPNO = insertIpno,
                INSLTUDE = insltude
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        public JsonResult CitySearch(String character, String compid)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);

            var find =(from m in db.HmlRegistrationGuestsDbSet where m.COMPID == companyID && m.CITY!=null select new { m.CITY }).Distinct().ToList();
            foreach (var a in find)
            {
                result.Add(a.CITY.ToString());
            }
            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult NationalitySearch(String character, String compid)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);

            var find = (from m in db.HmlRegistrationGuestsDbSet where m.COMPID == companyID && m.NATIONALITY != null select new { m.NATIONALITY }).Distinct().ToList();
            foreach (var a in find)
            {
                result.Add(a.NATIONALITY.ToString());
            }
            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }





        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
