using System;
using System.Linq;
using System.Web;
using WebServices.Utility;
using WebServices.Utility.Parse;

namespace WebServices.ws.gh.bbb
{
    /// <summary>
    /// </summary>
    public class verify_salesinfo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            System.Collections.Generic.Dictionary<string, string> content = ContentParser.FromURL(context);

            // Start handling
            TokenHandle handler = new TokenHandle(content, "prop");
            TokenHandleResult result = handler.HandleResult;

            context.Response.ContentType = "application/json";
            context.Response.Write(result.ToString());
            context.Response.StatusCode = Convert.ToInt32(result.StatusCode);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}