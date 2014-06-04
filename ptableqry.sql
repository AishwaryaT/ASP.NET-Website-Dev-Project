﻿/*
Deployment script for MyApplicationDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MyApplicationDB"
:setvar DefaultFilePrefix "MyApplicationDB"
:setvar DefaultDataPath "C:\Users\DELL\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\Projects\"
:setvar DefaultLogPath "C:\Users\DELL\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\Projects\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Table].[Id] (SqlSimpleColumn) will not be renamed to ssn';


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[Table]...';


GO
CREATE TABLE [dbo].[PatientTable] (
    [ssn]                      NVARCHAR (50)  NOT NULL,
    [PatientName]              NVARCHAR (50)  NULL,
    [VisitType]                NVARCHAR (50)  NULL,
    [VisitDate]                NVARCHAR (50)  NULL,
    [VisitLocation]            NVARCHAR (50)  NULL,
    [PrimaryInsurance]         NVARCHAR (50)  NULL,
    [Height]                   NVARCHAR (50)  NULL,
    [Weight]                   NVARCHAR (50)  NULL,
    [ReferredBy]               NVARCHAR (50)  NULL,
    [Followup]                 INT            NULL,
    [NoofMonth]                INT            NULL,
    [VisitRequired]            INT            NULL,
    [MedicalHistoryString]     NVARCHAR (150) NULL,
    [RiskFactorString]         NVARCHAR (150) NULL,
    [IncidentalFindingsString] NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([ssn] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
PRINT N'Update complete.';


GO
