using System.Collections.Generic;
using Newtonsoft.Json;
using WebServices.Utility.Parse;

namespace WebServices.Utility
{
    public class PolicyHandleResult
    {
        private readonly bool _successed;
        private readonly Dictionary<string, string> _errors;

        public string StatusCode { get; }

        public PolicyHandleResult()
        {
            this._successed = true;
            this.StatusCode = "201";
        }

        public PolicyHandleResult(Dictionary<string, string> errors)
        {
            this._successed = false;
            this._errors = errors;
        }

        public override string ToString()
        {
            if(_successed)
            {
                var output = new
                {
                    ResponseCode = "00",
                    ResponseMessage = "success"
                };
                return JsonConvert.SerializeObject(output, Formatting.Indented);
            }
            else
            {
                return JsonParser.SerializeStrDictionary(_errors);
            }
        }
    }
}