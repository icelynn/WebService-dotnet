using System.Collections.Generic;
using WebServices.Models.Database;
using WebServices.Utility.Parse;

namespace WebServices.Utility
{
    public class TokenHandleResult
    {
        private readonly bool _successed;
        private readonly SalesInfo _salesInfo;
        private readonly string _insurer = string.Empty;
        private readonly Dictionary<string, string> _errors;

        public string StatusCode { get; }

        // Return the SalesInfo if successed with nothing gone wrong
        public TokenHandleResult(SalesInfo salesInfo, string insurer)
        {
            this._insurer = insurer;
            this._successed = true;
            this._salesInfo = salesInfo;
            this.StatusCode = "200";
        }

        // Return a result with error message if failed
        public TokenHandleResult(Dictionary<string, string> errors)
        {
            this._successed = false;
            this._errors = errors;
            this.StatusCode = "400";
        }

        public override string ToString()
        {
            if (_successed)
            {
                string jsonSalesInfo = JsonParser.SerializeSalesInfo(_salesInfo);
                return jsonSalesInfo;
            }
            else
            {
                string jsonErrors = JsonParser.SerializeStrDictionary(_errors);
                return jsonErrors;
            }
        }
    }
}