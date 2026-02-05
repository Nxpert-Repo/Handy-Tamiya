using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Handy.Lib
{
    public class CommonEnum
    {
        /// <summary>
        /// Enumerates the handy functions
        /// </summary>
        public enum Function
        { 
            [StringValue("LocatorTagging")]
            LocatorTagging,
            [StringValue("StockMovement")]
            StockMovement,
            [StringValue("LocatorTagging")]
            StockReclass,
            [StringValue("StockPackingOpennig")]
            StockPackingOpennig,
            [StringValue("MaterialAdjustment")]
            MaterialAdjustment,
            [StringValue("CoilDefragging")]
            CoilDefragging,
            [StringValue("JobStart")]
			JobStart,
            [StringValue("DeliveryPreparation")]
            DeliveryPreparation,
            [StringValue("DeliveryChecklist")]
            DeliveryChecklist,
            [StringValue("Inventory")]
            Inventory,
            [StringValue("BarcodeTest")]
            BarcodeTest,
            [StringValue("Inquiry")]
            Inquiry,
            [StringValue("DisplayNewTags")]
            DisplayNewTags,
            [StringValue("MaterialIssuance")]
            MaterialIssuance,
            [StringValue("MaterialTransfer")]
            MaterialTransfer,
            [StringValue("Picklist")]
            Picklist,

        }
        public enum InventoryGenerationDisplay
        {
            [StringValue("panelGenerationInfo")]
            panelGenerationInfo,
            [StringValue("panelMachineryListView")]
            panelMachineryListView,
            [StringValue("panelRenewLogIn")]
            panelRenewLogIn
        }
        public enum StockType
        {
            [StringValue("C01")]
            BJT,
            [StringValue("C02")]
            MOSFET,
            [StringValue("C03")]
            TSTACK,
           [StringValue("C04")]
            MPOWER,
            [StringValue("C05")]
            IGBT,
            [StringValue("C06")]
            PSEN,
            [StringValue("CM1")]
            OTHERRAWMATERIAL,
            [StringValue("O01")]
            OEMBJT,
            [StringValue("O02")]
            OEMMOSFET,
            [StringValue("O03")]
            OEMTSTACK,
            [StringValue("O04")]
            OEMMPOWER,
            [StringValue("RM1")]
            DIRECTMATERIALS,
            [StringValue("RM2")]
            INDIRECTMATERIALS,
            [StringValue("RM3")]
            PACKAGINGMATERIALS1,
            [StringValue("RM4")]
            PACKAGINGMATERIALS2
          
              
        }

        // COMMENTED BY DEV1521-FRANCIS
        // MODIFIED TO FIT SPECS FOR NXPERTONE
        //public enum Warehouse
        //{
        //    [StringValue("MS2")]
        //    DefaultWarehouse,
        //    [StringValue("WFR")]
        //    WaferRoom,
        //    [StringValue("IP2")]
        //    IPMPSENMaterial,
        //    [StringValue("PS1")]
        //    ProductionFactory1,
        //    [StringValue("PS2")]
        //    ProductionFactory2,
        //    [StringValue("000")]
        //    OldWarehouse
        //}
        public enum Warehouse
        {            
            [StringValue("000")]
            StorageWarehouse,
            [StringValue("001")]
            HRMiniWarehouse,
            [StringValue("002")]
            GAMiniWarehouse,
            [StringValue("003")]
            CentralWarehouse,
            [StringValue("004")]
            CentralProcessing,
            [StringValue("PRD")]
            ProductionMiniWarehouse
        }


        
        public enum IssueStat : int
        {
            [StringValue("N")]
            New = 0,
            [StringValue("G")]
            Generate = 1,
            [StringValue("S")]
            Skip = 2,
            [StringValue("A")]
            Approve = 3
        }

        public enum Result
        {
            // Log IN
            EnterUser,
            EnterPIN,
            ServerNotFound,
            InvalidUser,
            InvalidPIN,
            OK,

            // linear, 2D and Locator Code
            is2D,
            InvalidCode,
            ValidCode,

            ////Defrag
            //Tagged,
            //Untagged
            Retry,
            Success
        }

        public enum BarcodeType : int
        {
            [StringValue("QRCODE")]
            QRCode = 11,  // Keyence
            //QRCode = 1,
            [StringValue("CODE39")]
            Code39 = 2
        }

        public enum StockClass : int
        {
            [StringValue("Mother Coil")]
            MotherCoil = 1,
            [StringValue("Coil Back")]
            CoilBack = 2,
            [StringValue("Semi-Product")]
            SemiProduct = 3,
            [StringValue("Product")]
            Product = 4,
            [StringValue("Mother Plate")]
            MotherPlate = 5,
            [StringValue("Returned")]
            Returned = 6,
        }

        public enum LabelType
        {
            Null,
            Item2D,             //Mother Coil or Coil Back
            ItemLinear,         //Semi-Product or Finished Goods
            LocatorCode,        //Locator Code
            JobSheetNo,         //Job Sheet No
            WIP,                //WIP
            WRISNo,             //WRIS No
            Invalid,            //Invalid Barcode
            ServerNotFound,     //Server Not Found
            IssuanceNo,         //WRIS No
            TransferNo,         //WRIS No

        }

        public enum MaterialAdjustmentProcess : int
        {
            [StringValue("E")]
            Excess = 1,
            [StringValue("W")]
            WriteOff = 2
        }

        public enum RRStatus : int
        {
            [StringValue("A")]
            Approved = 1,
            [StringValue("S")]
            Started = 2,
            [StringValue("G")]
            Generated = 3,
            [StringValue("N")]
            New = 4,
            [StringValue("E")]
            Error = 5,
            [StringValue("F")]
            Fulfilled = 6,
            [StringValue("P")]
            Prepared = 7,
            [StringValue("C")]
            Cancelled = 9,
            [StringValue("S")]
            Skipped = 10,
            [StringValue("T")]
            Temp = 11,
            [StringValue("R")]
            Reprint = 12,
            [StringValue("D")]
            Delivered = 13,
            [StringValue("R")]
            Revised = 14
        }

        public enum MessageButtons
        {
            Ok,
            OkCancel,
            YesNo,
            CloseOnly,
            RevertCancel,
            UnloadCancel,
            UnstartCancel
        }

        public enum ColorScheme
        {
            RedScheme, GreenScheme, BlueScheme, YellowScheme
        }

        public enum NotificationType
        {
            Default, Error, Warning, Information, Question, Success
        }

        public enum Buttons
        {
            Cancel,
            Exit,
            Ok,
            Save
        }

        public enum TextFocus
        {
            [StringValue("P")]
            Previous,
            [StringValue("N")]
            Next
        }

        public enum MaintenanceProcess
        {
            [StringValue("Database Settings")]
            DatabaseSettings,
            [StringValue("Host Name")]
            HostName,
            [StringValue("Log Files")]
            LogFiles,
            [StringValue("Handy Info")]
            HandyInfo,
            [StringValue("FTP")]
            FTP,
        }
        //Nilo Added 07/03/2012
        public enum UploadStats : int
        {
            [StringValue("0")]
            Pending = 0,
            [StringValue("1")]
            Sent = 1,
            [StringValue("2")]
            Redo = 2,
            [StringValue("3")]
            Saved = 3,
            [StringValue("4")]
            All = 4,
            [StringValue("5")]
            Reprint = 5,
            [StringValue("6")]
            Failed = 6,
            [StringValue("7")]
            AllValid = 7
        }

        public enum ScannedStatus
        {
            [StringValue("Pending")]
            Pending,
            [StringValue("Saved")]
            Saved,
            [StringValue("Sent")]
            Sent,
            [StringValue("Redo")]
            Redo,
            [StringValue("All")]
            All
        }

        //Nilo Added 09242012
        //Handy Signal Status
        public enum Signal : int
        {
            [StringValue("NONE")]
            NONE = 1,
            [StringValue("POOR")]
            POOR = 2,
            [StringValue("FAIR")]
            FAIR = 3,
            [StringValue("GOOD")]
            GOOD = 4,
            [StringValue("VERYGOOD")]
            VERYGOOD = 5,
            [StringValue("EXCELLENT")]
            EXCELLENT = 6
        }

        public enum ValidityType
        {
            [StringValue("00")]
            Success,   // naa sa mit
            [StringValue("01")]
            Reprint,   // naa bag.o na rr
            [StringValue("02")]
            InventoryNonExist,  // wala sa mit pero naa sa rr
            [StringValue("03")]
            Unretrieve,  // wala sa mit wala sa rr
            [StringValue("04")]
            Modified,  // [MMS]wala sa mit wala sa rr / [THI] For reprint because new qty is modified
         
            [StringValue("05")]
            Issued,  // [MMS]wala sa mit pero naa sa rr / [THI]not included from generation per stock type or not in mit
           [StringValue("06")]
            Deleted, // [THI] Not Selected Stock Code for machinery
           [StringValue("07")]
            Mismatch , // [MMS]wala sa mit wala sa rr / [THI] not included on the download
              [StringValue("08")]
           ForProcessing,
            [StringValue("09")]
            Unchecked // [THI] Not Selected Stock Code for machinery
        }
        /// <summary>
        /// Annotates the object such as enum with descriptive text
        /// </summary>
        public class StringValueAttribute : Attribute 
        {
            public string StringValue;
            public StringValueAttribute(string value) 
            {
                StringValue = value;
            }
        }
        /// <summary>
        /// Retrieves the StringValue attribute from the object
        /// </summary>
        /// <param name="value">The object value.</param>
        /// <returns>The StringValue attribute of the object value.</returns>
        public static string GetStringValue(object value) 
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
        /// <summary>
        /// Retrieves the StringValue attribute from Enum object
        /// </summary>
        /// <param name="value">The Enum object.</param>
        /// <returns>The StringValue attribute of the Enum object.</returns>
        public static string GetStringValue(Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

    }
}
