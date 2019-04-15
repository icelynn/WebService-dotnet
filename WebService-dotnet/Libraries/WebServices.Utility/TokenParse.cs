using System;
using System.Collections.Generic;
using System.Text;
using Jose;

namespace WebServices.Utility
{
    internal class TokenParse
    {
        private readonly string _accessToken = null;
        private readonly string _insurer = null;
        private readonly string secret = "StuDIUOsGarBAnzO";

        public TokenParseResult Result;

        /// <summary>
        ///  Find out the User who issued the request
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="insurer"></param>
        public TokenParse(string accessToken, string insurer)
        {
            this._accessToken = accessToken;
            this._insurer = insurer;
        }

        internal TokenParseResult GetUserGUID()
        {
            var jwtObject = Jose.JWT.Decode<Dictionary<string, object>>(
                _accessToken,
                Encoding.UTF8.GetBytes(secret),
                JwsAlgorithm.HS256
                );

            if (!IsTokenExpired((DateTime)jwtObject["Exp"]))
            {
                if (String.Equals(jwtObject["Insurer"].ToString(), _insurer))
                {
                    Guid guid = new Guid(jwtObject["UserGUID"].ToString());
                    return this.Result = new TokenParseResult(true, guid);
                }
                else
                {
                    // Indicates that the insurer does not match that in the token
                    this.Result = new TokenParseResult(errorCode: "13");
                }
            }
            else
            {
                // Token expired
                this.Result = new TokenParseResult(errorCode: "12");
            }

            return this.Result;
        }

        private bool IsTokenExpired(DateTime input)
        {
            DateTime currentTime = DateTime.UtcNow;
            return Convert.ToDateTime(input) < currentTime;
        }
    }
}
