using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

namespace Handy.Lib
{
    public static class Logger
    {
        //Author : Nilo Luansing
        //Desc   : Text File Manipulations
        //Date   : 07-06-2012

        #region Variable [Path & FileName]
        public static string HandyPath = @"\Application\handy-logs\";
        public static string HandyArchivedPath = @"\Application\handy-logs\Archives\";
        public static string HandyOnResetPath = @"\Application\StartUpCtl\OnReset\";
        public static string HandyOnRestorePath = @"\Application\StartUpCtl\OnRestore\";

        public static string HandyMITPathFile = @"\Application\handy-logs\MIT.log";
        public static string HandyUSERPathFile = @"\Application\handy-logs\HANDYUSER.log";
        public static string HandyCompanyInfoPathFile = @"\Application\handy-logs\HANDYCOMPANYINFO.log";
        public static string HandyTaggingPathFile = @"\Application\handy-logs\TAGGING.log";
        public static string HandyMovementPathFile = @"\Application\handy-logs\MOVEMENT.log";
        public static string HandyInfoPathFile = @"\Application\handy-logs\HANDYINFO.log";
        public static string HandyDeviceNetConPathFile = @"\Application\handy-logs\HANDYNETCONFIG.log";
        public static string HandyFTPSeqPathFile = @"\Application\handy-logs\HANDYFTPSEQFILE.log";
        public static string HandyFTPSettingPathFile = @"\Application\handy-logs\HANDYFTPSETTING.log";

        public static string HandyMITFile = @"MIT.log";
        public static string HandyMITTempFile = @"MIT.Temp.log";
        public static string HandyUSERFile = @"HANDYUSER.log";
        public static string HandyCompanyInfoFile = @"HANDYCOMPANYINFO.log";
        public static string HandyTaggingFile = @"TAGGING.log";
        public static string HandyTaggingTempFile = @"TAGGING.Temp.log";
        public static string HandyMovementFile = "MOVEMENT.log";
        public static string HandyMovementTempFile = "MOVEMENT.Temp.log";
        public static string HandyDefualtConModeFile = "HANDYCONNECTIONMODE.log";
        public static string HandyOnResetFile = "OnReset.txt";
        public static string HandyOnRestoreFile = "OnRestore.txt";
        public static string HandyHostFile = "HANDYHOSTNAME.log";
        public static string HandyInfoFile = "HANDYINFO.log";
        public static string HandyDeviceNetConFile = "HANDYNETCONFIG.log";
        public static string HandyMacFile = "HANDYMAC.log";
        public static string HandyFTPSeqFile = "HANDYFTPSEQFILE.log";
        public static string HandyFTPSettingFile = "HANDYFTPSETTING.log";
        #endregion

        #region common
        #region Other Textfile Functions
        public static void WriteLog(string location, string filename,string header,string msg, bool AppendTxt)
        {
            try
            {
                String IsCleanup = DateTime.Now.ToString("M-d");
                if (IsCleanup == "1-1") 
                {
                    // delete directory
                    if (System.IO.Directory.Exists(location + @"\\Logged") == true)
                    {
                        Directory.Delete(location + @"\Logged\",true);
                    }
                }
                if (header == "")
                    header = "";
                else
                header = string.Format(@"=============================================================================
                           \nFunction Name : {1}
                           \nDate/Time : {2}
                           \nMsg : {0}", header, DateTime.Now);
             
                // create directory
                if (System.IO.Directory.Exists(location + @"\\Logged") != true)
                {
                    Directory.CreateDirectory(location + @"\Logged\");
                }
                location = location + @"\Logged\";

                // create filename
                string myLog = location + "\\" + "~"+filename + ".log";
                FileStream FS = null;

                //write or append txt
                if (!AppendTxt)
                {
                    if (File.Exists(myLog))
                    {
                        File.Delete(myLog);
                    }
                    using (FS = File.Create(myLog)) { }
                    FS.Close();
                    StreamWriter TXT_WRITE = new StreamWriter(myLog);
                    TXT_WRITE.WriteLine(header);
                    TXT_WRITE.WriteLine(msg);
                    TXT_WRITE.Close();
                }
                else
                {
                    FileStream FSAppend = new FileStream(myLog, FileMode.Append, FileAccess.Write);
                    StreamWriter TXT_WRITE = new StreamWriter(FSAppend);
                    TXT_WRITE.WriteLine(header);
                    TXT_WRITE.WriteLine(msg);
                    TXT_WRITE.Close();
                    FSAppend.Close();
                }
                
            }
            catch
            {
                return;
            }
        }

        public static bool WritetoText(string location, string filename, string msg, bool AppendTxt)
        {
            bool Written = false;
            try
            {
                // create directory
                if (System.IO.Directory.Exists(location) != true)
                {
                    Directory.CreateDirectory(location);
                }

                // create filename
                string myLog = location + filename;
                FileStream FS = null;

                //write or append txt
                if (!AppendTxt)
                {
                    if (File.Exists(myLog))
                    {
                        File.Delete(myLog);
                    }
                    using (FS = File.Create(myLog)) { }
                    FS.Close();
                    StreamWriter TXT_WRITE = new StreamWriter(myLog);
                    TXT_WRITE.WriteLine(msg);
                    TXT_WRITE.Close();
                    Written = true;
                }
                else
                {
                    FileStream FSAppend = new FileStream(myLog, FileMode.Append, FileAccess.Write);
                    StreamWriter TXT_WRITE = new StreamWriter(FSAppend);
                    TXT_WRITE.WriteLine(msg);
                    TXT_WRITE.Close();
                    FSAppend.Close();
                    Written = true;
                }

            }
            catch
            {
                Written = false;
            }
            return Written;
        }
        //Check if file is existing
        public static bool isFileExist(string location, string filename)
        {
            bool exist = false;
            // create filename
            string myLog = location + filename;
            if (File.Exists(myLog))
            {
                exist = true;
            }
            return exist;
        }
        //Check if Directory is existing
        public static bool isDirectoryExist(string location)
        {
            bool exist = false;
            if (Directory.Exists(location))
            {
                exist = true;
            }
            return exist;
        }
        //Delete files
        public static bool isFileCleared(string location, string filename)
        {
            try
            {
                FilePathFormatter FormattedFilePath = new FilePathFormatter(location, filename);
                //Deleting temp file
                if (File.Exists(FormattedFilePath.FullFilePath))
                {
                    string bak = FormattedFilePath.FileName.Replace(".txt", "");
                    bak =  FormattedFilePath.Directory + bak.Replace(".log", "") + ".Bak.log";
                    string bak2 = bak.Replace(".Bak.log", ".bak.log");
                    if (File.Exists(bak))
                        File.Delete(bak);
                    else if (File.Exists(bak2))
                        File.Delete(bak2);
                    File.Move(FormattedFilePath.FullFilePath,bak);
                    //File.Delete(FormattedFilePath.Directory + FormattedFilePath.FileName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception Ex)
            {
                CommonFunctions.MessageShow(CommonMsg.Error.d_UnabletoProcess + "\n" + Ex.ToString(),CommonEnum.NotificationType.Error);
                return false;
            }
            
        }

        public static bool isDirectoryCleared(string location)
        {
            if (Directory.Exists(location))
            { 
                Directory.Delete(location,true);
                return Directory.Exists(location);
            }
            return false;
        }
        //Archive files
        public static bool isFileArchived(string Archivelocation, string Sourcelocation, string Sourcefilename)
        {
            try
            {
                if (!System.IO.Directory.Exists(Archivelocation))
                {
                    Directory.CreateDirectory(Archivelocation);
                }
                FilePathFormatter FormattedOrigFilePathName = new FilePathFormatter(Sourcelocation, Sourcefilename);
                //Renaming File as Archived
                int FileIndex = 10000;
                for (int i = 0; i < FileIndex; ++i)
                {
                    FilePathFormatter FormattedArcvFilePath = new FilePathFormatter(Archivelocation, string.Format("Arcv{0}_{1}", i, Sourcefilename));
                    if (!File.Exists(FormattedArcvFilePath.FullFilePath) && File.Exists(FormattedOrigFilePathName.FullFilePath))
                    {
                        File.Move(FormattedOrigFilePathName.FullFilePath, FormattedArcvFilePath.FullFilePath);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                CommonFunctions.MessageShow(CommonMsg.Error.d_UnabletoProcess + "\n" + Ex.ToString(), CommonEnum.NotificationType.Error);
                return false;
            }

        }
        //Get Text File Size
        public static string GetTextFileSize(string location,string filename)
        {
            return GetTextFileSize(location, filename, "KB");
        }
        /// <summary>
        /// Get Text File Size.
        /// Argumets for Measure
        ///     KB - Kilobytes
        ///     MB - Megabytes
        ///     GB - Gigabytes
        /// </summary>
        /// <param name="location"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetTextFileSize(string location, string filename,string Measure)
        {
            FilePathFormatter FormattedFilePath = new FilePathFormatter(location, filename);
            if (!isFileExist(FormattedFilePath.Directory, FormattedFilePath.FileName))
                return "0 KB";
            long size = new FileInfo(FormattedFilePath.FullFilePath).Length;
            if (size > 0)
            {
                double _size = (double)size;
                _size = _size / 1024;
                if (Measure.ToUpper().Trim().Equals("KB"))
                    return string.Format("{0:0.00} KB", _size);
                else if (Measure.ToUpper().Trim().Equals("MB"))
                    return string.Format("{0:0.00} MB", _size / 1024);
                else if (Measure.ToUpper().Trim().Equals("GB"))
                    return string.Format("{0:0.00} GB", _size / 1024 / 1024);
                else
                    return "0 KB";
            }
            else
                return "0 KB";
        }

        public static string GetDirectorySize(string location, string Measure)
        {
            if (!Directory.Exists(location))
                return "0 KB";
            // 1
            // Get array of all file names.
            string[] files = Directory.GetFiles(location, "*.*");

            // 2
            // Calculate total bytes of all files in a loop.
            long sumsize = 0;
            foreach (string file in files)
            {
                // 3
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(file);
                sumsize += info.Length;
            }

            // 5
            // Return total size
            
            if (sumsize > 0)
            {
                double _size = (double)sumsize;
                _size = _size / 1024;
                if (Measure.ToUpper().Trim().Equals("KB"))
                    return string.Format("{0:0.00} KB", _size);
                else if (Measure.ToUpper().Trim().Equals("MB"))
                    return string.Format("{0:0.00} MB", _size / 1024);
                else if (Measure.ToUpper().Trim().Equals("GB"))
                    return string.Format("{0:0.00} GB", _size / 1024 / 1024);
                else
                    return "0 KB";
            }
            else
                return "0 KB";
        }
       
        #endregion
        #region FindTextData
        public static bool FindTextData(string FileFullPath, string[] Param)
        { 
            return FindTextData(FileFullPath,"",Param);
        }

        public static bool FindTextData(string location, string filename, string[] Param)
        {
            return FindTextData(location, filename, Param, true);
        }

        public static bool FindTextData(string location,string filename, string[] Param, bool ignoreCase)
        {
            bool retunVal = false;
            try
            {
                //check if MIT LOG Exist
                if (!isFileExist(location, filename))
                    return retunVal;
                String TextLine = "";
                String[] TextData;
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(location+filename);

                while (objReader.Peek() != -1)
                {
                    TextLine = objReader.ReadLine();
                    TextData = TextLine.Split(',');
                    if (TextLine.Trim() != String.Empty)
                    {
                        try
                        {

                            int i = 0;
                            int CompareCount = 0;
                            //Getting the max index of the Param
                            if (Param != null)
                            {
                                foreach (string param in Param)
                                {
                                    if (ignoreCase)
                                    {
                                        if (param.Trim().ToUpper() == TextData[i].Trim().ToUpper())
                                            ++CompareCount;
                                    }
                                    else
                                    {
                                        if (param.Trim() == TextData[i].Trim())
                                            ++CompareCount;
                                    }
                                    ++i;
                                }

                                //Check if found
                                if (CompareCount == Param.Length && CompareCount > 0)
                                {
                                    objReader.Close();
                                    retunVal = true;
                                    return retunVal;
                                }
                                else
                                {
                                    retunVal = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            retunVal = false;
                        }
                    }
                }
                objReader.Close(); 
            }
            catch (Exception ex) { CommonFunctions.MessageShow(ex.ToString()); }
            return retunVal;
        }
        #endregion

        /// Author : Nilo L. Luansing Jr.
        /// Desc   : Text file writing generic functions
        /// Date   : 07/07/2012
        #region WriteTextData [Generic Text file writing functions]

        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file and return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, string[] param)
        {
            return WriteTextData(location, filename, param, true);
        }
        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file.
        /// Allow to set header.
        /// Return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, string[] param, bool headerInfo)
        {
            return WriteTextData(location, filename, param, headerInfo, false);
        }
        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file.
        /// Allow to set header.
        /// Allow to set text append.
        /// Return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, string[] param, bool headerInfo, bool AppendTxt)
        {
            return WriteTextData(location, filename, param, headerInfo, AppendTxt, ',');
        }
        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file.
        /// Allow to set header.
        /// Allow to set text append.
        /// Allow to set split chareacter.
        /// Return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, string[] param, bool headerInfo, bool AppendTxt, char splitChar)
        {
            if (param == null)
                return false;
            bool Written = false;
            try
            {
                string[] header = new string[7];
                string content = string.Empty;
                int RowsCount = 0;
                //Location/File name setter
                if (location.Trim() != string.Empty && filename.Trim() != string.Empty)
                {
                    if (!location.Trim().EndsWith(@"\") && !filename.Trim().EndsWith(@"\"))
                        location += @"\";
                    else if (location.Trim().EndsWith(@"\") && filename.Trim().StartsWith(@"\"))
                        location = location.Substring(0, location.Length - 1);
                }
                //
                //Assigning content
                foreach (string _param in param)
                {
                    content += string.Format("{0}{1}", _param.TrimStart().TrimEnd(), splitChar.ToString());
                }
                content = content.Substring(0, content.Length - 1);
                //Assigning header
                if (headerInfo && !AppendTxt)
                {
                    header[0] = string.Format("{0}", "#######################################################################");
                    header[1] = string.Format("\n# Directory    : {0}", location.TrimStart().TrimEnd());
                    header[2] = string.Format("\n# Filename     : {0}", filename.TrimStart().TrimEnd());
                    header[3] = string.Format("\n# Date Created : {0}", DateTime.Now);
                    header[4] = string.Format("\n# Max Field(s) : {0}", param.Length);
                    header[5] = string.Format("\n# Split Char   : {0}", splitChar);
                    header[6] = string.Format("\n{0}", "#######################################################################");
                }
                // create directory
                if (System.IO.Directory.Exists(location) != true)
                {
                    Directory.CreateDirectory(location);
                }

                // create filename
                string CreatedFile = location + filename;
                FileStream FS = null;

                //write or append txt
                if (!AppendTxt)
                {
                    if (File.Exists(CreatedFile))
                    {
                        File.Delete(CreatedFile);
                    }
                    using (FS = File.Create(CreatedFile)) { }
                    FS.Close();
                    StreamWriter TXT_WRITE = new StreamWriter(CreatedFile);
                    if (header != null && headerInfo && !AppendTxt)
                    {
                        foreach (string _header in header)
                            TXT_WRITE.WriteLine(_header);
                    }
                    TXT_WRITE.WriteLine(content);
                    TXT_WRITE.Close();
                    Written = true;
                }
                else
                {
                    FileStream FSAppend = new FileStream(CreatedFile, FileMode.Append, FileAccess.Write);
                    StreamWriter TXT_WRITE = new StreamWriter(FSAppend);
                    if (header != null && headerInfo && !AppendTxt)
                    {
                        foreach (string _header in header)
                            TXT_WRITE.WriteLine(_header);
                    }
                    TXT_WRITE.WriteLine(content);
                    TXT_WRITE.Close();
                    FSAppend.Close();
                    Written = true;
                }

            }
            catch
            {
                Written = false;
            }
            return Written;
        }
        //Using Text ParamInfo
        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file and return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, TextParameterInfo[] TextParamInfo)
        {
            return WriteTextData(location, filename, TextParamInfo, true);
        }
        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file.
        /// Allow to set header.
        /// Return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, TextParameterInfo[] TextParamInfo, bool headerInfo)
        {
            return WriteTextData(location, filename, TextParamInfo, headerInfo, false);
        }
        /// <summary>
        /// Supplied with the Directory and file name.
        /// Write the data to a  text file.
        /// Allow to set header.
        /// Allow to set text append.
        /// Return as a bool.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static bool WriteTextData(string location, string filename, TextParameterInfo[] TextParamInfo, bool headerInfo, bool AppendTxt)
        {
            return WriteTextData(location, filename, TextParamInfo, headerInfo, AppendTxt, ',');
        }
        public static bool WriteTextData(string location, string filename, TextParameterInfo[] TextParamInfo, bool headerInfo, bool AppendTxt, char splitChar)
        {
            if (TextParamInfo == null)
                return false;
            bool Written = false;
            try
            {
                string[] header = new string[8];
                string FieldNames = string.Empty;
                string content = string.Empty;
                int RowsCount = 0;
                //Location/File name setter
                if (location.Trim() != string.Empty && filename.Trim() != string.Empty)
                {
                    if (!location.Trim().EndsWith(@"\") && !filename.Trim().EndsWith(@"\"))
                        location += @"\";
                    else if (location.Trim().EndsWith(@"\") && filename.Trim().StartsWith(@"\"))
                        location = location.Substring(0, location.Length - 1);
                }
                //
                //Assigning content
                int ColNum = 1;
                foreach (TextParameterInfo _param in TextParamInfo)
                {
                        FieldNames += string.Format("{0}({1}){2}", _param.Name.TrimStart().TrimEnd(),ColNum, splitChar.ToString());
                        content += string.Format("{0}{1}", _param.Value.TrimStart().TrimEnd(), splitChar.ToString());
                        ++ColNum;
                }
                if (content.Length < 1)
                {
                    //nothing to write
                    return false;
                }
                if (FieldNames.Length > 1) // double check fields
                {
                    FieldNames = FieldNames.Substring(0, FieldNames.Length - 1);
                }
                content = content.Substring(0, content.Length - 1);
                //Assigning header
                if (headerInfo && !AppendTxt)
                {
                    header[0] = string.Format("{0}", "#######################################################################");
                    header[1] = string.Format("\n# Directory    : {0}", location.TrimStart().TrimEnd());
                    header[2] = string.Format("\n# Filename     : {0}", filename.TrimStart().TrimEnd());
                    header[3] = string.Format("\n# Date Created : {0}", DateTime.Now);
                    header[4] = string.Format("\n# Max Field(s) : {0}", TextParamInfo.Length);
                    header[5] = string.Format("\n# Split Char   : {0}", splitChar);
                    header[6] = string.Format("\n# FieldName(s) : {0}", FieldNames);
                    header[7] = string.Format("\n{0}", "#######################################################################");
                }
                // create directory
                if (System.IO.Directory.Exists(location) != true)
                {
                    Directory.CreateDirectory(location);
                }

                // create filename
                string CreatedFile = location + filename;
                FileStream FS = null;

                //write or append txt
                if (!AppendTxt)
                {
                    if (File.Exists(CreatedFile))
                    {
                        File.Delete(CreatedFile);
                    }
                    using (FS = File.Create(CreatedFile)) { }
                    FS.Close();
                    StreamWriter TXT_WRITE = new StreamWriter(CreatedFile);
                    if (header != null && headerInfo && !AppendTxt)
                    {
                        foreach (string _header in header)
                            TXT_WRITE.WriteLine(_header);
                    }
                    TXT_WRITE.WriteLine(content);
                    TXT_WRITE.Close();
                    Written = true;
                }
                else
                {
                    FileStream FSAppend = new FileStream(CreatedFile, FileMode.Append, FileAccess.Write);
                    StreamWriter TXT_WRITE = new StreamWriter(FSAppend);
                    if (header != null && headerInfo && !AppendTxt)
                    {
                        foreach (string _header in header)
                            TXT_WRITE.WriteLine(_header);
                    }
                    TXT_WRITE.WriteLine(content);
                    TXT_WRITE.Close();
                    FSAppend.Close();
                    Written = true;
                }

            }
            catch (Exception ex) 
            {
                Written = false;
                CommonFunctions.MessageShow(ex.ToString()); 
            }
            return Written;
        }
        
        #endregion WriteTextData

        /// Author : Nilo L. Luansing Jr.
        /// Desc   : Text file parsing generic functions
        /// Date   : 07/07/2012
        #region GetTextData [Generic Text file reading functions]
       
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get the data from the text file and return as an Array of string.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static string[] GetTextData(string FileFullPath, string[] Param)
        {
            return GetTextData(FileFullPath, Param, false);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get the data from the text file and return as an Array of string.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static string[] GetTextData(string FileFullPath, string[] Param, bool filterData)
        {
            return GetTextData(FileFullPath, "", Param, filterData);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get the data from the text file and return as an Array of string.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="filename"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static string[] GetTextData(string location, string filename, string[] Param)
        {
            return GetTextData(location, filename, Param, false);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get the data from the text file and return as an Array of string.
        /// Filter Data allows to check if the data exist on the text file.
        /// Return a null string Array if not found.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="filename"></param>
        /// <param name="Param"></param>
        /// <param name="filterData"></param>
        /// <returns></returns>
        public static string[] GetTextData(string location, string filename, string[] Param, bool filterData)
        {
            return GetTextData(location, filename, Param, filterData, true);
        }
        /// <summary> 
        /// Supplied with the full path and file name.
        /// Get the data from the text file and return as an Array of string.
        /// Filter Data allows to check if the data exist on the text file.
        /// Allows to check with key sensitivity.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="filename"></param>
        /// <param name="Param"></param>
        /// <param name="filterData"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static string[] GetTextData(string location, string filename, string[] Param, bool filterData, bool ignoreCase)
        {
            return GetTextData(location, filename, Param, filterData, ignoreCase, false);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get the data from the text file and return as an Array of string.
        /// Filter Data allows to check if the data exist on the text file.
        /// Allows to check with key sensitivity.
        /// Allows to include comments as valid data.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="filename"></param>
        /// <param name="Param"></param>
        /// <param name="filterData"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="includeComment"></param>
        /// <returns></returns>
        public static string[] GetTextData(string location, string filename, string[] Param, bool filterData, bool ignoreCase, bool includeComment)
        {
            return GetTextData(location, filename, Param, filterData, ignoreCase, includeComment, ',');
        }

        public static string[] GetTextData(string location, string filename, string[] Param, bool filterData, bool ignoreCase, bool includeComment, char splitChar)
        {
            bool isExist = false;
            try
            {
                //Location/File name setter
                if (location.Trim() != string.Empty && filename.Trim() != string.Empty)
                {
                    if (!location.Trim().EndsWith(@"\") && !filename.Trim().EndsWith(@"\"))
                        location += @"\";
                    else if (location.Trim().EndsWith(@"\") && filename.Trim().StartsWith(@"\"))
                        location = location.Substring(0, location.Length - 1);
                }
                //check if MIT LOG Exist
                if (!isFileExist(location, filename))
                {
                    Param = null;
                    return Param;
                }
                String TextLine = "";
                String[] TextData;
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(location+filename);

                while (objReader.Peek() != -1)
                {
                    TextLine = objReader.ReadLine();
                    TextData = TextLine.Split(splitChar);
                    if (TextLine.Trim() != String.Empty)
                    {
                        try
                        {
                            if (TextLine.TrimStart().StartsWith("#") && !includeComment) //set # as comment for textfile
                                continue;
                            else if (Param == null && filterData)
                                return Param;
                            else if (Param.Length > TextData.Length && filterData) //Check if Parameters has greater dimension
                                continue;

                            if (!filterData)
                            {
                                int i = 0;
                                foreach (string _text in TextData)
                                {
                                    //Check if the Text data is not exceeding the dimension of param
                                    if (i < Param.Length)
                                    {
                                        Param[i] = _text.TrimStart().TrimEnd();
                                        ++i;
                                    }
                                }
                                //Set is exist as true by defualt
                                isExist = true;
                            }
                            else  //Check if data is in text file
                            {
                                try
                                {

                                    int i = 0;
                                    int CompareCount = 0;
                                    //Getting the max index of the Param
                                    if (Param != null)
                                    {
                                        foreach (string param in Param)
                                        {
                                            //include empty param
                                            if (string.IsNullOrEmpty(param.TrimStart().TrimEnd()))
                                            {
                                                ++i;
                                                ++CompareCount;
                                                continue;
                                            }

                                            if (ignoreCase)
                                            {
                                                if (param.TrimStart().TrimEnd().ToUpper() == TextData[i].TrimStart().TrimEnd().ToUpper())
                                                {
                                                    Param[i] = TextData[i].Trim();
                                                    ++CompareCount;
                                                }
                                            }
                                            else
                                            {
                                                if (param.TrimStart().TrimEnd() == TextData[i].TrimStart().TrimEnd())
                                                {
                                                    Param[i] = TextData[i].Trim();
                                                    ++CompareCount;
                                                }
                                            }
                                            ++i;
                                        }

                                        //Check if found
                                        if ((CompareCount == Param.Length && CompareCount > 0) || (isExist))
                                        {
                                            objReader.Close();
                                            return Param;
                                        }
                                    }
                                }
                                catch
                                { Param = null; }

                            }
                        }
                        catch
                        { Param = null; }
                    }
                }
                objReader.Close();
            }
            catch (Exception ex) { CommonFunctions.MessageShow(ex.ToString()); }
            if (!isExist)
            {
                Param = null;
            }
            return Param;

        }
        #endregion GetTextData
        
        /// Author : Nilo L. Luansing Jr.
        /// Desc   : Datatable to Text File Generic funtions
        /// Date   : 07/12/2012
        #region WriteTextDataTable [Generic Datatable to Textfile Functions]
        /// <summary>
        /// Supplied with the full path and file name.
        /// Write datatable content into a text file.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static int WriteTextDataTable(string location, string filename, DataTable Table)
        {
            return WriteTextDataTable(location, filename, Table, "");
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Write datatable content into a text file.
        /// Allow to assign Table Name.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static int WriteTextDataTable(string location, string filename, DataTable Table, String TableName)
        {
            return WriteTextDataTable(location, filename, Table, TableName, true);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Write datatable content into a text file.
        /// Allow to assign Table Name.
        /// Allow to write Header Information.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static int WriteTextDataTable(string location, string filename, DataTable Table, String TableName, bool headerInfo)
        {
            return WriteTextDataTable(location, filename, Table, TableName, headerInfo, false);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Write datatable content into a text file.
        /// Allow to assign Table Name.
        /// Allow to write Header Information.
        /// Allow to Append content of datatable.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static int WriteTextDataTable(string location, string filename, DataTable Table, String TableName, bool headerInfo, bool AppendTxt)
        {
            return WriteTextDataTable(location, filename, Table, TableName, headerInfo, AppendTxt, ',');
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Write datatable content into a text file.
        /// Allow to assign Table Name.
        /// Allow to write Header Information.
        /// Allow to Append content of datatable.
        /// Allow to set Split Characters.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static int WriteTextDataTable(string location, string filename, DataTable Table, String TableName, bool headerInfo, bool AppendTxt, char SplitChar)
        {
            int WrittenRow = 0;
            if (Table == null)
                return 0;
            else if (Table.Rows.Count == 0)
                return 0;
            else
            {
                try
                {
                    string[] header = new string[10];
                    string FieldName = string.Empty;
                    int FieldNameCtr = 0;
                    string content = string.Empty;
                    //Location/File name setter
                    if (location.Trim() != string.Empty && filename.Trim() != string.Empty)
                    {
                        if (!location.Trim().EndsWith(@"\") && !filename.Trim().EndsWith(@"\"))
                            location += @"\";
                        else if (location.Trim().EndsWith(@"\") && filename.Trim().StartsWith(@"\"))
                            location = location.Substring(0, location.Length - 1);
                    }

                    //Assigning header
                    if (headerInfo && !AppendTxt)
                    {
                        header[0] = string.Format("{0}", "#######################################################################");
                        header[1] = string.Format("\n# Directory    : {0}", location.TrimStart().TrimEnd());
                        header[2] = string.Format("\n# Filename     : {0}", filename.TrimStart().TrimEnd());
                        header[3] = string.Format("\n# Date Created : {0}", DateTime.Now);
                        header[4] = "\n# Max Field(s) : {0}";
                        header[5] = string.Format("\n# Split Char   : {0}", SplitChar);
                        header[6] = string.Format("\n# Row(s) Count : {0}", Table.Rows.Count);
                        header[7] = string.Format("\n# Table Name   : {0}", TableName);
                        header[8] = "\n# FieldName(s) : {0}";
                        header[9] = string.Format("\n{0}", "#######################################################################");
                    }
                    // create directory
                    if (System.IO.Directory.Exists(location) != true)
                    {
                        Directory.CreateDirectory(location);
                    }

                    // create filename
                    string CreatedFile = location + filename;
                    FileStream FS = null;
                    //write or append txt
                    if (!AppendTxt)
                    {
                        if (File.Exists(CreatedFile))
                        {
                            File.Delete(CreatedFile);
                        }
                        using (FS = File.Create(CreatedFile)) { }
                        FS.Close();
                        StreamWriter TXT_WRITE = new StreamWriter(CreatedFile);
                        //Start writting data table content
                        int rowindex = 0;
                        foreach (DataRow row in Table.Rows)
                        {
                            content = string.Empty;
                            foreach (DataColumn column in Table.Columns)
                            {
                                if (rowindex == 0)
                                {
                                    ++FieldNameCtr;
                                    FieldName += column.ColumnName.ToString().TrimStart().TrimEnd();
                                    FieldName += SplitChar;
                                }
                                content += row[column.ColumnName].ToString().TrimStart().TrimEnd();
                                content += SplitChar;
                            }
                            if (rowindex == 0)
                            {
                                FieldName = FieldName.Substring(0, FieldName.Length - 1);
                                header[4] = string.Format(header[4], FieldNameCtr);
                                header[8] = string.Format(header[8], FieldName);
                                if (header != null && headerInfo && !AppendTxt)
                                {
                                    foreach (string _header in header)
                                        TXT_WRITE.WriteLine(_header);
                                }
                            }

                            ++rowindex;

                            content = content.Substring(0, content.Length - 1);
                            TXT_WRITE.WriteLine(content);
                        }
                        TXT_WRITE.Close();
                    }
                    else
                    {
                        FileStream FSAppend = new FileStream(CreatedFile, FileMode.Append, FileAccess.Write);
                        StreamWriter TXT_WRITE = new StreamWriter(FSAppend);
                        if (header != null && headerInfo && !AppendTxt)
                        {
                            foreach (string _header in header)
                                TXT_WRITE.WriteLine(_header);
                        }
                        TXT_WRITE.WriteLine(content);
                        TXT_WRITE.Close();
                        FSAppend.Close();
                    }

                }
                catch (Exception ex) { CommonFunctions.MessageShow(ex.ToString()); }
                return WrittenRow;
            }

        }
        #endregion WriteTextDataTable

        /// Author : Nilo L. Luansing Jr.
        /// Desc   : Text File to Datatable Generic Functions
        /// Date   : 07/12/2012
        #region GetTextDataTable [Generic Text File to DataTable Functions]
        /// <summary>
        /// Supplied with the full path.
        /// Get Text File data and Convert into DataTable.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable GetTextDataTable(string FullPath)
        {
            return GetTextDataTable(FullPath, "");
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get Text File data and Convert into DataTable.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable GetTextDataTable(string location, string filename)
        {
            return GetTextDataTable(location, filename, -1);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get Text File data and Convert into DataTable.
        /// Include comments as valid data.
        /// Base 1 indexing for Duplicate ColumnNumber
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable GetTextDataTable(string location, string filename, int RemoveDupColNumber)
        {
            return GetTextDataTable(location, filename, RemoveDupColNumber, false);
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get Text File data and Convert into DataTable.
        /// Include comments as valid data.
        /// Base 1 indexing for Duplicate ColumnNumber
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable GetTextDataTable(string location, string filename, int RemoveDupColNumber,  bool includeComment)
        {
            return GetTextDataTable(location, filename, RemoveDupColNumber, includeComment,',');
        }
        /// <summary>
        /// Supplied with the full path and file name.
        /// Get Text File data and Convert into DataTable.
        /// Include comments as valid data.
        /// Base 1 indexing for Duplicate ColumnNumber
        /// Set split characters.
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable GetTextDataTable(string location, string filename,int RemoveDupColNumber, bool includeComment, char splitChar)
        {
            DataTable Dt = new DataTable("TABLE");
            DataRow DtRow;
            bool isExist = false;
            try
            {
                //Location/File name setter
                if (location.Trim() != string.Empty && filename.Trim() != string.Empty)
                {
                    if (!location.Trim().EndsWith(@"\") && !filename.Trim().EndsWith(@"\"))
                        location += @"\";
                    else if (location.Trim().EndsWith(@"\") && filename.Trim().StartsWith(@"\"))
                        location = location.Substring(0, location.Length - 1);
                }

                //check if LOG Exist
                if (!isFileExist(location, filename))
                {
                    Dt = null;
                    return Dt;
                }
                String TextLine = "";
                String[] TextData;

                //Variables for Max Split retrieval
                int MaxSplit = 0;
                int TempMaxSplit = 0;
                //Adding Index Column to table
                DataColumn Dtculomn = Dt.Columns.Add("INDEX", typeof(Int32));
                int RefIndex = 0;
                
                //reading and assigning to TempTable
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(location + filename);
                while (objReader.Peek() != -1)
                {
                    TextLine = objReader.ReadLine();
                    TextData = TextLine.Split(splitChar);
                    if (TextLine.Trim() != String.Empty)
                    {

                        if (TextLine.TrimStart().StartsWith("#") && !includeComment) //set # as comment for textfile
                            continue;

                        //Getting Max Split to check if new column must be added (optimize 10/16/2012)
                        TempMaxSplit = TextLine.Split(splitChar).Length;
                        if (TempMaxSplit > MaxSplit)
                        {
                            for (int j = MaxSplit; j < TempMaxSplit; j++)
                            {
                                //Base 1 for Column Number
                                Dt.Columns.Add(string.Format("COLUMN_{0}", j+1), typeof(String));
                            }
                            Dt.AcceptChanges();
                            MaxSplit = TempMaxSplit;
                        }


                        //Removing Duplicates
                        if (RemoveDupColNumber >= 0 && RemoveDupColNumber<=MaxSplit)
                        {
                            //Delete if existing from datatable
                            DataRow[] rows = Dt.Select(string.Format("COLUMN_{0} = '{1}'", RemoveDupColNumber, TextData[RemoveDupColNumber-1].Trim()));
                            foreach (DataRow row in rows)
                            {
                                row.Delete();
                            }
                            Dt.AcceptChanges();
                        }
                        //end

                        int Col = 1;
                        //Declaring New Row
                        DtRow = Dt.NewRow();
                        foreach (string Data in TextData)
                        {
                            if(!string.IsNullOrEmpty(Data.Trim()))
                                DtRow[string.Format("COLUMN_{0}", Col)] = Data;
                            ++Col;
                        }
                        DtRow["INDEX"] = RefIndex;
                        Dt.Rows.Add(DtRow);
                        Dt.AcceptChanges();

                        ++RefIndex;
                    }
                }
                objReader.Close();
                
            }
            catch (Exception ex) { CommonFunctions.MessageShow(ex.ToString()); }
            if (Dt != null)
            {
                DataView dv = Dt.DefaultView;
                dv.Sort = "INDEX DESC";
                DataTable SortDt = dv.ToTable();
                return SortDt;
            }
            else
                return Dt;

        }
        #endregion GetTexDataTable

        /// Author : Nilo L. Luansing Jr.
        /// Desc   : Text File Updating Generic Function from Temp to Current and Backup Current to Bak
        /// Date   : 07/12/2012
        #region FileUpdateHandler [Generic Textfile Update Handling [*.Temp.log]->[*.log]->[*.Bak.log]]

        public static bool FileUpdateHandler(string CurrentFileName)
        {
            return FileUpdateHandler(CurrentFileName, false); //Does not clear file by default
        }
        public static bool FileUpdateHandler(string CurrentFileName, bool ClearFile)
        {
            bool Written = false;
            string location = HandyPath;
            try
            {
                //Location/File name setter
                if (location.Trim() != string.Empty && CurrentFileName.Trim() != string.Empty)
                {
                    if (!location.Trim().EndsWith(@"\") && !CurrentFileName.Trim().EndsWith(@"\"))
                        location += @"\";
                    else if (location.Trim().EndsWith(@"\") && CurrentFileName.Trim().StartsWith(@"\"))
                        location = location.Substring(0, location.Length - 1);
                }

                // create directory
                if (System.IO.Directory.Exists(location) != true)
                {
                    Directory.CreateDirectory(location);
                }

                // create filename
                string BackFile = location + CurrentFileName.Replace(".log", ".Bak.log");
                string CurrentFile = location + CurrentFileName;
                string TempFile = location + CurrentFileName.Replace(".log", ".Temp.log");
                FileStream FS = null;

                //deleting bak file
                if (File.Exists(BackFile))
                {
                    File.Delete(BackFile);
                }
                //renaming current file to bak
                if (File.Exists(CurrentFile))
                {
                    File.Move(CurrentFile, BackFile);
                }
                //renaming temp to current file
                if (File.Exists(TempFile))
                {
                    File.Move(TempFile, CurrentFile);
                    Written = true;
                }

                //Rechecking if file still exist if not then Create Empty current File
                if (!File.Exists(CurrentFile) && !ClearFile)
                {
                    //try rollback bak file to current file
                    if (File.Exists(BackFile))
                    {
                        File.Move(BackFile, CurrentFile);
                    }
                    else // create empty current File
                    {
                        using (FS = File.Create(CurrentFile)) { }
                        FS.Close();
                    }
                    Written = false;
                }
                else if (ClearFile)
                {
                    // create empty current File
                    using (FS = File.Create(CurrentFile)) { }
                    FS.Close();
                    Written = true;
                }
            }
            catch
            {
                Written = false;
            }
            return Written;
        }

        #endregion FileUpdateHandler

        #endregion Common

        public static bool RollBackMITFile()
        {
            bool Written = false;
            string location = HandyPath;
            try
            {
                // create directory
                if (System.IO.Directory.Exists(location) != true)
                {
                    Directory.CreateDirectory(location);
                }
                
                // create filename
                string MITBack = location + @"MIT.Bak.log";
                string MITCurrent = location + @"MIT.log";
                string MITTemp = location + @"MIT.Temp.log";
                FileStream FS = null;

                //renaming mit to temp for rollback if not successfull current MIT
                if (File.Exists(MITCurrent))
                {
                    File.Move(MITCurrent,MITTemp);
                }
                //renaming mit bak to current file  - start roll back
                if (File.Exists(MITBack))
                {
                    File.Move(MITBack, MITCurrent);
                    Written = true;
                }
                
                //Rechecking if MIT was successfully rolled back
                if (!File.Exists(MITCurrent))
                {
                    //try rollback temp file
                    if (File.Exists(MITTemp))
                    {
                        File.Move(MITTemp, MITCurrent);
                    }
                    else // create empty MIT File
                    {
                        using (FS = File.Create(MITCurrent)) { }
                        FS.Close();
                    }
                    Written = false;
                }
                
                //Deleting temp file
                if (File.Exists(MITTemp))
                {
                    File.Delete(MITTemp);
                }
            }
            catch
            {
                Written = false;
            }
            return Written;
        }
    }
    /// <summary>
    /// Texfile Paramater Information Handler
    /// </summary>
    public class TextParameterInfo
    {
        public string Name;
        public string Value;
 
        public TextParameterInfo(string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramName))
                paramName = "";
            if (string.IsNullOrEmpty(paramValue))
                paramValue = "";
            Name = paramName;
            Value=paramValue;
        }
    }

    public class FilePathFormatter
    {
        public string Directory;
        public string FileName;
        public string FullFilePath;

        public FilePathFormatter(string location, string filename)
        {
            
            //Location/File name setter
            if (location.Trim() != string.Empty && filename.Trim() != string.Empty)
            {
                if (!location.Trim().EndsWith(@"\") && !filename.Trim().EndsWith(@"\"))
                    location += @"\";
                else if (location.Trim().EndsWith(@"\") && filename.Trim().StartsWith(@"\"))
                    location = location.Substring(0, location.Length - 1);
            }

            this.Directory = location;
            this.FileName = filename;
            this.FullFilePath = this.Directory + this.FileName;
        }
    }
}
