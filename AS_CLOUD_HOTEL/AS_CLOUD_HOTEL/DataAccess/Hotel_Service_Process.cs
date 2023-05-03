using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.DataAccess
{
    public static class Hotel_Service_Process
    {
        public static string process(PageModel model, Int64 compid)
        {

            //Datetime formet
            IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime td;


            CLoudHotelDbContext db = new CLoudHotelDbContext();
            //Get Ip ADDRESS,Time & user PC Name
            string strHostName;
            IPHostEntry ipHostInfo;
            IPAddress ipAddress;

            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            string date = Convert.ToString(model.AGlMaster.TRANSDT);
            DateTime MyDateTime = DateTime.Parse(date);
            string converttoString = MyDateTime.ToString("dd-MMM-yyyy");
            string getYear = converttoString.Substring(9, 2);
            string getMonth = converttoString.Substring(3, 3);
            string Month_Year = getMonth + "-" + getYear;


            var forRemovedata = (from l in db.GlMasterDbSet
                                 where l.COMPID == compid && l.TRANSDT == model.AGlMaster.TRANSDT
                                 select l).ToList();
            foreach (var VARIABLE in forRemovedata)
            {
                if (VARIABLE.TABLEID == "HML_SERVICES" && VARIABLE.TRANSDT == model.AGlMaster.TRANSDT)
                {
                    db.GlMasterDbSet.Remove(VARIABLE);
                }
            }
            db.SaveChanges();


            //GL Process for HML_SERVICES
            var checkDate_HML_SERVICES = (from n in db.HmlServicesDbSet where n.TRANSDT == model.AGlMaster.TRANSDT && n.COMPID == compid select n).OrderBy(x => x.TRANSNO).ToList();

            if (checkDate_HML_SERVICES.Count != 0)
            {
                Int64 max_Sale = 130000;
                foreach (var get in checkDate_HML_SERVICES)
                {
                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.tra;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1040001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "3010001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Service-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);
                    model.AGlMaster.TRANSDRCR = "DEBIT";
                    model.AGlMaster.TABLEID = "HML_SERVICES";

                    model.AGlMaster.DEBITAMT = get.AMOUNT;
                    model.AGlMaster.CREDITAMT = 0;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();



                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.TRANSFOR;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "3010001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1040001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Service-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);

                    model.AGlMaster.TRANSDRCR = "CREDIT";
                    model.AGlMaster.TABLEID = "HML_SERVICES";

                    model.AGlMaster.DEBITAMT = 0;
                    model.AGlMaster.CREDITAMT = get.AMOUNT;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();


                }
                return "True";
            }
            else
            {
                return "False";
            }
        }
    }
}