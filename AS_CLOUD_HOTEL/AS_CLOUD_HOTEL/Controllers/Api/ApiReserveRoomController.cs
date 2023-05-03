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
    public class ApiReserveRoomController : ApiController
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

        public ApiReserveRoomController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        [System.Web.Http.HttpGet]
        public IEnumerable<HML_ReserveRoomDTO> GetReserveRoomData(String companyID, String reserveID)
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

            var find_GridData = (from t1 in db.HmlReserveRoomDbSet
                                 join t2 in db.HmlRoomTpDbSet on t1.COMPID equals t2.COMPID
                                 where t1.COMPID == compid && t1.RTPID == t2.RTPID && t1.RESVID == rID
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.RESVID,
                                     t1.RTPID,
                                     t1.ROOMRTO,
                                     t1.DISCTP,
                                     t1.DISCRT,
                                     t1.ROOMRTS,
                                     t1.ROOMQTY,
                                     t1.REMARKS,

                                     t2.RTPNM,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.RTPNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_ReserveRoomDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_ReserveRoomDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        RESVID = Convert.ToInt64(s.RESVID),
                        RTPID = Convert.ToInt64(s.RTPID),
                        ROOMRTO = Convert.ToInt64(s.ROOMRTO),
                        DISCTP = s.DISCTP,
                        DISCRT = s.DISCRT,
                        ROOMRTS = s.ROOMRTS,
                        ROOMQTY = s.ROOMQTY,
                        REMARKS = Convert.ToString(s.REMARKS),

                        RTPNM = s.RTPNM,

                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }









        [HttpPost]
        public HttpResponseMessage AddData(HML_ReserveRoomDTO model)
        {
            HML_RESVROOM reserveRoom = new HML_RESVROOM();

            var check_data = (from n in db.HmlReserveRoomDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID && n.RESVID == model.RESVID select n).ToList();
            if (check_data.Count == 0)
            {
                reserveRoom.COMPID = model.COMPID;
                reserveRoom.RESVID = model.RESVID;
                reserveRoom.RTPID = model.RTPID;
                reserveRoom.ROOMRTO = Convert.ToInt64(model.ROOMRTO);
                reserveRoom.DISCTP = model.DISCTP;
                reserveRoom.DISCRT = model.DISCRT;
                reserveRoom.ROOMRTS = model.ROOMRTS;
                reserveRoom.ROOMQTY = model.ROOMQTY;
                reserveRoom.REMARKS = model.REMARKS;


                reserveRoom.INSIPNO = ipAddress.ToString();
                reserveRoom.INSTIME = Convert.ToDateTime(td);
                reserveRoom.INSUSERID = model.INSUSERID;
                reserveRoom.INSLTUDE = Convert.ToString(model.INSLTUDE);

                db.HmlReserveRoomDbSet.Add(reserveRoom);
                db.SaveChanges();

                model.ID = reserveRoom.ID;
                model.COMPID = reserveRoom.COMPID;
                model.RESVID = reserveRoom.RESVID;
                model.RTPID = reserveRoom.RTPID;
                model.ROOMRTO = reserveRoom.ROOMRTO;
                model.DISCTP = reserveRoom.DISCTP;
                model.DISCRT = reserveRoom.DISCRT;
                model.ROOMRTS = reserveRoom.ROOMRTS;
                model.ROOMQTY = reserveRoom.ROOMQTY;
                model.REMARKS = reserveRoom.REMARKS;
                model.USERPC = reserveRoom.USERPC;
                model.INSIPNO = reserveRoom.INSIPNO;
                model.INSTIME = reserveRoom.INSTIME;
                model.INSUSERID = reserveRoom.INSUSERID;
                model.INSLTUDE = Convert.ToString(reserveRoom.INSLTUDE);

                //Log data save from HML_RESVROOM Tabel
                ReserveRoomController controller = new ReserveRoomController();
                controller.Insert_HML_RESVROOM_LogData(model);

                HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                return response1;
            }
            else
            {
                model.RTPID = 0;
                HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.Created, model);
                return response2;
            }

        }





        [HttpPost]
        public HttpResponseMessage UpdateData(HML_ReserveRoomDTO model)
        {
            var data_find = (from n in db.HmlReserveRoomDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.RTPID == model.RTPID && n.RESVID == model.RESVID select n).ToList();
            foreach (var item in data_find)
            {
                item.ROOMRTO = model.ROOMRTO;
                item.DISCTP = model.DISCTP;
                item.DISCRT = model.DISCRT;
                item.ROOMRTS = model.ROOMRTS;
                item.ROOMQTY = model.ROOMQTY;
                item.REMARKS = model.REMARKS;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_RESVROOM Tabel
            ReserveRoomController controller = new ReserveRoomController();
            controller.update_HML_RESVROOM_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }






        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_ReserveRoomDTO model)
        {
            HML_RESVROOM deleteModel = new HML_RESVROOM();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.RESVID = Convert.ToInt64(model.RESVID);
            deleteModel.RTPID = Convert.ToInt64(model.RTPID);

            deleteModel = db.HmlReserveRoomDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.RESVID, deleteModel.RTPID);
            db.HmlReserveRoomDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_RESVROOM Tabel
            ReserveRoomController controller = new ReserveRoomController();
            controller.Delete_HML_RESVROOM_LogData(model);
            controller.Delete_HML_RESVROOM_LogDelete(model);

            HML_ReserveRoomDTO floorplanObj = new HML_ReserveRoomDTO();
            return Request.CreateResponse(HttpStatusCode.OK, floorplanObj);
        }

    }
}
