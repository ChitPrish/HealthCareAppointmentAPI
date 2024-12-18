USE [master]
GO
/****** Object:  Database [HealthcareAppointment]    Script Date: 04-12-2024 01:19:36 ******/
CREATE DATABASE [HealthcareAppointment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthcareAppointment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HealthcareAppointment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HealthcareAppointment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HealthcareAppointment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthcareAppointment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthcareAppointment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthcareAppointment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthcareAppointment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthcareAppointment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthcareAppointment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET RECOVERY FULL 
GO
ALTER DATABASE [HealthcareAppointment] SET  MULTI_USER 
GO
ALTER DATABASE [HealthcareAppointment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthcareAppointment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthcareAppointment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthcareAppointment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HealthcareAppointment', N'ON'
GO
USE [HealthcareAppointment]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 04-12-2024 01:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[appointment_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NOT NULL,
	[healthcare_professional_id] [bigint] NOT NULL,
	[appointment_start_time] [datetime] NULL,
	[appointment_end_time] [datetime] NULL,
	[appointment_status] [int] NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[appointment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthcareProfessional]    Script Date: 04-12-2024 01:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthcareProfessional](
	[healthcare_professional_id] [bigint] NOT NULL,
	[healthcare_professionals_name] [varchar](100) NOT NULL,
	[specialty] [varchar](100) NULL,
 CONSTRAINT [PK_HealthcareProfessional] PRIMARY KEY CLUSTERED 
(
	[healthcare_professional_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04-12-2024 01:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[user_email] [varchar](100) NOT NULL,
	[password] [varchar](100) NULL,
	[created_date] [datetime] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([appointment_id], [user_id], [healthcare_professional_id], [appointment_start_time], [appointment_end_time], [appointment_status]) VALUES (1, 4, 1, CAST(N'2024-12-03T16:49:39.293' AS DateTime), CAST(N'2024-12-03T17:49:39.293' AS DateTime), 2)
INSERT [dbo].[Appointments] ([appointment_id], [user_id], [healthcare_professional_id], [appointment_start_time], [appointment_end_time], [appointment_status]) VALUES (2, 6, 2, CAST(N'2024-12-03T19:28:28.717' AS DateTime), CAST(N'2024-12-03T19:28:28.717' AS DateTime), 0)
INSERT [dbo].[Appointments] ([appointment_id], [user_id], [healthcare_professional_id], [appointment_start_time], [appointment_end_time], [appointment_status]) VALUES (3, 6, 3, CAST(N'2024-12-05T19:47:18.810' AS DateTime), CAST(N'2024-12-05T19:47:18.810' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
INSERT [dbo].[HealthcareProfessional] ([healthcare_professional_id], [healthcare_professionals_name], [specialty]) VALUES (0, N'test', N'dr dr')
INSERT [dbo].[HealthcareProfessional] ([healthcare_professional_id], [healthcare_professionals_name], [specialty]) VALUES (1, N'Dr. Max Doe', N'Sr. Heart Surgeon')
INSERT [dbo].[HealthcareProfessional] ([healthcare_professional_id], [healthcare_professionals_name], [specialty]) VALUES (2, N'Dr. Alex Carry', N'General Physician')
INSERT [dbo].[HealthcareProfessional] ([healthcare_professional_id], [healthcare_professionals_name], [specialty]) VALUES (3, N'Dr. Peter Brown', N'Pediatrician')
INSERT [dbo].[HealthcareProfessional] ([healthcare_professional_id], [healthcare_professionals_name], [specialty]) VALUES (5, N'Dr. Alen Dawn', N'E&T Sugeon')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_name], [user_email], [password], [created_date], [modified_date]) VALUES (1, N'Mark', N'mark@gmail.com', N'Mark@123', CAST(N'2024-11-30T08:08:00.000' AS DateTime), NULL)
INSERT [dbo].[Users] ([user_id], [user_name], [user_email], [password], [created_date], [modified_date]) VALUES (2, N'Scott', N'scott@gmail.com', N'Scott@234', CAST(N'2024-11-30T08:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Users] ([user_id], [user_name], [user_email], [password], [created_date], [modified_date]) VALUES (3, N'Sally', N'sally@gmail.com', N'Sally@345', CAST(N'2024-11-30T09:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Users] ([user_id], [user_name], [user_email], [password], [created_date], [modified_date]) VALUES (4, N'string1', N'string@wer.com', N'string2', CAST(N'2024-12-02T19:26:26.427' AS DateTime), CAST(N'2024-12-02T19:26:26.427' AS DateTime))
INSERT [dbo].[Users] ([user_id], [user_name], [user_email], [password], [created_date], [modified_date]) VALUES (6, N'chitra', N'chitra@gmail.com', N'chitra@123', CAST(N'2024-12-03T19:20:01.830' AS DateTime), CAST(N'2024-12-03T19:20:01.830' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_HealthcareProfessional] FOREIGN KEY([healthcare_professional_id])
REFERENCES [dbo].[HealthcareProfessional] ([healthcare_professional_id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_HealthcareProfessional]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Users]
GO
USE [master]
GO
ALTER DATABASE [HealthcareAppointment] SET  READ_WRITE 
GO
