using System;
using WebServices.Models.External;

namespace WebServices.Utility
{
    public class DownloadResult
    {
        public bool Success { get; private set; }
        public string StatusCode { get; }
        public DownloadResponseModel ResponseModel { get; }

        public DownloadResult(string serialNumber, ResponseInfo info)
        {
            this.ResponseModel = new DownloadResponseModel(serialNumber, info);
        }

        public override string ToString()
        {
            return ResponseModel.ToString();
        }
    }
}