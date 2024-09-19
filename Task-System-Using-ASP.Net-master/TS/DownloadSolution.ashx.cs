using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TS
{
    /// <summary>
    /// Summary description for DownloadSolution
    /// </summary>
    public class DownloadSolution : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request.QueryString["file"];
            if (!string.IsNullOrEmpty(file))
            {
                string filePath = context.Server.MapPath("~/user/Solution/") + file;

                if (File.Exists(filePath))
                {
                    try
                    {
                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        context.Response.TransmitFile(filePath);
                        context.Response.End();
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.Write("Error: " + ex.Message);
                        context.Response.End();
                    }
                }
                else
                {
                    context.Response.StatusCode = 404;
                    context.Response.Write("File not found.");
                    context.Response.End();
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Bad Request: File parameter is missing.");
                context.Response.End();
            }
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