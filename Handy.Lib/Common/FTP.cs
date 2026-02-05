using System;
using System.Collections.Generic;
using System.Text;
using FTPClient;

namespace Handy.Lib
{
    public class FTP
    {
        public void FTPupload()
        {
            try
            {
                //notify sending status

                //connect, open, send and close FTP
                FTPConnection ftp = new FTPConnection();
                ftp.Open("121.97.89.110", "LetTest", "!#LetTest2601#!", FTPMode.Passive);
                ftp.SendFile("\\Temp\\ScanLog " + CommonFunctions.GetDate() + ".txt", FTPFileTransferType.Binary);
                ftp.Close();

                //notify status
                ScanLog.WriteText("FTP Upload: Text file Sent Successfully");
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, "FTP connection failed", CommonEnum.MessageButtons.CloseOnly);
            }
        }
    }
}
