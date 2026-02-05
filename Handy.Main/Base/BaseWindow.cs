using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Handy.Lib;
//using Symbol.Fusion;
//using Symbol.Fusion.WLAN;
//using Symbol.Exceptions;


namespace Handy
{
    // Author : Nilo L. Luansing Jr.
    // Desc   : Base interface design and events
    //          for Window CE 6.0 and Symbol Barcode.
    // Date   : 07/17/2013
 
    //Design Generated is added for desktop compatibility inherittance.
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class BaseWindow : Form
    {
        MsgWindow MsgWin;

        public BaseWindow()
        {
            InitializeComponent();
            // for Keyence
            this.MsgWin = new MsgWindow();
        }

        #region Embeded Symbol Barcode Functions

        #region Barcode Variable
        public static bool EnableMultiScan = false; // for Keyence: flag to use multicode scanning
        protected BarcodeReader BCReader;
        protected ReaderData BCData;
        protected ReaderData BarcodeValue;
        protected String BarcodeTextData = "";
        protected bool GetRawBarcodeValue = false;
        protected EventHandler BCReadNotifyHandler = null;
        
        #endregion 

        /// <summary>
        /// Attaches handler when data is read, prepares barcode reader class and reader data class ready for scanning. Does not enable scanning action yet.
        /// </summary>
        /// <param name="BCReader"></param>
        /// <param name="BCData"></param>
        protected void SetBarcodeReader(BarcodeReader BCReader, ReaderData BCData)
        {
            this.BCReader = BCReader;
            this.BCData = BCData;
            this.BCReadNotifyHandler = new EventHandler(BarcodeReader_AnalyzeType);
            this.BarcodeReader_AttachReadNotify(BCReadNotifyHandler);
            this.BarcodeReader_Start();
        }

        /// <summary>
        /// Creates instances of barcode reader and reader data class. Does not enable scanning action yet.
        /// </summary>
        /// <returns></returns>
        protected bool BarcodeReader_Initialize()
        {
            bool _return = false;
            // If the reader is already initialized then fail the initialization.
            if (BCReader != null)
            {
                _return = false;
            }
            else // Else initialize the reader.
            {
                try
                {
                    BCReader = new BarcodeReader();
                    BCData = new ReaderData();
                    BCReader.Actions.Enable();

                    _return = true;
                }

                catch 
                {
                    _return = false;
                }
            }   
            return _return;
        }

        /// <summary>
        /// This function terminate and dispose use components of symber barcode reader.
        /// </summary>
        protected void BarcodeReader_Terminate()
        {
            // If we have a reader
            if (BCReader != null)
            {
                try
                {
                    BarcodeReader_Stop();

                    // Disable the reader.
                    BCReader.Actions.Disable();

                    // Free it up.
                    BCReader.Dispose();

                    // Make the reference null.
                    BCReader = null;
                }

                catch 
                {
                }
            }

            // After disposing the reader, dispose the reader data. 
            if (BCData != null)
            {
                try
                {
                    // Free it up.
                    BCData.Dispose();

                    // Make the reference null.
                    BCData = null;
                }

                catch 
                {
                }
            }
        }

        /// <summary>
        /// Allows device trigger to scan.
        /// </summary>
        protected void BarcodeReader_Start()
        {
            // If we have both a reader and a reader data
            if ((BCReader != null) &&
                (BCData != null))

                try
                {
                    if (!BCData.IsPending)
                    {
                        if (EnableMultiScan)
                            BarcodeReader.Enable_MultiScan();
                        else
                            BarcodeReader.Disable_MultiScan();
                        Bt.ScanLib.Control.btScanEnable();
                        // Submit a read. Must be called every time a read operation is to be made.
                        BCReader.Actions.Read(BCData);
                    }
                }

                catch 
                {
                }
        }

        /// <summary>
        /// Stops device trigger to scan.
        /// </summary>
        protected void BarcodeReader_Stop()
        {
            //If we have a reader
            if (BCReader != null)
            {
                try
                {
                    Bt.ScanLib.Control.btScanDisable();
                    // Flush (Cancel all pending reads).
                    if (BCReader.Info.SoftTrigger == true)
                    {
                        BCReader.Info.SoftTrigger = false;
                    }
                    BCReader.Actions.Flush();
                }
                catch 
                {
                }
            }
        }

        /// <summary>
        /// This function reads scanned barcode and identifies the defined NPAX barcode formats.
        /// Sets the value of variable ScannedBarcodeType.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            // Checks if the Invoke method is required because the ReadNotify delegate is called by a different thread
            if (this.InvokeRequired)
            {
                // Executes the ReadNotify delegate on the main thread
                this.Invoke(BCReadNotifyHandler, new object[] { Sender, e });
                return;
            }
            else
            {
                this.BarcodeTextData = "";
                // Fetches the ReaderData
                ReaderData TheReaderData = this.BCReader.GetNextReaderData();

                if (TheReaderData == null) 
                { 
                    TheReaderData.Result = Results.CANCELED;
                    return;
                }

                switch (TheReaderData.Result)
                {
                    // if it contains valid barcode
                    case Results.SUCCESS:
                        {
                            BarcodeReader_AnalyzeData(TheReaderData);
                            this.BarcodeReader_Start();
                        }
                        break;

                    case Results.E_SCN_READTIMEOUT:
                        {
                            this.BarcodeReader_Start();
                        }
                        break;

                    case Results.E_SCN_DEVICEFAILURE:

                        this.BarcodeReader_Stop();
                        this.BarcodeReader_Start();
                        break;

                    default:

                        string sMsg = "Read Failed\n"
                            + "Result = "
                            + (TheReaderData.Result).ToString();

                        CommonFunctions.MessageShow(sMsg);

                        if (TheReaderData.Result == Results.E_SCN_READINCOMPATIBLE)
                        {
                            // If the failure is E_SCN_READINCOMPATIBLE, exit the application.
                            CommonFunctions.MessageShow(Handy.Properties.Resources.AppExitMsg, Handy.Properties.Resources.Failure, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                            this.Close();
                            return;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Identifies the barcode type and populates the variables in CommonFunctions. 
        /// It saves the type in ScannedBarcodeType variable.
        /// </summary>
        /// <param name="BarcodeValue"></param>
        private void BarcodeReader_AnalyzeData(ReaderData BarcodeValue)
        {
            this.BarcodeValue = BarcodeValue;
            this.BarcodeTextData = BarcodeValue.Text;

            if (this.GetRawBarcodeValue)
            {
                //Reserve.
                //This settings is used when NPax predefined barcode
                //is not needed to identify. 
                //BarcodeValue is retrievable though.
            }
            else
            {
                this.ScannedBarcodeType = CommonFunctions.IdentifyBarcode(BarcodeValue.Text, BarcodeValue.Type.ToString());                
            }
        }        

        protected void BarcodeReader_AttachReadNotify(System.EventHandler ReadNotifyHandler)
        {
            // If we have a reader
            if (BCReader != null)
            {
                // Attach the read notification handler.
                BCReader.ReadNotify += ReadNotifyHandler;
                BCReadNotifyHandler = ReadNotifyHandler;
                // for Keyence
                MsgWin.ReadHandler = ReadNotifyHandler;
            }
        }

        private void BarcodeReader_DetachReadNotify()
        {
            if ((this.BCReader != null) && (BCReadNotifyHandler != null))
            {
                // Detach the read notification handler.
                this.BCReader.ReadNotify -= BCReadNotifyHandler;
                BCReadNotifyHandler = null;
                // for Keyence
                MsgWin.ReadHandler = null;
            }
        }

        #endregion

        #region Base Enumarates

        protected enum BaseButtons
        {
            /// <summary>
            /// Predefined handy buttons
            /// </summary>
            [CommonEnum.StringValue("OK")]
            Ok,
            [CommonEnum.StringValue("LOGIN")]
            Login,
            [CommonEnum.StringValue("SAVE")]
            Save,
            [CommonEnum.StringValue("START")]
            Start,
            [CommonEnum.StringValue("SCAN")]
            Scan,
            [CommonEnum.StringValue("DONE")]
            Done,
            [CommonEnum.StringValue("RENEW")]
            Renew,
            [CommonEnum.StringValue("OPEN")]
            Open,
            [CommonEnum.StringValue("RECLASS")]
            Reclass,
            [CommonEnum.StringValue("SELECT")]
            Select,
            [CommonEnum.StringValue("CLEAR")]
            Clear,
            [CommonEnum.StringValue("CANCEL")]
            Cancel,
            [CommonEnum.StringValue("EXIT")]
            Exit,
            [CommonEnum.StringValue("GENERATE")]
            Generate,
            [CommonEnum.StringValue("POST")]
            Post,
            [CommonEnum.StringValue("VIEW")]
            View,
            [CommonEnum.StringValue("HIDDEN")]
            Hidden,
            [CommonEnum.StringValue("LIST")]
            List
        }

        private enum ActiveButton
        {
            Left,
            Right
        }

        #endregion

        #region Private Variables

        private Int32 XPos = -1;
        private Int32 YPos = -1;

        #endregion

        #region Private Functions

        private void ShowHideBaseButtons(ActiveButton ActiveBttn, bool IsVisible)
        {
            try
            {
                switch (ActiveBttn)
                {
                    case ActiveButton.Left:
                        this.pnlButtonLeft.Visible = IsVisible;
                        this.pcbButtonLeft.Visible = IsVisible;
                        this.lblBtnLeft.Visible = IsVisible;
                        break;
                    case ActiveButton.Right:
                        this.pnlButtonRight.Visible = IsVisible;
                        this.pcbButtonRight.Visible = IsVisible;
                        this.lblBtnRight.Visible = IsVisible;
                        break;
                }
            }
            catch { }
        }

        private void SetBaseButtonCaption(LinkLabel BaseLabelButton, BaseButtons BaseButtonCaption)
        {
            try
            {
                BaseLabelButton.Text = CommonEnum.GetStringValue(BaseButtonCaption);
            }
            catch { }
        }

        private void ButtonKeyUpInterface(LinkLabel BaseLabelButton)
        {
            try
            {
                BaseLabelButton.BackColor = System.Drawing.Color.Teal;
            }
            catch { }
        }

        private void CaptureKeyUpEvent(object sender, Keys KeyCode)
        {
            switch (KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    this.ButtonKeyUpInterface(this.lblBtnLeft);
                    break;
                case Keys.F4:
                case Keys.F15:
                    if (this.CloseWindow.Equals(false))
                    {
                        this.ButtonKeyUpInterface(this.lblBtnRight);
                        //this.CloseWindow = true;
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
            }

            try
            {
                //This line allows form to always capture key event 
                //Jonel: should be placed in the initialization phase, not here :)
                this.KeyPreview = true;
            }
            catch { }
        }

        private void ButtonKeyDownInterface(LinkLabel BaseLabelButton)
        {
            try
            {
                BaseLabelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            }
            catch { }
        }

        private void CaptureKeyDownEvent(object sender, Keys KeyCode)
        {
            switch (KeyCode)
            {
                case Keys.F1:
                case Keys.F14:
                    this.ButtonKeyDownInterface(this.lblBtnLeft);
                    break;
                case Keys.F4:
                case Keys.F15:
                    this.ButtonKeyDownInterface(this.lblBtnRight);
                    break;
            }
        }

        #endregion

        #region Protected Variables

        /// <summary>
        /// This is the base variable used to identify scanned barcode type based on NPAX predefined types.
        /// </summary>
        protected CommonEnum.LabelType ScannedBarcodeType;

        /// <summary>
        /// This variable is use to indicate that current window will be closed.
        /// </summary>
        protected bool CloseWindow;

        #endregion

        #region Protected Functions

        /// <summary>
        /// This function is use to set current window title header.
        /// </summary>
        /// <param name="WindowTitle"></param>
        protected void SetWindowTitle(String WindowTitle)
        {
            try
            {
                this.lblWindowTitle.Text = WindowTitle.Trim().ToUpper();
                //Setting Baterry life interface icon
                CommonInterfaceFunctions.SetBatteryLifeInterface(this.pcbBatteryLife);
            }
            catch { }
        }

        /// <summary>
        /// This function will set the active left button only.
        /// </summary>
        /// <param name="BaseBtnLeft"></param>
        protected void SetLeftButton(BaseButtons BaseBtnLeft)
        {
            try
            {
                this.SetActiveButtons(BaseBtnLeft, BaseButtons.Hidden);
            }
            catch { }
        }

        /// <summary>
        /// This function will set the active right button only.
        /// </summary>
        /// <param name="BaseBtnRight"></param>
        protected void SetRightButton(BaseButtons BaseBtnRight)
        {
            try
            {
                this.SetActiveButtons(BaseButtons.Hidden, BaseBtnRight);
            }
            catch { }
        }

        /// <summary>
        /// This function will set both right and left active button.
        /// </summary>
        /// <param name="BaseBtnLeft"></param>
        /// <param name="BaseBtnRight"></param>
        protected void SetActiveButtons(BaseButtons BaseBtnLeft, BaseButtons BaseBtnRight)
        {
            // Jonel: Since there are only two cases, better to use if then else construct... :)
            switch (BaseBtnLeft)
            {
                case BaseButtons.Hidden: 
                    this.ShowHideBaseButtons(ActiveButton.Left, false);        // hide left button
                    break;
                default:
                    this.SetBaseButtonCaption(this.lblBtnLeft, BaseBtnLeft);   
                    break;
            }
            switch (BaseBtnRight)
            {
                case BaseButtons.Hidden: 
                    this.ShowHideBaseButtons(ActiveButton.Right, false);      // hide right button
                    break;
                default:
                    this.SetBaseButtonCaption(this.lblBtnRight, BaseBtnRight);
                    break;
            }

        }

        #endregion

        #region Protected Virtual Events

        protected virtual void lblBtnRight_Click(object sender, EventArgs e)
        {
            //Providing only the event handler
        }

        protected virtual void lblBtnLeft_Click(object sender, EventArgs e)
        {
            //Providing only the event handler
        }

        protected virtual void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            this.CaptureKeyUpEvent(sender, e.KeyCode);
        }
        #endregion

        //Events

        private void BaseWindow_Load(object sender, EventArgs e)
        {
            //CommonInterfaceFunctions.WLANCheck();
            //CommonInterfaceFunctions.WLANAddSignalQualityHandler(this.pcbSignal, true);
            //this.tmr_CaptureScreenTouch.Enabled = true;
        }

        private void BaseWindow_Closing(object sender, CancelEventArgs e)
        {
            //CommonInterfaceFunctions.WLANRemoveSignalQualityHandler(); //Relase wireless lan objects
            try
            {
                this.BarcodeReader_Stop();
                this.BarcodeReader_DetachReadNotify(); //Release barcode objects
            }
            catch { }
        }

        private void BaseWindow_KeyDown(object sender, KeyEventArgs e)
        {
            this.CaptureKeyDownEvent(sender, e.KeyCode);
        }

    }


        //-----------------------------------------------------------------------------------
        // Jonel
        // Code added for Keyence handy
        //-----------------------------------------------------------------------------------

    public class MsgWindow : Microsoft.WindowsCE.Forms.MessageWindow
        {
            public EventHandler ReadHandler = null;
            public MsgWindow()
            {
            }

            protected override void WndProc(ref Microsoft.WindowsCE.Forms.Message msg)
            {
                switch (msg.Msg)
                {
                    case (Int32)Bt.LibDef.WM_BT_SCAN:
                        // When reading is successful
                        if (msg.WParam.ToInt32() == (Int32)Bt.LibDef.BTMSG_WPARAM.WP_SCN_SUCCESS)
                        {
                            // save data to BarcodeReader
                            ReadBarcode();
                            // call user handler to fetch the data
                            if (ReadHandler != null)
                                ReadHandler(null, null);
                        }
                        break;
                    case (Int32)Bt.LibDef.WM_BT_WLAN:
                        if ((msg.WParam.ToInt32() == (Int32)Bt.LibDef.BTMSG_WPARAM.WP_WLAN_RSSI_LEVEL) || 
                        (msg.WParam.ToInt32() == (Int32)Bt.LibDef.BTMSG_WPARAM.WP_WLAN_SNR_LEVEL))
                        {
                            //btGetEventParams(
                            if (CommonInterfaceFunctions.SignalQualityHandler != null)
                                CommonInterfaceFunctions.SignalQualityHandler(new object(), new StatusChangeArgs());
                        }
                        break;
                }
                base.WndProc(ref msg);
            }

            private void ReadBarcode()
            {
                ReaderData dataReader = null;
                Int32 ret = 0;

                Int32 resultCount = 0;
                Byte[] codedataGet;
                Int32 codeLen = 0;
                Bt.LibDef.BT_SCAN_REPORT stReportGet = new Bt.LibDef.BT_SCAN_REPORT();
                Bt.LibDef.BT_SCAN_QR_REPORT stQrReportGet = new Bt.LibDef.BT_SCAN_QR_REPORT();

                try
                {
                    resultCount = Bt.ScanLib.Control.btScanGetResultCount();                    
                    // When code has been read
                    if (resultCount > 0)
                    {
                        //-----------------------------------------------------------
                        // Reading (individual)
                        //-----------------------------------------------------------
                        UInt16 i;
                        BarcodeReader.BCDataList.Clear();
                        //CommonFunctions.MessageShow(string.Format("Number of barcodes: {0}", resultCount));
                        for (i = 0; i < resultCount; i++)
                        {
                            codeLen = 0;
                            codeLen = Bt.ScanLib.Control.btScanGetDataSize(i);
                            if (codeLen <= 0)
                                goto L_END;
                            codedataGet = new Byte[codeLen];

                            // btScanGetData
                            stReportGet = new Bt.LibDef.BT_SCAN_REPORT();
                            stQrReportGet = new Bt.LibDef.BT_SCAN_QR_REPORT();
                            ret = Bt.ScanLib.Control.btScanGetData(i, codedataGet, ref stReportGet, ref stQrReportGet);
                            if (ret != Bt.LibDef.BT_OK)
                                goto L_END;
                            dataReader = new ReaderData();
                            dataReader.RawData = codedataGet;
                            dataReader.Type = stReportGet.codetype;
                            dataReader.Result = Results.SUCCESS;
                            dataReader.IsPending = false;
                            dataReader.Text = System.Text.UTF8Encoding.UTF8.GetString(dataReader.RawData, 0, dataReader.RawData.Length);
                            // test if same barcode is read. several calls to this function is run by the MsgWin, so we need to get one data only.
                            if (BarcodeReader.BCDataList.Count > 0 && BarcodeReader.BCDataList[BarcodeReader.BCDataList.Count - 1].Text.Equals(dataReader.Text))
                            {
                                // ignore repeat data
                            }
                            else
                                BarcodeReader.BCDataList.Add(dataReader);
                            dataReader = null;
                        }
                        return;
                    }
                }
                catch
                {
                    goto L_END;
                }
            L_END:
                BarcodeReader.BCDataList.Clear();
                return;
            }
        }
    //-----------------------------------------------------------------------------------
    // Jonel
    // Code added for Motorola handy compatability
    //-----------------------------------------------------------------------------------

    public class BarcodeReader
    {

        public static List<ReaderData> BCDataList = new List<ReaderData>();
        public Actions Actions;
        public Info Info;
        public EventHandler ReadNotify = null;

        public BarcodeReader()
        {
            Actions = new Actions();
            Info = new Info();
        }

        public void Dispose()
        {
            BCDataList.Clear();
        }
        public ReaderData GetNextReaderData()
        {
            int i;
            string sep = "";
            //CommonFunctions.MessageShow(string.Format("Number of records to read {0}", BCDataList.Count));
            if (BCDataList.Count > 0)
            {
                StringBuilder data = new StringBuilder();
                if (BCDataList.Count > 1)
                    sep = System.Text.UTF8Encoding.UTF8.GetString(new byte[] { 13, 10 }, 0, 2);
                
                for (i = 0; i < BCDataList.Count; i++)
                    data.Append(BCDataList[i].Text + sep);
                ReaderData dataReader = new ReaderData();
                i = BCDataList.Count - 1;
                dataReader.Text = data.ToString();
                dataReader.RawData = BCDataList[i].RawData;
                dataReader.Type = BCDataList[i].Type;
                dataReader.Result = BCDataList[i].Result;
                dataReader.IsPending = BCDataList[i].IsPending;
                BCDataList.Clear();
                return dataReader;
            }
            return null;
        }

        public static void Disable_MultiScan()
        {
            string disp = string.Empty;
            Int32 ret = 0;
            IntPtr rangePtr = Marshal.AllocCoTaskMem(sizeof(UInt32));
            Marshal.WriteInt32(rangePtr, (int)Bt.LibDef.BT_SCAN_RANGE_CENTER);
            ret = Bt.ScanLib.Setting.btScanSetProperty(Bt.LibDef.BT_SCAN_PROP_SCAN_TYPE, rangePtr);
            if (ret != Bt.LibDef.BT_OK)
            {
                disp = "Keyence btScanSetProperty error retcode[" + ret + "]";
                Handy.Lib.CommonFunctions.MessageShow(disp, Handy.Lib.CommonEnum.NotificationType.Warning);
                return;
            }

        }

        public static void Enable_MultiScan()
        {
            string disp = string.Empty;
            Int32 ret = 0;
            Bt.LibDef.BT_SCAN_FD_CODESET_PARAM param1 = new Bt.LibDef.BT_SCAN_FD_CODESET_PARAM();
            Bt.LibDef.BT_SCAN_FD_CODESET_PARAM param2 = new Bt.LibDef.BT_SCAN_FD_CODESET_PARAM();
            Bt.LibDef.BT_SCAN_FD_CODESET_PARAM param3 = new Bt.LibDef.BT_SCAN_FD_CODESET_PARAM();
            Bt.LibDef.BT_SCAN_FD_CODESET_PARAM param4 = new Bt.LibDef.BT_SCAN_FD_CODESET_PARAM();
            param1.type = (Int16)Bt.LibDef.BT_SCAN_CODE_C39;
            param1.codecount = 4;
            param1.min1 = 1;             param1.max1 = 39;
            param1.min2 = 1;             param1.max2 = 39;
            param1.min3 = 1;             param1.max3 = 39;
            param1.min4 = 1;             param1.max4 = 39;

            param2.type = (Int16) Bt.LibDef.BT_SCAN_CODE_C93;
            param2.codecount = 4;
            param2.min1 = 1;             param2.max1 = 93;
            param2.min2 = 1;             param2.max2 = 93;
            param2.min3 = 1;             param2.max3 = 93;
            param2.min4 = 1;             param2.max4 = 93;

            param3.type = (Int16)Bt.LibDef.BT_SCAN_CODE_C128;
            param3.codecount = 4;
            param3.min1 = 1; param3.max1 = 128;
            param3.min2 = 1; param3.max2 = 128;
            param3.min3 = 1; param3.max3 = 128;
            param3.min4 = 1; param3.max4 = 128;

            param4.type = (Int16)Bt.LibDef.BT_SCAN_CODE_JAN;
            param4.codecount = 4;
            param4.min1 = 1; param4.max1 = 13;
            param4.min2 = 1; param4.max2 = 13;
            param4.min3 = 1; param4.max3 = 13;
            param4.min4 = 1; param4.max4 = 13;

            try
            {
                // codeset param
                Bt.LibDef.BT_SCAN_FD_CODESET_PARAM[] codeset = 
                { 
                    param1,
                    param2,
                    param3,
                    param4
                };


                // set param
                Bt.LibDef.BT_SCAN_FD_SET_PARAM setparam = new Bt.LibDef.BT_SCAN_FD_SET_PARAM();
                setparam.typecount = 4;
                setparam.codeset = codeset;
                setparam.rsv1 = 0;

                IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(setparam));
                Marshal.StructureToPtr(setparam, ptr, true);
                ret = Bt.ScanLib.Setting.btScanSetProperty(Bt.LibDef.BT_SCAN_PROP_FULLDETECTION, ptr);
                Marshal.FreeCoTaskMem(ptr);
                if (ret != Bt.LibDef.BT_OK)
                {
                    disp = "Keyence btScanSetProperty error retcode[" + ret + "]";
                    Handy.Lib.CommonFunctions.MessageShow(disp, Handy.Lib.CommonEnum.NotificationType.Warning); 
                    return;
                }

                IntPtr rangePtr = Marshal.AllocCoTaskMem(sizeof(UInt32));
                Marshal.WriteInt32(rangePtr, (int)Bt.LibDef.BT_SCAN_RANGE_FULL);
                ret = Bt.ScanLib.Setting.btScanSetProperty(Bt.LibDef.BT_SCAN_PROP_SCAN_TYPE, rangePtr);
                if (ret != Bt.LibDef.BT_OK)
                {
                    disp = "Keyence btScanSetProperty error retcode[" + ret + "]";
                    Handy.Lib.CommonFunctions.MessageShow(disp, Handy.Lib.CommonEnum.NotificationType.Warning);
                    return;
                }

            }
            catch 
            {
                disp = "Cannot enable multicode scanning.";
                Handy.Lib.CommonFunctions.MessageShow(disp, Handy.Lib.CommonEnum.NotificationType.Warning);
            }
        }
    }
    public class Actions
    {
        public void Read(ReaderData BCData)
        {
        }
        public void Flush()
        {
            BarcodeReader.BCDataList.Clear();
        }
        public void Enable()
        {
        }
        public void Disable()
        {
        }
    }
    public class Info
    {
        public bool SoftTrigger;
    }

    public class ReaderData
    {
        public byte[] RawData;
        public bool IsPending;
        public Results Result;
        public string Text;
        public ushort Type;
        public int Length;

        public void Dispose()
        {
        }
    }

    public enum Results
    {
        SUCCESS,
        E_SCN_READTIMEOUT,
        CANCELED,
        E_SCN_DEVICEFAILURE,
        E_SCN_READINCOMPATIBLE
    }


}