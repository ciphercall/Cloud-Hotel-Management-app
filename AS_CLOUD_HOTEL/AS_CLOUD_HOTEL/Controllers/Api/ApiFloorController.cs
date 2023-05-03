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
    public class ApiFloorController : ApiController
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

        public ApiFloorController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        [System.Web.Http.HttpGet]
        public IEnumerable<HML_FloorDTO> GetFloorData(string Compid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            var find_GridData = (from t1 in db.HmlFloorDbSet
                                 where t1.COMPID == compid
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.FLOORID,
                                     t1.FLOORNM,
                                     t1.REMARKS,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.FLOORNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_FloorDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_FloorDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        FLOORID = Convert.ToInt64(s.FLOORID),
                        FLOORNM = s.FLOORNM,
                        REMARKS = Convert.ToString(s.REMARKS),
                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }









        [HttpPost]
        public HttpResponseMessage AddData(HML_FloorDTO model)
        {
            if (ModelState.IsValid)
            {
                HML_FLOOR floor = new HML_FLOOR();

                var check_data = (from n in db.HmlFloorDbSet where n.COMPID == model.COMPID && n.FLOORNM == model.FLOORNM select n).ToList();
                if (check_data.Count == 0)
                {
                    var find_data = (from n in db.HmlFloorDbSet where n.COMPID == model.COMPID select n.FLOORID).ToList();
                    if (find_data.Count == 0)
                    {
                        floor.FLOORID = Convert.ToInt64(Convert.ToString(model.COMPID) + "01");
                    }
                    else
                    {
                        Int64 find_Max_RTPID = Convert.ToInt64((from n in db.HmlFloorDbSet where n.COMPID == model.COMPID select n.FLOORID).Max());
                        floor.FLOORID = find_Max_RTPID + 1;
                    }

                    floor.COMPID = model.COMPID;
                    floor.FLOORNM = model.FLOORNM;
                    floor.REMARKS = model.REMARKS;
                    floor.USERPC = strHostName;
                    floor.INSIPNO = ipAddress.ToString();
                    floor.INSTIME = Convert.ToDateTime(td);
                    floor.INSUSERID = model.INSUSERID;
                    floor.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlFloorDbSet.Add(floor);
                    db.SaveChanges();

                    model.ID = floor.ID;
                    model.COMPID = floor.COMPID;
                    model.FLOORID = Convert.ToInt64(floor.FLOORID);
                    model.FLOORNM = floor.FLOORNM;
                    model.REMARKS = floor.REMARKS;
                    model.USERPC = floor.USERPC;
                    model.INSIPNO = floor.INSIPNO;
                    model.INSTIME = floor.INSTIME;
                    model.INSUSERID = floor.INSUSERID;
                    model.INSLTUDE = Convert.ToString(floor.INSLTUDE);

                    //Log data save from HML_FLOOR Tabel
                    FloorController controller = new FloorController();
                    controller.Insert_HML_FLOOR_LogData(model);

                    HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response1;
                }
                else
                {
                    model.FLOORID = 0;
                    HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response2;
                }
            }
            

            model.ValidationError = true;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;
        }





        [HttpPost]
        public HttpResponseMessage UpdateData(HML_FloorDTO model)
        {
            var data_find = (from n in db.HmlFloorDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.FLOORID == model.FLOORID select n).ToList();
            foreach (var item in data_find)
            {
                item.FLOORNM = Convert.ToString(model.FLOORNM);
                item.REMARKS = model.REMARKS;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_FLOOR Tabel
            FloorController controller = new FloorController();
            controller.update_HML_FLOOR_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }









        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_FloorDTO model)
        {
            HML_FLOOR deleteModel = new HML_FLOOR();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.FLOORID = Convert.ToInt64(model.FLOORID);

            var findChildData = (from n in db.HmlFloorplanDbSet
                                 where n.FLOORID == deleteModel.FLOORID && n.COMPID == deleteModel.COMPID
                                 select n).ToList();

            HML_FloorDTO floorObj = new HML_FloorDTO();

            if (findChildData.Count != 0)
            {
                floorObj.GetChildDataForDeleteMasterCategory = 1; // True (child data found)
            }
            else
            {
                deleteModel = db.HmlFloorDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.FLOORID);
                db.HmlFloorDbSet.Remove(deleteModel);
                db.SaveChanges();

                //Log data save from HML_FLOOR Tabel
                FloorController controller = new FloorController();
                controller.Delete_HML_FLOOR_LogData(model);
                controller.Delete_HML_FLOOR_LogDelete(model);
            }
            return Request.CreateResponse(HttpStatusCode.OK, floorObj);
        }
    }
    
}
