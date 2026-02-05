using System;
using System.Collections.Generic;
using System.Text;

namespace Handy.Lib
{
    public static class CommonMsg
    {
        public static class Success
        {
            //Common
            public static string d_TotalTransaction = "\n" + "Total transaction(s) : {0}" + "\n" + "View remarks.";
            //Tag
            public static string ItemTagged = "Item has been Tagged.";
            public static string ItemUpdated = "Item has been Updated";
            public static string NewRR = "New RR created.";
            //Defrag
            public static string SuccessCoilDefrag = "Coil Defragging Successful.";
            //MIT
            public static string SuccessMIT = "Saving was successful.\nRR No : {0}\nActual Qty : {1}";
            //DP
            public static string DPNoCustomer = "D/P No: {0}\nCustomer: {1}.";
            public static string DPCompleted = "D/P No:\n{0}\nScanned items: {1}";
            //DR
            public static string DRCompleted = "D/R No:\n{0}\nScanned items: {1}";
            //Reclass
            /// <summary>
            /// Argument(s) [TagNo][NewClassDesc]
            /// </summary>
            public static string SuccessReclass = "Reprinting barcode label is required.\n\nTag No : {0}\nNew class : {1}";


            /////////////////////////
             //Common
            public static string d_LocalSave = "Locally saved only.";
            public static string d_DownloadComplete = "Download Complete.";
            public static string d_TransactionComplete = "Transaction Complete. View remarks.";
            /// <summary>
            /// Argument(s) [WRIS No]
            /// </summary>
            public static string d_WRISIssueComplete = "WRIS No : {0}"+"\n"+"All item(s) has been successfully issued.";
            public static string d_ViewRemarks = "Some of the Item(s) must be re-transacted. View remarks.";
            //Tag[Return Remarks]
            public static string d_S = "Transaction Fulfilled.";
            //Move
            //Issued
            //PickList
            /// <summary>
            /// Argument(s) [WRIS No]
            /// </summary>
            public static string d_FifoGenereationCommitted = "WRIS No: {0}"+"\n\n"+"FiFo Pick List Generation was successfully committed.";
            public static string d_PicklistCommitted = "WRIS No: {0}" + "\n\n" + "Pick List Generation was successfully committed.";
            //MIT
            public static string d_PostingInventorySuccess = "Posting inventory list was successful.";
            //Maintenance
            public static string d_SystemConfig = "Handy Database Configuration was successfully updated." + "\n" + "Application must be restarted to apply changes.";
            public static string d_TagFileClear = "Locator Tagging Local File was successfully cleared.";
            public static string d_MovementFileClear = "Stock Movement Local File was successfully cleared.";
            public static string d_MITFileClear = "Inventory Local File was successfully cleared.";
            public static string d_MITRollBack = "Inventory Local File rolled back.";
            public static string d_SetRegistryKey = "Setting Host Name was successful.";
            public static string d_TerminalNumberUpdate = "Terminal Number was successfully updated. \nTerminal Number: {0}";
            public static string d_FTPProcess = "FTP Setting/Process completed.";
            public static string d_GenerateInventoryMaster = "Generating local inventory reference list was successful.";
        }
        public static class Info
        {
            public static string SelectStockTypeforRM3 = "Please select stock code before generation";           
            public static string InventoryModifiedQuantity = "Modify.LabelQty:{0}";
            public static string InventoryHoldsDiffRR = "Old holds different NewRR.";
            public static string UncheckedStockCodeOfMachinery = "UNCHECK[MACHINERY - {0} ]";
            public static string DoesNotBelongToTheSelectedStockCodeForMachinery = "Please download Machinery - {0} stock materials. ";
            public static string Uncheckstockcodemessage = "Uncheck[Machinery - {0} ]";
            public static string ScannedItemIsForMachinery = "Scanned label is Machinery type material. \n\nPlease generate Machinery type reference list.";
            public static string InventoryIssued = "Issued.";
            public static string ScannedItemIsForSteel = "Scanned label is Steel type material. \n\nPlease generate Steel type reference list.";
            public static string ScannedWarehouseItem = "Scanned Item is for Warehouse : {0}. \n\nPlease generate {0} reference list.";
            public static string ScannedItemIsForGeneralStock = "Scanned label is General Stock type material. \n\nPlease generate General Stock type reference list.";
            //Tag
            public static string Locator = "Locator : {0}";
            //Scanned
            public static string d_ScanItem = "Scanning Item is required.";
            public static string ScannedLabelCount = "Total Scanned Label : {0}.";
            public static string RefreshCount = "Batch Count Refreshed.";
            public static string RRNo = "RR Number : \n{0}";
            public static string TagNo = "Tag Number : {0}";
            public static string ItemRemaing = "Item(s) Remaining.";
            //DP
            public static string ItemFulfilled = "Item Already Fulfilled";
            public static string StatusDP = "Status: For DP.";
            public static string StatusNotFound = "Status: Not Found";
            public static string StatusDR = "Status: For DR";
            public static string ItemScanned = "Item has been scanned.";
            public static string DataUpdated = "All data are updated.";
            public static string AlreadyConfirmed = "Status: Already Confirmed";
            public static string Cancelled = "Status: Cancelled";
            public static string NoRRDP = "DP No. does not contain any item";
            public static string Fulfilled = "Fulfilled";
            public static string NotAllItemsPosted = "Not all atems has been sent.\nAfter closing this message press [ENTER KEY] and retry posting remaining item(s).";
            public static string NotAllItemsPostedRetry = "Not all atems has been sent.\nAfter closing this message please retry posting remaining unsent item(s).";
            public static string NotAllItemsScanSent = "Scanned item(s) are still not posted.\nPlease press Yes to post pending item(s).";
            public static string NotAllItemsScanned = "Are you sure you want to exit? There are still remaining item(s) unscanned.";
            //Job
            public static string JSNo = "Job Sheet No: {0}";
            public static string DPNo = "D/P No: {0}";
            public static string JobResulted = "Job Sheet has been resulted";
            public static string JobStarted = "Job Sheet has been started";
            public static string JobNotApproved = "Job Sheet not yet approved";
            public static string JobCancelled = "Job Sheet has been cancelled";
            public static string JobCannotUnstart = "Job Sheet has been started and cannot be un-started since it has been partially resulted";
            public static string JobRevised = "Job Sheet has been revised";
            public static string DisplayStatus = "Undefined Status: {0}";
            //Inventory
            public static string InventoryLocator = "Inventory Locator : {0}";
            public static string InventoryGenerationInfo = "Are you sure want to continue local inventory reference list generation?\n\nThis will take for a while.\nGood signal status is necessary.";
            public static string issueditem = "ISSUED";
            public static string MismatchStockType = "MISMATCH [{0}]";
            //Inventory Remarks
            public static string InventoryOkay =         "Inventory Successful.";
            public static string InventoryNonExist =     "Inventory Table Non-Existing.";
            public static string InventoryUnretrieved =  "Data unable to retrieved.";
            public static string InventoryReprintLabel = "Reprint.";         
            public static string InventrySubjectForReprocessing = "Subject for reprocessing.";
            public static string BarcodeObsolete = "Obsolete";
            public static string BarcodeUpdated = "Latest Barcode";
            public static string UnitNotApplicable = "---";
            public static string LocatorUndefined = "000000"; //Hardcoded default locator
            //Common
            public static string ResetHandyDatabase = "Handy database version is not compatible to installed handy application version. Handy database will be reset.";

            #region Info Messages

            //Common
            /// <summary>
            /// Arguments [RRNoDisplay][StockCode][Qty]
            /// </summary>
            public static string d_RRCommonInfo = "\n" + "RR No. : {0}" + "\n" + "Stock Code : {1}" + "\n" + "Qty :{2}";
            //Tag
            public static string d_ScanLocator = "Scanning Locator is required.";
            //Move
            //Issued
            public static string d_ScanWRIS = "Scanning WRIS is required.";
            public static string d_ScanRR = "Scanning RR is required.";
            public static string d_ScanSM = "Scanning Transfer Number is required.";
            /// <summary>
            /// Argument(s) [SPECS]
            /// </summary>
            public static string d_Specs = "{0}";
            public static string d_NewWRISSplit = "New Split requisition was created.";
            //MIT
            //Maintenance
            public static string d_Offline = "Handy is now configured for offline mode connection.";
            public static string d_Online = "Handy is now configured for online mode connection.";

            #endregion
        }
        public static class Warning
        {
            //Scanned
            public static string RREmpty = "RRNo is Empty.";
            public static string QtyEmpy = "Input Quantity is Empty";
            public static string NoQty = "There is no Available Quantity";
            public static string InvalidQty = "Please Enter a Valid Quantity";
            public static string InvalidQtyExcess = "Quantity must not be greater than {0} Quantity Excessed.";
            public static string ItemCancelled = "Item has been cancelled.";
            public static string ItemWeightRevised = "Item weight is already revised. Please reprint barcode label.";
            public static string ItemTemp = "Item still have Temporary RR, please re-process and reprint barcode.";
            public static string ItemNotYetApproved = "Item is not yet approved";
            public static string ItemNotTagged = "Item is not yet tagged";
            public static string ItemDelivered = "Item has been delivered";
            public static string ItemIsUsed = "Item is already used";
            public static string ItemIssued = "Item is already issued";
            public static string d_ReprintCount = "{0} scanned barcode is required for reprinting.";
            public static string WarehouseMismatch = "Can't continue stockmovement between different warehouses.";
            /// <summary>
            /// Argument [SIGNAL]
            /// </summary>
            public static string d_NoSignal = "SIGNAL STATUS : {0}\n\nThere is no available network signal. Please wait when adapter becomes ready.";
            public static string d_PoorSignal = "SIGNAL STATUS : {0}\n\nPlease search better access point to avoid error during data transactions.";
            //Tag
            public static string ScanLocator = "Locator scanning is required.";
            public static string NoTaggingQty = "Transaction cannot continue because there is no assigned quantity for tagging on this item.";
            public static string d_NotifyNotSave = "Transaction is still not saved. Are you sure you want to cancel?";
            public static string d_ClearTagged = "Are you sure you want to clear tagged list?";
            public static string d_ClearExceededTagged = "Tagged list has numerous count already.\nDo you want to clear tagged list?";
            public static string d_TaglistExceeded = "Tagged list has numerous count already.\nPlease press enter button and clear tagged list.";
           //projectno
            public static string d_MismatchProjNo = "Project Number Mismatch." + "\n" + "Item Project No : {0}";
            
            //Issuance
            public static string d_WRISCANCELLED = "WRIS NO : {0}" + "\n" + "Status has been cancelled.";
            //Movement
            public static string NoMovementQty = "Transaction cannot continue because there are reserved or used quantity on this item.";
            public static string d_TRANSCANCELLED = "WRIS NO : {0}" + "\n" + "Status has been cancelled.";
            //DP
            public static string ScanDR = "DR scanning is required.";
            public static string ScanIssuance = "Issuance scanning is required.";
            public static string ScanDP = "D/P No. scanning is required.";
            public static string ScanDPPrompt = "Do you want to generate suggested latest tag numbers?\nThis may take for a while";
            public static string NotGenerated = "Status: Not Generated.";
            public static string ItemMismatch = "Item mismatch";
            public static string DPUnload = "D/P No: {0}\nCustomer: {1}\n To unload All, Press Unload.";
            public static string Unload = "Unload";
            public static string UnloadAll = "Are you sure you want to unload all items in D/P: {0} List?";
            public static string UnloadItem = "Are you sur    e you want to unload this item?";
            public static string LoadingNotComplete = "Loading not complete.";
            public static string CancelUnscanned = "Do you want to cancel {0} un-scanned item(s)?";
            public static string SupervisoryCancel = "Supervisory Cancellation";
            public static string ItemNotInList = "Tag No: {0} does not belong in the list of scanned {1}";
            public static string ScannedItemNotInList = "Scanned Item {0} does not belong in the list of scanned {1}";
            public static string DPItemMismatch = "Please Reprint Barcode. Specs has been revised.";
            public static string BarcodeNoSpecs = "Scanned label is already obsolete in the system.\nBarcode content has no Specs.";
            public static string DRUnposted = "There are still item(s) unposted. List window will be display. Please press post to verify scanned item(s).";
            //CD
            public static string ScanItem = "Item scanning is required.";
            public static string NoDeffragQty = "Transaction cannot continue because there are reserved or used quantity on this item.";
            //Adjustment
            public static string NoAdjustQty = "Transaction cannot continue because there are reserved or used quantity on this item.";
            //Job
            public static string ProvideJobPin = "You'll need to provide PIN to Unstart.";
            public static string ScanJS = "Jobsheet scanning required.";
            //Inventory
            public static string TryAgain = "Please try again. \n{0}.";
            public static string PleaseTryAgain = "Please try again.";
            public static string Reprint = "Need to be reprinted.";
            public static string d_Unsent = "UNSENT";
            public static string d_QClearMITFile = "Are you sure do you want to clear sent item(s) from Inventory List?";
            public static string d_RefreshInventoryCount = "Are you sure you want to refresh inventory scanned count?";
            public static string d_UnabletoRefreshScannedCount = "Pending items from inventory list must be posted before refreshing scanned count. Unable to refresh inventory scanned count.";
            public static string d_UnabletoClearMIT = "There are pending items on the list. Unable to clear Inventory file.";
            public static string d_AlreadyUsed = "Scanned item is already used in the system." + "\n" + "Item will be subject for inventory reprocessing.";
            public static string d_Reprint = "Scanned label is already obsolete in the system.\nRe-printing is required.";
            public static string d_ReplaceTagGroup = "Label replacement is required. It has been already processed to this Tag No(s).\n[{0}]";
            public static string d_QClearFile = "Are you sure you want to clear {0} file?";
            
            /// <summary>
            /// Argument [Tag No]
            /// </summary>
            public static string d_ReprintOutdated = "Scanned label is already obsolete in the system.\nRe-printing RR# \n[{0}-{1}-{2}-{3}] is required.";
            public static string d_UnableGenMITMaster = "Unable to generate local inventory reference list.";
            public static string d_UnableRefreshMITMaster = "Unable to renew local inventory reference list.";
            public static string d_PendingWarning = "Are you sure you want to exit inventory processing?\nThere are still pending items on inventory list.";
            public static string d_PendingMaxCountWarning = "There are already {0} pending items being scanned. Posting items from the list is necessary to prevent data queue.";
            //Reclassing
            /// <summary>
            /// Argument(s) [ClassDesc]
            /// </summary>
            public static string d_NonReclass = "{0} class is not valid for re-classing.";
            public static string d_SelectClass = "Please select new class from the list.";
            public static string d_SelectCustomer = "Please select customer from the list.";
            //Stock opening
            /// <summary>
            /// Argument(s) [ClassDesc]
            /// </summary>
            public static string d_NonValidOpening = "{0} class is not valid for stock packing opening.";
            //Common
            /// <summary>
            /// Arguments [System Required][Handy Version]
            /// </summary>
            public static string d_NewVersion = "New build version is already available.\nNew Version : {0}\nHandy Version   : {1}\nYou may continue or contact system admin for updating.";
            /// <summary>
            /// Arguments [System Required][Handy Version]
            /// </summary>
            public static string d_IncompatibleVersion = "System required version and Handy application version is incompatible.\nSystem Required : {0}\nHandy Version   : {1}\nPlease update handy application.";
            public static string d_UnabletoRetrieveSystemVersion = "Unable to retrieve system required version.";
            public static string d_UnabletoSetDeviceDateTime = "Unable to set device date time base on server date time.";
            #region Warning Messages

            //Common
            public static string d_RRNoEmpty = "RR Number is Empty.";
            public static string d_InputEmpty = "Input Quantity is Empty.";
            public static string d_NoAvailable = "There is no Available Quantity.";
            public static string d_NoAvailableRequestQty = "There is no more available request quantity for\nStock Code: {0}\nStock Name: {1}";
            public static string d_QuantityInvalid = "Please input a Valid Quantity.";
            public static string d_ClearFile = string.Format("Log file has exceeded to its maximum size.\nIt is advisable to clear transaction log file after posting.");
            /// <summary>
            /// Argument [QTY]
            /// </summary>
            public static string d_Excessed = "Quantity must not be greater than {0}. Quantity Excessed.";
            //Tag[Return remarks]
            public static string d_LX = "Locator is not existing.";
            public static string d_RL = "Item is already tagged.";
            public static string d_RX = "Unable to retrieve RR Info.";
            public static string d_RNU = "No remaining un-tag quantity.";
            public static string d_RIGU = "Input is greater than available quantity.";
            //Tag
            /// <summary>
            /// Argument(s) [Locator Desc]
            /// </summary>
            public static string d_AleadyTag = "Already tagged in this locator. [ {0} ]";
            //Move
            public static string d_RLC = "New and old locator are the same.";  // "New and Old Locator are the same.";
            public static string d_RNA = "No remaining quantity to transfer.";  // "Item doesn't have an available quantity to transfer.";
            /// <summary>
            /// Argument(s) [Reserve QTY][Issue QTY]
            /// </summary>
            public static string d_ReserveIssue = "\n\tReserved [{0:0.00}]  Issued [{1:0.00}]";
            public static string d_RIGA = "Input qty is greater than available qty."; //"Inputted quantity is greater than available quantity";
            public static string d_SPlit = "Item has been split. Need for reprinting.";
            //Issued[Return Remarks]
            public static string d_RU = "Item is un-tag.";
            public static string d_WX = "Unable to retrieve WRIS Info.";
            public static string d_WNR = "WRIS doesn't have Item with request quantity.";
            /// <summary>
            /// Argument [ITEM RESERVE QTY][WRIS RESERVE QTY]
            /// </summary>
            public static string d_WRX = "Reserved Qty Mismatch." + "\n" + "Item reserved [{0:0.00}] less than WRIS reserved [{1:0.00}]";
            /// <summary>
            /// Argument(s) [WRIS RESERVED QTY]
            /// </summary>
            public static string d_WRP = "Issued Qty Mismatch." + "\n\t" + "WRIS reserved [{0:0.00}]";
            public static string d_WRRP = "Selected item mismatch.";
            /// <summary>
            /// Argument(s) [ISSUED QTY][REQUEST QTY]
            /// </summary>
            public static string d_WRG = "Inputted issued QTY [{0:0.00}]." + "\n" + "Greater than WRIS Requested QTY [{1:0.00}]";
            /// <summary>
            /// Argument(s) [AVAILABLE QTY][RESERVED QTY][ISSUED ]
            /// </summary>
            public static string d_WRAX = "Item out of stock." + "\n" + "Available [{0:0.00}] Reserved [{1:0.00}] Issued [{2:0.00}]";
            public static string h_ItemMismatch = "Item Mismatch";
            /// <summary>
            /// Argument(s) [WRIS][RR]
            /// </summary>
            public static string d_RegenerateWRIS = "\n" + "WRIS No. : {0}" + "\n\n" + "RR No. : {1}" + "\n\n" + "Quantity mismatch. Please regenerate reservation.";
            /// <summary>
            /// Argument(s) [WRIS][RR][STOCKCODE]
            /// </summary>
            public static string d_WRISRR = "\n" + "WRIS No. : {0}" + "\n\n" + "RR No. : {1}" + "\n" + "Stock Code : {2}";
            /// <summary>
            /// Argument(s) [AVAILABLE QTY][RESERVED QTY][ISSUED ]
            /// </summary>
            public static string d_WRRX = "Inputted QTY is greater than available." + "\n" + "Available [{0:0.00}] Reserved [{1:0.00}] Issued [{2:0.00}]";
            public static string d_WG = "Unable to generate Pick List";
            public static string d_WXX = "Need for resending.";

            //Inventory
            public static string d_DownloadInventoryReference = "Please download first the inventory reference list before starting inventory scanning.";
            public static string d_DeleteInventoryData = "Are you sure you want to delete all inventory scanned items?";
            //Maintenance
            public static string d_NoDataSource = "Please provide Data Source.";
            public static string d_NoDatabase = "Please provide Database Name.";
            public static string d_NoUser = "Please provide User name.";
            public static string d_NoPassword = "Please provide Password.";

            public static string d_RadioIsDisabled = "WLAN Radio is not Available";
            public static string d_RadioIsDisabledPleasewait = "WLAN Adapter is not available this time, please wait while the system is trying to enable the WLAN Adapter";

            public static string d_DPRRMismatch = "\n" + "DP No.: {0} does not contain this item," + "\n" + "RR No.: {1}" + "\n" + "Stock Code: {2}";

            #endregion
            
        }

        public static class Error
        {
            public static string ServerDisconnected = "Unable to connect to server.";
            public static string DisableAdapter = "Please check network adapter.";
            public static string InventoryNotRetrieve = "Unable to retrieve barcode information from Inventory Database." + "\n" + "Item is not part of the Inventory of the Warehouse Generated.";
            public static string InventoryNotRetrieveRR = "Unable to retrieve RR Number information from database." + "\n" + "Please verify this data from the system." + "\n\n" + "RR No : {0}";
            public static string ItemnotFound = "Item Not Found.";
            public static string BarcodeInvalid = "Barcode not valid.";
            public static string ProcessUnable = "Unable to process. ";
            public static string FunctionNotFound = "Function not found";
            

            #region Error Messages
            //Common
            public static string d_UnabletoProcess = "Unable to process transaction.";
            public static string d_FunctionNotFound = "Function Not Found.";
            public static string d_AllfieldsRequired = "All field(s) are required to be filled up.";
            //Tag
            public static string d_Unsave = "Unable to save transaction.";
            //Move
            //Issued
            public static string d_NoInformation = "WRIS No : {0}" + "\n" + "There is no remaining requested item on the list.";
            public static string d_NoPickList = "WRIS No : {0}" + "\n" + "There is no remaining item un-generated request on the list.";
            //MIT
            //Maintenance
            public static string d_SystemConfig = "Unable to update Handy Database Configurations.";
            public static string d_TagFileClear = "Unable to clear Locator Tagging Local File.";
            public static string d_MovementFileClear = "Unable to clear Stock Movement Local File.";
            public static string d_MITFileClear = "Unable to clear Inventory Local File.";
            public static string d_MITRollBack = "Unable to roll back Inventory File.";
            public static string d_SetRegistryKey = "Unable to set Host Name";
            public static string InventoryListDownloadingRequired = "Please download the inventory reference list per stock type before proceeding to scanning.";
            public static string ItemalreadyIssued = "Item is already issued. \n\nThis will be subject for inventory investigation.";
            #endregion
        }
    }
}
