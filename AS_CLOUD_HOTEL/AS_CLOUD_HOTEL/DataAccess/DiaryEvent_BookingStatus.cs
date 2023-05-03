using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.DataAccess
{
    public class DiaryEvent_BookingStatus
    {
        public Int64 ID;
        public string Title;
        public int SomeImportantKeyID;
        public string StartDateString;
        public string EndDateString;
        public string StatusString;
        public string StatusColor;
        public string ClassName;

        public string CheckInDate;
        public string CheckOutDate;
        public string ContactPerson;
        public string MobileNo;
        public string AdultPerson;
        public string ChildPerson;
        public string RoomType;
        public string RoomQuantity;
        public string RoomInformation;
        public static List<DiaryEvent_BookingStatus> LoadAllAppointmentsInDateRange(double start, double end, Int64 companyID)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            using (CLoudHotelDbContext db = new CLoudHotelDbContext())
            {
                List<DiaryEvent_BookingStatus> result = new List<DiaryEvent_BookingStatus>();


                //                string query1 = string.Format(
                //       @"SELECT HML_ROOM.ROOMNO, HML_ROOM.RTPID, HML_REGN.REGNID, HML_REGN.CHECKI , HML_REGN.GHECKO, GUESTNM, NATIONALITY FROM HML_ROOM
                //LEFT JOIN HML_REGN ON HML_ROOM.COMPID=HML_REGN.COMPID  AND HML_ROOM.ROOMNO=HML_REGN.ROOMNO
                //AND HML_ROOM.COMPID='{0}' AND '{1}' BETWEEN HML_REGN.CHECKI AND HML_REGN.GHECKO
                //LEFT JOIN HML_GUESTS ON HML_GUESTS.COMPID=HML_REGN.COMPID AND HML_GUESTS.REGNID = HML_REGN.REGNID AND SUBSTRING(CONVERT(NVARCHAR(20),HML_GUESTS.GUESTID,103),9,2) = '01'",
                //       companyID, currentDateTime);

                var rslt = (from reg in db.HmlReserveDbSet
                            where reg.COMPID == companyID && reg.CHECKI >= fromDate && reg.GHECKO <= toDate
                            select reg).ToList();

                //var rslt = ent.AppointmentDiary.Where(s => s.DateTimeScheduled >= fromDate && System.Data.Objects.EntityFunctions.AddMinutes(s.DateTimeScheduled, s.AppointmentLength) <= toDate);

                int statusEnum = 0, id = 1;
                int SomeImportantKeyID = 0;
                string rgDate = "";
                foreach (var item in rslt)
                {
                    DiaryEvent_BookingStatus rec = new DiaryEvent_BookingStatus();
                    rec.ID = id;
                    rec.SomeImportantKeyID = SomeImportantKeyID;
                    SomeImportantKeyID++;
                    id++;

                    rec.StartDateString = string.Format("{0:yyyy-MM-ddThh:mm}", item.CHECKI); // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    rec.EndDateString = string.Format("{0:yyyy-MM-ddThh:mm}", item.GHECKO); // field AppointmentLength is in minutes

                    DateTime revDate = Convert.ToDateTime(item.RESVDT);
                    rgDate = revDate.ToString("dd-MMM-yyyy");
                    rec.Title = item.CPNM + "- Rsv. Date:" + rgDate + ".";

                    DateTime checkIn = Convert.ToDateTime(item.CHECKI);
                    rec.CheckInDate = checkIn.ToString("dd-MMM-yyyy");
                    DateTime checkOut = Convert.ToDateTime(item.GHECKO);
                    rec.CheckOutDate = checkOut.ToString("dd-MMM-yyyy");

                    rec.ContactPerson = item.CPNM;
                    rec.MobileNo = item.CPMOBNO;
                    rec.AdultPerson = item.ADULTQP.ToString();
                    rec.ChildPerson = item.CHILDQP.ToString();
                    rec.RoomInformation = "";
                    var findRoomInformation =
                        (from n in db.HmlReserveRoomDbSet
                         where n.COMPID == companyID && n.RESVID == item.RESVID
                         select new { n.RTPID, n.ROOMQTY }).ToList();
                    foreach (var get in findRoomInformation)
                    {
                        var find_RoomType = (from room in db.HmlRoomTpDbSet where room.COMPID == companyID && room.RTPID == get.RTPID select new { room.RTPNM }).ToList();
                        foreach (var getRoom in find_RoomType)
                        {
                            rec.RoomType = getRoom.RTPNM;
                        }
                        rec.RoomQuantity = get.ROOMQTY.ToString();
                        rec.RoomInformation += rec.RoomType + "(" + rec.RoomQuantity + ") ";
                    }

                    rec.StatusString = SharedCalander.Enums.GetName<SharedCalander.AppointmentStatus>((SharedCalander.AppointmentStatus)statusEnum);
                    rec.StatusColor = SharedCalander.Enums.GetEnumDescription<SharedCalander.AppointmentStatus>(rec.StatusString);
                    string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
                    rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length - 1);
                    rec.StatusColor = ColorCode;
                    result.Add(rec);
                }

                return result;
            }

        }


        //public static List<DiaryEvent_BookingStatus> LoadAppointmentSummaryInDateRange(double start, double end, Int64 companyID)
        //{

        //    var fromDate = ConvertFromUnixTimestamp(start);
        //    var toDate = ConvertFromUnixTimestamp(end);
        //    using (CLoudHotelDbContext db = new CLoudHotelDbContext())
        //    {
        //        List<DiaryEvent_BookingStatus> res = new List<DiaryEvent_BookingStatus>();

        //        //var rslt = ent.AppointmentDiary.Where(s => s.DateTimeScheduled >= fromDate && System.Data.Objects.EntityFunctions.AddMinutes(s.DateTimeScheduled, s.AppointmentLength) <= toDate)
        //        //                                        .GroupBy(s => System.Data.Objects.EntityFunctions.TruncateTime(s.DateTimeScheduled))
        //        //                                        .Select(x => new { DateTimeScheduled = x.Key, Count = x.Count() });

        //        var rslt = (from reg in db.HmlRegistrationDbSet
        //                    where reg.COMPID == companyID && reg.CHECKI >= fromDate && reg.GHECKO <= toDate
        //                    select reg).ToList();
        //        int i = 0;
        //        string rgDate = "";
        //        foreach (var item in rslt)
        //        {
        //            DiaryEvent_BookingStatus rec = new DiaryEvent_BookingStatus();
        //            rec.ID = i; //we dont link this back to anything as its a group summary but the fullcalendar needs unique IDs for each event item (unless its a repeating event)
        //            rec.SomeImportantKeyID = -1;
        //            string StartDate = string.Format("{0:yyyy-MM-dd}", item.CHECKI);
        //            rec.StartDateString = StartDate + "T00:00:00"; //ISO 8601 format
        //            string EndDate = string.Format("{0:yyyy-MM-dd}", item.GHECKO);
        //            rec.EndDateString = EndDate + "T23:59:59";
        //            //rec.Title = "Booked";

        //            DateTime regDate = Convert.ToDateTime(item.REGNDT);
        //            rgDate = regDate.ToString("dd-MMM-yyyy");
        //            rec.Title = item.ROOMNO + " - Registration Date: " + rgDate + ".";
        //            res.Add(rec);
        //            i++;
        //        }

        //        return res;
        //    }

        //}



        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}