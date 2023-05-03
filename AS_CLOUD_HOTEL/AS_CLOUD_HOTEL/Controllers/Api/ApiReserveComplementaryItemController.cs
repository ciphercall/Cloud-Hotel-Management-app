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
    public class ApiReserveComplementaryItemController : ApiController
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

        public ApiReserveComplementaryItemController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        [System.Web.Http.HttpGet]
        public IEnumerable<HML_ReserveCiDTO> GetData(String companyID, String reserveID)
        {
            Int64 compid = 0, rID = 0;
            try
            {
                compid = Convert.ToInt64(companyID);
                rID = Convert.ToInt64(reserveID);
            }
            catch
            {
                compid = 0;
                rID = 0;
            }

            var find_GridData = (from t1 in db.HmlResrveCiDbSet
                                 join t2 in db.HmlCitemDbSet on t1.COMPID equals t2.COMPID
                                 where t1.COMPID == compid && t1.CITEMID == t2.CITEMID && t1.RESVID == rID
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.RESVID,
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
                yield return new HML_ReserveCiDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_ReserveCiDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        RESVID = Convert.ToInt64(s.RESVID),
                        CITEMID = Convert.ToInt64(s.CITEMID),
                        CITEMNM = s.CITEMNM,
                        DEFYN = s.DEFYN,
                        
                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }









        [HttpPost]
        public HttpResponseMessage AddData(HML_ReserveCiDTO model)
        {
            HML_RESVCI reserveComplementaryItem = new HML_RESVCI();

            var check_data = (from n in db.HmlResrveCiDbSet where n.COMPID == model.COMPID && n.CITEMID == model.CITEMID && n.RESVID == model.RESVID select n).ToList();
            if (check_data.Count == 0)
            {
                reserveComplementaryItem.COMPID = model.COMPID;
                reserveComplementaryItem.RESVID = model.RESVID;
                reserveComplementaryItem.CITEMID = model.CITEMID;
                
                reserveComplementaryItem.INSIPNO = ipAddress.ToString();
                reserveComplementaryItem.INSTIME = Convert.ToDateTime(td);
                reserveComplementaryItem.INSUSERID = model.INSUSERID;
                reserveComplementaryItem.INSLTUDE = Convert.ToString(model.INSLTUDE);

                db.HmlResrveCiDbSet.Add(reserveComplementaryItem);
                db.SaveChanges();

                model.ID = reserveComplementaryItem.ID;
                model.COMPID = reserveComplementaryItem.COMPID;
                model.RESVID = reserveComplementaryItem.RESVID;
                model.CITEMID = reserveComplementaryItem.CITEMID;
                model.USERPC = reserveComplementaryItem.USERPC;
                model.INSIPNO = reserveComplementaryItem.INSIPNO;
                model.INSTIME = reserveComplementaryItem.INSTIME;
                model.INSUSERID = reserveComplementaryItem.INSUSERID;
                model.INSLTUDE = Convert.ToString(reserveComplementaryItem.INSLTUDE);

                //Log data save from HML_RESVCI Tabel
                ReserveComplementaryItemController controller = new ReserveComplementaryItemController();
                controller.Insert_HML_RESVCI_LogData(model);

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
        public HttpResponseMessage DeleteData(HML_ReserveCiDTO model)
        {
            HML_RESVCI deleteModel = new HML_RESVCI();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.RESVID = Convert.ToInt64(model.RESVID);
            deleteModel.CITEMID = Convert.ToInt64(model.CITEMID);

            deleteModel = db.HmlResrveCiDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.RESVID, deleteModel.CITEMID);
            db.HmlResrveCiDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_RESVCI Tabel
            ReserveComplementaryItemController controller = new ReserveComplementaryItemController();
            controller.Delete_HML_RESVCI_LogData(model);
            controller.Delete_HML_RESVCI_LogDelete(model);

            HML_ReserveCiDTO floorplanObj = new HML_ReserveCiDTO();
            return Request.CreateResponse(HttpStatusCode.OK, floorplanObj);
        }
    }
}
