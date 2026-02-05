using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Handy.Lib;

namespace Handy
{
    public partial class StockCardWindow : Handy.BaseWindow
    {
        DataTable dt_Type = Handy.Lib.StockCard.StockCardBase.getStockType();
        
        public StockCardWindow(BarcodeReader BCReader, ReaderData BCData)
        {
            InitializeComponent();
            base.SetBarcodeReader(BCReader, BCData);
            base.SetWindowTitle("Stock Card");
            base.SetActiveButtons(BaseButtons.Generate, BaseButtons.Exit);
            CommonInterfaceFunctions.WLANAddSignalQualityHandler(base.pcbSignal, true);
            
        }
        protected override void BarcodeReader_AnalyzeType(object Sender, EventArgs e)
        {
            base.GetRawBarcodeValue = true;

            base.BarcodeReader_AnalyzeType(Sender, e);

            if (base.BarcodeValue == null)
            {
                //Do nothing
            }
            else
            {
                if (cmbStockType.Items.Count > 0)
                {
                    string RRDisplay = base.BarcodeTextData.Substring(0, 24);
                    DataTable barcode = Handy.Lib.StockCard.StockCardBase.getStockCodeFromBarCode(RRDisplay);
                    DataRow rrDetails = barcode.Rows[0];
                    var stockCode = rrDetails["Code"].ToString();
                    var type = rrDetails["Type"].ToString();
                    cmbStockType.SelectedValue = type;
                    loadStocks();
                    cmbStockCode.SelectedValue = stockCode;
                    loadData(Handy.Lib.StockCard.StockCardBase.getRR(stockCode));
                    Audio.PlayOKBeep();
                }   
                else
                {
                    MessageBox.Show("Generate Stock Type First.\nClick the Start button.");
                    Audio.PlayErrorBeep();
                }
               
            }

            base.BarcodeValue = null;
            base.GetRawBarcodeValue = false;
        }
        protected override void BaseWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                       
                        loadStockStype();
                    }
                    break;
                case Keys.F4:
                    Close();
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

        private void loadStockCard(string stockcode)
        { 
            
        }

        private void loadData(DataTable dt)
        {
            this.StocksListView.Items.Clear();
            int count = dt.Rows.Count;
            double balance = 0.00;
            string UOM = "";
           
            if (count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    ListViewItem StockCardListViewItem = new ListViewItem();
                    StockCardListViewItem.Text = row["RR No"].ToString();
                    StockCardListViewItem.SubItems.Add(row["Location"].ToString());
                    StockCardListViewItem.SubItems.Add((Convert.ToDouble(row["QTY"])).ToString());
                    this.StocksListView.Items.Add(StockCardListViewItem);
                    balance = balance + Convert.ToDouble(row["QTY"]);
                    UOM = row["Unit"].ToString();
                    StocksListView.Focus();
                }

                lblBal.Text = balance.ToString() + " " + UOM;
            }
            else
            {
                lblBal.Text = "0";
                MessageBox.Show("No Record Found");
            }
        
        }

        private void loadStockStype()
        {
            cmbStockType.ValueMember = "Type";
            cmbStockType.DisplayMember = "Desc";
            cmbStockType.DataSource = dt_Type;
        }

        private void loadStocks()
        {
            string stockType = "";
            if (cmbStockType.SelectedValue != null)
            {
                stockType = cmbStockType.SelectedValue.ToString();
                DataTable dt_Code = Handy.Lib.StockCard.StockCardBase.getStocks(stockType);
                cmbStockCode.ValueMember = "Code";
                cmbStockCode.DisplayMember = "Name";
                cmbStockCode.DataSource = dt_Code;
            }
           
        }
        private void cmbStockCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStockCode.SelectedValue != null)
            {
                string stockcode = cmbStockCode.SelectedValue.ToString();
                loadData(Handy.Lib.StockCard.StockCardBase.getRR(stockcode));
            }
        }

        private void cmbStockType_SelectedValueChanged_1(object sender, EventArgs e)
        {
            loadStocks();
            loadStockStype();
        }

    }
}

