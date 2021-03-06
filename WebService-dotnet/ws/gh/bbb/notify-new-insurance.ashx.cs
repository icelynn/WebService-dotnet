﻿using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using WebServices.Utility;
using WebServices.Utility.Parse;

namespace WebServices.ws.gh.bbb
{
    /// <summary>
    /// Summary description for notify_new_insurance
    /// </summary>
    public class notify_new_insurance : HttpTaskAsyncHandler
    {
        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Request.ContentType = "application/json";
        //    System.Collections.Generic.Dictionary<string, string> content = ContentParser.FromInputStream(context.Request.InputStream);

        //    string downloadUrl = @"http://localhost:8086/uat/filedownload.ashx";
        //    Downloader downloader = new Downloader(content, "bbb", new Uri(downloadUrl), @"D:\Projects\WebServices\");
        //    DownloadResult result = downloader.Result;

        //    context.Response.ContentType = "application/json";
        //    context.Response.Write(result.ToString());
        //    context.Response.StatusCode = Convert.ToInt32(result.StatusCode);
        //}

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            context.Request.ContentType = "application/json";
            System.Collections.Generic.Dictionary<string, string> content = ContentParser.FromInputStream(context.Request.InputStream);

            Downloader downloader = new Downloader(content, "bbb", @"D:\Projects\WebServices\WebServices\insurersinfo.ini");
            await downloader.Launch();
            DownloadResult result = downloader.Result;

            context.Response.ContentType = "application/json";
            context.Response.Write(result.ToString());
            context.Response.StatusCode = Convert.ToInt32(result.StatusCode);
        }

        public override bool IsReusable => false;
    }


}