﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.DataAccess;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.Controllers.GL
{
    public class ProcessController : AppController
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
        public string Process_Done1, Process_Done2, Process_Done3, Process_Done4, Process_Done5, Process_Done6, Process_Done7;
        private Int64 K;

        public ProcessController()
        {
            Process_Done1 = ""; Process_Done2 = ""; Process_Done3 = ""; Process_Done4 = ""; Process_Done5 = "";Process_Done6 = "";Process_Done7="";
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            ViewData["HighLight_Menu_AccountForm"] = "highlight menu";
            K = 0;
        }







        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_Process_LogData(GL_MASTER model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));
            Int64 loggedUserID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == loggedUserID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = loggedUserID;
            aslLog.LOGTYPE = "INSERT";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "GL_MASTER PROCESS";

            string username = "";
            var UserNameFind = (from n in db.AslUsercoDbSet where n.USERID == loggedUserID select n).ToList();
            foreach (var name in UserNameFind)
            {
                username = name.USERNM;
            }

            string transDate = "";
            if (model.TRANSDT != null)
            {
                string convert_Date = Convert.ToString(model.TRANSDT);
                DateTime MyDateTime = DateTime.Parse(convert_Date);
                transDate = MyDateTime.ToString("dd-MMM-yyyy");
            }

            aslLog.LOGDATA = Convert.ToString("Process: Process to GlMaster." + "\nTime: " + aslLog.LOGTIME + ",\nDate: " + transDate + ",\nUserName: " + username + ".");
            aslLog.USERPC = strHostName;
            db.AslLogDbSet.Add(aslLog);
        }
















        // GET: /Process/
        public ActionResult Index()
        {
            return View();
        }


        [AcceptVerbs("POST")]
        [ActionName("Index")]
        public ActionResult IndexPost(PageModel model, string command)
        {
            // For use only Log Data
            GL_MASTER logData = new GL_MASTER();
            logData.COMPID = model.AGlMaster.COMPID;
            logData.INSLTUDE = model.AGlMaster.INSLTUDE;
            logData.TRANSDT = model.AGlMaster.TRANSDT;

            if (command == "Process")
            {
                if (model.AGlMaster.TRANSDT != null)
                {
                    //Insert permission check
                    Int64 compid = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedCompID"]);
                    Int64 loggedUserID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);

                    string InsertStatus = "";
                    var permission = (from m in db.AslRoleDbSet
                                      where m.COMPID == compid && m.USERID == loggedUserID && m.CONTROLLERNAME == "Process" && m.ACTIONNAME == "Index" && m.MENUTP == "F"
                                      && m.MODULEID == "03"
                                      select new { m.INSERTR, m.DELETER, m.UPDATER });
                    foreach (var VARIABLE in permission)
                    {
                        InsertStatus = VARIABLE.INSERTR;
                    }
                    if (InsertStatus == "I")
                    {
                        TempData["message"] = "Permission not granted!";
                        return RedirectToAction("Index");
                    }


                    var forremovedata = (from l in db.GlMasterDbSet
                                         where l.COMPID == compid && l.TRANSDT == model.AGlMaster.TRANSDT
                                         select l).ToList();

                    foreach (var VARIABLE in forremovedata)
                    {
                        if (VARIABLE.TABLEID == "GL_STRANS")
                        {
                            db.GlMasterDbSet.Remove(VARIABLE);
                        }
                    }
                    db.SaveChanges();




                    //GL Process for GL_STRANS
                    var checkDate_GL_STRANS = (from n in db.GlStransDbSet where n.TRANSDT == model.AGlMaster.TRANSDT && n.COMPID == compid select n).OrderBy(x => x.TRANSNO).ToList();

                    if (checkDate_GL_STRANS.Count != 0)
                    {
                        foreach (var x in checkDate_GL_STRANS)
                        {

                            //var checkifexist = (from m in db.GlMasterDbSet
                            //    where m.COMPID == x.COMPID && m.TRANSDT == x.TRANSDT && m.TRANSTP == x.TRANSTP
                            //          && m.TRANSNO == x.TRANSNO
                            //    select m).ToList();
                            //if (checkifexist.Count == 0)
                            //{
                            if (x.TRANSTP == "MREC")
                            {
                                Int64 maxSlCheck = Convert.ToInt64((from a in db.GlMasterDbSet
                                                                    where a.COMPID == compid && a.TRANSTP == x.TRANSTP
                                                                    select a.TRANSSL).Max());

                                if (maxSlCheck == 0)
                                {
                                    model.AGlMaster.TRANSSL = 10001;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;
                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";


                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;


                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                    model.AGlMaster.TRANSSL = 10002;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                }
                                else
                                {
                                    model.AGlMaster.TRANSSL = maxSlCheck + 1;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;

                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                    model.AGlMaster.TRANSSL = maxSlCheck + 2;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;

                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();
                                }

                            }

                            else if (x.TRANSTP == "MPAY")
                            {
                                Int64 maxSlCheck = Convert.ToInt64((from a in db.GlMasterDbSet
                                                                    where a.COMPID == compid && a.TRANSTP == x.TRANSTP
                                                                    select a.TRANSSL).Max());

                                if (maxSlCheck == 0)
                                {
                                    model.AGlMaster.TRANSSL = 20001;


                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;

                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();


                                    model.AGlMaster.TRANSSL = 20002;


                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;

                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    model.AGlMaster.TRANSSL = maxSlCheck + 1;


                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;
                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();


                                    model.AGlMaster.TRANSSL = maxSlCheck + 2;


                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;

                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();
                                }
                            }
                            else if (x.TRANSTP == "JOUR")
                            {
                                Int64 maxSlCheck = Convert.ToInt64((from a in db.GlMasterDbSet
                                                                    where a.COMPID == compid && a.TRANSTP == x.TRANSTP
                                                                    select a.TRANSSL).Max());

                                if (maxSlCheck == 0)
                                {
                                    model.AGlMaster.TRANSSL = 30001;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;
                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                    model.AGlMaster.TRANSSL = 30002;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;

                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    model.AGlMaster.TRANSSL = maxSlCheck + 1;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;

                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";
                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                    model.AGlMaster.TRANSSL = maxSlCheck + 2;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;
                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();
                                }
                            }
                            else if (x.TRANSTP == "CONT")
                            {
                                Int64 maxSlCheck = Convert.ToInt64((from a in db.GlMasterDbSet
                                                                    where a.COMPID == compid && a.TRANSTP == x.TRANSTP
                                                                    select a.TRANSSL).Max());

                                if (maxSlCheck == 0)
                                {
                                    model.AGlMaster.TRANSSL = 40001;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;

                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";


                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                    model.AGlMaster.TRANSSL = 40002;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;
                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();


                                }
                                else
                                {
                                    model.AGlMaster.TRANSSL = maxSlCheck + 1;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.DEBITCD;
                                    model.AGlMaster.CREDITCD = x.CREDITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = x.AMOUNT;
                                    model.AGlMaster.CREDITAMT = 0;

                                    model.AGlMaster.TRANSDRCR = "DEBIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();

                                    model.AGlMaster.TRANSSL = maxSlCheck + 2;

                                    model.AGlMaster.TRANSDT = x.TRANSDT;
                                    model.AGlMaster.COMPID = x.COMPID;
                                    model.AGlMaster.TRANSTP = x.TRANSTP;
                                    model.AGlMaster.TRANSMY = x.TRANSMY;
                                    model.AGlMaster.TRANSNO = x.TRANSNO;
                                    model.AGlMaster.TRANSFOR = x.TRANSFOR;
                                    model.AGlMaster.TRANSMODE = x.TRANSMODE;
                                    model.AGlMaster.COSTPID = x.COSTPID;
                                    model.AGlMaster.DEBITCD = x.CREDITCD;
                                    model.AGlMaster.CREDITCD = x.DEBITCD;
                                    model.AGlMaster.CHEQUENO = x.CHEQUENO;
                                    model.AGlMaster.CHEQUEDT = x.CHEQUEDT;
                                    model.AGlMaster.REMARKS = x.REMARKS;

                                    model.AGlMaster.DEBITAMT = 0;
                                    model.AGlMaster.CREDITAMT = x.AMOUNT;

                                    model.AGlMaster.TRANSDRCR = "CREDIT";
                                    model.AGlMaster.TABLEID = "GL_STRANS";

                                    model.AGlMaster.USERPC = strHostName;
                                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);

                                    model.AGlMaster.INSUSERID =
                                        Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                                    db.GlMasterDbSet.Add(model.AGlMaster);
                                    db.SaveChanges();
                                }
                            }
                            Process_Done1 = "complete";
                            TempData["message"] = "Processing Done";

                            K++;
                            if (K == 1)
                            {
                                Insert_Process_LogData(logData);
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        TempData["message"] = "No no...process would not done";

                    }








                    //Sale & Sale Return Process from DataAccess folder(class Sale_SaleReturn_Process)
                    string Sale_Return = "";
                    Sale_Return = Sale_SaleReturn_Process.process(model, compid);
                    if (Sale_Return == "True")
                    {
                        K++;
                        if (K == 1)
                        {
                            Insert_Process_LogData(logData);
                            db.SaveChanges();
                        }
                        Process_Done2 = "complete";
                        TempData["message"] = "Processing Done";
                    }
                    else if (Sale_Return == "False")
                    {
                        TempData["message"] = "No no...process would not done";
                    }





                    //Buy & Buy Return Process from DataAccess folder(class Buy_BuyReturn_Process)
                    string Buy_BuyReturn = "";
                    Buy_BuyReturn = Buy_BuyReturn_Process.process(model, compid);
                    if (Buy_BuyReturn == "True")
                    {
                        K++;
                        if (K == 1)
                        {
                            Insert_Process_LogData(logData);
                            db.SaveChanges();
                        }
                        Process_Done3 = "complete";
                        TempData["message"] = "Processing Done";
                    }
                    else if (Buy_BuyReturn == "False")
                    {
                        TempData["message"] = "No no...process would not done";
                    }




                    //Reserve Payment Process from DataAccess folder(class Hotel_ReservePayment_Process)
                    string ReservePayment = "";
                    ReservePayment = Hotel_ReservePayment_Process.process(model, compid);
                    if (ReservePayment == "True")
                    {
                        K++;
                        if (K == 1)
                        {
                            Insert_Process_LogData(logData);
                            db.SaveChanges();
                        }
                        Process_Done4 = "complete";
                        TempData["message"] = "Processing Done";
                    }
                    else if (ReservePayment == "False")
                    {
                        TempData["message"] = "No no...process would not done";
                    }



                    //Registration Payment Process from DataAccess folder(class Hotel_RegistrationPayment_Process)
                    string RegistrationPayment = "";
                    RegistrationPayment = Hotel_RegistrationPayment_Process.process(model, compid);
                    if (RegistrationPayment == "True")
                    {
                        K++;
                        if (K == 1)
                        {
                            Insert_Process_LogData(logData);
                            db.SaveChanges();
                        }
                        Process_Done5 = "complete";
                        TempData["message"] = "Processing Done";
                    }
                    else if (RegistrationPayment == "False")
                    {
                        TempData["message"] = "No no...process would not done";
                    }



                    //Service Process from DataAccess folder(class Hotel_Service_Process)
                    string Service = "";
                    Service = Hotel_Service_Process.process(model, compid);
                    if (Service == "True")
                    {
                        K++;
                        if (K == 1)
                        {
                            Insert_Process_LogData(logData);
                            db.SaveChanges();
                        }
                        Process_Done6 = "complete";
                        TempData["message"] = "Processing Done";
                    }
                    else if (Service == "False")
                    {
                        TempData["message"] = "No no...process would not done";
                    }



                    //Bill Process from DataAccess folder(class Hotel_Service_Process)
                    string Bill = "";
                    Bill = Hotel_Bill_Process.process(model, compid);
                    if (Bill == "True")
                    {
                        K++;
                        if (K == 1)
                        {
                            Insert_Process_LogData(logData);
                            db.SaveChanges();
                        }
                        Process_Done7 = "complete";
                        TempData["message"] = "Processing Done";
                    }
                    else if (Bill == "False")
                    {
                        TempData["message"] = "No no...process would not done";
                    }





                    if (Process_Done1 != "" || Process_Done2 != "" || Process_Done3 != "" || Process_Done4 != "" || Process_Done5 != "" || Process_Done6 != "" || Process_Done7 != "")
                    {
                        TempData["message"] = "Processing Done";
                    }
                    else
                    {
                        TempData["message"] = "No no...process would not done";
                    }



                    string date = Convert.ToString(model.AGlMaster.TRANSDT);
                    DateTime MyDateTime = DateTime.Parse(date);
                    string converttoString = MyDateTime.ToString("dd-MMM-yyyy");
                    TempData["Process_Date"] = converttoString;
                }

            }
            else
            {
                TempData["message"] = null;
            }


            return RedirectToAction("Index");
        }






        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
