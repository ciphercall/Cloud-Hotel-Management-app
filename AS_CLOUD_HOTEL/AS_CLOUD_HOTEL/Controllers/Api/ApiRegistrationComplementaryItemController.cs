using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AS_CLOUD_HOTEL.Controllers.Hotel;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Api
{
    public class ApiRegistrationComplementaryItemController : ApiController
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

        public ApiRegistrationComplementaryItemController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        [System.Web.Http.HttpGet]
        public IEnumerable<HML_RegistrationCiDTO> GetData(String companyID, String regID)
        {
            Int64 compid = 0, rID = 0;
            try
            {
                compid = Convert.ToInt64(companyID);
                rID = Convert.ToInt64(regID);
            }
            catch
            {
                compid = 0;
                rID = 0;
            }

            var find_GridData = (from t1 in db.HmlRegistrationCiDbSet
                                 join t2 in db.HmlCitemDbSet on t1.COMPID equals t2.COMPID
                                 where t1.COMPID == compid && t1.CITEMID == t2.CITEMID && t1.REGNID == rID
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.REGNID,
                                     t1.CITEMID,
                                     t2.CITEMNM,
                                     t2.DEFYN,
                                     
                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.CITEMNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_RegistrationCiDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_RegistrationCiDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        REGNID = Convert.ToInt64(s.REGNID),
                        CITEMID = Convert.ToInt64(s.CITEMID),
                        CITEMNM = s.CITEMNM,
                        
                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }









        [HttpPost]
        public HttpResponseMessage AddData(HML_RegistrationCiDTO model)
        {
            HML_REGNCI regComplementaryItem = new HML_REGNCI();

            var check_data = (from n in db.HmlRegistrationCiDbSet where n.COMPID == model.COMPID && n.CITEMID == model.CITEMID && n.REGNID == model.REGNID select n).ToList();
            if (check_data.Count == 0)
            {
                regComplementaryItem.COMPID = model.COMPID;
                regComplementaryItem.REGNID = model.REGNID;
                regComplementaryItem.CITEMID = model.CITEMID;

                regComplementaryItem.INSIPNO = ipAddress.ToString();
                regComplementaryItem.INSTIME = Convert.ToDateTime(td);
                regComplementaryItem.INSUSERID = model.INSUSERID;
                regComplementaryItem.INSLTUDE = Convert.ToString(model.INSLTUDE);

                db.HmlRegistrationCiDbSet.Add(regComplementaryItem);
                db.SaveChanges();

                model.ID = regComplementaryItem.ID;
                model.COMPID = regComplementaryItem.COMPID;
                model.REGNID = regComplementaryItem.REGNID;
                model.CITEMID = regComplementaryItem.CITEMID;
                model.USERPC = regComplementaryItem.USERPC;
                model.INSIPNO = regComplementaryItem.INSIPNO;
                model.INSTIME = regComplementaryItem.INSTIME;
                model.INSUSERID = regComplementaryItem.INSUSERID;
                model.INSLTUDE = Convert.ToString(regComplementaryItem.INSLTUDE);

                //Log data save from HML_REGNCI Tabel
                RegistrationComplementaryItemController controller = new RegistrationComplementaryItemController();
                controller.Insert_HML_REGNCI_LogData(model);

                HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                return response1;
            }
            else
            {
                model.CITEMID = 0;
                HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.Created, model);
                return response2;
            }

        }





        //[HttpPost]
        //public HttpResponseMessage UpdateData(HML_ReserveRoomDTO model)
        //{
        //    var data_find = (from n in db.HmlReserveRoomDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.RTPID == model.RTPID && n.RESVID == model.RESVID select n).ToList();
        //    foreach (var item in data_find)
        //    {
        //        item.ROOMRTO = model.ROOMRTO;
        //        item.DISCTP = model.DISCTP;
        //        item.DISCRT = model.DISCRT;
        //        item.ROOMRTS = model.ROOMRTS;
        //        item.ROOMQTY = model.ROOMQTY;
        //        item.REMARKS = model.REMARKS;

        //        item.USERPC = strHostName;
        //        item.UPDIPNO = ipAddress.ToString();
        //        item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
        //        item.UPDTIME = Convert.ToDateTime(td);
        //        item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

        //    }
        //    db.SaveChanges();

        //    //Log data save from HML_RESVROOM Tabel
        //    ReserveRoomController controller = new ReserveRoomController();
        //    controller.update_HML_RESVROOM_LogData(model);

        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
        //    return response;

        //}






        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_RegistrationCiDTO model)
        {
            HML_REGNCI deleteModel = new HML_REGNCI();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.REGNID = Convert.ToInt64(model.REGNID);
            deleteModel.CITEMID = Convert.ToInt64(model.CITEMID);

            deleteModel = db.HmlRegistrationCiDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.REGNID, deleteModel.CITEMID);
            db.HmlRegistrationCiDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_REGNCI Tabel
            RegistrationComplementaryItemController controller = new RegistrationComplementaryItemController();
            controller.Delete_HML_REGNCI_LogData(model);
            controller.Delete_HML_REGNCI_LogDelete(model);

            HML_RegistrationCiDTO floorplanObj = new HML_RegistrationCiDTO();
            return Request.CreateResponse(HttpStatusCode.OK, floorplanObj);
        }
    }
}
