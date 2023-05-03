namespace AS_CLOUD_HOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AslCompanies",
                c => new
                    {
                        AslCompanyId = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        COMPNM = c.String(nullable: false),
                        ADDRESS = c.String(nullable: false),
                        ADDRESS2 = c.String(),
                        CONTACTNO = c.String(nullable: false),
                        EMAILID = c.String(nullable: false),
                        WEBID = c.String(),
                        STATUS = c.String(nullable: false),
                        EMAILIDP = c.String(),
                        EMAILPWP = c.String(),
                        SMSIDP = c.String(),
                        SMSPWP = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.AslCompanyId);
            
            CreateTable(
                "dbo.ASL_DELETE",
                c => new
                    {
                        Asl_DeleteID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        USERID = c.Long(),
                        DELSLNO = c.Long(),
                        DELDATE = c.String(),
                        DELTIME = c.String(),
                        DELIPNO = c.String(),
                        DELLTUDE = c.String(),
                        TABLEID = c.String(),
                        DELDATA = c.String(),
                        USERPC = c.String(),
                    })
                .PrimaryKey(t => t.Asl_DeleteID);
            
            CreateTable(
                "dbo.ASL_LOG",
                c => new
                    {
                        Asl_LOGid = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        USERID = c.Long(),
                        LOGTYPE = c.String(),
                        LOGSLNO = c.Long(),
                        LOGDATE = c.DateTime(),
                        LOGTIME = c.String(),
                        LOGIPNO = c.String(),
                        LOGLTUDE = c.String(),
                        TABLEID = c.String(),
                        LOGDATA = c.String(),
                        USERPC = c.String(),
                    })
                .PrimaryKey(t => t.Asl_LOGid);
            
            CreateTable(
                "dbo.ASL_MENU",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MODULEID = c.String(),
                        MENUTP = c.String(),
                        MENUID = c.String(),
                        MENUNM = c.String(),
                        ACTIONNAME = c.String(),
                        CONTROLLERNAME = c.String(),
                        SERIAL = c.Long(nullable: false),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ASL_MENUMST",
                c => new
                    {
                        MODULEID = c.String(nullable: false, maxLength: 128),
                        MODULENM = c.String(nullable: false),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                    })
                .PrimaryKey(t => t.MODULEID);
            
            CreateTable(
                "dbo.ASL_ROLE",
                c => new
                    {
                        ASL_ROLEId = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        USERID = c.Long(nullable: false),
                        MODULEID = c.String(nullable: false),
                        MENUTP = c.String(nullable: false),
                        MENUID = c.String(),
                        SERIAL = c.Long(nullable: false),
                        STATUS = c.String(),
                        INSERTR = c.String(),
                        UPDATER = c.String(),
                        DELETER = c.String(),
                        MENUNAME = c.String(),
                        ACTIONNAME = c.String(),
                        CONTROLLERNAME = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                    })
                .PrimaryKey(t => t.ASL_ROLEId);
            
            CreateTable(
                "dbo.AslUsercoes",
                c => new
                    {
                        AslUsercoId = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        USERID = c.Long(),
                        USERNM = c.String(nullable: false),
                        DEPTNM = c.String(),
                        OPTP = c.String(nullable: false),
                        ADDRESS = c.String(nullable: false),
                        MOBNO = c.String(nullable: false),
                        EMAILID = c.String(),
                        LOGINBY = c.String(nullable: false),
                        LOGINID = c.String(nullable: false),
                        LOGINPW = c.String(nullable: false),
                        TIMEFR = c.String(nullable: false),
                        TIMETO = c.String(nullable: false),
                        STATUS = c.String(nullable: false),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.AslUsercoId);
            
            CreateTable(
                "dbo.ASL_CALENDAR",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        USERID = c.Long(),
                        text = c.String(),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ASL_PCalendarImage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Year = c.Long(nullable: false),
                        Month = c.String(nullable: false, maxLength: 128),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.Year, t.Month });
            
            CreateTable(
                "dbo.GL_ACCHARMST",
                c => new
                    {
                        ACCHARMSTId = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        HEADTP = c.Int(nullable: false),
                        HEADCD = c.Long(),
                        HEADNM = c.String(nullable: false),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.ACCHARMSTId);
            
            CreateTable(
                "dbo.GL_ACCHART",
                c => new
                    {
                        ACCHARTId = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        HEADTP = c.Int(nullable: false),
                        HEADCD = c.Long(),
                        ACCOUNTCD = c.Long(),
                        ACCOUNTNM = c.String(),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.ACCHARTId);
            
            CreateTable(
                "dbo.GL_COSTPMST",
                c => new
                    {
                        CostMstID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        COSTCID = c.Long(),
                        COSTCNM = c.String(nullable: false),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.CostMstID);
            
            CreateTable(
                "dbo.GL_COSTPOOL",
                c => new
                    {
                        CostPLID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        COSTCID = c.Long(),
                        COSTPID = c.Long(),
                        COSTPNM = c.String(nullable: false),
                        COSTPSID = c.String(),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.CostPLID);
            
            CreateTable(
                "dbo.GL_MASTER",
                c => new
                    {
                        GL_MasterID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        TRANSTP = c.String(),
                        TRANSDT = c.DateTime(nullable: false),
                        TRANSMY = c.String(),
                        TRANSNO = c.Long(),
                        TRANSSL = c.Long(),
                        TRANSDRCR = c.String(),
                        TRANSFOR = c.String(),
                        TRANSMODE = c.String(),
                        COSTPID = c.Long(),
                        CREDITCD = c.Long(),
                        DEBITCD = c.Long(),
                        CHEQUENO = c.String(),
                        CHEQUEDT = c.DateTime(),
                        REMARKS = c.String(),
                        DEBITAMT = c.Decimal(precision: 18, scale: 2),
                        CREDITAMT = c.Decimal(precision: 18, scale: 2),
                        TABLEID = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.GL_MasterID);
            
            CreateTable(
                "dbo.GL_STRANS",
                c => new
                    {
                        Gl_StransID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        TRANSTP = c.String(),
                        TRANSDT = c.DateTime(nullable: false),
                        TRANSMY = c.String(),
                        TRANSNO = c.Long(),
                        TRANSFOR = c.String(nullable: false),
                        TRANSMODE = c.String(),
                        COSTPID = c.Long(),
                        CREDITCD = c.Long(),
                        DEBITCD = c.Long(),
                        CHEQUENO = c.String(),
                        CHEQUEDT = c.DateTime(),
                        REMARKS = c.String(),
                        AMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.Gl_StransID);
            
            CreateTable(
                "dbo.HML_BILL",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSMY = c.String(nullable: false, maxLength: 6),
                        TRANSNO = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        ROOMNO = c.Long(nullable: false),
                        REGNID = c.Long(nullable: false),
                        TOTAMT = c.Decimal(precision: 18, scale: 2),
                        SCHARGE = c.Decimal(precision: 18, scale: 2),
                        VATAMT = c.Decimal(precision: 18, scale: 2),
                        GROSSAMT = c.Decimal(precision: 18, scale: 2),
                        ADVAMT = c.Decimal(precision: 18, scale: 2),
                        DISCOUNT = c.Decimal(precision: 18, scale: 2),
                        NETAMT = c.Decimal(precision: 18, scale: 2),
                        PAIDAMT = c.Decimal(precision: 18, scale: 2),
                        BALAMT = c.Decimal(precision: 18, scale: 2),
                        DUEHID = c.Long(),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSMY, t.TRANSNO });
            
            CreateTable(
                "dbo.HML_BILLDTL",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSMY = c.String(nullable: false, maxLength: 6),
                        TRANSNO = c.Long(nullable: false),
                        BILLID = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        ROOMNO = c.Long(nullable: false),
                        REGNID = c.Long(nullable: false),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSMY, t.TRANSNO, t.BILLID });
            
            CreateTable(
                "dbo.HML_BILLHP",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        BILLID = c.Long(nullable: false),
                        BILLNM = c.String(maxLength: 100),
                        BILLRT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.BILLID });
            
            CreateTable(
                "dbo.HML_CITEM",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        CITEMID = c.Long(nullable: false),
                        CITEMNM = c.String(maxLength: 100),
                        DEFYN = c.String(maxLength: 3),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.CITEMID });
            
            CreateTable(
                "dbo.HML_FLOOR",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        FLOORID = c.Long(nullable: false),
                        FLOORNM = c.String(maxLength: 50),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.FLOORID });
            
            CreateTable(
                "dbo.HML_FLOORPLAN",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        FLOORID = c.Long(nullable: false),
                        RTPID = c.Long(nullable: false),
                        ROOMNO = c.Long(nullable: false),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.FLOORID, t.RTPID, t.ROOMNO });
            
            CreateTable(
                "dbo.HML_GUESTCO",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        GCOID = c.Long(nullable: false),
                        GCOGID = c.Long(nullable: false),
                        GCONM = c.String(maxLength: 100),
                        ADDRESS = c.String(maxLength: 100),
                        ORGCNO = c.String(maxLength: 50),
                        EMAILID = c.String(maxLength: 50),
                        CPNM = c.String(maxLength: 100),
                        CPPOST = c.String(maxLength: 50),
                        MOBNO1 = c.String(maxLength: 11),
                        MOBNO2 = c.String(maxLength: 11),
                        DISCRT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.GCOID });
            
            CreateTable(
                "dbo.HML_GUESTRF",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        GRFID = c.Long(nullable: false),
                        GRFGID = c.Long(nullable: false),
                        REFERNM = c.String(maxLength: 100),
                        ADDRESS = c.String(maxLength: 100),
                        MOBNO1 = c.String(maxLength: 11),
                        MOBNO2 = c.String(maxLength: 11),
                        EMAILID = c.String(maxLength: 50),
                        ORGNM = c.String(maxLength: 100),
                        POSTNM = c.String(maxLength: 100),
                        ORGCNO = c.String(maxLength: 50),
                        RFPCNT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.GRFID });
            
            CreateTable(
                "dbo.HML_REGNCI",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        REGNID = c.Long(nullable: false),
                        CITEMID = c.Long(nullable: false),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.REGNID, t.CITEMID });
            
            CreateTable(
                "dbo.HML_REGN",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        REGNYY = c.Long(nullable: false),
                        REGNID = c.Long(nullable: false),
                        REGNDT = c.DateTime(),
                        CHECKI = c.DateTime(),
                        GHECKO = c.DateTime(),
                        RESVYN = c.String(maxLength: 3),
                        RESVID = c.Long(),
                        GCOID = c.Long(),
                        CCYTP = c.String(maxLength: 4),
                        CCYCRT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RTPID = c.Long(nullable: false),
                        ROOMNO = c.Long(nullable: false),
                        ROOMRTO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DISCTP = c.String(maxLength: 10),
                        DISCRT = c.Decimal(precision: 18, scale: 2),
                        ROOMRTS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VISITPP = c.String(maxLength: 100),
                        VISITPRE = c.String(maxLength: 3),
                        DESTFR = c.String(maxLength: 100),
                        DESTTO = c.String(maxLength: 100),
                        GRFID = c.Long(),
                        ROOMNOL = c.Long(),
                        REGNIDL = c.Long(),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.REGNYY, t.REGNID });
            
            CreateTable(
                "dbo.HML_GUESTS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        REGNID = c.Long(nullable: false),
                        GUESTID = c.Long(nullable: false),
                        GUESTNM = c.String(nullable: false, maxLength: 100),
                        DOB = c.DateTime(),
                        GENDER = c.String(maxLength: 6),
                        ADDRESS = c.String(nullable: false, maxLength: 100),
                        CITY = c.String(maxLength: 50),
                        ZIPCODE = c.Long(),
                        COUNTRY = c.String(maxLength: 60),
                        NATIONALITY = c.String(nullable: false, maxLength: 60),
                        EMAILID = c.String(maxLength: 100),
                        TELNO = c.String(maxLength: 30),
                        MOBNO = c.String(nullable: false, maxLength: 30),
                        NIDNO = c.String(maxLength: 20),
                        DRLICNO = c.String(maxLength: 20),
                        VISANO = c.String(maxLength: 20),
                        VISAIDT = c.DateTime(),
                        VISAEDT = c.DateTime(),
                        PPNO = c.String(maxLength: 20),
                        PPIPLACE = c.String(maxLength: 50),
                        PPIDT = c.DateTime(),
                        PPEDT = c.DateTime(),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.REGNID, t.GUESTID });
            
            CreateTable(
                "dbo.HML_REGNPAY",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSMY = c.String(nullable: false, maxLength: 6),
                        TRANSNO = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        REGNID = c.Long(nullable: false),
                        TRFOR = c.String(maxLength: 8),
                        TRMODE = c.String(maxLength: 6),
                        CCYTP = c.String(maxLength: 4),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSMY, t.TRANSNO });
            
            CreateTable(
                "dbo.HML_RESERVE",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        RESVYY = c.Long(nullable: false),
                        RESVID = c.Long(nullable: false),
                        RESVDT = c.DateTime(),
                        CHECKI = c.DateTime(),
                        GHECKO = c.DateTime(),
                        ARRIVETM = c.String(),
                        RESVTP = c.String(maxLength: 10),
                        RESVMODE = c.String(maxLength: 8),
                        CPNM = c.String(maxLength: 100),
                        CPTELNO = c.String(maxLength: 30),
                        CPEMAIL = c.String(maxLength: 100),
                        CPMOBNO = c.String(maxLength: 11),
                        GUESTNM = c.String(maxLength: 100),
                        ADULTQP = c.Long(nullable: false),
                        CHILDQP = c.Long(nullable: false),
                        CCYTP = c.String(maxLength: 4),
                        GRFID = c.Long(),
                        RESVSTATS = c.String(maxLength: 7),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.RESVYY, t.RESVID });
            
            CreateTable(
                "dbo.HML_RESVPAY",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSMY = c.String(nullable: false, maxLength: 6),
                        TRANSNO = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        RESVID = c.Long(nullable: false),
                        TRMODE = c.String(maxLength: 6),
                        CCYTP = c.String(maxLength: 4),
                        AMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSMY, t.TRANSNO });
            
            CreateTable(
                "dbo.HML_RESVROOM",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        RESVID = c.Long(nullable: false),
                        RTPID = c.Long(nullable: false),
                        ROOMRTO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DISCTP = c.String(maxLength: 10),
                        DISCRT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ROOMRTS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ROOMQTY = c.Long(nullable: false),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.RESVID, t.RTPID });
            
            CreateTable(
                "dbo.HML_RESVCI",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        RESVID = c.Long(nullable: false),
                        CITEMID = c.Long(nullable: false),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.RESVID, t.CITEMID });
            
            CreateTable(
                "dbo.HML_ROOM",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        RTPID = c.Long(nullable: false),
                        ROOMNO = c.Long(nullable: false),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.RTPID, t.ROOMNO });
            
            CreateTable(
                "dbo.HML_ROOMSTATS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        ROOMNO = c.Long(nullable: false),
                        RSTATS = c.String(maxLength: 10),
                        CSTATS = c.String(maxLength: 10),
                        CLASTDT = c.String(),
                        CNEXTDT = c.String(),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.ROOMNO });
            
            CreateTable(
                "dbo.HML_ROOMTP",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        RTPID = c.Long(nullable: false),
                        RTPNM = c.String(maxLength: 100),
                        RATEBDT = c.Decimal(precision: 18, scale: 2),
                        RATEUSD = c.Decimal(precision: 18, scale: 2),
                        STATUS = c.String(maxLength: 1),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.RTPID });
            
            CreateTable(
                "dbo.HML_SERVICES",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSMY = c.String(nullable: false, maxLength: 6),
                        TRANSNO = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        GUESTTP = c.String(maxLength: 8),
                        ROOMNO = c.Long(nullable: false),
                        REGNID = c.Long(nullable: false),
                        BILLID = c.Long(nullable: false),
                        QTY = c.Long(),
                        RATE = c.Decimal(precision: 18, scale: 2),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(maxLength: 100),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSMY, t.TRANSNO });
            
            CreateTable(
                "dbo.STK_PS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        PSID = c.Long(nullable: false),
                        PSGRID = c.Long(nullable: false),
                        ADDRESS = c.String(maxLength: 100),
                        TELNO = c.String(maxLength: 20),
                        MOBNO = c.String(),
                        EMAIL = c.String(maxLength: 80),
                        WEBID = c.String(maxLength: 80),
                        CPNM = c.String(maxLength: 80),
                        CPCNO = c.String(maxLength: 11),
                        REMARKS = c.String(maxLength: 50),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.PSID });
            
            CreateTable(
                "dbo.ASL_SchedularCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        USERID = c.Long(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.COMPID, t.USERID });
            
            CreateTable(
                "dbo.ASL_PEMAIL",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSYY = c.Long(nullable: false),
                        TRANSNO = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        EMAILID = c.String(maxLength: 100),
                        EMAILSUBJECT = c.String(),
                        BODYMSG = c.String(),
                        STATUS = c.String(maxLength: 7),
                        SENTTM = c.DateTime(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSYY, t.TRANSNO });
            
            CreateTable(
                "dbo.ASL_PSMS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        TRANSYY = c.Long(nullable: false),
                        TRANSNO = c.Long(nullable: false),
                        TRANSDT = c.DateTime(),
                        MOBNO = c.String(maxLength: 13),
                        LANGUAGE = c.String(maxLength: 3),
                        MESSAGE = c.String(maxLength: 160),
                        STATUS = c.String(maxLength: 7),
                        SENTTM = c.DateTime(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.TRANSYY, t.TRANSNO });
            
            CreateTable(
                "dbo.STK_ITEM",
                c => new
                    {
                        STK_ITEM_ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        CATID = c.Long(),
                        ITEMID = c.Long(),
                        ITEMNM = c.String(),
                        BRAND = c.String(),
                        UNIT = c.String(),
                        BUYRT = c.Decimal(precision: 18, scale: 2),
                        SALRT = c.Decimal(precision: 18, scale: 2),
                        STKMIN = c.Decimal(precision: 18, scale: 2),
                        DISCRT = c.Decimal(precision: 18, scale: 2),
                        CPQTY = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.STK_ITEM_ID);
            
            CreateTable(
                "dbo.STK_ITEMMST",
                c => new
                    {
                        STK_ITEMMST_ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        CATID = c.Long(),
                        CATNM = c.String(),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.STK_ITEMMST_ID);
            
            CreateTable(
                "dbo.STK_STORE",
                c => new
                    {
                        STK_STORE_ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        STOREID = c.Long(),
                        STORENM = c.String(nullable: false),
                        STORESID = c.String(),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.STK_STORE_ID);
            
            CreateTable(
                "dbo.STK_TRANS",
                c => new
                    {
                        STK_TRANS_ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        TRANSTP = c.String(),
                        TRANSDT = c.DateTime(),
                        TRANSYY = c.Long(),
                        TRANSNO = c.Long(),
                        STOREFR = c.Long(),
                        STORETO = c.Long(),
                        PSID = c.Long(),
                        ITEMSL = c.Long(),
                        ITEMID = c.Long(),
                        QTY = c.Decimal(precision: 18, scale: 2),
                        RATE = c.Decimal(precision: 18, scale: 2),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        DISCRT = c.Decimal(precision: 18, scale: 2),
                        DISCAMT = c.Decimal(precision: 18, scale: 2),
                        GROSSAMT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.STK_TRANS_ID);
            
            CreateTable(
                "dbo.STK_TRANSMST",
                c => new
                    {
                        STK_TRANSMST_ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(),
                        TRANSTP = c.String(),
                        TRANSDT = c.DateTime(),
                        TRANSYY = c.Long(),
                        TRANSNO = c.Long(),
                        STOREFR = c.Long(),
                        STORETO = c.Long(),
                        PSID = c.Long(),
                        TOTAMT = c.Decimal(precision: 18, scale: 2),
                        DISCRTG = c.Decimal(precision: 18, scale: 2),
                        DISCAMTG = c.Decimal(precision: 18, scale: 2),
                        TOTGROSS = c.Decimal(precision: 18, scale: 2),
                        VATRT = c.Decimal(precision: 18, scale: 2),
                        VATAMT = c.Decimal(precision: 18, scale: 2),
                        OTCAMT = c.Decimal(precision: 18, scale: 2),
                        TOTNET = c.Decimal(precision: 18, scale: 2),
                        CASHAMT = c.Decimal(precision: 18, scale: 2),
                        CREDITAMT = c.Decimal(precision: 18, scale: 2),
                        REMARKS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => t.STK_TRANSMST_ID);
            
            CreateTable(
                "dbo.ASL_PCONTACTS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        GROUPID = c.Long(nullable: false),
                        NAME = c.String(),
                        EMAIL = c.String(),
                        MOBNO1 = c.String(),
                        MOBNO2 = c.String(),
                        ADDRESS = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID });
            
            CreateTable(
                "dbo.ASL_PGROUPS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        COMPID = c.Long(nullable: false),
                        GROUPID = c.Long(nullable: false),
                        GROUPNM = c.String(),
                        USERPC = c.String(),
                        INSUSERID = c.Long(nullable: false),
                        INSTIME = c.DateTime(),
                        INSIPNO = c.String(),
                        INSLTUDE = c.String(),
                        UPDUSERID = c.Long(nullable: false),
                        UPDTIME = c.DateTime(),
                        UPDIPNO = c.String(),
                        UPDLTUDE = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.COMPID, t.GROUPID });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ASL_PGROUPS");
            DropTable("dbo.ASL_PCONTACTS");
            DropTable("dbo.STK_TRANSMST");
            DropTable("dbo.STK_TRANS");
            DropTable("dbo.STK_STORE");
            DropTable("dbo.STK_ITEMMST");
            DropTable("dbo.STK_ITEM");
            DropTable("dbo.ASL_PSMS");
            DropTable("dbo.ASL_PEMAIL");
            DropTable("dbo.ASL_SchedularCalendar");
            DropTable("dbo.STK_PS");
            DropTable("dbo.HML_SERVICES");
            DropTable("dbo.HML_ROOMTP");
            DropTable("dbo.HML_ROOMSTATS");
            DropTable("dbo.HML_ROOM");
            DropTable("dbo.HML_RESVCI");
            DropTable("dbo.HML_RESVROOM");
            DropTable("dbo.HML_RESVPAY");
            DropTable("dbo.HML_RESERVE");
            DropTable("dbo.HML_REGNPAY");
            DropTable("dbo.HML_GUESTS");
            DropTable("dbo.HML_REGN");
            DropTable("dbo.HML_REGNCI");
            DropTable("dbo.HML_GUESTRF");
            DropTable("dbo.HML_GUESTCO");
            DropTable("dbo.HML_FLOORPLAN");
            DropTable("dbo.HML_FLOOR");
            DropTable("dbo.HML_CITEM");
            DropTable("dbo.HML_BILLHP");
            DropTable("dbo.HML_BILLDTL");
            DropTable("dbo.HML_BILL");
            DropTable("dbo.GL_STRANS");
            DropTable("dbo.GL_MASTER");
            DropTable("dbo.GL_COSTPOOL");
            DropTable("dbo.GL_COSTPMST");
            DropTable("dbo.GL_ACCHART");
            DropTable("dbo.GL_ACCHARMST");
            DropTable("dbo.ASL_PCalendarImage");
            DropTable("dbo.ASL_CALENDAR");
            DropTable("dbo.AslUsercoes");
            DropTable("dbo.ASL_ROLE");
            DropTable("dbo.ASL_MENUMST");
            DropTable("dbo.ASL_MENU");
            DropTable("dbo.ASL_LOG");
            DropTable("dbo.ASL_DELETE");
            DropTable("dbo.AslCompanies");
        }
    }
}
