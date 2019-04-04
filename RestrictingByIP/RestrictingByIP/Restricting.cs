using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace RestrictingByIP
{
    public class Restricting : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
           context.AuthenticateRequest += OnAuthenticateRequest;
        }

        public void OnAuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication httpApplication = sender as HttpApplication;
            string extension = ".jpg";

            List<string> blacklist = new List<string>();

            using (StreamReader streamReader = new StreamReader(HostingEnvironment.ApplicationPhysicalPath+"/Blacklist.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    blacklist.Add(line);
                }
            }

            string headerXFF = httpApplication.Request.Headers["X-Forwarded-For"].Split(new char[] { ',' }).FirstOrDefault();

            if (httpApplication.Request.Url.ToString().Contains(extension) && blacklist.Contains(headerXFF))
            {     
                httpApplication.Request.Abort(); // завершение
            }
                 
        }
    }
}
