using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace RestrictingByIP
{
    public class JpgHandler : IHttpHandler
    {
 
        public bool IsReusable
        {
            
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.FilePath; // путь к запрашиваемому файлу
         
            List<string> blacklist = new List<string>(); //список запрещенных адресов 
            
            using (StreamReader streamReader = new StreamReader(HostingEnvironment.ApplicationPhysicalPath + "/Blacklist.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    blacklist.Add(line);
                    Console.WriteLine(line);
                }
            }

            string headerXFF = context.Request.Headers["X-Forwarded-For"].Split(new char[] { ',' }).FirstOrDefault(); // вытаскиваем ip-адресс

            if (blacklist.Contains(headerXFF)) // если он есть в черном списке 
            {
                context.Response.Write(null); // пустой ответ (покажет alt тега <img>)
            }
            else
            {
                try
                {
                    context.Response.WriteFile(path); // картинка в ответе
                }
                catch (FileNotFoundException)
                {
                    context.Response.StatusCode = 404;
                }
            }
               
        }

    }
}
