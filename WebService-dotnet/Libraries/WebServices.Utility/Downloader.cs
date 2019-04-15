using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebServices.Models.External;
using WebServices.Utility.Parse.File;

namespace WebServices.Utility
{
    /// <summary>
    /// Contains the methods to validate the input and launch a request to insurer downloadlink.
    /// </summary>
    public class Downloader
    {
        private readonly string _fileName = String.Empty;
        private readonly string _fileDir = String.Empty;
        private readonly Uri _requestUri;
        private string _barcode = String.Empty;
        private string _serialNumber = String.Empty;
        private ResponseInfo _downloadStatus = null;

        public DownloadResult Result { get; private set; }

        /// <summary>
        /// Deserialize the json into Dcitionary, then Launch the insurer Web service to download the file.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="insurer"></param>
        /// <param name="iniFilePath"></param>
        public Downloader(Dictionary<string, string> content, string insurer, string iniFilePath)
        {
            ValidateInputStream(content);

            this._requestUri = new Uri(FileParse.FromIni(iniFilePath, insurer, "downloaduri"));
            this._fileDir = FileParse.FromIni(iniFilePath, insurer, "filedir");
            this._fileName = this._fileDir + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + _serialNumber + ".zip";
        }

        /// <summary>
        /// Spawn the connection to SKL Web Service.
        /// </summary>
        public async Task Launch()
        {
            if (this.Result == null)
            {
                if (String.IsNullOrEmpty(this._serialNumber))
                {
                    this.Result = new DownloadResult(_serialNumber, ResponseSet.SerialNumNotFoundError);
                }
                else if (String.IsNullOrEmpty(this._barcode) || String.IsNullOrEmpty(this._fileDir) || this._requestUri == null)
                {
                    this.Result = new DownloadResult(this._serialNumber, ResponseSet.InternalError);
                }
                else
                {
                    DownloadLaunch launcher = new DownloadLaunch(this._requestUri, this._fileName, "Y22L00", this._barcode);
                    StatusCheck( await launcher.SendAsync() );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        private void ValidateInputStream(Dictionary<string, string> content)
        {
            string number, barcode;

            if (content.TryGetValue("serialNumber", out number) && content.TryGetValue("barcode", out barcode))
            {
                this._serialNumber = number;
                this._barcode = barcode;
            }
            else
                this.Result = new DownloadResult("", ResponseSet.FieldsError);
        }

        private void StatusCheck(string statusCode)
        {
            if (statusCode == "InternalServerError")
            {
                this._downloadStatus = ResponseSet.InternalError;
            }
            else if (statusCode == "12")
            {
                this._downloadStatus = ResponseSet.PDFDownloadFailureError;
            }
            else
                this._downloadStatus = ResponseSet.DownloadSuccess;

            this.Result = new DownloadResult(this._serialNumber, this._downloadStatus);
        }

        //private void CompatibilityCheck()
        //{

        //}
    }
}
