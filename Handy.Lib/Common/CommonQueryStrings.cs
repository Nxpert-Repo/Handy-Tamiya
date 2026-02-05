using System;
using System.Collections.Generic;
using System.Text;

namespace Handy.Lib
{
    //Nilo Added 01/11/2013 transfer all string queries here
    //to optimize commonfuction source code
    public static class CommonQueryStrings
    {
        #region Mobile

        public static class Mobile
        {
            /// <summary>
            /// This variable indicates the version of source code and existing handy database.
            /// </summary>
            public const string HandyDBVersion = "1.0.0.2";
            /// <summary>
            /// This variables indicates the client using handy db.
            /// </summary>
            public const string HandyDBProfile = "MMS";

            public static class Table
            {
                public const string Tagging = "Tagging";
                public const string TaggedList = "TaggedList";
                public const string StockMovement = "StockMovement";
                public const string StockReclass = "StockReclass";
                public const string Inventory = "Inventory";
                public const string InventoryReference = "InventoryMaster";
                public const string Defragging = "CoilDefragging";
                public const string Jobstart = "JobStart";
                public const string DeliveryPreparation = "DeliveryPreparation";
                public const string DeliveryReportReprint = "DeliveryReportReprint";
                public const string DeliveryChecklist = "DeliveryReport";
                public const string ScannedStatusList = "ScanStatus";
                //public const string WarehouseRequisition = "WarehouseRequisition";
            }

            public static class Create
            {
                #region Handy Database Version

                public const string HandyDatabaseVersion = @"CREATE TABLE HandyDatabaseVersion (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                                          Profile nvarchar(15)NOT NULL,
                                                                          Version nvarchar(15)NOT NULL,
                                                                          Activate nvarchar(1))";
                #endregion

                #region Tagging
                public const string Tagging = @"CREATE TABLE Tagging (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                RRNo nvarchar(12)NOT NULL , 
                                                RRSeqNo nvarchar(3)NOT NULL, 
                                                LotSeqNo nvarchar(3)NOT NULL,
                                                LocSeqNo nvarchar(3)NOT NULL,
                                                Quantity numeric(21,6),
                                                StockCode nvarchar(25),
                                                PrintedDateTime datetime,
                                                LocatorCode nvarchar(6),
                                                UntaggedQuantity numeric(21,6),                              
                                                RRStatus nvarchar(1), 
                                                ScanFlag int, 
                                                SentFlag int)";
                #endregion

                #region TaggedList
                public const string TaggedList = @"CREATE TABLE TaggedList (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                    RRNo nvarchar(12)NOT NULL , 
                                                    RRSeqNo nvarchar(3)NOT NULL, 
                                                    LotSeqNo nvarchar(3)NOT NULL,
                                                    LocSeqNo nvarchar(3)NOT NULL,
                                                    BarcodeQuantity numeric(21,6),
                                                    StockCode nvarchar(25),
                                                    PrintedDateTime datetime,
                                                    TagNo nvarchar(30), 
                                                    Quantity numeric(21,6),
                                                    LocatorCode nvarchar(6),
                                                    LocatorDesc nvarchar(25),   
                                                    Status nvarchar(1),                           
                                                    Remark nvarchar(25),
                                                    ScannedDateTime datetime,
                                                    ScanFlag int, 
                                                    SentFlag int)";
                #endregion

                #region StockMovement
                public const string StockMovement = @"CREATE TABLE StockMovement (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                    RRNo nvarchar(12)NOT NULL , 
                                                    RRSeqNo nvarchar(3)NOT NULL, 
                                                    LotSeqNo nvarchar(3)NOT NULL,
                                                    LocSeqNo nvarchar(3)NOT NULL,
                                                    Quantity numeric(21,6),
                                                    StockCode nvarchar(25),
                                                    PrintedDateTime datetime,
                                                    OldLocatorCode nvarchar(6), 
                                                    Locatorcode nvarchar(6), 
                                                    AvailableQty numeric(21,6),
                                                    RRStatus nvarchar(1), 
                                                    ScanFlag int, 
                                                    SentFlag int)";
                #endregion

//                #region PickList
//                public const string WarehouseRequisition = @"CREATE TABLE WarehouseRequisition (UniqueId int IDENTITY (0,1) PRIMARY KEY,
//                                                             WRISNo nvarchar(12) NOT NULL,
//                                                             ";
//                #endregion

                #region StockReclass
                public const string StockReclass = @"CREATE TABLE StockReclass 
                                                   (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                    RRNo nvarchar(12) NOT NULL , 
	                                                RRSeqNo nvarchar(3) NOT NULL,
	                                                LotSeqNo nvarchar(3) NOT NULL,
	                                                LocSeqNo nvarchar(3) NOT NULL,
	                                                StockCode nvarchar(25),
                                                    BarcodeQuantity numeric(21,6),
                                                    PrintedDateTime datetime,
                                                    TagNo nvarchar(30), 
	                                                StockType nvarchar(3),
                                                    StockClassCodeOld nvarchar(3),
                                                    StockClassCodeNew nvarchar(3),
                                                    OldClass nvarchar(50),
                                                    NewClass nvarchar(50),
                                                    AvailableQty numeric(21,6),
                                                    RRStatus nvarchar(1), 
	                                                LocatorCode nvarchar(6), 
	                                                LocatorcodeDesc nvarchar(25), 
	                                                Thickness numeric(18,6),
	                                                Width numeric(18,6),
	                                                Length numeric(18,6),
	                                                Specs nvarchar(30),
	                                                Unit nvarchar(3),
                                                    SentDateTime datetime,
                                                    ScanFlag int, 
                                                    SentFlag int)";
                #endregion

                #region Inventory
                public const string Inventory = @"CREATE TABLE Inventory (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                RRNo nvarchar(12) NOT NULL , 
                                                RRSeqNo nvarchar(3) NOT NULL,
                                                LotSeqNo nvarchar(3) NOT NULL,
                                                LocSeqNo nvarchar(3) NOT NULL,
                                                StockCode nvarchar(25),
                                                PrintedDateTime datetime,
                                                TagNo nvarchar(30), 
                                                OldLocatorCode nvarchar(6), 
                                                Locatorcode nvarchar(6), 
                                                LocatorcodeDesc nvarchar(25), 
                                                BalanceQuantity numeric(21,6),
                                                ActualQuantity numeric(21,6),
                                                Unit nvarchar(3),
                                                SentDateTime datetime,
                                                Transcated nvarchar(1),
                                                Remark nvarchar(100),
                                                ScanFlag int, 
                                                SentFlag int,
                                                ValidityType nvarchar(2),
                                                BatchNo int)";
                #endregion

                #region Inventory Reference Master
                public const string InventoryReference = @"CREATE TABLE InventoryMaster
		                                                    (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
		                                                    TagNo nvarchar(6),
		                                                    TagSeqNo nvarchar(3),
	                                                        RRNo nvarchar(12) NOT NULL , 
	                                                        RRSeqNo nvarchar(3) NOT NULL,
	                                                        LotSeqNo nvarchar(3) NOT NULL,
	                                                        LocSeqNo nvarchar(3) NOT NULL,
	                                                        StockCode nvarchar(25),
	                                                        StockType nvarchar(3),
	                                                        LocatorCode nvarchar(6), 
	                                                        LocatorcodeDesc nvarchar(25), 
	                                                        Thickness numeric(18,6),
	                                                        Width numeric(18,6),
	                                                        Length numeric(18,6),
	                                                        Specs nvarchar(30),
	                                                        Unit nvarchar(3),
	                                                        BalanceQuantity numeric(21,6),
	                                                        ActualQuantity numeric(21,6),
	                                                        Status nvarchar(1))";
                #endregion

                #region Defragging
                public const string Defragging = @"CREATE TABLE CoilDefragging (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                LocatorCode nvarchar(6), 
                                                LayerNo int, 
                                                LayerSeqNo int, 
                                                RRNo nvarchar(12)NOT NULL , 
                                                RRSeqNo nvarchar(3)NOT NULL, 
                                                LotSeqNo nvarchar(3)NOT NULL,
                                                LocSeqNo nvarchar(3)NOT NULL,
                                                Quantity numeric(21,6),
                                                StockCode nvarchar(25),
                                                PrintedDateTime datetime,
                                                RRStatus nvarchar(1),
                                                ScanFlag int, 
                                                SentFlag int)";
                #endregion

                #region Jobstart
                public const string Jobstart = @"CREATE TABLE JobStart (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                TagNo nvarchar(30)NOT NULL, 
                                                RRNo nvarchar(12)NOT NULL , 
                                                RRSeqNo nvarchar(3)NOT NULL, 
                                                LotSeqNo nvarchar(3)NOT NULL,
                                                LocSeqNo nvarchar(3)NOT NULL,
                                                Quantity numeric(21,6),
                                                StockCode nvarchar(25),
                                                PrintedDateTime datetime,
                                                ScanFlag int,
                                                SentFlag int)";
                #endregion

                #region Delivery Preparation
                public const string DeliveryPreparation = @"CREATE TABLE DeliveryPreparation (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                            DPNo nvarchar(12)NOT NULL,
                                                            TagNo nvarchar(30)NOT NULL,
                                                            RRNo nvarchar(12)NOT NULL,
                                                            RRSeqNo nvarchar(3)NOT NULL, 
                                                            LotSeqNo nvarchar(3)NOT NULL,
                                                            LocSeqNo nvarchar(3)NOT NULL,
                                                            LocatorCode nvarchar(6),
                                                            Quantity numeric(21,6),
                                                            StockCode nvarchar(25),
                                                            PrintedDateTime datetime,
                                                            LastProcessDesc nvarchar(35),
                                                            Customer nvarchar(19),
                                                            RRStatus nvarchar(1),
                                                            Status nvarchar(1),
                                                            ScanFlag int,
                                                            SentFlag int,
                                                            Specs nvarchar(25))";
                #endregion

                #region Delivery Report
                public const string DeliveryChecklist = @"CREATE TABLE DeliveryReport (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                          DRNo nvarchar(12)NOT NULL,
                                                          TagNo nvarchar(30)NOT NULL,
                                                          RRNo nvarchar(12)NOT NULL,
                                                          RRSeqNo nvarchar(3)NOT NULL, 
                                                          LotSeqNo nvarchar(3)NOT NULL,
                                                          LocSeqNo nvarchar(3)NOT NULL,
                                                          LocatorCode nvarchar(6),
                                                          Quantity numeric(21,6),
                                                          StockCode nvarchar(25),
                                                          PrintedDateTime datetime,
                                                          Customer nvarchar(19),
                                                          RRStatus nvarchar(1),
                                                          Status nvarchar(1),
                                                          ScanFlag int,
                                                          SentFlag int,
                                                          Specs nvarchar(25))";
                #endregion

                #region Delivery Report Reprint
                /// <summary>
                /// CE DeliveryReportReprint Table
                /// </summary>
                public const string DeliveryReportReprint = @"CREATE TABLE DeliveryReportReprint (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                              DRNo nvarchar(12)NOT NULL,
                                                              DRScannedDateTime datetime,
                                                              RRNo nvarchar(12)NOT NULL,
                                                              RRSeqNo nvarchar(3)NOT NULL, 
                                                              LotSeqNo nvarchar(3)NOT NULL,
                                                              LocSeqNo nvarchar(3)NOT NULL)";
                #endregion

                #region Scanned Status List
                public const string ScannedStatusList = @"CREATE TABLE ScanStatus (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                        ControlNo nvarchar(24)NOT NULL,
                                                        ItemCount int,
                                                        ScannedCount int,
                                                        SentCount int,
                                                        CompleteFlag int,
                                                        Process nvarchar(2))";
                #endregion

                #region Material Issuance
                public const string MaterialIssuance = @"CREATE TABLE MaterialIssuance (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                                        IssuanceNo nvarchar(12)NOT NULL,
                                                                        IssuanceType nvarchar(2)NOT NULL,
                                                                        IssuanceDesc nvarchar(30)NOT NULL,
                                                                        RRNo nvarchar(12)NOT NULL,
                                                                        RRSeqNo nvarchar(3)NOT NULL, 
                                                                        RRLotSeqNo nvarchar(3)NOT NULL,
                                                                        RRLocSeqNo nvarchar(3)NOT NULL,
                                                                        StockCode nvarchar(25),
                                                                        StockName nvarchar(25),
                                                                        StockSpecs nvarchar(25),
                                                                        LotCode nvarchar(30)NOT NULL,
                                                                        LocatorCode nvarchar(6),
                                                                        Quantity numeric(21,6),
                                                                        Unit nvarchar(3),
                                                                        PrintedDateTime datetime,
                                                                        RRStatus nvarchar(1),
                                                                        Status nvarchar(1),
                                                                        ScanFlag int,
                                                                        SentFlag int)";
                #endregion

                #region Material Issuance Reprint
                public const string MaterialIssuanceReprint = @"CREATE TABLE MaterialIssuanceReprint (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                              IssuanceNo nvarchar(12)NOT NULL,
                                                              IssuanceScannedDateTime datetime,
                                                              RRNo nvarchar(12)NOT NULL,
                                                              RRSeqNo nvarchar(3)NOT NULL, 
                                                              RRLotSeqNo nvarchar(3)NOT NULL,
                                                              RRLocSeqNo nvarchar(3)NOT NULL)";
                #endregion

                #region Material Transfer
                public const string MaterialTransfer = @"CREATE TABLE MaterialTransfer (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                                        TransferNo nvarchar(12)NOT NULL,
                                                                        TransferType nvarchar(30)NOT NULL,
                                                                        RRNo nvarchar(12)NOT NULL,
                                                                        RRSeqNo nvarchar(3)NOT NULL, 
                                                                        RRLotSeqNo nvarchar(3)NOT NULL,
                                                                        RRLocSeqNo nvarchar(3)NOT NULL,
                                                                        StockCode nvarchar(25),
                                                                        StockName nvarchar(25),
                                                                        StockSpecs nvarchar(25),
                                                                        LotCode nvarchar(30)NOT NULL,
                                                                        LocatorCode nvarchar(6),
                                                                        Quantity numeric(21,6),
                                                                        Unit nvarchar(3),
                                                                        PrintedDateTime datetime,
                                                                        RRStatus nvarchar(1),
                                                                        Status nvarchar(1),
                                                                        ScanFlag int,
                                                                        SentFlag int)";
                #endregion

                #region Material Transfer Reprint
                public const string MaterialTransferReprint = @"CREATE TABLE MaterialTransferReprint (UniqueId int IDENTITY (0,1) PRIMARY KEY,
                                                              TransferNo nvarchar(12)NOT NULL,
                                                              TransferScannedDateTime datetime,
                                                              RRNo nvarchar(12)NOT NULL,
                                                              RRSeqNo nvarchar(3)NOT NULL, 
                                                              LotSeqNo nvarchar(3)NOT NULL,
                                                              LocSeqNo nvarchar(3)NOT NULL)";
                #endregion

                public const string T_Tagging = @"CREATE TABLE T_Tagging (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                   Tag_RRNo nvarchar(12) NOT NULL  
                                                  ,Tag_RRSeqNo nvarchar(3) NOT NULL
                                                  ,Tag_LotSeqNo nvarchar(3) NOT NULL
                                                  ,Tag_LocSeqNo nvarchar(3) NOT NULL
                                                  ,Tag_StockCode nvarchar(25)
                                                  ,Tag_InputQty decimal(21,6)
                                                  ,Tag_AvailableQty decimal(21,6)
                                                  ,Tag_ReservedQty decimal(21,6)
                                                  ,Tag_IssuedQty decimal(21,6)
                                                  ,Tag_BarcodeQty decimal(21,6)
                                                  ,Tag_BarcodePrintedDate datetime
                                                  ,Tag_LocatorCode nvarchar(6)
                                                  ,Tag_LocatorDesc nvarchar(25)
                                                  ,Tag_Remark nvarchar(100) 
                                                  ,Tag_SentFlag int
                                                  ,Tag_UserCode nvarchar(15))";

                public const string T_Movement = @"CREATE TABLE T_Movement (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                   Mvt_RRNo nvarchar(12) NOT NULL  
                                                  ,Mvt_RRSeqNo nvarchar(3) NOT NULL
                                                  ,Mvt_LotSeqNo nvarchar(3) NOT NULL
                                                  ,Mvt_LocSeqNo nvarchar(3) NOT NULL
                                                  ,Mvt_StockCode nvarchar(25)
                                                  ,Mvt_InputQty decimal(21,6)
                                                  ,Mvt_AvailableQty decimal(21,6)
                                                  ,Mvt_ReservedQty decimal(21,6)
                                                  ,Mvt_IssuedQty decimal(21,6)
                                                  ,Mvt_BarcodeQty decimal(21,6)
                                                  ,Mvt_BarcodePrintedDate datetime
                                                  ,Mvt_LocatorCode nvarchar(6)
                                                  ,Mvt_LocatorDesc nvarchar(25)
                                                  ,Mvt_OldLocatorDesc nvarchar(25)
                                                  ,Mvt_Remark nvarchar(100) 
                                                  ,Mvt_SentFlag int
                                                  ,Mvt_UserCode nvarchar(15))";

                public const string T_Inventory = @"CREATE TABLE T_Inventory (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                    Inv_RRNo nvarchar(12) NOT NULL  
                                                   ,Inv_RRSeqNo nvarchar(3) NOT NULL
                                                   ,Inv_LotSeqNo nvarchar(3) NOT NULL
                                                   ,Inv_LocSeqNo nvarchar(3) NOT NULL
                                                   ,Inv_StockCode nvarchar(25)
                                                   ,Inv_BarcodePrintedDate datetime
                                                   ,Inv_LocatorCode nvarchar(6)
                                                   ,Inv_LocatorDesc nvarchar(25)
                                                   ,Inv_BalanceQty decimal(21,6)   
                                                   ,Inv_InputQty decimal(21,6)
                                                   ,Inv_SentDateTime datetime
                                                   ,Inv_UpdateTransDate nvarchar(1) NOT NULL
                                                   ,Inv_Remark nvarchar(100) 
                                                   ,Inv_SentFlag int
								     			   ,Inv_ValidityType nvarchar(2)
                                                   ,Inv_Stockname nvarchar(75)
                                                   ,Inv_Specs nvarchar(200))";

                public const string T_StockCodeInitial = @"CREATE TABLE T_StockCodeInitial (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                    Sci_Selected bit NOT NULL 
                                                   ,Sci_StockType nvarchar(3)
                                                   ,Sci_StockInitial nvarchar(1) NOT NULL
                                                   ,Sci_Count int NOT NULL)";

                public const string T_SteelGrave = @"CREATE TABLE T_SteelGrave (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                     Stg_RRNo nvarchar(12) NOT NULL  
                                                    ,Stg_RRSeqNo nvarchar(3) NOT NULL
                                                    ,Stg_LotSeqNo nvarchar(3) NOT NULL
                                                    ,Stg_LocSeqNo nvarchar(3) NOT NULL
                                                    ,Stg_StockCode nvarchar(25)
                                                    ,Stg_BarcodeQty decimal(21,6)
                                                    ,Stg_BarcodePrintedDate datetime
                                                    ,Stg_LotCode nvarchar(30)
                                                    ,Stg_SentFlag int
                                                    ,Stg_UserCode nvarchar(15))";

                public const string T_ReturnToInventory = @"CREATE TABLE T_ReturnToInventory (UniqueId int IDENTITY (0,1) PRIMARY KEY, 
                                                                                              Rti_RRNo nvarchar(12) NOT NULL  
                                                                                              ,Rti_RRSeqNo nvarchar(3) NOT NULL
                                                                                              ,Rti_LotSeqNo nvarchar(3) NOT NULL
                                                                                              ,Rti_LocSeqNo nvarchar(3) NOT NULL
                                                                                              ,Rti_WRISNo nvarchar(12) NOT NULL  
                                                                                              ,Rti_WRISSeqNo nvarchar(3) NOT NULL
                                                                                              ,Rti_WRISSplitSeqNo nvarchar(3) NOT NULL
                                                                                              ,Rti_WRISIssuedQty decimal(21,8)
                                                                                              ,Rti_Specs nvarchar(60)
                                                                                              ,Rti_Grade nvarchar(40) 
                                                                                              ,Rti_Block nvarchar(40)
                                                                                              ,Rti_ProjectNo nvarchar(12) 
                                                                                              ,Rti_StockName nvarchar(35) 
                                                                                              ,Rti_StockCode nvarchar(35) NOT NULL
                                                                                              ,Rti_StockType nvarchar(6) NOT NULL
                                                                                              ,Rti_ApprovedByID nvarchar(12) NOT NULL
                                                                                              ,Rti_ApprovedByName nvarchar(30) NOT NULL
                                                                                              ,Rti_ReviewedByID nvarchar(12) NOT NULL
                                                                                              ,Rti_ReviewedByName nvarchar(30) NOT NULL
                                                                                              ,Rti_ReceivedQty decimal(21,8)
                                                                                              ,Rti_QAQuantity decimal(21,8)
                                                                                              ,Rti_LotCode nvarchar(30)
                                                                                              ,Rti_TempRRNo nvarchar(12) 
                                                                                              ,Rti_TempRRSeqNo nvarchar(3)
                                                                                              ,Rti_TempRRSentFlag int
                                                                                              ,Rti_Remark nvarchar(100)
                                                                                              ,Rti_SentFlag int
                                                                                              ,Rti_UserCode nvarchar(15)
                                                                                              )";
            }

            public static class View
            {
                /// <summary>
                /// Arguments [count]
                /// </summary>
                public const string T_StockCodeInitialcount = @"SELECT count(1) [count]
                                                                  From T_StockCodeInitial";
                public const string T_StockCodeInitial = @"SELECT Sci_Selected [Selected]
                                                                 ,Sci_StockType [StockType]
                                                                 ,Sci_StockInitial [StockCodeInitial] 
                                                                 ,Sci_Count [Count]
                                                             FROM T_StockCodeInitial";


                /// <summary>
                /// Arguments [StockInitial]
                /// </summary>
                public const string T_StockCodeInitialAdd = @"SELECT Sci_StockInitial
                                                                FROM T_StockCodeInitial 
                                                               Where Sci_Selected = '1'";

                #region Handy Database Version

                public const string HandyDatabaseVersion = @"SELECT Profile,
                                                                    Version,
                                                                    Activate
                                                               FROM HandyDatabaseVersion
                                                              WHERE Profile = '" + HandyDBProfile + "'";

                #endregion

                public const string HandyVersionTable = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
                                                                  WHERE TABLE_TYPE='TABLE' 
                                                                    AND TABLE_NAME='HandyDatabaseVersion'";
          

                #region Taggedlist
                public const string TaggedList = @"SELECT RRNo , 
                                                          RRSeqNo , 
                                                          LotSeqNo ,
                                                          LocSeqNo ,
                                                          BarcodeQuantity ,
                                                          StockCode ,
                                                          PrintedDateTime ,
                                                          TagNo , 
                                                          Quantity ,
                                                          LocatorCode ,
                                                          LocatorDesc ,    
                                                          Status ,                          
                                                          Remark ,
                                                          ScannedDateTime ,
                                                          ScanFlag , 
                                                          SentFlag
                                                     FROM TaggedList
                                                   WHERE (TagNo <> '' OR LEN(LTRIM(RTRIM(TagNo)))<>0)
                                                    ORDER BY SentFlag,ScannedDateTime DESC,LocatorCode ASC, UniqueId DESC";

                #endregion

                #region Delivery Preparation

                public const string DPList = @"SELECT TagNo,
                                                      LocatorCode, 
                                                      LastProcessDesc, 
                                                      ScanFlag, 
                                                      SentFlag, 
                                                      DPNo, 
                                                      Customer,
                                                      Specs
                                                 FROM DeliveryPreparation 
                                             ORDER BY ScanFlag,
                                                      SentFlag,	
                                                      TagNo";

                #endregion

                #region StockReclass

                public const string StockReclass = @"SELECT RRNo , 
                                                            RRSeqNo ,
                                                            LotSeqNo ,
                                                            LocSeqNo ,
                                                            StockCode ,
                                                            BarcodeQuantity ,
                                                            PrintedDateTime ,
                                                            TagNo ,
                                                            StockType ,
                                                            StockClassCodeOld ,
                                                            StockClassCodeNew ,
                                                            OldClass ,
                                                            NewClass ,
                                                            AvailableQty ,
                                                            RRStatus ,
                                                            LocatorCode ,
                                                            LocatorcodeDesc ,
                                                            Thickness ,
                                                            Width ,
                                                            Length ,
                                                            Specs ,
                                                            Unit ,
                                                            SentDateTime ,
                                                            ScanFlag ,
                                                            SentFlag 
                                                       FROM StockReclass 
                                                      WHERE SentFlag = 0 
                                                   ORDER BY UniqueId";
                
                public const string StockReclassField = "SELECT {5} FROM {0} WHERE RRNo = '{1}' AND RRSeqNo = '{2}' AND LotSeqNo = '{3}' AND LocSeqNo = '{4}'";

                #endregion

                #region Inventory List

                public const string InventoryScannedCount = @"SELECT COUNT(RRNo)[COUNT] FROM Inventory";

                public const string InventoryPendingCount = @"SELECT COUNT(RRNo)[COUNT] FROM Inventory WHERE SentFlag = '0'";

                /// <summary>
                /// Argument [CommonQuery.Mobile.Table]
                /// </summary>
                public const string Count = @"SELECT COUNT(RRNo) FROM {0}";
                
                /// <summary>
                /// Return a query string to retrieve data from table Inventory.  
                /// </summary>
                /// <param name="All">All indicates whether to get all records or top x only.</param>
                /// <returns></returns>
                public static string InventoryList(bool All)
                {                   
                    string Query = string.Format(@"SELECT {0}
                                                         UniqueId
                                                        ,SentFlag
                                                        ,TagNo
                                                        ,RRNo +'-'+ RRSeqNo +'-'+ LotSeqNo +'-'+ LocSeqNo [RRNoDisplay]
                                                        ,OldLocatorCode
                                                        ,Locatorcode
                                                        ,LocatorcodeDesc
                                                        ,BalanceQuantity
                                                        ,ActualQuantity
                                                        ,Unit
                                                        ,SentDateTime
                                                        ,Remark
                                                        ,Transcated
                                                        ,PrintedDateTime
                                                    FROM Inventory
                                                  WHERE (TagNo<>'' OR LEN(LTRIM(RTRIM(TagNo)))<>0)
                                                    AND (Unit <> '' OR LEN(LTRIM(RTRIM(Unit)))<>0)
                                                   ORDER BY SentFlag
                                                        ,SentDateTime DESC
                                                        ,UniqueId DESC", All == true ? "" : "TOP 20");
                    return Query;
                }

                public const string InventoryUnsent = @"SELECT
                                                             RRNo
                                                            ,RRSeqNo
                                                            ,LotSeqNo
                                                            ,LocSeqNo
                                                            ,StockCode
                                                            ,PrintedDateTime
                                                            ,Locatorcode
                                                            ,BalanceQuantity
                                                            ,ActualQuantity
                                                            ,Remark
                                                            ,Transcated
                                                            ,SentDateTime
                                                            ,ValidityType
                                                        FROM Inventory
                                                       WHERE SentFlag='0'
                                                    ORDER BY SentFlag
                                                            ,UniqueId DESC";
                #endregion

                public const string T_SelectedStockCodeForMachinery = @"SELECT Sci_Selected [Selected]
                                                                              ,Substring(Sci_StockInitial,1,1) [Sci_StockInitial]
                                                                          FROM T_StockCodeInitial
                                                                         WHERE Sci_StockInitial = '{0}'
                                                                           AND Sci_Selected = '1'";
            }

            public static class ViewFiltered
            {
                public const string InventoryUnsentCount = @"SELECT COUNT(Inv_SentFlag)[COUNT] 
                                                               FROM T_Inventory 
                                                              WHERE Inv_SentFlag = '0'";

                #region Issuance
                public const string Issuance = @"StockCode = '{0}' AND
                                                 Wrd_RRNo+'-'+Wrd_RRSeqNo+'-'+Wrd_RRLotSeqNo+'-'+Wrd_RRLoc = '{1}' AND 
                                                 IssueStatus = 'G'";
                #endregion

                #region Tagging
                /// <summary>
                /// Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo]
                /// </summary>
                public const string LocatorTagingUnsent = @"SELECT * FROM Tagging 
                                                             WHERE SentFlag = 0
                                                               AND RRNo = '{0}' 
                                                               AND RRSeqNo = '{1}' 
                                                               AND LotSeqNo = '{2}' 
                                                               AND LocSeqNo = '{3}' 
                                                          ORDER BY UniqueId";

                public const string LocatorTagingUnsentAll = @" SELECT * 
                                                                  FROM Tagging 
                                                                 WHERE SentFlag = 0 
                                                              ORDER BY UniqueId";


                public const string TaggedListPendigCount = @"SELECT COUNT(1) [Count]
                                                                FROM TaggedList
                                                               WHERE SentFlag = 0";

                #endregion

                #region Movement


                public const string StockMovementUnsentAll = @"SELECT * 
                                                                 FROM StockMovement
                                                                WHERE SentFlag = 0  
                                                             ORDER BY UniqueId";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo]
                /// </summary>
                public const string StockMovementUnsent = @"SELECT * FROM StockMovement
                                                             WHERE SentFlag = 0 
                                                               AND RRNo = '{0}' 
                                                               AND RRSeqNo = '{1}' 
                                                               AND LotSeqNo = '{2}' 
                                                               AND LocSeqNo = '{3}' 
                                                          ORDER BY UniqueId";
                #endregion

                #region Deliver Report

                /// <summary>
                /// Query to indicate whether there are RR that need reprint. Arguments [RRNo][RRSeqNo][LotSeqNo][LocSeqNo][DRScannedDateTime] for DeliveryReportReprint table.
                /// </summary>
                public const string ChecklistRRIsReprint = @"SELECT 1
                                                               FROM DeliveryReportReprint
                                                              WHERE RRNo = '{0}'
                                                                AND RRSeqNo = '{1}'
                                                                AND LotSeqNo = '{2}'
                                                                AND LocSeqNo = '{3}'
                                                                AND DRScannedDateTime > '{4}'";

                public const string ChecklistUnsent = @"SELECT Distinct ControlNo 
                                                          FROM ScanStatus 
                                                         WHERE Process = 'DR'
                                                           AND ItemCount = ScannedCount 
                                                           AND SentCount < ItemCount";

                public const string IssuanceUnsent = @"SELECT Distinct ControlNo 
                                                          FROM ScanStatus 
                                                         WHERE Process = 'MI'
                                                           AND ItemCount = ScannedCount 
                                                           AND SentCount < ItemCount";


                public const string TransferUnsent = @"SELECT Distinct ControlNo 
                                                          FROM ScanStatus 
                                                         WHERE Process = 'MT'
                                                           AND ItemCount = ScannedCount 
                                                           AND SentCount < ItemCount";

                public const string ChecklistControlNolist = @"SELECT Distinct ControlNo 
                                                                 FROM ScanStatus 
                                                                WHERE Process = 'DR'";

                public const string IssuanceControlNolist = @"SELECT Distinct ControlNo 
                                                                 FROM ScanStatus 
                                                                WHERE Process = 'MI'";

                public const string TransferControlNolist = @"SELECT Distinct ControlNo 
                                                                 FROM ScanStatus 
                                                                WHERE Process = 'MT'";

                /// <summary>
                /// Argument [DRNo]
                /// </summary>
                public const string ChecklistRRUnpostCount = @"SELECT Count(SentFlag) 
                                                                 FROM DeliveryReport 
                                                                WHERE DRNo = '{0}' 
                                                                  AND SentFlag = 0";

                public const string ChecklistRRScannedUnpostCount = @"SELECT Count(SentFlag) 
                                                                        FROM DeliveryReport 
                                                                       WHERE DRNo = '{0}' 
                                                                         AND ScanFlag = 1 
                                                                         AND SentFlag = 0";

                public const string ChecklistRRUnscannedCount = @"SELECT Count(ScanFlag) [Unscanned] 
                                                                    From DeliveryReport 
                                                                   WHERE ScanFlag = 0 ";

                public const string ChecklisAlltUnpostCOunt = @"SELECT Count(SentFlag) [Unsent] 
                                                                  From DeliveryReport 
                                                                 WHERE SentFlag = 0";



                public const string IssuanceRRUnscannedCount = @"SELECT Count(ScanFlag) [Unscanned] 
                                                                    From MaterialIssuance 
                                                                   WHERE ScanFlag = 0 ";

                public const string IssuanceAllUnpostCOunt = @"SELECT Count(SentFlag) [Unsent] 
                                                                  From MaterialIssuance 
                                                                 WHERE SentFlag = 0";

                #endregion

                #region Delivery Preparation

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][LotSeqNo][LocSeqNo]
                /// </summary>
                public const string DPRRNoScannedStatus = @"SELECT DPNo, 
                                                                   ScanFlag 
                                                              FROM DeliveryPreparation
                                                             WHERE RRNo = '{0}' 
                                                               AND RRSeqNo = '{1}'
                                                               AND LotSeqNo = '{2}'
                                                               AND LocSeqNo = '{3}'";

                /// <summary>
                /// Argument [DPNo]
                /// </summary>
                public const string DPRRUnpostCount = "SELECT Count(SentFlag) FROM DeliveryPreparation WHERE DPNo = '{0}' AND SentFlag = 0";

                public const string DPRRScannedUnpostCount = "SELECT Count(SentFlag) FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 1 AND SentFlag = 0";

                public const string DPRRUnscannedCount = @"SELECT Count(ScanFlag) [Unscanned] From DeliveryPreparation WHERE ScanFlag = 0 ";

                public const string DPAlltUnpostCOunt = @"SELECT Count(SentFlag) [Unsent] From DeliveryPreparation WHERE SentFlag = 0";

                public const string DPUnsent = @"SELECT Distinct ControlNo 
                                                            FROM ScanStatus 
                                                           WHERE Process = 'DP'
                                                             AND ItemCount = ScannedCount 
                                                             AND SentCount < ItemCount";

                public const string DPControlNolist = @"SELECT Distinct ControlNo FROM ScanStatus WHERE Process = 'DP'";

                public const string DPGetSpecsofRRinfo = "SELECT RRNo,RRSeqNo,LotSeqNo,LocSeqNo,Specs FROM DeliveryPreparation WHERE RRNo = '{0}' AND RRSeqNo = '{1}' AND LotSeqNo = '{2}' AND LocSeqNo = '{3}'";

                public const string DPIssuance = @"StockCode = '{0}' AND
                                                 Wrd_RRNo+'-'+Wrd_RRSeqNo+'-'+Wrd_RRLotSeqNo+'-'+Wrd_RRLoc = '{1}' "; //AND IssueStatus = 'G'
                #endregion

                #region Delivery Check List

                     public const string DRGetSpecsofRRinfo = "SELECT RRNo,RRSeqNo,LotSeqNo,LocSeqNo,Specs FROM DeliveryReport WHERE RRNo = '{0}' AND RRSeqNo = '{1}' AND LotSeqNo = '{2}' AND LocSeqNo = '{3}'";

                #endregion 


                     #region MITMobileDBList
                     public const string MobileInventoryList = @"SELECT UniqueId [INDEX]
                                                                  ,Inv_StockCode [COLUMN_1]
                                                                  ,Inv_RRNo+'-'+Inv_RRSeqNo+'-'+Inv_LotSeqNo+'-'+Inv_LocSeqNo [COLUMN_2]
                                                                  ,Inv_InputQty [COLUMN_3]
                                                                  ,Inv_BalanceQty [COLUMN_4]
                                                                  ,Inv_BarcodePrintedDate [COLUMN_5]
                                                                  ,Inv_UpdateTransDate [COLUMN_6]
                                                                  ,Inv_SentFlag [COLUMN_7]
                                                                  ,Inv_SentDateTime [COLUMN_8]
                                                                  ,Inv_Remark [COLUMN_9]
                                                                  ,Inv_LocatorDesc [COLUMN_10]
                                                                  ,Inv_Stockname 
                                                                  ,Inv_Specs 
                                                                  ,Inv_LocatorCode
                                                              FROM T_Inventory
                                                                  {0}
                                                             ORDER BY Inv_SentFlag
                                                                  ,Inv_SentDateTime DESC
                                                                  ,UniqueId DESC";

                     #endregion

                #region Inventory
                 
                     #region MobileInventoryListForPosting
                     //ulysses added Inv_SentDateTime 11/21/13
                     public const string MobileInventoryListForPosting = @"SELECT Inv_RRNo
                                                                            ,Inv_RRSeqNo
                                                                            ,Inv_LotSeqNo
                                                                            ,Inv_LocSeqNo
                                                                            ,Inv_StockCode 
                                                                            ,Inv_BarcodePrintedDate
                                                                            ,Inv_LocatorCode
                                                                            ,Inv_BalanceQty                            
                                                                            ,Inv_InputQty
                                                                            ,Inv_Remark
                                                                            ,Inv_UpdateTransDate
                                                                            ,Inv_SentDateTime
                                                                            ,Inv_ValidityType
                                                                        FROM T_Inventory
                                                                       WHERE Inv_SentFlag = 0
                                                                    ORDER BY Inv_SentFlag
                                                                            ,UniqueId DESC";
                     #endregion


                #endregion
            }

            public static class Insert
            {
                #region Handy Database Version

                public static string HandyDatabaseVersion = string.Format(@"INSERT INTO HandyDatabaseVersion
                                                                                      (Profile ,
                                                                                       Version ,
                                                                                       Activate)
                                                                            VALUES('{0}','{1}','1')"
                                                                          , HandyDBProfile
                                                                          , HandyDBVersion);

                #endregion

                #region Tagging

                public const string Tagging = @"INSERT INTO {0} 
                                                      (RRNo, 
                                                       RRSeqNo, 
                                                       LotSeqNo, 
                                                       LocSeqNo, 
                                                       Locatorcode, 
                                                       Quantity, 
                                                       UntaggedQuantity, 
                                                       RRStatus, 
                                                       ScanFlag, 
                                                       SentFlag) 
                                                VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','Q', 1, 0)";

                #endregion

                #region TaggedList
                /// <summary>
                /// Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo][BarcodeQty][BarcodeStockCode][Printed][Tagno][InputQty][LocatorCode][LocatorDesc][Status][Remark][ScannedDate][ScanFlag][SentFlag]
                /// </summary>
                public const string TaggedList = @"INSERT INTO TaggedList
                                                        ( RRNo , 
                                                          RRSeqNo , 
                                                          LotSeqNo ,
                                                          LocSeqNo ,
                                                          BarcodeQuantity ,
                                                          StockCode ,
                                                          PrintedDateTime ,
                                                          TagNo , 
                                                          Quantity ,
                                                          LocatorCode ,
                                                          LocatorDesc ,    
                                                          Status ,                          
                                                          Remark ,
                                                          ScannedDateTime ,
                                                          ScanFlag , 
                                                          SentFlag )
                                                  VALUES('{0}','{1}','{2}', '{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')";
                #endregion

                #region Stock Movement
                /// <summary>
                ///Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo][InputQty][StockCode][Printed][OldLocator][NewLocator][AvailableQty][Status][Scan][Sent]
                /// </summary>
                public const string StockMovement = @"INSERT INTO StockMovement
                                                           ( RRNo  , 
                                                             RRSeqNo , 
                                                             LotSeqNo ,
                                                             LocSeqNo ,
                                                             Quantity ,
                                                             StockCode ,
                                                             PrintedDateTime ,
                                                             OldLocatorCode ,
                                                             Locatorcode ,
                                                             AvailableQty ,
                                                             RRStatus ,
                                                             ScanFlag ,
                                                             SentFlag )
                                                     VALUES('{0}','{1}','{2}', '{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')";
                #endregion

                #region Stock Reclass
                public const string StockReclass = @"INSERT INTO StockReclass
	                                                    (RRNo , 
                                                        RRSeqNo ,
                                                        LotSeqNo ,
                                                        LocSeqNo ,
                                                        StockCode ,
                                                        BarcodeQuantity ,
                                                        PrintedDateTime ,
                                                        TagNo ,
                                                        StockType ,
                                                        StockClassCodeOld ,
                                                        StockClassCodeNew ,
                                                        OldClass ,
                                                        NewClass ,
                                                        AvailableQty ,
                                                        RRStatus ,
                                                        LocatorCode ,
                                                        LocatorcodeDesc ,
                                                        Thickness ,
                                                        Width ,
                                                        Length ,
                                                        Specs ,
                                                        Unit ,
                                                        SentDateTime ,
                                                        ScanFlag ,
                                                        SentFlag)
                                                    VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')";
                #endregion

                #region Delivery Preparation

                public static string DeliveryPreparationRRList = @"   INSERT INTO DeliveryPreparation 
                                                                                ( TagNo
                                                                                , RRNo
                                                                                , RRSeqNo
                                                                                , LotSeqNo
                                                                                , LocSeqNo
                                                                                , RRStatus
                                                                                , Status
                                                                                , LocatorCode
                                                                                , LastProcessDesc
                                                                                , ScanFlag
                                                                                , SentFlag
                                                                                , Customer
                                                                                , DPNo
                                                                                , Specs)
                                                                          VALUES('{0}'
                                                                                ,'{1}'
                                                                                ,'{2}'
                                                                                ,'{3}'
                                                                                ,'{4}'
                                                                                ,'{5}'
                                                                                ,'{6}'
                                                                                ,'{7}'
                                                                                ,'{8}'
                                                                                ,'{9}'
                                                                                ,'{10}'
                                                                                ,'{11}'
                                                                                ,'{12}'
                                                                                ,'{13}')";

                #endregion

                #region Delivery Checklist

                public static string DeliveryReportRRList = @"INSERT INTO DeliveryReport 
                                                                                (TagNo
                                                                                , RRNo
                                                                                , RRSeqNo
                                                                                , LotSeqNo
                                                                                , LocSeqNo
                                                                                , RRStatus
                                                                                , Status
                                                                                , LocatorCode
                                                                                , ScanFlag
                                                                                , SentFlag
                                                                                , Customer
                                                                                , DRNo
                                                                                , Specs)
                                                                          VALUES('{0}'
                                                                                ,'{1}'
                                                                                ,'{2}'
                                                                                ,'{3}'
                                                                                ,'{4}'
                                                                                ,'{5}'
                                                                                ,'{6}'
                                                                                ,'{7}'
                                                                                ,'{8}'
                                                                                ,'{9}'
                                                                                ,'{10}'
                                                                                ,'{11}'
                                                                                ,'{12}')";

                #endregion

                #region Delivery Checklist Reprint

                /// <summary>
                /// Arguments [DRNo][DRScannedDateTime][RRNo][RRSeqNo][LotSeqNo][LocSeqNo][PrintedDateTime]
                /// </summary>
                public const string DeliveryCheckListReprint = @"INSERT INTO DeliveryReportReprint
                                                                            (DRNo ,
                                                                             DRScannedDateTime ,
                                                                             RRNo ,
                                                                             RRSeqNo ,
                                                                             LotSeqNo ,
                                                                             LocSeqNo)
                                                                      VALUES('{0}','{1}','{2}','{3}','{4}','{5}')";

                #endregion

                #region Material Issuance

                public static string MaterialIssuanceRRList = @"INSERT INTO MaterialIssuance
                                                                           (IssuanceNo
                                                                           ,IssuanceType
                                                                           ,IssuanceDesc
                                                                           ,RRNo
                                                                           ,RRSeqNo
                                                                           ,RRLotSeqNo
                                                                           ,RRLocSeqNo
                                                                           ,StockCode
                                                                           ,StockName
                                                                           ,StockSpecs
                                                                           ,LotCode
                                                                           ,LocatorCode
                                                                           ,Quantity
                                                                           ,Unit
                                                                           ,RRStatus
                                                                           ,Status
                                                                           ,ScanFlag
                                                                           ,SentFlag)
                                                                     VALUES
                                                                           ('{0}'
                                                                           ,'{1}'
                                                                           ,'{2}'
                                                                           ,'{3}'
                                                                           ,'{4}'
                                                                           ,'{5}'
                                                                           ,'{6}'
                                                                           ,'{7}'
                                                                           ,'{8}'
                                                                           ,'{9}'
                                                                           ,'{10}'
                                                                           ,'{11}'
                                                                           ,'{12}'
                                                                           ,'{13}'
                                                                           ,'{14}'
                                                                           ,'{15}'
                                                                           ,'{16}'
                                                                           ,'{17}')";

                #endregion

                #region Material Issuance Reprint

                /// <summary>
                /// Arguments [IssuanceNo][IssuanceScannedDateTime][RRNo][RRSeqNo][LotSeqNo][LocSeqNo][PrintedDateTime]
                /// </summary>
                public const string MaterialIssuanceReprint = @"INSERT INTO MaterialIssuanceReprint
                                                                           (IssuanceNo
                                                                           ,IssuanceScannedDateTime
                                                                           ,RRNo 
                                                                           ,RRSeqNo 
                                                                           ,RRLotSeqNo 
                                                                           ,RRLocSeqNo)
                                                                     VALUES('{0}','{1}','{2}','{3}','{4}','{5}')";

                #endregion

                #region Inventory
                /// <summary>
                /// Arguments  [RRNo][RRSeqNo][LotSeqNo][LocSeqNo][StockCode][PrintedDateTime][TagNo][OldLocatorCode][Locatorcode][LocatorcodeDesc][BalanceQuantity][ActualQuantity][Unit][SentDateTime][Transcated][Remark][ScanFlag][SentFlag][ValidityType
                /// </summary>
                public const string Inventory = @"INSERT INTO Inventory
	                                                   ( RRNo
                                                        ,RRSeqNo
                                                        ,LotSeqNo
                                                        ,LocSeqNo
                                                        ,StockCode
                                                        ,PrintedDateTime
                                                        ,TagNo
                                                        ,OldLocatorCode
                                                        ,Locatorcode
                                                        ,LocatorcodeDesc
                                                        ,BalanceQuantity
                                                        ,ActualQuantity
                                                        ,Unit
                                                        ,SentDateTime
                                                        ,Transcated
                                                        ,Remark
                                                        ,ScanFlag
                                                        ,SentFlag
                                                        ,ValidityType
                                                        ,BatchNo )
	                                            VALUES
	                                                  (  '{0}'
	                                                    ,'{1}'
	                                                    ,'{2}'
	                                                    ,'{3}'
	                                                    ,'{4}'
	                                                    ,'{5}'
	                                                    ,'{6}'
	                                                    ,'{7}'
	                                                    ,'{8}'
	                                                    ,'{9}'
	                                                    ,'{10}'
	                                                    ,'{11}'
	                                                    ,'{12}'
                                                        ,'{13}'
                                                        ,'{14}'
                                                        ,'{15}'
                                                        ,'{16}'
                                                        ,'{17}'
                                                        ,'{18}'
                                                        ,'1' )";
                public const string T_StockCodeInitial = @"INSERT 
                                                             INTO T_StockCodeInitial 
                                                                ( Sci_Selected ,
                                                                  Sci_StockType ,
                                                                  Sci_StockInitial ,
                                                                  Sci_Count ) 
                                                          VALUES( '0', '{0}', '{1}', '{2}')";


                public static string T_Inventory = @"INSERT 
                                                       INTO T_Inventory
		                                                  ( Inv_RRNo
		                                                   ,Inv_RRSeqNo
		                                                   ,Inv_LotSeqNo
		                                                   ,Inv_LocSeqNo
		                                                   ,Inv_StockCode
		                                                   ,Inv_InputQty
		                                                   ,Inv_BalanceQty
		                                                   ,Inv_BarcodePrintedDate
		                                                   ,Inv_UpdateTransDate
                                                           ,Inv_LocatorCode
		                                                   ,Inv_LocatorDesc
		                                                   ,Inv_Remark
		                                                   ,Inv_SentDateTime
		                                                   ,Inv_SentFlag
                                                           ,Inv_ValidityType
                                                           ,Inv_Stockname
                                                           ,Inv_Specs )
		                                        VALUES('{0}','{1}','{2}','{3}' ,'{4}' ,'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')";
                
                #endregion
            }

            public static class Update
            {
                #region Tagging

                public const string Tagging = @"UPDATE {0} 
                                                   SET UntaggedQuantity = '{1}', 
                                                       Quantity = '{2}', 
                                                       Locatorcode = '{3}', 
                                                       ScanFlag = 1, 
                                                       SentFlag = 0, 
                                                       RRStatus = 'Q'
                                                 WHERE RRNo = '{4}' 
                                                   AND RRSeqNo = '{5}' 
                                                   AND LotSeqNo = '{6}' 
                                                   AND LocSeqNo = '{7}' 
                                                   AND ScanFlag = 1";

                /// <summary>
                /// Arguments [TableName][LocatorCode][Quantity][RRNo][RRSeq][LotSeqNo][LocSeqNo]
                /// </summary>
                public const string TaggingSent = @"UPDATE {0} 
                                                       SET LocatorCode = '{1}', 
                                                           Quantity = '{2}', 
                                                           RRStatus = 'S', 
                                                           SentFlag = 1 
                                                     WHERE RRNo = '{3}' 
                                                       AND RRSeqNo = '{4}' 
                                                       AND LotSeqNo = '{5}' 
                                                       AND LocSeqNo = '{6}' 
                                                       AND ScanFlag = 1";

                #endregion

                #region TaggedList

                public const string TaggedListFlag = @"UPDATE TaggedList
                                                          SET Remark = '{4}',
                                                              SentFlag = '{5}'
                                                        WHERE RRNo = '{0}' 
                                                          AND RRSeqNo = '{1}'
                                                          AND LotSeqNo = '{2}' 
                                                          AND LocSeqNo = '{3}'";

                public const string TaggedListFlagAll = @"UPDATE TaggedList
                                                          SET Remark = '{0}',
                                                              SentFlag = '{1}'";
                /// <summary>
                /// Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo][BarcodeQty][BarcodeStockCode][Printed][Tagno][InputQty][LocatorCode][LocatorDesc][Status][Remark][ScannedDate][ScanFlag][SentFlag]
                /// </summary>
                public const string TaggedList = @"UPDATE TaggedList
                                                      SET RRNo = '{0}', 
                                                          RRSeqNo = '{1}', 
                                                          LotSeqNo = '{2}',
                                                          LocSeqNo = '{3}',
                                                          BarcodeQuantity = '{4}',
                                                          StockCode = '{5}',
                                                          PrintedDateTime = '{6}',
                                                          TagNo = '{7}', 
                                                          Quantity = '{8}',
                                                          LocatorCode = '{9}',
                                                          LocatorDesc = '{10}',    
                                                          Status = '{11}',                          
                                                          Remark = '{12}',
                                                          ScannedDateTime = '{13}',
                                                          ScanFlag = '{14}', 
                                                          SentFlag = '{15}'
                                                    WHERE RRNo = '{0}' 
                                                      AND RRSeqNo = '{1}'
                                                      AND LotSeqNo = '{2}' 
                                                      AND LocSeqNo = '{3}'";
                #endregion

                #region Stock Movement
                /// <summary>
                ///Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo][InputQty][StockCode][Printed][OldLocator][NewLocator][AvailableQty][Status][Scan][Sent]
                /// </summary>
                public const string StockMovement = @"UPDATE StockMovement
                                                         SET Quantity = '{4}' ,
                                                             StockCode = '{5}' ,
                                                             PrintedDateTime = '{6}' ,
                                                             OldLocatorCode = '{7}' ,
                                                             Locatorcode = '{8}' ,
                                                             AvailableQty = '{9}' ,
                                                             RRStatus = '{10}' ,
                                                             ScanFlag = '{11}' ,
                                                             SentFlag = '{12}' 
                                                       WHERE RRNo = '{0}' 
                                                         AND RRSeqNo = '{1}'
                                                         AND LotSeqNo = '{2}' 
                                                         AND LocSeqNo = '{3}'";
                #endregion


                public const string LocatorUpdate = @"DECLARE @warehouseCode CHAR(3)
                                                      SELECT @warehouseCode = Lmt_WarehouseCode FROM T_LocatorMaster WHERE Lmt_Locatorcode = '{4}'
                                                      UPDATE T_ReceivingReportDetail
                                                         SET Rrd_Locatorcode = '{4}',
                                                             Rrd_LocaQuantity = CASE WHEN ISNULL('{5}','0') = '0' THEN Rrd_LotQuantity ELSE '{5}' END,
                                                             Rrd_Taggeddate = GETDATE(),
                                                             User_Login = '{6}',
                                                             Rrd_WarehouseCode = @warehouseCode                                                   
                                                       WHERE Rrd_RRNo= '{0}' 
                                                         AND Rrd_RRSeqNo = '{1}'
                                                         AND Rrd_LotSeqno = '{2}' 
                                                         AND Rrd_RRlocseqno = '{3}'";
                #region Stock Class
                public const string StockReclass = @"UPDATE StockReclass
		                                                SET RRNo = '{0}' , 
                                                            RRSeqNo = '{1}' , 
                                                            LotSeqNo = '{2}' , 
                                                            LocSeqNo = '{3}' , 
                                                            StockCode = '{4}' , 
                                                            BarcodeQuantity = '{5}' , 
                                                            PrintedDateTime = '{6}' , 
                                                            TagNo = '{7}' , 
                                                            StockType = '{8}' ,
                                                            StockClassCodeOld = '{9}' ,
                                                            StockClassCodeNew = '{10}',
                                                            OldClass = '{11}' ,
                                                            NewClass = '{12}' , 
                                                            AvailableQty = '{13}' , 
                                                            RRStatus = '{14}' , 
                                                            LocatorCode = '{15}' , 
                                                            LocatorcodeDesc = '{16}' , 
                                                            Thickness = '{17}' , 
                                                            Width = '{18}' , 
                                                            Length = '{19}' , 
                                                            Specs = '{20}' , 
                                                            Unit = '{21}' , 
                                                            SentDateTime = '{22}' , 
                                                            ScanFlag = '{23}' , 
                                                            SentFlag = '{24}' 
	                                                  WHERE RRNo='{0}'
	                                                    AND RRSeqNo='{1}'
	                                                    AND LotSeqNo='{2}'
	                                                    AND LocSeqNo='{3}'";
                #endregion

                #region Inventory
                public const string Inventory = @"UPDATE Inventory
		                                             SET StockCode = '{4}'
                                                        ,PrintedDateTime = '{5}'
                                                        ,TagNo = '{6}'
                                                        ,OldLocatorCode = '{7}'
                                                        ,Locatorcode = '{8}'
                                                        ,LocatorcodeDesc = '{9}'
                                                        ,BalanceQuantity = '{10}'
                                                        ,ActualQuantity = '{11}'
                                                        ,Unit = '{12}'
                                                        ,SentDateTime = '{13}'
                                                        ,Transcated = '{14}'
                                                        ,Remark = '{15}'
                                                        ,ScanFlag = '{16}'
                                                        ,SentFlag = '{17}'
                                                        ,ValidityType = '{18}'
	                                               WHERE RRNo = '{0}'
	                                                 AND RRSeqNo = '{1}'
	                                                 AND LotSeqNo = '{2}'
	                                                 AND LocSeqNo = '{3}'";

                public const string AllUnsentAsPosted = @"UPDATE Inventory SET SentFlag = '1' WHERE SentFlag = '0'";

                #endregion

                #region Delivery Report

                /// <summary>
                /// Argumet DRNo
                /// </summary>
                public const string CheckListCompleteFlagCommit = @"UPDATE ScanStatus SET CompleteFlag = 1,ScannedCount = ItemCount WHERE ControlNo = '{0}'";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][LotSeqNo][LocSeqNo]
                /// </summary>
                public const string CheckListRRSentFlagCommit = @"Update DeliveryReport
                                                                     Set SentFlag = 1
                                                                   WHERE RRNo = '{0}' 
                                                                     AND RRSeqNo = '{1}' 
                                                                     AND LotSeqNo = '{2}' 
                                                                     AND LocSeqNo = '{3}'";

                public const string CheckListRRSentFlagCommit_Issuance = @"Update MaterialIssuance
                                                                     Set SentFlag = 1
                                                                   WHERE RRNo = '{0}' 
                                                                     AND RRSeqNo = '{1}' 
                                                                     AND RRLotSeqNo = '{2}' 
                                                                     AND RRLocSeqNo = '{3}'";

                #endregion

                #region Material Issuance

                /// <summary>
                /// Argumet IssuanceNo
                /// </summary>
                public const string IssuanceCompleteFlagCommit = @"UPDATE ScanStatus SET CompleteFlag = 1,ScannedCount = ItemCount WHERE ControlNo = '{0}'";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo]
                /// </summary>
                public const string IssuanceRRSentFlagCommit = @"Update MaterialIssuance
                                                                     Set SentFlag = 1
                                                                   WHERE RRNo = '{0}' 
                                                                     AND RRSeqNo = '{1}' 
                                                                     AND RRLotSeqNo = '{2}' 
                                                                     AND RRLocSeqNo = '{3}'";
                #endregion

                #region Material Transfer

                /// <summary>
                /// Argumet IssuanceNo
                /// </summary>
                public const string TransferCompleteFlagCommit = @"UPDATE ScanStatus SET CompleteFlag = 1,ScannedCount = ItemCount WHERE ControlNo = '{0}'";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][RRLotSeqNo][RRLocSeqNo]
                /// </summary>
                public const string TransferRRSentFlagCommit = @"Update MaterialTransfer
                                                                     Set SentFlag = 1
                                                                   WHERE RRNo = '{0}' 
                                                                     AND RRSeqNo = '{1}' 
                                                                     AND RRLotSeqNo = '{2}' 
                                                                     AND RRLocSeqNo = '{3}'";
                #endregion

                #region Delivery Preparation
                /// <summary>
                /// Arguments [RRNo][RRSeq][RRLotSeq][RRLocSeq][Quantity][PrintedDate][StockCode]
                /// </summary>
                public const string DPRRNoScanFlagCommit = @"UPDATE DeliveryPreparation 
                                                          SET ScanFlag = 1,
                                                              Quantity = '{4}',
                                                              PrintedDateTime = '{5}',
                                                              StockCode = '{6}'
                                                          WHERE RRNo = '{0}' 
                                                            AND RRSeqNo = '{1}'
                                                            AND LotSeqNo = '{2}'
                                                            AND LocSeqNo = '{3}'";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][LotSeqNo][LocSeqNo]
                /// </summary>
                public const string DPRRNoSentFlagCommit = @"Update DeliveryPreparation
                                                                            Set SentFlag = 1
                                                                            WHERE RRNo = '{0}' 
                                                                            AND RRSeqNo = '{1}' 
                                                                            AND LotSeqNo = '{2}' 
                                                                            AND LocSeqNo = '{3}'";

                /// <summary>
                /// Argumet DRNo
                /// </summary>
                public const string DPCompleteFlagCommit = @"UPDATE ScanStatus SET CompleteFlag = 1,ScannedCount = ItemCount WHERE ControlNo = '{0}'";
                
                #endregion

                #region Inventory
                public const string T_UpdateStockCodeInitial = @"UPDATE T_StockCodeInitial 
                                                                    SET Sci_Selected = '0'
                                                                  WHERE Sci_Selected = '1';";
                public const string T_Inventory = @"UPDATE T_Inventory
			                                           SET Inv_StockCode = '{4}' ,
	                                                       Inv_InputQty = '{5}' ,
	                                                       Inv_BalanceQty = '{6}' ,
	                                                       Inv_BarcodePrintedDate = '{7}' ,
	                                                       Inv_UpdateTransDate = '{8}' ,
                                                           Inv_LocatorCode  =  '{9}' ,
	                                                       Inv_LocatorDesc = '{10}' ,
	                                                       Inv_Remark = '{11}' ,
	                                                       Inv_SentDateTime = '{12}' ,
	                                                       Inv_SentFlag = '{13}' ,
                                                           Inv_ValidityType = '{14}' ,
                                                           Inv_Stockname = '{15}' ,
                                                           Inv_Specs = '{16}'
		                                             WHERE Inv_RRNo = '{0}'
		                                               AND Inv_RRSeqNo = '{1}'
		                                               AND Inv_LotSeqNo = '{2}'
		                                               AND Inv_LocSeqNo = '{3}'";

                public const string T_StockCodeInitial = @"UPDATE T_StockCodeInitial 
                                                              SET Sci_Selected = '{0}'
                                                            WHERE Sci_StockInitial = '{1}'";

#endregion
            }

            public static class Delete
            {
                public const string LocatorTagging = @"DELETE Tagging WHERE SentFlag = '1'";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][LotSeqNo][LocSeqNo]
                /// </summary>
                public const string LocatorTaggingSent = @"DELETE Tagging
                                                            WHERE RRNo = '{0}' 
                                                              AND RRSeqNo = '{1}'
                                                              AND LotSeqNo = '{2}' 
                                                              AND LocSeqNo = '{3}'";

                public const string LocatorTaggedList = @"DELETE TaggedList WHERE SentFlag = '1'";
                
                public const string StockMovement = @"DELETE StockMovement WHERE SentFlag = '1'";

                /// <summary>
                /// Arguments [RRNo][RRSeqNo][LotSeqNo][LocSeqNo]
                /// </summary>
                public const string StockMovementSent = @" DELETE StockMovement
                                                            WHERE RRNo = '{0}' 
                                                              AND RRSeqNo = '{1}'
                                                              AND LotSeqNo = '{2}' 
                                                              AND LocSeqNo = '{3}'";

                public const string InventoryScannedCount = @"UPDATE Inventory SET BatchNo = '0'";

                /// <summary>
                /// Argument [DRNo]
                /// </summary>
                public const string ChecklistSentItems = @"DELETE DeliveryReport WHERE DRNo = '{0}' AND SentFlag = '1'";


                /// <summary>
                /// Argument [IssuanceNo]
                /// </summary>
                public const string IssuanceSentItems = @"DELETE MaterialIssuance WHERE IssuanceNo = '{0}' AND SentFlag = '1'";

                /// <summary>
                /// Argument [TransferNo]
                /// </summary>
                public const string TransferSentItems = @"DELETE MaterialTransfer WHERE TransferNo = '{0}' AND SentFlag = '1'";

                /// <summary>
                /// Argument [DRNo]
                /// </summary>
                public const string ChecklistReprintItems = @"DELETE DeliveryReportReprint WHERE DRNo = '{0}'";

                /// <summary>
                /// Argument [DRNo]
                /// </summary>
                public const string IssuanceReprintItems = @"DELETE MaterialIssuanceReprint WHERE IssuanceNo = '{0}'";

                /// <summary>
                /// Argument [DRNo]
                /// </summary>
                public const string TransferReprintItems = @"DELETE MaterialTransferReprint WHERE DRNo = '{0}'";

                /// <summary>
                /// Argument [DPNo]
                /// </summary>
                public const string DPSentItems = @"DELETE DeliveryPreparation WHERE DPNo = '{0}' AND SentFlag = '1'";
                public const string T_Inventory = "DELETE T_Inventory";

                #region MITMobileDBListClear
                public const string MITMobileDBListClear = "DELETE T_Inventory WHERE Inv_SentFlag <> '0'";
                #endregion
            }

        }

        #endregion

        #region Remote
        public static class Remote
        {
            public static class View
            {
                #region Untag RR Number
                /// <summary>
                /// Argument [RRNumber]
                /// </summary>
                public const string UntagRRNumber = @"SELECT Header.Rrh_No 'RRNumber'
                                                            ,COUNT(Rrd_RRNo) 'Untagged'
                                                       FROM .dbo.T_ReceivingReportDetail Detail
                                                       JOIN .dbo.T_ReceivingReportHeader Header
                                                         ON  Rrd_RRNo = Rrh_No
		                                                 AND (Rrd_TaggedDate IS NULL)
		                                                 AND Rrd_RRNo NOT LIKE 'TEMP%'
		                                                 AND Rrd_status IN ('A','U')
		                                                 AND Rrh_Status = 'A'
		                                                 AND Rrd_LotQuantity > 0
		                                                 AND Rrd_RRNo IN ({0})
                                                       JOIN .dbo.T_StockTypeMaster
                                                          ON Stm_StockTypCode = Rrd_Stocktype
                                                         AND Stm_StockGroupCode IN('R','-') 
                                                    GROUP BY Rrd_RRNo
                                                            ,Detail.Rrd_TaggedDate
                                                            ,Detail.Rrd_RMDate
                                                            ,Detail.Rrd_status
                                                            ,Header.Rrh_No
                                                            ,Header.Rrh_Status
                                                    ORDER BY COUNT(Detail.Rrd_RRNo) DESC";

                #endregion

                #region Untag Tag Number

                public const string UntagTagNo = @"SELECT 
                                                         Rrd_RRNo RRNumber
                                                        ,Rrd_TagNo + '-' + Rrd_TagSeqNo TagNo
                                                   FROM .dbo.T_ReceivingReportDetail Detail
                                                   JOIN .dbo.T_ReceivingReportHeader Header
		                                              ON Rrd_RRNo = Rrh_No
		                                             AND (Rrd_TaggedDate IS NULL)
		                                             AND Rrd_RRNo NOT LIKE 'TEMP%'
                                                     AND Rrd_status IN ('A','U')
                                                     AND Rrh_Status = 'A'
                                                     AND Rrd_LotQuantity > 0
                                                     AND Rrd_RRNo IN ({0})
                                                   JOIN .dbo.T_StockTypeMaster
		                                              ON Stm_StockTypCode = Rrd_Stocktype
		                                             AND Stm_StockGroupCode IN('R','-') 
                                                ORDER BY Rrd_RRNo, 
                                                         Rrd_TagNo, 
                                                         Rrd_TagSeqNo";
                #endregion

                #region Customer List
                public const string CustomerList = @"SELECT [Ccm_CustomerCode] [CustomerCode]
                                                           ,[Ccm_CustomerShortname] [CustomerName]
                                                      FROM .[dbo].[T_CustomerCodeMaster]
                                                      WHERE [Ccm_status] = 'A'
                                                   ORDER BY [Ccm_CustomerShortname] ASC";
                #endregion

                #region Generc Master List

                public const string GenericMasterList = @"  SELECT Gmt_GenericDesc [SpecsDesc],
                                                                   Gmt_Genericcode [SpecsCode]
                                                              FROM T_GenericMaster
                                                             WHERE Gmt_Status = 'A' ";

                #endregion

                #region Stock Class Description List

                public const string StockClassDescList = @" SELECT Scm_StockClassDesc [ClassDesc],
                                                                   Scm_StockClassCode [ClassCode]
                                                              FROM E_StockClassMaster
                                                             WHERE Scm_Status = 'A' ";

                #endregion

                #region SystemRequiredVersion
                public const string SystemRequiredVersion = @"SELECT Apm_Version [Version] FROM T_ApplicationMaster WHERE Apm_ApplicationCode = 'HANDY'";
                #endregion

                #region Company Info
                public const string CompanyInformation = @"SELECT Scm_CompName
                                                                , Scm_CompAddress1
                                                                , Scm_CompAddress2
                                                                , Scm_CompAddress3
                                                                , Scm_TelephoneNos
                                                                , Scm_FaxNos,handyVer 
                                                            FROM .dbo.T_SystemControl";
                #endregion

                #region Handy Users
                public static string HandyUser()
                {
                    return @"SELECT Umt_Usercode,
                                    Umt_UserHandyPin 
                             FROM  .dbo.T_UserMaster
                              WHERE isnull(Umt_Usercode, '') <> ''
                                AND isnull(Umt_UserHandypin, '') <> ''";
                }
                #endregion                

                #region Stock Card
                public static string StockCardView(string stockcode)
                {
                    string query = string.Format(@"SELECT 
	                                                     Rrd_RRNo + '-' + Rrd_RRSeqNo + '-' + Rrd_LotSeqNo + '-' + Rrd_RRlocseqno [RR No]
	                                                     ,Rrd_locatorcode [Location]
	                                                     ,Rrd_LocaQuantity - Rrd_IssuedQTY [QTY]
                                                         ,Rst_StdIssuanceUnit [Unit]
                                                    FROM T_ReceivingReportDetail
                                                         JOIN T_ReceivingReportHeader
                                                            ON Rrh_No = Rrd_RRNo 
	                                                     JOIN T_LocatorMaster 
		                                                    ON Lmt_Locatorcode = Rrd_locatorcode
                                                         JOIN T_RawMaterialsAndSupplies
															 ON Rst_Stockcode = Rrd_StockCode
	                                                WHERE Rrd_LocaQuantity - Rrd_IssuedQTY > 0 
                                                          AND Rrd_status IN('A','U')
		                                                  AND Rrd_StockCode = '{0}'
                                                          AND Rrd_WarehouseCode = '000' ORDER BY Rrd_RRNo + '-' + Rrd_RRSeqNo + '-' + Rrd_LotSeqNo + '-' + Rrd_RRlocseqno", stockcode);

                    return query;

                }

                public static string getStockType()
                {
                    string query = string.Format(@"SELECT
                                                    [Sgm_StockGroupCode] [Type]
	                                                ,[Sgm_StockGroupDesc] [Desc]	
                                                FROM T_StockGroupMaster WHERE Sgm_Status = 'A'");
                    return query;
                }

                public static string getStocks(string type)
                {
                    string query = string.Format(@"SELECT
	                                                    [Stock Code] [Code]
	                                                    ,RTRIM([Stock Code]) + '-' + [Stock Name] [Name]
                                                    FROM V_CurrentInventory WHERE Type = '{0}'
                                                    GROUP BY 
	                                                    [Stock Code]
	                                                    ,[Stock Name]
                                                        ,RTRIM([Stock Code]) + '-' + [Stock Name]
                                                    ORDER BY [Stock Code]", type);
                    return query;

                }

                public static string getStockCodeFromBarcode(string rrBarcode)
                {
                    string query = string.Format(@"SELECT
	                                                  Rrd_Stocktype [Type]
	                                                 ,RTRIM(Rrd_StockCode) [Code]
	                                                FROM T_ReceivingReportDetail
	                                                WHERE Rrd_RRNo + '*' + Rrd_RRSeqNo + '*' + Rrd_LotSeqNo + '*' + Rrd_RRlocseqno = '{0}'", rrBarcode);
                    return query;

                }
                #endregion

            }

            public static class ViewFiltered
            {
                public static string InventoryGeneratedby(string UserCode)
                {
                    string Query = string.Format(@"SELECT CONVERT(VARCHAR,GETDATE(),107) [GeneratedDate]
	                                                                           ,Umt_userfname [FirstName]
	                                                                           ,Umt_userlname [LastName]
                                                                        FROM .dbo.T_UserMaster
                                                                        WHERE Umt_Usercode = '{0}'", UserCode);
                    return Query;
                }


                public static string spHandyGetMachineryList(CommonEnum.StockType StockType)
                {
                    string Query = string.Format(@"SELECT Mit_Stocktype [StockType]
	                                               , Substring(Mit_StockCode,1,1) [StockCodeInitial] 
                                                   , count(1) [Count] 
                                                   FROM T_MonthlyInventory
                                                   WHERE Mit_Stocktype = 'rm3'
                                                   GROUP BY Substring(Mit_StockCode,1,1),Mit_Stocktype
                                                   ORDER by Substring(Mit_StockCode,1,1) Asc", CommonEnum.GetStringValue(StockType));
                    return Query;
                }

              
                #region Dimension and Specs

                public static string Specification(string StockCode)
                {
                    return string.Format(@" SELECT Sse_StockCode,
                                                   ISNULL(Sse_Thickness,0) [Thickness],
                                                   ISNULL(Sse_Width,0) [Width],
                                                   ISNULL(Sse_Height,0) [Height],
                                                   ISNULL(Sse_Length,0) [Length],
                                                   ISNULL(Sse_Spec, '') [Specs]
                                              FROM E_SteelSpecificationExtension
                                             WHERE Sse_StockCode = '{0}'", StockCode);
                }

                #endregion
                #region Unit
                public static string GetUnit(string StockCode)
                {
                    return string.Format(@" SELECT distinct rst_stdbaseUnit
                                              FROM t_rawmaterialsandSupplies
                                             WHERE rst_StockCode = '{0}'", StockCode);
                }
                #endregion

                #region DeliveryPreparationStatus
                /// <summary>
                /// Argument [DP Number]
                /// </summary>
                public const string DeliveryPreparationStatus = @"WITH T AS (SELECT DISTINCT Dpd_ScanStatus [Status]
                                                                                        FROM T_DeliveryPreparationDetail
                                                                                       WHERE Dpd_DeliveryPreparationNumber = '{0}'
                                                                                         AND Dpd_Status <> 'C'
                                                                                         AND LTRIM(RTRIM(Dpd_RRNo)) <> ''
                                                                                         AND LTRIM(RTRIM(Dpd_RRSeqNo)) <> ''
                                                                                         AND LTRIM(RTRIM(Dpd_RRLotSeqNo)) <> ''
                                                                                         AND LTRIM(RTRIM(Dpd_RRLocSeqNo)) <> '')

                                                                         SELECT TOP 1 ISNULL([Status], 'N') FROM T
                                                                         ORDER BY CASE  WHEN [Status] = NULL THEN 1
                                                                                        WHEN [Status] = 'N' THEN 2 
                                                                                        WHEN [Status] = 'A' THEN 3
                                                                                        WHEN [Status] = 'S' THEN 4
                                                                                        ELSE 5 END";
                #endregion

                #region DeliveryChecklistStatus
                /// <summary>
                /// Argumet [DR Number]
                /// </summary>
                public const string DeliveryChecklistStatus = @"WITH T AS (SELECT DISTINCT Wrd_IssueStatus
                                                                                      FROM T_WarehouseRequisitionDetail
                                                                                      JOIN T_WarehouseRequisitionHeader
                                                                                        ON Wrh_WHReqControlNo = Wrd_WHReqControlNo
                                                                                       --AND Wrh_Reqtype in ('20','21','03')
                                                                                     WHERE Wrd_WHReqControlNo = '{0}'
                                                                                       AND Wrd_Status <> 'C')

                                                                            SELECT TOP 1 * FROM T 
                                                                             ORDER BY CASE WHEN Wrd_IssueStatus = 'N' THEN 1
					                                                                       WHEN Wrd_IssueStatus = 'G' THEN 2
					                                                                       WHEN Wrd_IssueStatus = 'A' THEN 3
					                                                                       WHEN Wrd_IssueStatus = 'S' THEN 4
					                                                                       ELSE 5 END";
                #endregion

                #region Locator Master
                public const string LocatorMaster = @"SELECT Lmt_Locatorcode ,
                                                             Lmt_Locatordesc ,
                                                             Lmt_status ,
                                                             Lmt_Warehousecode
                                                       FROM .dbo.T_LocatorMaster 
                                                       WHERE 
                                                Lmt_LocatorArea IN ('W','P') --DVM Changed ('W','S') to ('W','P') 20170614
                                                         AND Lmt_Status = 'A'
                                                         AND Lmt_Locatorcode='{0}'";
                #endregion

                #region StockMovementRRWarehouseMatching 
                public const string StockMovementRRWarehouseMatching = @"IF EXISTS(SELECT *
                                                                                     FROM T_ReceivingReportDetail
                                                                                LEFT JOIN T_LocatorMaster
                                                                                       ON Rrd_WarehouseCode = Lmt_WarehouseCode
                                                                                    WHERE Rrd_RRNo = '{1}'
                                                                                      AND Rrd_RRSeqNo = '{2}'
                                                                                      AND Rrd_LotSeqNo = '{3}'
                                                                                      AND Rrd_RRlocseqno = '{4}'
                                                                                      AND Lmt_Locatorcode = '{0}')
                                                                                  BEGIN SELECT 1 END
                                                                                  ELSE SELECT 0 ";
                #endregion

                #region PickList

                public const string WRIS_Table = @"SELECT dbo.GETStockName(Wrd_Stockcode, Wrd_StockTypeCode), *
                                                     FROM T_WarehouseRequisitionDetail                                                
                                                    WHERE Wrd_WHReqControlNo = '{0}'
                                                      AND Wrd_IssueStatus = 'N'
                                                      AND Wrd_Status = 'A'";

                public const string PickList_RRScanned = @"DECLARE @IssuedQty decimal(21,6) = '{4}'
                                                           SELECT dbo.GETStockName(Rrd_StockCode, Rrd_Stocktype) [Stock Name], Wrd_RequestedQty [Requested Quantity], CASE WHEN (Wrd_IssuedQty + @IssuedQty + Rrd_LocaQuantity) > Wrd_RequestedQty THEN Wrd_RequestedQty ELSE (Wrd_IssuedQty + Rrd_LocaQuantity) END [Issued Quantity]
                                                             FROM T_ReceivingReportDetail RRD
                                                             LEFT JOIN T_WarehouseRequisitionDetail WRD
                                                               ON Rrd_RRNo = Wrd_RRNo
                                                              AND Rrd_RRSeqNO = Wrd_RRSeqNo
                                                              AND Rrd_LotSeqNo = Wrd_RRLotSeqNo
                                                              AND Rrd_RRlocseqno = Wrd_RRlocseqno
                                                              AND Rrd_StockCode = Wrd_StockCode
                                                            WHERE Rrd_RRNo = '{0}'
                                                              AND Rrd_RRSeqNO = '{1}'
                                                              AND Rrd_LotSeqNo = '{2}'
                                                              AND Rrd_RRlocseqno = '{3}'";
                #endregion

//                #region Inventory Generated by
//                /// <summary>
//                /// Argument [USERCODE]
//                /// </summary>
//                public const string InventoryGeneratedby = @"SELECT CONVERT(VARCHAR,GETDATE(),107) [GeneratedDate]
//	                                                               ,Umt_userfname [FirstName]
//	                                                               ,Umt_userlname [LastName]
//                                                              FROM .dbo.T_UserMaster
//                                                              WHERE Umt_Usercode = '{0}'";
//                #endregion

                #region MaterialIssuanceStatus
                /// <summary>
                /// Argumet [DR Number]
                /// </summary>
                public const string MaterialIssuanceStatus = @"WITH T AS (SELECT DISTINCT Wrd_IssueStatus
                                                                                    FROM T_WarehouseRequisitionDetail
                                                                                    JOIN T_WarehouseRequisitionHeader
                                                                                      ON Wrh_WHReqControlNo = Wrd_WHReqControlNo
                                                                                   WHERE Wrd_WHReqControlNo = '{0}'
                                                                                     AND Wrd_Status <> 'C')

                                                                            SELECT TOP 1 * FROM T 
                                                                             ORDER BY CASE WHEN Wrd_IssueStatus = 'N' THEN 1
					                                                                       WHEN Wrd_IssueStatus = 'G' THEN 2
					                                                                       WHEN Wrd_IssueStatus = 'A' THEN 3
					                                                                       WHEN Wrd_IssueStatus = 'S' THEN 4
					                                                                       ELSE 5 
                                                                                      END";
                #endregion


                #region MaterialTransferStatus
                /// <summary>
                /// Argumet [DR Number]
                /// </summary>
                public const string MaterialTransferStatus = @"WITH T AS (SELECT DISTINCT Wtd_Status
                                                                                    FROM T_WarehouseTransferDetail
                                                                                    JOIN T_WarehouseTransferHeader
                                                                                      ON Wth_TransferNo = Wtd_TransferNo
                                                                                   WHERE Wtd_TransferNo = '{0}'
                                                                                     AND Wtd_Status <> 'C')

                                                                            SELECT TOP 1 * FROM T 
                                                                             ORDER BY CASE WHEN Wtd_Status = 'N' THEN 1
					                                                                       WHEN Wtd_Status = 'A' THEN 2
					                                                                       WHEN Wtd_Status = 'C' THEN 3
					                                                                       ELSE 4 
                                                                                      END";
                #endregion

                public static string ReceivingReportStockCodeList()
                {
                    string Query = string.Format(@"SELECT DISTINCT Rrd_Stocktype [Stocktype],
				                                                   Substring(Rrd_StockCode, 1 ,5)[StockCode]
                                                              FROM T_ReceivingReportDetail
                                                             WHERE Rrd_Stocktype = '{0}'
                                                               AND Rrd_RRNo not like 'T%' 
                                                            AND (Rrd_Stocktype LIKE 'RM%' OR Rrd_Stocktype LIKE 'FG%' OR Rrd_Stocktype LIKE 'C%')
                                                          ORDER by Rrd_Stocktype");
                    return Query;
                }
                public static string ReceivingReportStockCodeList(CommonEnum.Warehouse Warehouse)
                {
                    string Query = string.Format(@"SELECT DISTINCT Rrd_Stocktype [Stocktype],
				                                                  RTRIM(Rrd_StockCode)[StockCode],rrd_locatorcode locator
                                                                   ,lmt_warehousecode [warehouse]
                                                              from T_Receivingreportdetail
                                                              join T_LocatorMaster on Lmt_Locatorcode=Rrd_locatorcode
                                                              join T_WarehouseMaster on Lmt_WarehouseCode=Wmt_WarehouseCode
                                                             WHERE lmt_warehousecode = '{0}'
                                                               AND Rrd_RRNo not like 'T%'
                                                          ORDER by lmt_warehousecode"
                                                 , CommonEnum.GetStringValue(Warehouse));
                    return Query;
                }

                public static string IsRRTagged(string rrno, string rrseqno, string rrlotseqno, string rrlocseqno)
                {
                    string Query = string.Format(@"SELECT Rrd_TaggedDate
                                                     FROM T_ReceivingReportDetail
                                                    WHERE Rrd_RRNo = '{0}'
                                                      AND Rrd_RRSeqNo = '{1}'
                                                      AND Rrd_LotSeqNo = '{2}'
                                                      AND Rrd_RRlocseqno = '{3}'"
                                                , rrno
                                                , rrseqno
                                                , rrlotseqno
                                                , rrlocseqno);
                    return Query;
                }

                public static string GetCurrentRRAvailableQuantity(string rrno, string rrseqno, string rrlotseqno, string rrlocseqno)
                {
                    string Query = string.Format(@"SELECT Rrd_LocaQuantity
                                                     FROM T_ReceivingReportDetail
                                                    WHERE Rrd_RRNo = '{0}'
                                                      AND Rrd_RRSeqNo = '{1}'
                                                      AND Rrd_LotSeqNo = '{2}'
                                                      AND Rrd_RRlocseqno = '{3}'"
                                                , rrno
                                                , rrseqno
                                                , rrlotseqno
                                                , rrlocseqno);
                    return Query;
                }

                public static string GetStockName(string stockcode)
                {
                    string Query = string.Format(@"SELECT Rst_Stockname
                                                     FROM T_RawMaterialsAndSupplies
                                                    WHERE Rst_Stockcode = '{0}'
                                                      AND Rst_Status = 'A'"
                                                , stockcode);
                    return Query;
                }

                public static string GetStockSpecs(string stockcode)
                {
                    string Query = string.Format(@"SELECT Rst_StockSpecs
                                                     FROM T_RawMaterialsAndSupplies
                                                    WHERE Rst_Stockcode = '{0}'
                                                      AND Rst_Status = 'A'"
                                                , stockcode);
                    return Query;
                }
            }
        }

        public static class StoredProc
        { 
            public static string LocatorTagging(string RRNo,
                                                string RRSeq,
                                                string LotSeqNo,
                                                string LocSeqNo,
                                                string LocatorCode,
                                                string Quantity,
                                                string UserCode)
            {
                return string.Format(@"EXEC dbo.spHandyLocatorTagging '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'"
                                    , RRNo
                                    , RRSeq
                                    , LotSeqNo
                                    , LocSeqNo
                                    , LocatorCode
                                    , Quantity
                                    , UserCode);
                                    
            }

            public static string StockMovement(string RRNo,
                                               string RRSeq,
                                               string LotSeqNo,
                                               string LocSeqNo,
                                               string LocatorCode,
                                               string Quantity,
                                               string UserCode)
            {
                return string.Format(@"EXEC dbo.spHandyStockMovement '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'"
                                     , RRNo
                                     , RRSeq
                                     , LotSeqNo
                                     , LocSeqNo
                                     , LocatorCode
                                     , "000"
                                     , Quantity
                                     , UserCode);
            }
            public const string spHandyUpdateMonitoring = "EXEC spHandyUpdateMonitoring";

            public const string spHandyGetJobStartRRInfo = "EXEC spHandyGetJobStartRRInfo '{0}','{1}','{2}','{3}',{4}";

            public const string spHandyGetLocatorTaggingRRInfo = "EXEC spHandyGetLocatorTaggingRRInfo '{0}','{1}','{2}'";

            public const string spHandyGetStockMovementRRInfo = "EXEC spHandyGetStockMovementRRInfo '{0}','{1}','{2}','{3}'";

            public const string spHandyGetMaterialAdjustmentRRInfo = "EXEC spHandyGetMaterialAdjustmentRRInfo '{0}','{1}','{2}','{3}'";

            public const string spHandyGetReceivingReportInfo = "EXEC spHandyGetReceivingReportInfo '{0}','{1}','{2}','{3}'";

            public const string spHandyLocatorTagging = "EXEC dbo.spHandyLocatorTagging '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'";

            public const string spHandyStockMovement = "EXEC dbo.spHandyStockMovement '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8}";

            public const string spHandyMaterialAdjustment = "EXEC dbo.spHandyMaterialAdjustment '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'";

            public const string spHandyStockIssuance = "EXEC dbo.spHandyStockIssuance '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'";

            public const string spHandyMIT = "EXEC .dbo.spHandyMIT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'";

            public const string spHandyScannedLabelIndicator = "EXEC dbo.spHandyScannedLabelIndicator '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'";

            public const string spHandyGetStockIssueList = "EXEC spHandyGetStockIssueList '{0}'";
            //stockmovement
            public const string spHandyGetStockMovementBatchList = "EXEC spHandyGetStockMovementBatchList '{0}'";

            public const string spHandyGetStockIssueListWithProjNo = "EXEC spHandyGetStockIssueListWithProjNo '{0}'";

            public const string spHandyGetLocatorAvailableStock = "EXEC spHandyGetLocatorAvailableStock '{0}'";

            public const string spHandyUpdateMonitoringParametered = "EXEC spHandyUpdateMonitoring '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'";

            public const string spHandyGetMaterialInquiryRRInfo = "EXEC spHandyGetMaterialInquiryRRInfo '{0}','{1}','{2}','{3}'";

            public const string spHandyGetFifoPickList = "EXEC spHandyGetFifoPickList '{0}','{1}','{2}'";

            public const string spHandyPicklistAssignment = "EXEC spHandyPicklistAssignment '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}'";

            public const string spHandyGetRRReturnToInventoryInfo = "EXEC spHandyGetRRReturntoInventoryInfo '{0}','{1}','{2}','{3}'";

            public const string spHandyGetRRReturnToInventoryTempRR = "EXEC spHandyGetRRReturntoInventoryTempRRGenerate";

            public const string spHandyGetRTIUserLookUp = "EXEC spHandyGetRTIUserLookUp";

            public const string spHandyGetRTIWRISLookUp = "EXEC spHandyGetRTIWRISLookUp '{0}','{1}','{2}','{3}'";

            public const string spHandyGetRRReturnToInventoryProcess = "EXEC spHandyGetRRReturntoInventoryProcess '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'";

            //Delivery Preparation
            public const string spHandyGetProductIssueList = "EXEC spHandyGetProductIssueList '{0}'";
            public const string spHandyGetProductIssueListWithProjNo = "EXEC spHandyGetProductIssueListWithProjNo '{0}'";
            public const string spHandyProductIssuance = "EXEC dbo.spHandyProductIssuance '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'";

          
            #region Inventory

            public static string spHandyGetInventoryTable(CommonEnum.Warehouse Warehouse)
            {
                return spHandyGetInventoryTablex(Warehouse);
            }

            public static string spHandyGetInventoryTable(CommonEnum.Warehouse Warehouse, string InitialStockCode)
            {
                return string.Format("EXEC dbo.spHandyGetInventoryTable '{0}', '{1}'", CommonEnum.GetStringValue(Warehouse), InitialStockCode);
            }

            public static string spHandyGetInventoryTablex(CommonEnum.Warehouse Warehouse)
            {
                return string.Format("EXEC dbo.spHandyGetInventoryTable '{0}'", CommonEnum.GetStringValue(Warehouse));
            }

            #endregion
          
        }
        #endregion
    }
}
