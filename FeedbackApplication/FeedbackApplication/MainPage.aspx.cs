using System;
using System.Web;

namespace FeedbackApplication
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["counter"] != null)
            if (Session["counter"] != null && Session["feedback"] == null) // если вход на страницу feedback был, но комментарий не оставлен
            {
                Response.Write("<h1>Might you have some information to let us know? Please put it here (<a href='FeedbackPage.aspx'>Feedback</a>) </h1>");
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnEndSession_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // вызов cобытия Session_End
            Response.Redirect(Request.Url.PathAndQuery); // перезагрузка страницы
        }

        protected void btnStopSite_Click(object sender, EventArgs e)
        {
            HttpRuntime.UnloadAppDomain(); // вызов события Application_End
            btnRefresh.Visible = true;
            lblWarning.Visible = true;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.PathAndQuery);
            btnRefresh.Visible = false;
            lblWarning.Visible = false;
        }
    }
}