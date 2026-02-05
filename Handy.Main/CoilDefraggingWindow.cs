using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using Handy.Lib;
using System.ComponentModel;

namespace Handy
{
    public partial class CoilDefraggingWindow : BaseWindow
    {
        #region Variables

        private CommonEnum.Buttons ExitButton = CommonEnum.Buttons.Exit;
        private static int _Layer = 1;
        private static int _LayerSeq = 1;
        private bool Reprint = false;

        //Coil Display
        int Layer = 1;
        int LayerSeq = 1;
        int BaseLayer = 1;
        int BaseLayerSeq = 1;
        bool[,] SelectArray = new bool[1, 1];
        bool[,] ActiveArray = new bool[1, 1];
        bool[,] EmptyArray = new bool[1, 1];
        bool[,] TempArray = null;
        //
        enum TxtScroll
        {
            Up,
            Down
        }
        TxtScroll Scroll = TxtScroll.Up;

        #endregion

        #region Constructor

        public CoilDefraggingWindow(Symbol.Barcode.Reader BCReader, Symbol.Barcode.ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Coil Defragging");
            base.SetActiveButtons(BaseButtons.Save, BaseButtons.Cancel);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
        }

        #endregion

        #region Functions

        private void GetCoilDefraggingRRInfo()
        {
            if (CommonFunctions.IsReceivingReportInfoGenerated() && CommonFunctions.IsStockMovementRRInfoGenerated())
            {
                if (this.Reprint)
                {
                    CommonFunctions.MessageShow(String.Format(CommonMsg.Warning.d_ReprintOutdated, CommonFunctions.TagNo), CommonEnum.NotificationType.Warning);
                    this.ClearAll();
                }
                else
                {
                    TagNo.Text = CommonFunctions.TagNo;
                    Dimension.Text = CommonFunctions.Dimension;
                    Specs.Text = CommonFunctions.Specs;
                    Class.Text = CommonFunctions.StockClass;
                    RRNo.Text = CommonFunctions.RRNoDisplay;
                    //
                    Weight.Text = CommonFunctions.AvailableQty.ToString("#");
                    UnitWeight.Text = CommonFunctions.Unit;
                    //
                    ExitButton = CommonEnum.Buttons.Cancel;
                    TagNo.Focus();
                    this.timerMultilined.Enabled = true;
                }
            }
            else
            {
                ClearAll();
                TagNo.Focus();
                TagNo.SelectAll();
                base.BarcodeReader_Start();
            }
        }

        private void SaveButton(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(CommonFunctions.BarcodeRRNo))
                CommonFunctions.MessageShow(string.Empty
                                            , CommonMsg.Warning.ScanItem
                                            , CommonEnum.NotificationType.Warning);
            else
            {
                
                RemoveArray();
                CoilDefraggingBase.ServerActualProcessCoilDefragging(_Layer, _LayerSeq);
                FillActiveArray(_Layer, _LayerSeq);
                SelectCoil();
                //Nilo Added to berify if scanned label is updated <06/07/2012>
                //CommonFunctions.ScannedLabelForRepriting(false, true, "", "CD-H" + CommonFunctions.HandyNo);
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;
                TagNo.Focus();
                base.BarcodeReader_Start();
            }
        }

        private void CancelButton(object sender, EventArgs e)
        {
            if (ExitButton == CommonEnum.Buttons.Cancel)
            {
                ClearAll();
                ExitButton = CommonEnum.Buttons.Exit;

                TagNo.Focus();
                base.BarcodeReader_Start();
            }
            else
            {
                try
                {
                    this.timerMultilined.Enabled = false;
                    this.timerMultilined.Dispose();
                }
                catch { }
                ClearAll();
                CommonFunctions.LocatorCode = string.Empty;
                CommonFunctions.LocatorDesc = string.Empty;
                Close();
            }
        }

        private void ClearAll()
        {
            Class.ScrollBars = ScrollBars.None;
            //Commmon
            TagNo.Text = "";
            Dimension.Text = "";
            Specs.Text = "";
            Class.Text = "";
            RRNo.Text = "";
            //
            Weight.Text = "";
            UnitWeight.Text = "";
            //
            CommonFunctions.ClearStrings();
        }

        private void RemoveArray()
        {
            CoilDefraggingBase.GetLocatorInfo();
            if (CommonFunctions.InputLayerNo > 0 && CommonFunctions.InputLayerSeqNo > 0)
            {
                ActiveArray[CommonFunctions.InputLayerNo - 1, CommonFunctions.InputLayerSeqNo - 1] = false;
            }
        }

        private void ResetActiveArray()
        {
            //RESET
            ActiveArray = null;
            ActiveArray = new bool[1, 1];
            SelectCoil();
        }

        private void SetActiveArrayList()
        {
            DataTable dt = CoilDefraggingBase.GetLocatorList();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    FillActiveArray((int)row["LayerNo"], (int)row["LayerSeqNo"]);
                }
            }
            dt.Dispose();
        }

        private void IsMultilined(TextBox txtBox, String txtContent)
        {
            //Set Properties
            if (txtContent.Length > 25)
            {
                txtBox.ScrollBars = ScrollBars.Vertical;
                txtBox.Multiline = true;
                txtBox.WordWrap = true;
                this.timerMultilined.Enabled = true;

                //AutoScroll
                if (this.Scroll.Equals(TxtScroll.Up))
                {
                    this.Scroll = TxtScroll.Down;
                    txtBox.SelectionStart = txtBox.Text.Length;
                    txtBox.ScrollToCaret();
                    txtBox.Refresh();
                }
                else
                {
                    this.Scroll = TxtScroll.Up;
                    txtBox.SelectionStart = 0;
                    txtBox.ScrollToCaret();
                    txtBox.Refresh();
                }
            }
            else
            {
                txtBox.ScrollBars = ScrollBars.None;
                txtBox.Enabled = true;
                this.timerMultilined.Enabled = false;
            }
        }

        #endregion

        #region CoilDisplay

        private void SelectCoil()
        {
            //FillActiveArray(1, 2);
            //FillActiveArray(3, 4);
            //FillActiveArray(3, 5);
            //FillActiveArray(2, 2);

            FillSelectArray(_Layer, _LayerSeq);

            GenerateCoilDisplay();
        }

        private void GenerateCoilDisplay()
        {
            if (!string.IsNullOrEmpty(SubLocator.Text) && !string.IsNullOrEmpty(SubLocatorDesc.Text))
            {
                VerifyArray(Layer, LayerSeq);

                int LayerSeqLength = LayerSeq;
                int LayerLength = Layer;

                Bitmap bmp = new Bitmap(CoilDisplay.Width, CoilDisplay.Height);
                Graphics circle = Graphics.FromImage(bmp);
                circle.FillRectangle(new SolidBrush(Color.White), 0, 0, CoilDisplay.Width, CoilDisplay.Height);

                //setting circle
                int Diameter = GetDiameter(Layer, LayerSeq);
                //int Diameter = pictureBox1.Width / LayerSeqLength;

                //Position X
                int StartPositionX = 0;
                int NextPositionX = StartPositionX;

                //  
                int PositionY = CoilDisplay.Height - Diameter;

                int i = 0;
                int j = 0;

                //Create Circle

                Pen DrawingPen = new Pen(System.Drawing.Color.Black, 2);
                Pen DrawingPen2 = new Pen(System.Drawing.Color.Black, 1);

                if (Layer <= LayerSeq)
                    do
                    {
                        do
                        {
                            if (ActiveArray[j, i])
                            {
                                //Add Border
                                circle.DrawEllipse(DrawingPen, NextPositionX, PositionY, Diameter, Diameter);
                                //Fill
                                if (SelectArray[j, i])
                                {
                                    circle.FillEllipse(new SolidBrush(Color.YellowGreen), NextPositionX, PositionY, Diameter, Diameter);
                                }
                                else
                                    circle.FillEllipse(new SolidBrush(Color.LightBlue), NextPositionX, PositionY, Diameter, Diameter);
                            }
                            else if (EmptyArray[j, i] || SelectArray[j, i])
                            {
                                //Fill
                                if (SelectArray[j, i])
                                    circle.FillEllipse(new SolidBrush(Color.YellowGreen), NextPositionX, PositionY, Diameter, Diameter);

                                circle.DrawEllipse(DrawingPen2, NextPositionX, PositionY, Diameter, Diameter);
                            }

                            ////Setting Next Position
                            NextPositionX = NextPositionX + Diameter;
                            i++;

                        } while (LayerSeqLength > i);

                        //Set Next Position X
                        StartPositionX = StartPositionX + (Diameter / 2);
                        NextPositionX = StartPositionX;

                        //Set Next Position Y
                        PositionY = PositionY - Diameter + (int)(Math.Cos(30) * Diameter);


                        //Coil Numbers
                        LayerSeqLength = LayerSeqLength - 1;

                        j++;
                        i = 0;

                    } while (LayerLength > j);

                circle.Dispose();
                CoilDisplay.Image = bmp;
                //e.Graphics.DrawImage(bmp, CoilDisplay.Location.X, CoilDisplay.Location.Y);
            }
        }

        protected int GetDiameter(int Layer, int LayerSeq)
        {
            int Width = CoilDisplay.Width;
            int Height = CoilDisplay.Height;

            if (((Width / LayerSeq) * Layer) >= Height)
                return ((Height / Layer) > 40) ? 40 : (Height / Layer);
            else
                return ((Width / LayerSeq) > 40) ? 40 : (Width / LayerSeq);
        }

        private void GetActiveLength()
        {
            if (Layer <= LayerSeq)
            {
                int i = 0;
                int j = 0;

                int LayerLength = ActiveArray.GetLength(0);
                int LayerSeqLength = ActiveArray.GetLength(1);
                int SeqNo = 0;

                do
                {
                    do
                    {
                        if (ActiveArray[j, i])
                        {
                            BaseLayer = j + 1; // actual --- virtual is 0
                            if ((i + j + 1) > SeqNo)
                            {
                                BaseLayerSeq = i + j + 1; // actual -- -1 in virtual
                                SeqNo = i + j + 1; // + j (including the layer)
                            }
                            else
                                BaseLayerSeq = SeqNo;
                        }
                        i++;
                    } while (i < LayerSeqLength);

                    //Layer Increment and Seq Reset
                    j++;
                    i = 0;

                } while (LayerLength > j);

                //MessageBox.Show(BaseLayer + "-" + BaseLayerSeq);

            }
        }

        private void FillSelectArray(int LayerNo, int LayerSeqNo)
        {
            TempArray = ActiveArray;
            GetActiveLength();

            Layer = (BaseLayer > LayerNo) ? BaseLayer : LayerNo;
            LayerSeq = (BaseLayerSeq > (LayerSeqNo + (LayerNo - 1))) ? BaseLayerSeq : LayerSeqNo + (LayerNo - 1);

            SetLengthActiveArray();

            GetTempArray();
            if (!(Layer == 0 || LayerSeq == 0))
                SelectArray[LayerNo - 1, LayerSeqNo - 1] = true;
        }

        private void SetActiveArray(int Layer, int LayerSeq)
        {
            if (!(Layer == 0 || LayerSeq == 0))
                ActiveArray[Layer - 1, LayerSeq - 1] = true;
        }

        private void SetLengthActiveArray()
        {
            ActiveArray = null;
            SelectArray = null;
            EmptyArray = null;
            ActiveArray = new bool[Layer, LayerSeq];
            SelectArray = new bool[Layer, LayerSeq];
            EmptyArray = new bool[Layer, LayerSeq];
        }

        private void GetTempArray()
        {
            if (Layer <= LayerSeq)
            {
                int i = 0;
                int j = 0;

                int LayerLength = TempArray.GetLength(0);
                int LayerSeqLength = TempArray.GetLength(1);

                do
                {
                    do
                    {
                        if (TempArray[j, i])
                            ActiveArray[j, i] = true;
                        i++;
                    } while (i < LayerSeqLength);

                    //Layer Increment and Seq Reset
                    j++;
                    i = 0;

                } while (LayerLength > j);
            }
        }

        private void FillActiveArray(int LayerNo, int LayerSeqNo)
        {
            Layer = (LayerNo > ActiveArray.GetLength(0)) ? LayerNo : ActiveArray.GetLength(0);
            LayerSeq = (LayerSeqNo > ActiveArray.GetLength(1)) ? LayerSeqNo : ActiveArray.GetLength(1);

            TempArray = ActiveArray; //Backup;
            SetLengthActiveArray();  //Reset
            GetTempArray();          //Restore Backup

            if (!(Layer == 0 || LayerSeq == 0))
                ActiveArray[LayerNo - 1, LayerSeqNo - 1] = true; //Set
        }

        private void VerifyArray(int Layer, int LayerSeq)
        {
            if (Layer <= LayerSeq)
            {
                int i = 0;
                int j = Layer - 1;

                int LayerLength = Layer;
                int LayerSeqLength = LayerSeq;

                if (j >= 1)
                {
                    do
                    {
                        do
                        {
                            if (ActiveArray[j, i] || SelectArray[j, i] || EmptyArray[j, i])
                            //if (j >= 1)
                            {
                                EmptyArray[(j - 1), i] = true;
                                EmptyArray[(j - 1), (i + 1)] = true;
                            }
                            i++;
                        } while (i < LayerSeqLength);
                        j--;
                        i = 0;

                    } while (j >= 1);
                }
            }

        }

        private void SubLocator_TextChanged(object sender, EventArgs e)
        {
            SelectCoil();
        }

        private void panel2_GotFocus(object sender, EventArgs e)
        {

        }

        private void timerMultilined_Tick(object sender, EventArgs e)
        {

        }

        //
        #endregion

        #region Override

        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.BarcodeReader_AnalyzeType(Sender, e);
        
            switch (base.ScannedBarcodeType)
            {
                case CommonEnum.LabelType.Item2D:
                    {
                        if (!string.IsNullOrEmpty(CommonFunctions.LocatorCode))
                        {
                            if (CommonFunctions.IsConnected())
                            {
                                if (CommonFunctions.ScannedLabelForRepriting(false, false, this.LocatorCode.Text, string.Format("CD-H{0}", CommonFunctions.HandyNo)))
                                    this.Reprint = true;
                                this.GetCoilDefraggingRRInfo();
                                this.Reprint = false;
                            }
                        }
                        else
                        {
                            CommonFunctions.MessageShow(string.Empty
                                                        , CommonMsg.Warning.ScanLocator
                                                        , CommonEnum.NotificationType.Warning);
                            ClearAll();
                            ResetActiveArray();
                            base.BarcodeReader_Start();
                        }
                    }
                    break;
                case CommonEnum.LabelType.Invalid:
                    {
                        ClearAll();
                        ResetActiveArray();
                        base.BarcodeReader_Start();
                    }
                    break;
                case CommonEnum.LabelType.LocatorCode:
                    {
                        ClearAll();
                        LocatorCode.Text = CommonFunctions.LocatorCode;
                        LocatorCodeDesc.Text = CommonFunctions.LocatorDesc;

                        //RESET
                        ActiveArray = null;
                        ActiveArray = new bool[1, 1];

                        //SET
                        try
                        {
                            SetActiveArrayList();
                            SelectCoil();
                        }
                        catch { }


                        base.BarcodeReader_Start();
                        TagNo.Focus();
                    }
                    break;
                case CommonEnum.LabelType.ServerNotFound:
                    {
                        ClearAll();
                        LocatorCodeDesc.Text = "";
                        LocatorCode.Text = "";
                        LocatorCode.Focus();
                        ResetActiveArray();
                        base.BarcodeReader_Start();
                    }
                    break;
            }

            base.ScannedBarcodeType = Handy.Lib.CommonEnum.LabelType.Null;
        }

        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Nilo Added : Label Indicator <05/25/2012>
                case Keys.ControlKey:
                    CommonFunctions.MessageShow(string.Format(CommonMsg.Info.ScannedLabelCount, CommonFunctions.getBatchNo(false))
                                                , CommonEnum.NotificationType.Information); //GET COUNT OF BATCH SCANNED
                    break;
                case Keys.Space:
                    CommonFunctions.getBatchNo(true);
                    CommonFunctions.MessageShow(CommonMsg.Info.RefreshCount
                                                , CommonEnum.NotificationType.Information); //REFRESH COUNT
                    // NEW BATCH NO
                    break;
                //end
                case Keys.F14:
                    SaveButton(this, e);
                    break;
                case Keys.F15:
                    CancelButton(this, e);
                    break;
                case Keys.Up:
                    {
                        if (_Layer < 5)
                            _Layer++;
                        CommonFunctions.LayerNo = _Layer;
                        CommonFunctions.LayerSeqNo = _LayerSeq;
                        SubLocator.Text = CommonFunctions.SubLocator;
                        SubLocatorDesc.Text = CommonFunctions.SubLocatorDesc;
                    }
                    break;
                case Keys.Down:
                    {
                        if (_Layer > 1)
                            _Layer--;
                        CommonFunctions.LayerNo = _Layer;
                        CommonFunctions.LayerSeqNo = _LayerSeq;
                        SubLocator.Text = CommonFunctions.SubLocator;
                        SubLocatorDesc.Text = CommonFunctions.SubLocatorDesc;
                    }
                    break;
                case Keys.Right:
                    {
                        _LayerSeq++;
                        CommonFunctions.LayerNo = _Layer;
                        CommonFunctions.LayerSeqNo = _LayerSeq;
                        SubLocator.Text = CommonFunctions.SubLocator;
                        SubLocatorDesc.Text = CommonFunctions.SubLocatorDesc;
                    }
                    break;
                case Keys.Left:
                    {
                        if (_LayerSeq > 1)
                            _LayerSeq--;
                        CommonFunctions.LayerNo = _Layer;
                        CommonFunctions.LayerSeqNo = _LayerSeq;
                        SubLocator.Text = CommonFunctions.SubLocator;
                        SubLocatorDesc.Text = CommonFunctions.SubLocatorDesc;
                    }
                    break;
            }

            base.BaseWindow_KeyUp(sender, e);
        }

        protected override void lblBtnRight_Click(object sender, EventArgs e)
        {
            KeyEventArgs KeyArgs = new KeyEventArgs(Keys.F15);
            this.BaseWindow_KeyUp(sender, KeyArgs);
        }

        protected override void lblBtnLeft_Click(object sender, EventArgs e)
        {
            KeyEventArgs KeyArgs = new KeyEventArgs(Keys.F14);
            this.BaseWindow_KeyUp(sender, KeyArgs);
        }

        #endregion

        //Events

        private void CoilDefraggingWindow_Load(object sender, EventArgs e)
        {
            SubLocator.Text = CommonFunctions.SubLocator;
            SubLocatorDesc.Text = CommonFunctions.SubLocatorDesc;
            LocatorCode.Focus();
            SelectCoil();
        }

        private void timerMultilined_Tick_1(object sender, EventArgs e)
        {
            this.IsMultilined(this.Class, this.Class.Text);
        }
        
    }
}
