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
using mshtml;

namespace AS_CLOUD_HOTEL.Controllers.Api
{
    public class ApiFloorPlanController : ApiController
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

        public ApiFloorPlanController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        [System.Web.Http.HttpGet]
        public IEnumerable<HML_FloorPlanDTO> GetFloorPlanData(String Compid, String floorid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            Int64 floorID = Convert.ToInt64(floorid);
            var find_GridData = (from t1 in db.HmlFloorplanDbSet
                                 join t2 in db.HmlRoomTpDbSet on t1.COMPID equals t2.COMPID
                                 join t3 in db.HmlRoomDbSet on t2.COMPID equals t3.COMPID
                                 where t1.COMPID == compid && t1.RTPID == t2.RTPID && t1.ROOMNO == t3.ROOMNO && t1.FLOORID==floorID
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.FLOORID,
                                     t1.RTPID,
                                     t1.ROOMNO,
                                     t1.REMARKS,

                                     t2.RTPNM,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.RTPNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_FloorPlanDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_FloorPlanDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        FLOORID = Convert.ToInt64(s.FLOORID),
                        RTPID = Convert.ToInt64(s.RTPID),
                        ROOMNO = Convert.ToInt64(s.ROOMNO),
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
        public HttpResponseMessage AddData(HML_FloorPlanDTO model)
        {
            if (ModelState.IsValid)
            {
                HML_FLOORPLAN floorPlan = new HML_FLOORPLAN();

                Int64 roomNumber = Convert.ToInt64(model.ROOMNO);
                var check_data = (from n in db.HmlFloorplanDbSet where n.COMPID == model.COMPID && n.FLOORID == model.FLOORID && n.RTPID == model.RTPID && n.ROOMNO == roomNumber select n).ToList();
                if (check_data.Count == 0)
                {
                    floorPlan.COMPID = model.COMPID;
                    floorPlan.FLOORID = model.FLOORID;
                    floorPlan.RTPID = model.RTPID;
                    floorPlan.ROOMNO = Convert.ToInt64(model.ROOMNO);
                    floorPlan.REMARKS = model.REMARKS;
                    floorPlan.USERPC = strHostName;
                    floorPlan.INSIPNO = ipAddress.ToString();
                    floorPlan.INSTIME = Convert.ToDateTime(td);
                    floorPlan.INSUSERID = model.INSUSERID;
                    floorPlan.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlFloorplanDbSet.Add(floorPlan);
                    db.SaveChanges();

                    model.ID = floorPlan.ID;
                    model.COMPID = floorPlan.COMPID;
                    model.FLOORID = Convert.ToInt64(floorPlan.FLOORID);
                    model.RTPID = floorPlan.RTPID;
                    model.ROOMNO = Convert.ToInt64(floorPlan.ROOMNO);
                    model.REMARKS = floorPlan.REMARKS;
                    model.USERPC = floorPlan.USERPC;
                    model.INSIPNO = floorPlan.INSIPNO;
                    model.INSTIME = floorPlan.INSTIME;
                    model.INSUSERID = floorPlan.INSUSERID;
                    model.INSLTUDE = Convert.ToString(floorPlan.INSLTUDE);

                    //Log data save from HML_FLOORPLAN Tabel
                    FloorController controller = new FloorController();
                    controller.Insert_HML_FLOORPLAN_LogData(model);

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


            model.ValidationError = true;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;
        }




        



        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_FloorPlanDTO model)
        {
            HML_FLOORPLAN deleteModel = new HML_FLOORPLAN();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.FLOORID = Convert.ToInt64(model.FLOORID);
            deleteModel.RTPID = Convert.ToInt64(model.RTPID);
            deleteModel.ROOMNO = Convert.ToInt64(model.ROOMNO);

            deleteModel = db.HmlFloorplanDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.FLOORID, deleteModel.RTPID, deleteModel.ROOMNO);
            db.HmlFloorplanDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_FLOORPLAN Tabel
            FloorController controller = new FloorController();
            controller.Delete_HML_FLOORPLAN_LogData(model);
            controller.Delete_HML_FLOORPLAN_LogDelete(model);

            HML_FloorPlanDTO floorplanObj = new HML_FloorPlanDTO();
            return Request.CreateResponse(HttpStatusCode.OK, floorplanObj);
        }



    }
}
