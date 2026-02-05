using System;
using System.Collections.Generic;
using System.Text;

namespace Handy.Lib
{
    class CommonStoredProcedures
    {
        //Nilo Added 06-07-2012 


        public static class Movement
        {
            /// <summary>
            /// "Unable to retrieve Locator Information.";
            /// </summary>
            public static string LX = "LX";
            /// <summary>
            /// "Unable to retrieve RR Number information.";
            /// </summary>
            public static string RX = "RX";
            /// <summary>
            /// "Item is untag.";
            /// </summary>
            public static string RU = "RU";
            /// <summary>
            /// "New and Old Locator are the same.";
            /// </summary>
            public static string RLC = "RLC";
            /// <summary>
            /// "Item doesn't have an available quantity to transfer.";
            /// </summary>
            public static string RNA = "RNA";
            /// <summary>
            /// "Inputed quantity is greater than available quantity";
            /// </summary>
            public static string RIGA = "RIGA";
            /// <summary>
            ///  Successfully transfered
            /// </summary>
            public static string S = "S";
            public static string LABEL_MSG = "Label must be reprinted.";

        }
        public static class Tagging
        {
            public static string LX = "LX";    // "Unable to retrieve Locator Information.";
            public static string RL = "RL";    // "Item is already tagged.";
            public static string RX = "RX";    // "Unable to retrieve RR Number information.";
            public static string RNU = "RNU";  // "Item does not have remaining untagged qty.";
            public static string RIGU = "RIGU"; //"Inputed quantity is greater than untagged quantity";
            //Successfull
            public static string S = "S"; //- Successfully transfered
            public static string LABEL_MSG = "Label must be reprinted.";
        }
        public static class Issuance
        {
            public static string RX = "RX";    //Unable to retrieve RR Number Information.
            public static string RU = "RU";    //Unable to Issue. Item is untag.
            public static string WX = "WX";    //Unable to retrieve WRIS Number Information.'
            public static string WNR = "WNR";  //doest have remaining requested quantity
            public static string WRX = "WRX";  //Item reserved quanty is less than the filed reserved quantity for this WRIS No.
            public static string WRP = "WRP";  //WRIS printed barcode reserved quantity does not match with system request quantity.
            public static string WRRP = "WRRP";//WRIS printed barcode reserved RR Number does not match with system reserved RR Number
            public static string WRG = "WRG";  //--RETURN ACTUAL REQUESTED//Inputed quantity is greater than remaining requested quantity
            public static string WRAX = "WRAX"; //--RETURN ACTUAL AVAILABLE //Item has less than availble quantity than WRIS requested quatity.
            public static string WRRX = "WRRX";//Item has less than availble quantity than WRIS inputted issuance quatity.'
            public static string WG = "WG";    //Unable to update WRIS for Pick List Generation 
            public static string WXX = "WXX";   //Unable to transact issuance.

            public static string S = "S";      //- Successfully Issued
        }


        public static class RTI
        {
            public static string RX = "Error Duplicate Generated TempRR Header";
            public static string RY = "Error Duplicate Generated TempRR Detail";
            public static string RZ = "Error Duplicate Generated TempRR RTI";
            public static string RV = "Error Duplicate WRISNumber RTI";
            public static string S = "Success RTI Transaction";
            public static string FX = "Error not found";
        }
    }
}
