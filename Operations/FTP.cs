using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SecondChance
{
    class FTP
    {
       private mainForm _mF;
       internal bool IsCancelPending = false;

        public FTP(mainForm main)
        {
            this._mF = main;
        }

        internal void UploadFile(string FTPAddress, string filePath, string username, string password)
        {
            FileInfo fileInf = new FileInfo(filePath);

             FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));

            
            reqFTP.Credentials = new NetworkCredential(username, password);
            reqFTP.KeepAlive = false;
            reqFTP.UsePassive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = filePath.Length;


           
            int buffLength = 4096;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    //update progressBar on workWindow
                    this._mF.WWin.FTPProgBarUpdate(Convert.ToInt32(fs.Length), Convert.ToInt32(fs.Position));
                    //write file to ftp stream.
                    strm.Write(buff, 0, contentLen);
                    if (IsCancelPending)
                    {                      
                        break;
                    }
                    contentLen = fs.Read(buff, 0, buffLength);
                   
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Upload Error");
            }

        }
        internal bool AutoUploadFile(string FTPAddress, string filePath, string username, string password)
        {
            FileInfo fileInf = new FileInfo(filePath);

            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));


            reqFTP.Credentials = new NetworkCredential(username, password);
            reqFTP.KeepAlive = false;
            reqFTP.UsePassive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = filePath.Length;



            int buffLength = 4096;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {                   
                    //write file to ftp stream.
                    strm.Write(buff, 0, contentLen);
                    if (IsCancelPending)
                    {
                        break;
                    }
                    contentLen = fs.Read(buff, 0, buffLength);

                }
                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
                return true;
                
            }
            catch (Exception ex)
            {
                //write error to eventlog
                this._mF.WriteLog("An error occured with the upload the error was:\r\n" + ex.Message,2);
                return false;
            }

        }
       
    }
}
