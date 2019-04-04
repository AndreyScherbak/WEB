using System;
using System.IO;
using System.Web.Hosting;

namespace FeedbackApplication
{
    public class Global : System.Web.HttpApplication
    {
     
        protected void Application_Start(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + "/Log.txt", true))
            {
                streamWriter.WriteLine("The site is running. Date: {0}", DateTime.Now);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
             if (Session["counter"] != null) // были ли входы на страницу feedback
             {
                 using (StreamWriter streamWriter = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + "/Log.txt", true))
                 {
                     streamWriter.WriteLine("Total number of visits feedback page: {0}", Session["counter"]);
                     streamWriter.WriteLine("Feedback: {0}", Session["feedback"]);
                 }
             }
        }


        protected void Application_End(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + "/Log.txt", true))
            {
                streamWriter.WriteLine("The site is stopped. Date: {0}", DateTime.Now);
            }
        }
    }
}