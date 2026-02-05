using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Handy.Lib
{
    public class ScanLog
    {
        private static StreamWriter sw;

        public static void CreateTextFile()
        {
            string FilePath = @"\Temp\ScanLog " + CommonFunctions.GetDate() + ".txt";
            if (!File.Exists(FilePath))
            {
                StreamWriter sw;
                sw = File.CreateText(FilePath);
                sw.WriteLine("Created: " + CommonFunctions.GetDateTime());
                sw.Close();
            }
        }

        public static void WriteONToText()
        {
            sw = File.AppendText(@"\Temp\ScanLog " + CommonFunctions.GetDate() + ".txt");
            sw.WriteLine("============================");
            sw.WriteLine(CommonFunctions.GetTime() + ": The reader is turned ON");
            sw.WriteLine("============================");
            sw.Close();
        }

        public static void WriteOFFToText()
        {
            sw = File.AppendText(@"\Temp\ScanLog " + CommonFunctions.GetDate() + ".txt");
            sw.WriteLine("============================");
            sw.WriteLine(CommonFunctions.GetTime() + ": The reader is turned OFF");
            sw.WriteLine("============================");
            sw.Close();
        }

        public static void WriteText(string Text)
        {
            sw = File.AppendText(@"\Temp\ScanLog " + CommonFunctions.GetDate() + ".txt");
            sw.WriteLine(CommonFunctions.GetTime() + " : " + Text);
            sw.Close();
        }

        //public static bool Save()
        //{
        //    StreamWriter writer = null;
        //    bool result = true;

        //    try
        //    {
        //        // create the directory if necessary
        //        string path = Path.GetDirectoryName(InventoryFileName);
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        // write the inventory to the file
        //        FileInfo fileInfo = new FileInfo(InventoryFileName);
        //        writer = fileInfo.CreateText();
        //        foreach (KeyValuePair<string, InventoryLocation> kvpLocations in Locations)
        //        {
        //            InventoryLocation location = kvpLocations.Value;
        //            writer.WriteLine(location.Items.Count.ToString() + " " + location.Location);
        //            foreach (KeyValuePair<string, InventoryItem> kvpItems in location.Items)
        //            {
        //                InventoryItem item = kvpItems.Value;
        //                writer.WriteLine(item.Quantity.ToString() + " " + item.Barcode);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (writer != null)
        //        {
        //            writer.Close();
        //        }
        //    }

        //    // clear the changed flag and return the result
        //    Changed = false;
        //    ItemsQueuedForSave = 0;
        //    return result;
        //}

    }
}
