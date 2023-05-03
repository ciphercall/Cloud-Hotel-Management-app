USE [asl_CloudHML]
GO
/****** Object:  User [cloudHml]    Script Date: 2/15/2017 4:09:22 PM ******/
CREATE USER [cloudHml] FOR LOGIN [cloudHml] WITH DEFAULT_SCHEMA=[cloudHml]
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'cloudHml'
GO
/****** Object:  Schema [cloudHml]    Script Date: 2/15/2017 4:09:25 PM ******/
CREATE SCHEMA [cloudHml]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/15/2017 4:09:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ASL_CALENDAR]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_CALENDAR](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[USERID] [bigint] NULL,
	[text] [nvarchar](max) NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
 CONSTRAINT [PK_dbo.ASL_CALENDAR] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_DELETE]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_DELETE](
	[Asl_DeleteID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[USERID] [bigint] NULL,
	[DELSLNO] [bigint] NULL,
	[DELDATE] [nvarchar](max) NULL,
	[DELTIME] [nvarchar](max) NULL,
	[DELIPNO] [nvarchar](max) NULL,
	[DELLTUDE] [nvarchar](max) NULL,
	[TABLEID] [nvarchar](max) NULL,
	[DELDATA] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_DELETE] PRIMARY KEY CLUSTERED 
(
	[Asl_DeleteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_LOG]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_LOG](
	[Asl_LOGid] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[USERID] [bigint] NULL,
	[LOGTYPE] [nvarchar](max) NULL,
	[LOGSLNO] [bigint] NULL,
	[LOGDATE] [datetime] NULL,
	[LOGTIME] [nvarchar](max) NULL,
	[LOGIPNO] [nvarchar](max) NULL,
	[LOGLTUDE] [nvarchar](max) NULL,
	[TABLEID] [nvarchar](max) NULL,
	[LOGDATA] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_LOG] PRIMARY KEY CLUSTERED 
(
	[Asl_LOGid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_MENU]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_MENU](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MODULEID] [nvarchar](max) NULL,
	[MENUTP] [nvarchar](max) NULL,
	[MENUID] [nvarchar](max) NULL,
	[MENUNM] [nvarchar](max) NULL,
	[ACTIONNAME] [nvarchar](max) NULL,
	[CONTROLLERNAME] [nvarchar](max) NULL,
	[SERIAL] [bigint] NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_MENU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_MENUMST]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_MENUMST](
	[MODULEID] [nvarchar](128) NOT NULL,
	[MODULENM] [nvarchar](max) NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_MENUMST] PRIMARY KEY CLUSTERED 
(
	[MODULEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_PCalendarImage]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_PCalendarImage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Year] [bigint] NOT NULL,
	[Month] [nvarchar](128) NOT NULL,
	[FilePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_PCalendarImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Year] ASC,
	[Month] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_PCONTACTS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_PCONTACTS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[GROUPID] [bigint] NOT NULL,
	[NAME] [nvarchar](max) NULL,
	[EMAIL] [nvarchar](max) NULL,
	[MOBNO1] [nvarchar](max) NULL,
	[MOBNO2] [nvarchar](max) NULL,
	[ADDRESS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_PCONTACTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_PEMAIL]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_PEMAIL](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSYY] [bigint] NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[EMAILID] [nvarchar](100) NULL,
	[EMAILSUBJECT] [nvarchar](max) NULL,
	[BODYMSG] [nvarchar](max) NULL,
	[STATUS] [nvarchar](7) NULL,
	[SENTTM] [datetime] NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_PEMAIL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSYY] ASC,
	[TRANSNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_PGROUPS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_PGROUPS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[GROUPID] [bigint] NOT NULL,
	[GROUPNM] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_PGROUPS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[GROUPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_PSMS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_PSMS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSYY] [bigint] NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[MOBNO] [nvarchar](13) NULL,
	[LANGUAGE] [nvarchar](3) NULL,
	[MESSAGE] [nvarchar](160) NULL,
	[STATUS] [nvarchar](7) NULL,
	[SENTTM] [datetime] NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_PSMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSYY] ASC,
	[TRANSNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_ROLE]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_ROLE](
	[ASL_ROLEId] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[USERID] [bigint] NOT NULL,
	[MODULEID] [nvarchar](max) NOT NULL,
	[MENUTP] [nvarchar](max) NOT NULL,
	[MENUID] [nvarchar](max) NULL,
	[SERIAL] [bigint] NOT NULL,
	[STATUS] [nvarchar](max) NULL,
	[INSERTR] [nvarchar](max) NULL,
	[UPDATER] [nvarchar](max) NULL,
	[DELETER] [nvarchar](max) NULL,
	[MENUNAME] [nvarchar](max) NULL,
	[ACTIONNAME] [nvarchar](max) NULL,
	[CONTROLLERNAME] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_ROLE] PRIMARY KEY CLUSTERED 
(
	[ASL_ROLEId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ASL_SchedularCalendar]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASL_SchedularCalendar](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[USERID] [bigint] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ASL_SchedularCalendar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[COMPID] ASC,
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AslCompanies]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AslCompanies](
	[AslCompanyId] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[COMPNM] [nvarchar](max) NOT NULL,
	[ADDRESS] [nvarchar](max) NOT NULL,
	[ADDRESS2] [nvarchar](max) NULL,
	[CONTACTNO] [nvarchar](max) NOT NULL,
	[EMAILID] [nvarchar](max) NOT NULL,
	[WEBID] [nvarchar](max) NULL,
	[STATUS] [nvarchar](max) NOT NULL,
	[EMAILIDP] [nvarchar](max) NULL,
	[EMAILPWP] [nvarchar](max) NULL,
	[SMSIDP] [nvarchar](max) NULL,
	[SMSPWP] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AslCompanies] PRIMARY KEY CLUSTERED 
(
	[AslCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AslUsercoes]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AslUsercoes](
	[AslUsercoId] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[USERID] [bigint] NULL,
	[USERNM] [nvarchar](max) NOT NULL,
	[DEPTNM] [nvarchar](max) NULL,
	[OPTP] [nvarchar](max) NOT NULL,
	[ADDRESS] [nvarchar](max) NOT NULL,
	[MOBNO] [nvarchar](max) NOT NULL,
	[EMAILID] [nvarchar](max) NULL,
	[LOGINBY] [nvarchar](max) NOT NULL,
	[LOGINID] [nvarchar](max) NOT NULL,
	[LOGINPW] [nvarchar](max) NOT NULL,
	[TIMEFR] [nvarchar](max) NOT NULL,
	[TIMETO] [nvarchar](max) NOT NULL,
	[STATUS] [nvarchar](max) NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AslUsercoes] PRIMARY KEY CLUSTERED 
(
	[AslUsercoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GL_ACCHARMST]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GL_ACCHARMST](
	[ACCHARMSTId] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[HEADTP] [int] NOT NULL,
	[HEADCD] [bigint] NULL,
	[HEADNM] [nvarchar](max) NOT NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GL_ACCHARMST] PRIMARY KEY CLUSTERED 
(
	[ACCHARMSTId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GL_ACCHART]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GL_ACCHART](
	[ACCHARTId] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[HEADTP] [int] NOT NULL,
	[HEADCD] [bigint] NULL,
	[ACCOUNTCD] [bigint] NULL,
	[ACCOUNTNM] [nvarchar](max) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GL_ACCHART] PRIMARY KEY CLUSTERED 
(
	[ACCHARTId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GL_COSTPMST]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GL_COSTPMST](
	[CostMstID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[COSTCID] [bigint] NULL,
	[COSTCNM] [nvarchar](max) NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GL_COSTPMST] PRIMARY KEY CLUSTERED 
(
	[CostMstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GL_COSTPOOL]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GL_COSTPOOL](
	[CostPLID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[COSTCID] [bigint] NULL,
	[COSTPID] [bigint] NULL,
	[COSTPNM] [nvarchar](max) NOT NULL,
	[COSTPSID] [nvarchar](max) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GL_COSTPOOL] PRIMARY KEY CLUSTERED 
(
	[CostPLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GL_MASTER]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GL_MASTER](
	[GL_MasterID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[TRANSTP] [nvarchar](max) NULL,
	[TRANSDT] [datetime] NOT NULL,
	[TRANSMY] [nvarchar](max) NULL,
	[TRANSNO] [bigint] NULL,
	[TRANSSL] [bigint] NULL,
	[TRANSDRCR] [nvarchar](max) NULL,
	[TRANSFOR] [nvarchar](max) NULL,
	[TRANSMODE] [nvarchar](max) NULL,
	[COSTPID] [bigint] NULL,
	[CREDITCD] [bigint] NULL,
	[DEBITCD] [bigint] NULL,
	[CHEQUENO] [nvarchar](max) NULL,
	[CHEQUEDT] [datetime] NULL,
	[REMARKS] [nvarchar](max) NULL,
	[DEBITAMT] [decimal](18, 2) NULL,
	[CREDITAMT] [decimal](18, 2) NULL,
	[TABLEID] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GL_MASTER] PRIMARY KEY CLUSTERED 
(
	[GL_MasterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GL_STRANS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GL_STRANS](
	[Gl_StransID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[TRANSTP] [nvarchar](max) NULL,
	[TRANSDT] [datetime] NOT NULL,
	[TRANSMY] [nvarchar](max) NULL,
	[TRANSNO] [bigint] NULL,
	[TRANSFOR] [nvarchar](max) NOT NULL,
	[TRANSMODE] [nvarchar](max) NULL,
	[COSTPID] [bigint] NULL,
	[CREDITCD] [bigint] NULL,
	[DEBITCD] [bigint] NULL,
	[CHEQUENO] [nvarchar](max) NULL,
	[CHEQUEDT] [datetime] NULL,
	[REMARKS] [nvarchar](max) NULL,
	[AMOUNT] [decimal](18, 2) NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GL_STRANS] PRIMARY KEY CLUSTERED 
(
	[Gl_StransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_BILL]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_BILL](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSMY] [nvarchar](6) NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[ROOMNO] [bigint] NOT NULL,
	[REGNID] [bigint] NOT NULL,
	[TOTAMT] [decimal](18, 2) NULL,
	[SCHARGE] [decimal](18, 2) NULL,
	[VATAMT] [decimal](18, 2) NULL,
	[GROSSAMT] [decimal](18, 2) NULL,
	[ADVAMT] [decimal](18, 2) NULL,
	[DISCOUNT] [decimal](18, 2) NULL,
	[NETAMT] [decimal](18, 2) NULL,
	[PAIDAMT] [decimal](18, 2) NULL,
	[BALAMT] [decimal](18, 2) NULL,
	[DUEHID] [bigint] NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_BILL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSMY] ASC,
	[TRANSNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_BILLDTL]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_BILLDTL](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSMY] [nvarchar](6) NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[BILLID] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[ROOMNO] [bigint] NOT NULL,
	[REGNID] [bigint] NOT NULL,
	[AMOUNT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_BILLDTL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSMY] ASC,
	[TRANSNO] ASC,
	[BILLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_BILLHP]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_BILLHP](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[BILLID] [bigint] NOT NULL,
	[BILLNM] [nvarchar](100) NULL,
	[BILLRT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_BILLHP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[BILLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_CITEM]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_CITEM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[CITEMID] [bigint] NOT NULL,
	[CITEMNM] [nvarchar](100) NULL,
	[DEFYN] [nvarchar](3) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_CITEM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[CITEMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_FLOOR]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_FLOOR](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[FLOORID] [bigint] NOT NULL,
	[FLOORNM] [nvarchar](50) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_FLOOR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[FLOORID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_FLOORPLAN]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_FLOORPLAN](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[FLOORID] [bigint] NOT NULL,
	[RTPID] [bigint] NOT NULL,
	[ROOMNO] [bigint] NOT NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_FLOORPLAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[FLOORID] ASC,
	[RTPID] ASC,
	[ROOMNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_GUESTCO]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_GUESTCO](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[GCOID] [bigint] NOT NULL,
	[GCOGID] [bigint] NOT NULL,
	[GCONM] [nvarchar](100) NULL,
	[ADDRESS] [nvarchar](100) NULL,
	[ORGCNO] [nvarchar](50) NULL,
	[EMAILID] [nvarchar](50) NULL,
	[CPNM] [nvarchar](100) NULL,
	[CPPOST] [nvarchar](50) NULL,
	[MOBNO1] [nvarchar](11) NULL,
	[MOBNO2] [nvarchar](11) NULL,
	[DISCRT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_GUESTCO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[GCOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_GUESTRF]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_GUESTRF](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[GRFID] [bigint] NOT NULL,
	[GRFGID] [bigint] NOT NULL,
	[REFERNM] [nvarchar](100) NULL,
	[ADDRESS] [nvarchar](100) NULL,
	[MOBNO1] [nvarchar](11) NULL,
	[MOBNO2] [nvarchar](11) NULL,
	[EMAILID] [nvarchar](50) NULL,
	[ORGNM] [nvarchar](100) NULL,
	[POSTNM] [nvarchar](100) NULL,
	[ORGCNO] [nvarchar](50) NULL,
	[RFPCNT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_GUESTRF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[GRFID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_GUESTS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_GUESTS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[REGNID] [bigint] NOT NULL,
	[GUESTID] [bigint] NOT NULL,
	[GUESTNM] [nvarchar](100) NOT NULL,
	[DOB] [datetime] NULL,
	[GENDER] [nvarchar](6) NULL,
	[ADDRESS] [nvarchar](100) NOT NULL,
	[CITY] [nvarchar](50) NULL,
	[ZIPCODE] [bigint] NULL,
	[COUNTRY] [nvarchar](60) NULL,
	[NATIONALITY] [nvarchar](60) NOT NULL,
	[EMAILID] [nvarchar](100) NULL,
	[TELNO] [nvarchar](30) NULL,
	[MOBNO] [nvarchar](30) NOT NULL,
	[NIDNO] [nvarchar](20) NULL,
	[DRLICNO] [nvarchar](20) NULL,
	[VISANO] [nvarchar](20) NULL,
	[VISAIDT] [datetime] NULL,
	[VISAEDT] [datetime] NULL,
	[PPNO] [nvarchar](20) NULL,
	[PPIPLACE] [nvarchar](50) NULL,
	[PPIDT] [datetime] NULL,
	[PPEDT] [datetime] NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_GUESTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[REGNID] ASC,
	[GUESTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_REGN]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_REGN](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[REGNYY] [bigint] NOT NULL,
	[REGNID] [bigint] NOT NULL,
	[REGNDT] [datetime] NULL,
	[CHECKI] [datetime] NULL,
	[GHECKO] [datetime] NULL,
	[RESVYN] [nvarchar](3) NULL,
	[RESVID] [bigint] NULL,
	[GCOID] [bigint] NULL,
	[CCYTP] [nvarchar](4) NULL,
	[CCYCRT] [decimal](18, 2) NOT NULL,
	[RTPID] [bigint] NOT NULL,
	[ROOMNO] [bigint] NOT NULL,
	[ROOMRTO] [decimal](18, 2) NOT NULL,
	[DISCTP] [nvarchar](10) NULL,
	[DISCRT] [decimal](18, 2) NULL,
	[ROOMRTS] [decimal](18, 2) NOT NULL,
	[VISITPP] [nvarchar](100) NULL,
	[VISITPRE] [nvarchar](3) NULL,
	[DESTFR] [nvarchar](100) NULL,
	[DESTTO] [nvarchar](100) NULL,
	[GRFID] [bigint] NULL,
	[ROOMNOL] [bigint] NULL,
	[REGNIDL] [bigint] NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_REGN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[REGNYY] ASC,
	[REGNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_REGNCI]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_REGNCI](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[REGNID] [bigint] NOT NULL,
	[CITEMID] [bigint] NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_REGNCI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[REGNID] ASC,
	[CITEMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_REGNPAY]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_REGNPAY](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSMY] [nvarchar](6) NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[REGNID] [bigint] NOT NULL,
	[TRFOR] [nvarchar](8) NULL,
	[TRMODE] [nvarchar](6) NULL,
	[CCYTP] [nvarchar](4) NULL,
	[AMOUNT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_REGNPAY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSMY] ASC,
	[TRANSNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_RESERVE]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_RESERVE](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[RESVYY] [bigint] NOT NULL,
	[RESVID] [bigint] NOT NULL,
	[RESVDT] [datetime] NULL,
	[CHECKI] [datetime] NULL,
	[GHECKO] [datetime] NULL,
	[ARRIVETM] [nvarchar](max) NULL,
	[RESVTP] [nvarchar](10) NULL,
	[RESVMODE] [nvarchar](8) NULL,
	[CPNM] [nvarchar](100) NULL,
	[CPTELNO] [nvarchar](30) NULL,
	[CPEMAIL] [nvarchar](100) NULL,
	[CPMOBNO] [nvarchar](11) NULL,
	[GUESTNM] [nvarchar](100) NULL,
	[ADULTQP] [bigint] NOT NULL,
	[CHILDQP] [bigint] NOT NULL,
	[CCYTP] [nvarchar](4) NULL,
	[GRFID] [bigint] NULL,
	[RESVSTATS] [nvarchar](7) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_RESERVE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[RESVYY] ASC,
	[RESVID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_RESVCI]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_RESVCI](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[RESVID] [bigint] NOT NULL,
	[CITEMID] [bigint] NOT NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_RESVCI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[RESVID] ASC,
	[CITEMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_RESVPAY]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_RESVPAY](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSMY] [nvarchar](6) NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[RESVID] [bigint] NOT NULL,
	[TRMODE] [nvarchar](6) NULL,
	[CCYTP] [nvarchar](4) NULL,
	[AMOUNT] [decimal](18, 2) NOT NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_RESVPAY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSMY] ASC,
	[TRANSNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_RESVROOM]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_RESVROOM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[RESVID] [bigint] NOT NULL,
	[RTPID] [bigint] NOT NULL,
	[ROOMRTO] [decimal](18, 2) NOT NULL,
	[DISCTP] [nvarchar](10) NULL,
	[DISCRT] [decimal](18, 2) NOT NULL,
	[ROOMRTS] [decimal](18, 2) NOT NULL,
	[ROOMQTY] [bigint] NOT NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_RESVROOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[RESVID] ASC,
	[RTPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_ROOM]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_ROOM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[RTPID] [bigint] NOT NULL,
	[ROOMNO] [bigint] NOT NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_ROOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[RTPID] ASC,
	[ROOMNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_ROOMSTATS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_ROOMSTATS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[ROOMNO] [bigint] NOT NULL,
	[RSTATS] [nvarchar](10) NULL,
	[CSTATS] [nvarchar](10) NULL,
	[CLASTDT] [nvarchar](max) NULL,
	[CNEXTDT] [nvarchar](max) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_ROOMSTATS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[ROOMNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_ROOMTP]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_ROOMTP](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[RTPID] [bigint] NOT NULL,
	[RTPNM] [nvarchar](100) NULL,
	[RATEBDT] [decimal](18, 2) NULL,
	[RATEUSD] [decimal](18, 2) NULL,
	[STATUS] [nvarchar](1) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_ROOMTP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[RTPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HML_SERVICES]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HML_SERVICES](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[TRANSMY] [nvarchar](6) NOT NULL,
	[TRANSNO] [bigint] NOT NULL,
	[TRANSDT] [datetime] NULL,
	[GUESTTP] [nvarchar](8) NULL,
	[ROOMNO] [bigint] NOT NULL,
	[REGNID] [bigint] NOT NULL,
	[BILLID] [bigint] NOT NULL,
	[QTY] [bigint] NULL,
	[RATE] [decimal](18, 2) NULL,
	[AMOUNT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](100) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HML_SERVICES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[TRANSMY] ASC,
	[TRANSNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STK_ITEM]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STK_ITEM](
	[STK_ITEM_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[CATID] [bigint] NULL,
	[ITEMID] [bigint] NULL,
	[ITEMNM] [nvarchar](max) NULL,
	[BRAND] [nvarchar](max) NULL,
	[UNIT] [nvarchar](max) NULL,
	[BUYRT] [decimal](18, 2) NULL,
	[SALRT] [decimal](18, 2) NULL,
	[STKMIN] [decimal](18, 2) NULL,
	[DISCRT] [decimal](18, 2) NULL,
	[CPQTY] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.STK_ITEM] PRIMARY KEY CLUSTERED 
(
	[STK_ITEM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STK_ITEMMST]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STK_ITEMMST](
	[STK_ITEMMST_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[CATID] [bigint] NULL,
	[CATNM] [nvarchar](max) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.STK_ITEMMST] PRIMARY KEY CLUSTERED 
(
	[STK_ITEMMST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STK_PS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STK_PS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NOT NULL,
	[PSID] [bigint] NOT NULL,
	[PSGRID] [bigint] NOT NULL,
	[ADDRESS] [nvarchar](100) NULL,
	[TELNO] [nvarchar](20) NULL,
	[MOBNO] [nvarchar](max) NULL,
	[EMAIL] [nvarchar](80) NULL,
	[WEBID] [nvarchar](80) NULL,
	[CPNM] [nvarchar](80) NULL,
	[CPCNO] [nvarchar](11) NULL,
	[REMARKS] [nvarchar](50) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NOT NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NOT NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.STK_PS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[COMPID] ASC,
	[PSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STK_STORE]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STK_STORE](
	[STK_STORE_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[STOREID] [bigint] NULL,
	[STORENM] [nvarchar](max) NOT NULL,
	[STORESID] [nvarchar](max) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.STK_STORE] PRIMARY KEY CLUSTERED 
(
	[STK_STORE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STK_TRANS]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STK_TRANS](
	[STK_TRANS_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[TRANSTP] [nvarchar](max) NULL,
	[TRANSDT] [datetime] NULL,
	[TRANSYY] [bigint] NULL,
	[TRANSNO] [bigint] NULL,
	[STOREFR] [bigint] NULL,
	[STORETO] [bigint] NULL,
	[PSID] [bigint] NULL,
	[ITEMSL] [bigint] NULL,
	[ITEMID] [bigint] NULL,
	[QTY] [decimal](18, 2) NULL,
	[RATE] [decimal](18, 2) NULL,
	[AMOUNT] [decimal](18, 2) NULL,
	[DISCRT] [decimal](18, 2) NULL,
	[DISCAMT] [decimal](18, 2) NULL,
	[GROSSAMT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.STK_TRANS] PRIMARY KEY CLUSTERED 
(
	[STK_TRANS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STK_TRANSMST]    Script Date: 2/15/2017 4:09:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STK_TRANSMST](
	[STK_TRANSMST_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[COMPID] [bigint] NULL,
	[TRANSTP] [nvarchar](max) NULL,
	[TRANSDT] [datetime] NULL,
	[TRANSYY] [bigint] NULL,
	[TRANSNO] [bigint] NULL,
	[STOREFR] [bigint] NULL,
	[STORETO] [bigint] NULL,
	[PSID] [bigint] NULL,
	[TOTAMT] [decimal](18, 2) NULL,
	[DISCRTG] [decimal](18, 2) NULL,
	[DISCAMTG] [decimal](18, 2) NULL,
	[TOTGROSS] [decimal](18, 2) NULL,
	[VATRT] [decimal](18, 2) NULL,
	[VATAMT] [decimal](18, 2) NULL,
	[OTCAMT] [decimal](18, 2) NULL,
	[TOTNET] [decimal](18, 2) NULL,
	[CASHAMT] [decimal](18, 2) NULL,
	[CREDITAMT] [decimal](18, 2) NULL,
	[REMARKS] [nvarchar](max) NULL,
	[USERPC] [nvarchar](max) NULL,
	[INSUSERID] [bigint] NULL,
	[INSTIME] [datetime] NULL,
	[INSIPNO] [nvarchar](max) NULL,
	[INSLTUDE] [nvarchar](max) NULL,
	[UPDUSERID] [bigint] NULL,
	[UPDTIME] [datetime] NULL,
	[UPDIPNO] [nvarchar](max) NULL,
	[UPDLTUDE] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.STK_TRANSMST] PRIMARY KEY CLUSTERED 
(
	[STK_TRANSMST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201702150825457_InitialCreate', N'AS_CLOUD_HOTEL.Migrations.Configuration', 0x1F8B0800000000000400ED7DDD72E33A92E6FD46EC3B387CB57B31E5B24F4F4FF589AA99A0494A561725F29094ABDD370E96C5AA52B47E3C127DA2EAD9F6621F695F6101F057FC05C0244549796727892F0108FC32910012FFEFFFFCDF8FFFF573BDBAFAD3DFED97DBCDA7EBDB77EFAFAFFCCDCB76B1DC7CFF74FD167CFBB70FD7FFF59FFFF37F7CD417EB9F578FF17BBFD1F748C9CDFED3F58F2078FDFDE666FFF2C35F7BFB77EBE5CB6EBBDF7E0BDEBD6CD737DE627B73F7FEFDDF6E6E6F6F7C02714DB0AEAE3EDA6F9B60B9F6D93FE45F75BB79F15F83376F35DD2EFCD53E9293270E43BD9A796B7FFFEABDF89FAE15E75935CCB9F6FC60BABAF12E2C707DA5AC961EA98CE3AFBE5D5F799BCD36F00252D5DFE77BDF0976DBCD77E79508BC95FBEBD527EF7DF3567B3F6AC2EFE9EBBCAD797F475B73931694EA8DEBA49DA4A53AE991E017AD1E6B2D69E87EA56ED7AFDEE657F63DF2E667FFD7818088ACDDF6D5DF05BF6CFF5BA1F464717D75738870938748004A4BD34A7DBA9E6C82BFFEE5FA6AF6B65A795F577ED28799CE7682EDCE1FFB1B7FE705FEC2F282C0DF913E9D2C7CD6B8423D725A55736A4DB49CBEE622B3695C84FCD264DC5E5F4DBD9F86BFF91EFCF8744DFEBCBE1A2D7FFA8B5812557BBE5992614E0A05BB37BFA459F57A154DB375C7399AE23B00CD4D3D3B7315D59D99FDB7519F2A13231D08FD29FEA2DF83A8ADD7E2B88A3B3FC2D089BAD5EABC814C91F5A57B45CED4E9A33D444D1FAD993BBA6DA99DAB99CC1CAA49906849297732D5E3321A21789758708E62130B84431AF518EE5CD3BBFF912C4DA2F7482999DE23C57AE93DA2A78BDEFB78933A35F5AE8E633C6BBAA1BBBAA4ABF3ACF92B3FF0E9AF22E1EA644A0FD8D5911876A44F1D231D3FBC6534C5EDFE43227AB29F44977A7AF986889E7E18C855EE0DBD0737251C08CA699A3D21EA31CCB12CEF90A24BB9F9555CF4BC188734CA7DB2BAFF08881E61662365B2CCC66B846993FA202AA2A717A2227ACE8BA8C2DFF512886AAACFE6324C251302EA33F03335B5792F438576A0DBFD4C8EAAE9A93520C1AF869093EA4ECCD94CE9810369D0C9360D43B77B5147ED9B62348D739CB5E3641A8EBFA78E2B43E129458A123907B9DEDE7DE822E0186A3E46781E3F4AFC28793F4A626FE4C24E5159A9F5B54CD9A34E0025BEABB61880CE9EA86628EF4F426F1FEB4A00DE0CD8DA542397E9B66BF7C16564C6DFBD9E3078DDBD1EE6F1F7E1199FAFCF8FAE01BA065CAEC17E35DFFBBB97AD6468382C2CB9F9262D7C5EE1615AE418F3014DB7DC1E2225A6750CF7E2687B91A6E6FD696F0F6A0EC8CFEE9FFA6F20537C0C079929B6BEF4AF98DA871184FB24A1D73DC2103ED616B0233B3F82B51DB83774F43D47A23FFE90FCB0616E425215439F698A2DE3F3C9EC03E873038084BB16F83F83CE7FF77DE0ED82E7056993E8C8F4370B8E724203C052BD1581F57693B5F7DD87596B2D7DEDC9F7765C2F4EB79BE0C7B0976FC3B6B48A09868DEC7B8162B45CF9A4B5759A3BA59CB1F1ACA8EA83624B2E0A2585A5A699D9C2039E663EE88A964EAB4891DFEE847F688AA18AAB3DC654D526D31BFB73F721588C839DB0E7878E1E04EBB6E0DC168C8B7C5BD539E67CE6CA95EA21B687BC8CBC8CBCDC312FABA6E35A92CEB0BADD07D37D20B3452A5374C0C44C3B479529833BB090C6AABE78A4B1AE68CC340D591AB30C5916B38C332531193D47C90CC1143B3D2C4FA2438A4C8E4CDE31934F1587EEEB93E0715AD8DB133E95A1F283C2036673D756C807D8FD812AA647738B035574BD9FE24C21B67470E8113C9ECACA38F9FDBB3CFD62ABDDEF3C659A46664F8AA6660F9C29E556D8BA36110D5269FABD7019F541FF63AEF740B2A1A2B26F6B18EE07EB3C659AD6CF7F59AEBDD5F595B5237F4569EB3E5C5F392F1EA5813BBE5F1010B0AF63CEE887A11F76B17E98C3CC82941FB67A26F5F5367B293F2C5B18FDB0CBF1C3603C1DA95E41D7075D9F6871734AD736F9FD140CD1A343810E058743F130359EEF2786547CBEE8469487F12323CEF16A620C79DFA5BF90F07ED0633B30E01EC25F3B33C10587410644C2AC98E6B4AD6A5B1FCF5A77BD09393D76E89EA7B10E05F7A840566E6C9B8E0388A7688F8068DAC451C53C807ABC990ED9779632D100E1EE1503B2EBE6FA83A0CD6CF6EA6EDFBF3FFD380E9EC1C23358757A06E19869EEF9F866A5EFD246CA04A4D08DEBCF8D8B7FA30B76054523106861D1C2A2853D050BFB600DC3C05E8A2184302614A3764B230C7D523536927EC5B843D247D23F45D25727AE3E1D06E7B3AA5C02E9270D6D0DD203ED6BFAE86956A3E5372469246924E94E497A6498A6D46E7378926655B904924E1ADA1AA496A4FF1D82A3D199AE80419E469EEE9BA72D43990D9AAB4BDFB55D5ED438088D068027DA5EB29F52140224E88F06020D44E5AF8606A22703319EEB8EAB9AC3300F63D5BC04473E6A664B883100460FD19AE6A4EF307A4C7BACD67EB320F39AE694EE206AD4FA8C10303DA65A96E9B85D3785E5DEBFAD6BCC2D9496BBAEB5D07D8EB8E054C5C2E802A10B74B22E903D1A880B648F2EC2050A9BD912A2B50B64EBA3867B7E4ECB093A2763DB93AB45FCC61E0600F5B47A50D38F136C8F2C15375B563131BA41E8069DA21B44B761AB93617841F19670DCA393E5C9F6DBE441F6F9209122912291327125910E87469FF8CE849533EE79B2E8D3D3F1999862881FB7521F74F5F344B4D4989632454B9109EB63E7FB2CA912C1E3CF65AB270DBDA63ED5A69CFA0B44305D7D120A0D9FE8AA3DC1B0D37B48C19B4903ECB53FD52DC80662D8303EEB13A7B33E799C3813D7AAEF14885E09F5D875A613E28BD774C7ADBD41176A93B8E3D65E980BA3A62C8EC9F3198A65CF0D0D8E68190CABE06CA0F257C3D9409FAB4B5209418F1A5661D5BE940941EBA5A8B8B35A8380AC11883A5DE6BDF08C429F697A9D11E74B96D1D7A2997894AC2E1108C81ACA3F27969A49A0CA7955CC7CE6DAB5394A20AA3653DC8939538CFA5EE05425D8F5CD8B7E305E8BAB1BB5F6E737B0D5D8F64A04BB90B059ADD63B10F7DA3626F52B8D206AC89C44E947CB443C18438B4924E5B5EA3D1F901659D6C43214B5CEF1016131A247A6033A49658CD3199CCEE074A68FC50D4B791AC67C06131297609C72263BD92C7410C984EDFAAB143E80DCF2D0706902C4B4A98FD50E4CB787B61D6DFBF9D976D2CF8FFA306C3B5B7EE6DDBB102E229FBB658FBBA42D06443D86BD7741B1EDC9A3EE42DCAADCDC15DD2F58532D0D9E03847BD2D3A9C35E626FAAC542893D34A729CA077218026E71A029E63E37DC3FAC76FCA03E4C0CAD35480F6EACC4EA3DF9121D5771EB9CD5FFC0FC49E812A34B7C2E2EF12386BB86EC145F64B8ABBD0F7FB1A128CC538586180DF1491A62BA75761896B83CE254FE6A591AC3F333C320712598430E97774041AA93BA3BB140F1FF705B072AD1F0A2E1ADFCD5D0F0F6687887931680DBEC5E505A80F68617D30220912291764DA4C399BD6066F56E661E98141DA91AA9FA3CA83A5CE51D065F5F0A0B435068D3EA3C488046ED478BA1386EBA3CD4D927A7CEF47FF4A107CD5B050C9A37346F3D9B377720D76A5FCAF208C004C3ED637BA6ADB8FABD26B0F6D00C37773428386A76E7B50604CD079A0F341F9D9A0F7A4864A2EA03991CE1A6B8128C0BDC14C776C8D72ECD431C918089F2B53FAD7A3F318CB618C525FA665B0E65C8F100297A06E8199C9367E0B89F9FAD81F80496730973CAB095ED10C6AD3F8BBEAE366A3A35089237A9E92C1FCCA7DA7432F1034453BEE8F7B579D44094349C1805D2519F680CE47C65B30701922F0B1D087420D08160E28203A138C6B3F3F2C35FBCADBC9D4A1CFFCDC2DB49F9130B687F22FEF5853D8AC569791410A3DC5D062BBFF3C1EAFA3F83CE953881B70BE8672AFAC9EA9B854C31A22F78DB1FF3FB8B92260CC289677120CE0C309715D86B9B03E69861BABE12FC323DCEFCFEEFBADAFDC6867B537B9A3AE3EE09A969F90B22F584A3CFDC34730EB797829E2D7AB6E8D95E555A56673A90E018DAD5128C93B7AB8D59A820EE6E3294D978AE8CEB3E24083553DD71EAB5DC825C7480E614CD299AD39333A774A5891E589431A771D9679970CE41E1A35AB786224AF132A2862FA4ECFC677391DAE03FD0D48A98C3BAD922D0909E4D7A9825CE9FE06E9D74140310CCFD3C9DCCA0D060AFD754ADCC3E95EE378A008DA7E39A6FB4D66DAC351A6700E33C75DC36F699146F65A2E3F26765A549891E2C2E722472247264D71CE9B8A62D75D34252589A1FD3D203664756499932200C293861678A9DDA552DE4E61235C8CDC8CD03E466168297E56656589A9BD3D203E66656C9DAA336409B7CE49642CAD77264966E38587F648B9771C5F494ECF36E0ECD39867011412D906199C19E2C828D655134650A0637B64DC701C443EF02BD0BF42E7AF12E5A84C7E2F2ED7C8C130890A19B316C37C3355D40E3135ADA31B0A905C3238D65E6160AEF5171E1FC0A0206F84B982EA493423A6EA6C3AD062ACE0360E5545BD726907D872E14BA50E84275BE99563567AEA21E213FE7F9ED7C25566DDE1A64A64CBBFF9C9A8E4DC368611B696FFB5173D7B99AE6D3F967618F70BF2AEE57ADD3737C8BC5687620274012CA47DBC60BD2C3BE1BA450A450A450260EA5EA7613784BC21F312318DBB7C5C336F057DA57FA8CA60038AC7558CEF1839879F72B75BB7EF536BFB4AF447A7D95AA236DF057DFDEA56F14BAA0044CF3577EE05762119ED77443A76B59CD58C6F67B1D90618E7950A6FEE6AD0E66AACFE6BC38EB7DD00445C3D61C68F67655DB4BB66970F5D17CEFEF5EB635BF5DF84223549C4DA4AE4EAA62E8334DB1B9C1266BEF7B6D2BAD83371B71C72BE5E5E587B7ABF919C6C6B3A2AA0F8ACDF33BC478CD681C5886BADD0716515B03A69A8E6BF1D58CA16DB7AB2634D33438D0A6DE9EF816355853C571F5E65F76BC22BCE66DF635484EB837A409E961BDBA5FAE2A9B47B3E8D20C9EDC383E21C25565BD6238CDE5467C786D027BB078B0D465E0AFEBA0D8D5723C48A3D5765BF91B52A491619ACDBF618CF4BAF2368D6896A1CC7810C76FFE3EA826228AC7D2CFAAC593D25568BB6F8D68F68807CDF6BF2F091CF3B9D5651D28CD3BAB4E44319B1045F158EB6B87326B3CD73796C5B5BC5F6B32B368AAAEA5144EBE972313CBF26725BD471763EAF663B31D4BD148151B001FC5AA676FB7B51F5F7269361F24416C1A41EC2E501EB4A69AF1D68AE08469919AD0A21B79F820DD5AFA8BEEC7E0C072C8AFB07CF16B2B97A44B6FC2B32A61A2DCAA4D0085EC6975DE4931D55A233C798D78ADFA9AD8A25ABF270AD4F2C13953A7168CE6CD68840AFE35A9B143C981614E9C1A0F2C7BBC89038DC540EAB0C263001C486E9D63926E5AE5456A6862B247A5096FFEBADA7A0B36537BA99D3DA44B367C90E3DDF6ADF223CD46D44A2794C9D43179F6F1860EF8B517093EDE90575EFCD7E0CD5B4DC9EC74B58F1F4CBDD75732B7DDA72523C995F3EABD50FFFFDF88D29FEBD566FFE9FA4710BCFE7E73B367D0FB77EBE5CB6EBBDF7E0BDEBD6CD737DE627B73F7FEFDDF6E6E6F6FD621C6CDCB3E3B65CD4F74134D64D8902943EE29514D6A3A5AEEF634299DF7D5A3B36B75B12EBEC63F518E3596CF97F3A1C4F48788CBD1BFE328E7B36A9873EDF9C17475E35DD8A9D9F9750E2CEDD811692B35DDACD97E52B56C758A854971BA26EFEDF20B1E49199A7C51DDAEDED69BB227F9306935621C88CC6255055BEB516810318F322BB0526DEBE2E59C8386C542619CBB52A0C22687FA76B1CF9AC6A00E9B9688F9B192DC7059A444C88F13A53ECEA244227E8C38374C16249609B7C82A6D52C1C36844B2BE942131A940CBA64EA146B14C08A5509B58C68F12C7BCB328B18C1F2513D2CE0265C4425861203687140A8570C2C86C0E27140AE14491D71C502415E8EB34527DD0DDA95808ABD84B895008A7D84B895008A7A497526911E9E34DCEFAE46DDD4DC1D8E516CBF23694D7C26683C80006360D3A4B18D89AC23506F6396C427E241D3EE9DBC0968E6DE1814D7AC331F20332110AE168EC504B0E27140AE1143FB444288453FCD012A1104EC987964AF9915CE5DED0F33F582214ED69A5ACA795EE4CD1F1E823593782E10EBACE24471CA525EB58831458167DF2587C9A7C412AEF3E59B9CF21110AE1147927110AE1147927118AB5ABC03B895008A7C83B895008A784775269FFBC1376AA52D6D367C93BE94A330CF1B0956939E6292F5AE941E738476CF63F35B57971BCA4520124526B3737638A65622885DA443231947C342296094411547762CEC2BDBF07AC9E918B45126CD33074BB88987F26304F258CAE18B9796A24C3792ADC3CF51C6697C725D724240FC7AF8553A60C8F97624B4BF7C093AC4C819D12297EB5F8D51EA01CEDAB4DB7B9C17CB26C5B9CDCF75A5EB4D27047250A4B2419F969CEC7CED35D83716260963408CBE8B66B17A827140A7DE60ADB9497FBCC95929D7A753861FC32879308055DE282E3994ACFCB2D46D3C8313ED1344A9BC6ECCE6D905D04D14E6FA94D0455656B82956191922D04E983D33490B444DEB78E6522A46BB9799458C68F625A79031B4AFADF0F11DD9E73E833DC1F67F7028D8ECEEE9F8A21532614C4C9D727110AE2585F4A70A85020F04AC86E94B3D3B14C0CC5358B28AED06F05E30AA111E5C0C1DD0B3C38A7B17BE1705F31CCA43739772537F1AD2E5ED5DBF93548B1C547182BCCB6641E6084127E843DBD9BF879C16E19CEE264E5FC68E4572DC14AA5831B8199C37730C33077584F6E30368174B344F5E4D3CDFBD9F2A144C0FDD96E821F39F72714F1638C962BDFF2F230A9743043A870CEB2FD003A3897293E74EA8B578719A22285594AF641DFB394075DD1F25E7D2C134351B5228A2A5C97FC2C2596F1A32429DDB2308910BD45F416B9712ECB5BCC1D4007A4D956242B4CB115047BF1F44ABA81A65ACF0365C4C25879B6CE8891B091B0B9B190B0A5083B97E50384B193AC2052945D5DBA92674913A6FBA040B5A9B86FCEA66D508B30915010A77886301222AF21AF71E35C18AFE5F20DC1F11ACD4F24CF6BA5A5EB78CD2AAC2FA5D25366B592EA4442419C3276143C62CD8A38A51572C46A847E28070EF2350FCEA5F17536A31B085B4719E0A4B8BAAA6C553FD322ACFEF95174F0A06FBE4E6ED33958398F858238F4B69C028E564817D388337D2AC1990A6D7348AED429E0887D1DAC886394E03842BB2CC3AEB0D5FC4E87542C883532CBA046C55C78CDBD6DE63FFE8CF808169B5DBE920F1FA55291ED48F745A0442850A307FD8FB95EC86592484591F29F492AEDDF8B60DDC16EBA297412938AFE6E05A88C58605C029DC6441F8903077D241E9C53F191B2B96A417C24A7E4DE6386C6E1235595ADF49156CF61FD0B3E52F601FA4803F491D01F6944427FA41927BEA7F960B92F92A1DD47BBCF8D735976FF20B37C7BB39F64A217B7FAD5452B8762FEFB3A96891F9A4905701568CEEA7C75629908B98F0B47466299409BCCE2EC3096F1A3387493CD38F74526427E9CF872DC2C4C2CE3476197FF167052A980E1D31E0B38B14CC0C598386AD180A6527EA4995EEC9F58C68F622913AD009308F971EE15A30013CB047A67AE3FE4C7712CC3051C7452B8B1D04969E3A464AFAD81F355E83537F2EE4A6969F45804189A7462BE55B1ECB2FD1E98292D5A1D0E1CB43A3C38176975E2ABCDE00CCE83D5C2DE94151EB2B981A1775A22BF192B9689A1D8F9C9402443424542E5C642429524D4CCFD8E307C1ADE072947A7156587CCA6ACCA059858288853D8DD1A0B4556A6464FB3FCBA1413210F220F72E35C1C0F666EA785E1C1F0365B391EAC283B641E6455CEC32442419C3C0F2642F409910BB9B1900BDB70617ABF36201FB2FBB85B706279F94BE045BBB803CA16DDFF04154A45666DC44166E5C1B938661DBFF9FB002E6D2EE5C5F15C775CD59464D5CAD243E6D4B16A1676158722218C7109C8581825EFAB462291ED2230296E4D7BACE63FA758C68F0295E4562D1ED5153DA76B59A693DFCF1AC9F8515896DFDB439458268872578222749532DDBC938F76C732B4BF687FB9B1D0FEB6B1BFBB6FE0F6D71EB5B1BF65A5076D7FED51C1748622218CA2FD8D64225C382A66BB4F84FDDBE021591B284B4E7C887C0F472281CDA3C46AE7416259DF1E8E3DB2D4FC269E58865618AD3037165A61492B6CFBDF97C40C7BC172BB519790C6986EE9532792B6B8AAF0904D31CCBE46A8456C24330E1C24331E9C932433682A6B4164A747634F4F451A7B12DA000F4386B4447EDF7A2C13E897075DFD3CC9F54B24139825D112B9EF299689B4C879CC6F0A8A656228C5DE0D65FDC66E55F5299FC321120961146271B1EC2457E548093B7F6F5622148B51E63B3796F51EE964D5CFCFB162213FCEE3C499B856AE51895014C7D6CB806C2143A9E98E9BBF2A2D9689A1E47FF258D66F34271CAF46D92016CAAD16B2751E2716E2EC1C1D5A6E2C7468011C5A162F073DDFC902DE3239A8EA0A0FDDB56DEF94B29617683A160AE21496AC63A180E931EF7376870A04EAA1CFB4FC9DDEB1ACFFB0BD3A7173938F50C28FF0CF89A516925D25429131379FB976BE32B1901F67A6D0ABC815A3D0B08307FD2F261036289C500E4582CB2325AB2342FD33D1F2189148E01BB08D49613D22110AB9954A1E269689A14CF2F3D644288653C823960805967C0A76D312349A9635B10C45D5F328B1540829DFA248248251E89548846E29BAA5DC58E89602B8A596F78BEA860EB75ACA538B886B69E9217BA643CB3B0296310426C7995D92075538096A590654E1F4A700E14ECC5CD28885F68B070BED97B4FDDAFBBB3FC1AE340FAD0EF9051F75699B55517AC8368B2D5B15160A4359DF4B59B44471A130949DE642A162DB9347DDCDDFD19A48C5FA266FB46299184AD182A652815E06388E5012BB488422382C6C92C78984223825719044D87F4450D1E686FB47EE274F8422DFC3C4D0F23889B05FAF0964698C8C56C7550ACB98A918FD2FF4BFB8B1D0FF6AE77F59DE2F6017ECB14DD8A0A2F4905DB0F30D1B40388538E547938326074D4EC6E4D8DB2D68863D4A4A746F550BA3535E7CC8560768CA0EB45F13775A56E3FC91DF729008D1EAA0D5E1C642AB236F7588D1813E57E73CB63857575EF8FCCD0D9EABE3C0411AE3C1B93C1A83F69A5B78CCA7E72D0FE75C127A72CD3848813C381749814EE0056FA02730E8371CAE3CC9B36145F94153220C9D952DE509AFE3A92528AA388AA1386EE1C6E758288033D3FF51C4898548F548F5DC5848F52DA8DE05BDD78A729B2B7BAF5555E141133C84CFEB16F6094522010CC5D5EF0BFBC262A118CEDCC9B72816F2E350BB32CFB1722C43524652E6C6B9385276FCDD9FCB171FD4FBA67B6E27AA2EEB7C57171F32359FEB9611B64D32BF869708FB0FB5409C7B81B91EB2B00828BA0048EC5CD1F2E1F617349F1C7D8DE6338B731CF36981594DC7FDFC6CC9D8CBAA8243B6949693C708252208E3C2D08F6502EC0994596328F91E4ACE5C089FB8F8A2DFE73B3612098C12807328859C139108AD1A5A356E2CB46A3256CD79F9E12FDE4803546FE56F161ED88DA18A43E6767970099BC78953395C17B981BAE8DF04968E72E121EE2E83959F333CA14800C3FF19E420984420F61678BB40F3825C4D32620113B659149112A1509D82B77DA1424C369C0F8D0C5C63FB5D5F7BCB15E437169DB394FBB0AA0A0FD9A164518DFC89E94478BAA117A88464AC8833BFFFBBAEBA2560C91381008AA93D4D9D712E82120BFB8EDB3BFACCCD1FE88E65E8E8A1A3C78D73618E5E687F9CA9036A7D089EACED292D8A96A77FCB03118E3094D978AE8C73DF412A15A88DEE3805A04488D606AD4D435FA3B5C9E21CC9DA04FF9A043ED876771AF8A6874C2463E6E545AB89232CF19C1F42070FFA363EAA52C8961D89043EB292C33BE2677768897CCC3796094C2A889DCA2FCA862281CF6136C959BF5022508BF953FEAC69241230118A91C7884422C6EAF374322B0C3726E34781393AAB5A85B5EE4884F178349CDC5868385B18CEF51E2C17706CB5A68EDBC27C96966EB2A0A450A5118D9F9DA21D25050A8B9E8A60763964480E1C64481E9C8B6348465290FCE8B8A62D9375B6A66C1D37B222A5CC983EE99B1799E6629522A1204E9E1D13A1204E61EF502A45A645A6E5C642A695645A77E76D40F73DB2F0B424D35694AD635A56A49469D327475946C8EFB14F84FD87FF87B6ACC1383E7F97682214C4C9A7354B847DEE60A5F31D27B7593396F51DBD3B97730C30B12E5A429996C030213FCED8361DA700944AD15B416F851B0BBD9536DE0A70E82C3CD4271D3BAB2EDEE8B65445CF0E1EA2F382CE4B1D4E7BE7C535DD82618B65A2E67A5C66AF85F61046B6B90428940AB58BD9E742CB22293FD2A3E2E63D9148248451E8E558C68F62BA456F269609F5CC4C2FFEE24C261224771E0A9549840238B6AE4D8A9D9311A37385CE1537163A5732CED5FC75B5F516EA7613782F60EE15DB05AA9A335751A572B73594AF1C9A03D84A4A6CCCBC009308F971664A7E3487127E048873A46CB7E86DC90ED25B6194BB12943BA1E802D0395FA4780E1CA4781E9C53A2F8F16EFB0696B58D11346335697AAF2A7D09E4CE8A142E328C8548654865DC38E74865F143E6952E37FE2EFF4AA23D9224FFEF6301A51CEFBB1FD2555A8E9E375F7BACD5FB57EF8592007963B4DCEDE91967EFABB7F7C357AEAF4817FDB95CF8BB4FD7CEAF7DE0AFDFD117DE39FFBD52574BD2DEF485A9B7597EF3F781BBFD97BFF9747DF7FE96B835CA6AE9EDE9D9ACD5B7EBAB9FEBD586FCF323085E7FBFB9D93305FB77EBE5CB6EBBDF7E0BDEBD6CD737DE627B73F7FEFDDF6E6E6F6FFCC5FA66BF5FACB2E49821E9D81FDAAFD4EDFAD5DBFC3A24D18F9FFD5FF95F23FEBD6DFF5BA174F1E0FCC79B3CC4C7BC2F76509A56EAD3F5D7E5F725ED17C6F6639FFC6C5EE02F2C2F08FCDD869ECFF7590BAEAF666FAB95F775458A7CF356FBC281F0BCAE98A60FB5A420C1EE8D0B83526B88B1F9D3DBBDFCF076FF6BEDFDFCDFC2F5495C4E40B0BB4634BE56B21913FDF621EA961C5186008BD2CF00B4323EEA05D8440BA4620CCCFA0203E64C1DA87A1128A85AC5CE050054C6BD68F36527BE4508B2209C132CD7BE044C6834615A16D94D881E4FFD8B36DD943817EDBA29F12D605A26DB4D59EFA2DE46929986A61BBAAB4BDAC867CD5FF9815F74EFB86C64A6F4F06D24C430237DED18E9F89006D1D8CE13804146B0B2E3BE2D16D8E02758701CE12AF7860E645DC3CE578E6B2D84BE6FC31CCB7EDCA4E852CEFB8D8B5EC6674D1AEB3E5930839560B5A7080292A508597346DB05C50E040B8C1D08D630D921ECF7536287A93E9BCBD083CCACB8FBB9F0D4D4E6603F26ED1A17665E40A1006BC53155E7812273E189390BD7CD80A6D7B66918BA0D0649B95931AAB9906B50E0A4EC82E651C2E457D8A2C8C77F29D388B26015475D5F4DBD9F86BFF91EFCF8747D7BF74192FCA0C278F8D5E05753FED5108E970B174465A502EA99B2C79D53707F3CAD41B89D193E343E6F861B0B2A5A0D61E13943DE9CECA0DBAE0DC50E641206831546E960B0980B09E5A20DDF89444B8696AC747978BEF7772F5BC9E05858587271382D7C1901328A01E5986ABAE5024D804D0BCA22822E7A473948FB5CA3E68DE0CDEE9F602AC6C0A07C1B06667D8101A3FC356A36B4DC582ED04F09B9AEDFAF49E4AAD2006D62DF0BD57C3FDDB12DECF156AA55C5D0679A62CB586C9975ACEE17B0206C6BC02E3201F819F7F42A93E705BB83A4DDE0F2370B091CA1B160A9D18D3893B5F7DD8759C1287DEDC9A7A1398E17A7DB4DF063888B22610BDA8522C2B601072C47CB954F9A570086E48DB1F1ACA8EA83624BC67993C2529E7EB6F0F03DFD075DD1528758669C500415A016507385E4842B86116A614ED6653A8998C4713CA684F95AF05E0BD643CE130AA2AA340D14100C507404C913C9F382C953351DD792F41AD5ED3E98EE0399ED0199A2C3674FDA472A08086E5B40A2B964A2314D439668AC927B32F978C6322E8C66406A02765292813940AB33E8AD21895E30894E15876E8F91A0505AD8DB13969361D183C2C327D2245F25C00F9BE4ACAC1E6B7C6BA42CAB67F3B232779DDA1E9E61204ECD9E34FEDEB155981D5B0C6D6402824D4D20E68231AB2CA761DBF087A6DFB707511FF43FE63A10F98560F51F49DFC69DF5124B1F19D5C97F59AEBD154DD841FEDA2FB784A46E3F10FE7AF128E49DDC6FD9A102C8035BE8E9A0A773629E8E53721B08A7A7B37A76029A295CCAD3C916464FE77C3C1D1EB742A079E8575454E5DCFD8AF8261371A38F815DB4D46767A91FA6C6F3FDC4908AEA96654B2C0BFE5624E82C7935313DBCEF161324726C653BBA67D0C60C1F6C67FBAB1C6A9D41E64701E075D39CB6AE8BAD8F67ED3BDBEC722AE8D09D2663BD2BF8F81E8A6ED0D34BB2BAC157B4C70ED1E9CD23B2069F077FA677D9F79632D13A84BF578C2EBB7EAE3FB4B5CA159EDFE19EDEF7EF871D4FC183257C6E1A1E2C49C4957E9AE69E8FAB56FA2E6DA44CE007BDBAD69E54DCF5E81AC2040CD0C0A18143032768E01EAC61D8B733B743205C4F418ABBCCDA721745B5917091709170BB265C95DE4F3F0CBE65553963C24DDAD71E059E72357DF434AB05FD0D091109F1FC09716498A6D4F65C784264553963424CDAD71EA58110FF5D980FD149444E444ECC72A26528B341F362E9BBB6CB8B1AC71B916CEB68B17EAB1B1F064C6017F919F919F999F1F378AE3BAE6A0E839DC7AA79C63E6BD4BAB618630810F828404576D8B6B0A63D568B9F544B0FBD22636C4B54B5E4D074DBE6AB96653A2E704559EEDDDBFAAADE4A8116EEB06D094A376061341F1D017404FA7104ECD1401C017B74CE8E40D8BAB618ED1D015B1F95E5AC1FA82B703A66AB1BFF82B842F0BF15752FE0513BF1DAEC91A5E25E2A7406D019E8DC19A07B1FD5C9307C81781F266E0380D9920AB39700790D79ED34796D38ACF6C47700A29C00CF8AD49E9E86C08C14A4FDE103F541573F4FDAA28C298AD916854CC31EA1F76651CCB627F31A42E15CDDAC3E15539F1CB4EC2F129092D1C6135B002520767A6517784369D4B6E1B7B915DF65D86D28987589D359973C4E9C896B35F58970A784B076C16EB6FBC235DD718BB7C3B5DF26EAB8C57BE2DAA236C4D2F84F8BB5CC85181AA0D6201883405F1D7DF57441422A07DC516310ACDA67EEAEB75FBD883BA93D8A58F09ACF7F31EF5BBBEFFA4C2BDE645E7D50BBA36515DE8050FD9172F150FD3F27969A4992279B877E3E73ED86D3EEC2559B29F42E77C5686AF45FC53B9267D947C27CBBBAD1B096F29BDC5A9A002657FB092F3480DE897B8DB631695A4A1247257EB3D209E8A47DFC80C200A43DB44AEC7DCB065AD6C43214B57EB6214E160416A2B9DDA58A44FFBB0606FDEF33F5BFA9A367294FC370C031B763C61F18701620A8043E206919ED92B4CF07BDF441D815B3CB723FB773EB3B086463D621B49268257BB292A4031FF5615849B6DCC7BBA81CAEE29DA98D8C7BA23508484DCE6B5159B1EDC9A3EE425DC0EC3C82AF1552D046432D6CFCBB39DFD3457447B558280ABEB2CD6123F1CDD212515CBE68E9DC70FFB05A7EBDEAC3C4D0DAA3C0BB7810EB9EE42B715CC5ADF7E4FE03DDC31A1C740FD13D8CC455EEE123065106E8205E441005C07D3DFB8807A60C419B86364DD4A6D13D73C3306AE5818CF257CB123A9D8D4583895600ED51BEA0EDC5027DD2DDFE628AFF87DB3EE085660ECD1C9AB9C4CC0DE70C2CB7913BFF33B000660ECFC022AF5D2CAF0DC775C704ABB05E37A64645A244A28424CA707D6C186C79E61C08C25FCDEB99E2A101B513504371DC34C6DFEA835067FA3FA0B0D002A005400B90B100EE40AE143CF3E0358407EC76B041CB565CFD5E930A0CF3C2CF1DAD2B786AB9E60D648E548E547EFE544E77694F547D20BE3CEEC4B9A89D386C8B6BC392A5F076E4E15C720E721D70EDEA25AF29EDCA8EE2812A34D468A83B37D48EFBF9D91A8889B69C339E6E858D6B09316E3FCE3BBA29A0F94C8D78F28BD2A32F525F52F3D99C0FC2B5FBA2DF37249E11C76C3CEF2403D994CB45FCFC108FF5144F4A82C6138DE769194FC521B3DC971FFEE26DE5ED54E2896E16E42B90B1A50B685B1AFFACC2D6747112D61464D4BACB60E5830C36D7FF1980003981B70B34D2D16D3F257DB3808021F509DEF65D7F43D1D9D94138A12CFEC079A2FF22E244ADCFF40F2A2ED451C24006EBCCEFFFAEAB308BC2F7A6F63475C630A4D2BC24217CE4D8D1676E9A8F40DAE0A3CB872EDFC9B97C96331D48C4048DD5591B2B8EDC1FC2370D18CA6C3C57C6858FA4DDFD0553DD719A406FC53307A3E542CB85960B2ED24FCFE0C858AEB8ECB34C48E1A0F0710D0957C054A94D93CF35EC1B8E3AF1621483C1727309628D0A331EB9713A9B004D6FE64FDDDD2CE4284687E0EEE7E964D6157AB7572EA95666C9BFA72575B971D6AB75E584B974E3CA0973C9B675EAB86DCC2B29DECAC2C6E52FC2C8120820FB88CC85CC75C9CCE5B8A62D954E39292CCD5A69E9E17316AB2B0808076F71B58A8139C5D50C644164416441411664315B59166485A559302D3D7C1664752D6EAC97DB360113266F8CFC7383D405FEB9D93DBDC7B70588DBB226F5DB4D7903504ECBDB752102615D862C4EF6FC42B771228AAE4C3B831FDBA6E374888F9E0C7A3217EFC9B40845C5E5DBF933A7138C4297E6425C1AD7743B343BA14D1E776C943BC3279DC30C7357F88F8ADB9DC742C03BFC654DB74B778874FC4CEF6ECD4F711E3AACBC6AEBDAA4CBBE47670E9DB94B75E6D86653D59CB98A7A84947867B3339498B5797B94993285F9264A0FA34A21B1FDA1B7705077205015278C4F80B1719B251F65E336CB445CCED98C7106724620613F64F72614A0FD24485A485A27405AEA7613784BF231C75FE376E18F96BB3D3D7FEC7DF548671DD62B2CE5F841CC74FB95BA5DBF7A1BF2E1A77A3E5D3BFEEADBBBEC437A447EED91DEFCBA258D082B9B3C5FFAFB420F1434114ED57443A7AB35454D9987A59A32CF39F418E6B842097B52A5813DE4809FEAB379057EF8A84A41F89453030DFE562B614FEBF4B0173854D9A651F58B848FAA94844F9B34EC57F3BDBF7BD9960FAFF859C5E80A1F730E2E5531F499A6D8158D491F5735287D83439B15A78A98ACBDEF7E85CEFC4B559AF3EF35E81F1BCF8AAA3E2876F910397C5CA6F3F00D5E6DB5BA9A3471E9514DC7B52A1B953EADD094BEC0A9CA348D1A55EC699D2AF642B3AAA9E2B87AD9B0CC3CAB50133F6E56E2845B5F4A95C4CF2A94C48F1B94D074A0346561898EF451998AF429A706CDAD53C29ED6E9612F70AA7AB06A34D187758AE8730E3DECD6A40A35D1B32A2DD1630E2523C334CBC658E6599592E831AF12CB5066758AC2E7B5CAC2573814B20CA0AA59A12E795AA52C798157953DAA53459FD6AAA22F70A8A2D943D54985A6F86195A2F839A79E1A2DF53AF83BAD8C75B20F6BBB8C8F776885E87DE0D58D614FEBDAC35EE05245731E97B944074FAB55452FF0A97AAC6B55F4B446D5A340ABC2CB67AB75858FEB94856F706AAB19E0E1C33A4DBC03BCA645F5ADE16E4972994DB59AE8799DAEE8154E856E95518A1FD6A972F98C5292D8BB5C53FAB84A57FA4683B6283B69514FFCA04C43FC8CC3132F266F2B77C64BDEABF2C74B5EE59912448B02E55381E861E514207ACEA387A62EA9D0C21E55EA604F397EAE0A87257D54F59371B92BD98376D54A2A1DFD83173854852763CA1545CFAAD4448F39945479DF9967554AF8BCEF833D61357A6ABB2D7D836B861B2F5A564D6E93E7D5F3DAE4151E8551C4BD425DFCB45259FC4259F42C899325CF3EDE84409180FC1B6C7764F63DDD2EFCD59E493FDED86F1B1A3A0CFFD3FCFDF27B0AF191606EFC9760B9DDA4A0F13B93CDB76D1C0324ADCCD6287E25BF78E707DEC20B3C65172CBF792F0179FCE2EFF7CBCDF7EBAB476FF5465ED1D75FFDC56463BE05AF6F81B2DFFBEBAFAB5FD9F67EBCA9D7FFF1A650E78FE62BFD6F0FD10452CD258DB69A9BFBB7E56A91D47B548CDA5641D0F865B438416AE5047491E2FBAF0469B6DD700245DDA7F9AF84C0FD4DE0FAEBD71501DB9B1BC7FBD3AFAE5B731F1EF6D8476DE97DDF79EB7D84919627FF92E1B758FFFCCFFF0FF231F015F9A80300, N'6.0.0-20911')
SET IDENTITY_INSERT [dbo].[ASL_LOG] ON 

INSERT [dbo].[ASL_LOG] ([Asl_LOGid], [COMPID], [USERID], [LOGTYPE], [LOGSLNO], [LOGDATE], [LOGTIME], [LOGIPNO], [LOGLTUDE], [TABLEID], [LOGDATA], [USERPC]) VALUES (1, 1, 10001, N'LOG IN', 1, CAST(N'2017-02-15 00:00:00.000' AS DateTime), N'02:51:22 PM', N'192.168.10.101', N'22.360178899999998,91.8274197', N'AslUsercoes', N'User Name: Alchemy Software(Piash),
Department Name: Admin,
Operation Type: AslSuperadmin,
Address: Goal pahar,Suborna, 203/b,Chittagong,
Mobile No: 8801740545009,
Email ID: superadmin01@gmail.com,
Login BY: EMAIL,
Login ID: superadmin01@gmail.com,
Time From: 00:00,
Time To: 23:59,
Status: A.', N'DESKTOP-G8JI2VP')
INSERT [dbo].[ASL_LOG] ([Asl_LOGid], [COMPID], [USERID], [LOGTYPE], [LOGSLNO], [LOGDATE], [LOGTIME], [LOGIPNO], [LOGLTUDE], [TABLEID], [LOGDATA], [USERPC]) VALUES (2, 1, 10001, N'LOG IN', 2, CAST(N'2017-02-15 00:00:00.000' AS DateTime), N'03:47:08 PM', N'192.168.10.101', N'22.3600949,91.82746069999999', N'AslUsercoes', N'User Name: Alchemy Software(Piash),
Department Name: Admin,
Operation Type: AslSuperadmin,
Address: Goal pahar,Suborna, 203/b,Chittagong,
Mobile No: 8801740545009,
Email ID: superadmin01@gmail.com,
Login BY: EMAIL,
Login ID: superadmin01@gmail.com,
Time From: 00:00,
Time To: 23:59,
Status: A.', N'DESKTOP-G8JI2VP')
INSERT [dbo].[ASL_LOG] ([Asl_LOGid], [COMPID], [USERID], [LOGTYPE], [LOGSLNO], [LOGDATE], [LOGTIME], [LOGIPNO], [LOGLTUDE], [TABLEID], [LOGDATA], [USERPC]) VALUES (3, 101, 10001, N'INSERT', 1, CAST(N'2017-02-15 00:00:00.000' AS DateTime), N'03:50:25 PM', N'192.168.10.101', N'22.3600949,91.82746069999999', N'AslUsercoes', N'User Name: Demo,
Department Name: Admin,
Operation Type: CompanyAdmin,
Address: Chittagong,
Mobile No: 8801990000000,
Email ID: demo@gmail.com,
Login BY: EMAIL,
Login ID: demo@gmail.com,
Time From: 00:01,
Time To: 23:59,
Status: A.', N'DESKTOP-G8JI2VP')
INSERT [dbo].[ASL_LOG] ([Asl_LOGid], [COMPID], [USERID], [LOGTYPE], [LOGSLNO], [LOGDATE], [LOGTIME], [LOGIPNO], [LOGLTUDE], [TABLEID], [LOGDATA], [USERPC]) VALUES (4, 101, 10101, N'LOG IN', 1, CAST(N'2017-02-15 00:00:00.000' AS DateTime), N'03:51:36 PM', N'192.168.10.101', N'22.3600949,91.82746069999999', N'AslUsercoes', N'User Name: Demo,
Department Name: Admin,
Operation Type: CompanyAdmin,
Address: Chittagong,
Mobile No: 8801990000000,
Email ID: demo@gmail.com,
Login BY: EMAIL,
Login ID: demo@gmail.com,
Time From: 00:01,
Time To: 23:59,
Status: A.', N'DESKTOP-G8JI2VP')
INSERT [dbo].[ASL_LOG] ([Asl_LOGid], [COMPID], [USERID], [LOGTYPE], [LOGSLNO], [LOGDATE], [LOGTIME], [LOGIPNO], [LOGLTUDE], [TABLEID], [LOGDATA], [USERPC]) VALUES (5, 1, 10001, N'LOG IN', 3, CAST(N'2017-02-15 00:00:00.000' AS DateTime), N'03:54:33 PM', N'192.168.10.101', N'22.3600949,91.82746069999999', N'AslUsercoes', N'User Name: Alchemy Software(Piash),
Department Name: Admin,
Operation Type: AslSuperadmin,
Address: Goal pahar,Suborna, 203/b,Chittagong,
Mobile No: 8801740545009,
Email ID: superadmin01@gmail.com,
Login BY: EMAIL,
Login ID: superadmin01@gmail.com,
Time From: 00:00,
Time To: 23:59,
Status: A.', N'DESKTOP-G8JI2VP')
INSERT [dbo].[ASL_LOG] ([Asl_LOGid], [COMPID], [USERID], [LOGTYPE], [LOGSLNO], [LOGDATE], [LOGTIME], [LOGIPNO], [LOGLTUDE], [TABLEID], [LOGDATA], [USERPC]) VALUES (6, 101, 10101, N'LOG IN', 2, CAST(N'2017-02-15 00:00:00.000' AS DateTime), N'03:56:16 PM', N'192.168.10.101', N'22.3600949,91.82746069999999', N'AslUsercoes', N'User Name: Demo,
Department Name: Admin,
Operation Type: CompanyAdmin,
Address: Chittagong,
Mobile No: 8801990000000,
Email ID: demo@gmail.com,
Login BY: EMAIL,
Login ID: demo@gmail.com,
Time From: 00:01,
Time To: 23:59,
Status: A.', N'DESKTOP-G8JI2VP')
SET IDENTITY_INSERT [dbo].[ASL_LOG] OFF
SET IDENTITY_INSERT [dbo].[ASL_MENU] ON 

INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (1, N'01', N'F', N'F0101', N'User Information', N'Create', N'AslUserCo', 0, NULL, NULL, NULL, NULL, 10001, CAST(N'2015-04-18 15:06:53.820' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (2, N'01', N'R', N'R0101', N'User Log Data List', N'GetCompanyUserLogData', N'UserReport', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (3, N'02', N'F', N'F0201', N'Items Creation', N'Index', N'StockItem', 8, N'travelmate', 10001, CAST(N'2015-04-18 14:27:04.153' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:01:42.483' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (4, N'02', N'F', N'F0202', N'Store Creation', N'Index', N'Store', 9, N'travelmate', 10001, CAST(N'2015-04-18 14:27:32.057' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:01:15.743' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (5, N'02', N'F', N'F0203', N'Invoice-Sale', N'Index', N'Sale', 1, N'travelmate', 10001, CAST(N'2015-04-18 14:28:12.673' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 11:59:16.187' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (6, N'02', N'F', N'F0204', N'Invoice-Purchase', N'Index', N'Buy', 2, N'travelmate', 10001, CAST(N'2015-04-18 14:28:39.780' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 11:59:32.390' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (7, N'02', N'F', N'F0205', N'Invoice-Sale Return', N'Index', N'SaleReturn', 3, N'travelmate', 10001, CAST(N'2015-04-18 14:29:27.493' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 11:59:24.533' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (8, N'02', N'F', N'F0206', N'Invoice-Purchase Return', N'Index', N'BuyReturn', 4, N'travelmate', 10001, CAST(N'2015-04-18 14:30:01.707' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 11:59:02.417' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (9, N'02', N'F', N'F0207', N'Item-Transfer', N'Index', N'Transfer', 7, N'travelmate', 10001, CAST(N'2015-04-18 14:30:43.523' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:00:34.790' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (10, N'02', N'F', N'F0208', N'Item-Receive', N'Index', N'Receive', 5, N'travelmate', 10001, CAST(N'2015-04-18 14:31:30.400' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:00:44.510' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (11, N'02', N'F', N'F0209', N'Item-Issue', N'Index', N'Issue', 6, N'travelmate', 10001, CAST(N'2015-04-18 14:31:49.960' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:00:53.617' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (12, N'02', N'R', N'R0201', N'Lists of Item', N'GetItemList', N'Report', 12, N'travelmate', 10001, CAST(N'2015-04-18 14:33:12.487' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:03:06.743' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (13, N'02', N'R', N'R0202', N'Item Ledger', N'ItemLedger', N'Report', 1, N'travelmate', 10001, CAST(N'2015-04-18 14:33:54.363' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:03:23.673' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (14, N'02', N'R', N'R0203', N'Closing Stock Details', N'ClosingStock_Details', N'Report', 5, N'travelmate', 10001, CAST(N'2015-04-18 14:35:32.870' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:04:28.937' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (15, N'02', N'R', N'R0204', N'Closing Stock With Value', N'ClosingStock_withValue', N'Report', 6, N'travelmate', 10001, CAST(N'2015-04-18 14:36:30.003' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:04:33.330' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (16, N'02', N'R', N'R0205', N'Sales Statement-Daily', N'DailySalesStatement', N'Report', 4, N'travelmate', 10001, CAST(N'2015-04-18 14:37:09.357' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:04:24.700' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (17, N'02', N'R', N'R0206', N'Transaction Details', N'TransactionDetails', N'Report', 3, N'travelmate', 10001, CAST(N'2015-04-18 14:37:46.347' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:04:18.923' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (18, N'02', N'R', N'R0207', N'Stock Order Level', N'StockOrder_levelStatement', N'Report', 7, N'travelmate', 10001, CAST(N'2015-04-18 14:38:40.307' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:04:47.130' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (19, N'02', N'R', N'R0208', N'Sale/Purchase Details', N'Sale_Purchase_DETAILS', N'Report', 8, N'travelmate', 10001, CAST(N'2015-04-18 14:39:38.420' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-18 14:39:55.867' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (20, N'02', N'R', N'R0209', N'Sale/Purchase Summary', N'Sale_Purchase_SUMMARY', N'Report', 9, N'travelmate', 10001, CAST(N'2015-04-18 14:40:39.330' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:05:01.740' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (21, N'02', N'R', N'R0210', N'Sale/Purchase Summary-All Head', N'Sale_Purchase_SUMMARY_All_Head', N'Report', 10, N'travelmate', 10001, CAST(N'2015-04-18 14:42:43.720' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:05:12.933' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (22, N'02', N'R', N'R0211', N'Sale/Purchase Summary-All Item', N'Sale_Purchase_SUMMARY_All_Item', N'Report', 11, N'travelmate', 10001, CAST(N'2015-04-18 14:44:12.580' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-21 12:05:21.717' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (23, N'03', N'F', N'F0301', N'Voucher Input', N'Create', N'Transaction', 1, N'travelmate', 10001, CAST(N'2015-04-18 14:53:10.060' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (24, N'03', N'F', N'F0302', N'Voucher Process', N'Index', N'Process', 2, N'travelmate', 10001, CAST(N'2015-04-18 14:53:52.117' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (25, N'03', N'F', N'F0303', N'Accounts Head Creation', N'Index', N'AccountHead', 3, N'travelmate', 10001, CAST(N'2015-04-18 14:55:11.340' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (26, N'03', N'F', N'F0304', N'Cost Pool Creation', N'Index', N'CostPool', 4, N'travelmate', 10001, CAST(N'2015-04-18 14:55:38.820' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (27, N'03', N'F', N'F0305', N'Closing Balance Entry', N'Index', N'ClosingBalance', 5, N'travelmate', 10001, CAST(N'2015-04-18 14:56:08.477' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (28, N'03', N'R', N'R0301', N'Cash Book', N'CashBookIndex', N'Ledger', 1, N'travelmate', 10001, CAST(N'2015-04-18 14:56:53.427' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (29, N'03', N'R', N'R0302', N'Bank Book', N'BankBookIndex', N'Ledger', 2, N'travelmate', 10001, CAST(N'2015-04-18 14:57:18.750' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (30, N'03', N'R', N'R0303', N'General Ledger', N'Index', N'Ledger', 3, N'travelmate', 10001, CAST(N'2015-04-18 14:57:40.303' AS DateTime), N'192.168.0.24', 10001, CAST(N'2015-04-18 14:57:54.377' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (31, N'03', N'R', N'R0304', N'Transaction Listing', N'Index', N'Trans', 4, N'travelmate', 10001, CAST(N'2015-04-18 14:58:18.713' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (32, N'03', N'R', N'R0305', N'Cheque register', N'ChequeRegisterIndex', N'Register', 5, N'travelmate', 10001, CAST(N'2015-04-18 14:58:55.610' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (33, N'03', N'R', N'R0306', N'Receipts / Payment Statement-Details', N'RPDetailsIndex', N'Statement', 6, N'travelmate', 10001, CAST(N'2015-04-18 14:59:33.877' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (34, N'03', N'R', N'R0307', N'Receipts / Payment Statement-Summary', N'RPSummaryIndex', N'Statement', 7, N'travelmate', 10001, CAST(N'2015-04-18 14:59:56.763' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (35, N'03', N'R', N'R0308', N'Trial Balance', N'Index', N'TrialBalance', 8, N'travelmate', 10001, CAST(N'2015-04-18 15:00:22.953' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (36, N'03', N'R', N'R0309', N'Income Statement', N'Index', N'Income', 9, N'travelmate', 10001, CAST(N'2015-04-18 15:01:20.443' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (37, N'03', N'R', N'R0310', N'Balance Sheet', N'Index', N'BalanceSheet', 10, N'travelmate', 10001, CAST(N'2015-04-18 15:01:47.747' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (38, N'03', N'R', N'R0311', N'Schedule / Notes(I)', N'Notes1Index', N'Notes', 11, N'travelmate', 10001, CAST(N'2015-04-18 15:02:07.170' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (39, N'03', N'R', N'R0312', N'Schedule / Notes(II)', N'Notes2Index', N'Notes', 12, N'travelmate', 10001, CAST(N'2015-04-18 15:02:26.820' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (40, N'03', N'R', N'R0313', N'Cost Pool Wise Transaction-Details', N'CostPoolTranDetails', N'CostPoolReport', 13, N'travelmate', 10001, CAST(N'2015-04-18 15:02:47.467' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (41, N'03', N'R', N'R0314', N'Cost Pool Wise Transaction-Summary', N'CostPoolTranSummary', N'CostPoolReport', 14, N'travelmate', 10001, CAST(N'2015-04-18 15:03:18.923' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (42, N'03', N'R', N'R0315', N'Cost Pool Op.P/L Single', N'CostPoolSingle', N'CostPoolReport', 15, N'travelmate', 10001, CAST(N'2015-04-18 15:03:45.730' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (43, N'03', N'R', N'R0316', N'Cost Pool Op.P/L Group', N'CostPoolHead', N'CostPoolReport', 16, N'travelmate', 10001, CAST(N'2015-04-18 15:04:09.323' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (44, N'03', N'R', N'R0317', N'List of Cost Pool', N'Get_ListofCostPool', N'ListReport', 17, N'travelmate', 10001, CAST(N'2015-04-18 15:04:38.603' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (45, N'03', N'R', N'R0318', N'Head of Accounts', N'Get_HeadOfAccounts_List', N'ListReport', 18, N'travelmate', 10001, CAST(N'2015-04-18 15:05:12.550' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (46, N'02', N'F', N'F0210', N'Party/Supplier Info', N'Create', N'PartySupplier', 10, N'sv57', 10001, CAST(N'2016-01-17 12:35:23.487' AS DateTime), N'142.4.49.156', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (47, N'04', N'F', N'F0401', N'Upload File', N'UploadDocument', N'UploadContact', 1, N'sv57', 10001, CAST(N'2016-02-01 16:37:04.930' AS DateTime), N'142.4.49.156', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (48, N'04', N'F', N'F0402', N'Send Email', N'Index', N'Mail', 2, N'sv57', 10001, CAST(N'2016-02-01 16:38:02.303' AS DateTime), N'142.4.49.156', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (49, N'04', N'F', N'F0403', N'Send SMS', N'Index', N'Sms', 3, N'sv57', 10001, CAST(N'2016-02-01 16:38:20.147' AS DateTime), N'142.4.49.156', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (50, N'05', N'F', N'F0501', N'Guest-Refer Information', N'Create', N'GuesTrf', 31, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-05-17 12:58:21.143' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:10:27.473' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (51, N'05', N'F', N'F0502', N'Guest-Company Information', N'Create', N'GuesTco', 32, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-05-22 15:52:56.870' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:10:34.210' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (52, N'05', N'F', N'F0503', N'Room Type Information', N'RoomTypeInformation', N'Room', 21, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-05-25 16:32:41.417' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:11:08.523' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (53, N'05', N'F', N'F0504', N'Floor Information', N'Floor', N'Floor', 23, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-05-30 13:48:19.527' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:11:33.803' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (54, N'05', N'F', N'F0505', N'Bill Head Information', N'Index', N'BillHp', 25, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-06-05 11:15:54.937' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:11:43.940' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (55, N'05', N'F', N'F0506', N'Complementary Item Information', N'Index', N'CItem', 26, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-06-06 12:56:43.507' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:11:49.420' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (56, N'05', N'F', N'F0507', N'Reservation  ', N'Create', N'Reserve', 6, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-06-09 11:49:54.887' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:12:11.893' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (57, N'05', N'F', N'F0508', N'Room Information', N'TypeWiseRoomInformation', N'Room', 22, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-06-25 12:23:37.597' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:11:15.227' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (58, N'05', N'F', N'F0509', N'Service', N'Create', N'Service', 2, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-06-27 16:08:42.477' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:12:19.803' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (59, N'05', N'F', N'F0510', N'Registration', N'Create', N'Registration', 1, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-07-12 13:10:05.947' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:12:16.407' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (60, N'05', N'F', N'F0511', N'Floor Wise Plan', N'FloorPlan', N'Floor', 20, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-07-25 16:32:44.683' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:11:28.587' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (61, N'05', N'F', N'F0512', N'Billing', N'Create', N'Bill', 3, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-02 17:22:04.197' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:12:23.860' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (62, N'05', N'F', N'F0513', N'Room Status', N'Index', N'RoomStatus', 4, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-16 16:05:52.603' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:12:29.167' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (63, N'05', N'R', N'R0501', N'Guest Refer Information', N'Get_GuestReferInformation', N'HotelReport', 11, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-23 15:46:54.263' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:14:07.277' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (64, N'05', N'R', N'R0502', N'Guest Company Information', N'Get_GuestCompanyInformation', N'HotelReport', 12, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-23 15:47:23.480' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:14:12.783' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (66, N'05', N'R', N'R0504', N'Type Wise Room Information', N'Get_TypeWiseRoomInformation', N'HotelReport', 9, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-24 16:32:50.110' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:13:47.727' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (68, N'05', N'R', N'R0506', N'Floor Wise Plan', N'Get_FloorWisePlan', N'HotelReport', 10, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-24 16:33:26.887' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:14:02.837' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (69, N'05', N'R', N'R0507', N'Bill Head Information', N'Get_BillHeadInformation', N'HotelReport', 7, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-27 12:58:53.647' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:13:35.143' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (70, N'05', N'R', N'R0508', N'Complementary Item Information', N'Get_ComplementaryItemInformation', N'HotelReport', 8, N'DESKTOP-28FFKO6', 10001, CAST(N'2016-08-27 12:59:15.237' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:13:39.583' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (71, N'05', N'R', N'R0509', N'Reservation Statement', N'ReservationStatement', N'HotelReport', 6, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-04 15:05:39.690' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:13:30.387' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (72, N'05', N'R', N'R0510', N'Money Receive-Reservation', N'MoneyReceive_Reservation', N'HotelReport', 4, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-04 15:06:10.020' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:14:22.463' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (73, N'05', N'R', N'R0511', N'Service Statement', N'ServiceStatement', N'HotelReport', 2, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-04 15:06:33.397' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:14:10.323' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (74, N'05', N'R', N'R0512', N'Money Receive-Registration', N'MoneyReceive_Registration', N'HotelReport', 3, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-05 12:49:23.637' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:14:15.823' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (75, N'05', N'R', N'R0513', N'Guest Details', N'Guest_Details', N'HotelReport', 5, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-10 16:50:40.403' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-18 14:13:24.500' AS DateTime), N'192.168.0.143')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (76, N'05', N'R', N'R0514', N'Bill Status', N'Bill_Status', N'HotelReport', 1, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-10 16:51:06.573' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-17 14:14:06.583' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (77, N'05', N'R', N'R0515', N'Reservation Today', N'Reservation_Today', N'HotelReport', 13, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-18 14:14:49.733' AS DateTime), N'192.168.0.143', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (10077, N'05', N'R', N'R0516', N'In House Guest Status', N'InhouseGuestStatus', N'HotelReport', 14, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-19 17:51:56.007' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-19 17:55:45.197' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (10078, N'05', N'R', N'R0517', N'Foreign Nationals Staying', N'ForeignNationalsStaying', N'HotelReport', 15, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-21 13:12:19.270' AS DateTime), N'192.168.0.144', 10001, CAST(N'2016-09-21 13:15:58.907' AS DateTime), N'192.168.0.144')
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (10079, N'05', N'R', N'R0518', N'Due Undertaking', N'Due_Undertaking', N'HotelReport', 16, N'DESKTOP-G8JI2VP', 10001, CAST(N'2016-09-26 16:28:34.453' AS DateTime), N'192.168.0.144', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENU] ([Id], [MODULEID], [MENUTP], [MENUID], [MENUNM], [ACTIONNAME], [CONTROLLERNAME], [SERIAL], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (10080, N'05', N'F', N'F0514', N'Bill Transfer', N'Index', N'BillTransfer', 33, N'WS8', 10001, CAST(N'2016-09-27 17:22:46.170' AS DateTime), N'204.9.187.75', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ASL_MENU] OFF
INSERT [dbo].[ASL_MENUMST] ([MODULEID], [MODULENM], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (N'01', N'User Module', N'travelmate', NULL, NULL, NULL, 10001, CAST(N'2015-04-19 14:39:32.100' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENUMST] ([MODULEID], [MODULENM], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (N'02', N'Stock Module', N'travelmate', NULL, NULL, NULL, 10001, CAST(N'2015-04-18 14:24:34.430' AS DateTime), N'192.168.0.24')
INSERT [dbo].[ASL_MENUMST] ([MODULEID], [MODULENM], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (N'03', N'Account Module', N'travelmate', 10001, CAST(N'2015-04-18 14:17:45.763' AS DateTime), N'192.168.0.24', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENUMST] ([MODULEID], [MODULENM], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (N'04', N'Promotion', N'sv57', 10001, CAST(N'2016-02-01 16:36:10.087' AS DateTime), N'142.4.49.156', NULL, NULL, NULL)
INSERT [dbo].[ASL_MENUMST] ([MODULEID], [MODULENM], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (N'05', N'Hotel', N'DESKTOP-28FFKO6', 10001, CAST(N'2016-05-17 12:57:37.503' AS DateTime), N'192.168.0.144', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ASL_PCalendarImage] ON 

INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (1, 2017, N'01', N'/P_Calendar_images/201701_2017-01.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (3, 2017, N'03', N'/P_Calendar_images/201703_2017-03.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (4, 2018, N'01', N'/P_Calendar_images/201801_2018-01.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (5, 2018, N'02', N'/P_Calendar_images/201802_2018-calendar.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (7, 2017, N'05', N'/P_Calendar_images/201705_2017-05.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (8, 2017, N'04', N'/P_Calendar_images/201704_2017-04.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (9, 2017, N'06', N'/P_Calendar_images/201706_2017-06.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (10, 2017, N'07', N'/P_Calendar_images/201707_2017-07.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (11, 2017, N'08', N'/P_Calendar_images/201708_2017-08.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (12, 2017, N'09', N'/P_Calendar_images/201709_2017-09.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (13, 2017, N'10', N'/P_Calendar_images/201710_2017-10.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (14, 2017, N'11', N'/P_Calendar_images/201711_2017-11.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (15, 2017, N'12', N'/P_Calendar_images/201712_2017-12.jpg')
INSERT [dbo].[ASL_PCalendarImage] ([Id], [Year], [Month], [FilePath]) VALUES (17, 2017, N'02', N'/P_Calendar_images/201702_2017-02.jpg')
SET IDENTITY_INSERT [dbo].[ASL_PCalendarImage] OFF
SET IDENTITY_INSERT [dbo].[ASL_ROLE] ON 

INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (1, 101, 10101, N'01', N'F', N'F0101', 0, N'A', N'A', N'A', N'A', N'User Information', N'Create', N'AslUserCo', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (2, 101, 10101, N'01', N'R', N'R0101', 0, N'A', N'A', N'A', N'A', N'User Log Data List', N'GetCompanyUserLogData', N'UserReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (3, 101, 10101, N'02', N'F', N'F0203', 1, N'A', N'A', N'A', N'A', N'Invoice-Sale', N'Index', N'Sale', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (4, 101, 10101, N'02', N'R', N'R0202', 1, N'A', N'A', N'A', N'A', N'Item Ledger', N'ItemLedger', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (5, 101, 10101, N'03', N'R', N'R0301', 1, N'A', N'A', N'A', N'A', N'Cash Book', N'CashBookIndex', N'Ledger', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (6, 101, 10101, N'03', N'F', N'F0301', 1, N'A', N'A', N'A', N'A', N'Voucher Input', N'Create', N'Transaction', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (7, 101, 10101, N'04', N'F', N'F0401', 1, N'A', N'A', N'A', N'A', N'Upload File', N'UploadDocument', N'UploadContact', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (8, 101, 10101, N'05', N'F', N'F0510', 1, N'A', N'A', N'A', N'A', N'Registration', N'Create', N'Registration', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (9, 101, 10101, N'05', N'R', N'R0514', 1, N'A', N'A', N'A', N'A', N'Bill Status', N'Bill_Status', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (10, 101, 10101, N'05', N'F', N'F0509', 2, N'A', N'A', N'A', N'A', N'Service', N'Create', N'Service', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (11, 101, 10101, N'04', N'F', N'F0402', 2, N'A', N'A', N'A', N'A', N'Send Email', N'Index', N'Mail', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (12, 101, 10101, N'03', N'F', N'F0302', 2, N'A', N'A', N'A', N'A', N'Voucher Process', N'Index', N'Process', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (13, 101, 10101, N'03', N'R', N'R0302', 2, N'A', N'A', N'A', N'A', N'Bank Book', N'BankBookIndex', N'Ledger', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (14, 101, 10101, N'02', N'F', N'F0204', 2, N'A', N'A', N'A', N'A', N'Invoice-Purchase', N'Index', N'Buy', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (15, 101, 10101, N'05', N'R', N'R0511', 2, N'A', N'A', N'A', N'A', N'Service Statement', N'ServiceStatement', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (16, 101, 10101, N'05', N'R', N'R0512', 3, N'A', N'A', N'A', N'A', N'Money Receive-Registration', N'MoneyReceive_Registration', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (17, 101, 10101, N'02', N'F', N'F0205', 3, N'A', N'A', N'A', N'A', N'Invoice-Sale Return', N'Index', N'SaleReturn', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (18, 101, 10101, N'02', N'R', N'R0206', 3, N'A', N'A', N'A', N'A', N'Transaction Details', N'TransactionDetails', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (19, 101, 10101, N'03', N'R', N'R0303', 3, N'A', N'A', N'A', N'A', N'General Ledger', N'Index', N'Ledger', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (20, 101, 10101, N'03', N'F', N'F0303', 3, N'A', N'A', N'A', N'A', N'Accounts Head Creation', N'Index', N'AccountHead', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (21, 101, 10101, N'04', N'F', N'F0403', 3, N'A', N'A', N'A', N'A', N'Send SMS', N'Index', N'Sms', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (22, 101, 10101, N'05', N'F', N'F0512', 3, N'A', N'A', N'A', N'A', N'Billing', N'Create', N'Bill', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (23, 101, 10101, N'05', N'F', N'F0513', 4, N'A', N'A', N'A', N'A', N'Room Status', N'Index', N'RoomStatus', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (24, 101, 10101, N'03', N'F', N'F0304', 4, N'A', N'A', N'A', N'A', N'Cost Pool Creation', N'Index', N'CostPool', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (25, 101, 10101, N'02', N'R', N'R0205', 4, N'A', N'A', N'A', N'A', N'Sales Statement-Daily', N'DailySalesStatement', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (26, 101, 10101, N'03', N'R', N'R0304', 4, N'A', N'A', N'A', N'A', N'Transaction Listing', N'Index', N'Trans', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (27, 101, 10101, N'02', N'F', N'F0206', 4, N'A', N'A', N'A', N'A', N'Invoice-Purchase Return', N'Index', N'BuyReturn', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (28, 101, 10101, N'05', N'R', N'R0510', 4, N'A', N'A', N'A', N'A', N'Money Receive-Reservation', N'MoneyReceive_Reservation', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (29, 101, 10101, N'05', N'R', N'R0513', 5, N'A', N'A', N'A', N'A', N'Guest Details', N'Guest_Details', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (30, 101, 10101, N'02', N'R', N'R0203', 5, N'A', N'A', N'A', N'A', N'Closing Stock Details', N'ClosingStock_Details', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (31, 101, 10101, N'02', N'F', N'F0208', 5, N'A', N'A', N'A', N'A', N'Item-Receive', N'Index', N'Receive', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (32, 101, 10101, N'03', N'R', N'R0305', 5, N'A', N'A', N'A', N'A', N'Cheque register', N'ChequeRegisterIndex', N'Register', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (33, 101, 10101, N'03', N'F', N'F0305', 5, N'A', N'A', N'A', N'A', N'Closing Balance Entry', N'Index', N'ClosingBalance', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (34, 101, 10101, N'05', N'F', N'F0507', 6, N'A', N'A', N'A', N'A', N'Reservation  ', N'Create', N'Reserve', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (35, 101, 10101, N'05', N'R', N'R0509', 6, N'A', N'A', N'A', N'A', N'Reservation Statement', N'ReservationStatement', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (36, 101, 10101, N'03', N'R', N'R0306', 6, N'A', N'A', N'A', N'A', N'Receipts / Payment Statement-Details', N'RPDetailsIndex', N'Statement', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (37, 101, 10101, N'02', N'F', N'F0209', 6, N'A', N'A', N'A', N'A', N'Item-Issue', N'Index', N'Issue', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (38, 101, 10101, N'02', N'R', N'R0204', 6, N'A', N'A', N'A', N'A', N'Closing Stock With Value', N'ClosingStock_withValue', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (39, 101, 10101, N'02', N'R', N'R0207', 7, N'A', N'A', N'A', N'A', N'Stock Order Level', N'StockOrder_levelStatement', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (40, 101, 10101, N'02', N'F', N'F0207', 7, N'A', N'A', N'A', N'A', N'Item-Transfer', N'Index', N'Transfer', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (41, 101, 10101, N'03', N'R', N'R0307', 7, N'A', N'A', N'A', N'A', N'Receipts / Payment Statement-Summary', N'RPSummaryIndex', N'Statement', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (42, 101, 10101, N'05', N'R', N'R0507', 7, N'A', N'A', N'A', N'A', N'Bill Head Information', N'Get_BillHeadInformation', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (43, 101, 10101, N'05', N'R', N'R0508', 8, N'A', N'A', N'A', N'A', N'Complementary Item Information', N'Get_ComplementaryItemInformation', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (44, 101, 10101, N'03', N'R', N'R0308', 8, N'A', N'A', N'A', N'A', N'Trial Balance', N'Index', N'TrialBalance', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (45, 101, 10101, N'02', N'F', N'F0201', 8, N'A', N'A', N'A', N'A', N'Items Creation', N'Index', N'StockItem', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (46, 101, 10101, N'02', N'R', N'R0208', 8, N'A', N'A', N'A', N'A', N'Sale/Purchase Details', N'Sale_Purchase_DETAILS', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (47, 101, 10101, N'02', N'R', N'R0209', 9, N'A', N'A', N'A', N'A', N'Sale/Purchase Summary', N'Sale_Purchase_SUMMARY', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (48, 101, 10101, N'02', N'F', N'F0202', 9, N'A', N'A', N'A', N'A', N'Store Creation', N'Index', N'Store', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (49, 101, 10101, N'03', N'R', N'R0309', 9, N'A', N'A', N'A', N'A', N'Income Statement', N'Index', N'Income', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (50, 101, 10101, N'05', N'R', N'R0504', 9, N'A', N'A', N'A', N'A', N'Type Wise Room Information', N'Get_TypeWiseRoomInformation', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (51, 101, 10101, N'05', N'R', N'R0506', 10, N'A', N'A', N'A', N'A', N'Floor Wise Plan', N'Get_FloorWisePlan', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (52, 101, 10101, N'02', N'F', N'F0210', 10, N'A', N'A', N'A', N'A', N'Party/Supplier Info', N'Create', N'PartySupplier', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (53, 101, 10101, N'03', N'R', N'R0310', 10, N'A', N'A', N'A', N'A', N'Balance Sheet', N'Index', N'BalanceSheet', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (54, 101, 10101, N'02', N'R', N'R0210', 10, N'A', N'A', N'A', N'A', N'Sale/Purchase Summary-All Head', N'Sale_Purchase_SUMMARY_All_Head', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (55, 101, 10101, N'02', N'R', N'R0211', 11, N'A', N'A', N'A', N'A', N'Sale/Purchase Summary-All Item', N'Sale_Purchase_SUMMARY_All_Item', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (56, 101, 10101, N'03', N'R', N'R0311', 11, N'A', N'A', N'A', N'A', N'Schedule / Notes(I)', N'Notes1Index', N'Notes', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (57, 101, 10101, N'05', N'R', N'R0501', 11, N'A', N'A', N'A', N'A', N'Guest Refer Information', N'Get_GuestReferInformation', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (58, 101, 10101, N'05', N'R', N'R0502', 12, N'A', N'A', N'A', N'A', N'Guest Company Information', N'Get_GuestCompanyInformation', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (59, 101, 10101, N'03', N'R', N'R0312', 12, N'A', N'A', N'A', N'A', N'Schedule / Notes(II)', N'Notes2Index', N'Notes', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (60, 101, 10101, N'02', N'R', N'R0201', 12, N'A', N'A', N'A', N'A', N'Lists of Item', N'GetItemList', N'Report', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (61, 101, 10101, N'03', N'R', N'R0313', 13, N'A', N'A', N'A', N'A', N'Cost Pool Wise Transaction-Details', N'CostPoolTranDetails', N'CostPoolReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (62, 101, 10101, N'05', N'R', N'R0515', 13, N'A', N'A', N'A', N'A', N'Reservation Today', N'Reservation_Today', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (63, 101, 10101, N'05', N'R', N'R0516', 14, N'A', N'A', N'A', N'A', N'In House Guest Status', N'InhouseGuestStatus', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (64, 101, 10101, N'03', N'R', N'R0314', 14, N'A', N'A', N'A', N'A', N'Cost Pool Wise Transaction-Summary', N'CostPoolTranSummary', N'CostPoolReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (65, 101, 10101, N'03', N'R', N'R0315', 15, N'A', N'A', N'A', N'A', N'Cost Pool Op.P/L Single', N'CostPoolSingle', N'CostPoolReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (66, 101, 10101, N'05', N'R', N'R0517', 15, N'A', N'A', N'A', N'A', N'Foreign Nationals Staying', N'ForeignNationalsStaying', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (67, 101, 10101, N'05', N'R', N'R0518', 16, N'A', N'A', N'A', N'A', N'Due Undertaking', N'Due_Undertaking', N'HotelReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (68, 101, 10101, N'03', N'R', N'R0316', 16, N'A', N'A', N'A', N'A', N'Cost Pool Op.P/L Group', N'CostPoolHead', N'CostPoolReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (69, 101, 10101, N'03', N'R', N'R0317', 17, N'A', N'A', N'A', N'A', N'List of Cost Pool', N'Get_ListofCostPool', N'ListReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (70, 101, 10101, N'03', N'R', N'R0318', 18, N'A', N'A', N'A', N'A', N'Head of Accounts', N'Get_HeadOfAccounts_List', N'ListReport', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (71, 101, 10101, N'05', N'F', N'F0511', 20, N'A', N'A', N'A', N'A', N'Floor Wise Plan', N'FloorPlan', N'Floor', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (72, 101, 10101, N'05', N'F', N'F0503', 21, N'A', N'A', N'A', N'A', N'Room Type Information', N'RoomTypeInformation', N'Room', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (73, 101, 10101, N'05', N'F', N'F0508', 22, N'A', N'A', N'A', N'A', N'Room Information', N'TypeWiseRoomInformation', N'Room', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (74, 101, 10101, N'05', N'F', N'F0504', 23, N'A', N'A', N'A', N'A', N'Floor Information', N'Floor', N'Floor', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (75, 101, 10101, N'05', N'F', N'F0505', 25, N'A', N'A', N'A', N'A', N'Bill Head Information', N'Index', N'BillHp', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (76, 101, 10101, N'05', N'F', N'F0506', 26, N'A', N'A', N'A', N'A', N'Complementary Item Information', N'Index', N'CItem', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (77, 101, 10101, N'05', N'F', N'F0501', 31, N'A', N'A', N'A', N'A', N'Guest-Refer Information', N'Create', N'GuesTrf', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (78, 101, 10101, N'05', N'F', N'F0502', 32, N'A', N'A', N'A', N'A', N'Guest-Company Information', N'Create', N'GuesTco', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
INSERT [dbo].[ASL_ROLE] ([ASL_ROLEId], [COMPID], [USERID], [MODULEID], [MENUTP], [MENUID], [SERIAL], [STATUS], [INSERTR], [UPDATER], [DELETER], [MENUNAME], [ACTIONNAME], [CONTROLLERNAME], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [UPDUSERID], [UPDTIME], [UPDIPNO]) VALUES (79, 101, 10101, N'05', N'F', N'F0514', 33, N'A', N'A', N'A', N'A', N'Bill Transfer', N'Index', N'BillTransfer', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ASL_ROLE] OFF
SET IDENTITY_INSERT [dbo].[ASL_SchedularCalendar] ON 

INSERT [dbo].[ASL_SchedularCalendar] ([Id], [COMPID], [USERID], [Title], [Text], [StartDate], [EndDate], [Status]) VALUES (1, 101, 10101, N'A', N'X', CAST(N'2017-02-15 00:01:00.000' AS DateTime), CAST(N'2017-02-15 23:59:00.000' AS DateTime), N'Active')
INSERT [dbo].[ASL_SchedularCalendar] ([Id], [COMPID], [USERID], [Title], [Text], [StartDate], [EndDate], [Status]) VALUES (2, 101, 10101, N'B', N'', CAST(N'2017-02-14 00:01:00.000' AS DateTime), CAST(N'2017-02-16 23:59:00.000' AS DateTime), N'Active')
SET IDENTITY_INSERT [dbo].[ASL_SchedularCalendar] OFF
SET IDENTITY_INSERT [dbo].[AslCompanies] ON 

INSERT [dbo].[AslCompanies] ([AslCompanyId], [COMPID], [COMPNM], [ADDRESS], [ADDRESS2], [CONTACTNO], [EMAILID], [WEBID], [STATUS], [EMAILIDP], [EMAILPWP], [SMSIDP], [SMSPWP], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (2, 101, N'Demo', N'Chittagong', N'Goal Pahar More', N'8801990000000', N'demo@gmail.com', NULL, N'A', NULL, NULL, NULL, NULL, N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:49:29.020' AS DateTime), N'192.168.10.101', N'22.3600949,91.82746069999999', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AslCompanies] OFF
SET IDENTITY_INSERT [dbo].[AslUsercoes] ON 

INSERT [dbo].[AslUsercoes] ([AslUsercoId], [COMPID], [USERID], [USERNM], [DEPTNM], [OPTP], [ADDRESS], [MOBNO], [EMAILID], [LOGINBY], [LOGINID], [LOGINPW], [TIMEFR], [TIMETO], [STATUS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (1, 1, 10001, N'Alchemy Software(Piash)', N'Admin', N'AslSuperadmin', N'Goal pahar,Suborna, 203/b,Chittagong', N'8801740545009', N'superadmin01@gmail.com', N'EMAIL', N'superadmin01@gmail.com', N'asl123s', N'00:00', N'23:59', N'A', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[AslUsercoes] ([AslUsercoId], [COMPID], [USERID], [USERNM], [DEPTNM], [OPTP], [ADDRESS], [MOBNO], [EMAILID], [LOGINBY], [LOGINID], [LOGINPW], [TIMEFR], [TIMETO], [STATUS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (2, 2, 10002, N'Alchemy Software(Shamim)', N'Admin', N'AslSuperadmin', N'Goal pahar, 203/b,Chittagong', N'8801775222222', N'superadmin02@gmail.com', N'EMAIL', N'superadmin02@gmail.com', N'asl123s', N'00:00', N'23:59', N'A', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[AslUsercoes] ([AslUsercoId], [COMPID], [USERID], [USERNM], [DEPTNM], [OPTP], [ADDRESS], [MOBNO], [EMAILID], [LOGINBY], [LOGINID], [LOGINPW], [TIMEFR], [TIMETO], [STATUS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (3, 101, 10101, N'Demo', N'Admin', N'CompanyAdmin', N'Chittagong', N'8801990000000', N'demo@gmail.com', N'EMAIL', N'demo@gmail.com', N'123', N'00:01', N'23:59', N'A', N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:50:24.570' AS DateTime), N'192.168.10.101', N'22.3600949,91.82746069999999', 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AslUsercoes] OFF
SET IDENTITY_INSERT [dbo].[GL_ACCHARMST] ON 

INSERT [dbo].[GL_ACCHARMST] ([ACCHARMSTId], [COMPID], [HEADTP], [HEADCD], [HEADNM], [REMARKS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (1, 101, 1, 101101, N'CASH', NULL, N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 14:52:21.397' AS DateTime), N'192.168.10.101', N'22.360178899999998,91.8274197', NULL, NULL, NULL, NULL)
INSERT [dbo].[GL_ACCHARMST] ([ACCHARMSTId], [COMPID], [HEADTP], [HEADCD], [HEADNM], [REMARKS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (2, 101, 1, 101101, N'CASH', NULL, N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:49:29.020' AS DateTime), N'192.168.10.101', N'22.3600949,91.82746069999999', NULL, NULL, NULL, NULL)
INSERT [dbo].[GL_ACCHARMST] ([ACCHARMSTId], [COMPID], [HEADTP], [HEADCD], [HEADNM], [REMARKS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (3, 101, 1, 101102, N'BANK', NULL, N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:49:29.020' AS DateTime), N'192.168.10.101', N'22.3600949,91.82746069999999', NULL, NULL, NULL, NULL)
INSERT [dbo].[GL_ACCHARMST] ([ACCHARMSTId], [COMPID], [HEADTP], [HEADCD], [HEADNM], [REMARKS], [USERPC], [INSUSERID], [INSTIME], [INSIPNO], [INSLTUDE], [UPDUSERID], [UPDTIME], [UPDIPNO], [UPDLTUDE]) VALUES (4, 101, 1, 101103, N'PARTY', NULL, N'DESKTOP-G8JI2VP', 10001, CAST(N'2017-02-15 15:49:29.020' AS DateTime), N'192.168.10.101', N'22.3600949,91.82746069999999', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[GL_ACCHARMST] OFF
