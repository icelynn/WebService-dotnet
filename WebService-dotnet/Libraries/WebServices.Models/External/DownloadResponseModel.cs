using System.Collections.Generic;
using WebServices.Utility.Parse;

namespace WebServices.Models.External
{
    public class DownloadResponseModel
    {
        public Dictionary<string, object> ResponseInfo { get; private set; }

        public DownloadResponseModel(string serialNumber, ResponseInfo info)
        {
            Initialize(serialNumber);
            SetResponseState(info);
        }

        private void Initialize(string serialNumber)
        {
            this.ResponseInfo = new Dictionary<string, object>()
            {
                { "ResponseCode" , "" },
                { "ResponseMessage" , "" },
                { "ResponseObj" , serialNumber }
            };
        }

        public void SetResponseState(ResponseInfo info)
        {
            this.ResponseInfo["ResponseCode"] = info.ResponseCode();
            this.ResponseInfo["ResponseMessage"] = info.ResponseMessage();
        }

        public override string ToString()
        {
            string output = JsonParser.SerializeDictionary(this.ResponseInfo);
            return output;
        }
    }
}
