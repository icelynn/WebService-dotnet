using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.Models.External
{
    public class TokenErrorModel
    {
        //private Dictionary _errors;
        private Dictionary<string, string> _errors;

        public TokenErrorModel()
        {
            ErrorsInitialize();
        }

        public Dictionary<string, string> ParamaterError()
        {
            _errors["Message"] = "An error has occurred.";
            _errors["ErrorCode"] = "11";
            _errors["ErrorMessage"] = "Token and Insurer are required, make sure you enter the contents and try again!";

            return _errors;
        }

        public Dictionary<string, string> NotFoundError()
        {
            _errors["Message"] = "An error has occurred.";
            _errors["ErrorCode"] = "14";
            _errors["ErrorMessage"] = "User not found.";

            return _errors;
        }

        public Dictionary<string, string> ParseError(string errorCode)
        {
            switch (errorCode)
            {
                case "12":
                    _errors["Message"] = "An error has occurred.";
                    _errors["ErrorCode"] = "12";
                    _errors["ErrorMessage"] = "Token expired.";
                    break;

                case "13":
                    _errors["Message"] = "An error has occurred.";
                    _errors["ErrorCode"] = "13";
                    _errors["ErrorMessage"] = "Illegal token.";
                    break;

                default:
                    break;
            }

            return _errors;
        }

        private void ErrorsInitialize()
        {
            _errors = new Dictionary<string, string>()
            {
                { "Message", "" },
                { "ErrorCode", "" },
                { "ErrorMessage", "" }
            };
        }
    }
}
