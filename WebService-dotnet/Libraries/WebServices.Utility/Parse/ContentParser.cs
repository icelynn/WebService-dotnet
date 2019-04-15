using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebServices.Utility.Parse
{
    /// <summary>
    /// 處理 Http Request 的內容 (不包含Header)。
    /// </summary>
    public static class ContentParser
    {
        /// <summary>
        /// Parse InputStream in the coming Request to Dictionary.
        /// </summary>
        /// <param name="reqStream"></param>
        /// <returns></returns>
        public static Dictionary<string, string> FromInputStream(Stream reqStream)
        {
            StreamReader reader = new StreamReader(reqStream);
            string inputJson = reader.ReadToEnd();
            return JsonParser.DeserializeStrDict(inputJson);
        }

        /// <summary>
        /// Parse URL parameters to Dictionary.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Dictionary<string, string> FromURL(HttpContext context)
        {
            Uri actualURL = new Uri(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.RawUrl);

            string token = HttpUtility.ParseQueryString(actualURL.Query).Get("token");
            string insurer = HttpUtility.ParseQueryString(actualURL.Query).Get("insurer");

            Dictionary<string, string> input = new Dictionary<string, string>()
            {
                { "token",  token},
                { "insurer", insurer }
            };

            return input;
        }
    }
}
