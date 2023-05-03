using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Api
{
    public class ApiBillTransferController : ApiController
    {
        CLoudHotelDbContext db = new CLoudHotelDbContext();

        //Datetime formet
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;

        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;

        public ApiBillTransferController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }


        //Grid level data
        [System.Web.Http.HttpGet]
        public IEnumerable<HML_BillTransferDTO> GetItemList(string cid, string room, string regid)
        {
            Int64 compid = Convert.ToInt64(cid);
            Int64 roomNo = Convert.ToInt64(room);
            Int64 registrationID = Convert.ToInt64(regid);

            string theDate = td.ToString("dd-MMM-yyyy");
            DateTime dt = Convert.ToDateTime(theDate);
            var findGridData = (from registration in db.HmlRegistrationDbSet
                                where registration.COMPID == compid && registration.ROOMNOL == roomNo && registration.REGNIDL == registrationID
                                && registration.CHECKI <= dt && dt <= registration.GHECKO
                                select new
                                {
                                    registration.ID,
                                    registration.COMPID,
                                    
                                    registration.ROOMNO,
                                    registration.REGNID,
                                    registration.REMARKS,

                                    //registration.INSIPNO,
                                    //registration.INSLTUDE,
                                    //registration.INSTIME,
                                    //registration.INSUSERID,
                                }).OrderBy(e => e.ROOMNO).ToList();

            if (findGridData.Count == 0)
            {
                yield return new HML_BillTransferDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in findGridData)
                {

                    var registrationGuest =
                        (from m in db.HmlRegistrationGuestsDbSet
                            where m.COMPID == compid && m.REGNID == s.REGNID
                            select new {m.GUESTNM}).ToList();
                    String guestName = "";
                    foreach (var get in registrationGuest)
                    {
                        guestName = get.GUESTNM;
                        break;
                    }

                    DateTime transDate = Convert.ToDateTime(td);
                    String transDate_Convert = transDate.ToString("dd-MMM-yyyy");

                    yield return new HML_BillTransferDTO
                    {
                        ID = Convert.ToInt64(s.ID),
                        COMPID = Convert.ToInt64(s.COMPID),

                        Transaction_Date = transDate_Convert,
                        ROOMNO_Child = Convert.ToInt64(s.ROOMNO),
                        REGNID__Child = Convert.ToInt64(s.REGNID),
                        GUESTNM_Child = guestName,
                        Remarks = s.REMARKS,

                        //INSUSERID = s.INSUSERID,
                        //INSLTUDE = s.INSLTUDE,
                        //INSTIME = s.INSTIME,
                        //INSIPNO = s.INSIPNO,
                    };
                }
            }
        }





        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Addrow(HML_BillTransferDTO model)
        {
            if (model.ROOMNO_Parent != model.ROOMNO_Child)
            {
                var checkData = (from n in db.HmlRegistrationDbSet
                    where n.COMPID == model.COMPID && n.REGNID == model.REGNID__Child && n.ROOMNO == model.ROOMNO_Child
                          && n.REGNIDL == model.REGNID_Parent && n.ROOMNOL == model.ROOMNO_Parent
                    select n).ToList();

                if (checkData.Count == 0)
                {
                    var findData = (from n in db.HmlRegistrationDbSet
                        where
                            n.COMPID == model.COMPID && n.REGNID == model.REGNID__Child &&
                            n.ROOMNO == model.ROOMNO_Child
                        select n).ToList();
                    foreach (var item in findData)
                    {
                        item.ROOMNOL = model.ROOMNO_Parent;
                        item.REGNIDL = model.REGNID_Parent;
                        item.REMARKS = model.Remarks;
                    }
                    db.SaveChanges();

                    //Log data save from Bill Transfer Tabel
                    //BillController controller = new BillController();
                    //controller.update_BillDetails_LogData(model);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response;
                }
                else
                {
                    model.REGNID__Child = 0;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response;
                }
            }
            else
            {
                model.REGNID__Child = 0;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }

        }





        [HttpPost]
        public HttpResponseMessage UpdateData(HML_BillTransferDTO model)
        {
            var check_data = (from n in db.HmlRegistrationDbSet
                where
                    n.ID == model.ID && n.COMPID == model.COMPID && n.REGNID == model.REGNID__Child &&
                    n.ROOMNO == model.ROOMNO_Child
                    && n.REGNIDL == model.REGNID_Parent && n.ROOMNOL == model.ROOMNO_Parent
                select n).ToList();
            if (check_data.Count == 1)
            {
                foreach (var item in check_data)
                {
                    item.ROOMNOL = null;
                    item.REGNIDL = null;
                    item.REMARKS = null;
                }
                db.SaveChanges();
            }

            HML_BillDTO obj = new HML_BillDTO();
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }







    }
}
