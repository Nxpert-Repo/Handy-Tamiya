using System;
using System.Collections.Generic;
using System.Text;

namespace Handy.Lib
{
    class CommonConstant
    {
        public static class StockMovement
        {
            //Movement errcode
            public const string LX = "LX";      // "Unable to retrieve Locator Information.";
            public const string RX = "RX";      // "Unable to retrieve RR Number information.";
            public const string RU = "RU";      // "Item is untag.";
            public const string RLC = "RLC";    // "New and Old Locator are the same.";
            public const string RNA = "RNA";    // "Item doesn't have an available quantity to transfer.";
            public const string RIGA = "RIGA";  //"Inputed quantity is greater than available quantity";
            //Successful
            public const string S = "S";        //- Successfully transfered
            public const string LABEL_MSG = "Label must be reprinted.";
        }
        public static class LocatorTagging
        {
            public const string LX = "LX";      // "Unable to retrieve Locator Information.";
            public const string RL = "RL";      // "Item is already tagged.";
            public const string RX = "RX";      // "Unable to retrieve RR Number information.";
            public const string RNU = "RNU";    // "Item does not have remaining untagged qty.";
            public const string RIGU = "RIGU"; //"Inputed quantity is greater than untagged quantity";
            //Successful
            public const string S = "S"; //- Successfully transfered
            public const string LABEL_MSG = "Label must be reprinted.";
        }
        public static class MaterialIssuance
        {
            public const string RX = "RX";    //Unable to retrieve RR Number Information.
            public const string RU = "RU";    //Unable to Issue. Item is untag.
            public const string WX = "WX";    //Unable to retrieve WRIS Number Information.'
            public const string WNR = "WNR";  //doest have remaining requested quantity
            public const string WRX = "WRX";  //Item reserved quanty is less than the filed reserved quantity for this WRIS No.
            public const string WRP = "WRP";  //WRIS printed barcode reserved quantity does not match with system request quantity.
            public const string WRRP = "WRRP";//WRIS printed barcode reserved RR Number does not match with system reserved RR Number
            public const string WRG = "WRG";  //Inputed quantity is greater than remaining requested quantity
            public const string WRAX = "WRAX";//Item has less than availble quantity than WRIS requested quatity.
            public const string WRRX = "WRRX";//Item has less than availble quantity than WRIS inputted issuance quatity.'
            public const string WG = "WG";    //Unable to update WRIS for Pick List Generation 
            public const string WXX = "WXX";   //Unable to transact issuance.

            public const string S = "S";      //- Successfully Issued
        }
    }
}
