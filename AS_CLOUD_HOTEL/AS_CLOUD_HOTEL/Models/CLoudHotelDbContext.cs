using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.ASL;
using AS_CLOUD_HOTEL.Models.HML;
using AS_CLOUD_HOTEL.Models.Store;

namespace AS_CLOUD_HOTEL.Models
{
    public class CLoudHotelDbContext : DbContext
    {
        public DbSet<AslCompany> AslCompanyDbSet { get; set; }
        public DbSet<AslUserco> AslUsercoDbSet { get; set; }
        public DbSet<ASL_LOG> AslLogDbSet { get; set; }
        public DbSet<ASL_DELETE> AslDeleteDbSet { get; set; }
        public DbSet<ASL_MENUMST> AslMenumstDbSet { get; set; }
        public DbSet<ASL_MENU> AslMenuDbSet { get; set; }
        public DbSet<ASL_ROLE> AslRoleDbSet { get; set; }
        public DbSet<GL_ACCHARMST> GlAccharmstDbSet { get; set; }
        public DbSet<GL_ACCHART> GlAcchartDbSet { get; set; }
        public DbSet<GL_COSTPMST> GLCostPMSTDbSet { get; set; }
        public DbSet<GL_COSTPOOL> GlCostPoolDbSet { get; set; }
        public DbSet<GL_STRANS> GlStransDbSet { get; set; }
        public DbSet<GL_MASTER> GlMasterDbSet { get; set; }
        public DbSet<STK_ITEMMST> StkItemmstDbSet { get; set; }
        public DbSet<STK_ITEM> StkItemDbSet { get; set; }
        public DbSet<STK_STORE> StkStoreDbSet { get; set; }
        public DbSet<STK_TRANSMST> StkTransmstDbSet { get; set; }
        public DbSet<STK_TRANS> StkTransDbSet { get; set; }
        public DbSet<STK_PS> PsDbSet { get; set; }
        public DbSet<HML_GUESTRF> HmlGuestrfDbSet { get; set; }
        public DbSet<HML_GUESTCO> HmlGuestcoDbSet { get; set; }
        public DbSet<HML_ROOMTP> HmlRoomTpDbSet { get; set; }
        public DbSet<HML_ROOM> HmlRoomDbSet { get; set; }
        public DbSet<HML_FLOOR> HmlFloorDbSet { get; set; }
        public DbSet<HML_FLOORPLAN> HmlFloorplanDbSet { get; set; }
        public DbSet<HML_BILLHP> HmlBillHpDbSet { get; set; }
        public DbSet<HML_CITEM> HmlCitemDbSet { get; set; }
        public DbSet<HML_RESERVE> HmlReserveDbSet { get; set; }
        public DbSet<HML_RESVROOM> HmlReserveRoomDbSet { get; set; }
        public DbSet<HML_RESVPAY> HmlReservePayDbSet { get; set; }
        public DbSet<HML_RESVCI> HmlResrveCiDbSet { get; set; }
        public DbSet<HML_REGN> HmlRegistrationDbSet { get; set; }
        public DbSet<HML_REGNPAY> HmlRegistrationPaymentDbSet { get; set; }
        public DbSet<HML_GUESTS> HmlRegistrationGuestsDbSet { get; set; }
        public DbSet<HML_REGNCI> HmlRegistrationCiDbSet { get; set; }
        public DbSet<HML_ROOMSTATS> HmlRoomStatusDbSet { get; set; }
        public DbSet<HML_SERVICES> HmlServicesDbSet { get; set; }
        public DbSet<HML_BILL> HmlBillDbSet { get; set; }
        public DbSet<HML_BILLDTL> HmlBillDetailsDbSet { get; set; }


       
        //Upload Excel File Data module
        public DbSet<ASL_PCONTACTS> UploadContactDbSet { get; set; }
        public DbSet<ASL_PGROUPS> UploadGroupDbSet { get; set; }
        public DbSet<ASL_PEMAIL>SendLogEmailDbSet { get; set; }
        public DbSet<ASL_PSMS> SendLogSMSDbSet { get; set; }

        public DbSet<ASL_CALENDAR> CalendarDbSet { get; set; }


        //Promotional
        public DbSet<ASL_PCalendarImage> CalendarImageDbSet { get; set; }
        public DbSet<ASL_SchedularCalendar> SchedularCalendarDbSet { get; set; }

        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}